using Microsoft.Extensions.DependencyInjection;
using Quartz;
using Quartz.Spi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuartzSample.Jobs
{
    //public class SingletonJobFactory : IJobFactory
    //{
    //    private readonly IServiceProvider _serviceProvider;
    //    public SingletonJobFactory(IServiceProvider serviceProvider)
    //    {
    //        _serviceProvider = serviceProvider;

    //    }
    //    public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
    //    {
    //        // throw new NotImplementedException();
    //        return _serviceProvider.GetRequiredService(bundle.JobDetail.JobType) as IJob;

    //    }

    //    public void ReturnJob(IJob job)
    //    {
    //        //throw new NotImplementedException();
    //    }
    //}
    public class SingletonJobFactory : IJobFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public SingletonJobFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IJob NewJob(TriggerFiredBundle bundle, IScheduler scheduler)
        {
            return _serviceProvider.GetRequiredService(bundle.JobDetail.JobType) as IJob;

        }

        public void ReturnJob(IJob job)
        {

        }
    }

}
