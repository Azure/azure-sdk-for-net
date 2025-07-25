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

            #region Snippet:AzHealthDeidSample4_ListCompletedFiles
            Pageable<DeidentificationDocumentDetails> files = client.GetJobDocuments("job-name-1");

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
