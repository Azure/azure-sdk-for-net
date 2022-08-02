// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
#region Snippet:Azure_Analytics_Purview_Share_Samples_03_Namespaces
using Azure.Core;
using Azure.Identity;
#endregion Snippet:Azure_Analytics_Purview_Share_Samples_03_Namespaces

namespace Azure.Analytics.Purview.Share.Tests.Samples
{
    [TestFixture]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name", Justification = "For documentation purposes")]
    internal class SendInvitationSample : ShareClientTestBase
    {
        public SendInvitationSample() : base(true)
        {
        }

        [RecordedTest]
        public async Task SendInvitation()
        {
            #region Snippet:Azure_Analytics_Purview_Share_Samples_SendInvitation
#if SNIPPET
            var credential = new DefaultAzureCredential();
            var endPoint = "https://<my-account-name>.purview.azure.com/share";
#else
            var credential = TestEnvironment.Credential;
            var endPoint = TestEnvironment.Endpoint.ToString();
#endif

            // Send invitation
            var sentShareName = "sample-Share";
            var invitationName = "invitation-to-fabrikam";

            var invitationData = new
            {
                invitationKind = "User",
                properties = new
                {
#if SNIPPET
                    targetEmail = "user@domain.com"
#else
                    targetEmail = "yamanwahsheh@microsoft.com"
#endif
                }
            };

            // Instead of sending invitation to Azure login email of the user, you can send invitation to object ID of a service principal and tenant ID.
            // Tenant ID is optional. To use this method, comment out the previous declaration, and uncomment the next one.
            //var invitationData = new
            //{
            //    invitationKind = "Application",
            //    properties = new
            //    {
            //        targetActiveDirectoryId = "<targetActieDirectoryId>",
            //        targetObjectId = "<targetObjectId>"
            //    }
            //};

#if SNIPPET
            var sentShareInvitationsClient = new SentShareInvitationsClient(endPoint, credential);
#else
            var sentShareInvitationsClient = GetSentShareInvitationsClient();
#endif
            await sentShareInvitationsClient.CreateOrUpdateAsync(sentShareName, invitationName, RequestContent.Create(invitationData));
#endregion Snippet:Azure_Analytics_Purview_Share_Samples_SendInvitation
        }
    }
}
