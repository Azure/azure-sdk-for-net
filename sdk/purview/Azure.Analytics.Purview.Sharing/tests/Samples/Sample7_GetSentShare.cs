// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.Analytics.Purview.Sharing.Tests.Samples
{
    public class Sample7_GetSentShare : SentSharesClientTestBase
    {
        public Sample7_GetSentShare(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task GetSentShareTest()
        {
            #region Snippet:SentSharesClientSample_GetSentShare

#if SNIPPET
            var credential = new DefaultAzureCredential();
            var endPoint = "https://<my-account-name>.purview.azure.com/share";
            var sentShareClient = new SentSharesClient(endPoint, credential);

            Response response = await sentShareClient.GetSentShareAsync(<sentShareId>);
#else
            var sentShareClient = GetSentSharesClient();

            Response response = await sentShareClient.GetSentShareAsync("7911b09b-9cb3-416a-a3f0-e242c0bfd574");
#endif

            #endregion
        }
    }
}
