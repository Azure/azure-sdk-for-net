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

        public void SetupTestScript(LoadTestAdministrationClient loadTestAdministrationClient, string testId, string fileName)
        {
            loadTestAdministrationClient.BeginUploadTestFile(
                testId, fileName, RequestContent.Create(
                    File.OpenRead(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName)))
                );
        }

        public async Task SetupTestScriptAsync(LoadTestAdministrationClient loadTestAdministrationClient, string testId, string fileName)
        {
            await loadTestAdministrationClient.BeginUploadTestFileAsync(
                 testId, fileName, RequestContent.Create(
                    File.OpenRead(Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), fileName)))
                );
        }
    }
}
