// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Monitor.Ingestion.Tests
{
    public class IngestionClientTest: RecordedTestBase<IngestionClientTestEnvironment>
    {
        public IngestionClientTest(bool isAsync) : base(isAsync)
        {
        }

        /* please refer to https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/tests/TemplateClientLiveTests.cs to write tests. */

        [RecordedTest]
        public void TestOperation()
        {
            Assert.IsTrue(true);
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

        [Test]
        public void HelloIngestion()
        {
            var dcrImmutableId = "testImmutable";
            var dcrEndpoint = "https://nibhati-dce-ku6s.westus2-1.ingest.monitor.azure.com";
            var currentTime = DateTimeOffset.UtcNow.ToString("O");
            BinaryData data = BinaryData.FromObjectAsJson(
                // Use an anonymous type to create the payload
                new[] {
                    new
                    {
                        Time = currentTime,
                        Computer = "Computer1",
                        AdditionalContext = new
                        {
                            InstanceName = "user1",
                            TimeZone = "Pacific Time",
                            Level = 4,
                            CounterName = "AppMetric1",
                            CounterValue = 15.3
                        }
                    },
                    new
                    {
                        Time = currentTime,
                        Computer = "Computer2",
                        AdditionalContext = new
                        {
                            InstanceName = "user2",
                            TimeZone = "Central Time",
                            Level = 3,
                            CounterName = "AppMetric1",
                            CounterValue = 23.5
                        }
                    },
                });

            IngestionUsingDataCollectionRulesClient client = new(
                dcrEndpoint,
                new AzureKeyCredential("samplekey"));

            // Make the request
            Response response = client.Upload(dcrImmutableId, "Custom-MyTableRawData", RequestContent.Create(data));

            // Check the response
            string json = response.Content.ToString();
            Console.WriteLine($"response:\n{json}");
        }
    }
}
