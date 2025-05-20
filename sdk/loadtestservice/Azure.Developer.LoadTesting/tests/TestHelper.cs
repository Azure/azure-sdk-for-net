// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Core;
using NUnit.Framework.Internal;

namespace Azure.Developer.LoadTesting.Tests.Helper
{
    public class TestHelper
    {
        public void SetupLoadTest(LoadTestAdministrationClient loadTestAdministrationClient, string testId)
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

        public async Task SetupLoadTestAsync(LoadTestAdministrationClient loadTestAdministrationClient, string testId)
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
                    GetFileContentStream(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName))
                    )
                );
        }

        public async Task SetupTestScriptAsync(LoadTestAdministrationClient loadTestAdministrationClient, string testId, string fileName, WaitUntil waitUntil = WaitUntil.Started)
        {
            await loadTestAdministrationClient.UploadTestFileAsync(
                 waitUntil, testId, fileName, RequestContent.Create(
                    await GetFileContentStreamAsync(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName))
                    )
                );
        }

        public void SetupTestProfile(LoadTestAdministrationClient loadTestAdministrationClient, string testProfileId, string testId, string targetResourceId)
        {
            loadTestAdministrationClient.CreateOrUpdateTestProfile(
                testProfileId,
                RequestContent.Create(
                        new
                        {
                            displayName = "Dotnet Testing Framework TestProfile",
                            description = "This test profile was created through loadtesting C# SDK",
                            testId = testId,
                            targetResourceId = targetResourceId,
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
        }

        public async Task SetupTestProfileAsync(LoadTestAdministrationClient loadTestAdministrationClient, string testProfileId, string testId, string targetResourceId)
        {
            await loadTestAdministrationClient.CreateOrUpdateTestProfileAsync(
                testProfileId,
                RequestContent.Create(
                        new
                        {
                            displayName = "Dotnet Testing Framework TestProfile",
                            description = "This test profile was created through loadtesting C# SDK",
                            testId = testId,
                            targetResourceId = targetResourceId,
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
        }

        public async Task SetupLoadTestResourceAndTestScriptAsync(LoadTestAdministrationClient loadTestAdministrationClient, string testId, string filename)
        {
            await SetupLoadTestAsync(loadTestAdministrationClient, testId);
            await SetupTestScriptAsync(loadTestAdministrationClient, testId, filename, waitUntil: WaitUntil.Completed);
        }

        public void SetupLoadTestResourceAndTestScript(LoadTestAdministrationClient loadTestAdministrationClient, string testId, string filename)
        {
            SetupLoadTest(loadTestAdministrationClient, testId);
            SetupTestScript(loadTestAdministrationClient, testId, filename, WaitUntil.Completed);
        }

        public async Task SetupTestRunWithLoadTestAsync(LoadTestAdministrationClient loadTestAdministrationClient, string testId, string filename, LoadTestRunClient loadTestRunClient, string testRunId, WaitUntil waitUntil)
        {
            await SetupLoadTestAsync(loadTestAdministrationClient, testId);
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
            SetupLoadTest(loadTestAdministrationClient, testId);
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

        public Operation<BinaryData> SetupTestProfileRun(LoadTestRunClient loadTestRunClient, string testProfileRunId, string testProfileId, WaitUntil waitUntil)
        {
            return loadTestRunClient.BeginTestProfileRun(waitUntil, testProfileRunId, RequestContent.Create(
                    new
                    {
                        testProfileId = testProfileId,
                        displayName = "TestProfileRun created from dotnet test framework"
                    }
                ));
        }

        public async Task<Operation<BinaryData>> SetupTestProfileRunAsync(LoadTestRunClient loadTestRunClient, string testProfileRunId, string testProfileId, WaitUntil waitUntil)
        {
            return await loadTestRunClient.BeginTestProfileRunAsync(waitUntil, testProfileRunId, RequestContent.Create(
                    new
                    {
                        testProfileId = testProfileId,
                        displayName = "TestProfileRun created from dotnet test framework"
                    }
                ));
        }

        public Stream GetFileContentStream(string filePath)
        {
            // NOTE: This is just used to escape the line endings in the file before sending it.
            var fileContent = File.ReadAllText(filePath)
                .Replace("\n\r", "\n"); // Normalize line endings

            var fileBytes = System.Text.Encoding.UTF8.GetBytes(fileContent);
            return new MemoryStream(fileBytes);
        }

        public async Task<Stream> GetFileContentStreamAsync(string filePath)
        {
            // NOTE: This is just used to escape the line endings in the file before sending it.
#if NETFRAMEWORK
            var fileContent = await Task.FromResult(File.ReadAllText(filePath)
                .Replace("\n\r", "\n"));
#else
            var fileContent = await File.ReadAllTextAsync(filePath);
            fileContent.Replace("\n\r", "\n"); // Normalize line endings
#endif
            var fileBytes = System.Text.Encoding.UTF8.GetBytes(fileContent);
            return new MemoryStream(fileBytes);
        }
    }
}
