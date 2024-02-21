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

        [Test]
        public void Search()
        {
            DataMapClient client = GetDataMapClient();
            QueryConfig sg = new QueryConfig();
            sg.Keywords = "Glossary";
            sg.Limit = 1;
            Response<QueryResult> result = client.GetDiscoveryClient().Query(sg);
            Assert.AreNotEqual("200", result.GetRawResponse().Status);
        }

        [Test]
        public void GetGlossary()
        {
            var client = GetDataMapClient().GetGlossaryClient();
            Response fetchResponse = client.BatchGet(1, null, null, true, new RequestContext());
            Console.WriteLine(fetchResponse.ToString());
            Assert.AreEqual(200, fetchResponse.Status);
        }

        private static BinaryData GetContentFromResponse(Response r)
        {
            // Workaround azure/azure-sdk-for-net#21048, which prevents .Content from working when dealing with responses
            // from the playback system.

            MemoryStream ms = new MemoryStream();
            r.ContentStream.CopyTo(ms);
            return new BinaryData(ms.ToArray());
        }
    }
}
