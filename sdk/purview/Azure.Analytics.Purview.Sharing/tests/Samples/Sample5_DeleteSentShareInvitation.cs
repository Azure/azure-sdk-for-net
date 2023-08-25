// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.Analytics.Purview.Sharing.Tests.Samples
{
    public class Sample5_DeleteSentShareInvitation : SentSharesClientTestBase
    {
        public Sample5_DeleteSentShareInvitation(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task DeleteSentShareInvitationTest()
        {
            #region Snippet:SentSharesClientSample_DeleteSentShareInvitation

#if SNIPPET
            var credential = new DefaultAzureCredential();
            var endPoint = new Uri("https://my-account-name.purview.azure.com/share");
            var sentShareClient = new SentSharesClient(endPoint, credential);

            Operation operation = await sentShareClient.DeleteSentShareInvitationAsync(WaitUntil.Completed, "sentShareId", "sentShareInvitationId", new());
#else
            var sentShareClient = GetSentSharesClient();

            Operation operation = await sentShareClient.DeleteSentShareInvitationAsync(WaitUntil.Completed, "016eb068-ddaa-41be-8804-8bef566663a5", "4ae8a8dc-0662-4027-960e-92b4778fc5ff", new());
#endif

            #endregion
        }
    }
}
