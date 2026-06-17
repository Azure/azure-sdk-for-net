// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.AI.VoiceLive.Tests.Infrastructure;
using NUnit.Framework;

namespace Azure.AI.VoiceLive.Tests
{
    [TestFixture]
    public class AzureRealtimeNativeVoiceTests
    {
        [Test]
        public void AzureRealtimeNativeVoiceName_KnownValuesMatchExpectedStrings()
        {
            Assert.That(AzureRealtimeNativeVoiceName.Aarti.ToString(), Is.EqualTo("aarti"));
            Assert.That(AzureRealtimeNativeVoiceName.Andrew.ToString(), Is.EqualTo("andrew"));
            Assert.That(AzureRealtimeNativeVoiceName.Ava.ToString(), Is.EqualTo("ava"));
            Assert.That(AzureRealtimeNativeVoiceName.Xiaoxiao.ToString(), Is.EqualTo("xiaoxiao"));
            Assert.That(AzureRealtimeNativeVoiceName.Yunxi.ToString(), Is.EqualTo("yunxi"));
            Assert.That(AzureRealtimeNativeVoiceName.Ximena.ToString(), Is.EqualTo("ximena"));
        }

        [Test]
        public void AzureRealtimeNativeVoiceName_ImplicitConversionFromString()
        {
            AzureRealtimeNativeVoiceName name = "florian";
            Assert.That(name, Is.EqualTo(AzureRealtimeNativeVoiceName.Florian));
        }

        [Test]
        public void AzureRealtimeNativeVoiceName_UnknownValueRoundTrips()
        {
            AzureRealtimeNativeVoiceName unknown = "future-voice";
            Assert.That(unknown.ToString(), Is.EqualTo("future-voice"));
        }

        [Test]
        public void AzureRealtimeNativeVoice_SerializesWithCorrectTypeAndName()
        {
            var voice = new AzureRealtimeNativeVoice(AzureRealtimeNativeVoiceName.Ava);
            var json = TestUtilities.SerializeViaIJsonModel(voice);
            using var doc = JsonDocument.Parse(json);

            Assert.That(doc.RootElement.GetProperty("type").GetString(), Is.EqualTo("azure-realtime-native"));
            Assert.That(doc.RootElement.GetProperty("name").GetString(), Is.EqualTo("ava"));
        }

        [Test]
        public void AzureRealtimeNativeVoice_RoundTrip()
        {
            var original = new AzureRealtimeNativeVoice(AzureRealtimeNativeVoiceName.Andrew);

            // Verify serialized JSON has correct TypeSpec wire keys
            var json = TestUtilities.SerializeViaIJsonModel(original);
            using var doc = JsonDocument.Parse(json);
            Assert.That(doc.RootElement.GetProperty("type").GetString(), Is.EqualTo("azure-realtime-native"));
            Assert.That(doc.RootElement.GetProperty("name").GetString(), Is.EqualTo("andrew"));

            // Verify deserialization from known TypeSpec wire JSON
            var fromWire = TestUtilities.DeserializeViaIJsonModel(
                """{"type":"azure-realtime-native","name":"andrew"}""",
                new AzureRealtimeNativeVoice(AzureRealtimeNativeVoiceName.Ava));
            Assert.That(fromWire.Type, Is.EqualTo("azure-realtime-native"));
            Assert.That(fromWire.Name, Is.EqualTo(AzureRealtimeNativeVoiceName.Andrew));
        }
    }
}
