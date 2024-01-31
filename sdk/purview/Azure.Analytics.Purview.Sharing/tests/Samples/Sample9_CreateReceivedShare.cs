// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:ReceivedSharesClientSample_ImportNamespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
#endregion
using Azure.Core.TestFramework;

namespace Azure.Analytics.Purview.Sharing.Tests.Samples
{
    public class Sample9_CreateReceivedShare : ReceivedSharesClientTestBase
    {
        public Sample9_CreateReceivedShare(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CreateReceivedShareTest()
        {
            #region Snippet:ReceivedSharesClientSample_CreateReceivedShare

            #region Snippet:ReceivedSharesClientSample_CreateReceivedSharesClient
#if SNIPPET
            var credential = new DefaultAzureCredential();
            var endPoint = new Uri("https://my-account-name.purview.azure.com/share");
            var receivedSharesClient = new ReceivedSharesClient(endPoint, credential);
#else
            var receivedSharesClient = GetReceivedSharesClient();
#endif
            #endregion

            var data = new
            {
                shareKind = "InPlace",
                properties = new
                {
                    sink = new
                    {
                        storeKind = "AdlsGen2Account",
                        storeReference = new
                        {
#if SNIPPET
                            referenceName = "/subscriptions/suscriptionId/resourceGroups/resourceGroup/providers/Microsoft.Storage/storageAccounts/receiverStorageAccount",
#else
                            referenceName = "/subscriptions/d941aad1-e4af-44a5-a70e-0381a9f702f1/resourcegroups/dev-rg/providers/Microsoft.Storage/storageAccounts/consumeraccount",
#endif

                            type = "ArmResourceReference"
                        },
                        properties = new
                        {
#if SNIPPET
                            containerName = "containerName",
                            folder = "folder",
                            mountPath = "mountPath",
#else
                            containerName = "container2241218",
                            folder = "folder2241218",
                            mountPath = "",
#endif
                        }
                    },
#if SNIPPET
                    displayName = "displayName",
#else
                    displayName = "testDisplayName1",
#endif
                }
            };

#if SNIPPET
            Operation<BinaryData> createResponse = await receivedSharesClient.CreateOrReplaceReceivedShareAsync(WaitUntil.Completed, "receivedShareId", RequestContent.Create(data));
#else
            Operation<BinaryData> createResponse = await receivedSharesClient.CreateOrReplaceReceivedShareAsync(WaitUntil.Completed, "11726395-c265-4d91-acc8-7bb2cc650f5c", RequestContent.Create(data));
#endif

#endregion
        }
    }
}
