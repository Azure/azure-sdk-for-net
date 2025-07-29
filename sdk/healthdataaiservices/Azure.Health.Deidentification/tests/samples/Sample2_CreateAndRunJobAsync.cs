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
        public async Task CreateAndRunJobAsync()
        {
            string serviceEndpoint = TestEnvironment.Endpoint;
            TokenCredential credential = TestEnvironment.Credential;

            DeidentificationClient client = new(
                new Uri(serviceEndpoint),
                credential,
                new DeidentificationClientOptions()
            );

            string storageAccountUrl = TestEnvironment.GetStorageAccountLocation();

            #region Snippet:AzHealthDeidSample2Async_CreateJob
            DeidentificationJob job = new()
            {
                SourceLocation = new SourceStorageLocation(new Uri(storageAccountUrl), "folder1/"),
                TargetLocation = new TargetStorageLocation(new Uri(storageAccountUrl), "output_folder1/"),
                OperationType = DeidentificationOperationType.Redact,
            };

            job = (await client.DeidentifyDocumentsAsync(WaitUntil.Completed, "my-job-1", job)).Value;
            Console.WriteLine($"Job Status: {job.Status}"); // Job Status: Completed
            #endregion
        }
    }
}
