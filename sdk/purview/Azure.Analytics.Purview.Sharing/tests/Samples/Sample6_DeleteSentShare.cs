// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.Analytics.Purview.Sharing.Tests.Samples
{
    public class Sample6_DeleteSentShare : SentSharesClientTestBase
    {
        public Sample6_DeleteSentShare(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task DeleteSentShareTest()
        {
            #region Snippet:SentSharesClientSample_DeleteSentShare

#if SNIPPET
            var credential = new DefaultAzureCredential();
            var endPoint = "https://my-account-name.purview.azure.com/share";
            var sentShareClient = new SentSharesClient(endPoint, credential);

            Operation operation = await sentShareClient.DeleteSentShareAsync(WaitUntil.Completed, "sentShareId");
#else
            var sentShareClient = GetSentSharesClient();

            Operation operation = await sentShareClient.DeleteSentShareAsync(WaitUntil.Completed, "7911b09b-9cb3-416a-a3f0-e242c0bfd574");
#endif

            #endregion
        }
    }
}
