// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Communication.JobRouter.Tests.Infrastructure;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Communication.JobRouter.Tests.Samples
{
    public class Sample2_ClassificationWithQueueSelectorAsync : SamplesBase<RouterTestEnvironment>
    {
        [Test]
        public async Task QueueSelection_ById()
        {
            JobRouterClient routerClient = new JobRouterClient("<< CONNECTION STRING >>");
            JobRouterAdministrationClient routerAdministrationClient = new JobRouterAdministrationClient("<< CONNECTION STRING >>");

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Classification_QueueSelectionById
            // In this scenario we are going to use a classification policy while submitting a job.
            // We are going to utilize the 'QueueSelectorAttachments' attribute on the classification policy to determine
            // which queue a job should be enqueued in. For this scenario, we are going to demonstrate
            // StaticLabelSelector to select a queue directly by its unique ID through the classification policy
            // Steps
            // 1. Create 2 Queues - Queue1(For Office 365 related jobs), Queue2(For XBox related jobs)
            // 2. Create 2 classification policies - CP1(For Office 365 related jobs), CP2(For XBox related jobs)
            // 3. Create 2 jobs - Job1 (with CP1), Job2 (with CP2)
            //
            // Output:
            // 1. Job1 is enqueued in Queue1
            // 2. Job2 is enqueued in Queue2

            Response<DistributionPolicy> distributionPolicy = await routerAdministrationClient.CreateDistributionPolicyAsync(
                new CreateDistributionPolicyOptions(distributionPolicyId: "distribution-policy-id-2", offerExpiresAfter: TimeSpan.FromSeconds(30), mode: new LongestIdleMode())
                {
                    Name = "My LongestIdle Distribution Policy",
                }
                );

            Response<RouterQueue> queue1 = await routerAdministrationClient.CreateQueueAsync(
                new CreateQueueOptions(queueId: "Queue-1", distributionPolicyId: distributionPolicy.Value.Id)
                {
                    Name = "Queue_365",
                });

            Response<RouterQueue> queue2 = await routerAdministrationClient.CreateQueueAsync(
                new CreateQueueOptions(queueId: "Queue-2", distributionPolicyId: distributionPolicy.Value.Id)
                {
                    Name = "Queue_XBox",
                });

            Response<ClassificationPolicy> cp1 = await routerAdministrationClient.CreateClassificationPolicyAsync(
                new CreateClassificationPolicyOptions(classificationPolicyId: "classification-policy-o365")
                {
                    Name = "Classification_Policy_O365",
                    QueueSelectorAttachments =
                    {
                        new StaticQueueSelectorAttachment(new RouterQueueSelector("Id", LabelOperator.Equal, new RouterValue(queue1.Value.Id)))
                    },
                });

            Response<ClassificationPolicy> cp2 = await routerAdministrationClient.CreateClassificationPolicyAsync(
                new CreateClassificationPolicyOptions(classificationPolicyId: "classification-policy-xbox")
                {
                    Name = "Classification_Policy_XBox",
                    QueueSelectorAttachments =
                    {
                        new StaticQueueSelectorAttachment(new RouterQueueSelector("Id", LabelOperator.Equal, new RouterValue(queue2.Value.Id)))
                    }
                });

            Response<RouterJob> jobO365 = await routerClient.CreateJobWithClassificationPolicyAsync(
                new CreateJobWithClassificationPolicyOptions(
                    jobId: "jobO365",
                    channelId: "general",
                    classificationPolicyId: cp1.Value.Id)
                {
                    ChannelReference = "12345",
                });

            Response<RouterJob> jobXbox = await routerClient.CreateJobWithClassificationPolicyAsync(
                new CreateJobWithClassificationPolicyOptions(
                    jobId: "jobXbox",
                    channelId: "general",
                    classificationPolicyId: cp2.Value.Id)
                {
                    ChannelReference = "12345",
                });

#if !SNIPPET
            bool condition = false;
            DateTimeOffset startTime = DateTimeOffset.UtcNow;
            TimeSpan maxWaitTime = TimeSpan.FromSeconds(10);
            while (!condition && DateTimeOffset.UtcNow.Subtract(startTime) <= maxWaitTime)
            {
                Response<RouterJob> jobO365Dto = await routerClient.GetJobAsync(jobO365.Value.Id);
                Response<RouterJob> jobXBoxDto = await routerClient.GetJobAsync(jobXbox.Value.Id);
                condition = jobO365Dto.Value.Status == RouterJobStatus.Queued &&
                            jobXBoxDto.Value.Status == RouterJobStatus.Queued;
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
#endif

            Response<RouterJob> jobO365Result = await routerClient.GetJobAsync(jobO365.Value.Id);
            Response<RouterJob> jobXBoxResult = await routerClient.GetJobAsync(jobXbox.Value.Id);

            Console.WriteLine($"O365 job has been enqueued in queue: {queue1.Value.Id}. Status: {jobO365Result.Value.QueueId == queue1.Value.Id}");
            Console.WriteLine($"XBox job has been enqueued in queue: {queue2.Value.Id}. Status: {jobXBoxResult.Value.QueueId == queue2.Value.Id}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Classification_QueueSelectionById

        }

        [Test]
        public async Task QueueSelection_ByCondition()
        {
            JobRouterClient routerClient = new JobRouterClient("<< CONNECTION STRING >>");
            JobRouterAdministrationClient routerAdministrationClient = new JobRouterAdministrationClient("<< CONNECTION STRING >>");

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Classification_QueueSelectionByConditionalLabelAttachments
            // In this scenario we are going to use a classification policy while submitting a job.
            // We are going to utilize the 'QueueSelectorAttachments' attribute on the classification policy to determine
            // which queue a job should be enqueued in. For this scenario, we are going to demonstrate
            // ConditionalLabelSelector to select a queue based on labels associated with a queue
            // Steps
            // 1. Create 2 Queues
            //     - Queue1(For Office 365 related jobs) - with label {ProductDetail = 'Office_Support'},
            //     - Queue2(For XBox related jobs) - with label {ProductDetail = 'XBox_Support'},
            // 2. Create 1 classification policy
            //    - Set condition: If job.Product == O365, then attach label {ProductDetail = 'Office_Support'}
            //                     Else if job.Product == XBx, then attach labels {ProductDetail = 'XBox_Support'}
            // 3. Create 2 jobs
            //     - Job1 - with label {Product = 'O365'}
            //     - Job2 - with labels {Product = 'XBx'}
            //
            // Output:
            // 1. Job1 is enqueued in Queue1
            // 2. Job2 is enqueued in Queue2

            Response<DistributionPolicy> distributionPolicy = await routerAdministrationClient.CreateDistributionPolicyAsync(
                new CreateDistributionPolicyOptions(
                    distributionPolicyId: "distribution-policy-id-3",
                    offerExpiresAfter: TimeSpan.FromSeconds(30),
                    mode: new LongestIdleMode())
                {
                    Name = "My LongestIdle Distribution Policy",
                }
            );

            Response<RouterQueue> queue1 = await routerAdministrationClient.CreateQueueAsync(
                new CreateQueueOptions(
                    queueId: "Queue-1",
                    distributionPolicyId: distributionPolicy.Value.Id)
                {
                    Name = "Queue_365",
                    Labels =
                    {
                        ["ProductDetail"] = new RouterValue("Office_Support")
                    }
                });

            Response<RouterQueue> queue2 = await routerAdministrationClient.CreateQueueAsync(
                new CreateQueueOptions(
                    queueId: "Queue-2",
                    distributionPolicyId: distributionPolicy.Value.Id)
                {
                    Name = "Queue_XBox",
                    Labels =
                    {
                        ["ProductDetail"] = new RouterValue("XBox_Support")
                    }
                });

            Response<ClassificationPolicy> classificationPolicy = await routerAdministrationClient.CreateClassificationPolicyAsync(
                new CreateClassificationPolicyOptions(classificationPolicyId: "classification-policy")
                {
                    Name = "Classification_Policy_O365_And_XBox",
                    QueueSelectorAttachments = {
                        new ConditionalQueueSelectorAttachment(
                            condition: new ExpressionRouterRule("If(job.Product = \"O365\", true, false)"),
                            queueSelectors: new List<RouterQueueSelector>()
                            {
                                new RouterQueueSelector("ProductDetail", LabelOperator.Equal, new RouterValue("Office_Support"))
                            }),
                        new ConditionalQueueSelectorAttachment(
                            condition: new ExpressionRouterRule("If(job.Product = \"XBx\", true, false)"),
                            queueSelectors: new List<RouterQueueSelector>()
                            {
                                new RouterQueueSelector("ProductDetail", LabelOperator.Equal, new RouterValue("XBox_Support"))
                            })
                    }
                });

            Response<RouterJob> jobO365 = await routerClient.CreateJobWithClassificationPolicyAsync(
                new CreateJobWithClassificationPolicyOptions(
                    jobId: "jobO365",
                    channelId: "general",
                    classificationPolicyId: classificationPolicy.Value.Id)
                {
                    ChannelReference = "12345",
                    Labels =
                    {
                        ["Language"] = new RouterValue("en"),
                        ["Product"] = new RouterValue("O365"),
                        ["Geo"] = new RouterValue("North America"),
                    },
                });

            Response<RouterJob> jobXbox = await routerClient.CreateJobWithClassificationPolicyAsync(
                new CreateJobWithClassificationPolicyOptions(
                    jobId: "jobXbox",
                    channelId: "general",
                    classificationPolicyId: classificationPolicy.Value.Id)
                {
                    ChannelReference = "12345",
                    Labels =
                    {
                        ["Language"] = new RouterValue("en"),
                        ["Product"] = new RouterValue("XBx"),
                        ["Geo"] = new RouterValue("North America"),
                    },
                });

#if !SNIPPET
            bool condition = false;
            DateTimeOffset startTime = DateTimeOffset.UtcNow;
            TimeSpan maxWaitTime = TimeSpan.FromSeconds(10);
            while (!condition && DateTimeOffset.UtcNow.Subtract(startTime) <= maxWaitTime)
            {
                Response<RouterJob> jobO365Dto = await routerClient.GetJobAsync(jobO365.Value.Id);
                Response<RouterJob> jobXBoxDto = await routerClient.GetJobAsync(jobXbox.Value.Id);
                condition = jobO365Dto.Value.Status == RouterJobStatus.Queued &&
                            jobXBoxDto.Value.Status == RouterJobStatus.Queued;
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
#endif

            Response<RouterJob> jobO365Result = await routerClient.GetJobAsync(jobO365.Value.Id);
            Response<RouterJob> jobXBoxResult = await routerClient.GetJobAsync(jobXbox.Value.Id);

            Console.WriteLine($"O365 job has been enqueued in queue: {queue1.Value.Id}. Status: {jobO365Result.Value.QueueId == queue1.Value.Id}");
            Console.WriteLine($"XBox job has been enqueued in queue: {queue2.Value.Id}. Status: {jobXBoxResult.Value.QueueId == queue2.Value.Id}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Classification_QueueSelectionByConditionalLabelAttachments
        }

        [Test]
        public async Task QueueSelection_ByPassThroughValues()
        {
            JobRouterClient routerClient = new JobRouterClient("<< CONNECTION STRING >>");
            JobRouterAdministrationClient routerAdministrationClient = new JobRouterAdministrationClient("<< CONNECTION STRING >>");

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Classification_QueueSelectionByPassThroughLabelAttachments
            // cSpell:ignore EMEA, Emea
            // In this scenario we are going to use a classification policy while submitting a job.
            // We are going to utilize the 'QueueSelectorAttachments' attribute on the classification policy to determine
            // which queue a job should be enqueued in. For this scenario, we are going to demonstrate
            // PassThroughLabelSelector to select a queue based on labels associated with a queue and the incoming job
            // Steps
            // 1. Create 3 Queues
            //     - Queue1(For Office 365 related jobs - EN - EMEA) - with labels {ProductDetail = 'Office_Support', Language = 'en', Region = 'EMEA'},
            //     - Queue2(For Office 365 related jobs - FR - EMEA) - with labels {ProductDetail = 'Office_Support', Language = 'fr', Region = 'EMEA'},
            //     - Queue3(For Office 365 related jobs - EN - NA) - with labels {ProductDetail = 'Office_Support', Language = 'en', Region = 'NA'},
            // 2. Create 1 classification policy
            //    - Set condition: Pass through the following properties from job: ProductDetail, Language, Region
            // 3. Create 3 jobs
            //     - Job1 - with labels {Product = 'O365', ProductDetail = 'Office_Support', Language = 'en', Region = 'EMEA'}
            //     - Job2 - with labels {Product = 'O365', ProductDetail = 'Office_Support', Language = 'fr', Region = 'EMEA'}
            //     - Job3 - with labels {Product = 'O365', ProductDetail = 'Office_Support', Language = 'en', Region = 'NA'}
            //
            // Output:
            // 1. Job1 is enqueued in Queue1
            // 2. Job2 is enqueued in Queue2
            // 3. Job3 is enqueued in Queue3

            Response<DistributionPolicy> distributionPolicy = await routerAdministrationClient.CreateDistributionPolicyAsync(
                new CreateDistributionPolicyOptions(
                    distributionPolicyId: "distribution-policy-id-4",
                    offerExpiresAfter: TimeSpan.FromSeconds(30),
                    mode: new LongestIdleMode())
                {
                    Name = "My LongestIdle Distribution Policy",
                }
                );

            Response<RouterQueue> queue1 = await routerAdministrationClient.CreateQueueAsync(
                new CreateQueueOptions(
                    queueId: "Queue-1",
                    distributionPolicyId: distributionPolicy.Value.Id)
                {
                    Name = "Queue_365_EN_EMEA",
                    Labels =
                    {
                        ["ProductDetail"] = new RouterValue("Office_Support"),
                        ["Language"] = new RouterValue("en"),
                        ["Region"] = new RouterValue("EMEA"),
                    },
                });

            Response<RouterQueue> queue2 = await routerAdministrationClient.CreateQueueAsync(
                new CreateQueueOptions(
                    queueId: "Queue-2",
                    distributionPolicyId: distributionPolicy.Value.Id)
                {
                    Name = "Queue_365_FR_EMEA",
                    Labels =
                    {
                        ["ProductDetail"] = new RouterValue("Office_Support"),
                        ["Language"] = new RouterValue("fr"),
                        ["Region"] = new RouterValue("EMEA"),
                    },
                });

            Response<RouterQueue> queue3 = await routerAdministrationClient.CreateQueueAsync(
                new CreateQueueOptions(
                    queueId: "Queue-3",
                    distributionPolicyId: distributionPolicy.Value.Id)
                {
                    Name = "Queue_365_EN_NA",
                    Labels =
                    {
                        ["ProductDetail"] = new RouterValue("Office_Support"),
                        ["Language"] = new RouterValue("en"),
                        ["Region"] = new RouterValue("NA"),
                    },
                });

            Response<ClassificationPolicy> classificationPolicy = await routerAdministrationClient.CreateClassificationPolicyAsync(
                new CreateClassificationPolicyOptions(classificationPolicyId: "classification-policy")
                {
                    Name = "Classification_Policy_O365_EMEA_NA",
                    QueueSelectorAttachments = {
                        new PassThroughQueueSelectorAttachment("ProductDetail", LabelOperator.Equal),
                        new PassThroughQueueSelectorAttachment("Language", LabelOperator.Equal),
                        new PassThroughQueueSelectorAttachment("Region", LabelOperator.Equal),
                    },
                });

            Response<RouterJob> jobENEmea = await routerClient.CreateJobWithClassificationPolicyAsync(
                new CreateJobWithClassificationPolicyOptions(
                    jobId: "jobENEmea",
                    channelId: "general",
                    classificationPolicyId: classificationPolicy.Value.Id)
                {
                    ChannelReference = "12345",
                    Labels =
                    {
                        ["Language"] = new RouterValue("en"),
                        ["Product"] = new RouterValue("O365"),
                        ["Geo"] = new RouterValue("Europe, Middle East, Africa"),
                        ["ProductDetail"] = new RouterValue("Office_Support"),
                        ["Region"] = new RouterValue("EMEA"),
                    },
                });

            Response<RouterJob> jobFREmea = await routerClient.CreateJobWithClassificationPolicyAsync(
                new CreateJobWithClassificationPolicyOptions(
                    jobId: "jobFREmea",
                    channelId: "general",
                    classificationPolicyId: classificationPolicy.Value.Id)
                {
                    ChannelReference = "12345",
                    Labels =
                    {
                        ["Language"] = new RouterValue("fr"),
                        ["Product"] = new RouterValue("O365"),
                        ["Geo"] = new RouterValue("Europe, Middle East, Africa"),
                        ["ProductDetail"] = new RouterValue("Office_Support"),
                        ["Region"] = new RouterValue("EMEA"),
                    },
                });

            Response<RouterJob> jobENNa = await routerClient.CreateJobWithClassificationPolicyAsync(
                new CreateJobWithClassificationPolicyOptions(
                    jobId: "jobENNa",
                    channelId: "general",
                    classificationPolicyId: classificationPolicy.Value.Id)
                {
                    ChannelReference = "12345",
                    Labels =
                    {
                        ["Language"] = new RouterValue("en"),
                        ["Product"] = new RouterValue("O365"),
                        ["Geo"] = new RouterValue("North America"),
                        ["ProductDetail"] = new RouterValue("Office_Support"),
                        ["Region"] = new RouterValue("NA"),
                    },
                });

#if !SNIPPET
            bool condition = false;
            DateTimeOffset startTime = DateTimeOffset.UtcNow;
            TimeSpan maxWaitTime = TimeSpan.FromSeconds(10);
            while (!condition && DateTimeOffset.UtcNow.Subtract(startTime) <= maxWaitTime)
            {
                Response<RouterJob> jobEnEmeaDto = await routerClient.GetJobAsync(jobENEmea.Value.Id);
                Response<RouterJob> jobFrEmeaDto = await routerClient.GetJobAsync(jobFREmea.Value.Id);
                Response<RouterJob> jobEnNaDto = await routerClient.GetJobAsync(jobENNa.Value.Id);
                condition = jobEnEmeaDto.Value.Status == RouterJobStatus.Queued &&
                            jobFrEmeaDto.Value.Status == RouterJobStatus.Queued &&
                            jobEnNaDto.Value.Status == RouterJobStatus.Queued;
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
#endif

            Response<RouterJob> jobENEmeaResult = await routerClient.GetJobAsync(jobENEmea.Value.Id);
            Response<RouterJob> jobFREmeaResult = await routerClient.GetJobAsync(jobFREmea.Value.Id);
            Response<RouterJob> jobENNaResult = await routerClient.GetJobAsync(jobENNa.Value.Id);

            Console.WriteLine($"O365 EN EMEA job has been enqueued in queue: {queue1.Value.Id}. Status: {jobENEmeaResult.Value.QueueId == queue1.Value.Id}");
            Console.WriteLine($"O365 FR EMEA job has been enqueued in queue: {queue2.Value.Id}. Status: {jobFREmeaResult.Value.QueueId == queue2.Value.Id}");
            Console.WriteLine($"O365 EN NA job has been enqueued in queue: {queue3.Value.Id}. Status: {jobENEmeaResult.Value.QueueId == queue3.Value.Id}");

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Classification_QueueSelectionByPassThroughLabelAttachments
        }

        // TODO
        /*[Test]
        public async Task QueueSelection_ByRuleEngineLabels()
        {
            throw new NotImplementedException();
        }*/

        // TODO
        /*[Test]
        public async Task QueueSelection_ByWeightedAllocation()
        {
            throw new NotImplementedException();
        }*/
    }
}
