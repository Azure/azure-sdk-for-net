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

            Response response = await sentShareClient.GetSentShareInvitationAsync("e802f487-92bf-4dc3-bf1d-86afe0d757a3", "e322785e-8fb0-4d7b-b7b3-521e0d602fae");
#endif

            #endregion
        }
    }
}
