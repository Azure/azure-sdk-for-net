// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;

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
            var endPoint = "https://my-account-name.purview.azure.com/share";
            var sentShareClient = new SentSharesClient(endPoint, credential);

            List<BinaryData> sentShareInvitations = await sentShareClient.GetAllSentShareInvitationsAsync("sentShareId").ToEnumerableAsync();
#else
            var sentShareClient = GetSentSharesClient();

            List<BinaryData> sentShareInvitations = await sentShareClient.GetAllSentShareInvitationsAsync("9393cfc1-7300-4159-aeff-277b2026846a").ToEnumerableAsync();
#endif

            #endregion
        }
    }
}
