// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using Microsoft.Azure.WebJobs.Extensions.Storage.Common.Tests;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Hosting;
using NUnit.Framework;

namespace Microsoft.Azure.WebJobs.Extensions.Storage.Blobs
{
    public class StorageBlobsWebJobsBuilderExtensionsTests
    {
        [Test]
        public void ConfigureOptions_AppliesValuesCorrectly_Blobs()
        {
            string extensionPath = "AzureWebJobs:Extensions:Blobs";
            var values = new Dictionary<string, string>
            {
                { $"{extensionPath}:MaxDegreeOfParallelism", "2" },
                { $"{extensionPath}:PoisonBlobThreshold", "3" },
            };

            BlobsOptions options = TestHelpers.GetConfiguredOptions<BlobsOptions>(b =>
            {
                b.AddAzureStorageBlobs();
            }, values);

            Assert.AreEqual(2, options.MaxDegreeOfParallelism);
            Assert.AreEqual(3, options.PoisonBlobThreshold);
        }
    }
}
