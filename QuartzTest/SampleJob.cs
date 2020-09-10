using Quartz;
using System;
using System.Threading.Tasks;

namespace QuartzTest
{
    [DisallowConcurrentExecution]
    public class SampleJob : IJob
    {
        public async Task Execute(IJobExecutionContext jobContext)
        {
            await Task.Run(() =>
            {
                Task.Delay(5000).Wait();

                var jobDataMap = jobContext.MergedJobDataMap;

               // If you need complex parameters, use JobDataMap.Put when you create the job
               var sampleJobParameters = (SampleJobParameters)jobDataMap.Get("SampleJobParameters");

               if (sampleJobParameters.Control.InvokeRequired)
               {
                   var frmMain = sampleJobParameters.Control as FrmMain;
                   frmMain.Invoke(new Action(
                            () =>
                            {
                                string message = $"{DateTime.Now.ToLongTimeString()} - Job executed. Trigger: {jobContext.Trigger.Key.Name}";
                                frmMain.listBox.Items.Add(message);
                            }
                        )
                    );
               }
            }
            );
        }
    }
}
