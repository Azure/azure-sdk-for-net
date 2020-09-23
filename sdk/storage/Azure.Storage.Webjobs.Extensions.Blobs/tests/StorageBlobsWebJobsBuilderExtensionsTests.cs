// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Azure.WebJobs.Host.TestCommon;
using Microsoft.Extensions.Hosting;
using Xunit;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.UnitTests.Queues
{
    public class StorageBlobsWebJobsBuilderExtensionsTests
    {
        [Fact]
        public void ConfigureOptions_AppliesValuesCorrectly_Blobs()
        {
            string extensionPath = "AzureWebJobs:Extensions:Blobs";
            var values = new Dictionary<string, string>
            {
                { $"{extensionPath}:CentralizedPoisonQueue", "true" },
            };

            BlobsOptions options = TestHelpers.GetConfiguredOptions<BlobsOptions>(b =>
            {
                b.AddAzureStorageBlobs();
            }, values);

            Assert.True(options.CentralizedPoisonQueue);
        }
    }
}
