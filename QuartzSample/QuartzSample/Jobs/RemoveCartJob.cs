using Microsoft.EntityFrameworkCore;
using Quartz;
using QuartzSample.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuartzSample.Jobs
{
    [DisallowConcurrentExecution]
    public class RemoveCartJob : IJob
    {
        //private QuartzSampleDbContext _ctx;

        //public RemoveCartJob(QuartzSampleDbContext ctx)
        //{
        //    ctx = _ctx;
        //}

        public Task Execute(IJobExecutionContext context)
        {
            //var option = new DbContextOptionsBuilder<QuartzSampleDbContext>();
            //option.UseSqlServer("Server=.\\sql2017;Database=QuartzSampleDb;Trusted_Connection=True;MultipleActiveResultSets=true");
            //using (QuartzSampleDbContext _ctx=new QuartzSampleDbContext(option.Options))
            //{
            //    var result = _ctx.Persons.ToList();

            //}

            // throw new NotImplementedException();
           
            return Task.CompletedTask;
        }
    }
}
