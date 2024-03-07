// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.TestFramework;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.TestFramework;
using NUnit.Framework;
using System.IO;
using System;
using System.Threading.Tasks;

namespace Azure.ResourceManager.MigrationDiscoverySap.Tests
{
    public class MigrationDiscoverySapManagementTestBase : ManagementRecordedTestBase<MigrationDiscoverySapManagementTestEnvironment>
    {
        protected ArmClient Client { get; private set; }
        protected SubscriptionResource DefaultSubscription { get; private set; }

        protected MigrationDiscoverySapManagementTestBase(bool isAsync, RecordedTestMode mode)
        : base(isAsync, mode)
        {
        }

        protected MigrationDiscoverySapManagementTestBase(bool isAsync)
            : base(isAsync)
        {
        }

        [SetUp]
        public async Task CreateCommonClient()
        {
            Client = GetArmClient();
            DefaultSubscription = await Client.GetDefaultSubscriptionAsync().ConfigureAwait(false);
        }

        protected async Task<ResourceGroupResource> CreateResourceGroup(SubscriptionResource subscription, string rgNamePrefix, AzureLocation location)
        {
            string rgName = Recording.GenerateAssetName(rgNamePrefix);
            ResourceGroupData input = new ResourceGroupData(location);
            var lro = await subscription.GetResourceGroups().CreateOrUpdateAsync(WaitUntil.Completed, rgName, input);
            return lro.Value;
        }

        /// <summary>
        /// Get Blob Content client with blob uri and SaS token.
        /// </summary>
        /// <param name="sasUri">The SAS Uri of the blob.</param>
        /// <returns>Blob content client.</returns>
        protected Azure.Storage.Blobs.BlobClient GetBlobContentClient(string sasUri)
        {
            // Split the sas uri into blob uri and sas token.
            // https://learn.microsoft.com/en-us/azure/ai-services/translator/document-translation/how-to-guides/create-sas-tokens?tabs=blobs#use-your-sas-url-to-grant-access-to-blob-storage
            var sasUriFragment = sasUri.Split('?');
            // Checks if the sas uri fragments are not-empty, not-null and has 2 elements.
            if (sasUriFragment.Length != 2)
            {
                throw new InvalidDataException(
                    $"Invalid sas uri: {sasUri}. Sas uri should be in the format of <blobUri>?<sasToken>");
            }

            // Construct the blob client with a sas token.
            var blobClient = new Azure.Storage.Blobs.BlobClient(
                new Uri(sasUriFragment[0]),
                new AzureSasCredential(sasUriFragment[1]));

            return blobClient;
        }

        /// <summary>
        /// Tracks till it satisfies the input condition (boolean function).
        /// </summary>
        /// <param name="func">The function describing the condition was achieved or not.</param>
        /// <param name="totalCount">The total count to loop.</param>
        /// <returns>The status on whether the condition was achieved.</returns>
        protected static async Task<bool> TrackTillConditionReachedForAsyncOperationAsync(
            Func<Task<bool>> func,
            int totalCount = 100)
        {
            var isConditionReached = false;
            int counter = 0;
            while (counter < totalCount)
            {
                await Task.Delay(TimeSpan.FromSeconds(2));
                if (await func())
                {
                    isConditionReached = true;
                    break;
                }

                counter++;
            }

            return isConditionReached;
        }
    }
}
