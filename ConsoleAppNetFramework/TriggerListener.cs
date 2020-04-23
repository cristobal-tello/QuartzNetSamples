using Quartz;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleAppNetFramework
{
    class TriggerListener : ITriggerListener
    {
        public string Name => "Trigger Listener Name";

        public Task TriggerComplete(ITrigger trigger, IJobExecutionContext context, SchedulerInstruction triggerInstructionCode, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run( () => System.Console.WriteLine(string.Format("TriggerComplete. Name: {0}", trigger.Key.Name)));
        }

        public async Task TriggerCompleteAsync(ITrigger trigger, IJobExecutionContext context, SchedulerInstruction triggerInstructionCode, CancellationToken cancellationToken = default(CancellationToken))
        {
            await System.Console.Out.WriteLineAsync(string.Format("TriggerComplete. Name: {0}", trigger.Key.Name));
        }

        public Task TriggerFired(ITrigger trigger, IJobExecutionContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() => System.Console.WriteLine(string.Format("TriggerFired. Name: {0}", trigger.Key.Name)));
        }

        public async Task TriggerFiredAsync(ITrigger trigger, IJobExecutionContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            await System.Console.Out.WriteLineAsync(string.Format("TriggerFiredAsync. Name: {0}", trigger.Key.Name));
        }

        public async Task TriggerMisfired(ITrigger trigger, CancellationToken cancellationToken = default(CancellationToken))
        {
            await System.Console.Out.WriteLineAsync(string.Format("TriggerMisfired. Name: {0}", trigger.Key.Name));
        }

        public async Task<bool> VetoJobExecution(ITrigger trigger, IJobExecutionContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            return false;
        }
    }
}
