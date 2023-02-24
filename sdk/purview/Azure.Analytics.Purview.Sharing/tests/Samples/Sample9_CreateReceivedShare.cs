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
            var endPoint = "https://my-account-name.purview.azure.com/share";
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
                            referenceName = "/subscriptions/0f3dcfc3-18f8-4099-b381-8353e19d43a7/resourceGroups/faisalaltell/providers/Microsoft.Storage/storageAccounts/ftreceiversan",
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
                            containerName = "container222843",
                            folder = "folder222843",
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
            Operation<BinaryData> createResponse = await receivedSharesClient.CreateOrReplaceReceivedShareAsync(WaitUntil.Completed, "4298d43f-7bc0-46b6-84a1-354c621d79a4", RequestContent.Create(data));
#endif

#endregion
        }
    }
}
