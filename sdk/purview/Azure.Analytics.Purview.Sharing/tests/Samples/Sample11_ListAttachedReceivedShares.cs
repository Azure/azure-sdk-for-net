// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using System.Collections.Generic;
using Azure.Identity;

namespace Azure.Analytics.Purview.Sharing.Tests.Samples
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
            var endPoint = new Uri("https://my-account-name.purview.azure.com/share");
            var receivedSharesClient = new ReceivedSharesClient(endPoint, credential);

            List<BinaryData> createResponse = await receivedSharesClient.GetAllAttachedReceivedSharesAsync("referenceName", null, null, new()).ToEnumerableAsync();
#else
            var receivedSharesClient = GetReceivedSharesClient();

            List<BinaryData> createResponse = await receivedSharesClient.GetAllAttachedReceivedSharesAsync("/subscriptions/d941aad1-e4af-44a5-a70e-0381a9f702f1/resourcegroups/dev-rg/providers/Microsoft.Storage/storageAccounts/consumeraccount", null, null, new()).ToEnumerableAsync();
#endif

            #endregion
        }
    }
}
