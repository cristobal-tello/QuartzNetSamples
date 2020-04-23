using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppNetFramework
{
    class SchedulerListener : ISchedulerListener
    {
        public Task JobAdded(IJobDetail jobDetail, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => System.Console.WriteLine(string.Format("Scheduler Listener. Name: {0}", jobDetail.Key.Name)));
        }

        public Task JobDeleted(JobKey jobKey, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => System.Console.WriteLine(string.Format("Scheduler JobDeleted. Name: {0}", jobKey.Name)));
        }

        public Task JobInterrupted(JobKey jobKey, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => System.Console.WriteLine(string.Format("Scheduler JobInterrupted. Name: {0}", jobKey.Name)));
        }

        public Task JobPaused(JobKey jobKey, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => System.Console.WriteLine(string.Format("Scheduler JobPaused. Name: {0}", jobKey.Name)));
        }

        public Task JobResumed(JobKey jobKey, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => System.Console.WriteLine(string.Format("Scheduler JobResumed. Name: {0}", jobKey.Name)));
        }

        public Task JobScheduled(ITrigger trigger, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => System.Console.WriteLine(string.Format("Scheduler JobScheduled. Name: {0}", trigger.Key.Name)));
        }

        public Task JobsPaused(string jobGroup, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => System.Console.WriteLine(string.Format("Scheduler JobsPaused. Name: {0}", jobGroup)));
        }

        public Task JobsResumed(string jobGroup, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => System.Console.WriteLine(string.Format("Scheduler JobsPaused. Name: {0}", jobGroup)));
        }

        public Task JobUnscheduled(TriggerKey triggerKey, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => System.Console.WriteLine(string.Format("Scheduler JobUnscheduled. Name: {0}", triggerKey.Name)));
        }

        public Task SchedulerError(string msg, SchedulerException cause, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => System.Console.WriteLine(string.Format("Scheduler SchedulerError. Name: {0}", msg)));
        }

        public Task SchedulerInStandbyMode(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => System.Console.WriteLine(string.Format("Scheduler SchedulerInStandbyMode")));
        }

        public Task SchedulerShutdown(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => System.Console.WriteLine(string.Format("Scheduler SchedulerShutdown")));
        }

        public Task SchedulerShuttingdown(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => System.Console.WriteLine(string.Format("Scheduler SchedulerShuttingdown")));
        }

        public Task SchedulerStarted(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => System.Console.WriteLine(string.Format("Scheduler SchedulerStarted")));
        }

        public Task SchedulerStarting(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => System.Console.WriteLine(string.Format("Scheduler SchedulerStarting")));
        }

        public Task SchedulingDataCleared(CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => System.Console.WriteLine(string.Format("Scheduler SchedulingDataCleared")));
        }

        public Task TriggerFinalized(ITrigger trigger, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => System.Console.WriteLine(string.Format("Scheduler TriggerFinalized. Name: {0}", trigger.Key.Name)));
        }

        public Task TriggerPaused(TriggerKey triggerKey, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => System.Console.WriteLine(string.Format("Scheduler TriggerPaused. Name: {0}", triggerKey.Name)));
        }

        public Task TriggerResumed(TriggerKey triggerKey, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => System.Console.WriteLine(string.Format("Scheduler TriggerResumed. Name: {0}", triggerKey.Name)));
        }

        public Task TriggersPaused(string triggerGroup, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => System.Console.WriteLine(string.Format("Scheduler TriggersPaused. Name: {0}", triggerGroup)));
        }

        public Task TriggersResumed(string triggerGroup, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => System.Console.WriteLine(string.Format("Scheduler TriggersResumed. Name: {0}", triggerGroup)));
        }
    }
}
