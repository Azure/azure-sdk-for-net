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
        public GetReceivedAssetsSample(bool isAsync, RecordedTestMode? mode = null) : base(isAsync, mode)
        {
        }

        [Test]
        public async Task GetReceivedShares()
        {
            #region Snippet:Azure_Analytics_Purview_Share_Samples_GetReceivedAssets
#if SNIPPET
            var credential = new DefaultAzureCredential();
            var endPoint = "https://<my-account-name>.purview.azure.com/share";

#else
            var credential = TestEnvironment.Credential;
            var endPoint = TestEnvironment.Endpoint.ToString();

#endif
            // Get received assets
            var receivedShareName = "fabrikam-received-share";
            var receivedAssetsClient = new ReceivedAssetsClient(endPoint, credential);
            var receivedAssets = receivedAssetsClient.GetReceivedAssets(receivedShareName);
            var receivedAssetName = JsonDocument.Parse(receivedAssets.First()).RootElement.GetProperty("name").GetString();

            string assetMappingName = "receiver-asset-mapping";
            string receiverContainerName = "receivedcontainer";
            string receiverFolderName = "receivedfolder";
            string receiverMountPath = "receivedmountpath";
            string receiverStorageResourceId = "<RECEIVER_STORAGE_ACCOUNT_RESOURCE_ID>";

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

            var assetMappingsClient = new AssetMappingsClient(endPoint, credential);
            var assetMapping = await assetMappingsClient.CreateAsync(WaitUntil.Completed, receivedShareName, assetMappingName, RequestContent.Create(assetMappingData));
            #endregion Snippet:Azure_Analytics_Purview_Share_Samples_GetReceivedAssets
        }
    }
}
