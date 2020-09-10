using Quartz;
using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace QuartzTest
{
    class SampleTriggerListener : ITriggerListener
    {
        public string Name => "SampleTriggerListener";

        private void AddToListBox(IJobExecutionContext context, [CallerMemberName] string methodName = null)
        {
            var jobDataMap = context.MergedJobDataMap;

            var sampleJobParameters = (SampleJobParameters)jobDataMap.Get("SampleJobParameters");

            if (sampleJobParameters.Control.InvokeRequired)
            {
                var frmMain = sampleJobParameters.Control as FrmMain;
                frmMain.Invoke(new Action(
                         () =>
                         {
                             string message = $"{DateTime.Now.ToLongTimeString()} - {methodName}. Trigger: {context.Trigger.Key.Name}";
                             frmMain.listBox.Items.Add(message);
                         }
                     )
                 );
            }
        }

        public Task TriggerComplete(ITrigger trigger, IJobExecutionContext context, SchedulerInstruction triggerInstructionCode, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() =>
                {
                    AddToListBox(context);
                }
            );
        }

        public async Task TriggerCompleteAsync(ITrigger trigger, IJobExecutionContext context, SchedulerInstruction triggerInstructionCode, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Task.Run(() =>
            {
                AddToListBox(context);
            }
            );
        }

        public Task TriggerFired(ITrigger trigger, IJobExecutionContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() =>
                {
                    AddToListBox(context);
                }
            );
        }

        public async Task TriggerFiredAsync(ITrigger trigger, IJobExecutionContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Task.Run(() =>
                {
                    AddToListBox(context);
                }
            );
        }

        public async Task TriggerMisfired(ITrigger trigger, CancellationToken cancellationToken = default(CancellationToken))
        {
            System.Windows.Forms.MessageBox.Show("TriggerMisfired");
            await System.Console.Out.WriteLineAsync($"TriggerMisfired. Name: {trigger.Key.Name}");
        }

        public async Task<bool> VetoJobExecution(ITrigger trigger, IJobExecutionContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            await Task.Run(() =>
                {
                    AddToListBox(context);
                }
            );

            return await Task.FromResult(false);
        }
    }
}
