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

            Assert.That(parsedPackage, Is.Not.Null);
            ValidateAudioData(parsedPackage);
        }

        private static void ValidateMetadata(MediaStreamingMetadata streamingMetadata)
        {
            Assert.That(streamingMetadata, Is.Not.Null);
            Assert.That(streamingMetadata.MediaSubscriptionId, Is.EqualTo("subscriptionId"));

            ValidateFormat(streamingMetadata.Format);
        }

        private static void ValidateFormat(MediaStreamingFormat streamingFormat)
        {
            Assert.That(streamingFormat, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(streamingFormat.Encoding, Is.EqualTo("encodingType"));
                Assert.That(streamingFormat.SampleRate, Is.EqualTo(8));
                Assert.That(streamingFormat.Channels, Is.EqualTo(2));
                Assert.That(streamingFormat.Length, Is.EqualTo(100.1));
            });
        }

        private static void ValidateAudioData(MediaStreamingAudio streamingAudio)
        {
            Assert.That(streamingAudio, Is.Not.Null);
            Assert.Multiple(() =>
            {
                Assert.That(streamingAudio.Data.Length, Is.EqualTo(5));
                Assert.That(streamingAudio.Timestamp.Year, Is.EqualTo(2022));
                Assert.That(streamingAudio.Participant is CommunicationIdentifier, Is.True);
                Assert.That(streamingAudio.Participant.RawId, Is.EqualTo("participantId"));
                Assert.That(streamingAudio.IsSilent, Is.False);
            });
        }
    }
}
