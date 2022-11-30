// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Text.Json;
using Azure.Communication.CallingServer.Models.MediaStreaming;

namespace Azure.Communication.CallingServer
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
            if (stringJson.Contains("format"))
            {
                MediaStreamingMetadataInternal metadataInternal = JsonSerializer.Deserialize<MediaStreamingMetadataInternal>(stringJson);
                MediaStreamingFormat mediaStreamingFormat = new MediaStreamingFormat(
                    metadataInternal.Format.Encoding, metadataInternal.Format.SampleRate, metadataInternal.Format.Channels, metadataInternal.Format.Length);
                return new MediaStreamingMetadata(metadataInternal.MediaSubscriptionId, mediaStreamingFormat);
            }
            else if (stringJson.Contains("data"))
            {
                MediaStreamingAudioInternal audioInternal = JsonSerializer.Deserialize<MediaStreamingAudioInternal>(stringJson);
                return new MediaStreamingAudio(
                    audioInternal.Data, audioInternal.Timestamp, audioInternal.ParticipantId, audioInternal.IsSilence);
            }
            else
                throw new NotSupportedException(stringJson);
        }
    }
}
