// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
            JobRouterClient routerClient = new JobRouterClient("<< CONNECTION STRING >>");
            JobRouterAdministrationClient routerAdministration = new JobRouterAdministrationClient("<< CONNECTION STRING >>");

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Classification_PrioritybyStaticRule

            // In this scenario we are going to create a classification policy which assigns a static value of 10 to every job
            // The classification policy will be setup to add only the priority value to a job
            // Hence, when the job will be created it will have a queueId assigned to it

            // define the classification policy
            string classificationPolicyId = "static-priority";
            Response<ClassificationPolicy> classificationPolicy = await routerAdministration.CreateClassificationPolicyAsync(
                new CreateClassificationPolicyOptions(classificationPolicyId: classificationPolicyId)
                {
                    PrioritizationRule = new StaticRouterRule(new RouterValue(10))
                });

            Console.WriteLine($"Classification policy successfully created with id: {classificationPolicy.Value.Id} and priority rule of type: {classificationPolicy.Value.PrioritizationRule.Kind}");

            // setting up queue

            // Create distribution policy for queue
            string distributionPolicyId = "longest-idle-distribution";
            Response<DistributionPolicy> distributionPolicy = await routerAdministration.CreateDistributionPolicyAsync(
                new CreateDistributionPolicyOptions(
                    distributionPolicyId: distributionPolicyId,
                    offerExpiresAfter: TimeSpan.FromMinutes(5),
                    mode: new LongestIdleMode()));

            Console.WriteLine($"Distribution policy successfully created with id: {distributionPolicy.Value.Id}");

            // Create queue
            string jobQueueId = "my-default-queue";
            Response<RouterQueue> jobQueue =
                await routerAdministration.CreateQueueAsync(new CreateQueueOptions(queueId: jobQueueId, distributionPolicyId: distributionPolicyId));

            Console.WriteLine($"Queue has been successfully created with id: {jobQueue.Value.Id}");

            // Create a job

            Response<RouterJob> job = await routerClient.CreateJobWithClassificationPolicyAsync(
                options: new CreateJobWithClassificationPolicyOptions(
                    jobId: "demo-job-id",
                    channelId: "Voip",
                    classificationPolicyId: classificationPolicyId)
                {
                    QueueId = jobQueueId
                });

            Console.WriteLine($"Job has been successfully created with id: {job.Value.Id}, and status: {job.Value.Status}"); // Status: PendingClassification

#if !SNIPPET

            bool condition = false;
            DateTimeOffset startTime = DateTimeOffset.UtcNow;
            TimeSpan maxWaitTime = TimeSpan.FromSeconds(10);
            while (!condition && DateTimeOffset.UtcNow.Subtract(startTime) <= maxWaitTime)
            {
                Response<RouterJob> jobDto = await routerClient.GetJobAsync(job.Value.Id);
                condition = jobDto.Value.Status == RouterJobStatus.Queued;
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
#endif

            // After a few seconds, the job would have successfully classified and queued

            Response<RouterJob> queriedJob = await routerClient.GetJobAsync(job.Value.Id);

            Console.WriteLine($"Job has been successfully queued: {queriedJob.Value.Status == RouterJobStatus.Queued}");
            Console.WriteLine($"Job has been queue in `{jobQueueId}`: {queriedJob.Value.QueueId == jobQueueId}");
            Console.WriteLine($"Job has been assigned a priority value: {queriedJob.Value.Priority}"); // 10

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Classification_PrioritybyStaticRule
        }

        [Test]
        public async Task Scenario2()
        {
            JobRouterClient routerClient = new JobRouterClient("<< CONNECTION STRING >>");
            JobRouterAdministrationClient routerAdministration = new JobRouterAdministrationClient("<< CONNECTION STRING >>");

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Classification_PrioritybyExpressionRouterRule

            // In this scenario we are going to create a classification policy which assigns a priority value by evaluating a simple PowerFx expression
            // The classification policy will be setup to add only the priority value to a job
            // Hence, when the job will be created it will have a queueId assigned to it

            // define the classification policy
            string classificationPolicyId = "expression-priority";
            Response<ClassificationPolicy> classificationPolicy = await routerAdministration.CreateClassificationPolicyAsync(
                new CreateClassificationPolicyOptions(classificationPolicyId: classificationPolicyId)
                {
                    PrioritizationRule = new ExpressionRouterRule("If(job.Escalated = true, 10, 1)") // this will check whether the job has a label "Escalated" set to "true"
                });

            Console.WriteLine($"Classification policy successfully created with id: {classificationPolicy.Value.Id} and priority rule of type: {classificationPolicy.Value.PrioritizationRule.Kind}");

            // setting up queue

            // Create distribution policy for queue
            string distributionPolicyId = "longest-idle-distribution";
            Response<DistributionPolicy> distributionPolicy = await routerAdministration.CreateDistributionPolicyAsync(
                new CreateDistributionPolicyOptions(
                    distributionPolicyId: distributionPolicyId,
                    offerExpiresAfter: TimeSpan.FromMinutes(5),
                    mode: new LongestIdleMode()));

            Console.WriteLine($"Distribution policy successfully created with id: {distributionPolicy.Value.Id}");

            // Create queue
            string jobQueueId = "my-default-queue";
            Response<RouterQueue> jobQueue =
                await routerAdministration.CreateQueueAsync(new CreateQueueOptions(queueId: jobQueueId, distributionPolicyId: distributionPolicyId));

            Console.WriteLine($"Queue has been successfully created with id: {jobQueue.Value.Id}");

            // Create a job

            Response<RouterJob> job1 = await routerClient.CreateJobWithClassificationPolicyAsync(
                options: new CreateJobWithClassificationPolicyOptions(
                    jobId: "demo-job-id-1",
                    channelId: "Voip",
                    classificationPolicyId: classificationPolicyId)
                {
                    QueueId = jobQueueId,
                    Labels =
                    {
                        ["Escalated"] = new RouterValue(false)
                    }
                });

            Console.WriteLine($"Job has been successfully created with id: {job1.Value.Id}, and status: {job1.Value.Status}"); // Status: PendingClassification

            Response<RouterJob> job2 = await routerClient.CreateJobWithClassificationPolicyAsync(
                options: new CreateJobWithClassificationPolicyOptions(
                    jobId: "demo-job-id-2",
                    channelId: "Voip",
                    classificationPolicyId: classificationPolicyId)
                {
                    QueueId = jobQueueId,
                    Labels =
                    {
                        ["Escalated"] = new RouterValue(true)
                    }
                });

            Console.WriteLine($"Job has been successfully created with id: {job1.Value.Id}, and status: {job1.Value.Status}"); // Status: PendingClassification

#if !SNIPPET

            bool condition = false;
            DateTimeOffset startTime = DateTimeOffset.UtcNow;
            TimeSpan maxWaitTime = TimeSpan.FromSeconds(10);
            while (!condition && DateTimeOffset.UtcNow.Subtract(startTime) <= maxWaitTime)
            {
                Response<RouterJob> job1Dto = await routerClient.GetJobAsync(job1.Value.Id);
                Response<RouterJob> job2Dto = await routerClient.GetJobAsync(job2.Value.Id);
                condition = job1Dto.Value.Status == RouterJobStatus.Queued && job2Dto.Value.Status == RouterJobStatus.Queued;
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
#endif

            // After a few seconds, both jobs would have successfully classified and queued

            Response<RouterJob> queriedJob1 = await routerClient.GetJobAsync(job1.Value.Id);

            Console.WriteLine($"Job has been successfully queued: {queriedJob1.Value.Status == RouterJobStatus.Queued}");
            Console.WriteLine($"Job has been queue in `{jobQueueId}`: {queriedJob1.Value.QueueId == jobQueueId}");
            Console.WriteLine($"Job has been assigned a priority value: {queriedJob1.Value.Priority}"); // 1

            Response<RouterJob> queriedJob2 = await routerClient.GetJobAsync(job1.Value.Id);

            Console.WriteLine($"Job has been successfully queued: {queriedJob2.Value.Status == RouterJobStatus.Queued}");
            Console.WriteLine($"Job has been queue in `{jobQueueId}`: {queriedJob2.Value.QueueId == jobQueueId}");
            Console.WriteLine($"Job has been assigned a priority value: {queriedJob2.Value.Priority}"); // 10

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Classification_PrioritybyExpressionRouterRule
        }

        [Test]
        public async Task Scenario3()
        {
            JobRouterClient routerClient = new JobRouterClient("<< CONNECTION STRING >>");
            JobRouterAdministrationClient routerAdministration = new JobRouterAdministrationClient("<< CONNECTION STRING >>");

            #region Snippet:Azure_Communication_JobRouter_Tests_Samples_Classification_PrioritybyAzureFunctionRouterRule

            // In this scenario we are going to create a classification policy which assigns a priority value by evaluating a simple AzureFunction
            // The classification policy will be setup to add only the priority value to a job
            // Hence, when the job will be created it will have a queueId assigned to it

            // define the classification policy
            string classificationPolicyId = "expression-priority";
            Response<ClassificationPolicy> classificationPolicy = await routerAdministration.CreateClassificationPolicyAsync(
                new CreateClassificationPolicyOptions(classificationPolicyId: classificationPolicyId)
                {
                    PrioritizationRule = new FunctionRouterRule(new Uri("<insert azure function rule URI>")) // this will check whether the job has a label "Escalated" set to "true"
                });

            Console.WriteLine($"Classification policy successfully created with id: {classificationPolicy.Value.Id} and priority rule of type: {classificationPolicy.Value.PrioritizationRule.Kind}");

            // setting up queue

            // Create distribution policy for queue
            string distributionPolicyId = "longest-idle-distribution";
            Response<DistributionPolicy> distributionPolicy = await routerAdministration.CreateDistributionPolicyAsync(
                new CreateDistributionPolicyOptions(
                    distributionPolicyId: distributionPolicyId,
                    offerExpiresAfter: TimeSpan.FromMinutes(5),
                    mode: new LongestIdleMode()));

            Console.WriteLine($"Distribution policy successfully created with id: {distributionPolicy.Value.Id}");

            // Create queue
            string jobQueueId = "my-default-queue";
            Response<RouterQueue> jobQueue =
                await routerAdministration.CreateQueueAsync(new CreateQueueOptions(queueId: jobQueueId, distributionPolicyId: distributionPolicyId));

            Console.WriteLine($"Queue has been successfully created with id: {jobQueue.Value.Id}");

            // Create a job

            Response<RouterJob> job1 = await routerClient.CreateJobWithClassificationPolicyAsync(
                options: new CreateJobWithClassificationPolicyOptions(
                    jobId: "demo-job-id-1",
                    channelId: "Voip",
                    classificationPolicyId: classificationPolicyId)
                {
                    QueueId = jobQueueId,
                    Labels =
                    {
                        ["Escalated"] = new RouterValue(false)
                    }
                });

            Console.WriteLine($"Job has been successfully created with id: {job1.Value.Id}, and status: {job1.Value.Status}"); // Status: PendingClassification

            Response<RouterJob> job2 = await routerClient.CreateJobWithClassificationPolicyAsync(
                options: new CreateJobWithClassificationPolicyOptions(
                    jobId: "demo-job-id-2",
                    channelId: "Voip",
                    classificationPolicyId: classificationPolicyId)
                {
                    QueueId = jobQueueId,
                    Labels =
                    {
                        ["Escalated"] = new RouterValue(true)
                    }
                });

            Console.WriteLine($"Job has been successfully created with id: {job1.Value.Id}, and status: {job1.Value.Status}"); // Status: PendingClassification

#if !SNIPPET

            bool condition = false;
            DateTimeOffset startTime = DateTimeOffset.UtcNow;
            TimeSpan maxWaitTime = TimeSpan.FromSeconds(10);
            while (!condition && DateTimeOffset.UtcNow.Subtract(startTime) <= maxWaitTime)
            {
                Response<RouterJob> job1Dto = await routerClient.GetJobAsync(job1.Value.Id);
                Response<RouterJob> job2Dto = await routerClient.GetJobAsync(job2.Value.Id);
                condition = job1Dto.Value.Status == RouterJobStatus.Queued && job2Dto.Value.Status == RouterJobStatus.Queued;
                await Task.Delay(TimeSpan.FromSeconds(1));
            }
#endif

            // After a few seconds, both jobs would have successfully classified and queued

            Response<RouterJob> queriedJob1 = await routerClient.GetJobAsync(job1.Value.Id);

            Console.WriteLine($"Job has been successfully queued: {queriedJob1.Value.Status == RouterJobStatus.Queued}");
            Console.WriteLine($"Job has been queue in `{jobQueueId}`: {queriedJob1.Value.QueueId == jobQueueId}");
            Console.WriteLine($"Job has been assigned a priority value: {queriedJob1.Value.Priority}"); // 1

            Response<RouterJob> queriedJob2 = await routerClient.GetJobAsync(job1.Value.Id);

            Console.WriteLine($"Job has been successfully queued: {queriedJob2.Value.Status == RouterJobStatus.Queued}");
            Console.WriteLine($"Job has been queue in `{jobQueueId}`: {queriedJob2.Value.QueueId == jobQueueId}");
            Console.WriteLine($"Job has been assigned a priority value: {queriedJob2.Value.Priority}"); // 10

            #endregion Snippet:Azure_Communication_JobRouter_Tests_Samples_Classification_PrioritybyAzureFunctionRouterRule
        }
    }
}
