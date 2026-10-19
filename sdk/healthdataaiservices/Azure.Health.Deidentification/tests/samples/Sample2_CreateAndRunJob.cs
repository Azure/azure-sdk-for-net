// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Health.Deidentification.Tests;
using NUnit.Framework;

namespace Azure.Health.Deidentification.Samples
{
    public partial class Samples_DeidentificationClient : SamplesBase<DeidentificationTestEnvironment>
    {
        [Test]
        public void CreateAndRunJob()
        {
            string serviceEndpoint = TestEnvironment.Endpoint;
            TokenCredential credential = TestEnvironment.Credential;

            DeidentificationClient client = new(
                new Uri(serviceEndpoint),
                credential,
                new DeidentificationClientOptions()
            );

            string storageAccountUrl = TestEnvironment.GetStorageAccountLocation();
            // Unique per run so repeated live runs against the same resource don't collide.
            string jobName = $"net-sample-{Guid.NewGuid():N}".Substring(0, 23);

            #region Snippet:AzHealthDeidSample2_CreateJob
            DeidentificationJob job = new()
            {
                SourceLocation = new SourceStorageLocation(new Uri(storageAccountUrl), "example_patient_1/"),
                TargetLocation = new TargetStorageLocation(new Uri(storageAccountUrl), "output_folder1/") { Overwrite = true },
                OperationType = DeidentificationOperationType.Redact,
            };

            job = client.DeidentifyDocuments(WaitUntil.Started, jobName, job).Value;
            Console.WriteLine($"Job status: {job.Status}"); // Job status: NotStarted
            #endregion
        }
    }
}
