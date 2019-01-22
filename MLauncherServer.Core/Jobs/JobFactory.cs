﻿using Quartz;
using Quartz.Simpl;
using Quartz.Spi;
using System;

namespace MLauncherServer.Core.Jobs
{
    public class JobFactory : SimpleJobFactory
    {
        private readonly IServiceProvider _serviceProvider;
        public JobFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }
        public override IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            return  _serviceProvider.GetService(typeof(IJob)) as IJob;
        }
    }
}
