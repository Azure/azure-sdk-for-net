// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.TestFramework;
using NUnit.Framework;
#region Snippet:Azure_Analytics_Purview_Share_Samples_07_Namespaces
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Identity;
#endregion Snippet:Azure_Analytics_Purview_Share_Samples_07_Namespaces

namespace Azure.Analytics.Purview.Share.Tests.Samples
{
    [TestFixture]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name", Justification = "For documentation purposes")]
    internal class ViewAcceptedSharesSample : ShareClientTestBase
    {
        public ViewAcceptedSharesSample() : base(true)
        {
        }

        [RecordedTest]
        public async Task ViewAcceptedShares()
        {
            #region Snippet:Azure_Analytics_Purview_Share_Samples_ViewAcceptedShares
            var sentShareName = "sample-Share";
#if SNIPPET
            var credential = new DefaultAzureCredential();
            var endPoint = "https://<my-account-name>.purview.azure.com/share";
            var acceptedSentSharesClient = new AcceptedSentSharesClient(endPoint, credential);
#else
            var credential = TestEnvironment.Credential;
            var endPoint = TestEnvironment.Endpoint.ToString();
            var acceptedSentSharesClient = GetAcceptedSentSharesClient();
#endif

            // View accepted shares
            var acceptedSentShares = await acceptedSentSharesClient.GetAcceptedSentSharesAsync(sentShareName).ToEnumerableAsync();

            var acceptedSentShare = acceptedSentShares.FirstOrDefault();

            if (acceptedSentShare == null)
            {
                //No accepted sent shares
                return;
            }
            using var jsonDocument = JsonDocument.Parse(acceptedSentShare);
            var receiverEmail = jsonDocument.RootElement.GetProperty("properties").GetProperty("receiverEmail").GetString();
            #endregion Snippet:Azure_Analytics_Purview_Share_Samples_ViewAcceptedShares
        }
    }
}
