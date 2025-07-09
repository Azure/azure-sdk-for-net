// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary> The MediaStreamingOptions. </summary>
    public class MediaStreamingOptions
    {
        /// <summary> Initializes a new instance of <see cref="MediaStreamingOptions"/>. </summary>
        /// <param name="audioChannelType"> The audio channel type to stream, e.g., unmixed audio, mixed audio. </param>
        /// <param name="streamingTransport">Media streaming transport.</param>
        public MediaStreamingOptions(MediaStreamingAudioChannel audioChannelType, StreamingTransport streamingTransport = default)
        {
            MediaStreamingAudioChannel = audioChannelType;
            MediaStreamingTransport = streamingTransport == default ? StreamingTransport.Websocket : streamingTransport;
            MediaStreamingContent = MediaStreamingContent.Audio;
        }

        /// <summary> Transport URL for media streaming. </summary>
        public Uri TransportUri { get; set; }
        /// <summary> The type of tranport to be used for media streaming, eg. Websocket. </summary>
        public StreamingTransport MediaStreamingTransport { get; }
        /// <summary> Content type to stream, eg. audio, audio/video. </summary>
        public MediaStreamingContent MediaStreamingContent { get; set; }
        /// <summary> Audio channel type to stream, eg. unmixed audio, mixed audio. </summary>
        public MediaStreamingAudioChannel MediaStreamingAudioChannel { get; }
        /// <summary> Determines if the media streaming should be started immediately after call is answered or not. </summary>
        public bool? StartMediaStreaming { get; set; }
        /// <summary> A value indicating whether bidirectional streaming is enabled. </summary>
        public bool? EnableBidirectional { get; set; }
        /// <summary> Specifies the audio format used for encoding, including sample rate and channel type. </summary>
        public AudioFormat? AudioFormat { get; set; }
        /// <summary> A value that indicates whether to stream the DTMF tones. </summary>
        public bool? EnableDtmfTones { get; set; }
    }
}
