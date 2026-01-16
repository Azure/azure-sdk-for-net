// Copyright (c) Microsoft Corporation. All rights reserved.
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
            Assert.That(streamingAudioMetadata, Is.Not.Null);
            Assert.That(streamingAudioMetadata.MediaSubscriptionId, Is.EqualTo("subscriptionId"));
            Assert.That(streamingAudioMetadata.Encoding, Is.EqualTo("encodingType"));
            Assert.That(streamingAudioMetadata.SampleRate, Is.EqualTo(8));
            Assert.That((int)streamingAudioMetadata.Channels, Is.EqualTo(2));
        }

        private static void ValidateAudioData(AudioData streamingAudio)
        {
            Assert.That(streamingAudio, Is.Not.Null);
            Assert.That(streamingAudio.Data.ToArray(), Is.EqualTo(Convert.FromBase64String("AQIDBAU=")).AsCollection);
            Assert.That(streamingAudio.Timestamp.Year, Is.EqualTo(2022));
            Assert.That(streamingAudio.Participant is CommunicationIdentifier, Is.True);
            Assert.That(streamingAudio.Participant.RawId, Is.EqualTo("participantId"));
            Assert.That(streamingAudio.IsSilent, Is.False);
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
            Assert.That(streamingDtmf, Is.Not.Null);
            Assert.That(streamingDtmf.Data, Is.EqualTo("5"));
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
            Assert.That(transcriptionMetadata, Is.Not.Null);
            Assert.That(transcriptionMetadata.TranscriptionSubscriptionId, Is.EqualTo("subscriptionId"));
            Assert.That(transcriptionMetadata.Locale, Is.EqualTo("en-US"));
            Assert.That(transcriptionMetadata.CallConnectionId, Is.EqualTo("callConnectionId"));
            Assert.That(transcriptionMetadata.CorrelationId, Is.EqualTo("correlationId"));
            Assert.That(transcriptionMetadata.SpeechRecognitionModelEndpointId, Is.EqualTo("speechRecognitionModelEndpointId"));
        }

        private static void ValidateTranscriptionDataWithWordsNull(TranscriptionData transcription)
        {
            Assert.That(transcription, Is.Not.Null);
            Assert.That(transcription.Text, Is.EqualTo("store hours"));
            Assert.That(transcription.Format, Is.EqualTo("display"));
            Assert.That(transcription.Offset.Ticks, Is.EqualTo(49876484));
            Assert.That(transcription.Duration.Ticks, Is.EqualTo(9200000));

            Assert.That(transcription.Participant is CommunicationIdentifier, Is.True);
            Assert.That(transcription.Participant.RawId, Is.EqualTo("abc12345"));
            Console.WriteLine(transcription.ResultState.ToString());
            Assert.That(transcription.ResultState, Is.EqualTo(TranscriptionResultState.Intermediate));
        }

        private static void ValidateTranscriptionData(TranscriptionData transcription)
        {
            Assert.That(transcription, Is.Not.Null);
            Assert.That(transcription.Text, Is.EqualTo("Hello World!"));
            Assert.That(transcription.Format, Is.EqualTo("display"));
            Assert.That(transcription.Confidence, Is.EqualTo(0.98d));
            Assert.That(transcription.Offset.Ticks, Is.EqualTo(1));
            Assert.That(transcription.Duration.Ticks, Is.EqualTo(2));

            // validate individual words
            IList<WordData> words = transcription.Words.ToList();
            Assert.That(words.Count, Is.EqualTo(2));
            Assert.That(words[0].Text, Is.EqualTo("Hello"));
            Assert.That(words[0].Offset.Ticks, Is.EqualTo(1));
            Assert.That(words[0].Duration.Ticks, Is.EqualTo(1));
            Assert.That(words[1].Text, Is.EqualTo("World"));
            Assert.That(words[1].Offset.Ticks, Is.EqualTo(6));
            Assert.That(words[1].Duration.Ticks, Is.EqualTo(1));

            Assert.That(transcription.Participant is CommunicationIdentifier, Is.True);
            Assert.That(transcription.Participant.RawId, Is.EqualTo("abc12345"));
            Console.WriteLine(transcription.ResultState.ToString());
            Assert.That(transcription.ResultState, Is.EqualTo(TranscriptionResultState.Final));
        }
        #endregion
    }
}
