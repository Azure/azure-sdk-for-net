// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;

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
            var endPoint = "https://my-account-name.purview.azure.com/share";
            var receivedSharesClient = new ReceivedSharesClient(endPoint, credential);
#else
            var receivedSharesClient = GetReceivedSharesClient();
#endif

#if SNIPPET
            Response operation = await receivedSharesClient.GetReceivedShareAsync("receivedShareId");
#else
            Response operation = await receivedSharesClient.GetReceivedShareAsync("bb00baac-b768-4004-a712-c5b942dc9e83");
#endif

#endregion
        }
    }
}
