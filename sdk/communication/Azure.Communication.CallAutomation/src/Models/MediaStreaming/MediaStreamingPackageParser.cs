// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Text.Json;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Parser of the different packages received as part of
    /// Media streaming.
    /// </summary>
    public static class MediaStreamingPackageParser
    {
        /// <summary>
        /// Parsing a MediaStreaming package from BinaryData.
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static MediaStreamingPackageBase Parse(BinaryData json)
        {
            return Parse(json.ToString());
        }

        /// <summary>
        /// Parsing a MediaStreaming package from a byte array.
        /// </summary>
        /// <param name="receivedBytes">a UTF8 byte array.</param>
        /// <returns></returns>
        public static MediaStreamingPackageBase Parse(byte[] receivedBytes)
        {
            return Parse(Encoding.UTF8.GetString(receivedBytes));
        }

        /// <summary>
        /// Parse the incoming package.
        /// </summary>
        /// <param name="stringJson"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static MediaStreamingPackageBase Parse(string stringJson)
        {
            JsonElement package = JsonDocument.Parse(stringJson).RootElement;
            if (package.GetProperty("kind").ToString() == "AudioMetadata")
            {
                return JsonSerializer.Deserialize<MediaStreamingMetadata>(package.GetProperty("audioMetadata").ToString());
            }
            else if (package.GetProperty("kind").ToString() == "AudioData")
            {
                MediaStreamingAudioDataInternal audioInternal = JsonSerializer.Deserialize<MediaStreamingAudioDataInternal>(package.GetProperty("audioData").ToString());
                return new MediaStreamingAudioData(
                    audioInternal.Data, audioInternal.Timestamp, audioInternal.ParticipantRawId, audioInternal.Silent);
            }
            else
                throw new NotSupportedException(stringJson);
        }
    }
}
