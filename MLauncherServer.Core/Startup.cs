using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MLauncherServer.Core.Configuration;
using MLauncherServer.Core.Jobs;
using MLauncherServer.Core.Services;
using Quartz;
using Quartz.Impl;
using System;

namespace MLauncherServer.Core
{
    public class Startup
    {
        private readonly Appconfiguration _configuration;

        public Startup()
        {
            var configurationBuilder = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", false, true);

            var configuration = configurationBuilder.Build();

            _configuration = configuration.Get<Appconfiguration>();
        }
        public void Configure(IApplicationBuilder app,IServiceProvider serviceProvider)
        {
            var _scheduler = serviceProvider.GetService<IScheduler>();
            _scheduler.Start().Wait();

            var userManagerJob = JobBuilder.Create<UserManagerJob>()
                .WithIdentity("ManagerJob")
                .Build();

            var userManagerJobTrigger = TriggerBuilder.Create()
                .WithIdentity("ManagerTrigger")
                .StartNow()
                .WithSimpleSchedule(x => x.WithIntervalInSeconds(_configuration.JobIntervalInSeconds)
                .RepeatForever())
                .Build();

            _scheduler.ScheduleJob(userManagerJob, userManagerJobTrigger);
        }
        public virtual IServiceProvider ConfigureServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped(typeof(IDatabaseProvider), typeof(DatabaseProvider));
            serviceCollection.AddScoped(typeof(IUserManagerService), typeof(UserManagerService));
            serviceCollection.AddScoped(typeof(IJob), typeof(UserManagerJob));
            serviceCollection.AddSingleton(_configuration);

            serviceCollection.AddScoped(x =>
            {
                var sched = new StdSchedulerFactory().GetScheduler().Result;
                sched.JobFactory = new JobFactory(serviceCollection.BuildServiceProvider());
                return sched;
            });

            return serviceCollection.BuildServiceProvider();
        }
    }
}