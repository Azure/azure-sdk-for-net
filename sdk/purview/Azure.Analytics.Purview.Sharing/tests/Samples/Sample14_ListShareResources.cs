// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;

namespace Azure.Analytics.Purview.Sharing.Tests.Samples;

internal class Sample14_ListShareResources : ShareResourcesClientTestBase
{
    public Sample14_ListShareResources(bool isAsync) : base(isAsync)
    {
    }

    [RecordedTest]
    public async Task GetReceivedShareTest()
    {
        #region Snippet:ShareResourcesClientExample_ListShareResources

#if SNIPPET
            var credential = new DefaultAzureCredential();
            var endPoint = "https://my-account-name.purview.azure.com/share";
            var receivedSharesClient = new ReceivedSharesClient(endPoint, credential);
#else
        var shareResourcesClient = GetShareResourcesClient();
#endif

#if SNIPPET
            Response operation = await receivedSharesClient.GetReceivedShareAsync("receivedShareId");
#else
        List<BinaryData> shareResources = await shareResourcesClient.GetShareResourcesAsync().ToEnumerableAsync();
#endif

        #endregion
    }
}
