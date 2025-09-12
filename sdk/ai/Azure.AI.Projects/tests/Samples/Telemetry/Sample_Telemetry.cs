// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests
{
    public class Sample_Telemetry : SamplesBase<AIProjectsTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void TelemetryExample()
        {
            #region Snippet:AI_Projects_TelemetryExampleSync
#if SNIPPET
            var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
#else
            var endpoint = TestEnvironment.PROJECTENDPOINT;
#endif
            AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());

            Console.WriteLine("Get the Application Insights connection string.");
            var connectionString = projectClient.Telemetry.GetApplicationInsightsConnectionString();
            Console.WriteLine($"Connection string: {connectionString}");
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task TelemetryExampleAsync()
        {
            #region Snippet:AI_Projects_TelemetryExampleAsync
#if SNIPPET
            var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
#else
            var endpoint = TestEnvironment.PROJECTENDPOINT;
#endif
            AIProjectClient projectClient = new AIProjectClient(new Uri(endpoint), new DefaultAzureCredential());

            Console.WriteLine("Get the Application Insights connection string.");
            var connectionString = await projectClient.Telemetry.GetApplicationInsightsConnectionStringAsync();
            Console.WriteLine($"Connection string: {connectionString}");
            #endregion
        }
    }
}
