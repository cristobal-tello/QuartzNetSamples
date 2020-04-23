using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppNetFramework
{
    class JobListener : IJobListener
    {
        public string Name => "Job Listener name";

        public Task JobExecutionVetoed(IJobExecutionContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => System.Console.WriteLine(string.Format("JobExecutionVetoed. Name: {0}", context.JobDetail.Key.Name)));
        }

        public Task JobToBeExecuted(IJobExecutionContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => System.Console.WriteLine(string.Format("JobToBeExecuted. Name: {0}", context.JobDetail.Key.Name)));
        }

        public Task JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => System.Console.WriteLine(string.Format("JobWasExecuted. Name: {0}", context.JobDetail.Key.Name)));
        }
    }
}
