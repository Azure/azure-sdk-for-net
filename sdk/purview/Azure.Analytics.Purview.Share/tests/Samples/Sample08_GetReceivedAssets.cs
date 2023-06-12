// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
#region Snippet:Azure_Analytics_Purview_Share_Samples_08_Namespaces
using System;
using System.Linq;
using System.Text.Json;
using Azure.Core;
using Azure.Identity;
#endregion Snippet:Azure_Analytics_Purview_Share_Samples_08_Namespaces

namespace Azure.Analytics.Purview.Share.Tests.Samples
{
    [TestFixture]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name", Justification = "For documentation purposes")]
    internal class GetReceivedAssetsSample : ShareClientTestBase
    {
        public GetReceivedAssetsSample() : base(true)
        {
        }

        [RecordedTest]
        public async Task GetReceivedShares()
        {
            #region Snippet:Azure_Analytics_Purview_Share_Samples_GetReceivedAssets
            var receivedShareName = "sample-share";
#if SNIPPET
            var credential = new DefaultAzureCredential();
            var endPoint = "https://<my-account-name>.purview.azure.com/share";
            var receivedAssetsClient = new ReceivedAssetsClient(endPoint, credential);
#else
            var credential = TestEnvironment.Credential;
            var endPoint = TestEnvironment.Endpoint.ToString();
            var receivedAssetsClient = GetReceivedAssetsClient();
#endif

            // Get received assets
            var receivedAssets = await receivedAssetsClient.GetReceivedAssetsAsync(receivedShareName).ToEnumerableAsync();
            using var jsonDocument = JsonDocument.Parse(receivedAssets.First());
            var receivedAssetName = jsonDocument.RootElement.GetProperty("name").GetString();

            string assetMappingName = "receiver-asset-mapping";
            string receiverContainerName = "receivedcontainer";
            string receiverFolderName = "receivedfolder";
            string receiverMountPath = "receivedmountpath";
#if SNIPPET
            string receiverStorageResourceId = "<RECEIVER_STORAGE_ACCOUNT_RESOURCE_ID>";
#else
            string receiverStorageResourceId = "/subscriptions/0f3dcfc3-18f8-4099-b381-8353e19d43a7/resourceGroups/yaman-rg/providers/Microsoft.Storage/storageAccounts/yamanstorage";
#endif

            var assetMappingData = new
            {
                // For Adls Gen2 asset use "AdlsGen2Account"
                kind = "BlobAccount",
                properties = new
                {
                    assetId = Guid.Parse(receivedAssetName),
                    storageAccountResourceId = receiverStorageResourceId,
                    containerName = receiverContainerName,
                    folder = receiverFolderName,
                    mountPath = receiverMountPath
                }
            };

#if SNIPPET
            var assetMappingsClient = new AssetMappingsClient(endPoint, credential);
#else
            var assetMappingsClient = GetAssetMappingsClient();
#endif
            var assetMapping = await assetMappingsClient.CreateAsync(WaitUntil.Completed, receivedShareName, assetMappingName, RequestContent.Create(assetMappingData));
#endregion Snippet:Azure_Analytics_Purview_Share_Samples_GetReceivedAssets
        }
    }
}
