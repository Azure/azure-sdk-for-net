// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

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
            var endPoint = "https://<my-account-name>.purview.azure.com/share";
            var sentShareClient = new SentSharesClient(endPoint, credential);

            List<BinaryData> response = await sentShareClient.GetAllSentSharesAsync(<referenceName>).ToEnumerableAsync();
#else
            var sentShareClient = GetSentSharesClient();

            List<BinaryData> response = await sentShareClient.GetAllSentSharesAsync("/subscriptions/0f3dcfc3-18f8-4099-b381-8353e19d43a7/resourceGroups/faisalaltell/providers/Microsoft.Storage/storageAccounts/ftsharersan").ToEnumerableAsync();
#endif

            #endregion
        }
    }
}
