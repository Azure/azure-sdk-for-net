// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
            var endPoint = "https://my-account-name.purview.azure.com/share";
            var receivedSharesClient = new ReceivedSharesClient(endPoint, credential);
#else
            var receivedSharesClient = GetReceivedSharesClient();
#endif

#if SNIPPET
            Operation operation = await receivedSharesClient.DeleteReceivedShareAsync(WaitUntil.Completed, "receivedShareId");
#else
            Operation operation = await receivedSharesClient.DeleteReceivedShareAsync(WaitUntil.Completed, "bb00baac-b768-4004-a712-c5b942dc9e83");
#endif

#endregion
        }
    }
}
