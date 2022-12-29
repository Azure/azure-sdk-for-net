// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using NUnit.Framework;

namespace Azure.Developer.LoadTesting.Tests
{
    public class LoadTestAdministrationClientTest: RecordedTestBase<LoadTestingClientTestEnvironment>
    {
        public LoadTestAdministrationClientTest(bool isAsync) : base(isAsync) {
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
                TestEnvironment.TestId,
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
            Assert.NotNull(response);
        }
    }
}
