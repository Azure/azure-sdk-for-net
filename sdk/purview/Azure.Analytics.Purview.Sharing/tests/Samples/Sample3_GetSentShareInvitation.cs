// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.Analytics.Purview.Sharing.Tests.Samples
{
    public class Sample3_GetSentShareInvitation : SentSharesClientTestBase
    {
        public Sample3_GetSentShareInvitation(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task GetSentShareInvitationTest()
        {
            #region Snippet:SentSharesClientSample_GetSentShareInvitation

#if SNIPPET
            var credential = new DefaultAzureCredential();
            var endPoint = "https://my-account-name.purview.azure.com/share";
            var sentShareClient = new SentSharesClient(endPoint, credential);

            Response response = await sentShareClient.GetSentShareInvitationAsync("sentShareId", "sentShareInvitationId");
#else
            var sentShareClient = GetSentSharesClient();

            Response response = await sentShareClient.GetSentShareInvitationAsync("9393cfc1-7300-4159-aeff-277b2026846a", "0423c905-402c-423c-af12-9a5faad51349");
#endif

            #endregion
        }
    }
}
