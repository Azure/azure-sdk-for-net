// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Moq;

using OpenTelemetry.Exporter.AzureMonitor.Models;

using Xunit;

namespace OpenTelemetry.Exporter.AzureMonitor
{
    public class AzureMonitorTransmitterTests
    {
        public const string EmptyConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000";

        [Fact]
        public async Task VerifyIngestionBehavior_Success()
        {
            int testItemsReceived = 1, testItemsAccepted = 1;
            var errors = new List<TelemetryErrorDetails>();

            var transmitter = new AzureMonitorTransmitter(
                exporterOptions: new AzureMonitorExporterOptions { ConnectionString = EmptyConnectionString },
                applicationInsightsRestClient: GetMockServiceRestClient(itemsReceived: testItemsReceived, itemsAccepted: testItemsAccepted, errors));

            var returnValue = await transmitter.TrackAsync(
                telemetryItems: new List<TelemetryItem> { default },
                async: true,
                cancellationToken: CancellationToken.None);

            Assert.Equal(testItemsAccepted, returnValue);
        }

        // TODO: The AzureMonitorTransmitter currently doesn't handle responses other than Success.
        // public async Task VerifyIngestionBehavior_Failure()

        private ApplicationInsightsRestClient GetMockServiceRestClient(int itemsReceived, int itemsAccepted, List<TelemetryErrorDetails> errors)
        {
            var mockApplicationInsightsRestClient = new Mock<ApplicationInsightsRestClient>();
            mockApplicationInsightsRestClient
                .Setup(x => x.InternalTrackAsync(It.IsAny<IEnumerable<TelemetryItem>>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(GetMockResponse(itemsReceived, itemsAccepted, errors)));

            return mockApplicationInsightsRestClient.Object;
        }

        private Azure.Response<TrackResponse> GetMockResponse(int itemsReceived, int itemsAccepted, List<TelemetryErrorDetails> errors)
        {
            var trackResponse = new TrackResponse(itemsReceived, itemsAccepted, errors);
            var mockAzureResponse = new Mock<Azure.Response<TrackResponse>>();
            mockAzureResponse.Setup(x => x.Value).Returns(trackResponse);
            return mockAzureResponse.Object;
        }
    }
}
