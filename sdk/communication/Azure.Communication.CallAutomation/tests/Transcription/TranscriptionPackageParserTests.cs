// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using Azure.Communication.CallAutomation.Models.Transcription;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Azure.Communication.CallAutomation.Tests.Trascription
{
    internal class TranscriptionPackageParserTests
    {
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

            TranscriptionMetadata streamingMetadata = (TranscriptionMetadata)TranscriptionPackageParser.Parse(metadataJson);
            ValidateMetadata(streamingMetadata);
        }

        [Test]
        public void ParseTranscription_Test()
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
                    "\"words\":" +
                    "[" +
                        "{" +
                            "\"text\":\"Hello\"," +
                            "\"offset\":1" +
                        "}," +
                        "{" +
                            "\"text\":\"World\"," +
                            "\"offset\":6" +
                        "}" +
                    "]," +
                    "\"participantRawID\":\"abc12345\"," +
                    "\"resultStatus\":\"final\"" +
                "}" +
            "}";

            TranscriptionData transcription = (TranscriptionData) TranscriptionPackageParser.Parse(transcriptionJson);
            ValidateTranscriptionData(transcription);
        }

        [Test]
        public void ParseBinaryData()
        {
            JObject jsonData = new()
            {
                ["kind"] = "TranscriptionData",
                ["transcriptionData"] = new JObject()
            };
            jsonData["transcriptionData"]["text"] = "Hello World!";
            jsonData["transcriptionData"]["format"] = "display";
            jsonData["transcriptionData"]["confidence"] = 0.98d;
            jsonData["transcriptionData"]["offset"] = 1;

            JArray words = new();
            jsonData["transcriptionData"]["words"] = words;

            JObject word0 = new()
            {
                ["text"] = "Hello",
                ["offset"] = 1
            };
            words.Add(word0);

            JObject word1 = new()
            {
                ["text"] = "World",
                ["offset"] = 6
            };
            words.Add(word1);

            jsonData["transcriptionData"]["participantRawID"] = "abc12345";
            jsonData["transcriptionData"]["resultStatus"] = "final";

            var binaryData = BinaryData.FromString(jsonData.ToString());

            TranscriptionData transcription = (TranscriptionData)TranscriptionPackageParser.Parse(binaryData);
            ValidateTranscriptionData(transcription);
        }

        [Test]
        public void ParseAudioEventsWithBynaryArray()
        {
            JObject jsonData = new()
            {
                ["kind"] = "TranscriptionData",
                ["transcriptionData"] = new JObject()
            };
            jsonData["transcriptionData"]["text"] = "Hello World!";
            jsonData["transcriptionData"]["format"] = "display";
            jsonData["transcriptionData"]["confidence"] = 0.98d;
            jsonData["transcriptionData"]["offset"] = 1;

            JArray words = new();
            jsonData["transcriptionData"]["words"] = words;

            JObject word0 = new()
            {
                ["text"] = "Hello",
                ["offset"] = 1
            };
            words.Add(word0);

            JObject word1 = new()
            {
                ["text"] = "World",
                ["offset"] = 6
            };
            words.Add(word1);

            jsonData["transcriptionData"]["participantRawID"] = "abc12345";
            jsonData["transcriptionData"]["resultStatus"] = "final";

            byte[] receivedBytes = System.Text.Encoding.UTF8.GetBytes(jsonData.ToString());
            TranscriptionData parsedPackage = (TranscriptionData) TranscriptionPackageParser.Parse(receivedBytes);

            Assert.NotNull(parsedPackage);
            ValidateTranscriptionData(parsedPackage);
        }

        private static void ValidateMetadata(TranscriptionMetadata transcriptionMetadata)
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
            Assert.AreEqual(1, transcription.Offset);

            // validate individual words
            IList<WordData> words = transcription.Words.ToList();
            Assert.AreEqual(2, words.Count);
            Assert.AreEqual("Hello", words[0].Text);
            Assert.AreEqual(1, words[0].Offset);
            Assert.AreEqual("World", words[1].Text);
            Assert.AreEqual(6, words[1].Offset);

            Assert.IsTrue(transcription.Participant is CommunicationIdentifier);
            Assert.AreEqual("abc12345", transcription.Participant.RawId);
            Console.WriteLine(transcription.ResultStatus.ToString());
            Assert.AreEqual(ResultStatus.Final, transcription.ResultStatus);
        }
    }
}
