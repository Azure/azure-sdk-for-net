// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;

namespace Azure.Analytics.Purview.Sharing.Tests.Samples;

internal class Sample14_ListShareResources : ShareResourcesClientTestBase
{
    public Sample14_ListShareResources(bool isAsync) : base(isAsync)
    {
    }

    [RecordedTest]
    public async Task ListShareResourcesTest()
    {
        #region Snippet:ShareResourcesClientExample_ListShareResources

#if SNIPPET
        var credential = new DefaultAzureCredential();
        var endPoint = new Uri("https://my-account-name.purview.azure.com/share");
        var shareResourcesClient = new ShareResourcesClient(endPoint, credential);
#else
        var shareResourcesClient = GetShareResourcesClient();
#endif

#if SNIPPET
        List<BinaryData> createResponse = await shareResourcesClient.GetAllShareResourcesAsync(null, null, null).ToEnumerableAsync();
#else
        List<BinaryData> shareResources = await shareResourcesClient.GetAllShareResourcesAsync(null, null, null).ToEnumerableAsync();
#endif

        #endregion
    }
}
