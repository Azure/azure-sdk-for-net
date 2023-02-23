// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;

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
            var endPoint = "https://<my-account-name>.purview.azure.com/share";
            var sentShareClient = new SentSharesClient(endPoint, credential);

            Response response = await sentShareClient.GetSentShareInvitationAsync(<sentShareId>, <sentShareInvitationId>);
#else
            var sentShareClient = GetSentSharesClient();

            Response response = await sentShareClient.GetSentShareInvitationAsync("7911b09b-9cb3-416a-a3f0-e242c0bfd574", "91c4b19f-8bad-4bcc-b623-f19673fb0f83");
#endif

            #endregion
        }
    }
}
