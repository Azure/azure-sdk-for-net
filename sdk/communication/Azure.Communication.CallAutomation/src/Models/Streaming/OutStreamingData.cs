// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Base class for Out Streaming Data
    /// </summary>
    public class OutStreamingData
    {
        /// <summary>
        /// Create the new instance of outstreamingdata with kind
        /// </summary>
        /// <param name="kind"></param>
        internal OutStreamingData(MediaKind kind)
        {
            this.Kind = kind;
        }

        /// <summary>
        /// Out streaming data kind ex. StopAudio, AudioData
        /// </summary>
        public MediaKind Kind { get; }

        /// <summary>
        /// Out streaming Audio Data
        /// </summary>
        public AudioData AudioData { get; internal set; }

        /// <summary>
        /// Out streaming Stop Audio Data
        /// </summary>
        public StopAudio StopAudio { get; internal set; }

        /// <summary>
        /// Out streaming Mark Data
        /// </summary>
        public MarkData MarkData { get; internal set; }

        /// <summary>
        /// Get the streaming data for outbound
        /// </summary>
        /// <param name="audioData"></param>
        /// <returns>the string of outstreaming data</returns>
        public static string GetAudioDataForOutbound(byte[] audioData)
        {
            // Create a ServerAudioData object for this chunk
            var audio = new OutStreamingData(MediaKind.AudioData)
            {
                AudioData = new AudioData(audioData)
            };
            // Serialize the JSON object to a string
            return JsonSerializer.Serialize(audio);
        }

        /// <summary>
        /// Get the streaming data for outbound
        /// </summary>
        /// <param name="audioData"></param>
        /// <param name="markId"></param>
        /// <returns>the string of outstreaming data</returns>
        public static string GetAudioDataForOutbound(byte[] audioData, string markId)
        {
            // Create a ServerAudioData object for this chunk
            var audio = new OutStreamingData(MediaKind.AudioData)
            {
                AudioData = new AudioData(audioData, markId)
            };
            // Serialize the JSON object to a string
            return JsonSerializer.Serialize(audio);
        }

        /// <summary>
        /// Get the stop audiofor outbound
        /// </summary>
        /// <returns>the string of outstreaming data with the stop audio.</returns>
        public static string GetStopAudioForOutbound()
        {
            var jsonObject = new OutStreamingData(MediaKind.StopAudio)
            {
                StopAudio = new StopAudio()
            };

            // Serialize the JSON object to a string
            return JsonSerializer.Serialize(jsonObject);
        }

        /// <summary>
        /// Get the mark data for outbound
        /// </summary>
        /// <param name="id"></param>
        /// <param name="status"></param>
        /// <returns>the string of outstreaming data with the mark data.</returns>
        public static string GetMarkDataForOutbound(string id, MarkStatus status)
        {
            // Create a ServerMarkData object for this chunk
            var mark = new OutStreamingData(MediaKind.MarkData)
            {
                MarkData = new MarkData
                {
                    Id = id,
                    Status = status
                }
            };
            // Serialize the JSON object to a string
            return JsonSerializer.Serialize(mark);
        }
    }
}
