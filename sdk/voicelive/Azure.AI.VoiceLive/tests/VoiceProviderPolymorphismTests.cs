// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.AI.VoiceLive.Tests.Infrastructure;
using NUnit.Framework;

namespace Azure.AI.VoiceLive.Tests
{
    [TestFixture]
    public class VoiceProviderPolymorphismTests
    {
        [TestCaseSource(nameof(SessionVoicePayloadCases))]
        public void SessionOptionsVoice_DeserializesToExpectedProviderType(string json, Type expectedType)
        {
            var options = TestUtilities.DeserializeViaIJsonModel(json, new VoiceLiveSessionOptions());
            Assert.That(options.Voice, Is.TypeOf(expectedType));
        }

        [TestCaseSource(nameof(SessionVoiceRoundTripCases))]
        public void SessionOptionsVoice_RoundTripsForAllProviderTypes(VoiceProvider originalVoice, Type expectedType)
        {
            var options = new VoiceLiveSessionOptions { Voice = originalVoice };

            var json = TestUtilities.SerializeViaIJsonModel(options);
            var fromWire = TestUtilities.DeserializeViaIJsonModel(json, new VoiceLiveSessionOptions());

            Assert.That(fromWire.Voice, Is.TypeOf(expectedType));

            switch (fromWire.Voice)
            {
                case OpenAIVoice openAi:
                    Assert.That(openAi.Name, Is.EqualTo(((OpenAIVoice)originalVoice).Name));
                    break;
                case AzureStandardVoice standard:
                    Assert.That(standard.Name, Is.EqualTo(((AzureStandardVoice)originalVoice).Name));
                    break;
                case AzureCustomVoice custom:
                    Assert.That(custom.Name, Is.EqualTo(((AzureCustomVoice)originalVoice).Name));
                    Assert.That(custom.EndpointId, Is.EqualTo(((AzureCustomVoice)originalVoice).EndpointId));
                    break;
                case AzurePersonalVoice personal:
                    Assert.That(personal.Name, Is.EqualTo(((AzurePersonalVoice)originalVoice).Name));
                    Assert.That(personal.Model, Is.EqualTo(((AzurePersonalVoice)originalVoice).Model));
                    break;
                case AzureAvatarSyncVoice avatarSync:
                    Assert.That(avatarSync.Model, Is.EqualTo(((AzureAvatarSyncVoice)originalVoice).Model));
                    break;
                case AzureRealtimeNativeVoice native:
                    Assert.That(native.Name, Is.EqualTo(((AzureRealtimeNativeVoice)originalVoice).Name));
                    break;
                default:
                    Assert.Fail($"Unexpected voice type {fromWire.Voice?.GetType().Name}");
                    break;
            }
        }

        [TestCaseSource(nameof(SessionVoicePayloadCases))]
        public void SessionResponseVoice_DeserializesToExpectedProviderType(string sessionOptionsPayload, Type expectedType)
        {
            string voicePayload = ExtractVoicePayload(sessionOptionsPayload);
            string responseJson = "{\"id\":\"resp-1\",\"object\":\"realtime.response\",\"voice\":" + voicePayload + "}";

            var response = TestUtilities.DeserializeViaIJsonModel(responseJson, new SessionResponse());

            Assert.That(response.Voice, Is.TypeOf(expectedType));
        }

        [TestCaseSource(nameof(SessionVoicePayloadCases))]
        public void VoiceLiveSessionResponseVoice_DeserializesToExpectedProviderType(string sessionOptionsPayload, Type expectedType)
        {
            string voicePayload = ExtractVoicePayload(sessionOptionsPayload);
            string responseJson = "{\"voice\":" + voicePayload + "}";

            var response = TestUtilities.DeserializeViaIJsonModel(responseJson, new VoiceLiveSessionResponse());

            Assert.That(response.Voice, Is.TypeOf(expectedType));
        }

        private static IEnumerable<TestCaseData> SessionVoiceRoundTripCases()
        {
            yield return new TestCaseData(new OpenAIVoice(OAIVoice.Alloy), typeof(OpenAIVoice))
                .SetName("SessionOptionsVoice_OpenAI_RoundTrips");

            yield return new TestCaseData(new AzureStandardVoice("en-US-AvaNeural"), typeof(AzureStandardVoice))
                .SetName("SessionOptionsVoice_AzureStandard_RoundTrips");

            yield return new TestCaseData(new AzureCustomVoice("my-custom-voice", "my-endpoint"), typeof(AzureCustomVoice))
                .SetName("SessionOptionsVoice_AzureCustom_RoundTrips");

            yield return new TestCaseData(new AzurePersonalVoice("my-personal-voice", PersonalVoiceModels.DragonLatestNeural), typeof(AzurePersonalVoice))
                .SetName("SessionOptionsVoice_AzurePersonal_RoundTrips");

            yield return new TestCaseData(new AzureAvatarSyncVoice(PersonalVoiceModels.DragonLatestNeural), typeof(AzureAvatarSyncVoice))
                .SetName("SessionOptionsVoice_AvatarVoiceSync_RoundTrips");

            yield return new TestCaseData(new AzureRealtimeNativeVoice(AzureRealtimeNativeVoiceName.Ava), typeof(AzureRealtimeNativeVoice))
                .SetName("SessionOptionsVoice_AzureRealtimeNative_RoundTrips");
        }

        private static string ExtractVoicePayload(string sessionOptionsPayload)
        {
            using var document = JsonDocument.Parse(sessionOptionsPayload);
            return document.RootElement.GetProperty("voice").GetRawText();
        }

        private static IEnumerable<TestCaseData> SessionVoicePayloadCases()
        {
            string openAiName = OAIVoice.Alloy.ToString();
            string personalModel = PersonalVoiceModels.DragonLatestNeural.ToString();

            yield return new TestCaseData(
                "{\"voice\":{\"type\":\"openai\",\"name\":\"" + openAiName + "\"}}",
                typeof(OpenAIVoice))
                .SetName("SessionOptionsVoice_OpenAI_Deserializes");

            yield return new TestCaseData(
                """
                {"voice":{"type":"azure-standard","name":"en-US-AvaNeural"}}
                """,
                typeof(AzureStandardVoice))
                .SetName("SessionOptionsVoice_AzureStandard_Deserializes");

            yield return new TestCaseData(
                """
                {"voice":{"type":"azure-custom","name":"my-custom-voice","endpoint_id":"my-endpoint"}}
                """,
                typeof(AzureCustomVoice))
                .SetName("SessionOptionsVoice_AzureCustom_Deserializes");

            yield return new TestCaseData(
                "{\"voice\":{\"type\":\"azure-personal\",\"name\":\"my-personal-voice\",\"model\":\"" + personalModel + "\"}}",
                typeof(AzurePersonalVoice))
                .SetName("SessionOptionsVoice_AzurePersonal_Deserializes");

            yield return new TestCaseData(
                "{\"voice\":{\"type\":\"avatar-voice-sync\",\"model\":\"" + personalModel + "\"}}",
                typeof(AzureAvatarSyncVoice))
                .SetName("SessionOptionsVoice_AvatarVoiceSync_Deserializes");

            yield return new TestCaseData(
                """
                {"voice":{"type":"azure-realtime-native","name":"ava"}}
                """,
                typeof(AzureRealtimeNativeVoice))
                .SetName("SessionOptionsVoice_AzureRealtimeNative_Deserializes");
        }
    }
}
