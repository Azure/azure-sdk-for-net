// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.FileShares.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.FileShares.Tests
{
    public class FileShareNameAvailabilityTests : FileSharesManagementTestBase
    {
        public FileShareNameAvailabilityTests(bool isAsync)
            : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task CheckNameAvailable()
        {
            string uniqueName = Recording.GenerateAssetName("fileshare");
            var content = new FileShareNameAvailabilityContent
            {
                Name = uniqueName,
                Type = "Microsoft.FileShares/fileShares",
            };

            var result = await DefaultSubscription.CheckFileShareNameAvailabilityAsync(
                new AzureLocation(DefaultLocation), content);

            Assert.IsNotNull(result.Value);
            Assert.IsTrue(result.Value.IsNameAvailable);
        }

        [TestCase]
        [RecordedTest]
        public async Task CheckNameNotAvailable()
        {
            // Create a file share first
            var resourceGroup = await CreateResourceGroup("fileshare-rg");
            string fileShareName = Recording.GenerateAssetName("fileshare");
            await CreateFileShare(resourceGroup, fileShareName);

            // Check availability of the same name - should not be available
            var content = new FileShareNameAvailabilityContent
            {
                Name = fileShareName,
                Type = "Microsoft.FileShares/fileShares",
            };

            var result = await DefaultSubscription.CheckFileShareNameAvailabilityAsync(
                new AzureLocation(DefaultLocation), content);

            Assert.IsNotNull(result.Value);
            Assert.IsFalse(result.Value.IsNameAvailable);
        }
    }
}
