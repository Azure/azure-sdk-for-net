// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using System;

namespace Azure.Analytics.Purview.Sharing.Tests.Samples
{
    public class Sample2_CreateSentShareServiceInvitation : SentSharesClientTestBase
    {
        public Sample2_CreateSentShareServiceInvitation(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CreateSentShareServiceInvitationTest()
        {
            #region Snippet:SentSharesClientSample_CreateSentShareInvitation

#if SNIPPET
            var credential = new DefaultAzureCredential();
            var endPoint = new Uri("https://my-account-name.purview.azure.com/share");
            var sentShareClient = new SentSharesClient(endPoint, credential);
#else
            var sentShareClient = GetSentSharesClient();
#endif

            var data = new
            {
                invitationKind = "Service",
                properties = new
                {
#if SNIPPET
                    TargetActiveDirectoryId = "targetActiveDirectoryId",
                    TargetObjectId = "targetObjectId",
#else
                    TargetActiveDirectoryId = "165944e1-1963-4e83-920f-4d0e9c44599c",
                    TargetObjectId = "5fc438a9-bdb9-46d4-89d7-43fdccc0f23e",
#endif
                }
            };

#if SNIPPET
            Response response = await sentShareClient.CreateSentShareInvitationAsync("sentShareId", "sentShareInvitationId", RequestContent.Create(data));
#else
            Response response = await sentShareClient.CreateSentShareInvitationAsync("b9228fde-9f48-4d9f-a634-24206bbce06b", "eaa4a02b-8147-4bab-b71f-31407eacd17c", RequestContent.Create(data));
#endif

#endregion
        }
    }
}
