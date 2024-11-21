// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Base class for Streaming Data
    /// </summary>
    public abstract class StreamingData
    {
        /// <summary>
        /// Kind of the streaming data ex.AudioData, AudioMetadata, TranscriptionData, TranscriptionMetadata.
        /// </summary>
        public static StreamingDataKind Kind { get; internal set; }

        /// <summary>
        /// Convert the base64 string into streaming data subtypes.
        /// ex. AudioData, AudioMetadata, TranscriptionData, TranscriptionMetadata
        /// </summary>
        /// <param name="data">The base64 string streaming data</param>
        /// <returns> The streaming data</returns>
        public static StreamingData Parse(string data)
        {
            return ParseStreamingData(data);
        }

        /// <summary>
        /// Convert the base64 string into streaming data subtypes.
        /// ex. AudioData, AudioMetadata, TranscriptionData, TranscriptionMetadata
        /// </summary>
        /// <typeparam name="T"> Subtypes of StreamingData. </typeparam>
        /// <param name="data">The base64 string streaming data</param>
        /// <returns>Subtypes of StreamingData.</returns>
        public static T Parse<T>(string data) where T : StreamingData
        {
            return (T)ParseStreamingData(data);
        }

        private static StreamingData ParseStreamingData(string base64Data)
        {
            JsonElement streamingData = JsonDocument.Parse(base64Data).RootElement;

            string kind = streamingData.GetProperty("kind").ToString();
            Kind = (StreamingDataKind)Enum.Parse(typeof(StreamingDataKind), kind);

            switch (kind)
            {
                #region Audio
                case "AudioMetadata":
                    return JsonSerializer.Deserialize<AudioMetadata>(streamingData.GetProperty("audioMetadata").ToString());

                case "AudioData":
                    AudioDataInternal audioInternal = JsonSerializer.Deserialize<AudioDataInternal>(streamingData.GetProperty("audioData").ToString());
                    return new AudioData(
                        audioInternal.Data, audioInternal.Timestamp, audioInternal.ParticipantRawId, audioInternal.Silent);

                #endregion

                #region Transcription
                case "TranscriptionMetadata":
                    return JsonSerializer.Deserialize<TranscriptionMetadata>(streamingData.GetProperty("transcriptionMetadata").ToString());

                case "TranscriptionData":
                    TranscriptionDataInternal transcriptionDataInternal = JsonSerializer.Deserialize<TranscriptionDataInternal>(
                   streamingData.GetProperty("transcriptionData").ToString()
                   );
                    return new TranscriptionData(
                        transcriptionDataInternal.Text,
                        transcriptionDataInternal.Format,
                        transcriptionDataInternal.Confidence,
                        transcriptionDataInternal.Offset,
                        transcriptionDataInternal.Duration,
                        transcriptionDataInternal.Words,
                        transcriptionDataInternal.ParticipantRawID,
                        transcriptionDataInternal.ResultState
                        );

                #endregion

                default:
                    throw new NotSupportedException(base64Data);
            }
        }
    }
}
