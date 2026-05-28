// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Analytics.Purview.DataMap.Tests
{
    public class DataMapClientTest : DataMapClientTestBase
    {
        public DataMapClientTest(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task Search()
        {
            DataMapClient client = GetDataMapClient();
            QueryConfig sg = new QueryConfig();
            sg.Keywords = "Glossary";
            sg.Limit = 1;
            Response<QueryResult> result = await client.GetDiscoveryClient().QueryAsync(sg);
            Assert.AreEqual(200, result.GetRawResponse().Status);
        }

        [RecordedTest]
        public async Task GetGlossary()
        {
            var client = GetDataMapClient().GetGlossaryClient();
            Response fetchResponse = await client.BatchGetAsync(1, null, null, true, new RequestContext());
            // Console.WriteLine(fetchResponse.Content);
            Assert.AreEqual(200, fetchResponse.Status);
        }

        [RecordedTest]
        public async Task GetTypes()
        {
            var client = GetDataMapClient().GetTypeDefinitionClient();
            Response<AtlasTypeDef> response = await client.GetByNameAsync("AtlasGlossary");
            // Console.WriteLine(response);
            Assert.AreEqual(200, response.GetRawResponse().Status);
        }
    }
}
