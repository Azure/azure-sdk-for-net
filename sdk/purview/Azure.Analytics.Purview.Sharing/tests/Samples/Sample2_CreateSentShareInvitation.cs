// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;

namespace Azure.Analytics.Purview.Share.Tests.Samples
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
            var endPoint = "https://<my-account-name>.purview.azure.com/share";
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
                    TargetActiveDirectoryId = <targetActiveDirectoryId>,
                    TargetObjectId = <targetObjectId>,
#else
                    TargetActiveDirectoryId = "72f988bf-86f1-41af-91ab-2d7cd011db47",
                    TargetObjectId = "fc010728-94f6-4e9c-be3c-c08687414bd4",
#endif
                }
            };

#if SNIPPET
            Response response = await sentShareClient.CreateSentShareInvitationAsync(<sentShareId>, <sentShareInvitationId>, RequestContent.Create(data));
#else
            Response response = await sentShareClient.CreateSentShareInvitationAsync("e802f487-92bf-4dc3-bf1d-86afe0d757a3", "e322785e-8fb0-4d7b-b7b3-521e0d602fae", RequestContent.Create(data));
#endif

#endregion
        }
    }
}
