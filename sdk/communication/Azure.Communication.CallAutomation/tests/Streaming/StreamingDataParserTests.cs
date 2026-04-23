// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using NUnit.Framework.Legacy;

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
            ClassicAssert.IsNotNull(streamingAudioMetadata);
            ClassicAssert.AreEqual("subscriptionId", streamingAudioMetadata.MediaSubscriptionId);
            ClassicAssert.AreEqual("encodingType", streamingAudioMetadata.Encoding);
            ClassicAssert.AreEqual(8, streamingAudioMetadata.SampleRate);
            ClassicAssert.AreEqual(2, (int)streamingAudioMetadata.Channels);
        }

        private static void ValidateAudioData(AudioData streamingAudio)
        {
            ClassicAssert.IsNotNull(streamingAudio);
            CollectionAssert.AreEqual(Convert.FromBase64String("AQIDBAU="), streamingAudio.Data.ToArray());
            ClassicAssert.AreEqual(2022, streamingAudio.Timestamp.Year);
            ClassicAssert.IsTrue(streamingAudio.Participant is CommunicationIdentifier);
            ClassicAssert.AreEqual("participantId", streamingAudio.Participant.RawId);
            ClassicAssert.IsFalse(streamingAudio.IsSilent);
        }
        #endregion

        #region DTMF
        [Test]
        public void ParseDtmfData_Test()
        {
            string dtmfJson = "{"
                + "\"kind\": \"DtmfData\","
                + "\"dtmfData\": {"
                + "\"data\": \"5\""
                + "}"
                + "}";

            DtmfData streamingDtmf = (DtmfData)StreamingData.Parse(dtmfJson);
            ValidateDtmfData(streamingDtmf);
        }
        private static void ValidateDtmfData(DtmfData streamingDtmf)
        {
            ClassicAssert.IsNotNull(streamingDtmf);
            ClassicAssert.AreEqual("5", streamingDtmf.Data);
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
                    "\"correlationId\":\"correlationId\"," +
                    "\"speechRecognitionModelEndpointId\":\"speechRecognitionModelEndpointId\"" +
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

        [Test]
        public void ParseTranscriptionDataWithWordsNull_Test()
        {
            var data = "{" +
                "\"kind\":\"TranscriptionData\"," +
                "\"transcriptionData\":" +
                "{\"text\":\"store hours\"," +
                "\"format\":\"display\"," +
                "\"offset\":49876484," +
                "\"duration\":9200000," +
                "\"participantRawID\":\"abc12345\"," +
                "\"resultStatus\":\"Intermediate\"}}";
            TranscriptionData transcription = (TranscriptionData)StreamingData.Parse(data);
            ValidateTranscriptionDataWithWordsNull(transcription);
        }

        private static void ValidateTranscriptionMetadata(TranscriptionMetadata transcriptionMetadata)
        {
            ClassicAssert.IsNotNull(transcriptionMetadata);
            ClassicAssert.AreEqual("subscriptionId", transcriptionMetadata.TranscriptionSubscriptionId);
            ClassicAssert.AreEqual("en-US", transcriptionMetadata.Locale);
            ClassicAssert.AreEqual("callConnectionId", transcriptionMetadata.CallConnectionId);
            ClassicAssert.AreEqual("correlationId", transcriptionMetadata.CorrelationId);
            ClassicAssert.AreEqual("speechRecognitionModelEndpointId", transcriptionMetadata.SpeechRecognitionModelEndpointId);
        }

        private static void ValidateTranscriptionDataWithWordsNull(TranscriptionData transcription)
        {
            ClassicAssert.IsNotNull(transcription);
            ClassicAssert.AreEqual("store hours", transcription.Text);
            ClassicAssert.AreEqual("display", transcription.Format);
            ClassicAssert.AreEqual(49876484, transcription.Offset.Ticks);
            ClassicAssert.AreEqual(9200000, transcription.Duration.Ticks);

            ClassicAssert.IsTrue(transcription.Participant is CommunicationIdentifier);
            ClassicAssert.AreEqual("abc12345", transcription.Participant.RawId);
            Console.WriteLine(transcription.ResultState.ToString());
            ClassicAssert.AreEqual(TranscriptionResultState.Intermediate, transcription.ResultState);
        }

        private static void ValidateTranscriptionData(TranscriptionData transcription)
        {
            ClassicAssert.IsNotNull(transcription);
            ClassicAssert.AreEqual("Hello World!", transcription.Text);
            ClassicAssert.AreEqual("display", transcription.Format);
            ClassicAssert.AreEqual(0.98d, transcription.Confidence);
            ClassicAssert.AreEqual(1, transcription.Offset.Ticks);
            ClassicAssert.AreEqual(2, transcription.Duration.Ticks);

            // validate individual words
            IList<WordData> words = transcription.Words.ToList();
            ClassicAssert.AreEqual(2, words.Count);
            ClassicAssert.AreEqual("Hello", words[0].Text);
            ClassicAssert.AreEqual(1, words[0].Offset.Ticks);
            ClassicAssert.AreEqual(1, words[0].Duration.Ticks);
            ClassicAssert.AreEqual("World", words[1].Text);
            ClassicAssert.AreEqual(6, words[1].Offset.Ticks);
            ClassicAssert.AreEqual(1, words[1].Duration.Ticks);

            ClassicAssert.IsTrue(transcription.Participant is CommunicationIdentifier);
            ClassicAssert.AreEqual("abc12345", transcription.Participant.RawId);
            Console.WriteLine(transcription.ResultState.ToString());
            ClassicAssert.AreEqual(TranscriptionResultState.Final, transcription.ResultState);
        }
        #endregion
    }
}
