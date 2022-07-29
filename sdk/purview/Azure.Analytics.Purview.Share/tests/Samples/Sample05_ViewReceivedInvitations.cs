// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Azure_Analytics_Purview_Share_Samples_05_Namespaces
using Azure.Identity;
#endregion Snippet:Azure_Analytics_Purview_Share_Samples_05_Namespaces

namespace Azure.Analytics.Purview.Share.Tests.Samples
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name", Justification = "For documentation purposes")]
    internal class ViewReceivedInvitationsSample
    {
        public void ViewReceivedInvitations()
        {
            #region Snippet:Azure_Analytics_Purview_Share_Samples_ViewReceivedInvitations
            var credential = new DefaultAzureCredential();
            var endPoint = "https://<my-account-name>.purview.azure.com";

            // View received invitations
            var receivedInvitationsClient = new ReceivedInvitationsClient(endPoint, credential);
            var receivedInvitations = receivedInvitationsClient.GetReceivedInvitations();
            #endregion Snippet:Azure_Analytics_Purview_Share_Samples_ViewReceivedInvitations
        }
    }
}
