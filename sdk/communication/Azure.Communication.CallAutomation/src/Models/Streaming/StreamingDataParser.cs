// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text;
using System.Text.Json;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// A generic parser for different packages, such as Media(Audio) or Transcription, received as
    /// part of streaming over websocket
    /// </summary>
    public static class StreamingDataParser
    {
        /// <summary>
        /// Parsing a MediaStreaming package from BinaryData.
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static StreamingData Parse(BinaryData json)
        {
            return Parse(json.ToString());
        }

        /// <summary>
        /// Parsing a MediaStreaming package from a byte array.
        /// </summary>
        /// <param name="receivedBytes">a UTF8 byte array.</param>
        /// <returns></returns>
        public static StreamingData Parse(byte[] receivedBytes)
        {
            return Parse(Encoding.UTF8.GetString(receivedBytes));
        }

        /// <summary>
        /// Parse the incoming package.
        /// </summary>
        /// <param name="stringJson"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public static StreamingData Parse(string stringJson)
        {
            JsonElement package = JsonDocument.Parse(stringJson).RootElement;

            string kind = package.GetProperty("kind").ToString();

            switch (kind)
            {
                #region Audio
                case "AudioMetadata":
                    return JsonSerializer.Deserialize<AudioMetadata>(package.GetProperty("audioMetadata").ToString());

                case "AudioData":
                    AudioDataInternal audioInternal = JsonSerializer.Deserialize<AudioDataInternal>(package.GetProperty("audioData").ToString());
                    return new AudioData(
                        audioInternal.Data, audioInternal.Timestamp, audioInternal.ParticipantRawId, audioInternal.Silent);

                #endregion

                #region Transcription
                case "TranscriptionMetadata":
                    return JsonSerializer.Deserialize<TranscriptionMetadata>(package.GetProperty("transcriptionMetadata").ToString());

                case "TranscriptionData":
                    TranscriptionDataInternal transcriptionDataInternal = JsonSerializer.Deserialize<TranscriptionDataInternal>(
                   package.GetProperty("transcriptionData").ToString()
                   );
                    return new TranscriptionData(
                        transcriptionDataInternal.Text,
                        transcriptionDataInternal.Format,
                        transcriptionDataInternal.Confidence,
                        transcriptionDataInternal.Offset,
                        transcriptionDataInternal.Duration,
                        transcriptionDataInternal.Words,
                        transcriptionDataInternal.ParticipantRawID,
                        transcriptionDataInternal.ResultStatus
                        );

                    #endregion

                default:
                    throw new NotSupportedException(stringJson);
            }
        }
    }
}
