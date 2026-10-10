// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure;
using Azure.AI.VoiceLive.Tests.Infrastructure;
using NUnit.Framework;

namespace Azure.AI.VoiceLive.Tests
{
    [TestFixture]
    public class AudioEchoCancellationTests
    {
        [Test]
        public void EchoCancellationReferenceSource_KnownValues()
        {
            Assert.That(EchoCancellationReferenceSource.Server.ToString(), Is.EqualTo("server"));
            Assert.That(EchoCancellationReferenceSource.Client.ToString(), Is.EqualTo("client"));
        }

        [Test]
        public void AudioEchoCancellation_ChannelsAndReferenceSource_Serialize()
        {
            var echo = new AudioEchoCancellation
            {
                Channels = 2,
                ReferenceSource = EchoCancellationReferenceSource.Server,
            };

            var json = TestUtilities.SerializeViaIJsonModel(echo);
            using var doc = JsonDocument.Parse(json);

            Assert.That(doc.RootElement.GetProperty("channels").GetInt32(), Is.EqualTo(2));
            Assert.That(doc.RootElement.GetProperty("reference_source").GetString(), Is.EqualTo("server"));
        }

        [Test]
        public void AudioEchoCancellation_ClientReferenceSource_Serializes()
        {
            var echo = new AudioEchoCancellation { ReferenceSource = EchoCancellationReferenceSource.Client };
            var json = TestUtilities.SerializeViaIJsonModel(echo);
            using var doc = JsonDocument.Parse(json);

            Assert.That(doc.RootElement.GetProperty("reference_source").GetString(), Is.EqualTo("client"));
        }

        [Test]
        public void AudioEchoCancellation_DefaultsOmittedFromJson()
        {
            var echo = new AudioEchoCancellation();
            var json = TestUtilities.SerializeViaIJsonModel(echo);
            using var doc = JsonDocument.Parse(json);

            Assert.That(doc.RootElement.TryGetProperty("channels", out _), Is.False);
            Assert.That(doc.RootElement.TryGetProperty("reference_source", out _), Is.False);
        }

        [Test]
        public void AudioEchoCancellation_RoundTrip()
        {
            var original = new AudioEchoCancellation
            {
                Channels = 4,
                ReferenceSource = EchoCancellationReferenceSource.Client,
            };

            // Verify serialized JSON has correct TypeSpec wire keys
            var json = TestUtilities.SerializeViaIJsonModel(original);
            using var doc = JsonDocument.Parse(json);
            Assert.That(doc.RootElement.GetProperty("reference_source").GetString(), Is.EqualTo("client"));
            Assert.That(doc.RootElement.GetProperty("channels").GetInt32(), Is.EqualTo(4));

            // Verify deserialization from known TypeSpec wire JSON
            var fromWire = TestUtilities.DeserializeViaIJsonModel(
                """{"reference_source":"client","channels":4}""",
                new AudioEchoCancellation());
            Assert.That(fromWire.ReferenceSource, Is.EqualTo(EchoCancellationReferenceSource.Client));
            Assert.That(fromWire.Channels, Is.EqualTo(4));
        }

        [Test]
        public void AudioEchoCancellation_RoundTrip_DefaultsRoundTripAsNull()
        {
            // Verify defaults omitted when serialized
            var json = TestUtilities.SerializeViaIJsonModel(new AudioEchoCancellation());
            using var doc = JsonDocument.Parse(json);
            Assert.That(doc.RootElement.TryGetProperty("channels", out _), Is.False);
            Assert.That(doc.RootElement.TryGetProperty("reference_source", out _), Is.False);

            // Verify deserialization from empty wire JSON yields null properties
            var fromWire = TestUtilities.DeserializeViaIJsonModel("{}", new AudioEchoCancellation());
            Assert.That(fromWire.Channels, Is.Null);
            Assert.That(fromWire.ReferenceSource, Is.Null);
        }
    }
}
