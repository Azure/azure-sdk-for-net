// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.Developer.LoadTesting.Tests.Helper;
using NUnit.Framework;

namespace Azure.Developer.LoadTesting.Tests
{
    internal class LoadTestRunClientTest: RecordedTestBase<LoadTestingClientTestEnvironment>
    {
        private string _testId;
        private string _testRunId;
        private string _fileName;
        private string _resourceId;
        private TestHelper _testHelper;
        private LoadTestAdministrationClient _loadTestAdministrationClient;

        public LoadTestRunClientTest(bool isAsync) : base(isAsync)
        {
            _testId = "test-from-csharp-sdk-testing-framework";
            _fileName = "sample.jmx";
            _testRunId = "test-run-from-csharp-sdk-testing-framework";
            _testHelper = new TestHelper();

            BodyRegexSanitizers.Add(new BodyRegexSanitizer(@"sig=(?<group>.*?)(?=\s+)", SanitizeValue)
            {
                GroupForReplace = "group"
            });
        }

        /* please refer to https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/template/Azure.Template/tests/TemplateClientLiveTests.cs to write tests. */
        private LoadTestRunClient CreateRunClient()
        {
            return InstrumentClient(new LoadTestRunClient(new Uri("https://" + TestEnvironment.Endpoint), TestEnvironment.Credential, InstrumentClientOptions(new LoadTestingClientOptions())));
        }

        private LoadTestAdministrationClient CreateAdministrationClient()
        {
            return InstrumentClient(new LoadTestAdministrationClient(new Uri("https://" + TestEnvironment.Endpoint), TestEnvironment.Credential, InstrumentClientOptions(new LoadTestingClientOptions())));
        }

        [Test]
        public async Task BeginCreateOrUpdateTestRun()
        {
            LoadTestRunClient loadTestRunClient = CreateRunClient();
            _loadTestAdministrationClient = CreateAdministrationClient();
            await _testHelper.SetupLoadTestResourceAndTestScriptAsync(_loadTestAdministrationClient, _testId, _fileName);

            TestRunOperation testRunOperation = await loadTestRunClient.BeginCreateOrUpdateTestRunAsync(
                _testRunId, RequestContent.Create(
                    new
                    {
                        testId = _testId,
                        displayName = "Run created from dotnet testing framework"
                    }
                ), waitUntil: WaitUntil.Completed);

            Assert.IsTrue(testRunOperation.HasValue);
            Assert.NotNull(testRunOperation.Value);
            Assert.IsTrue(testRunOperation.HasCompleted);

            await loadTestRunClient.DeleteTestRunAsync(_testRunId);
            testRunOperation = await loadTestRunClient.BeginCreateOrUpdateTestRunAsync(
                    _testRunId, RequestContent.Create(
                        new
                        {
                            testId = _testId,
                            displayName = "Run created from dotnet testing framework"
                        }
                   ));

            await testRunOperation.WaitForCompletionAsync();
            Assert.IsTrue(testRunOperation.HasValue);
            Assert.NotNull(testRunOperation.Value);
            Assert.IsTrue(testRunOperation.HasCompleted);
        }

        [Test]
        public async Task GetTestRun()
        {
            LoadTestRunClient loadTestRunClient = CreateRunClient();
            _loadTestAdministrationClient = CreateAdministrationClient();

            Response response = await loadTestRunClient.GetTestRunAsync(_testRunId);
            Assert.NotNull(response);
        }

        [Test]
        public async Task GetTestRunFile()
        {
            LoadTestRunClient loadTestRunClient = CreateRunClient();
            _loadTestAdministrationClient = CreateAdministrationClient();

            Response response = await loadTestRunClient.GetTestRunFileAsync(_testRunId, _fileName);
            Assert.NotNull(response);
        }

        [Test]
        public async Task ListTestRuns()
        {
            LoadTestRunClient loadTestRunClient = CreateRunClient();
            _loadTestAdministrationClient = CreateAdministrationClient();

            await _testHelper.SetupTestRunWithLoadTestAsync(_loadTestAdministrationClient, _testId, _fileName, loadTestRunClient, _testRunId, waitUntil: WaitUntil.Started);
            AsyncPageable<BinaryData> reponse = loadTestRunClient.GetTestRunsAsync();

            Assert.NotNull(reponse);
        }

        [Test]
        public async Task DeleteTestRun()
        {
            LoadTestRunClient loadTestRunClient = CreateRunClient();
            _loadTestAdministrationClient = CreateAdministrationClient();

            await _testHelper.SetupTestRunWithLoadTestAsync(_loadTestAdministrationClient, _testId, _fileName, loadTestRunClient, _testRunId, waitUntil: WaitUntil.Started);
            Response response = await loadTestRunClient.DeleteTestRunAsync(_testRunId);

            Assert.NotNull(response);
        }

        [Test]
        public async Task StopTestRun()
        {
            LoadTestRunClient loadTestRunClient = CreateRunClient();
            _loadTestAdministrationClient = CreateAdministrationClient();

            await loadTestRunClient.DeleteTestRunAsync(_testRunId);
            await _testHelper.SetupTestRunWithLoadTestAsync(_loadTestAdministrationClient, _testId, _fileName, loadTestRunClient, _testRunId, waitUntil: WaitUntil.Started);

            Response response = await loadTestRunClient.StopTestRunAsync(_testRunId);
            Assert.NotNull(response);
        }

        [Test]
        public async Task CreateOrUpdateAppComponents()
        {
            LoadTestRunClient loadTestRunClient = CreateRunClient();
            _loadTestAdministrationClient = CreateAdministrationClient();

            await _testHelper.SetupTestRunWithLoadTestAsync(_loadTestAdministrationClient, _testId, _fileName, loadTestRunClient, _testRunId, waitUntil: WaitUntil.Started);

            _resourceId = TestEnvironment.ResourceId;

            Response response = await loadTestRunClient.CreateOrUpdateAppComponentsAsync(
                    _testRunId,
                    RequestContent.Create(
                        new Dictionary<string, Dictionary<string, Dictionary<string, string>>>
                        {
                            { "components",  new Dictionary<string, Dictionary<string, string>>
                            {
                                    { _resourceId, new Dictionary<string, string>
                                    {
                                            { "resourceId", _resourceId },
                                            { "resourceName", "App-Service-Sample-Demo" },
                                            { "resourceType", "Microsoft.Web/sites" },
                                            { "kind", "web" }
                                        }
                                    }
                                }
                            }
                        }
                    )
                );

            Assert.NotNull(response);
        }

        [Test]
        public async Task GetAppComponents()
        {
            LoadTestRunClient loadTestRunClient = CreateRunClient();
            _loadTestAdministrationClient = CreateAdministrationClient();
            await _testHelper.SetupTestRunWithLoadTestAsync(_loadTestAdministrationClient, _testId, _fileName, loadTestRunClient, _testRunId, waitUntil: WaitUntil.Started);
            _resourceId = TestEnvironment.ResourceId;

            await loadTestRunClient.CreateOrUpdateAppComponentsAsync(
                    _testRunId,
                    RequestContent.Create(
                        new Dictionary<string, Dictionary<string, Dictionary<string, string>>>
                        {
                            { "components",  new Dictionary<string, Dictionary<string, string>>
                            {
                                    { _resourceId, new Dictionary<string, string>
                                    {
                                            { "resourceId", _resourceId },
                                            { "resourceName", "App-Service-Sample-Demo" },
                                            { "resourceType", "Microsoft.Web/sites" },
                                            { "kind", "web" }
                                        }
                                    }
                                }
                            }
                        }
                    )
                );

            Response response = await loadTestRunClient.GetAppComponentsAsync(_testRunId);

            Assert.NotNull(response);
        }

        [Test]
        public async Task CreateOrUpdateServerMetricsConfig()
        {
            LoadTestRunClient loadTestRunClient = CreateRunClient();
            _loadTestAdministrationClient = CreateAdministrationClient();

            await _testHelper.SetupTestRunWithLoadTestAsync(_loadTestAdministrationClient, _testId, _fileName, loadTestRunClient, _testRunId, waitUntil: WaitUntil.Started);

            _resourceId = TestEnvironment.ResourceId;

            Response response = await loadTestRunClient.CreateOrUpdateServerMetricsConfigAsync(
                    _testRunId,
                    RequestContent.Create(
                        new Dictionary<string, Dictionary<string, Dictionary<string, string>>>
                        {
                            {
                                "metrics", new Dictionary<string, Dictionary<string, string>>
                                {
                                    {
                                        _resourceId, new Dictionary<string, string>
                                        {
                                            {"resourceId", _resourceId },
                                            {"metricNamespace", "microsoft.insights/components"},
                                            {"displayDescription", "sample description"},
                                            {"name",  "requests/duration"},
                                            {"aggregation", "Average"},
                                            {"unit", ""},
                                            {"resourceType", "microsoft.insights/components"}
                                        }
                                    }
                                }
                            }
                        }
                    )
                );
            Assert.NotNull( response );
        }

        [Test]
        public async Task GetServerMetricsConfig()
        {
            LoadTestRunClient loadTestRunClient = CreateRunClient();
            _loadTestAdministrationClient = CreateAdministrationClient();

            await _testHelper.SetupTestRunWithLoadTestAsync(_loadTestAdministrationClient, _testId, _fileName, loadTestRunClient, _testRunId, waitUntil: WaitUntil.Started);

            _resourceId = TestEnvironment.ResourceId;

            await loadTestRunClient.CreateOrUpdateServerMetricsConfigAsync(
                    _testRunId,
                    RequestContent.Create(
                        new Dictionary<string, Dictionary<string, Dictionary<string, string>>>
                        {
                            {
                                "metrics", new Dictionary<string, Dictionary<string, string>>
                                {
                                    {
                                        _resourceId, new Dictionary<string, string>
                                        {
                                            {"resourceId", _resourceId },
                                            {"metricNamespace", "microsoft.insights/components"},
                                            {"displayDescription", "sample description"},
                                            {"name",  "requests/duration"},
                                            {"aggregation", "Average"},
                                            {"unit", ""},
                                            {"resourceType", "microsoft.insights/components"}
                                        }
                                    }
                                }
                            }
                        }
                    )
                );

            Response response = await loadTestRunClient.GetServerMetricsConfigAsync(_testRunId);

            Assert.NotNull(response);
        }

        [Test]
        public async Task GetMetrics()
        {
            LoadTestRunClient loadTestRunClient = CreateRunClient();
            _loadTestAdministrationClient = CreateAdministrationClient();

            await _testHelper.SetupTestRunWithLoadTestAsync(_loadTestAdministrationClient, _testId, _fileName, loadTestRunClient, _testRunId, waitUntil: WaitUntil.Completed);

            Response getTestRunResponse = await loadTestRunClient.GetTestRunAsync(_testRunId);
            Assert.NotNull(getTestRunResponse);
            JsonDocument testRunJson = JsonDocument.Parse(getTestRunResponse.Content.ToString());

            Response getMetricNamespaces = await loadTestRunClient.GetMetricNamespacesAsync(_testRunId);
            Assert.NotNull(getMetricNamespaces);
            JsonDocument metricNamespacesJson = JsonDocument.Parse(getMetricNamespaces.Content.ToString());

            Response getMetricDefinitions = await loadTestRunClient.GetMetricDefinitionsAsync(
                _testRunId, metricNamespacesJson.RootElement.GetProperty("value")[0].GetProperty("name").ToString()
                );
            Assert.NotNull(getMetricDefinitions);
            JsonDocument metricDefinitionsJson = JsonDocument.Parse(getMetricDefinitions.Content.ToString());

            AsyncPageable<BinaryData> metrics = loadTestRunClient.GetMetricsAsync(
                    _testRunId,
                    metricNamespacesJson.RootElement.GetProperty("value")[0].GetProperty("name").GetString(),
                    metricDefinitionsJson.RootElement.GetProperty("value")[0].GetProperty("name").GetString(),
                    testRunJson.RootElement.GetProperty("startDateTime").GetString()+"/"+testRunJson.RootElement.GetProperty("endDateTime"),
                    null
                );
            Assert.NotNull(metrics);
        }
    }
}
