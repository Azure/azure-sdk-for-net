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
            Assert.That(result.GetRawResponse().Status, Is.EqualTo(200));
        }

        [RecordedTest]
        public async Task GetGlossary()
        {
            var client = GetDataMapClient().GetGlossaryClient();
            Response fetchResponse = await client.BatchGetAsync(1, null, null, true, new RequestContext());
            // Console.WriteLine(fetchResponse.Content);
            Assert.That(fetchResponse.Status, Is.EqualTo(200));
        }

        [RecordedTest]
        public async Task GetTypes()
        {
            var client = GetDataMapClient().GetTypeDefinitionClient();
            Response<AtlasTypeDef> response = await client.GetByNameAsync("AtlasGlossary");
            // Console.WriteLine(response);
            Assert.That(response.GetRawResponse().Status, Is.EqualTo(200));
        }
    }
}
