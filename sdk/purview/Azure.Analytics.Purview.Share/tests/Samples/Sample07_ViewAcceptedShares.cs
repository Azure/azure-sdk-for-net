// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;
#region Snippet:Azure_Analytics_Purview_Share_Samples_07_Namespaces
using System.Linq;
using System.Text.Json;
using Azure.Identity;
#endregion Snippet:Azure_Analytics_Purview_Share_Samples_07_Namespaces

namespace Azure.Analytics.Purview.Share.Tests.Samples
{
    [TestFixture]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name", Justification = "For documentation purposes")]
    internal class ViewAcceptedSharesSample : ShareClientTestBase
    {
        public ViewAcceptedSharesSample() : base(false)
        {
        }

        public ViewAcceptedSharesSample(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public void ViewAcceptedShares()
        {
            #region Snippet:Azure_Analytics_Purview_Share_Samples_ViewAcceptedShares
#if SNIPPET
            var credential = new DefaultAzureCredential();
            var endPoint = "https://<my-account-name>.purview.azure.com/share";
#else
            var credential = TestEnvironment.Credential;
            var endPoint = TestEnvironment.Endpoint.ToString();
#endif
            var sentShareName = "sample-Share";

            // View accepted shares
            var acceptedSentSharesClient = new AcceptedSentSharesClient(endPoint, credential);
            var acceptedSentShares = acceptedSentSharesClient.GetAcceptedSentShares(sentShareName);

            var acceptedSentShare = acceptedSentShares.FirstOrDefault();

            if (acceptedSentShare == null)
            {
                //No accepted sent shares
                return;
            }

            var receiverEmail = JsonDocument.Parse(acceptedSentShare).RootElement.GetProperty("properties").GetProperty("receiverEmail").GetString();
            #endregion Snippet:Azure_Analytics_Purview_Share_Samples_ViewAcceptedShares
        }
    }
}
