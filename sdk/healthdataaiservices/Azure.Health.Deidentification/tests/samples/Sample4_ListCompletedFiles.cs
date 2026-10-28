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
        public void ListCompletedFiles()
        {
            string serviceEndpoint = TestEnvironment.Endpoint;
            TokenCredential credential = TestEnvironment.Credential;

            DeidentificationClient client = new(
                new Uri(serviceEndpoint),
                credential,
                new DeidentificationClientOptions()
            );

            // Create and complete a job so there are documents to list; kept outside the snippet.
            string storageAccountUrl = TestEnvironment.GetStorageAccountLocation();
            string jobName = $"net-sample-{Guid.NewGuid():N}".Substring(0, 23);
            DeidentificationJob job = new()
            {
                SourceLocation = new SourceStorageLocation(new Uri(storageAccountUrl), "example_patient_1/"),
                TargetLocation = new TargetStorageLocation(new Uri(storageAccountUrl), "output_folder1/") { Overwrite = true },
                OperationType = DeidentificationOperationType.Redact,
            };
            client.DeidentifyDocuments(WaitUntil.Completed, jobName, job);

            #region Snippet:AzHealthDeidSample4_ListCompletedFiles
            Pageable<DeidentificationDocumentDetails> files = client.GetJobDocuments(jobName);

            foreach (DeidentificationDocumentDetails file in files)
            {
                Console.WriteLine($"File Name: {file.InputLocation.Location}");
                Console.WriteLine($"File Status: {file.Status}");
                Console.WriteLine($"File Output Path: {file.OutputLocation.Location}");
            }
            #endregion
        }
    }
}
