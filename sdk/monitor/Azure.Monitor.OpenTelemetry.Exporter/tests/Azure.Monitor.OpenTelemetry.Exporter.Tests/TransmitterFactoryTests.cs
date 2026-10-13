// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Monitor.OpenTelemetry.Exporter.Internals;
using Azure.Monitor.OpenTelemetry.Exporter.Internals.Diagnostics;
using Azure.Monitor.OpenTelemetry.Exporter.Tests.CommonTestFramework;
using Xunit;

namespace Azure.Monitor.OpenTelemetry.Exporter.Tests
{
    public class TransmitterFactoryTests
    {
        /// <summary>
        /// Users may not specify their connection string in the <see cref="AzureMonitorExporterOptions"/>.
        /// In this scenario, the sdk would use the environment variable.
        ///
        /// This test confirms that the factory correctly handles a null value.
        /// </summary>
        [Fact]
        public void VerifyNullConnectionString()
        {
            var factory = new TransmitterFactory();
            var options = new AzureMonitorExporterOptions() { ConnectionString = null };

            var mockPlatform = new MockPlatform();
            mockPlatform.SetEnvironmentVariable("APPLICATIONINSIGHTS_CONNECTION_STRING", "InstrumentationKey=00000000-0000-0000-0000-000000000000;");

            var transmitter = factory.Get(options, mockPlatform);

            Assert.Single(factory._transmitters);
            Assert.True(factory._transmitters.ContainsKey(string.Empty));
        }

        [Fact]
        public void VerifyRepeatedCallsGenerateOnlyOneTransmitter()
        {
            var factory = new TransmitterFactory();
            var options = new AzureMonitorExporterOptions { ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000;" };

            var transmitter1 = factory.Get(options);
            var transmitter2 = factory.Get(options);

            Assert.Single(factory._transmitters);
            Assert.True(factory._transmitters.ContainsKey(options.ConnectionString));
            Assert.Equal(transmitter1, transmitter2);
        }

        [Theory]
        [InlineData(false, true, "without", "with")]
        [InlineData(true, false, "with", "without")]
        public void ACachedTransmitterWithADifferentCredentialSettingIsReported(bool firstHasCredential, bool secondHasCredential, string transmitterCredential, string exporterCredential)
        {
            var factory = new TransmitterFactory();
            var platform = new MockPlatform();

            using var first = (AzureMonitorTransmitter)factory.Get(CreateOptions(firstHasCredential ? new StubCredential() : null), platform);

            using var listener = new TestEventListener();
            listener.EnableEvents(AzureMonitorExporterEventSource.Log, EventLevel.Warning, EventKeywords.All);

            var second = factory.Get(CreateOptions(secondHasCredential ? new StubCredential() : null), platform);

            Assert.Same(first, second);
            Assert.Equal(firstHasCredential, first.IsAadEnabled);

            var mismatch = Assert.Single(listener.Messages.Where(e => e.EventName == "CachedTransmitterCredentialMismatch"));
            Assert.Equal(transmitterCredential, mismatch.Payload![0]);
            Assert.Equal(exporterCredential, mismatch.Payload[1]);
        }

        // Separate credential instances for the same identity are normal and must not warn.
        [Theory]
        [InlineData(false)]
        [InlineData(true)]
        public void ACachedTransmitterWithTheSameCredentialSettingIsNotReported(bool hasCredential)
        {
            var factory = new TransmitterFactory();
            var platform = new MockPlatform();

            using var first = (AzureMonitorTransmitter)factory.Get(CreateOptions(hasCredential ? new StubCredential() : null), platform);

            using var listener = new TestEventListener();
            listener.EnableEvents(AzureMonitorExporterEventSource.Log, EventLevel.Warning, EventKeywords.All);

            factory.Get(CreateOptions(hasCredential ? new StubCredential() : null), platform);

            Assert.DoesNotContain(listener.Messages, e => e.EventName == "CachedTransmitterCredentialMismatch");
        }

        private static AzureMonitorExporterOptions CreateOptions(TokenCredential? credential) => new()
        {
            ConnectionString = "InstrumentationKey=00000000-0000-0000-0000-000000000000;IngestionEndpoint=https://eastus-1.in.applicationinsights.azure.com/",
            Credential = credential,
            DisableOfflineStorage = true,
            EnableStatsbeat = false,
        };

        private sealed class StubCredential : TokenCredential
        {
            public override AccessToken GetToken(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => new("token", DateTimeOffset.UtcNow.AddHours(1));

            public override ValueTask<AccessToken> GetTokenAsync(TokenRequestContext requestContext, CancellationToken cancellationToken)
                => new(GetToken(requestContext, cancellationToken));
        }
    }
}
