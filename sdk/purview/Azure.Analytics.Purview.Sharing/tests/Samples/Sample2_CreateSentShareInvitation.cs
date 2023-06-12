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
                    TargetObjectId = "67bb1d64-b708-496a-ba33-48c242cbb6c8",
#endif
                }
            };

#if SNIPPET
            Response response = await sentShareClient.CreateSentShareInvitationAsync("sentShareId", "sentShareInvitationId", RequestContent.Create(data));
#else
            Response response = await sentShareClient.CreateSentShareInvitationAsync("016eb068-ddaa-41be-8804-8bef566663a5", "4ae8a8dc-0662-4027-960e-92b4778fc5ff", RequestContent.Create(data));
#endif

#endregion
        }
    }
}
