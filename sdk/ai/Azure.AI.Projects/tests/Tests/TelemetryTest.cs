// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests
{
    public class TelemetryTest : RecordedTestBase<AIProjectsTestEnvironment>
    {
        public TelemetryTest(bool isAsync) : base(isAsync)
        {
            TestDiagnostics = false;
        }

        [RecordedTest]
        public void TelemetryTestSync()
        {
            var endpoint = TestEnvironment.PROJECTENDPOINT;
            AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());

            Console.WriteLine("Get the Application Insights connection string.");
            var connectionString = projectClient.Telemetry.GetApplicationInsightsConnectionString();
            Console.WriteLine($"Connection string: {connectionString}");
            Assert.True(TestBase.RegexAppInsightsConnectionString.IsMatch(connectionString), "The connection string should match the expected format.");
            // TODO: add check for when it's the recording and it'll be sanitized (essentially check that the connection string is <sanitized-value>)

            Assert.AreEqual(connectionString, projectClient.Telemetry.GetApplicationInsightsConnectionString(),
                "Testing the cached value of the connection string.");
        }

        [RecordedTest]
        public async Task TelemetryTestAsync()
        {
            var endpoint = TestEnvironment.PROJECTENDPOINT;
            AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());

            Console.WriteLine("Get the Application Insights connection string.");
            var connectionString = await projectClient.Telemetry.GetApplicationInsightsConnectionStringAsync();
            Console.WriteLine($"Connection string: {connectionString}");
            Assert.True(TestBase.RegexAppInsightsConnectionString.IsMatch(connectionString), "The connection string should match the expected format.");

            Assert.AreEqual(connectionString, projectClient.Telemetry.GetApplicationInsightsConnectionString(),
                "Testing the cached value of the connection string.");
        }
    }
}
