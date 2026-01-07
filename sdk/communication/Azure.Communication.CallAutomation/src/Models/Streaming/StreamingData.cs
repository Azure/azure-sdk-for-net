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
        /// Parses a base64 encoded string into a StreamingData object,
        /// which can be one of the following subtypes: AudioData, AudioMetadata, TranscriptionData, or TranscriptionMetadata.
        /// </summary>
        /// <param name="data">The base64 string represents streaming data that will be converted into the appropriate subtype of StreamingData.</param>
        /// <returns>the type of StreamingData.</returns>
        /// <exception cref="NotSupportedException">Throws a NotSupportedException if the provided base64 string does not correspond
        /// to a supported data type for the specified Kind.</exception>
        public static StreamingData Parse(string data)
        {
            return ParseStreamingData(data);
        }

        /// <summary>
        /// Parses a base64 encoded string into a StreamingData object,
        /// which can be one of the following subtypes: AudioData, AudioMetadata, TranscriptionData, or TranscriptionMetadata.
        /// </summary>
        /// <typeparam name="T"> Subtypes of StreamingData -> AudioData, AudioMetadata, TranscriptionData, or TranscriptionMetadata</typeparam>
        /// <param name="data">The base64 string represents streaming data that will be converted into the appropriate subtype of StreamingData.</param>
        /// <returns>the type of StreamingData.</returns>
        /// <exception cref="NotSupportedException">Throws a NotSupportedException if the provided base64 string does not correspond
        /// to a supported data type for the specified Kind.</exception>
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
                    var audioMetadataInternal = JsonSerializer.Deserialize<AudioMetadataInternal>(streamingData.GetProperty("audioMetadata").ToString());
                    return new AudioMetadata(audioMetadataInternal);

                case "AudioData":
                    AudioDataInternal audioInternal = JsonSerializer.Deserialize<AudioDataInternal>(streamingData.GetProperty("audioData").ToString());
                    return new AudioData(
                        audioInternal.Data, audioInternal.Timestamp, audioInternal.ParticipantRawId, audioInternal.Silent, audioInternal.Mark);

                case "MarkData":
                    MarkDataInternal markDataInternal = JsonSerializer.Deserialize<MarkDataInternal>(streamingData.GetProperty("markData").ToString());
                    return new MarkData
                    {
                        Id = markDataInternal.Id,
                        Status = markDataInternal.Status
                    };

                #endregion

                #region Dtmf
                case "DtmfData":
                    DtmfDataInternal dtmfInternal = JsonSerializer.Deserialize<DtmfDataInternal>(streamingData.GetProperty("dtmfData").ToString());
                    return new DtmfData(dtmfInternal.Data, dtmfInternal.Timestamp, dtmfInternal.ParticipantRawId);
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
                        transcriptionDataInternal.ResultStatus
                        );

                #endregion

                default:
                    throw new NotSupportedException($"The provided base64 string does not correspond to a supported data type for the Kind: {Kind}");
            }
        }
    }
}
