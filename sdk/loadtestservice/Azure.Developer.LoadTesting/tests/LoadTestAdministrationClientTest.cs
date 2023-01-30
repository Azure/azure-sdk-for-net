// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.Developer.LoadTesting.Tests.Helper;
using NUnit.Framework;

namespace Azure.Developer.LoadTesting.Tests
{
    public class LoadTestAdministrationClientTest: LoadTestTestsBase
    {
        public LoadTestAdministrationClientTest(bool isAsync) : base(isAsync) { }

        [SetUp]
        public async Task SetUp()
        {
            _loadTestAdministrationClient = CreateAdministrationClient();

            if (!CheckForSkipSetUp())
            {
                await _testHelper.SetupTestingLoadTestResourceAsync(_loadTestAdministrationClient, _testId);

                if (CheckForUploadTestFile())
                {
                    await _testHelper.SetupTestScriptAsync(_loadTestAdministrationClient, _testId, _fileName);
                }
            }
        }

        [TearDown]
        public async Task TearDown()
        {
            if (!CheckForSkipTearDown())
            {
                await _loadTestAdministrationClient.DeleteTestAsync(_testId);
            }
        }

        [Test]
        [Category(SKIP_SET_UP)]
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
        [Category(SKIP_TEAR_DOWN)]
        public async Task DeleteTest()
        {
            Response response = await _loadTestAdministrationClient.DeleteTestAsync(_testId);
            try
            {
                await _loadTestAdministrationClient.DeleteTestAsync(_testId);
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
        public async Task GetLoadTest()
        {
            Response response = await _loadTestAdministrationClient.GetTestAsync(_testId);
            JsonDocument jsonDocument = JsonDocument.Parse(response.Content.ToString());
            Assert.NotNull(response.Content);
            Assert.AreEqual(_testId, jsonDocument.RootElement.GetProperty("testId").ToString());
        }

        [Test]
        public async Task ListLoadTest()
        {
            int pageSizeHint = 2;
            AsyncPageable<BinaryData> responsePageable = _loadTestAdministrationClient.GetTestsAsync();

            int count = 0;

            await foreach (var page in responsePageable.AsPages(pageSizeHint: pageSizeHint))
            {
                count++;

               foreach (var value in page.Values)
               {
                    JsonDocument jsonDocument = JsonDocument.Parse(value.ToString());
                    Assert.NotNull(jsonDocument.RootElement.GetProperty("testId").ToString());

                    Console.WriteLine(value.ToString());
               }
            }

            int i = 0;
            await foreach (var page in responsePageable.AsPages(pageSizeHint: pageSizeHint))
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
        [Category(UPLOAD_TEST_FILE)]
        public async Task GetTestFile()
        {
            Response response = await _loadTestAdministrationClient.GetTestFileAsync(_testId, _fileName);

            JsonDocument jsonDocument = JsonDocument.Parse(response.Content.ToString());
            Assert.NotNull(response.Content);
            Assert.AreEqual(_fileName, jsonDocument.RootElement.GetProperty("fileName").ToString());
        }

        [Test]
        [Category(UPLOAD_TEST_FILE)]
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
        [Category(UPLOAD_TEST_FILE)]
        public async Task ListTestFiles()
        {
            AsyncPageable<BinaryData> responsePageable = _loadTestAdministrationClient.GetTestFilesAsync(_testId);

            await foreach (var page in responsePageable.AsPages())
            {
                foreach (var value in page.Values)
                {
                    JsonDocument jsonDocument = JsonDocument.Parse(value.ToString());
                    Assert.AreEqual(_fileName, jsonDocument.RootElement.GetProperty("fileName").ToString());
                }
            }
        }

        [Test]
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

            Response response = await _loadTestAdministrationClient.GetAppComponentsAsync(_testId);
            JsonDocument jsonDocument = JsonDocument.Parse(response.Content.ToString());
            Assert.AreEqual(_resourceId, jsonDocument.RootElement.GetProperty("components").GetProperty(_resourceId).GetProperty("resourceId").ToString());
        }

        [Test]
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

            Response response = await _loadTestAdministrationClient.GetServerMetricsConfigAsync(_testId);
            JsonDocument jsonDocument = JsonDocument.Parse(response.Content.ToString());
            Assert.AreEqual(_resourceId, jsonDocument.RootElement.GetProperty("metrics").GetProperty(_resourceId).GetProperty("resourceId").ToString());
        }

        [Test]
        public async Task UploadTestFile()
        {
            FileUploadOperation fileUploadOperation = await _loadTestAdministrationClient.UploadTestFileAsync(
                WaitUntil.Completed, _testId, _fileName, RequestContent.Create(
                    File.OpenRead(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), _fileName))
                    )
                );

            JsonDocument jsonDocument = JsonDocument.Parse(fileUploadOperation.Value.ToString());
            Assert.AreEqual(_fileName, jsonDocument.RootElement.GetProperty("fileName").ToString());
            Assert.AreEqual("VALIDATION_SUCCESS", jsonDocument.RootElement.GetProperty("validationStatus").ToString());
            Assert.IsTrue(fileUploadOperation.HasValue);
            Assert.IsTrue(fileUploadOperation.HasCompleted);

            await TearDown();
            await SetUp();

            fileUploadOperation = await _loadTestAdministrationClient.UploadTestFileAsync(
                   WaitUntil.Started, _testId, _fileName, RequestContent.Create(
                        File.OpenRead(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), _fileName))
                    )
                );

            await fileUploadOperation.WaitForCompletionAsync();

            jsonDocument = JsonDocument.Parse(fileUploadOperation.Value.ToString());
            Assert.AreEqual(_fileName, jsonDocument.RootElement.GetProperty("fileName").ToString());
            Assert.AreEqual("VALIDATION_SUCCESS", jsonDocument.RootElement.GetProperty("validationStatus").ToString());
            Assert.IsTrue(fileUploadOperation.HasValue);
            Assert.IsTrue(fileUploadOperation.HasCompleted);
        }
    }
}
