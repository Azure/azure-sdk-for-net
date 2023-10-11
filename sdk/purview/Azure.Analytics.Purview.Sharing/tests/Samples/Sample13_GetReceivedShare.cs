// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using System;

namespace Azure.Analytics.Purview.Sharing.Tests.Samples
{
    public class Sample13_GetReceivedShare : ReceivedSharesClientTestBase
    {
        public Sample13_GetReceivedShare(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task GetReceivedShareTest()
        {
            #region Snippet:ReceivedSharesClientSample_GetReceivedShare

#if SNIPPET
            var credential = new DefaultAzureCredential();
            var endPoint = new Uri("https://my-account-name.purview.azure.com/share");
            var receivedSharesClient = new ReceivedSharesClient(endPoint, credential);
#else
            var receivedSharesClient = GetReceivedSharesClient();
#endif

#if SNIPPET
            Response operation = await receivedSharesClient.GetReceivedShareAsync("receivedShareId", new());
#else
            Response operation = await receivedSharesClient.GetReceivedShareAsync("11726395-c265-4d91-acc8-7bb2cc650f5c", new());
#endif

#endregion
        }
    }
}
