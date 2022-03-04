using MLauncherServer.Core.Services;
using NLog;
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MLauncherServer.Core.Jobs
{
    public class UserManagerJob : IJob
    {
        private readonly IUserManagerService _userManagerService;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public UserManagerJob(IUserManagerService userManagerService)
        {
            _userManagerService = userManagerService;
        }
        public async Task Execute(IJobExecutionContext context)
        {
            try
            {
                Logger.Info("Starting job execution...");

                await _userManagerService.ProcessUsers();

                Logger.Info("Job execution done.");
            }
            catch (Exception e)
            {
                Logger.Error(e, "An error occured while processing job");
                throw;
            }
        }
    }
}
