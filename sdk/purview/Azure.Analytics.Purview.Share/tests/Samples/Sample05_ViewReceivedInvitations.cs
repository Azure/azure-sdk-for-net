// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;
#region Snippet:Azure_Analytics_Purview_Share_Samples_05_Namespaces
using Azure.Core;
using Azure.Identity;
using System.Threading.Tasks;
#endregion Snippet:Azure_Analytics_Purview_Share_Samples_05_Namespaces

namespace Azure.Analytics.Purview.Share.Tests.Samples
{
    [TestFixture]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name", Justification = "For documentation purposes")]
    internal class ViewReceivedInvitationsSample : ShareClientTestBase
    {
        public ViewReceivedInvitationsSample() : base(true)
        {
        }

        [RecordedTest]
        public async Task ViewReceivedInvitations()
        {
            #region Snippet:Azure_Analytics_Purview_Share_Samples_ViewReceivedInvitations
#if SNIPPET
            var credential = new DefaultAzureCredential();
            var endPoint = "https://<my-account-name>.purview.azure.com/share";
            var receivedInvitationsClient = new ReceivedInvitationsClient(endPoint, credential);
#else
            var credential = TestEnvironment.Credential;
            var endPoint = TestEnvironment.Endpoint.ToString();
            var receivedInvitationsClient = GetReceivedInvitationsClient();
#endif

            // View received invitations
            var receivedInvitations = await receivedInvitationsClient.GetReceivedInvitationsAsync().ToEnumerableAsync();
            #endregion Snippet:Azure_Analytics_Purview_Share_Samples_ViewReceivedInvitations
        }
    }
}
