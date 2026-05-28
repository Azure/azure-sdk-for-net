// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace Azure.Developer.LoadTesting.Tests
{
    public class LoadTestAdministrationClientTest: LoadTestTestsBase
    {
        public LoadTestAdministrationClientTest(bool isAsync) : base(isAsync) { }

        [SetUp]
        public async Task SetUp()
        {
            _loadTestAdministrationClient = CreateAdministrationClient();

            // NOTE: Load test, test file and test profile requires a load test first.
            if (RequiresLoadTest() || RequiresTestFile() || RequiresTestProfile())
            {
                await _testHelper.SetupLoadTestAsync(_loadTestAdministrationClient, _testId);
            }

            if (RequiresTestFile() || RequiresTestProfile())
            {
                await _testHelper.SetupTestScriptAsync(_loadTestAdministrationClient, _testId, _fileName);
            }

            if (RequiresTestProfile())
            {
                await _testHelper.SetupTestProfileAsync(_loadTestAdministrationClient, _testProfileId, _testId, TestEnvironment.TargetResourceId);
            }
        }

        [TearDown]
        public async Task TearDown()
        {
            if (!SkipTearDown())
            {
                await _loadTestAdministrationClient.DeleteTestProfileAsync(_testProfileId);
                await _loadTestAdministrationClient.DeleteTestAsync(_testId);
            }
        }

        [Test]
        public async Task CreateOrUpdateTest()
        {
            Response response = await _loadTestAdministrationClient.CreateOrUpdateTestAsync(
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
            JsonDocument jsonDocument = JsonDocument.Parse(response.Content.ToString());
            Assert.NotNull(response.Content);
            Assert.AreEqual(_testId, jsonDocument.RootElement.GetProperty("testId").ToString());
        }

        [Test]
        [Category(REQUIRES_LOAD_TEST)]
        [Category(SKIP_TEAR_DOWN)]
        public async Task DeleteTest()
        {
            Response response = await _loadTestAdministrationClient.DeleteTestAsync(_testId);
        }

        [Test]
        [Category(REQUIRES_LOAD_TEST)]
        public async Task GetLoadTest()
        {
            var loadTestResponse = await _loadTestAdministrationClient.GetTestAsync(_testId);
            var loadTest = loadTestResponse.Value;
            Assert.NotNull(loadTest);
            Assert.AreEqual(_testId, loadTest.TestId);
        }

        [Test]
        [Category(REQUIRES_LOAD_TEST)]
        public async Task ListLoadTest()
        {
            int pageSizeHint = 2;
            var pagedResponse = _loadTestAdministrationClient.GetTestsAsync();

            int count = 0;

            await foreach (var page in pagedResponse.AsPages(pageSizeHint: pageSizeHint))
            {
                count++;

               foreach (var value in page.Values)
               {
                    Assert.NotNull(value.TestId);

                    Console.WriteLine(value.ToString());
               }
            }

            int i = 0;
            await foreach (var page in pagedResponse.AsPages(pageSizeHint: pageSizeHint))
            {
                i++;

                if (i<count)
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
        [Category(REQUIRES_TEST_FILE)]
        public async Task GetTestFile()
        {
            var fileGetResponse = await _loadTestAdministrationClient.GetTestFileAsync(_testId, _fileName);

            var file = fileGetResponse.Value;
            Assert.NotNull(file);
            Assert.AreEqual(_fileName, file.FileName);
        }

        [Test]
        [Category(REQUIRES_TEST_FILE)]
        public async Task DeleteTestFile()
        {
            Response response = await _loadTestAdministrationClient.DeleteTestFileAsync(_testId, _fileName);

            try
            {
                await _loadTestAdministrationClient.DeleteTestFileAsync(_testId, _fileName);
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
        [Category(REQUIRES_TEST_FILE)]
        public async Task ListTestFiles()
        {
            var pagedResponse = _loadTestAdministrationClient.GetTestFilesAsync(_testId);

            await foreach (var page in pagedResponse.AsPages())
            {
                foreach (var value in page.Values)
                {
                    Assert.AreEqual(_fileName, value.FileName);
                }
            }
        }

        [Test]
        [Category(REQUIRES_LOAD_TEST)]
        public async Task CreateOrUpdateAppComponents()
        {
            _resourceId = TestEnvironment.ResourceId;
            Response response = await _loadTestAdministrationClient.CreateOrUpdateAppComponentsAsync(
                    _testId,
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
        [Category(REQUIRES_LOAD_TEST)]
        public async Task GetAppComponents()
        {
            _resourceId = TestEnvironment.ResourceId;
            await _loadTestAdministrationClient.CreateOrUpdateAppComponentsAsync(
                    _testId,
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

            var appComponentsResponse = await _loadTestAdministrationClient.GetAppComponentsAsync(_testId);
            var appComponents = appComponentsResponse.Value;
            Assert.NotNull(appComponents);
            var component = appComponents.Components.Values.FirstOrDefault();
            Assert.NotNull(component);
            Assert.AreEqual(_resourceId, component.ResourceId.ToString());
        }

        [Test]
        [Category(REQUIRES_LOAD_TEST)]
        public async Task CreateOrUpdateServerMetricsConfig()
        {
            _resourceId = TestEnvironment.ResourceId;

            Response response = await _loadTestAdministrationClient.CreateOrUpdateServerMetricsConfigAsync(
                    _testId,
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
        [Category(REQUIRES_LOAD_TEST)]
        public async Task GetServerMetricsConfig()
        {
            _resourceId = TestEnvironment.ResourceId;
            await _loadTestAdministrationClient.CreateOrUpdateServerMetricsConfigAsync(
                    _testId,
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

            var serverMetricsResponse = await _loadTestAdministrationClient.GetServerMetricsConfigAsync(_testId);
            var serverMetrics = serverMetricsResponse.Value;
            Assert.NotNull(serverMetrics);
            var metric = serverMetrics.Metrics.Values.FirstOrDefault();
            Assert.NotNull(metric);
            Assert.AreEqual(_resourceId, metric.ResourceId.ToString());
        }

        [Test]
        [Category(REQUIRES_LOAD_TEST)]
        public async Task UploadTestFile_WaitUntilCompleted()
        {
            var fileContentStream = await _testHelper.GetFileContentStreamAsync(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), _fileName));
            FileUploadResultOperation fileUploadOperation = await _loadTestAdministrationClient.UploadTestFileAsync(
                WaitUntil.Completed, _testId, _fileName, RequestContent.Create(
                    fileContentStream
                    )
                );

            JsonDocument jsonDocument = JsonDocument.Parse(fileUploadOperation.Value.ToString());
            Assert.AreEqual(_fileName, jsonDocument.RootElement.GetProperty("fileName").ToString());
            Assert.AreEqual("VALIDATION_SUCCESS", jsonDocument.RootElement.GetProperty("validationStatus").ToString());
            Assert.IsTrue(fileUploadOperation.HasValue);
            Assert.IsTrue(fileUploadOperation.HasCompleted);
        }

        [Test]
        [Category(REQUIRES_LOAD_TEST)]
        public async Task UploadTestFile_PollOperation()
        {
            var fileContentStream = await _testHelper.GetFileContentStreamAsync(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), _fileName));
            FileUploadResultOperation fileUploadOperation = await _loadTestAdministrationClient.UploadTestFileAsync(
                   WaitUntil.Started, _testId, _fileName, RequestContent.Create(
                        fileContentStream
                    )
                );

            await fileUploadOperation.WaitForCompletionAsync();

            JsonDocument jsonDocument = JsonDocument.Parse(fileUploadOperation.Value.ToString());
            Assert.AreEqual(_fileName, jsonDocument.RootElement.GetProperty("fileName").ToString());
            Assert.AreEqual("VALIDATION_SUCCESS", jsonDocument.RootElement.GetProperty("validationStatus").ToString());
            Assert.IsTrue(fileUploadOperation.HasValue);
            Assert.IsTrue(fileUploadOperation.HasCompleted);
        }

        [Test]
        [Category(REQUIRES_LOAD_TEST)]
        public async Task CreateOrUpdateTestProfile()
        {
            _targetResourceId = TestEnvironment.TargetResourceId;
            Response response = await _loadTestAdministrationClient.CreateOrUpdateTestProfileAsync(
                _testProfileId,
                RequestContent.Create(
                        new
                        {
                            displayName = "Dotnet Testing Framework Loadtest",
                            description = "This test was created through loadtesting C# SDK",
                            testId = _testId,
                            targetResourceId = _targetResourceId,
                            targetResourceConfigurations = new
                            {
                                kind = "FunctionsFlexConsumption",
                                configurations = new
                                {
                                    config1 = new
                                    {
                                        instanceMemoryMB = 2048,
                                        httpConcurrency = 20
                                    },
                                    config2 = new
                                    {
                                        instanceMemoryMB = 4096,
                                        httpConcurrency = 20
                                    }
                                }
                            }
                        }
                    )
                );
            JsonDocument jsonDocument = JsonDocument.Parse(response.Content.ToString());
            Assert.AreEqual(_testProfileId, jsonDocument.RootElement.GetProperty("testProfileId").ToString());
        }

        [Test]
        [Category(REQUIRES_TEST_PROFILE)]
        public async Task GetTestProfile()
        {
            var testProfileResponse = await _loadTestAdministrationClient.GetTestProfileAsync(_testProfileId);
            var testProfile = testProfileResponse.Value;
            Assert.NotNull(testProfile);
            Assert.AreEqual(_testProfileId, testProfile.TestProfileId);
            Assert.AreEqual(_targetResourceId, testProfile.TargetResourceId.ToString());
        }

        [Test]
        [Category(REQUIRES_TEST_PROFILE)]
        public async Task ListTestProfile()
        {
            var testProfilesResponse = _loadTestAdministrationClient.GetTestProfilesAsync();
            Assert.NotNull(testProfilesResponse);
            await foreach (var page in testProfilesResponse.AsPages())
            {
                foreach (var value in page.Values)
                {
                    Assert.NotNull(value.TestProfileId);
                }
            }
        }

        [Test]
        [Category(REQUIRES_LOAD_TEST)]
        [Category(REQUIRES_TEST_PROFILE)]
        public async Task DeleteTestProfile()
        {
            Response response = await _loadTestAdministrationClient.DeleteTestProfileAsync(_testProfileId);
        }
    }
}
