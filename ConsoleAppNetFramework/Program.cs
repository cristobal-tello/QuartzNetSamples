using Quartz;
using Quartz.Impl;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppNetFramework
{
    class Program
    {
        static void Main(string[] args)
        {
            //_01SimpleUse().GetAwaiter().GetResult();   // You need to uncomment to see how it works and comment other lines
            //_02Use2Triggers().GetAwaiter().GetResult();
            //_03DailyTimeSchedule().GetAwaiter().GetResult();
            //_04DailyTimeExtendSchedule().GetAwaiter().GetResult();
            //_05CronTrigger().GetAwaiter().GetResult();
            _06Listeners().GetAwaiter().GetResult();
        }
        private static async Task _01SimpleUse()
        {
            try
            {
                // Grab the Scheduler instance from the Factory
                NameValueCollection props = new NameValueCollection
                {
                    { "quartz.serializer.type", "binary" }
                };
                StdSchedulerFactory factory = new StdSchedulerFactory(props);
                IScheduler scheduler = await factory.GetScheduler();

                // and start it off
                await scheduler.Start();

                // We create a job
                IJobDetail job = JobBuilder.Create<HelloJob>()
                                        .UsingJobData("param1", "value1")       // UsingJobData is only necessary if you need to send parameters to the job
                                        .UsingJobData("param2", 12)             // Remember, UsingJobData only allows simple types (String, int, long, float, double, boolean)
                                        .UsingJobData("param3", true)           // To get the parameters in the job, use Context.JobDetail.JobDataMap
                                        .WithIdentity("HelloJob", "HelloGroup")
                                        .Build();

                // Only if you want send Complex type parameter to job. Use MergedJobDataMap in the job to get these values
                job.JobDataMap.Put("ComplexParameter", new ComplexParameter { Id = Guid.NewGuid(), Names = new List<string>() { "James", "Will", "Ashley" } });

                // Trigger the job to run now, and then repeat every 10 seconds
                ITrigger trigger = TriggerBuilder.Create()
                    .UsingJobData("triggerParam1", "trigger value1")        // UsigJobData is only necessary if you need to send parameters to the trigger
                    .WithIdentity("trigger1", "HelloGroup")
                    .StartNow()
                    .WithSimpleSchedule(x => x
                    .WithIntervalInSeconds(10)
                    .RepeatForever())
                    .Build();

                await scheduler.ScheduleJob(job, trigger);


                // some sleep to show what's happening
                await Task.Delay(TimeSpan.FromSeconds(60));

                // and last shut down the scheduler when you are ready to close your program
                await scheduler.Shutdown();
            }
            catch (SchedulerException se)
            {
                await Console.Error.WriteLineAsync(se.ToString());
            }
        }
        private static async Task _02Use2Triggers()
        {
            try
            {
                // Grab the Scheduler instance from the Factory
                NameValueCollection props = new NameValueCollection
                {
                    { "quartz.serializer.type", "binary" }
                };
                StdSchedulerFactory factory = new StdSchedulerFactory(props);
                IScheduler scheduler = await factory.GetScheduler();

                // and start it off
                await scheduler.Start();

                // We create a job
                IJobDetail job = JobBuilder.Create<HelloJob>()
                                        .UsingJobData("param1", "value1")       // UsingJobData is only necessary if you need to send parameters to the job
                                        .UsingJobData("param2", 12)             // Remember, UsingJobData only allows simple types (String, int, long, float, double, boolean)
                                        .UsingJobData("param3", true)           // To get the parameters in the job, use Context.JobDetail.JobDataMap
                                        .WithIdentity("HelloJob", "HelloGroup")
                                        .StoreDurably()
                                        .Build();

                // Only if you want send Complex type parameter to job. Use MergedJobDataMap in the job to get these values
                job.JobDataMap.Put("ComplexParameter", new ComplexParameter { Id = Guid.NewGuid(), Names = new List<string>() { "James", "Will", "Ashley" } });

                await scheduler.AddJob(job, true);    // Don't forget to add .StoreDurably when you create a job

                // Trigger the job to run now, and then repeat every 10 seconds
                ITrigger trigger1 = TriggerBuilder.Create()
                    .ForJob(job)
                    .UsingJobData("triggerParam1", "trigger value1")        // UsigJobData is only necessary if you need to send parameters to the trigger
                    .WithIdentity("trigger1", "HelloGroup")
                    .StartNow()
                    .WithSimpleSchedule(x => x
                            .WithIntervalInSeconds(10)
                            .RepeatForever())
                    .Build();

                // Trigger the job to run now, and then repeat every 10 seconds
                ITrigger trigger2 = TriggerBuilder.Create()
                    .ForJob(job)
                    .UsingJobData("triggerParam1", "trigger value2")        // UsigJobData is only necessary if you need to send parameters to the trigger
                    .WithIdentity("trigger2", "HelloGroup")
                    .StartNow()
                    .WithSimpleSchedule(x => x
                        .WithIntervalInSeconds(3)
                        .RepeatForever())
                    .Build();

                await scheduler.ScheduleJob(trigger1);
                await scheduler.ScheduleJob(trigger2);


                // some sleep to show what's happening
                await Task.Delay(TimeSpan.FromSeconds(60));

                // and last shut down the scheduler when you are ready to close your program
                await scheduler.Shutdown();
            }
            catch (SchedulerException se)
            {
                await Console.Error.WriteLineAsync(se.ToString());
            }
        }
        private static async Task _03DailyTimeSchedule()
        {
            try
            {
                // Grab the Scheduler instance from the Factory
                NameValueCollection props = new NameValueCollection
                {
                    { "quartz.serializer.type", "binary" }
                };
                StdSchedulerFactory factory = new StdSchedulerFactory(props);
                IScheduler scheduler = await factory.GetScheduler();

                // and start it off
                await scheduler.Start();

                // We create a job
                IJobDetail job = JobBuilder.Create<HelloJob>()
                                        .UsingJobData("param1", "value1")       // UsingJobData is only necessary if you need to send parameters to the job
                                        .UsingJobData("param2", 12)             // Remember, UsingJobData only allows simple types (String, int, long, float, double, boolean)
                                        .UsingJobData("param3", true)           // To get the parameters in the job, use Context.JobDetail.JobDataMap
                                        .WithIdentity("HelloJob", "HelloGroup")
                                        .Build();

                // Only if you want send Complex type parameter to job. Use MergedJobDataMap in the job to get these values
                job.JobDataMap.Put("ComplexParameter", new ComplexParameter { Id = Guid.NewGuid(), Names = new List<string>() { "James", "Will", "Ashley" } });

                // Trigger the job to run now, and then repeat every 10 seconds
                ITrigger trigger = TriggerBuilder.Create()
                    .UsingJobData("triggerParam1", "trigger value1")        // UsigJobData is only necessary if you need to send parameters to the trigger
                    .WithIdentity("trigger1", "HelloGroup")
                    .StartNow()
                    .WithDailyTimeIntervalSchedule(x => x
                        .StartingDailyAt(TimeOfDay.HourAndMinuteOfDay(11, 0))   // Run only betwwen 11:00AM to 11:30AM, every minute
                        .EndingDailyAt(TimeOfDay.HourAndMinuteOfDay(11, 30))
                        .WithIntervalInMinutes(1))
                        .Build();

                await scheduler.ScheduleJob(job, trigger);


                // some sleep to show what's happening
                await Task.Delay(TimeSpan.FromSeconds(300));

                // and last shut down the scheduler when you are ready to close your program
                await scheduler.Shutdown();
            }
            catch (SchedulerException se)
            {
                await Console.Error.WriteLineAsync(se.ToString());
            }
        }
        private static async Task _04DailyTimeExtendSchedule()
        {
            try
            {
                // Grab the Scheduler instance from the Factory
                NameValueCollection props = new NameValueCollection
                {
                    { "quartz.serializer.type", "binary" }
                };

                StdSchedulerFactory factory = new StdSchedulerFactory(props);
                IScheduler scheduler = await factory.GetScheduler();

                // and start it off
                await scheduler.Start();

                // We create a job
                IJobDetail job = JobBuilder.Create<HelloJob>()
                                        .UsingJobData("param1", "value1")       // UsingJobData is only necessary if you need to send parameters to the job
                                        .UsingJobData("param2", 12)             // Remember, UsingJobData only allows simple types (String, int, long, float, double, boolean)
                                        .UsingJobData("param3", true)           // To get the parameters in the job, use Context.JobDetail.JobDataMap
                                        .WithIdentity("HelloJob", "HelloGroup")
                                        .Build();

                // Only if you want send Complex type parameter to job. Use MergedJobDataMap in the job to get these values
                job.JobDataMap.Put("ComplexParameter", new ComplexParameter { Id = Guid.NewGuid(), Names = new List<string>() { "James", "Will", "Ashley" } });

                // Trigger the job to run now, and then repeat every 10 seconds
                ITrigger trigger = TriggerBuilder.Create()
                    .UsingJobData("triggerParam1", "trigger value1")        // UsigJobData is only necessary if you need to send parameters to the trigger
                    .WithIdentity("trigger1", "HelloGroup")
                    .StartNow()
                    .WithDailyTimeIntervalSchedule(x => x
                        .OnDaysOfTheWeek(DayOfWeek.Monday, DayOfWeek.Friday)    // Also, this job only run on Monday or Friday
                        .WithIntervalInMinutes(1))
                        .Build();

                await scheduler.ScheduleJob(job, trigger);


                // some sleep to show what's happening
                await Task.Delay(TimeSpan.FromSeconds(180));

                // and last shut down the scheduler when you are ready to close your program
                await scheduler.Shutdown();
            }
            catch (SchedulerException se)
            {
                await Console.Error.WriteLineAsync(se.ToString());
            }
        }
        private static async Task _05CronTrigger()
        {
            try
            {
                // Grab the Scheduler instance from the Factory
                NameValueCollection props = new NameValueCollection
                {
                    { "quartz.serializer.type", "binary" }
                };
                StdSchedulerFactory factory = new StdSchedulerFactory(props);
                IScheduler scheduler = await factory.GetScheduler();

                // and start it off
                await scheduler.Start();

                // We create a job
                IJobDetail job = JobBuilder.Create<HelloJob>()
                                        .UsingJobData("param1", "value1")       // UsingJobData is only necessary if you need to send parameters to the job
                                        .UsingJobData("param2", 12)             // Remember, UsingJobData only allows simple types (String, int, long, float, double, boolean)
                                        .UsingJobData("param3", true)           // To get the parameters in the job, use Context.JobDetail.JobDataMap
                                        .WithIdentity("HelloJob", "HelloGroup")
                                        .Build();

                // Only if you want send Complex type parameter to job. Use MergedJobDataMap in the job to get these values
                job.JobDataMap.Put("ComplexParameter", new ComplexParameter { Id = Guid.NewGuid(), Names = new List<string>() { "James", "Will", "Ashley" } });

                // Trigger the job to run now, and then repeat every 10 seconds
                ITrigger trigger = TriggerBuilder.Create()
                    .UsingJobData("triggerParam1", "trigger value1")        // UsigJobData is only necessary if you need to send parameters to the trigger
                    .WithIdentity("trigger1", "HelloGroup")
                    .StartNow()
                    .WithCronSchedule("0 0/2 * 1/1 * ? *")         // See cronmaker.com. In this example, run job every 2 minutes, any day, any month, any year...
                        .Build();

                await scheduler.ScheduleJob(job, trigger);


                // some sleep to show what's happening
                await Task.Delay(TimeSpan.FromSeconds(180));

                // and last shut down the scheduler when you are ready to close your program
                await scheduler.Shutdown();
            }
            catch (SchedulerException se)
            {
                await Console.Error.WriteLineAsync(se.ToString());
            }
        }

        private static async Task _06Listeners()
        {
            try
            {
                // Grab the Scheduler instance from the Factory
                NameValueCollection props = new NameValueCollection
                {
                    { "quartz.serializer.type", "binary" }
                };
                StdSchedulerFactory factory = new StdSchedulerFactory(props);
                IScheduler scheduler = await factory.GetScheduler();

                // and start it off
                await scheduler.Start();

                // We create a job
                IJobDetail job = JobBuilder.Create<HelloJob>()
                                        .UsingJobData("param1", "value1")       // UsingJobData is only necessary if you need to send parameters to the job
                                        .UsingJobData("param2", 12)             // Remember, UsingJobData only allows simple types (String, int, long, float, double, boolean)
                                        .UsingJobData("param3", true)           // To get the parameters in the job, use Context.JobDetail.JobDataMap
                                        .WithIdentity("HelloJob", "HelloGroup")
                                        .Build();

                // Only if you want send Complex type parameter to job. Use MergedJobDataMap in the job to get these values
                job.JobDataMap.Put("ComplexParameter", new ComplexParameter { Id = Guid.NewGuid(), Names = new List<string>() { "James", "Will", "Ashley" } });

                // Trigger the job to run now, and then repeat every 10 seconds
                ITrigger trigger = TriggerBuilder.Create()
                    .UsingJobData("triggerParam1", "trigger value1")        // UsigJobData is only necessary if you need to send parameters to the trigger
                    .WithIdentity("trigger1", "HelloGroup")
                    .StartNow()
                    .WithSimpleSchedule(x => x.WithIntervalInSeconds(10).RepeatForever())
                    .Build();

                
                scheduler.ListenerManager.AddTriggerListener(new TriggerListener());
                scheduler.ListenerManager.AddJobListener(new JobListener());
                scheduler.ListenerManager.AddSchedulerListener(new SchedulerListener());

                // Note we moved ScheduleJob after listeners!!
                await scheduler.ScheduleJob(job, trigger);

                // some sleep to show what's happening
                await Task.Delay(TimeSpan.FromSeconds(180));

                // and last shut down the scheduler when you are ready to close your program
                await scheduler.Shutdown();
            }
            catch (SchedulerException se)
            {
                await Console.Error.WriteLineAsync(se.ToString());
            }
        }
    }
}
