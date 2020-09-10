using Quartz;
using System;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace QuartzTest
{
    public class SampleJobListener : IJobListener
    {
        public string Name => "SampleJobListener";

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

        public Task JobExecutionVetoed(IJobExecutionContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() =>
                {
                    AddToListBox(context);
                }
            );
        }

        public Task JobToBeExecuted(IJobExecutionContext context, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() =>
                {
                    AddToListBox(context);
                }
            );
        }

        public Task JobWasExecuted(IJobExecutionContext context, JobExecutionException jobException, CancellationToken cancellationToken = default(CancellationToken))
        {
            return Task.Run(() =>
                {
                    AddToListBox(context);
                }
            );
        }
    }
}
