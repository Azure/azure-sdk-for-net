// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;

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
            var endPoint = "https://my-account-name.purview.azure.com/share";
            var sentShareClient = new SentSharesClient(endPoint, credential);

            Response response = await sentShareClient.GetSentShareAsync("sentShareId");
#else
            var sentShareClient = GetSentSharesClient();

            Response response = await sentShareClient.GetSentShareAsync("9393cfc1-7300-4159-aeff-277b2026846a");
#endif

            #endregion
        }
    }
}
