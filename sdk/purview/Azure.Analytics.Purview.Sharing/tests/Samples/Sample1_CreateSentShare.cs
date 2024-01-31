// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:SentSharesClientSample_ImportNamespaces
using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
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
            var endPoint = new Uri("https://my-account-name.purview.azure.com/share");
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
                            referenceName = "/subscriptions/subscriptionId/resourceGroups/resourceGroup/providers/Microsoft.Storage/storageAccounts/sharerStorageAccount",
#else
                            referenceName = "/subscriptions/d941aad1-e4af-44a5-a70e-0381a9f702f1/resourcegroups/dev-rg/providers/Microsoft.Storage/storageAccounts/provideraccount",
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
            Operation<BinaryData> createResponse = await sentShareClient.CreateOrReplaceSentShareAsync(WaitUntil.Completed, "016eb068-ddaa-41be-8804-8bef566663a5", RequestContent.Create(data));
#endif

            #endregion
        }
    }
}
