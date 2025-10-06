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
        public void Search()
        {
            DataMapClient client = GetDataMapClient();
            QueryConfig sg = new QueryConfig();
            sg.Keywords = "Glossary";
            sg.Limit = 1;
            Response<QueryResult> result = client.GetDiscoveryClient().Query(sg);
            Assert.AreEqual(200, result.GetRawResponse().Status);
        }

        [RecordedTest]
        public void GetGlossary()
        {
            var client = GetDataMapClient().GetGlossaryClient();
            Response fetchResponse = client.BatchGet(1, null, null, true, new RequestContext());
            // Console.WriteLine(fetchResponse.Content);
            Assert.AreEqual(200, fetchResponse.Status);
        }

        [RecordedTest]
        public void GetTypes()
        {
            var client = GetDataMapClient().GetTypeDefinitionClient();
            Response<AtlasTypeDef> response = client.GetByName("AtlasGlossary");
            // Console.WriteLine(response);
            Assert.AreEqual(200, response.GetRawResponse().Status);
        }
    }
}
