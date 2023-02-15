// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using System.Collections.Generic;

namespace Azure.Analytics.Purview.Share.Tests.Samples
{
    public class Sample11_ListAttachedReceivedShares : ReceivedSharesClientTestBase
    {
        public Sample11_ListAttachedReceivedShares(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task ListAttachedReceivedShares()
        {
            #region Snippet:ReceivedSharesClientSample_ListAttachedReceivedShares

#if SNIPPET
            var credential = new DefaultAzureCredential();
            var endPoint = "https://<my-account-name>.purview.azure.com/share";
            var receivedSharesClient = new ReceivedSharesClient(endPoint, credential);

            List<BinaryData> createResponse = await receivedSharesClient.GetAllAttachedReceivedSharesAsync(<referenceName>).ToEnumerableAsync();
#else
            var receivedSharesClient = GetReceivedSharesClient();

            List<BinaryData> createResponse = await receivedSharesClient.GetAllAttachedReceivedSharesAsync("/subscriptions/0f3dcfc3-18f8-4099-b381-8353e19d43a7/resourceGroups/faisalaltell/providers/Microsoft.Storage/storageAccounts/ftreceiversan").ToEnumerableAsync();
#endif

            #endregion
        }
    }
}
