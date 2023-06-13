// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using System;

namespace Azure.Analytics.Purview.Sharing.Tests.Samples
{
    internal class Sample15_CreateSentShareUserInvitation : SentSharesClientTestBase
    {
        public Sample15_CreateSentShareUserInvitation(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CreateSentShareUserInvitationTest()
        {
            #region Snippet:SentSharesClientSample_CreateSentShareUserInvitation

#if SNIPPET
            var credential = new DefaultAzureCredential();
            var endPoint = new Uri("https://my-account-name.purview.azure.com/share");
            var sentShareClient = new SentSharesClient(endPoint, credential);
#else
            var sentShareClient = GetSentSharesClient();
#endif

            var data = new
            {
                invitationKind = "User",
                properties = new
                {
#if SNIPPET
                    TargetEmail = "receiver@microsoft.com",
                    Notify = true,
#else
                    TargetEmail = "customer@contoso.com",
                    Notify = true,
#endif
                }
            };

#if SNIPPET
            Response response = await sentShareClient.CreateSentShareInvitationAsync("sentShareId", "sentShareInvitationId", RequestContent.Create(data));
#else
            Response response = await sentShareClient.CreateSentShareInvitationAsync("b9228fde-9f48-4d9f-a634-24206bbce06b", "e6f27ecd-e78c-466b-842b-2d8211cc9d35", RequestContent.Create(data));
#endif

            #endregion
        }
    }
}
