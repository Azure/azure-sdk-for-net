// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
#region Snippet:Azure_Analytics_Purview_Share_Samples_01_Namespaces
using Azure.Core;
using Azure.Identity;
#endregion Snippet:Azure_Analytics_Purview_Share_Samples_01_Namespaces

namespace Azure.Analytics.Purview.Share.Tests.Samples
{
    [TestFixture]
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name", Justification = "For documentation purposes")]
    internal class CreateSentShare : ShareClientTestBase
    {
        public CreateSentShare() : base(true)
        {
        }

        [RecordedTest]
        public async Task CreateSentShareSample()
        {
            #region Snippet:Azure_Analytics_Purview_Share_Samples_CreateSentShare
            #region Snippet:Azure_Analytics_Purview_Share_Authenticate_The_Client
#if SNIPPET
            var credential = new DefaultAzureCredential();
            var endPoint = "https://<my-account-name>.purview.azure.com/share";
            var sentShareClient = new SentSharesClient(endPoint, credential);
#else
            var credential = TestEnvironment.Credential;
            var endPoint = TestEnvironment.Endpoint.ToString();
            var sentShareClient = GetSentSharesClient();
#endif

            #endregion Snippet:Azure_Analytics_Purview_Share_Authenticate_The_Client
            // Create sent share
            var sentShareName = "sample-Share";

            var inPlaceSentShareDto = new
            {
                shareKind = "InPlace",
                properties = new
                {
                    description = "demo share",
                    collection = new
                    {
                        // for root collection else name of any accessible child collection in the Purview account.
#if SNIPPET
                        referenceName = "<purivewAccountName>",
#else
                        referenceName = "w95gh9ze",
#endif
                        type = "CollectionReference"
                    }
                }
            };

            var sentShare = await sentShareClient.CreateOrUpdateAsync(sentShareName, RequestContent.Create(inPlaceSentShareDto));
            #endregion Snippet:Azure_Analytics_Purview_Share_Samples_CreateSentShare
        }
    }
}
