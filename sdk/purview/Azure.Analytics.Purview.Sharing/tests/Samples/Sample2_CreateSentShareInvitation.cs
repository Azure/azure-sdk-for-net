// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.Analytics.Purview.Sharing.Tests.Samples
{
    public class Sample2_CreateSentShareInvitation : SentSharesClientTestBase
    {
        public Sample2_CreateSentShareInvitation(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task CreateSentShareInvitationTest()
        {
            #region Snippet:SentSharesClientSample_CreateSentShareInvitation

#if SNIPPET
            var credential = new DefaultAzureCredential();
            var endPoint = "https://my-account-name.purview.azure.com/share";
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
                    TargetActiveDirectoryId = "72f988bf-86f1-41af-91ab-2d7cd011db47",
                    TargetObjectId = "fc010728-94f6-4e9c-be3c-c08687414bd4",
#endif
                }
            };

#if SNIPPET
            Response response = await sentShareClient.CreateSentShareInvitationAsync("sentShareId", "sentShareInvitationId", RequestContent.Create(data));
#else
            Response response = await sentShareClient.CreateSentShareInvitationAsync("9393cfc1-7300-4159-aeff-277b2026846a", "0423c905-402c-423c-af12-9a5faad51349", RequestContent.Create(data));
#endif

#endregion
        }
    }
}
