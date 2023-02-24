// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:SentSharesClientSample_ImportNamespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
#endregion
using Azure.Core.TestFramework;

namespace Azure.Analytics.Purview.Sharing.Tests.Samples
{
    public class Sample1_CreateSentShare : SentSharesClientTestBase
    {
        public Sample1_CreateSentShare(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CreateSentShareTest()
        {
            #region Snippet:SentSharesClientSample_CreateSentShare

            #region Snippet:SentSharesClientSample_CreateSentSharesClient
#if SNIPPET
            var credential = new DefaultAzureCredential();
            var endPoint = "https://my-account-name.purview.azure.com/share";
            var sentShareClient = new SentSharesClient(endPoint, credential);
#else
            var sentShareClient = GetSentSharesClient();
#endif
            #endregion

            var data = new
            {
                shareKind = "InPlace",
                properties = new
                {
                    artifact = new
                    {
                        storeKind = "AdlsGen2Account",
                        storeReference = new
                        {
#if SNIPPET
                            referenceName = "/subscriptions/subscriptionId"/resourceGroups/resourceGroup/providers/Microsoft.Storage/storageAccounts/sharerStorageAccount",
#else
                            referenceName = "/subscriptions/0f3dcfc3-18f8-4099-b381-8353e19d43a7/resourceGroups/faisalaltell/providers/Microsoft.Storage/storageAccounts/ftsharersan",
#endif
                            type = "ArmResourceReference"
                        },
                        properties = new
                        {
                            paths = new[]
                           {
                                new
                                {
#if SNIPPET
                                    containerName = "containerName",
                                    senderPath = "senderPath",
                                    receiverPath = "receiverPath"
#else
                                    containerName = "container1",
                                    senderPath = "testfolder1",
                                    receiverPath = "testfolder1"
#endif
                                }
                            }
                        }
                    },
#if SNIPPET
                    displayName = "displayName",
                    description = "description",
#else
                    displayName = "testDisplayName1",
                    description = "updatedDescription",
#endif
                }
            };

#if SNIPPET
            Operation<BinaryData> createResponse = await sentShareClient.CreateOrReplaceSentShareAsync(WaitUntil.Completed, "sentShareId", RequestContent.Create(data));
#else
            Operation<BinaryData> createResponse = await sentShareClient.CreateOrReplaceSentShareAsync(WaitUntil.Completed, "7911b09b-9cb3-416a-a3f0-e242c0bfd574", RequestContent.Create(data));
#endif

            #endregion
        }
    }
}
