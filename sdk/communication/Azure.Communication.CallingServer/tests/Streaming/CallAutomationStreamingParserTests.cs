// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Communication.CallingServer.Models.Streaming;
using NUnit.Framework;

namespace Azure.Communication.CallingServer.Tests.Streaming
{
    internal class CallAutomationStreamingParserTests
    {
        private const string FormatJson = "{"
                + "\"encoding\": \"encodingType\","
                + "\"sampleRate\": 8,"
                + "\"channels\": 2,"
                + "\"length\": 100.1"
                + "}";

        [Test]
        public void ParseFormat_Test()
        {
            MediaStreamingFormat? streamingFormat = JsonSerializer.Deserialize<MediaStreamingFormat>(FormatJson);
            ValidateFormat(streamingFormat);
        }

        [Test]
        public void ParseMetadata_Test()
        {
            string metadataJson = "{{"
                + "\"subscriptionId\": \"subscriptionId\","
                + "\"format\": {0}"
                + "}}";

            MediaStreamingMetadata? streamingMetadata = JsonSerializer.Deserialize<MediaStreamingMetadata>(string.Format(metadataJson, FormatJson));
            Assert.IsNotNull(streamingMetadata);
            Assert.AreEqual("subscriptionId", streamingMetadata?.SubscriptionId);

            ValidateFormat(streamingMetadata?.Format);
        }

        private static void ValidateFormat(MediaStreamingFormat? streamingFormat)
        {
            Assert.IsNotNull(streamingFormat);
            Assert.AreEqual("encodingType", streamingFormat?.Encoding);
            Assert.AreEqual(8, streamingFormat?.SampleRate);
            Assert.AreEqual(2, streamingFormat?.Channels);
            Assert.AreEqual(100.1, streamingFormat?.Length);
        }

        [Test]
        public void ParseAudio_Test()
        {
            string audioJson = "{"
                + "\"data\": \"AQIDBAU=\","      // [1, 2, 3, 4, 5]
                + "\"timestamp\": \"2022-08-23T11:48:05Z\","
                + "\"participantId\": \"participantId\","
                + "\"isSilence\": false"
                + "}";

            MediaStreamingAudio? streamingAudio = JsonSerializer.Deserialize<MediaStreamingAudio>(audioJson);
            Assert.IsNotNull(streamingAudio);
            Assert.AreEqual(5, streamingAudio?.Data.Length);
            Assert.AreEqual(2022, streamingAudio?.Timestamp.Year);
            Assert.AreEqual("participantId", streamingAudio?.ParticipantId);
            Assert.IsFalse(streamingAudio?.IsSilence);
        }
    }
}
