// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
#region Snippet:Azure_Analytics_Purview_Share_Samples_02_Namespaces
using Azure.Core;
using Azure.Identity;
#endregion Azure_Analytics_Purview_Share_Samples_02_Namespaces

namespace Azure.Analytics.Purview.Share.Tests.Samples
{
    [TestFixture]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name", Justification = "For documentation purposes")]
    internal class AddAnAssetToASentShareSample : ShareClientTestBase
    {
        public AddAnAssetToASentShareSample() : base(true)
        {
        }

        [RecordedTest]
        public async Task AddAnAssetToASentShare()
        {
            #region Snippet:Azure_Analytics_Purview_Share_Samples_AddAnAssetToASentShare
#if SNIPPET
            var credential = new DefaultAzureCredential();
            var endPoint = "https://<my-account-name>.purview.azure.com/share";
#else
            var credential = TestEnvironment.Credential;
            var endPoint = TestEnvironment.Endpoint.ToString();
#endif

            // Add asset to sent share
            var sentShareName = "sample-Share";
            var assetName = "fabrikam-blob-asset";
            var assetNameForReceiver = "receiver-visible-asset-name";
#if SNIPPET
            var senderStorageResourceId = "<SENDER_STORAGE_ACCOUNT_RESOURCE_ID>";
#else
            var senderStorageResourceId = "/subscriptions/0f3dcfc3-18f8-4099-b381-8353e19d43a7/resourceGroups/yaman-rg/providers/Microsoft.Storage/storageAccounts/yamanstorage";
#endif
            var senderStorageContainer = "fabrikamcontainer";
            var senderPathToShare = "folder/sample.txt";
            var pathNameForReceiver = "from-fabrikam";

            var assetData = new
            {
                // For Adls Gen2 asset use "AdlsGen2Account"
                kind = "blobAccount",
                properties = new
                {
                    storageAccountResourceId = senderStorageResourceId,
                    receiverAssetName = assetNameForReceiver,
                    paths = new[]
                    {
                        new
                        {
                            containerName = senderStorageContainer,
                            senderPath = senderPathToShare,
                            receiverPath = pathNameForReceiver
                        }
                    }
                }
            };
#if SNIPPET
            var assetsClient = new AssetsClient(endPoint, credential);
#else
            var assetsClient = GetAssetsClient();
#endif
            await assetsClient.CreateAsync(WaitUntil.Started, sentShareName, assetName, RequestContent.Create(assetData));
#endregion Snippet:Azure_Analytics_Purview_Share_Samples_AddAnAssetToASentShare
        }
    }
}
