// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Microsoft.OpenTelemetry.Exporter.AzureMonitor.Integration.Tests.TestFramework;

using Xunit;
using Xunit.Abstractions;

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor.Integration.Tests
{
    public class OpenTelemetryTests : IClassFixture<OpenTelemetryWebApplicationFactory<AspNetCoreWebApp.Startup>>
    {
        private readonly OpenTelemetryWebApplicationFactory<AspNetCoreWebApp.Startup> factory;
        private readonly ITestOutputHelper output;

        public OpenTelemetryTests(OpenTelemetryWebApplicationFactory<AspNetCoreWebApp.Startup> factory, ITestOutputHelper output)
        {
            this.factory = factory;
            this.output = output;
        }

#if !NET5_0  // "https://github.com/Azure/azure-sdk-for-net/issues/16961")]
        /// <summary>
        /// This test validates that when an app instrumented with the AzureMonitorExporter receives an HTTP request,
        /// A TelemetryItem is created matching that request.
        /// </summary>
        [Fact]
        public async Task ProofOfConcept()
        {
            string testValue = Guid.NewGuid().ToString();

            // Arrange
            var client = this.factory.CreateClient();

            //// Act
            var response = await client.GetAsync($"api/home/{testValue}");

            // Shutdown
            response.EnsureSuccessStatusCode();
            Task.Delay(100).Wait(); //TODO: HOW TO REMOVE THIS WAIT?
            this.factory.ForceFlush();

            // Assert
            Assert.True(this.factory.TelemetryItems.Any(), "test project did not capture telemetry");

            PrintTelemetryItems(this.factory.TelemetryItems);
            var item = this.factory.TelemetryItems.Single();
            var baseData = (Models.RequestData)item.Data.BaseData;
            Assert.True(baseData.Url.EndsWith(testValue), "it is expected that the recorded TelemetryItem matches the value of testValue.");
        }
#endif

        /// <summary>
        /// This uses the XUnit ITestOutputHelper to print details to the output of the test run.
        /// </summary>
        private void PrintTelemetryItems(IEnumerable<Models.TelemetryItem> telemetryItems)
        {
            foreach (var item in telemetryItems)
            {
                this.output.WriteLine(item.Name);

                if (item.Data.BaseData is Models.RequestData requestData)
                {
                    this.output.WriteLine($"\t{requestData.Url}");
                }
            }
        }
    }
}
