// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Analytics.Synapse.Spark.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.Analytics.Synapse.Spark.Tests
{
    /// <summary>
    /// The suite of tests for the <see cref="SparkBatchClient"/> class.
    /// </summary>
    /// <remarks>
    /// These tests have a dependency on live Azure services and may incur costs for the associated
    /// Azure subscription.
    /// </remarks>
    public class SparkBatchClientLiveTests : SparkClientTestBase
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SparkBatchClientLiveTests"/> class.
        /// </summary>
        /// <param name="isAsync">A flag used by the Azure Core Test Framework to differentiate between tests for asynchronous and synchronous methods.</param>
        public SparkBatchClientLiveTests(bool isAsync) : base(isAsync)
        {
        }

        /// <summary>
        /// Verifies that the <see cref="SparkBatchClient" /> is able to connect to the
        /// Azure Synapse Analytics service and perform operations.
        /// </summary>
        [Test]
        [Ignore("This test case cannot pass due to backend limitations for service principals.")]
        public async Task TestSparkBatchJob()
        {
            // Submit the Spark job
            SparkBatchJobOptions createParams = this.CreateSparkJobRequestParameters();
            SparkBatchOperation createOperation = await SparkBatchClient.StartCreateSparkBatchJobAsync(createParams);
            SparkBatchJob jobCreateResponse = await createOperation.WaitForCompletionAsync();

            // Verify the Spark batch job completes successfully
            Assert.True("success".Equals(jobCreateResponse.State, StringComparison.OrdinalIgnoreCase) && jobCreateResponse.Result == SparkBatchJobResultType.Succeeded,
                string.Format(
                    "Job: {0} did not return success. Current job state: {1}. Actual result: {2}. Error (if any): {3}",
                    jobCreateResponse.Id,
                    jobCreateResponse.State,
                    jobCreateResponse.Result,
                    string.Join(", ", jobCreateResponse.Errors ?? new List<SparkServiceError>())
                )
            );

            // Get the list of Spark batch jobs and check that the submitted job exists
            List<SparkBatchJob> listJobResponse = await this.ListSparkBatchJobsAsync();
            Assert.NotNull(listJobResponse);
            Assert.IsTrue(listJobResponse.Any(job => job.Id == jobCreateResponse.Id));
        }

        [Test]
        public async Task TestGetSparkBatchJob()
        {
            SparkBatchJobCollection sparkJobs = (await SparkBatchClient.GetSparkBatchJobsAsync()).Value;
            foreach (SparkBatchJob expectedSparkJob in sparkJobs.Sessions)
            {
                try
                {
                    SparkBatchJob actualSparkJob = await SparkBatchClient.GetSparkBatchJobAsync(expectedSparkJob.Id);
                    ValidateSparkBatchJob(expectedSparkJob, actualSparkJob);
                }
                catch (Azure.RequestFailedException)
                {
                }
            }
        }
    }
}
