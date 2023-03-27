// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using Azure.Analytics.Synapse.Spark;
using Azure.Analytics.Synapse.Spark.Models;
using Azure.Analytics.Synapse.Tests;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.Synapse.Spark.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="SparkBatchClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class SparkBatchClientLiveTests : RecordedTestBase<SynapseTestEnvironment>
    {
        public SparkBatchClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        private SparkBatchClient CreateClient()
        {
            return InstrumentClient(new SparkBatchClient(
                new Uri(TestEnvironment.EndpointUrl),
                TestEnvironment.SparkPoolName,
                TestEnvironment.Credential,
                options: InstrumentClientOptions(new SparkClientOptions())
            ));
        }

        [RecordedTest]
        public async Task TestSparkBatchJobCompletesWhenJobStarts()
        {
            SparkBatchClient client = CreateClient();

            // Submit the Spark job
            SparkBatchJobOptions createParams = SparkTestUtilities.CreateSparkJobRequestParameters(Recording, TestEnvironment);
            var sparkBatchOperation = await client.CreateSparkBatchJobAsync(WaitUntil.Completed, createParams).ConfigureAwait(false);
            SparkBatchJob jobCreateResponse = sparkBatchOperation.Value;

            // Verify the Spark batch job submission starts successfully
            Assert.True(LivyStates.Starting == jobCreateResponse.State || LivyStates.Running == jobCreateResponse.State || LivyStates.Success == jobCreateResponse.State,
                string.Format(
                    "Job: {0} did not return success. Current job state: {1}. Error (if any): {2}",
                    jobCreateResponse.Id,
                    jobCreateResponse.State,
                    string.Join(", ", jobCreateResponse.Errors ?? new List<SparkServiceError>())
                )
            );

            // Get the list of Spark batch jobs and check that the submitted job exists
            List<SparkBatchJob> listJobResponse = await SparkTestUtilities.ListSparkBatchJobsAsync(client);
            Assert.NotNull(listJobResponse);
            Assert.IsTrue(listJobResponse.Any(job => job.Id == jobCreateResponse.Id));
        }

        [RecordedTest]
        public async Task TestSparkBatchJobCompletesWhenJobComplete()
        {
            SparkBatchClient client = CreateClient();

            SparkBatchJobOptions createParams = SparkTestUtilities.CreateSparkJobRequestParameters(Recording, TestEnvironment);

            // Set completion type to wait for completion of job execution.
            createParams.CreationCompletionType = SparkBatchOperationCompletionType.JobExecution;

            var createOperation = await client.CreateSparkBatchJobAsync(WaitUntil.Completed, createParams).ConfigureAwait(false);
            SparkBatchJob jobCreateResponse = createOperation.Value;

            // Verify the Spark batch job exuecution completes successfully
            Assert.True(LivyStates.Success == jobCreateResponse.State  && jobCreateResponse.Result == SparkBatchJobResultType.Succeeded,
                string.Format(
                    "Job: {0} did not return success. Current job state: {1}. Actual result: {2}. Error (if any): {3}",
                    jobCreateResponse.Id,
                    jobCreateResponse.State,
                    jobCreateResponse.Result,
                    string.Join(", ", jobCreateResponse.Errors ?? new List<SparkServiceError>())
                )
            );

            // Get the list of Spark batch jobs and check that the submitted job exists
            List<SparkBatchJob> listJobResponse = await SparkTestUtilities.ListSparkBatchJobsAsync(client);
            Assert.NotNull(listJobResponse);
            Assert.IsTrue(listJobResponse.Any(job => job.Id == jobCreateResponse.Id));
        }

        [RecordedTest]
        public async Task TestSparkBatchOperationPublicConstructor()
        {
            SparkBatchClient client = CreateClient();

            // Submit the Spark job
            SparkBatchJobOptions createParams = SparkTestUtilities.CreateSparkJobRequestParameters(Recording, TestEnvironment);
            SparkBatchOperation createOperation = await client.CreateSparkBatchJobAsync(WaitUntil.Started, createParams);

            // Create another SparkBatchOperation
            SparkBatchOperation anotherOperation =
                InstrumentOperation(new SparkBatchOperation(int.Parse(createOperation.Id), client, createOperation.CompletionType));
            SparkBatchJob jobCreateResponse = await anotherOperation.WaitForCompletionAsync();

            // Verify the Spark batch job submission starts successfully
            Assert.True(LivyStates.Starting == jobCreateResponse.State || LivyStates.Running == jobCreateResponse.State || LivyStates.Success == jobCreateResponse.State,
                string.Format(
                    "Job: {0} did not return success. Current job state: {1}. Error (if any): {2}",
                    jobCreateResponse.Id,
                    jobCreateResponse.State,
                    string.Join(", ", jobCreateResponse.Errors ?? new List<SparkServiceError>())
                )
            );

            // Get the list of Spark batch jobs and check that the submitted job exists
            List<SparkBatchJob> listJobResponse = await SparkTestUtilities.ListSparkBatchJobsAsync(client);
            Assert.NotNull(listJobResponse);
            Assert.IsTrue(listJobResponse.Any(job => job.Id == jobCreateResponse.Id));
        }

        [RecordedTest]
        public async Task TestGetSparkBatchJob()
        {
            SparkBatchClient client = CreateClient();

            SparkBatchJobCollection sparkJobs = (await client.GetSparkBatchJobsAsync()).Value;
            foreach (SparkBatchJob expectedSparkJob in sparkJobs.Sessions)
            {
                try
                {
                    SparkBatchJob actualSparkJob = await client.GetSparkBatchJobAsync(expectedSparkJob.Id);
                    ValidateSparkBatchJob(expectedSparkJob, actualSparkJob);
                }
                catch (Azure.RequestFailedException)
                {
                }
            }
        }

       internal void ValidateSparkBatchJob(SparkBatchJob expectedSparkJob, SparkBatchJob actualSparkJob)
       {
            Assert.AreEqual(expectedSparkJob.Name, actualSparkJob.Name);
            Assert.AreEqual(expectedSparkJob.Id, actualSparkJob.Id);
            Assert.AreEqual(expectedSparkJob.AppId, actualSparkJob.AppId);
            Assert.AreEqual(expectedSparkJob.SubmitterId, actualSparkJob.SubmitterId);
            Assert.AreEqual(expectedSparkJob.ArtifactId, actualSparkJob.ArtifactId);
        }
    }
}
