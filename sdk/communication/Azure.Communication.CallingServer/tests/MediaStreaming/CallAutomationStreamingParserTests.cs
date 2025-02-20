// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Azure.Communication.CallingServer.Tests.MediaStreaming
{
    internal class CallAutomationStreamingParserTests
    {
        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void ParseMetadata_Test()
        {
            string metadataJson = "{"
                + "\"subscriptionId\": \"subscriptionId\","
                + "\"format\": {"
                + "\"encoding\": \"encodingType\","
                + "\"sampleRate\": 8,"
                + "\"channels\": 2,"
                + "\"length\": 100.1"
                + "}"
                + "}";

            MediaStreamingMetadata streamingMetadata = (MediaStreamingMetadata)MediaStreamingPackageParser.Parse(metadataJson);
            ValidateMetadata(streamingMetadata);
        }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void ParseAudio_Test()
        {
            string audioJson = "{"
                + "\"data\": \"AQIDBAU=\","      // [1, 2, 3, 4, 5]
                + "\"timestamp\": \"2022-08-23T11:48:05Z\","
                + "\"participantId\": \"participantId\","
                + "\"isSilence\": false"
                + "}";

            MediaStreamingAudio streamingAudio = (MediaStreamingAudio) MediaStreamingPackageParser.Parse(audioJson);
            ValidateAudioData(streamingAudio);
        }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void ParseBinaryData()
        {
            JObject jsonData = new JObject();
            jsonData["data"] = "AQIDBAU=";
            jsonData["timestamp"] = "2022-08-23T11:48:05Z";
            jsonData["participantId"] = "participantId";
            jsonData["isSilence"] = false;

            var binaryData = BinaryData.FromString(jsonData.ToString());

            MediaStreamingAudio streamingAudio = (MediaStreamingAudio)MediaStreamingPackageParser.Parse(binaryData);
            ValidateAudioData(streamingAudio);
        }

        [Test]
        [Ignore("Disabling this test as the library is flagged for decomissioning.")]
        public void ParseAudioEventsWithBynaryArray()
        {
            JObject jsonAudio = new JObject();
            jsonAudio["data"] = "AQIDBAU=";
            jsonAudio["timestamp"] = "2022-08-23T11:48:05Z";
            jsonAudio["participantId"] = "participantId";
            jsonAudio["isSilence"] = false;

            byte[] receivedBytes = System.Text.Encoding.UTF8.GetBytes(jsonAudio.ToString());
            MediaStreamingAudio parsedPackage = (MediaStreamingAudio) MediaStreamingPackageParser.Parse(receivedBytes);

            Assert.NotNull(parsedPackage);
            ValidateAudioData(parsedPackage);
        }

        private static void ValidateMetadata(MediaStreamingMetadata streamingMetadata)
        {
            Assert.IsNotNull(streamingMetadata);
            Assert.AreEqual("subscriptionId", streamingMetadata.MediaSubscriptionId);

            ValidateFormat(streamingMetadata.Format);
        }

        private static void ValidateFormat(MediaStreamingFormat streamingFormat)
        {
            Assert.IsNotNull(streamingFormat);
            Assert.AreEqual("encodingType", streamingFormat.Encoding);
            Assert.AreEqual(8, streamingFormat.SampleRate);
            Assert.AreEqual(2, streamingFormat.Channels);
            Assert.AreEqual(100.1, streamingFormat.Length);
        }

        private static void ValidateAudioData(MediaStreamingAudio streamingAudio)
        {
            Assert.IsNotNull(streamingAudio);
            Assert.AreEqual(5, streamingAudio.Data.Length);
            Assert.AreEqual(2022, streamingAudio.Timestamp.Year);
            Assert.IsTrue(streamingAudio.Participant is CommunicationIdentifier);
            Assert.AreEqual("participantId", streamingAudio.Participant.RawId);
            Assert.IsFalse(streamingAudio.IsSilent);
        }
    }
}
