// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Azure_Analytics_Purview_Share_Samples_04_Namespaces
using System.Linq;
using System.Text.Json;
using Azure.Identity;
#endregion Snippet:Azure_Analytics_Purview_Share_Samples_04_Namespaces

namespace Azure.Analytics.Purview.Share.Tests.Samples
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name", Justification = "For documentation purposes")]
    internal class ViewSentShareInvitationsSample
    {
        public void ViewSentShareInvitations()
        {
            #region Snippet:Azure_Analytics_Purview_Share_Samples_ViewSentShareInvitations
            var credential = new DefaultAzureCredential();
            var endPoint = "https://<my-account-name>.purview.azure.com";
            var sentShareName = "sample-Share";

            // View sent share invitations. (Pending/Rejected)
            var sentShareInvitationsClient = new SentShareInvitationsClient(endPoint, credential);
            var sentShareInvitations = sentShareInvitationsClient.GetSentShareInvitations(sentShareName);
            var responseInvitation = sentShareInvitations.FirstOrDefault();

            if (responseInvitation == null)
            {
                //No invitations
                return;
            }

            var responseInvitationDocument = JsonDocument.Parse(responseInvitation);
            var targetEmail = responseInvitationDocument.RootElement.GetProperty("name");
            #endregion Snippet:Azure_Analytics_Purview_Share_Samples_ViewSentShareInvitations
        }
    }
}
