// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;
#region Snippet:Azure_Analytics_Purview_Share_Samples_05_Namespaces
using Azure.Identity;
#endregion Snippet:Azure_Analytics_Purview_Share_Samples_05_Namespaces

namespace Azure.Analytics.Purview.Share.Tests.Samples
{
    [TestFixture]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name", Justification = "For documentation purposes")]
    internal class ViewReceivedInvitationsSample : ShareClientTestBase
    {
        public ViewReceivedInvitationsSample(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public void ViewReceivedInvitations()
        {
            #region Snippet:Azure_Analytics_Purview_Share_Samples_ViewReceivedInvitations
#if SNIPPET
            var credential = new DefaultAzureCredential();
            var endPoint = "https://<my-account-name>.purview.azure.com/share";
#else
            var credential = TestEnvironment.Credential;
            var endPoint = TestEnvironment.Endpoint.ToString();
#endif

            // View received invitations
            var receivedInvitationsClient = new ReceivedInvitationsClient(endPoint, credential);
            var receivedInvitations = receivedInvitationsClient.GetReceivedInvitations();
            #endregion Snippet:Azure_Analytics_Purview_Share_Samples_ViewReceivedInvitations
        }
    }
}
