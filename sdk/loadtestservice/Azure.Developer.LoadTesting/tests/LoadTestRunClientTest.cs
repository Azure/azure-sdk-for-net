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
    internal class LoadTestRunClientTest: LoadTestTestsBase
    {
        public LoadTestRunClientTest(bool isAsync): base(isAsync) { }

        [SetUp]
        public async Task SetUp()
        {
            _loadTestAdministrationClient = CreateAdministrationClient();
            _loadTestRunClient = CreateRunClient();

            await _testHelper.SetupTestingLoadTestResourceAsync(_loadTestAdministrationClient, _testId);
            await _testHelper.SetupTestScriptAsync(_loadTestAdministrationClient, _testId, _fileName, waitUntil: WaitUntil.Completed);

            if (!CheckForSkipTestRun())
            {
                _testRunOperation = await _testHelper.SetupTestRunAsync(_loadTestRunClient, _testRunId, _testId, WaitUntil.Started);
            }
        }

        [TearDown]
        public async Task TearDown()
        {
            if (!CheckForSkipDeleteTestRun())
            {
                await _loadTestRunClient.DeleteTestRunAsync(_testRunId);
            }
            await _loadTestAdministrationClient.DeleteTestAsync(_testId);
        }

        [Test]
        [Category(SKIP_TEST_RUN)]
        public async Task BeginCreateOrUpdateTestRun()
        {
           TestRunOperation testRunOperation = await _loadTestRunClient.BeginTestRunAsync(
                WaitUntil.Completed, _testRunId, RequestContent.Create(
                    new
                    {
                        testId = _testId,
                        displayName = "Run created from dotnet testing framework"
                    }
                ));

            JsonDocument jsonDocument = JsonDocument.Parse(testRunOperation.Value.ToString());
            Assert.AreEqual(_testRunId, jsonDocument.RootElement.GetProperty("testRunId").ToString());
            Assert.AreEqual(_testId, jsonDocument.RootElement.GetProperty("testId").ToString());
            Assert.AreEqual("DONE", jsonDocument.RootElement.GetProperty("status").ToString());
            Assert.IsTrue(testRunOperation.HasValue);
            Assert.IsTrue(testRunOperation.HasCompleted);

            await _loadTestRunClient.DeleteTestRunAsync(_testRunId);
            await _testHelper.SetupLoadTestResourceAndTestScriptAsync(_loadTestAdministrationClient, _testId, _fileName);

            testRunOperation = await _loadTestRunClient.BeginTestRunAsync(
                   WaitUntil.Completed, _testRunId, RequestContent.Create(
                        new
                        {
                            testId = _testId,
                            displayName = "Run created from dotnet testing framework"
                        }
                   ));

            await testRunOperation.WaitForCompletionAsync();

            jsonDocument = JsonDocument.Parse(testRunOperation.Value.ToString());
            Assert.AreEqual(_testRunId, jsonDocument.RootElement.GetProperty("testRunId").ToString());
            Assert.AreEqual(_testId, jsonDocument.RootElement.GetProperty("testId").ToString());
            Assert.AreEqual("DONE", jsonDocument.RootElement.GetProperty("status").ToString());
            Assert.IsTrue(testRunOperation.HasValue);
            Assert.IsTrue(testRunOperation.HasCompleted);
        }

        [Test]
        public async Task GetTestRun()
        {
            Response response = await _loadTestRunClient.GetTestRunAsync(_testRunId);

            JsonDocument jsonDocument = JsonDocument.Parse(response.Content.ToString());
            Assert.AreEqual(_testRunId, jsonDocument.RootElement.GetProperty("testRunId").ToString());
            Assert.AreEqual(_testId, jsonDocument.RootElement.GetProperty("testId").ToString());
        }

        [Test]
        public async Task GetTestRunFile()
        {
            Response response = await _loadTestRunClient.GetTestRunFileAsync(_testRunId, _fileName);
            JsonDocument jsonDocument = JsonDocument.Parse(response.Content.ToString());
            Assert.AreEqual(_fileName, jsonDocument.RootElement.GetProperty("fileName").ToString());
            Assert.AreEqual("VALIDATION_SUCCESS", jsonDocument.RootElement.GetProperty("validationStatus").ToString());
        }

        [Test]
        public async Task ListTestRuns()
        {
            int pageSizeHint = 2;
            AsyncPageable<BinaryData> responsePageable = _loadTestRunClient.GetTestRunsAsync();

            int count = 0;

            await foreach (var page in responsePageable.AsPages(pageSizeHint: pageSizeHint))
            {
                count++;

                foreach (var testRun in page.Values)
                {
                    JsonDocument jsonDocument = JsonDocument.Parse(testRun.ToString());
                    Assert.NotNull(jsonDocument.RootElement.GetProperty("testId").ToString());
                    Assert.NotNull(jsonDocument.RootElement.GetProperty("testRunId").ToString());
                }
            }

            int i = 0;
            await foreach (var page in responsePageable.AsPages(pageSizeHint: pageSizeHint))
            {
                i++;

                if (i < count)
                {
                    Assert.AreEqual(pageSizeHint, page.Values.Count);
                }
                else
                {
                    Assert.LessOrEqual(page.Values.Count, pageSizeHint);
                }
            }
        }

        [Test]
        [Category(SKIP_DELETE_TEST_RUN)]
        public async Task DeleteTestRun()
        {
            Response response = await _loadTestRunClient.DeleteTestRunAsync(_testRunId);

            try
            {
                await _loadTestRunClient.DeleteTestRunAsync(_testRunId);
                Assert.Fail();
            }
            catch (RequestFailedException)
            {
                Assert.Pass();
            }
            catch (Exception)
            {
                Assert.Fail();
            }
        }

        [Test]
        public async Task StopTestRun()
        {
            Response response = await _loadTestRunClient.StopTestRunAsync(_testRunId);

            JsonDocument jsonDocument = JsonDocument.Parse(response.Content.ToString());
            Assert.AreEqual(_testId, jsonDocument.RootElement.GetProperty("testId").ToString());
            Assert.AreEqual(_testRunId, jsonDocument.RootElement.GetProperty("testRunId").ToString());
        }

        [Test]
        public async Task CreateOrUpdateAppComponents()
        {
            _resourceId = TestEnvironment.ResourceId;

            Response response = await _loadTestRunClient.CreateOrUpdateAppComponentsAsync(
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

            JsonDocument jsonDocument = JsonDocument.Parse(response.Content.ToString());
            Assert.AreEqual(_resourceId, jsonDocument.RootElement.GetProperty("components").GetProperty(_resourceId).GetProperty("resourceId").ToString());
        }

        [Test]
        public async Task GetAppComponents()
        {
            _resourceId = TestEnvironment.ResourceId;

            await _loadTestRunClient.CreateOrUpdateAppComponentsAsync(
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

            Response response = await _loadTestRunClient.GetAppComponentsAsync(_testRunId);

            JsonDocument jsonDocument = JsonDocument.Parse(response.Content.ToString());
            Assert.AreEqual(_resourceId, jsonDocument.RootElement.GetProperty("components").GetProperty(_resourceId).GetProperty("resourceId").ToString());
        }

        [Test]
        public async Task CreateOrUpdateServerMetricsConfig()
        {
            _resourceId = TestEnvironment.ResourceId;

            Response response = await _loadTestRunClient.CreateOrUpdateServerMetricsConfigAsync(
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
            JsonDocument jsonDocument = JsonDocument.Parse(response.Content.ToString());
            Assert.AreEqual(_resourceId, jsonDocument.RootElement.GetProperty("metrics").GetProperty(_resourceId).GetProperty("resourceId").ToString());
        }

        [Test]
        public async Task GetServerMetricsConfig()
        {
            _resourceId = TestEnvironment.ResourceId;
            await _loadTestRunClient.CreateOrUpdateServerMetricsConfigAsync(
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

            Response response = await _loadTestRunClient.GetServerMetricsConfigAsync(_testRunId);

            JsonDocument jsonDocument = JsonDocument.Parse(response.Content.ToString());
            Assert.AreEqual(_resourceId, jsonDocument.RootElement.GetProperty("metrics").GetProperty(_resourceId).GetProperty("resourceId").ToString());
        }

        [Test]
        public async Task GetMetrics()
        {
            await _testRunOperation.WaitForCompletionAsync();

            Response getTestRunResponse = await _loadTestRunClient.GetTestRunAsync(_testRunId);
            Assert.NotNull(getTestRunResponse);
            JsonDocument testRunJson = JsonDocument.Parse(getTestRunResponse.Content.ToString());

            Response getMetricNamespaces = await _loadTestRunClient.GetMetricNamespacesAsync(_testRunId);
            Assert.NotNull(getMetricNamespaces);
            JsonDocument metricNamespacesJson = JsonDocument.Parse(getMetricNamespaces.Content.ToString());

            Response getMetricDefinitions = await _loadTestRunClient.GetMetricDefinitionsAsync(
                _testRunId, metricNamespacesJson.RootElement.GetProperty("value")[0].GetProperty("name").ToString()
                );
            Assert.NotNull(getMetricDefinitions);
            JsonDocument metricDefinitionsJson = JsonDocument.Parse(getMetricDefinitions.Content.ToString());

            AsyncPageable<BinaryData> metricsReponsePageable = _loadTestRunClient.GetMetricsAsync(
                    _testRunId,
                    metricDefinitionsJson.RootElement.GetProperty("value")[0].GetProperty("name").GetString(),
                    metricNamespacesJson.RootElement.GetProperty("value")[0].GetProperty("name").GetString(),
                    testRunJson.RootElement.GetProperty("startDateTime").GetString()+"/"+testRunJson.RootElement.GetProperty("endDateTime")
                );

            await foreach (var page in metricsReponsePageable.AsPages())
            {
                foreach (var item in page.Values)
                {
                    JsonDocument jsonItem = JsonDocument.Parse(item.ToString());
                    Assert.NotNull(jsonItem.RootElement.GetProperty("data"));
                }
            }
        }
    }
}
