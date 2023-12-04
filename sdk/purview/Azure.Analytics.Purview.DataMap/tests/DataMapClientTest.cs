// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Analytics.Purview.DataMap.Tests
{
    public class DataMapClientTest: RecordedTestBase<DataMapClientTestEnvironment>
    {
        public DataMapClientTest(bool isAsync) : base(isAsync)
        {
        }

        /* please refer to https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/tests/TemplateClientLiveTests.cs to write tests. */

        [RecordedTest]
        public void Search()
        {
            PurviewDataMapClient client = GetDataMapClient();
            var data = new
            {
                keywords = "myPurview"
            };
            Response fetchResponse = await client.SearchAsync(RequestContent.Create(data));
            using var jsonDocument = JsonDocument.Parse(GetContentFromResponse(fetchResponse));
            JsonElement fetchBodyJson = jsonDocument.RootElement;
            Assert.AreEqual(0, fetchBodyJson.GetProperty("@search.count").GetInt16());
        }

        [RecordedTest]
        public async Task Suggest()
        {
            PurviewDataMapClient client = GetDataMapClient();
            var data = new
            {
                keywords = "sampledata.csv",
            };
            Response fetchResponse = await client.SuggestAsync(RequestContent.Create(data));
            Assert.AreEqual(fetchResponse.Status, 200);
            using var jsonDocument = JsonDocument.Parse(GetContentFromResponse(fetchResponse));
            JsonElement fetchBodyJson = jsonDocument.RootElement;
            Assert.AreEqual("s3://testpurview/sampledata.csv", fetchBodyJson.GetProperty("value")[0].GetProperty("qualifiedName").GetString());
        }

        #region Helpers

        private static BinaryData GetContentFromResponse(Response r)
        {
            // Workaround azure/azure-sdk-for-net#21048, which prevents .Content from working when dealing with responses
            // from the playback system.

            MemoryStream ms = new MemoryStream();
            r.ContentStream.CopyTo(ms);
            return new BinaryData(ms.ToArray());
        }
        #endregion
    }
}
