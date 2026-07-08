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
        public void AzureSemanticEouDetection_SerializesWithCorrectDiscriminator()
        {
            var eou = new AzureSemanticEouDetection
            {
                ThresholdLevel = EouThresholdLevel.High,
            };

            var json = TestUtilities.SerializeViaIJsonModel(eou);
            using var doc = JsonDocument.Parse(json);

            Assert.That(doc.RootElement.GetProperty("model").GetString(), Is.EqualTo("semantic_detection_v1"));
            Assert.That(doc.RootElement.GetProperty("threshold_level").GetString(), Is.EqualTo("high"));
        }

        [Test]
        public void AzureSemanticEouDetectionEn_UsesEnglishDiscriminator()
        {
            var eou = new AzureSemanticEouDetectionEn();
            var json = TestUtilities.SerializeViaIJsonModel(eou);
            using var doc = JsonDocument.Parse(json);

            Assert.That(doc.RootElement.GetProperty("model").GetString(), Is.EqualTo("semantic_detection_v1_en"));
        }

        [Test]
        public void AzureSemanticEouDetection_Polymorphic_DeserializesFromJson()
        {
            var eou = TestUtilities.DeserializeViaIJsonModel<EouDetection>(
                """{"model":"semantic_detection_v1","threshold_level":"medium"}""",
                new AzureSemanticEouDetection());

            Assert.That(eou, Is.TypeOf<AzureSemanticEouDetection>());
            var semantic = (AzureSemanticEouDetection)eou;
            Assert.That(semantic.ThresholdLevel, Is.EqualTo(EouThresholdLevel.Medium));
        }

        [Test]
        public void AzureSemanticEouDetectionMultilingual_UsesMultilingualDiscriminator()
        {
            var json = TestUtilities.SerializeViaIJsonModel(new AzureSemanticEouDetectionMultilingual());
            using var doc = JsonDocument.Parse(json);

            Assert.That(doc.RootElement.GetProperty("model").GetString(), Is.EqualTo("semantic_detection_v1_multilingual"));
        }
    }
}
