// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
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

            await _testHelper.SetupLoadTestAsync(_loadTestAdministrationClient, _testId);
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
           TestRunResultOperation testRunOperation = await _loadTestRunClient.BeginTestRunAsync(
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
            var testRunResponse = await _loadTestRunClient.GetTestRunAsync(_testRunId);
            var testRun = testRunResponse.Value;
            Assert.NotNull(testRun);
            Assert.AreEqual(_testRunId, testRun.TestRunId);
            Assert.AreEqual(_testId, testRun.TestId);
        }

        [Test]
        public async Task GetTestRunFile()
        {
            var testRunFileResponse = await _loadTestRunClient.GetTestRunFileAsync(_testRunId, _fileName);
            Assert.NotNull(testRunFileResponse.Value);
            Assert.AreEqual(_fileName, testRunFileResponse.Value.FileName);
            Assert.AreEqual(FileValidationStatus.ValidationSuccess, testRunFileResponse.Value.ValidationStatus);
        }

        [Test]
        public async Task ListTestRuns()
        {
            int pageSizeHint = 2;
            var pagedResponse = _loadTestRunClient.GetTestRunsAsync();

            int count = 0;

            await foreach (var page in pagedResponse.AsPages(pageSizeHint: pageSizeHint))
            {
                count++;

                foreach (var testRun in page.Values)
                {
                    Assert.AreEqual(_testId, testRun.TestId);
                    Assert.AreEqual(_testRunId, testRun.TestRunId);
                }
            }

            int i = 0;
            await foreach (var page in pagedResponse.AsPages(pageSizeHint: pageSizeHint))
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
            var stopResponse = await _loadTestRunClient.StopTestRunAsync(_testRunId);
            Assert.NotNull(stopResponse.Value);
            Assert.AreEqual(_testId, stopResponse.Value.TestId);
            Assert.AreEqual(_testRunId, stopResponse.Value.TestRunId);
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

            var appComponentsResponse = await _loadTestRunClient.GetAppComponentsAsync(_testRunId);
            var appComponents = appComponentsResponse.Value;
            var component = appComponents.Components.Values.FirstOrDefault();
            Assert.NotNull(component);
            Assert.AreEqual(_resourceId, component.ResourceId);
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

            var serverMetricsResponse = await _loadTestRunClient.GetServerMetricsConfigAsync(_testRunId);
            var serverMetrics = serverMetricsResponse.Value;
            var metric = serverMetrics.Metrics.Values.FirstOrDefault();
            Assert.NotNull(metric);
            Assert.AreEqual(_resourceId, metric.ResourceId);
        }

        [Test]
        public async Task GetMetrics()
        {
            await _testRunOperation.WaitForCompletionAsync();

            var getTestRunResponse = await _loadTestRunClient.GetTestRunAsync(_testRunId);
            Assert.NotNull(getTestRunResponse.Value);
            var testRun = getTestRunResponse.Value;

            var getMetricNamespaces = await _loadTestRunClient.GetMetricNamespacesAsync(_testRunId);
            Assert.NotNull(getMetricNamespaces.Value);
            var metricNamespaces = getMetricNamespaces.Value;

            var getMetricDefinitions = await _loadTestRunClient.GetMetricDefinitionsAsync(
                _testRunId, metricNamespaces.Value.FirstOrDefault().Name);
            var metricDefinitions = getMetricDefinitions.Value;

            AsyncPageable<TimeSeriesElement> metricsResponsePageable = _loadTestRunClient.GetMetricsAsync(
                    _testRunId,
                    metricDefinitions.Value.FirstOrDefault().Name,
                    metricNamespaces.Value.FirstOrDefault().Name,
                    testRun.StartDateTime.Value.ToString("o") + "/" + testRun.EndDateTime.Value.ToString("o")
                );

            await foreach (var page in metricsResponsePageable.AsPages())
            {
                foreach (var item in page.Values)
                {
                    Assert.NotNull(item.Data);
                }
            }
        }
    }
}
