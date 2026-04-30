// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests
{
    public class TelemetryTest : ProjectsClientTestBase
    {
        public TelemetryTest(bool isAsync) : base(isAsync)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task TelemetryOperationsTest()
        {
            AIProjectClient projectClient = GetTestProjectClient();

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
            if (Mode == RecordedTestMode.Playback)
            {
                // In playback mode, the connection string should be sanitized
                Assert.That(connectionString, Is.EqualTo("Sanitized"), "In playback mode, the connection string should be 'Sanitized'.");
            }
            else
            {
                // In record or live mode, the connection string should match the expected format
                ValidateAppInsightsConnectionString(connectionString);
            }

            Assert.That(connectionString, Is.EqualTo(projectClient.Telemetry.GetApplicationInsightsConnectionString()),
                "Testing the cached value of the connection string.");
        }
    }
}
