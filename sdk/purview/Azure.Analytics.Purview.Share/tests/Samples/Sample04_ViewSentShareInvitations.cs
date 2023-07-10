// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;
#region Snippet:Azure_Analytics_Purview_Share_Samples_04_Namespaces
using System.Linq;
using System.Text.Json;
using Azure.Identity;
using System.Threading.Tasks;
#endregion Snippet:Azure_Analytics_Purview_Share_Samples_04_Namespaces

namespace Azure.Analytics.Purview.Share.Tests.Samples
{
    [TestFixture]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name", Justification = "For documentation purposes")]
    internal class ViewSentShareInvitationsSample : ShareClientTestBase
    {
        public ViewSentShareInvitationsSample() : base(true)
        {
        }

        [RecordedTest]
        public async Task ViewSentShareInvitations()
        {
            #region Snippet:Azure_Analytics_Purview_Share_Samples_ViewSentShareInvitations
            var sentShareName = "sample-Share";
#if SNIPPET
            var credential = new DefaultAzureCredential();
            var endPoint = "https://<my-account-name>.purview.azure.com/share";
            var sentShareInvitationsClient = new SentShareInvitationsClient(endPoint, credential);
#else
            var credential = TestEnvironment.Credential;
            var endPoint = TestEnvironment.Endpoint.ToString();
            var sentShareInvitationsClient = GetSentShareInvitationsClient();
#endif

            // View sent share invitations. (Pending/Rejected)
            var sentShareInvitations = await sentShareInvitationsClient.GetSentShareInvitationsAsync(sentShareName).ToEnumerableAsync();
            var responseInvitation = sentShareInvitations.FirstOrDefault();

            if (responseInvitation == null)
            {
                //No invitations
                return;
            }

            using var responseInvitationDocument = JsonDocument.Parse(responseInvitation);
            var targetEmail = responseInvitationDocument.RootElement.GetProperty("name");
            #endregion Snippet:Azure_Analytics_Purview_Share_Samples_ViewSentShareInvitations
        }
    }
}
