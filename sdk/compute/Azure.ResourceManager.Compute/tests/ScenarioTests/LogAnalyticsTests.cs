// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Compute.Models;
using Azure.Management.Resources;
using Azure.Management.Storage.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Compute.Tests
{
    [AsyncOnly]
    public class LogAnalyticsTests : VMTestBase
    {
        public LogAnalyticsTests(bool isAsync)
           : base(isAsync)
        {
        }

        [SetUp]
        public void ClearChallengeCacheforRecord()
        {
            if (Mode == RecordedTestMode.Record || Mode == RecordedTestMode.Playback)
            {
                InitializeBase();
            }
        }

        [TearDown]
        public async Task CleanupResourceGroup()
        {
            await CleanupResourceGroupsAsync();
        }

        [Test]
        [Ignore("TRACK2: compute team will help to record")]
        public async Task TestExportingThrottlingLogs()
        {
            string rg1Name = Recording.GenerateAssetName(TestPrefix);

            string storageAccountName = Recording.GenerateAssetName(TestPrefix);
            EnsureClientsInitialized(DefaultLocation);

            string sasUri = await GetBlobContainerSasUri(rg1Name, storageAccountName);

            RequestRateByIntervalInput requestRateByIntervalInput = new RequestRateByIntervalInput(sasUri, Recording.UtcNow.AddDays(-10), Recording.UtcNow.AddDays(-8), IntervalInMins.FiveMins);

            var result = await WaitForCompletionAsync(await LogAnalyticsOperations.StartExportRequestRateByIntervalAsync("westcentralus", requestRateByIntervalInput));
            //BUG: LogAnalytics API does not return correct result.
            //Assert.EndsWith(".csv", result.Properties.Output);

            ThrottledRequestsInput throttledRequestsInput = new ThrottledRequestsInput(sasUri, Recording.UtcNow.AddDays(-10), Recording.UtcNow.AddDays(-8))
            {
                GroupByOperationName = true,
            };

            var result1 = await WaitForCompletionAsync(await LogAnalyticsOperations.StartExportThrottledRequestsAsync("westcentralus", throttledRequestsInput));

            //BUG: LogAnalytics API does not return correct result.
            //Assert.EndsWith(".csv", result.Properties.Output);
        }

        private async Task<string> GetBlobContainerSasUri(string rg1Name, string storageAccountName)
        {
            string sasUri = "foobar";

            if (Mode == RecordedTestMode.Record)
            {
                StorageAccount storageAccountOutput = await CreateStorageAccount(rg1Name, storageAccountName);
                var accountKeyResult = (await StorageAccountsOperations.ListKeysAsync(rg1Name, storageAccountName)).Value;
                //var accountKeyResult = await StorageAccountsClient.ListKeysWithHttpMessagesAsync(rg1Name, storageAccountName).Result;
                StorageAccount storageAccount = new StorageAccount(DefaultLocation);

                BlobContainer container = await BlobContainersOperations.GetAsync(rg1Name, storageAccountName, "sascontainer");
                //container.CreateIfNotExistsAsync();
                sasUri = GetContainerSasUri(container);
            }

            return sasUri;
        }

        private string GetContainerSasUri(BlobContainer container)
        {
            //SharedAccessBlobPolicy sasConstraints = new SharedAccessBlobPolicy();
            //sasConstraints.SharedAccessStartTime = Recording.UtcNow.AddDays(-1);
            //sasConstraints.SharedAccessExpiryTime = Recording.UtcNow.AddDays(2);
            //sasConstraints.Permissions = SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.Write;

            ////Generate the shared access signature on the blob, setting the constraints directly on the signature.
            //string sasContainerToken = container.GetSharedAccessSignature(sasConstraints);

            ////Return the URI string for the container, including the SAS token.
            //return container.Uri + sasContainerToken;
            return "just a url";
        }
    }
}
