// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.OpenTelemetry.Exporter.AzureMonitor
{
    using Xunit;

    public class ApplicationInsightsRestClientTests
    {
        [Theory]
        [InlineData(null)] // default case
        [InlineData("2")]
        public void VerifyGetIngestionUri(string version)
        {
            var testHost = "https://dc.services.visualstudio.com";

            var options = new AzureMonitorExporterOptions
            {
                ConnectionString = $"InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint={testHost}",
                ApiVersion = version,
            };

            var transmitter = new AzureMonitorTransmitter(options);
            var testUri = transmitter.GetIngestionUri();

            Assert.Equal(expected: "https://dc.services.visualstudio.com/v2/track", actual: testUri);
        }
    }
}
