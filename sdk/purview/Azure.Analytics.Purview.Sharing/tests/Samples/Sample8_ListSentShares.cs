// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.Analytics.Purview.Sharing.Tests.Samples
{
    public class Sample8_ListSentShares : SentSharesClientTestBase
    {
        public Sample8_ListSentShares(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task ListSentSharesTest()
        {
            #region Snippet:SentSharesClientSample_ListSentShares

#if SNIPPET
            var credential = new DefaultAzureCredential();
            var endPoint = new Uri("https://my-account-name.purview.azure.com/share");
            var sentShareClient = new SentSharesClient(endPoint, credential);

            List<BinaryData> response = await sentShareClient.GetAllSentSharesAsync("referenceName", null, null, new()).ToEnumerableAsync();
#else
            var sentShareClient = GetSentSharesClient();

            List<BinaryData> response = await sentShareClient.GetAllSentSharesAsync("/subscriptions/d941aad1-e4af-44a5-a70e-0381a9f702f1/resourcegroups/dev-rg/providers/Microsoft.Storage/storageAccounts/provideraccount", null, null, new()).ToEnumerableAsync();
#endif

            #endregion
        }
    }
}
