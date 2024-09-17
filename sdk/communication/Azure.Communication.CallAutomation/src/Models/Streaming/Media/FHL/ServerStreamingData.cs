// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation.FHL
{
    public class ServerStreamingData
    {
        /// <summary>
        /// The WebSocket data object which is then serialized to JSON format
        /// </summary>
        /// <param name="kind">Server message type kind</param>
        /// <param name="audioData">Audio data</param>
        public ServerStreamingData(ServerMessageType kind, ServerAudioData audioData)
        {
            Kind = kind;
            ServerAudioData = audioData;
        }

        /// <summary>
        /// Message that determines the format that of the subsequent messages
        /// received through the WebSocket.
        /// IsRequired = true
        /// </summary>
        public ServerMessageType Kind { get; }

        /// <summary>
        /// Audio Data which contains the audio data stream information
        /// IsRequired = false
        /// </summary>
        public ServerAudioData ServerAudioData { get; }

        /// <summary>
        /// Mark determines end of stream of data
        /// IsRequired = false
        /// </summary>
        public Mark Mark { get; set; }

        /// <summary>
        /// Stop playback and clear buffers
        /// IsRequired = false
        /// </summary>
        public StopAudio StopAudio { get; set; }

    }
}
