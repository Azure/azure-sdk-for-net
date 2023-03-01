// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Core;
using NUnit.Framework.Internal;

namespace Azure.Developer.LoadTesting.Tests.Helper
{
    public class TestHelper
    {
        public void SetupTestingLoadTestResource(LoadTestAdministrationClient loadTestAdministrationClient, string testId)
        {
            loadTestAdministrationClient.CreateOrUpdateTest(
                testId,
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
        }

        public async Task SetupTestingLoadTestResourceAsync(LoadTestAdministrationClient loadTestAdministrationClient, string testId)
        {
            await loadTestAdministrationClient.CreateOrUpdateTestAsync(
                testId,
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
        }

        public void SetupTestScript(LoadTestAdministrationClient loadTestAdministrationClient, string testId, string fileName, WaitUntil waitUntil = WaitUntil.Started)
        {
            loadTestAdministrationClient.UploadTestFile(
                waitUntil, testId, fileName, RequestContent.Create(
                    File.OpenRead(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName))
                    )
                );
        }

        public async Task SetupTestScriptAsync(LoadTestAdministrationClient loadTestAdministrationClient, string testId, string fileName, WaitUntil waitUntil = WaitUntil.Started)
        {
            await loadTestAdministrationClient.UploadTestFileAsync(
                 waitUntil, testId, fileName, RequestContent.Create(
                    File.OpenRead(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName))
                    )
                );
        }

        public async Task SetupLoadTestResourceAndTestScriptAsync(LoadTestAdministrationClient loadTestAdministrationClient, string testId, string filename)
        {
            await SetupTestingLoadTestResourceAsync(loadTestAdministrationClient, testId);
            await SetupTestScriptAsync(loadTestAdministrationClient, testId, filename, waitUntil: WaitUntil.Completed);
        }

        public void SetupLoadTestResourceAndTestScript(LoadTestAdministrationClient loadTestAdministrationClient, string testId, string filename)
        {
            SetupTestingLoadTestResource(loadTestAdministrationClient, testId);
            SetupTestScript(loadTestAdministrationClient, testId, filename, WaitUntil.Completed);
        }

        public async Task SetupTestRunWithLoadTestAsync(LoadTestAdministrationClient loadTestAdministrationClient, string testId, string filename, LoadTestRunClient loadTestRunClient, string testRunId, WaitUntil waitUntil)
        {
            await SetupTestingLoadTestResourceAsync(loadTestAdministrationClient, testId);
            await SetupTestScriptAsync(loadTestAdministrationClient, testId, filename, waitUntil: WaitUntil.Completed);
            await loadTestRunClient.BeginTestRunAsync(waitUntil, testRunId, RequestContent.Create(
                    new
                    {
                        testId = testId,
                        displayName = "Run created from dotnet testing framework"
                    }
                ));
        }

        public void SetupTestRunWithLoadTest(LoadTestAdministrationClient loadTestAdministrationClient, string testId, string filename, LoadTestRunClient loadTestRunClient, string testRunId, WaitUntil waitUntil)
        {
            SetupTestingLoadTestResource(loadTestAdministrationClient, testId);
            SetupTestScript(loadTestAdministrationClient, testId, filename, waitUntil: WaitUntil.Completed);
            loadTestRunClient.BeginTestRun(waitUntil, testRunId, RequestContent.Create(
                    new
                    {
                        testId = testId,
                        displayName = "Run created from dotnet testing framework"
                    }
                ));
        }

        public TestRunResultOperation SetupTestRun(LoadTestRunClient loadTestRunClient, string testId, WaitUntil waitUntil)
        {
            return loadTestRunClient.BeginTestRun(waitUntil, testId, RequestContent.Create(
                    new
                    {
                        testId = testId,
                        displayName = "Run created from dotnet testing framework"
                    }
                ));
        }

        public async Task<TestRunResultOperation> SetupTestRunAsync(LoadTestRunClient loadTestRunClient, string testRunId, string testId, WaitUntil waitUntil)
        {
            return await loadTestRunClient.BeginTestRunAsync(waitUntil, testRunId, RequestContent.Create(
                    new
                    {
                        testId = testId,
                        displayName = "Run created from dotnet testing framework"
                    }
                ));
        }
    }
}
