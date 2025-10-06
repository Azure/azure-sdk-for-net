// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Analytics.Purview.DataMap.Tests
{
    public partial class Sample1_GetTypeByNameAsync : SamplesBase<PurviewDataMapTestEnvironment>
    {
        [Test]
        [AsyncOnly]
        public async Task GetTypeByNameAsync()
        {
            Uri endpoint = TestEnvironment.Endpoint;
            TokenCredential credential = new DefaultAzureCredential();
            DataMapClient dataMapClient = new DataMapClient(endpoint, credential);

            #region Snippet:DataMapGetTypeByNameAsync
            TypeDefinition client = dataMapClient.GetTypeDefinitionClient();
            var response = await client.GetByNameAsync("AtlasGlossary", null);
            #endregion
        }
    }
}
