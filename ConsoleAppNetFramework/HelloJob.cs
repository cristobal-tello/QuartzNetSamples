using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace ConsoleAppNetFramework
{
    class HelloJob : IJob
    {
        public async Task Execute(IJobExecutionContext jobContext)
        {
            // If you need to get parameters  use UsingJobData when create the job
            //var jobDataMap = jobContext.JobDetail.JobDataMap;           // Use JobDetail.JobDataMap when you only have parametes in Job

            var jobDataMap = jobContext.MergedJobDataMap;                // Use only when you have parameters in both job and trigger

            var param1Value = jobDataMap.GetString("param1");
            var param2Value = jobDataMap.GetInt("param2");
            var param3Value = jobDataMap.GetBoolean("param3");

            var triggerParam1 = jobDataMap.GetString("triggerParam1");

            // If you need complex parameters, use JobDataMap.Put when you create the job
            var complexParameter = (ComplexParameter)jobDataMap.Get("ComplexParameter");

            string message = string.Format("{0}\tHello world!!. Parameters passed are: Param1: '{1}', Param2: '{2}' Param3: '{3}'\nComplex parameters values are: Guid: '{4}', Name list size: {5}\nTrigger param value: '{6}'", 
                                            DateTime.Now.ToLongTimeString(), param1Value, param2Value, param3Value, complexParameter.Id, complexParameter.Names.Count, triggerParam1);
            //System.Console.WriteLine(message);  // Warning warning CS1998
            await System.Console.Out.WriteLineAsync(message);
            Debug.WriteLine(message);
        }
    }
}
