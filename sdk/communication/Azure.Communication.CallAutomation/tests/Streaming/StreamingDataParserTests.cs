﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Azure.Communication.CallAutomation.Tests.MediaStreaming
{
    internal class StreamingDataParserTests
    {
        #region Audio
        [Test]
        public void ParseAudioMetadata_Test()
        {
            string metadataJson = "{"
                + "\"kind\": \"AudioMetadata\","
                + "\"audioMetadata\": {"
                + "\"subscriptionId\": \"subscriptionId\","
                + "\"encoding\": \"encodingType\","
                + "\"sampleRate\": 8,"
                + "\"channels\": 2,"
                + "\"length\": 640"
                + "}"
                + "}";

            AudioMetadata streamingMetadata = (AudioMetadata)StreamingData.Parse(metadataJson);
            ValidateAudioMetadata(streamingMetadata);
        }

        [Test]
        public void ParseAudioData_Test()
        {
            string audioJson = "{"
                + "\"kind\": \"AudioData\","
                + "\"audioData\": {"
                + "\"data\": \"AQIDBAU=\","      // [1, 2, 3, 4, 5]
                + "\"timestamp\": \"2022-08-23T11:48:05Z\","
                + "\"participantRawID\": \"participantId\","
                + "\"silent\": false"
                + "}"
                + "}";

            AudioData streamingAudio = (AudioData)StreamingData.Parse(audioJson);
            ValidateAudioData(streamingAudio);
        }

        private static void ValidateAudioMetadata(AudioMetadata streamingAudioMetadata)
        {
            Assert.IsNotNull(streamingAudioMetadata);
            Assert.AreEqual("subscriptionId", streamingAudioMetadata.MediaSubscriptionId);
            Assert.AreEqual("encodingType", streamingAudioMetadata.Encoding);
            Assert.AreEqual(8, streamingAudioMetadata.SampleRate);
            Assert.AreEqual(2, (int)streamingAudioMetadata.Channels);
            Assert.AreEqual(640, streamingAudioMetadata.Length);
        }

        private static void ValidateAudioData(AudioData streamingAudio)
        {
            Assert.IsNotNull(streamingAudio);
            Assert.AreEqual(Convert.FromBase64String("AQIDBAU="), streamingAudio.Data);
            Assert.AreEqual(2022, streamingAudio.Timestamp.Year);
            Assert.IsTrue(streamingAudio.Participant is CommunicationIdentifier);
            Assert.AreEqual("participantId", streamingAudio.Participant.RawId);
            Assert.IsFalse(streamingAudio.IsSilent);
        }
        private static void ValidateAudioDataNoParticipant(AudioData streamingAudio)
        {
            Assert.IsNotNull(streamingAudio);
            Assert.AreEqual(Convert.FromBase64String("AQIDBAU="), streamingAudio.Data);
            Assert.AreEqual(2022, streamingAudio.Timestamp.Year);
            Assert.IsNull(streamingAudio.Participant);
            Assert.IsFalse(streamingAudio.IsSilent);
        }
        #endregion

        #region Transcription

        [Test]
        public void ParseTranscriptionMetadata_Test()
        {
            var metadataJson =
            "{" +
                "\"kind\":\"TranscriptionMetadata\"," +
                "\"transcriptionMetadata\":" +
                "{" +
                    "\"subscriptionId\":\"subscriptionId\"," +
                    "\"locale\":\"en-US\"," +
                    "\"callConnectionId\":\"callConnectionId\"," +
                    "\"correlationId\":\"correlationId\"" +
                "}" +
            "}";

            TranscriptionMetadata streamingMetadata = (TranscriptionMetadata)StreamingData.Parse(metadataJson);
            ValidateTranscriptionMetadata(streamingMetadata);
        }

        [Test]
        public void ParseTranscriptionData_Test()
        {
            var transcriptionJson =
            "{" +
                "\"kind\":\"TranscriptionData\"," +
                "\"transcriptionData\":" +
                "{" +
                    "\"text\":\"Hello World!\"," +
                    "\"format\":\"display\"," +
                    "\"confidence\":0.98," +
                    "\"offset\":1," +
                    "\"duration\":2," +
                    "\"words\":" +
                    "[" +
                        "{" +
                            "\"text\":\"Hello\"," +
                            "\"offset\":1," +
                            "\"duration\":1" +
                        "}," +
                        "{" +
                            "\"text\":\"World\"," +
                            "\"offset\":6," +
                            "\"duration\":1" +
                        "}" +
                    "]," +
                    "\"participantRawID\":\"abc12345\"," +
                    "\"resultStatus\":\"final\"" +
                "}" +
            "}";

            TranscriptionData transcription = (TranscriptionData)StreamingData.Parse(transcriptionJson);
            ValidateTranscriptionData(transcription);
        }

        private static void ValidateTranscriptionMetadata(TranscriptionMetadata transcriptionMetadata)
        {
            Assert.IsNotNull(transcriptionMetadata);
            Assert.AreEqual("subscriptionId", transcriptionMetadata.TranscriptionSubscriptionId);
            Assert.AreEqual("en-US", transcriptionMetadata.Locale);
            Assert.AreEqual("callConnectionId", transcriptionMetadata.CallConnectionId);
            Assert.AreEqual("correlationId", transcriptionMetadata.CorrelationId);
        }

        private static void ValidateTranscriptionData(TranscriptionData transcription)
        {
            Assert.IsNotNull(transcription);
            Assert.AreEqual("Hello World!", transcription.Text);
            Assert.AreEqual(TextFormat.Display, transcription.Format);
            Assert.AreEqual(0.98d, transcription.Confidence);
            Assert.AreEqual(1, transcription.Offset.Ticks);
            Assert.AreEqual(2, transcription.Duration.Ticks);

            // validate individual words
            IList<WordData> words = transcription.Words.ToList();
            Assert.AreEqual(2, words.Count);
            Assert.AreEqual("Hello", words[0].Text);
            Assert.AreEqual(1, words[0].Offset.Ticks);
            Assert.AreEqual(1, words[0].Duration.Ticks);
            Assert.AreEqual("World", words[1].Text);
            Assert.AreEqual(6, words[1].Offset.Ticks);
            Assert.AreEqual(1, words[1].Duration.Ticks);

            Assert.IsTrue(transcription.Participant is CommunicationIdentifier);
            Assert.AreEqual("abc12345", transcription.Participant.RawId);
            Console.WriteLine(transcription.ResultState.ToString());
            Assert.AreEqual(TranscriptionResultState.Final, transcription.ResultState);
        }
        #endregion
    }
}
