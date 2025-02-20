// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.Purview.Sharing.Tests
{
    internal class ShareResourcesClientTest : ShareResourcesClientTestBase
    {
        public ShareResourcesClientTest(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task GetListShareResourcesTest()
        {
            ShareResourcesClient client = GetShareResourcesClient();

            List<BinaryData> listResponse = await client.GetAllShareResourcesAsync(null, null, null).ToEnumerableAsync();

            Assert.Greater(listResponse.Count, 0);
        }
    }
}
