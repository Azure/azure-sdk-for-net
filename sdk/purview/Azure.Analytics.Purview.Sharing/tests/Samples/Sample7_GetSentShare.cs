// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using System;

namespace Azure.Analytics.Purview.Sharing.Tests.Samples
{
    public class Sample7_GetSentShare : SentSharesClientTestBase
    {
        public Sample7_GetSentShare(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task GetSentShareTest()
        {
            #region Snippet:SentSharesClientSample_GetSentShare

#if SNIPPET
            var credential = new DefaultAzureCredential();
            var endPoint = new Uri("https://my-account-name.purview.azure.com/share");
            var sentShareClient = new SentSharesClient(endPoint, credential);

            Response response = await sentShareClient.GetSentShareAsync("sentShareId", new());
#else
            var sentShareClient = GetSentSharesClient();

            Response response = await sentShareClient.GetSentShareAsync("fe11781e-9a7d-488d-bd22-cc2c95536e96", new());
#endif

            #endregion
        }
    }
}
