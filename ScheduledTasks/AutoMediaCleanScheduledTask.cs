using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediaBrowser.Controller.Library;
using MediaBrowser.Model.Logging;
using MediaBrowser.Model.Tasks;

public class AutoMediaCleanScheduledTask : IScheduledTask
{
    private readonly ILibraryManager _libraryManager;
    private readonly ILogger _logger;

    public AutoMediaCleanScheduledTask(ILibraryManager libraryManager, ILogger logger)
    {

        _libraryManager = libraryManager ?? throw new ArgumentNullException(nameof(libraryManager));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public string Name => throw new NotImplementedException();

    public string Key => "XNet.Emby.AutoMediaCleaner";

    public string Description => "Automatically delete stale/unwatched media based on configuration";

    public string Category => "XNet";


    public Task Execute(CancellationToken cancellationToken, IProgress<double> progress)
    {
        throw new NotImplementedException();
    }

    public IEnumerable<TaskTriggerInfo> GetDefaultTriggers() => new[]{
            new TaskTriggerInfo {
                Type = TaskTriggerInfo.TriggerDaily,
                TimeOfDayTicks = TimeSpan.FromHours(3).Ticks,
                MaxRuntimeTicks = TimeSpan.FromHours(2).Ticks
            }
        };
}