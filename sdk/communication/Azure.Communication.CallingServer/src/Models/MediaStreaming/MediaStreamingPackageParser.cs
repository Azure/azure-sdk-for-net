// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Communication.CallingServer.Models.MediaStreaming;
using Azure.Core;
using Azure.Messaging;

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
        /// Parsing Audio packages from BinaryData.
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static MediaStreamingPackageBase[] ParseMany(BinaryData json)
        {
            Argument.AssertNotNull(json, nameof(json));

            MediaStreamingPackageBase[] packages = null;
            JsonDocument requestDocument = JsonDocument.Parse(json);

            // Parse JsonElement into separate events, deserialize event envelope properties
            if (requestDocument.RootElement.ValueKind == JsonValueKind.Object)
            {
                packages = new MediaStreamingPackageBase[1];
                packages[0] = Parse(requestDocument.RootElement.ToString());
            }
            else if (requestDocument.RootElement.ValueKind == JsonValueKind.Array)
            {
                packages = new MediaStreamingPackageBase[requestDocument.RootElement.GetArrayLength()];
                int i = 0;
                foreach (JsonElement property in requestDocument.RootElement.EnumerateArray())
                {
                    packages[i++] = Parse(property.ToString());
                }
            }
            return packages ?? Array.Empty<MediaStreamingPackageBase>();
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
