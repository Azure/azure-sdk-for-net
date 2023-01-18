// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
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

        [Test]
        public async Task DeleteTestFile()
        {
            LoadTestAdministrationClient loadTestAdministrationClient = CreateAdministrationClient();
            await _testHelper.SetupTestingLoadTestResourceAsync(loadTestAdministrationClient, _testId);
            await _testHelper.SetupTestScriptAsync(loadTestAdministrationClient, _testId, _fileName);

            Response response = await loadTestAdministrationClient.DeleteTestFileAsync(_testId, _fileName);
            Assert.NotNull(response);
        }

        [Test]
        public async Task ListTestFiles()
        {
            LoadTestAdministrationClient loadTestAdministrationClient = CreateAdministrationClient();
            await _testHelper.SetupTestingLoadTestResourceAsync(loadTestAdministrationClient, _testId);
            await _testHelper.SetupTestScriptAsync(loadTestAdministrationClient, _testId, _fileName);

            AsyncPageable<BinaryData> response = loadTestAdministrationClient.GetTestFilesAsync(_testId);
            Assert.NotNull(response);
        }

        [Test]
        public async Task CreateOrUpdateAppComponents()
        {
            LoadTestAdministrationClient loadTestAdministrationClient = CreateAdministrationClient();
            await _testHelper.SetupTestingLoadTestResourceAsync(loadTestAdministrationClient, _testId);
            _resourceId = TestEnvironment.ResourceId;

            Response response = await loadTestAdministrationClient.CreateOrUpdateAppComponentsAsync(
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
        }

        [Test]
        public async Task GetAppComponents()
        {
            LoadTestAdministrationClient loadTestAdministrationClient = CreateAdministrationClient();
            await _testHelper.SetupTestingLoadTestResourceAsync(loadTestAdministrationClient, _testId);

            _resourceId = TestEnvironment.ResourceId;

            await loadTestAdministrationClient.CreateOrUpdateAppComponentsAsync(
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

            Response response = await loadTestAdministrationClient.GetAppComponentsAsync(_testId);
            Assert.IsNotNull(response);
        }

        [Test]
        public async Task CreateOrUpdateServerMetricsConfig()
        {
            LoadTestAdministrationClient loadTestAdministrationClient = CreateAdministrationClient();
            await _testHelper.SetupTestingLoadTestResourceAsync(loadTestAdministrationClient, _testId);
            _resourceId = TestEnvironment.ResourceId;

            Response response = await loadTestAdministrationClient.CreateOrUpdateServerMetricsConfigAsync(
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
        }

        [Test]
        public async Task GetServerMetricsConfig()
        {
            LoadTestAdministrationClient loadTestAdministrationClient = CreateAdministrationClient();
            await _testHelper.SetupTestingLoadTestResourceAsync(loadTestAdministrationClient, _testId);
            _resourceId = TestEnvironment.ResourceId;

            await loadTestAdministrationClient.CreateOrUpdateServerMetricsConfigAsync(
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

            Response response = await loadTestAdministrationClient.GetServerMetricsConfigAsync(_testId);
            Assert.NotNull(response);
        }

        [Test]
        public async Task UploadTestFile()
        {
            LoadTestAdministrationClient loadTestAdministrationClient = CreateAdministrationClient();
            await _testHelper.SetupTestingLoadTestResourceAsync(loadTestAdministrationClient, _testId);

            FileUploadOperation fileUploadOperation = await loadTestAdministrationClient.UploadTestFileAsync(
                WaitUntil.Completed, _testId, _fileName, RequestContent.Create(
                    File.OpenRead(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), _fileName))
                    )
                );

            Assert.IsTrue(fileUploadOperation.HasValue);
            Assert.NotNull(fileUploadOperation.Value);
            Assert.IsTrue(fileUploadOperation.HasCompleted);

            await loadTestAdministrationClient.DeleteTestAsync(_testId);

            await _testHelper.SetupTestingLoadTestResourceAsync(loadTestAdministrationClient, _testId);
            fileUploadOperation = await loadTestAdministrationClient.UploadTestFileAsync(
                   WaitUntil.Started, _testId, _fileName, RequestContent.Create(
                        File.OpenRead(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), _fileName))
                    )
                );

            await fileUploadOperation.WaitForCompletionAsync();
            Assert.IsTrue(fileUploadOperation.HasValue);
            Assert.NotNull(fileUploadOperation.Value);
            Assert.IsTrue(fileUploadOperation.HasCompleted);
        }
    }
}
