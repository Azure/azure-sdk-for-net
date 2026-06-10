// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.AI.VoiceLive.Tests.Infrastructure;
using NUnit.Framework;

namespace Azure.AI.VoiceLive.Tests
{
    [TestFixture]
    public class SmartEndOfTurnDetectionTests
    {
        [Test]
        public void SmartEndOfTurnDetection_SerializesWithCorrectDiscriminator()
        {
            var eou = new SmartEndOfTurnDetection
            {
                ThresholdLevel = EouThresholdLevel.High,
                TimeoutMs = 500,
            };

            var json = TestUtilities.SerializeViaIJsonModel(eou);
            using var doc = JsonDocument.Parse(json);

            Assert.That(doc.RootElement.GetProperty("model").GetString(), Is.EqualTo("smart_end_of_turn_detection"));
            Assert.That(doc.RootElement.GetProperty("threshold_level").GetString(), Is.EqualTo("high"));
            Assert.That(doc.RootElement.GetProperty("timeout_ms").GetInt32(), Is.EqualTo(500));
        }

        [Test]
        public void SmartEndOfTurnDetection_OptionalPropertiesOmittedWhenNull()
        {
            var eou = new SmartEndOfTurnDetection();
            var json = TestUtilities.SerializeViaIJsonModel(eou);
            using var doc = JsonDocument.Parse(json);

            Assert.That(doc.RootElement.GetProperty("model").GetString(), Is.EqualTo("smart_end_of_turn_detection"));
            Assert.That(doc.RootElement.TryGetProperty("threshold_level", out _), Is.False);
            Assert.That(doc.RootElement.TryGetProperty("timeout_ms", out _), Is.False);
        }

        [Test]
        public void SmartEndOfTurnDetection_Polymorphic_DeserializesFromJson()
        {
            var eou = TestUtilities.DeserializeViaIJsonModel<EouDetection>(
                """{"model":"smart_end_of_turn_detection","threshold_level":"medium","timeout_ms":800}""",
                new SmartEndOfTurnDetection());

            Assert.That(eou, Is.TypeOf<SmartEndOfTurnDetection>());
            var smart = (SmartEndOfTurnDetection)eou;
            Assert.That(smart.ThresholdLevel, Is.EqualTo(EouThresholdLevel.Medium));
            Assert.That(smart.TimeoutMs, Is.EqualTo(800));
        }

        [Test]
        public void SmartEndOfTurnDetection_RoundTrip()
        {
            var original = new SmartEndOfTurnDetection
            {
                ThresholdLevel = EouThresholdLevel.High,
                TimeoutMs = 1500,
            };

            // Verify serialized JSON has correct TypeSpec wire keys
            var json = TestUtilities.SerializeViaIJsonModel(original);
            using var doc = JsonDocument.Parse(json);
            Assert.That(doc.RootElement.GetProperty("model").GetString(), Is.EqualTo("smart_end_of_turn_detection"));
            Assert.That(doc.RootElement.GetProperty("threshold_level").GetString(), Is.EqualTo("high"));
            Assert.That(doc.RootElement.GetProperty("timeout_ms").GetInt32(), Is.EqualTo(1500));

            // Verify deserialization from known TypeSpec wire JSON
            var fromWire = TestUtilities.DeserializeViaIJsonModel<EouDetection>(
                """{"model":"smart_end_of_turn_detection","threshold_level":"high","timeout_ms":1500}""",
                new SmartEndOfTurnDetection());
            Assert.That(fromWire, Is.TypeOf<SmartEndOfTurnDetection>());
            var smart = (SmartEndOfTurnDetection)fromWire;
            Assert.That(smart.ThresholdLevel, Is.EqualTo(EouThresholdLevel.High));
            Assert.That(smart.TimeoutMs, Is.EqualTo(1500));
        }
    }
}
