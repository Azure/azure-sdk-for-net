// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
#region Snippet:Azure_Analytics_Purview_Share_Samples_06_Namespaces
using System.Linq;
using System.Text.Json;
using Azure.Core;
using Azure.Identity;
#endregion Snippet:Azure_Analytics_Purview_Share_Samples_06_Namespaces

namespace Azure.Analytics.Purview.Share.Tests.Samples
{
    [TestFixture]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name", Justification = "For documentation purposes")]
    internal class CreateAReceivedShareSample : ShareClientTestBase
    {
        public CreateAReceivedShareSample(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public async Task CreateAReceivedShare()
        {
            #region Snippet:Azure_Analytics_Purview_Share_Samples_CreateAReceivedShare
#if SNIPPET
            var credential = new DefaultAzureCredential();
            var endPoint = "https://<my-account-name>.purview.azure.com/share";
#else
            var credential = TestEnvironment.Credential;
            var endPoint = TestEnvironment.Endpoint.ToString();
#endif

            // Create received share
            var receivedInvitationsClient = new ReceivedInvitationsClient(endPoint, credential);
            var receivedInvitations = receivedInvitationsClient.GetReceivedInvitations();
            var receivedShareName = "fabrikam-received-share";
            var receivedInvitation = receivedInvitations.LastOrDefault();

            if (receivedInvitation == null)
            {
                //No received invitations
                return;
            }

            var receivedInvitationDocument = JsonDocument.Parse(receivedInvitation).RootElement;
            var receivedInvitationId = receivedInvitationDocument.GetProperty("name");

            var receivedShareData = new
            {
                shareKind = "InPlace",
                properties = new
                {
                    invitationId = receivedInvitationId,
                    sentShareLocation = "eastus",
                    collection = new
                    {
                        // for root collection else name of any accessible child collection in the Purview account.
                        referenceName = "<purivewAccountName>",
                        type = "CollectionReference"
                    }
                }
            };

            var receivedShareClient = new ReceivedSharesClient(endPoint, credential);
            var receivedShare = await receivedShareClient.CreateAsync(receivedShareName, RequestContent.Create(receivedShareData));
            #endregion Snippet:Azure_Analytics_Purview_Share_Samples_CreateAReceivedShare
        }
    }
}
