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
        public async void ListCompletedFilesAsync()
        {
            const string serviceEndpoint = "https://example.api.cac001.deid.azure.com";
            TokenCredential credential = TestEnvironment.Credential;

            DeidentificationClient client = new(
                new Uri(serviceEndpoint),
                credential,
                new DeidentificationClientOptions()
            );

            #region Snippet:AzHealthDeidSample4Async_ListCompletedFiles
            AsyncPageable<DocumentDetails> files = client.GetJobDocumentsAsync("job-name-1");

            await foreach (DocumentDetails file in files)
            {
                Console.WriteLine($"File Name: {file.Input.Path}");
                Console.WriteLine($"File Status: {file.Status}");
                Console.WriteLine($"File Output Path: {file.Output.Path}");
            }
            #endregion
        }
    }
}
