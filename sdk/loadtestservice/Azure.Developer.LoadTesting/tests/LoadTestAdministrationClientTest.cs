// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.Developer.LoadTesting.Tests.Helper;
using NUnit.Framework;

namespace Azure.Developer.LoadTesting.Tests
{
    public class LoadTestAdministrationClientTest: RecordedTestBase<LoadTestingClientTestEnvironment>
    {
        private string _testId;
        private string _fileName;
        //private string testRunId;
        //private string resourceId;
        private TestHelper _testHelper;

        public LoadTestAdministrationClientTest(bool isAsync) : base(isAsync) {
            _testId = "test-from-csharp-sdk-testing-framework";
            _fileName = "sample.jmx";
            //testRunId = "test-run-from-csharp-sdk";
            //resourceId = TestEnvironment.ResourceId;

            _testHelper = new TestHelper();

            BodyRegexSanitizers.Add(new BodyRegexSanitizer(@"sig=(?<group>.*?)(?=\s+)", SanitizeValue)
            {
                GroupForReplace = "group"
            });
        }

        /* please refer to https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/tests/TemplateClientLiveTests.cs to write tests. */
        private LoadTestAdministrationClient CreateAdministrationClient()
        {
            return InstrumentClient(new LoadTestAdministrationClient(new Uri("https://" + TestEnvironment.Endpoint), TestEnvironment.Credential, InstrumentClientOptions(new LoadTestingClientOptions())));
        }

        [Test]
        public async Task CreateOrUpdateTest()
        {
            LoadTestAdministrationClient loadTestAdministrationClient = CreateAdministrationClient();
            Response response = await loadTestAdministrationClient.CreateOrUpdateTestAsync(
                _testId,
                RequestContent.Create(
                        new
                        {
                            description = "This test was created through loadtesting C# SDK",
                            displayName = "Dotnet Testing Framework Loadtest",
                            loadTestConfig = new
                            {
                                engineInstance = 1,
                                splitAllCSVs = false,
                            },
                            secrets = new { },
                            enviornmentVariables = new { },
                            passFailCriteria = new
                            {
                                passFailMetrics = new { },
                            }
                        }
                    )
                );
            Assert.NotNull(response.Content);
        }

        [Test]
        public async Task DeleteTest()
        {
            LoadTestAdministrationClient loadTestAdministrationClient = CreateAdministrationClient();
            await _testHelper.SetupTestingLoadTestResourceAsync(loadTestAdministrationClient, _testId);

            Response response = await loadTestAdministrationClient.DeleteTestAsync(_testId);

            Assert.NotNull(response);
        }

        [Test]
        public async Task GetLoadTest()
        {
            LoadTestAdministrationClient loadTestAdministrationClient = CreateAdministrationClient();
            await _testHelper.SetupTestingLoadTestResourceAsync(loadTestAdministrationClient, _testId);

            Response response = await loadTestAdministrationClient.GetTestAsync(_testId);

            Assert.NotNull(response);
        }

        [Test]
        public async Task ListLoadTest()
        {
            LoadTestAdministrationClient loadTestAdministrationClient = CreateAdministrationClient();
            await _testHelper.SetupTestingLoadTestResourceAsync(loadTestAdministrationClient, _testId);

            AsyncPageable<BinaryData> response = loadTestAdministrationClient.GetTestsAsync();

            Assert.NotNull(response);
        }

        [Test]
        public async Task GetTestFile()
        {
            LoadTestAdministrationClient loadTestAdministrationClient = CreateAdministrationClient();
            await _testHelper.SetupTestingLoadTestResourceAsync(loadTestAdministrationClient, _testId);
            await _testHelper.SetupTestScriptAsync(loadTestAdministrationClient, _testId, _fileName);

            Response response = await loadTestAdministrationClient.GetTestFileAsync(_testId, _fileName);
            Assert.NotNull(response);
        }
    }
}
