// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
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
                        + "\"data\": \"AQIDBAU=\","
                        + "\"timestamp\": \"2022-08-23T11:48:05Z\","
                        + "\"participantRawID\": \"participantId\","
                        + "\"mark\": {\"Id\": \"mark123\"},"
                        + "\"silent\": false"
                        + "}"
                        + "}";

            AudioData streamingAudio = (AudioData)StreamingData.Parse(audioJson);
            ValidateAudioData(streamingAudio);
        }

        [Test]
        public void ParseMarkData_Test()
        {
            string markJson = "{"
                + "\"kind\": \"MarkData\","
                + "\"markData\": {"
                + "\"id\": \"test\","
                + "\"status\": \"cancelled\""
                + "}"
                + "}";

            MarkData streamingAudio = (MarkData)StreamingData.Parse(markJson);
            ValidateMarkData(streamingAudio);
        }

        [Test]
        public void ParseMarkDataWithEmptyStatus_Test()
        {
            string markJson = "{"
                + "\"kind\": \"MarkData\","
                + "\"markData\": {"
                + "\"id\": \"test\""
                + "}"
                + "}";

            MarkData streamingAudio = (MarkData)StreamingData.Parse(markJson);
            ValidateMarkData(streamingAudio, true);
        }

        private static void ValidateAudioMetadata(AudioMetadata streamingAudioMetadata)
        {
            Assert.That(streamingAudioMetadata, Is.Not.Null);
            Assert.That(streamingAudioMetadata.MediaSubscriptionId, Is.EqualTo("subscriptionId"));
            Assert.That(streamingAudioMetadata.Encoding, Is.EqualTo("encodingType"));
            Assert.That(streamingAudioMetadata.SampleRate, Is.EqualTo(8));
            Assert.That((int)streamingAudioMetadata.Channels, Is.EqualTo(2));
            Assert.That(streamingAudioMetadata.Length, Is.EqualTo(640));
        }

        private static void ValidateAudioData(AudioData streamingAudio)
        {
            Assert.That(streamingAudio, Is.Not.Null);
            Assert.That(streamingAudio.Data, Is.EqualTo(Convert.FromBase64String("AQIDBAU=")));
            Assert.That(streamingAudio.Timestamp.Year, Is.EqualTo(2022));
            Assert.That(streamingAudio.Participant is CommunicationIdentifier, Is.True);
            Assert.That(streamingAudio.Participant.RawId, Is.EqualTo("participantId"));
            Assert.That(streamingAudio.Mark.Id, Is.EqualTo("mark123"));
            Assert.That(streamingAudio.IsSilent, Is.False);
        }
        private static void ValidateAudioDataNoParticipant(AudioData streamingAudio)
        {
            Assert.That(streamingAudio, Is.Not.Null);
            Assert.That(streamingAudio.Data, Is.EqualTo(Convert.FromBase64String("AQIDBAU=")));
            Assert.That(streamingAudio.Timestamp.Year, Is.EqualTo(2022));
            Assert.That(streamingAudio.Participant, Is.Null);
            Assert.That(streamingAudio.IsSilent, Is.False);
        }

        private static void ValidateMarkData(MarkData streamingAudio, bool emptyStatus = false)
        {
            Assert.That(streamingAudio, Is.Not.Null);
            Assert.That(streamingAudio.Id, Is.EqualTo("test"));
            if (!emptyStatus)
                Assert.That(streamingAudio.Status, Is.EqualTo(MarkStatus.Cancelled));
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
            Assert.That(transcriptionMetadata, Is.Not.Null);
            Assert.That(transcriptionMetadata.TranscriptionSubscriptionId, Is.EqualTo("subscriptionId"));
            Assert.That(transcriptionMetadata.Locale, Is.EqualTo("en-US"));
            Assert.That(transcriptionMetadata.CallConnectionId, Is.EqualTo("callConnectionId"));
            Assert.That(transcriptionMetadata.CorrelationId, Is.EqualTo("correlationId"));
        }

        private static void ValidateTranscriptionData(TranscriptionData transcription)
        {
            Assert.That(transcription, Is.Not.Null);
            Assert.That(transcription.Text, Is.EqualTo("Hello World!"));
            Assert.That(transcription.Format, Is.EqualTo(TextFormat.Display));
            Assert.That(transcription.Confidence, Is.EqualTo(0.98d));
            Assert.That(transcription.Offset, Is.EqualTo(1));
            Assert.That(transcription.Duration, Is.EqualTo(2));

            // validate individual words
            IList<WordData> words = transcription.Words.ToList();
            Assert.That(words.Count, Is.EqualTo(2));
            Assert.That(words[0].Text, Is.EqualTo("Hello"));
            Assert.That(words[0].Offset, Is.EqualTo(1));
            Assert.That(words[0].Duration, Is.EqualTo(1));
            Assert.That(words[1].Text, Is.EqualTo("World"));
            Assert.That(words[1].Offset, Is.EqualTo(6));
            Assert.That(words[1].Duration, Is.EqualTo(1));

            Assert.That(transcription.Participant is CommunicationIdentifier, Is.True);
            Assert.That(transcription.Participant.RawId, Is.EqualTo("abc12345"));
            Console.WriteLine(transcription.ResultStatus.ToString());
            Assert.That(transcription.ResultStatus, Is.EqualTo(ResultStatus.Final));
        }
        #endregion

        #region Transcription-StreamingDataParser

        [Test]
        public void ParseTranscriptionMetadata_DataParser_Test()
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

            TranscriptionMetadata streamingMetadata = (TranscriptionMetadata)StreamingDataParser.Parse(metadataJson);
            ValidateTranscriptionMetadata(streamingMetadata);
        }

        [Test]
        public void ParseTranscriptionData_DataParser_Test()
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

            TranscriptionData transcription = (TranscriptionData)StreamingDataParser.Parse(transcriptionJson);
            ValidateTranscriptionData(transcription);
        }

        [Test]
        public void ParseTranscriptionBinaryData()
        {
            JObject jsonData = new()
            {
                ["kind"] = "TranscriptionData",
                ["transcriptionData"] = new JObject()
            };
            jsonData["transcriptionData"]!["text"] = "Hello World!";
            jsonData["transcriptionData"]!["format"] = "display";
            jsonData["transcriptionData"]!["confidence"] = 0.98d;
            jsonData["transcriptionData"]!["offset"] = 1;
            jsonData["transcriptionData"]!["duration"] = 2;

            JArray words = new();
            jsonData["transcriptionData"]!["words"] = words;

            JObject word0 = new()
            {
                ["text"] = "Hello",
                ["offset"] = 1,
                ["duration"] = 1
            };
            words.Add(word0);

            JObject word1 = new()
            {
                ["text"] = "World",
                ["offset"] = 6,
                ["duration"] = 1
            };
            words.Add(word1);

            jsonData["transcriptionData"]!["participantRawID"] = "abc12345";
            jsonData["transcriptionData"]!["resultStatus"] = "final";

            var binaryData = BinaryData.FromString(jsonData.ToString());

            TranscriptionData transcription = (TranscriptionData)StreamingDataParser.Parse(binaryData);
            ValidateTranscriptionData(transcription);
        }

        [Test]
        public void ParseTranscriptionDataEventsWithBinaryArray()
        {
            JObject jsonData = new()
            {
                ["kind"] = "TranscriptionData",
                ["transcriptionData"] = new JObject()
            };
            jsonData["transcriptionData"]!["text"] = "Hello World!";
            jsonData["transcriptionData"]!["format"] = "display";
            jsonData["transcriptionData"]!["confidence"] = 0.98d;
            jsonData["transcriptionData"]!["offset"] = 1;
            jsonData["transcriptionData"]!["duration"] = 2;

            JArray words = new();
            jsonData["transcriptionData"]!["words"] = words;

            JObject word0 = new()
            {
                ["text"] = "Hello",
                ["offset"] = 1,
                ["duration"] = 1
            };
            words.Add(word0);

            JObject word1 = new()
            {
                ["text"] = "World",
                ["offset"] = 6,
                ["duration"] = 1
            };
            words.Add(word1);

            jsonData["transcriptionData"]!["participantRawID"] = "abc12345";
            jsonData["transcriptionData"]!["resultStatus"] = "final";

            byte[] receivedBytes = System.Text.Encoding.UTF8.GetBytes(jsonData.ToString());
            TranscriptionData parsedPackage = (TranscriptionData)StreamingDataParser.Parse(receivedBytes);

            Assert.That(parsedPackage, Is.Not.Null);
            ValidateTranscriptionData(parsedPackage);
        }
        #endregion
    }
}