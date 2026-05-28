// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.Analytics.Purview.Sharing.Tests.Samples
{
    public class Sample12_DeleteReceivedShare : ReceivedSharesClientTestBase
    {
        public Sample12_DeleteReceivedShare(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task DeleteReceivedShareTest()
        {
            #region Snippet:ReceivedSharesClientSample_DeleteReceivedShare

#if SNIPPET
            var credential = new DefaultAzureCredential();
            var endPoint = new Uri("https://my-account-name.purview.azure.com/share");
            var receivedSharesClient = new ReceivedSharesClient(endPoint, credential);
#else
            var receivedSharesClient = GetReceivedSharesClient();
#endif

#if SNIPPET
            Operation operation = await receivedSharesClient.DeleteReceivedShareAsync(WaitUntil.Completed, "receivedShareId", new());
#else
            Operation operation = await receivedSharesClient.DeleteReceivedShareAsync(WaitUntil.Completed, "c2da55e1-c80c-4925-91fc-37c82a925ff0", new());
#endif

#endregion
        }
    }
}
