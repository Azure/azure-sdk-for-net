// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using System.Collections.Generic;

namespace Azure.Analytics.Purview.Sharing.Tests.Samples
{
    public class Sample10_ListDetachedReceivedShares : ReceivedSharesClientTestBase
    {
        public Sample10_ListDetachedReceivedShares(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task ListDetachedReceivedShares()
        {
            #region Snippet:ReceivedSharesClientSample_ListDetachedReceivedShares

#if SNIPPET
            var credential = new DefaultAzureCredential();
            var endPoint = "https://<my-account-name>.purview.azure.com/share";
            var receivedSharesClient = new ReceivedSharesClient(endPoint, credential);
#else
            var receivedSharesClient = GetReceivedSharesClient();
#endif

            List<BinaryData> createResponse = await receivedSharesClient.GetAllDetachedReceivedSharesAsync().ToEnumerableAsync();

            #endregion
        }
    }
}
