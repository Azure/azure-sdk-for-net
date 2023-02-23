// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.Analytics.Purview.Sharing.Tests.Samples
{
    public class Sample4_ListSentShareInvitations : SentSharesClientTestBase
    {
        public Sample4_ListSentShareInvitations(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task ListSentShareInvitationsTest()
        {
            #region Snippet:SentSharesClientSample_ListSentShareInvitations

#if SNIPPET
            var credential = new DefaultAzureCredential();
            var endPoint = "https://<my-account-name>.purview.azure.com/share";
            var sentShareClient = new SentSharesClient(endPoint, credential);

            List<BinaryData> sentShareInvitations = await sentShareClient.GetAllSentShareInvitationsAsync(<sentShareId>).ToEnumerableAsync();
#else
            var sentShareClient = GetSentSharesClient();

            List<BinaryData> sentShareInvitations = await sentShareClient.GetAllSentShareInvitationsAsync("e802f487-92bf-4dc3-bf1d-86afe0d757a3").ToEnumerableAsync();
#endif

            #endregion
        }
    }
}
