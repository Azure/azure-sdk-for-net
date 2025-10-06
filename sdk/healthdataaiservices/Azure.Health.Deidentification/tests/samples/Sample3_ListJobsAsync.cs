// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Health.Deidentification.Tests;
using NUnit.Framework;

namespace Azure.Health.Deidentification.Samples
{
    public partial class Samples_DeidentificationClient : SamplesBase<DeidentificationTestEnvironment>
    {
        [Test]
        public async Task ListJobsAsync()
        {
            string serviceEndpoint = TestEnvironment.Endpoint;
            TokenCredential credential = TestEnvironment.Credential;

            DeidentificationClient client = new(
                new Uri(serviceEndpoint),
                credential,
                new DeidentificationClientOptions()
            );

            #region Snippet:AzHealthDeidSample3Async_ListJobs
            AsyncPageable<DeidentificationJob> jobs = client.GetJobsAsync();

            await foreach (DeidentificationJob job in jobs)
            {
                Console.WriteLine($"Job Name: {job.JobName}");
                Console.WriteLine($"Job Status: {job.Status}");
            }
            #endregion
        }
    }
}
