// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Communication.CallAutomation.Models.MediaStreaming;
using Newtonsoft.Json.Linq;
using NUnit.Framework;

namespace Azure.Communication.CallAutomation.Tests.MediaStreaming
{
    internal class CallAutomationStreamingParserTests
    {
        [Test]
        public void ParseMetadata_Test()
        {
            string metadataJson = "{"
                + "\"kind\": \"AudioMetadata\","
                + "\"subscriptionId\": \"subscriptionId\","
                + "\"encoding\": \"encodingType\","
                + "\"sampleRate\": 8,"
                + "\"channels\": 2,"
                + "\"length\": 640"
                + "}";

            MediaStreamingMetadata streamingMetadata = (MediaStreamingMetadata)MediaStreamingPackageParser.Parse(metadataJson);
            ValidateMetadata(streamingMetadata);
        }

        [Test]
        public void ParseAudio_Test()
        {
            string audioJson = "{"
                + "\"kind\": \"AudioData\","
                + "\"data\": \"AQIDBAU=\","      // [1, 2, 3, 4, 5]
                + "\"timestamp\": \"2022-08-23T11:48:05Z\","
                + "\"participantRawId\": \"participantId\","
                + "\"silent\": false"
                + "}";

            MediaStreamingAudio streamingAudio = (MediaStreamingAudio) MediaStreamingPackageParser.Parse(audioJson);
            ValidateAudioData(streamingAudio);
        }

        [Test]
        public void ParseBinaryData()
        {
            JObject jsonData = new JObject();
            jsonData["kind"] = "AudioData";
            jsonData["data"] = "AQIDBAU=";
            jsonData["timestamp"] = "2022-08-23T11:48:05Z";
            jsonData["participantRawId"] = "participantId";
            jsonData["silent"] = false;

            var binaryData = BinaryData.FromString(jsonData.ToString());

            MediaStreamingAudio streamingAudio = (MediaStreamingAudio)MediaStreamingPackageParser.Parse(binaryData);
            ValidateAudioData(streamingAudio);
        }

        [Test]
        public void ParseAudioEventsWithBynaryArray()
        {
            JObject jsonAudio = new JObject();
            jsonAudio["kind"] = "AudioData";
            jsonAudio["data"] = "AQIDBAU=";
            jsonAudio["timestamp"] = "2022-08-23T11:48:05Z";
            jsonAudio["participantRawId"] = "participantId";
            jsonAudio["silent"] = false;

            byte[] receivedBytes = System.Text.Encoding.UTF8.GetBytes(jsonAudio.ToString());
            MediaStreamingAudio parsedPackage = (MediaStreamingAudio) MediaStreamingPackageParser.Parse(receivedBytes);

            Assert.NotNull(parsedPackage);
            ValidateAudioData(parsedPackage);
        }

        private static void ValidateMetadata(MediaStreamingMetadata streamingMetadata)
        {
            Assert.IsNotNull(streamingMetadata);
            Assert.AreEqual("subscriptionId", streamingMetadata.MediaSubscriptionId);
            Assert.AreEqual("encodingType", streamingMetadata.Encoding);
            Assert.AreEqual(8, streamingMetadata.SampleRate);
            Assert.AreEqual(2, streamingMetadata.Channels);
            Assert.AreEqual(640, streamingMetadata.Length);
        }

        private static void ValidateAudioData(MediaStreamingAudio streamingAudio)
        {
            Assert.IsNotNull(streamingAudio);
            Assert.AreEqual("AQIDBAU=", streamingAudio.Data);
            Assert.AreEqual(2022, streamingAudio.Timestamp.Year);
            Assert.IsTrue(streamingAudio.Participant is CommunicationIdentifier);
            Assert.AreEqual("participantId", streamingAudio.Participant.RawId);
            Assert.IsFalse(streamingAudio.IsSilent);
        }
    }
}
