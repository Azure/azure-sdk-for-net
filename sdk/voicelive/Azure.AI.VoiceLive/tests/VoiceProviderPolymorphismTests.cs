// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
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
