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
    public class Sample2_ClassificationWithPriorityRuleAsync : SamplesBase<RouterTestEnvironment>
    {
        [Test]
        public async Task Scenario1()
        {
#if !SNIPPET
            var routerClient = new RouterClient(Environment.GetEnvironmentVariable("AZURE_COMMUNICATION_SERVICE_CONNECTION_STRING"));
#endif

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Classification_PrioritybyStaticRule

            // In this scenario we are going to create a classification policy which assigns a static value of 10 to every job
            // The classification policy will be setup to add only the priority value to a job
            // Hence, when the job will be created it will have a queueId assigned to it

            // define the classification policy
            var classificationPolicyId = "static-priority";
            var classificationPolicy = await routerClient.CreateClassificationPolicyAsync(
                id: classificationPolicyId,
                new CreateClassificationPolicyOptions()
                {
                    PrioritizationRule = new StaticRule(10)
                });

            Console.WriteLine($"Classification policy successfully created with id: {classificationPolicy.Value.Id} and priority rule of type: {classificationPolicy.Value.PrioritizationRule.Kind}");

            // setting up queue

            // Create distribution policy for queue
            var distributionPolicyId = "longest-idle-distribution";
            var distributionPolicy = await routerClient.CreateDistributionPolicyAsync(
                id: distributionPolicyId,
                offerTtlSeconds: 60 * 5,
                mode: new LongestIdleMode());

            Console.WriteLine($"Distribution policy successfully created with id: {distributionPolicy.Value.Id}");

            // Create queue
            var jobQueueId = "my-default-queue";
            var jobQueue =
                await routerClient.CreateQueueAsync(id: jobQueueId, distributionPolicyId: distributionPolicyId);

            Console.WriteLine($"Queue has been successfully created with id: {jobQueue.Value.Id}");

            // Create a job

            var job = await routerClient.CreateJobWithClassificationPolicyAsync(
                id: "demo-job-id",
                channelId: "Voip",
                classificationPolicyId: classificationPolicyId,
                options: new CreateJobWithClassificationPolicyOptions()
                {
                    QueueId = jobQueueId
                });

            Console.WriteLine($"Job has been successfully created with id: {job.Value.Id}, and status: {job.Value.JobStatus}"); // Status: PendingClassification

#if !SNIPPET

            bool condition = false;
            var startTime = DateTimeOffset.UtcNow;
            var maxWaitTime = TimeSpan.FromSeconds(10);
            while (!condition && DateTimeOffset.UtcNow.Subtract(startTime) <= maxWaitTime)
            {
                var jobDto = await routerClient.GetJobAsync(job.Value.Id);
                condition = jobDto.Value.JobStatus == JobStatus.Queued;
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
#endif

            // After a few seconds, the job would have successfully classified and queued

            var queriedJob = await routerClient.GetJobAsync(job.Value.Id);

            Console.WriteLine($"Job has been successfully queued: {queriedJob.Value.JobStatus == JobStatus.Queued}");
            Console.WriteLine($"Job has been queue in `{jobQueueId}`: {queriedJob.Value.QueueId == jobQueueId}");
            Console.WriteLine($"Job has been assigned a priority value: {queriedJob.Value.Priority}"); // 10

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Classification_PrioritybyStaticRule
        }

        [Test]
        public async Task Scenario2()
        {
#if !SNIPPET
            var routerClient = new RouterClient(Environment.GetEnvironmentVariable("AZURE_COMMUNICATION_SERVICE_CONNECTION_STRING"));
#endif

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Classification_PrioritybyExpressionRule

            // In this scenario we are going to create a classification policy which assigns a priority value by evaluating a simple PowerFx expression
            // The classification policy will be setup to add only the priority value to a job
            // Hence, when the job will be created it will have a queueId assigned to it

            // define the classification policy
            var classificationPolicyId = "expression-priority";
            var classificationPolicy = await routerClient.CreateClassificationPolicyAsync(
                id: classificationPolicyId,
                new CreateClassificationPolicyOptions()
                {
                    PrioritizationRule = new ExpressionRule("If(job.Escalated = true, 10, 1)") // this will check whether the job has a label "Escalated" set to "true"
                });

            Console.WriteLine($"Classification policy successfully created with id: {classificationPolicy.Value.Id} and priority rule of type: {classificationPolicy.Value.PrioritizationRule.Kind}");

            // setting up queue

            // Create distribution policy for queue
            var distributionPolicyId = "longest-idle-distribution";
            var distributionPolicy = await routerClient.CreateDistributionPolicyAsync(
                id: distributionPolicyId,
                offerTtlSeconds: 60 * 5,
                mode: new LongestIdleMode());

            Console.WriteLine($"Distribution policy successfully created with id: {distributionPolicy.Value.Id}");

            // Create queue
            var jobQueueId = "my-default-queue";
            var jobQueue =
                await routerClient.CreateQueueAsync(id: jobQueueId, distributionPolicyId: distributionPolicyId);

            Console.WriteLine($"Queue has been successfully created with id: {jobQueue.Value.Id}");

            // Create a job

            var job1 = await routerClient.CreateJobWithClassificationPolicyAsync(
                id: "demo-job-id-1",
                channelId: "Voip",
                classificationPolicyId: classificationPolicyId,
                options: new CreateJobWithClassificationPolicyOptions()
                {
                    QueueId = jobQueueId,
                    Labels = new LabelCollection()
                    {
                        ["Escalated"] = new LabelValue(false)
                    }
                });

            Console.WriteLine($"Job has been successfully created with id: {job1.Value.Id}, and status: {job1.Value.JobStatus}"); // Status: PendingClassification

            var job2 = await routerClient.CreateJobWithClassificationPolicyAsync(
                id: "demo-job-id-2",
                channelId: "Voip",
                classificationPolicyId: classificationPolicyId,
                options: new CreateJobWithClassificationPolicyOptions()
                {
                    QueueId = jobQueueId,
                    Labels = new LabelCollection()
                    {
                        ["Escalated"] = new LabelValue(true)
                    }
                });

            Console.WriteLine($"Job has been successfully created with id: {job1.Value.Id}, and status: {job1.Value.JobStatus}"); // Status: PendingClassification

#if !SNIPPET

            bool condition = false;
            var startTime = DateTimeOffset.UtcNow;
            var maxWaitTime = TimeSpan.FromSeconds(10);
            while (!condition && DateTimeOffset.UtcNow.Subtract(startTime) <= maxWaitTime)
            {
                var job1Dto = await routerClient.GetJobAsync(job1.Value.Id);
                var job2Dto = await routerClient.GetJobAsync(job2.Value.Id);
                condition = job1Dto.Value.JobStatus == JobStatus.Queued && job2Dto.Value.JobStatus == JobStatus.Queued;
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
#endif

            // After a few seconds, both jobs would have successfully classified and queued

            var queriedJob1 = await routerClient.GetJobAsync(job1.Value.Id);

            Console.WriteLine($"Job has been successfully queued: {queriedJob1.Value.JobStatus == JobStatus.Queued}");
            Console.WriteLine($"Job has been queue in `{jobQueueId}`: {queriedJob1.Value.QueueId == jobQueueId}");
            Console.WriteLine($"Job has been assigned a priority value: {queriedJob1.Value.Priority}"); // 1

            var queriedJob2 = await routerClient.GetJobAsync(job1.Value.Id);

            Console.WriteLine($"Job has been successfully queued: {queriedJob2.Value.JobStatus == JobStatus.Queued}");
            Console.WriteLine($"Job has been queue in `{jobQueueId}`: {queriedJob2.Value.QueueId == jobQueueId}");
            Console.WriteLine($"Job has been assigned a priority value: {queriedJob2.Value.Priority}"); // 10

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Classification_PrioritybyExpressionRule
        }

        [Test]
        public async Task Scenario3()
        {
#if !SNIPPET
            var routerClient = new RouterClient(Environment.GetEnvironmentVariable("AZURE_COMMUNICATION_SERVICE_CONNECTION_STRING"));
#endif

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Classification_PrioritybyAzureFunctionRule

            // In this scenario we are going to create a classification policy which assigns a priority value by evaluating a simple AzureFunction
            // The classification policy will be setup to add only the priority value to a job
            // Hence, when the job will be created it will have a queueId assigned to it

            // define the classification policy
            var classificationPolicyId = "expression-priority";
            var classificationPolicy = await routerClient.CreateClassificationPolicyAsync(
                id: classificationPolicyId,
                new CreateClassificationPolicyOptions()
                {
                    PrioritizationRule = new AzureFunctionRule("<insert azure function rule URI>") // this will check whether the job has a label "Escalated" set to "true"
                });

            Console.WriteLine($"Classification policy successfully created with id: {classificationPolicy.Value.Id} and priority rule of type: {classificationPolicy.Value.PrioritizationRule.Kind}");

            // setting up queue

            // Create distribution policy for queue
            var distributionPolicyId = "longest-idle-distribution";
            var distributionPolicy = await routerClient.CreateDistributionPolicyAsync(
                id: distributionPolicyId,
                offerTtlSeconds: 60 * 5,
                mode: new LongestIdleMode());

            Console.WriteLine($"Distribution policy successfully created with id: {distributionPolicy.Value.Id}");

            // Create queue
            var jobQueueId = "my-default-queue";
            var jobQueue =
                await routerClient.CreateQueueAsync(id: jobQueueId, distributionPolicyId: distributionPolicyId);

            Console.WriteLine($"Queue has been successfully created with id: {jobQueue.Value.Id}");

            // Create a job

            var job1 = await routerClient.CreateJobWithClassificationPolicyAsync(
                id: "demo-job-id-1",
                channelId: "Voip",
                classificationPolicyId: classificationPolicyId,
                options: new CreateJobWithClassificationPolicyOptions()
                {
                    QueueId = jobQueueId,
                    Labels = new LabelCollection()
                    {
                        ["Escalated"] = new LabelValue(false)
                    }
                });

            Console.WriteLine($"Job has been successfully created with id: {job1.Value.Id}, and status: {job1.Value.JobStatus}"); // Status: PendingClassification

            var job2 = await routerClient.CreateJobWithClassificationPolicyAsync(
                id: "demo-job-id-2",
                channelId: "Voip",
                classificationPolicyId: classificationPolicyId,
                options: new CreateJobWithClassificationPolicyOptions()
                {
                    QueueId = jobQueueId,
                    Labels = new LabelCollection()
                    {
                        ["Escalated"] = new LabelValue(true)
                    }
                });

            Console.WriteLine($"Job has been successfully created with id: {job1.Value.Id}, and status: {job1.Value.JobStatus}"); // Status: PendingClassification

#if !SNIPPET

            bool condition = false;
            var startTime = DateTimeOffset.UtcNow;
            var maxWaitTime = TimeSpan.FromSeconds(10);
            while (!condition && DateTimeOffset.UtcNow.Subtract(startTime) <= maxWaitTime)
            {
                var job1Dto = await routerClient.GetJobAsync(job1.Value.Id);
                var job2Dto = await routerClient.GetJobAsync(job2.Value.Id);
                condition = job1Dto.Value.JobStatus == JobStatus.Queued && job2Dto.Value.JobStatus == JobStatus.Queued;
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
#endif

            // After a few seconds, both jobs would have successfully classified and queued

            var queriedJob1 = await routerClient.GetJobAsync(job1.Value.Id);

            Console.WriteLine($"Job has been successfully queued: {queriedJob1.Value.JobStatus == JobStatus.Queued}");
            Console.WriteLine($"Job has been queue in `{jobQueueId}`: {queriedJob1.Value.QueueId == jobQueueId}");
            Console.WriteLine($"Job has been assigned a priority value: {queriedJob1.Value.Priority}"); // 1

            var queriedJob2 = await routerClient.GetJobAsync(job1.Value.Id);

            Console.WriteLine($"Job has been successfully queued: {queriedJob2.Value.JobStatus == JobStatus.Queued}");
            Console.WriteLine($"Job has been queue in `{jobQueueId}`: {queriedJob2.Value.QueueId == jobQueueId}");
            Console.WriteLine($"Job has been assigned a priority value: {queriedJob2.Value.Priority}"); // 10

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Classification_PrioritybyAzureFunctionRule
        }
    }
}
