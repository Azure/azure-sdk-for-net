// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
#region Snippet:Azure_Analytics_Purview_Share_Samples_01_Namespaces
using Azure.Core;
using Azure.Identity;
#endregion Snippet:Azure_Analytics_Purview_Share_Samples_01_Namespaces

namespace Azure.Analytics.Purview.Share.Samples
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1649:File name should match first type name", Justification = "For documentation purposes")]
    internal class CreateSentShare
    {
        public async Task CreateSentShareSample()
        {
            #region Snippet:Azure_Analytics_Purview_Share_Samples_CreateSentShare
            var credential = new DefaultAzureCredential();
            var endPoint = "https://<my-account-name>.purview.azure.com";

            var sentShareClient = new SentSharesClient(endPoint, credential);

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
                        referenceName = "<reference>",
                        type = "CollectionReference"
                    }
                }
            };

            var sentShare = await sentShareClient.CreateOrUpdateAsync(sentShareName, RequestContent.Create(inPlaceSentShareDto));
            #endregion Snippet:Azure_Analytics_Purview_Share_Samples_CreateSentShare
        }
    }
}
