// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;

namespace Azure.Analytics.Purview.Share.Tests.Samples
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
            var endPoint = "https://<my-account-name>.purview.azure.com/share";
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
                            referenceName = "/subscriptions/<suscriptionId>/resourceGroups/<resourceGroup>/providers/Microsoft.Storage/storageAccounts/<storageAccount>",
#else
                            referenceName = "/subscriptions/0f3dcfc3-18f8-4099-b381-8353e19d43a7/resourceGroups/faisalaltell/providers/Microsoft.Storage/storageAccounts/ftreceiversan",
#endif

                            type = "ArmResourceReference"
                        },
                        properties = new
                        {
#if SNIPPET
                            containerName = <>,
                            folder = <>,
                            mountPath = <>,
#else
                            containerName = "container214746",
                            folder = "folder214746",
                            mountPath = "",
#endif
                        }
                    },
#if SNIPPET
                    displayName = <displayName>,
#else
                    displayName = "testDisplayName1",
#endif
                }
            };

#if SNIPPET
            Operation<BinaryData> createResponse = await receivedSharesClient.CreateOrReplaceReceivedShareAsync(WaitUntil.Completed, <receivedShareId>, RequestContent.Create(data));
#else
            Operation<BinaryData> createResponse = await receivedSharesClient.CreateOrReplaceReceivedShareAsync(WaitUntil.Completed, "7de5fc90-2960-45a0-adb4-940db27a2305", RequestContent.Create(data));
#endif

#endregion
        }
    }
}
