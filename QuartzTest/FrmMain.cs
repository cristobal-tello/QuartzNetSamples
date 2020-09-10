using Quartz;
using Quartz.Impl;
using Quartz.Impl.Matchers;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Windows.Forms;

namespace QuartzTest
{
    public partial class FrmMain : Form
    {
        IScheduler scheduler;
        IJobDetail job;

        public FrmMain()
        {
            InitializeComponent();

            NameValueCollection props = new NameValueCollection
                {
                    { "quartz.serializer.type", "binary" }
                };

            StdSchedulerFactory factory = new StdSchedulerFactory(props);
            scheduler = factory.GetScheduler().Result;

            buttonEvery2Min.Enabled = false;
            buttonNow.Enabled = false;
            buttonQuartzStop.Enabled = false;

         
        }

        private void buttonQuartzStart_Click(object sender, EventArgs e)
        {
            scheduler.Start();
            string message = $"{DateTime.Now.ToShortTimeString()} - Scheduler started";
            listBox.Items.Add(message);

            buttonEvery2Min.Enabled = true;
            buttonQuartzStop.Enabled = true;

        }

        private void buttonQuartzStop_Click(object sender, EventArgs e)
        {
            scheduler.Shutdown();
            string message = $"{DateTime.Now.ToShortTimeString()} - Scheduler shutdown";
            listBox.Items.Add(message);
        }

        private void buttonEvery2Min_Click(object sender, EventArgs e)
        {
            string message = $"{DateTime.Now.ToLongTimeString()} ---------> Button 2Min click";
            listBox.Items.Add(message);

            // We create a job
            job = JobBuilder.Create<SampleJob>()
                                    .StoreDurably(true)
                                    .WithIdentity("SampleJob", "SampleGroup")
                                    .Build();

            // Only if you want send Complex type parameter to job. Use MergedJobDataMap in the job to get these values
            job.JobDataMap.Put("SampleJobParameters", new SampleJobParameters { Control = this });

            scheduler.AddJob(job, false).Wait();
            scheduler.ListenerManager.AddJobListener(new SampleJobListener());

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("TriggerButton2", "SampleGroup")
                .StartNow()
                .WithCronSchedule("0 0/1 * 1/1 * ? *")         // See cronmaker.com. In this example, run job every 2 minutes, any day, any month, any year...
                .ForJob(job) 
                .Build();

            scheduler.ListenerManager.AddTriggerListener(new SampleTriggerListener());

            scheduler.ScheduleJob(trigger).ContinueWith
            (
                t =>
                {
                    var d = t.Result;

                    message = $"{DateTime.Now.ToLongTimeString()} - Button 2 click - {d}";
                    listBox.Invoke(
                        new Action
                        (
                            () =>
                            {
                                listBox.Items.Add(message);
                            }
                        )
                    );
                }
            );

            buttonNow.Enabled = true;
        }

        private void buttonNow_Click(object sender, EventArgs e)
        {
            string message = $"{DateTime.Now.ToLongTimeString()} ---------> Button Now click";
            listBox.Items.Add(message);

            var jobs = scheduler.GetJobKeys(GroupMatcher<JobKey>.AnyGroup()).Result;

            var job = jobs.FirstOrDefault(j => j.Name == "SampleJob");

            if (job != null)
            {
                scheduler.TriggerJob(job).ContinueWith(
                    t =>
                    {
                        var success = t.IsCompleted && !t.IsFaulted;
                    }
                    );

            }



            //IReadOnlyCollection<TriggerKey> x = scheduler.GetTriggerKeys(GroupMatcher<TriggerKey>.AnyGroup()).Result;
            ////scheduler.ResumeTrigger
            
            //var triggerNow = x.FirstOrDefault(y => y.Name == "TriggerNow");

            //if (triggerNow != null)
            //{
            //    scheduler.ResumeTrigger(triggerNow);

            //}

           
            //var triggerName = "TriggerNow";

            //ITrigger trigger = TriggerBuilder.Create()
            //    .WithIdentity(triggerName, "SampleGroup")
            //    .StartNow()
            //    .ForJob(job)
            //    .Build();

            //scheduler.ScheduleJob(trigger).ContinueWith(
            //    t =>
            //    {
            //        var d = t.Result;

            //        string message = $"{DateTime.Now.ToLongTimeString()} - Button 1 click - {d}";
            //        listBox.Invoke(
            //            new Action
            //            (
            //                () =>
            //                {
            //                    listBox.Items.Add(message);
            //                }
            //            )
            //        );
            //    }
            //);
        }

        private void butttonClearList_Click(object sender, EventArgs e)
        {
            listBox.Items.Clear();
        }

        private void buttonEvery3Min_Click(object sender, EventArgs e)
        {
            string message = $"{DateTime.Now.ToLongTimeString()} ---------> Button 3Min click";
            listBox.Items.Add(message);

            // We create a job
            job = JobBuilder.Create<SampleJob>()
                                    .StoreDurably(true)
                                    .WithIdentity("SampleJob2", "SampleGroup")
                                    .Build();

            // Only if you want send Complex type parameter to job. Use MergedJobDataMap in the job to get these values
            job.JobDataMap.Put("SampleJobParameters", new SampleJobParameters { Control = this });

            scheduler.AddJob(job, false).Wait();
            scheduler.ListenerManager.AddJobListener(new SampleJobListener());

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("TriggerButton3", "SampleGroup")
                .StartNow()
                .WithCronSchedule("0 0/1 * 1/1 * ? *")         // See cronmaker.com. In this example, run job every 2 minutes, any day, any month, any year...
                .ForJob(job)
                .Build();

            scheduler.ListenerManager.AddTriggerListener(new SampleTriggerListener());

            scheduler.ScheduleJob(trigger).ContinueWith
            (
                t =>
                {
                    var d = t.Result;

                    message = $"{DateTime.Now.ToLongTimeString()} - Button 3 click - {d}";
                    listBox.Invoke(
                        new Action
                        (
                            () =>
                            {
                                listBox.Items.Add(message);
                            }
                        )
                    );
                }
            );

            buttonNow.Enabled = true;

        }
    }
}
