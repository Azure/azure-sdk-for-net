// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Azure.Core.TestFramework;
using Azure.Identity;
using NUnit.Framework;
using Azure.AI.Projects.Tests.Utils;

namespace Azure.AI.Projects.Tests
{
    public class TelemetryTest : ProjectsClientTestBase
    {
        public TelemetryTest(bool isAsync) : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task TelemetryOperationsTest()
        {
            AIProjectClient projectClient = GetTestClient();

            Console.WriteLine("Get the Application Insights connection string.");
            string connectionString = "";
            if (IsAsync)
            {
                connectionString = await projectClient.Telemetry.GetApplicationInsightsConnectionStringAsync();
            }
            else
            {
                connectionString = projectClient.Telemetry.GetApplicationInsightsConnectionString();
            }
            Console.WriteLine($"Connection string: {connectionString}");

            // Check test mode to determine expected format
            string testMode = Environment.GetEnvironmentVariable("AZURE_TEST_MODE");

            if (!string.IsNullOrEmpty(testMode) && testMode.Equals("Playback", StringComparison.OrdinalIgnoreCase))
            {
                // In playback mode, the connection string should be sanitized
                Assert.AreEqual("Sanitized", connectionString, "In playback mode, the connection string should be 'Sanitized'.");
            }
            else
            {
                // In record or live mode, the connection string should match the expected format
                Assert.True(TestBase.RegexAppInsightsConnectionString.IsMatch(connectionString), "The connection string should match the expected format.");
            }

            Assert.AreEqual(connectionString, projectClient.Telemetry.GetApplicationInsightsConnectionString(),
                "Testing the cached value of the connection string.");
        }
    }
}
