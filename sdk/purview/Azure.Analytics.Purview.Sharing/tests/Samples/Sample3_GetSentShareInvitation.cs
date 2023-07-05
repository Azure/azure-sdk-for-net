// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using System;

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
            var endPoint = new Uri("https://my-account-name.purview.azure.com/share");
            var sentShareClient = new SentSharesClient(endPoint, credential);

            Response response = await sentShareClient.GetSentShareInvitationAsync("sentShareId", "sentShareInvitationId", new());
#else
            var sentShareClient = GetSentSharesClient();

            Response response = await sentShareClient.GetSentShareInvitationAsync("fe11781e-9a7d-488d-bd22-cc2c95536e96", "4ae8a8dc-0662-4027-960e-92b4778fc5ff", new());
#endif

            #endregion
        }
    }
}
