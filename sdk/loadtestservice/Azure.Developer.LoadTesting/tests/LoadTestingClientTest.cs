// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;
using NUnit.Framework.Internal;
using Azure.Core.TestFramework.Models;

namespace Azure.Developer.LoadTesting.Tests
{
    public class LoadTestingClientTest: RecordedTestBase<LoadTestingClientTestEnvironment>
    {
        public string testId;
        public string fileId;
        public string testRunId;
        public string appComponentId;

        public LoadTestingClientTest(bool isAsync) : base(isAsync)
        {
            testId = "d7c68e2a-bcd8-423f-b9ce-fe9cccd00f1c";
            fileId = "1c2ccb7b-8f62-4f70-812e-70df2c3df314";
            testRunId = "df697300-dd3d-4654-bddf-e83d70f71af8";
            appComponentId = "ff0be495-eb8b-43f7-b18b-7877d33d98e7";

            BodyRegexSanitizers.Add(new BodyRegexSanitizer(@"sig=(?<group>.*?)(?=\s+)", SanitizeValue)
            {
                GroupForReplace = "group"
            });

            SanitizedHeaders.Add("Content-Type");
        }

        /* please refer to https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/tests/TemplateClientLiveTests.cs to write tests. */
        private LoadTestAdministrationClient CreateAdministrationClient()
        {
            return InstrumentClient(new LoadTestingClient(TestEnvironment.Endpoint, TestEnvironment.Credential, InstrumentClientOptions(new AzureLoadTestingClientOptions())).getLoadTestAdministration());
        }

        private TestRunClient CreateTestRunClient()
        {
            return InstrumentClient(new LoadTestingClient(TestEnvironment.Endpoint, TestEnvironment.Credential, InstrumentClientOptions(new AzureLoadTestingClientOptions())).getLoadTestRun());
        }

        [Test]
        public async Task CreateOrUpdateTest()
        {
            LoadTestAdministrationClient loadTestAdministration = CreateAdministrationClient();

            Response response = await loadTestAdministration.CreateOrUpdateTestAsync(testId, RequestContent.Create(
                   new
                   {
                       description = "This is created using SDK",
                       displayName = "SDK's LoadTest",
                       loadTestConfig = new
                       {
                           engineInstances = 1,
                           splitAllCSVs = false,
                       },
                       secrets = new { },
                       enviornmentVariables = new { },
                       passFailCriteria = new
                       {
                           passFailMetrics = new { },
                       }
                   }));

            Assert.NotNull(response);
        }

        [Test]
        public async Task UploadTestFile()
        {
            LoadTestAdministrationClient loadTestAdministration = CreateAdministrationClient();

            Response response = await loadTestAdministration.UploadTestFileAsync(testId, fileId, File.OpenRead(Path.Combine("tests", "sample.jmx")));

            Assert.NotNull(response);
        }

        [Test]
        public async Task CreateOrUpdateAppComponent()
        {
            LoadTestAdministrationClient loadTestAdministration = CreateAdministrationClient();

            string appComponentConnectionString = "/subscriptions/7c71b563-0dc0-4bc0-bcf6-06f8f0516c7a/resourceGroups/App-Service-Sample-Demo-rg/providers/Microsoft.Web/sites/App-Service-Sample-Demo";

            Response response = await loadTestAdministration.CreateOrUpdateAppComponentsAsync(appComponentId, RequestContent.Create(
                    new
                    {
                        testid = testId,
                        name = "New App Component",
                        value = new
                        {
                            appComponentConnectionString = new
                            {
                                resourceId = appComponentConnectionString,
                                resourceName = "App-Service-Sample-Demo",
                                resourceType = "Microsoft.Web/sites",
                                subscriptionId = "7c71b563-0dc0-4bc0-bcf6-06f8f0516c7a"
                            }
                        }
                    }
                ));

            Assert.NotNull(response);
        }

        [Test]
        public async Task CreateAndUpdateTest()
        {
            TestRunClient loadTestRun = CreateTestRunClient();

            Response response = await loadTestRun.CreateAndUpdateTestAsync(testRunId, RequestContent.Create(
                    new
                    {
                        testId = testId,
                        displayName = "This is display name"
                    }
                ));

            Assert.NotNull(response);
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
