using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediaBrowser.Controller.Entities;
using MediaBrowser.Controller.Library;
using MediaBrowser.Model.Activity;
using MediaBrowser.Model.Entities;
using MediaBrowser.Model.Logging;
using MediaBrowser.Model.Tasks;
using XNet.Emby.Plugins.AutoMediaCleaner;

public class AutoMediaCleanScheduledTask : IScheduledTask
{
    private readonly ILibraryManager _libraryManager;
    private readonly IActivityManager _activityManager;
    private readonly IUserManager _userManager;
    private readonly IUserDataManager _userDataManager;
    private readonly ILogger _logger;

    public AutoMediaCleanScheduledTask(ILibraryManager libraryManager, IActivityManager activityManager, IUserManager um, IUserDataManager udm, ILogger logger)
    {
        //var x = udm.GetAllUserData(343);

        _libraryManager = libraryManager ?? throw new ArgumentNullException(nameof(libraryManager));
        _activityManager = activityManager ?? throw new ArgumentNullException(nameof(activityManager));
        _userManager = um ?? throw new ArgumentNullException(nameof(um));
        _userDataManager = udm ?? throw new ArgumentNullException(nameof(udm));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public string Name => "Auto media cleaner";

    public string Key => "XNet.Emby.AutoMediaCleaner";

    public string Description => "Automatically delete stale/unwatched media based on configuration";

    public string Category => "Maintenance";


    public async Task Execute(CancellationToken cancellationToken, IProgress<double> progress)
    {
        _logger.Info("hoi from autocleaner plugin");

        int cutoffDays = 90;
        var items = _libraryManager.GetItemList(new InternalItemsQuery
        {
            MediaTypes = new[] { MediaType.Video },
            IsVirtualItem = false,
            IsFavorite = Plugin.Instance.Configuration.SkipFavorites ? false : default(bool?)
            //                MaxDateLastSaved = DateTime.Now.AddDays(-90),
        }).OfType<Video>().ToList();

        var activityLogItems = _activityManager.GetActivityLogEntries(DateTimeOffset.Now.AddDays(cutoffDays * -1), null, null);
        //_libraryManager.DeleteItem(, new DeleteOptions() { DeleteFileLocation = true });
        var numComplete = 0;



        //var activeItems = activityLogItems.Items.Select(a => a.).ToList();
        foreach (var item in items.Where(item => item.DateCreated < DateTimeOffset.Now.AddDays(cutoffDays * -1)))
        {

            try
            {
                cancellationToken.ThrowIfCancellationRequested();
                await Task.FromResult<string>("hoi");
            }
            catch (OperationCanceledException)
            {
                break;
            }
            catch (Exception ex)
            {
                _logger.ErrorException("Error {0}", ex, item.Name);
            }

            numComplete++;
            double percent = numComplete;
            percent /= items.Count;
            percent *= 100;

            progress.Report(percent);
        }
    }

    public IEnumerable<TaskTriggerInfo> GetDefaultTriggers() => new[]{
            new TaskTriggerInfo {
                Type = TaskTriggerInfo.TriggerDaily,
                TimeOfDayTicks = TimeSpan.FromHours(3).Ticks,
                MaxRuntimeTicks = TimeSpan.FromHours(2).Ticks
            }
        };
}