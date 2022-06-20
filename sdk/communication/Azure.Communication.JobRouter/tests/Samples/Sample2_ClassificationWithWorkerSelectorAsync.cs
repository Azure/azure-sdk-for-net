// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Tests.Infrastructure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.Samples
{
    public class Sample2_ClassificationWithWorkerSelectorAsync : SamplesBase<RouterTestEnvironment>
    {
        [Test]
        public async Task WorkerSelection_StaticSelectors()
        {
            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Classification_StaticWorkerSelectors
            // In this scenario we are going to use a classification policy while submitting a job.
            // We are going to utilize the 'WorkerSelectors' attribute on the classification policy to attach
            // custom worker selectors to the job. For this scenario, we are going to demonstrate
            // StaticWorkerSelector to filter workers on static values.
            // We would like to filter workers on the following criteria:-
            // 1. "Location": "United States"
            // 2. "Language": "en-us"
            // 3. "Geo": "NA"
            //
            // We will create 2 workers, one without the aforementioned labels and the other one with.
            //
            // We will observe the following:-
            //
            // Output:
            // 1. Incoming job will have the aforementioned worker selectors attached to it.
            // 2. Offer will be sent only to the worker who satisfies all three criteria
            //
            // NOTE: All jobs with referencing the classification policy will have the WorkerSelectors attached to them

#if !SNIPPET
            var routerClient = new RouterClient(Environment.GetEnvironmentVariable("AZURE_COMMUNICATION_SERVICE_CONNECTION_STRING"));
#endif
            // Set up queue
            var distributionPolicyId = "distribution-policy-id-2";
            var distributionPolicy = await routerClient.CreateDistributionPolicyAsync(
                id: distributionPolicyId,
                offerTtlSeconds: 5 * 60,
                mode: new LongestIdleMode(),
                new CreateDistributionPolicyOptions()
                {
                    Name = "My LongestIdle Distribution Policy",
                }
                );

            var queueId = "Queue-1";
            var queue1 = await routerClient.CreateQueueAsync(
                id: queueId,
                distributionPolicyId: distributionPolicy.Value.Id,
                new CreateQueueOptions()
                {
                    Name = "Queue_365",
                });

            // Set up classification policy
            var cpId = "classification-policy-o365";
            var cp1 = await routerClient.CreateClassificationPolicyAsync(
                id: cpId,
                new CreateClassificationPolicyOptions()
                {
                    Name = "Classification_Policy_O365",
                    WorkerSelectors = new List<WorkerSelectorAttachment>()
                    {
                        new StaticWorkerSelector(new WorkerSelector("Location", LabelOperator.Equal, "United States")),
                        new StaticWorkerSelector(new WorkerSelector("Language", LabelOperator.Equal, "en-us")),
                        new StaticWorkerSelector(new WorkerSelector("Geo", LabelOperator.Equal, "NA"))
                    }
                });

            // Set up job
            var jobO365 = await routerClient.CreateJobWithClassificationPolicyAsync(
                id: "jobO365",
                channelId: "general",
                classificationPolicyId: cp1.Value.Id,
                new CreateJobWithClassificationPolicyOptions()
                {
                    ChannelReference = "12345",
                    QueueId = queueId, // We only want to attach WorkerSelectors with classification policy this time, so we will specify queueId
                    Priority = 10, // We only want to attach WorkerSelectors with classification policy this time, so we will specify priority
                });

#if !SNIPPET
            bool condition = false;
            var startTime = DateTimeOffset.UtcNow;
            var maxWaitTime = TimeSpan.FromSeconds(10);
            while (!condition && DateTimeOffset.UtcNow.Subtract(startTime) <= maxWaitTime)
            {
                var jobO365Dto = await routerClient.GetJobAsync(jobO365.Value.Id);
                condition = jobO365Dto.Value.JobStatus == JobStatus.Queued;
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
#endif

            var jobO365Result = await routerClient.GetJobAsync(jobO365.Value.Id);

            Console.WriteLine($"O365 job has been enqueued in queue: {queue1.Value.Id}. Status: {jobO365Result.Value.QueueId == queue1.Value.Id}");

            // Set up two workers
            var workerId1 = "worker-id-1";
            var worker1Labels = new LabelCollection()
            {
                ["Location"] = "United States", ["Language"] = "en-us", ["Geo"] = "NA", ["Skill_English_Lvl"] = 7
            };
            var worker1 = await routerClient.CreateWorkerAsync(
                id: workerId1,
                totalCapacity: 100,
                options: new CreateWorkerOptions()
                {
                    AvailableForOffers = true, // registering worker at the time of creation
                    ChannelConfigurations = new Dictionary<string, ChannelConfiguration>()
                    {
                        ["general"] = new ChannelConfiguration(10),
                    },
                    Labels = worker1Labels, // attaching labels associated with worker
                    QueueIds = new Dictionary<string, QueueAssignment>()
                    {
                        [queueId] = new QueueAssignment(), // assigning queue to worker
                    }
                });

            var workerId2 = "worker-id-2";
            var worker2Labels = new LabelCollection()
            {
                ["Skill_English_Lvl"] = 7
            };
            var worker2 = await routerClient.CreateWorkerAsync(
                id: workerId2,
                totalCapacity: 100,
                options: new CreateWorkerOptions()
                {
                    AvailableForOffers = true, // registering worker at the time of creation
                    ChannelConfigurations = new Dictionary<string, ChannelConfiguration>()
                    {
                        ["general"] = new ChannelConfiguration(10),
                    },
                    Labels = worker2Labels, // attaching labels associated with worker
                    QueueIds = new Dictionary<string, QueueAssignment>()
                    {
                        [queueId] = new QueueAssignment(), // assigning queue to worker
                    }
                });

#if !SNIPPET
            condition = false;
            startTime = DateTimeOffset.UtcNow;
            maxWaitTime = TimeSpan.FromSeconds(10);
            while (!condition && DateTimeOffset.UtcNow.Subtract(startTime) <= maxWaitTime)
            {
                var worker1Dto = await routerClient.GetWorkerAsync(workerId1);
                condition = worker1Dto.Value.Offers.Any(offer => offer.JobId == jobO365.Value.Id);
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
#endif

            // we expect worker1 to get an offer for the job, and worker2 to not

            var queriedWorker1 = await routerClient.GetWorkerAsync(workerId1);
            var queriedWorker2 = await routerClient.GetWorkerAsync(workerId2);

            Console.WriteLine($"Worker 1 has successfully received offer for job: {queriedWorker1.Value.Offers.Any(offer => offer.JobId == jobO365.Value.Id)}");
            Console.WriteLine($"Worker 2 has not received offer for job: {queriedWorker2.Value.Offers.Any(offer => offer.JobId == jobO365.Value.Id)}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Classification_StaticWorkerSelectors

        }

        [Test]
        public async Task WorkerSelection_ByCondition()
        {
            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Classification_CondtitionalWorkerSelectors
            // In this scenario we are going to use a classification policy while submitting a job.
            // We are going to utilize the 'WorkerSelectors' attribute on the classification policy to attach
            // custom worker selectors to the job. For this scenario, we are going to demonstrate
            // ConditionalWorkerSelector to filter workers based on a condition.
            // We would like to filter workers on the following criteria:-
            // 1. If job "Location": "United States",
            // then find workers with:
            //     1. "Language": "en-us"
            //     2. "Geo": "NA"
            //     3. "Skill_English_Lvl" >= 5
            //   If job "Location": "Canada"
            // then find workers with:
            //     1. "Language": "en-ca"
            //     2. "Geo": "NA"
            //     3. "Skill_English_Lvl" >= 5
            //
            // We will create 2 workers, one without the aforementioned labels and the other one with.
            // We will create a job, which has some meaningful labels associated with itself.
            //
            // We will observe the following:-
            //
            // Output:
            // 1. Incoming job will have the aforementioned worker selectors attached to it.
            // 2. Offer will be sent only to the worker who satisfies all three criteria

#if !SNIPPET
            var routerClient = new RouterClient(Environment.GetEnvironmentVariable("AZURE_COMMUNICATION_SERVICE_CONNECTION_STRING"));
#endif

            // Set up queue
            var distributionPolicyId = "distribution-policy-id-3";
            var distributionPolicy = await routerClient.CreateDistributionPolicyAsync(
                id: distributionPolicyId,
                offerTtlSeconds: 5 * 60,
                mode: new LongestIdleMode(),
                new CreateDistributionPolicyOptions()
                {
                    Name = "My LongestIdle Distribution Policy",
                }
                );

            var queueId = "Queue-1";
            var queue1 = await routerClient.CreateQueueAsync(
                id: queueId,
                distributionPolicyId: distributionPolicy.Value.Id,
                new CreateQueueOptions()
                {
                    Name = "Queue_365",
                });

            // Set up classification policy
            var cpId = "classification-policy-o365";
            var cp1 = await routerClient.CreateClassificationPolicyAsync(
                id: cpId,
                new CreateClassificationPolicyOptions()
                {
                    Name = "Classification_Policy_O365",
                    WorkerSelectors = new List<WorkerSelectorAttachment>()
                    {
                        new ConditionalWorkerSelector(
                            condition: new ExpressionRule("If(job.Location = \"United States\", true, false)"),
                            labelSelectors: new List<WorkerSelector>()
                            {
                                new WorkerSelector("Language", LabelOperator.Equal, "en-us"),
                                new WorkerSelector("Geo", LabelOperator.Equal, "NA"),
                                new WorkerSelector("Skill_English_Lvl", LabelOperator.GreaterThanEqual, 5)
                            }),
                        new ConditionalWorkerSelector(
                            condition: new ExpressionRule("If(job.Location = \"Canada\", true, false)"),
                            labelSelectors: new List<WorkerSelector>()
                            {
                                new WorkerSelector("Language", LabelOperator.Equal, "en-ca"),
                                new WorkerSelector("Geo", LabelOperator.Equal, "NA"),
                                new WorkerSelector("Skill_English_Lvl", LabelOperator.GreaterThanEqual, 5)
                            }),
                    }
                });

            // Set up job
            var jobO365 = await routerClient.CreateJobWithClassificationPolicyAsync(
                id: "jobO365",
                channelId: "general",
                classificationPolicyId: cp1.Value.Id,
                new CreateJobWithClassificationPolicyOptions()
                {
                    ChannelReference = "12345",
                    QueueId = queueId, // We only want to attach WorkerSelectors with classification policy this time, so we will specify queueId
                    Priority = 10, // We only want to attach WorkerSelectors with classification policy this time, so we will specify priority
                    Labels = new LabelCollection() // we will attach a label to the job which will affects its classification
                    {
                        ["Location"] = "United States",
                    }
                });

#if !SNIPPET
            bool condition = false;
            var startTime = DateTimeOffset.UtcNow;
            var maxWaitTime = TimeSpan.FromSeconds(10);
            while (!condition && DateTimeOffset.UtcNow.Subtract(startTime) <= maxWaitTime)
            {
                var jobO365Dto = await routerClient.GetJobAsync(jobO365.Value.Id);
                condition = jobO365Dto.Value.JobStatus == JobStatus.Queued;
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
#endif

            var jobO365Result = await routerClient.GetJobAsync(jobO365.Value.Id);

            Console.WriteLine($"O365 job has been enqueued in queue: {queue1.Value.Id}. Status: {jobO365Result.Value.QueueId == queue1.Value.Id}");  // true
            Console.Write($"O365 job has the following worker selectors attached to it after classification: {jobO365Result.Value.AttachedWorkerSelectors}"); // { "Language" = "en-us", "Geo" = "NA", "Skill_English_Lvl" >= 5 }

            // Set up two workers
            var workerId1 = "worker-id-1";
            var worker1Labels = new LabelCollection()
            {
                ["Language"] = "en-us",
                ["Geo"] = "NA",
                ["Skill_English_Lvl"] = 7
            };
            var worker1 = await routerClient.CreateWorkerAsync(
                id: workerId1,
                totalCapacity: 100,
                options: new CreateWorkerOptions()
                {
                    AvailableForOffers = true, // registering worker at the time of creation
                    ChannelConfigurations = new Dictionary<string, ChannelConfiguration>()
                    {
                        ["general"] = new ChannelConfiguration(10),
                    },
                    Labels = worker1Labels, // attaching labels associated with worker
                    QueueIds = new Dictionary<string, QueueAssignment>()
                    {
                        [queueId] = new QueueAssignment(), // assigning queue to worker
                    }
                });

            var workerId2 = "worker-id-2";
            var worker2Labels = new LabelCollection()
            {
                ["Language"] = "en-ca",
                ["Geo"] = "NA",
                ["Skill_English_Lvl"] = 7
            };
            var worker2 = await routerClient.CreateWorkerAsync(
                id: workerId2,
                totalCapacity: 100,
                options: new CreateWorkerOptions()
                {
                    AvailableForOffers = true, // registering worker at the time of creation
                    ChannelConfigurations = new Dictionary<string, ChannelConfiguration>()
                    {
                        ["general"] = new ChannelConfiguration(10),
                    },
                    Labels = worker2Labels, // attaching labels associated with worker
                    QueueIds = new Dictionary<string, QueueAssignment>()
                    {
                        [queueId] = new QueueAssignment(), // assigning queue to worker
                    }
                });

#if !SNIPPET
            condition = false;
            startTime = DateTimeOffset.UtcNow;
            maxWaitTime = TimeSpan.FromSeconds(10);
            while (!condition && DateTimeOffset.UtcNow.Subtract(startTime) <= maxWaitTime)
            {
                var worker1Dto = await routerClient.GetWorkerAsync(workerId1);
                condition = worker1Dto.Value.Offers.Any(offer => offer.JobId == jobO365.Value.Id);
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
#endif

            // we expect worker1 to get an offer for the job, and worker2 to not

            var queriedWorker1 = await routerClient.GetWorkerAsync(workerId1);
            var queriedWorker2 = await routerClient.GetWorkerAsync(workerId2);

            Console.WriteLine($"Worker 1 has successfully received offer for job: {queriedWorker1.Value.Offers.Any(offer => offer.JobId == jobO365.Value.Id)}");
            Console.WriteLine($"Worker 2 has not received offer for job: {queriedWorker2.Value.Offers.Any(offer => offer.JobId == jobO365.Value.Id)}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Classification_CondtitionalWorkerSelectors
        }

        [Test]
        public async Task WorkerSelection_ByPassThroughValues()
        {
            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Classification_PassThroughWorkerSelectors
            // cSpell:ignore XBOX, Xbox
            // In this scenario we are going to use a classification policy while submitting a job.
            // We are going to utilize the 'WorkerSelectors' attribute on the classification policy to attach
            // custom worker selectors to the job. For this scenario, we are going to demonstrate
            // PassThroughWorkerSelectors to filter workers based on a conditions already attached to job.
            // We would like to filter workers on the following criteria already attached to job:-
            // "Location", "Geo", "Language", "Dept"
            // Additionally, we attach a static selector to specify a skill level
            //
            // We will create 2 workers, one without the aforementioned labels and the other one with.
            // We will create 2 jobs, which has some meaningful labels associated with itself.
            //
            // We will observe the following:-
            //
            // Output:
            // 1. Incoming jobs will have the aforementioned worker selectors attached to it.
            // 2. Offer will be sent only to the worker who satisfies all criteria

#if !SNIPPET
            var routerClient = new RouterClient(Environment.GetEnvironmentVariable("AZURE_COMMUNICATION_SERVICE_CONNECTION_STRING"));
#endif
            // Set up queue
            var distributionPolicyId = "distribution-policy-id-4";
            var distributionPolicy = await routerClient.CreateDistributionPolicyAsync(
                id: distributionPolicyId,
                offerTtlSeconds: 5 * 60,
                mode: new LongestIdleMode(),
                new CreateDistributionPolicyOptions()
                {
                    Name = "My LongestIdle Distribution Policy",
                }
                );

            var queueId = "Queue-1";
            var queue1 = await routerClient.CreateQueueAsync(
                id: queueId,
                distributionPolicyId: distributionPolicy.Value.Id,
                new CreateQueueOptions()
                {
                    Name = "Queue_365",
                });

            // Set up classification policy
            var cpId = "classification-policy-o365";
            var cp1 = await routerClient.CreateClassificationPolicyAsync(
                id: cpId,
                new CreateClassificationPolicyOptions()
                {
                    Name = "Classification_Policy_O365_XBOX",
                    WorkerSelectors = new List<WorkerSelectorAttachment>()
                    {
                        new PassThroughWorkerSelector("Location", LabelOperator.Equal),
                        new PassThroughWorkerSelector("Geo", LabelOperator.Equal),
                        new PassThroughWorkerSelector("Language", LabelOperator.Equal),
                        new PassThroughWorkerSelector("Dept", LabelOperator.Equal),
                        new StaticWorkerSelector(new WorkerSelector("Skill_English_Lvl", LabelOperator.GreaterThanEqual, 5)),
                    }
                });

            // Set up jobs
            var jobO365 = await routerClient.CreateJobWithClassificationPolicyAsync(
                id: "jobO365",
                channelId: "general",
                classificationPolicyId: cp1.Value.Id,
                new CreateJobWithClassificationPolicyOptions()
                {
                    ChannelReference = "12345",
                    QueueId = queueId, // We only want to attach WorkerSelectors with classification policy this time, so we will specify queueId
                    Priority = 10, // We only want to attach WorkerSelectors with classification policy this time, so we will specify priority
                    Labels = new LabelCollection() // we will attach a label to the job which will affects its classification
                    {
                        ["Location"] = "United States",
                        ["Geo"] = "NA",
                        ["Language"] = "en-us",
                        ["Dept"] = "O365"
                    }
                });

            var jobXbox = await routerClient.CreateJobWithClassificationPolicyAsync(
                id: "jobXbox",
                channelId: "general",
                classificationPolicyId: cp1.Value.Id,
                new CreateJobWithClassificationPolicyOptions()
                {
                    ChannelReference = "12345",
                    QueueId = queueId, // We only want to attach WorkerSelectors with classification policy this time, so we will specify queueId
                    Priority = 10, // We only want to attach WorkerSelectors with classification policy this time, so we will specify priority
                    Labels = new LabelCollection() // we will attach a label to the job which will affects its classification
                    {
                        ["Location"] = "United States",
                        ["Geo"] = "NA",
                        ["Language"] = "en-us",
                        ["Dept"] = "Xbox"
                    }
                });

#if !SNIPPET
            bool condition = false;
            var startTime = DateTimeOffset.UtcNow;
            var maxWaitTime = TimeSpan.FromSeconds(10);
            while (!condition && DateTimeOffset.UtcNow.Subtract(startTime) <= maxWaitTime)
            {
                var jobO365Dto = await routerClient.GetJobAsync(jobO365.Value.Id);
                var jobXboxDto = await routerClient.GetJobAsync(jobXbox.Value.Id);
                condition = jobO365Dto.Value.JobStatus == JobStatus.Queued && jobXboxDto.Value.JobStatus == JobStatus.Queued;
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
#endif

            var jobO365Result1 = await routerClient.GetJobAsync(jobO365.Value.Id);

            Console.WriteLine($"O365 job has been enqueued in queue: {queue1.Value.Id}. Status: {jobO365Result1.Value.QueueId == queue1.Value.Id}");  // true
            Console.Write($"O365 job has the following worker selectors attached to it after classification: {jobO365Result1.Value.AttachedWorkerSelectors}"); // { "Location" = "United States, "Language" = "en-us", "Geo" = "NA", "Dept" = "O365", "Skill_English_Lvl" >= 5 }

            var jobXboxResult = await routerClient.GetJobAsync(jobXbox.Value.Id);

            Console.WriteLine($"O365 job has been enqueued in queue: {queue1.Value.Id}. Status: {jobXboxResult.Value.QueueId == queue1.Value.Id}");  // true
            Console.Write($"O365 job has the following worker selectors attached to it after classification: {jobXboxResult.Value.AttachedWorkerSelectors}"); // { "Location" = "United States, "Language" = "en-us", "Geo" = "NA", "Dept" = "Xbox", "Skill_English_Lvl" >= 5 }

            // Set up two workers
            var workerId1 = "worker-id-1";
            var worker1Labels = new LabelCollection()
            {
                ["Location"] = "United States",
                ["Geo"] = "NA",
                ["Language"] = "en-us",
                ["Dept"] = "O365",
                ["Skill_English_Lvl"] = 10,
            };
            var worker1 = await routerClient.CreateWorkerAsync(
                id: workerId1,
                totalCapacity: 100,
                options: new CreateWorkerOptions()
                {
                    AvailableForOffers = true, // registering worker at the time of creation
                    ChannelConfigurations = new Dictionary<string, ChannelConfiguration>()
                    {
                        ["general"] = new ChannelConfiguration(10),
                    },
                    Labels = worker1Labels, // attaching labels associated with worker
                    QueueIds = new Dictionary<string, QueueAssignment>()
                    {
                        [queueId] = new QueueAssignment(), // assigning queue to worker
                    }
                });

            var workerId2 = "worker-id-2";
            var worker2Labels = new LabelCollection()
            {
                ["Location"] = "United States",
                ["Geo"] = "NA",
                ["Language"] = "en-us",
                ["Dept"] = "Xbox",
                ["Skill_English_Lvl"] = 10,
            };
            var worker2 = await routerClient.CreateWorkerAsync(
                id: workerId2,
                totalCapacity: 100,
                options: new CreateWorkerOptions()
                {
                    AvailableForOffers = true, // registering worker at the time of creation
                    ChannelConfigurations = new Dictionary<string, ChannelConfiguration>()
                    {
                        ["general"] = new ChannelConfiguration(10),
                    },
                    Labels = worker2Labels, // attaching labels associated with worker
                    QueueIds = new Dictionary<string, QueueAssignment>()
                    {
                        [queueId] = new QueueAssignment(), // assigning queue to worker
                    }
                });

#if !SNIPPET
            condition = false;
            startTime = DateTimeOffset.UtcNow;
            maxWaitTime = TimeSpan.FromSeconds(10);
            while (!condition && DateTimeOffset.UtcNow.Subtract(startTime) <= maxWaitTime)
            {
                var worker1Dto = await routerClient.GetWorkerAsync(workerId1);
                var worker2Dto = await routerClient.GetWorkerAsync(workerId2);
                condition = worker1Dto.Value.Offers.Any(offer => offer.JobId == jobO365.Value.Id)
                            && worker2Dto.Value.Offers.Any(offer => offer.JobId == jobXbox.Value.Id);
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
#endif

            // we expect worker1 to get an offer for the jobO365, and worker2 to get an offer for jobXbox

            var queriedWorker1 = await routerClient.GetWorkerAsync(workerId1);
            var queriedWorker2 = await routerClient.GetWorkerAsync(workerId2);

            Console.WriteLine($"Worker 1 has successfully received offer for jobO365: {queriedWorker1.Value.Offers.Any(offer => offer.JobId == jobO365.Value.Id)}");
            Console.WriteLine($"Worker 2 has successfully received offer for jobXbox: {queriedWorker2.Value.Offers.Any(offer => offer.JobId == jobXbox.Value.Id)}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Classification_PassThroughWorkerSelectors
        }
    }
}
