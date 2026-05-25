// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary> The MediaStreamingOptions. </summary>
    public class MediaStreamingOptions
    {
        /// <summary> Initializes a new instance of MediaStreamingOptions. </summary>
        public MediaStreamingOptions(Uri transportUri,
            MediaStreamingContentTypeDto contentType, MediaStreamingAudioChannelTypeDto audioChannelType, MediaStreamingTransportTypeDto transportType = default, bool? startMediaStreaming = null)
        {
            TransportUri = transportUri;
            MediaStreamingTransport = transportType.Equals(default) ? MediaStreamingTransportTypeDto.Websocket : transportType;
            MediaStreamingContent = contentType;
            MediaStreamingAudioChannel = audioChannelType;
            StartMediaStreaming = startMediaStreaming;
        }

        /// <summary> Initializes a new instance of MediaStreamingOptions. </summary>
        public MediaStreamingOptions(MediaStreamingContentTypeDto contentType, MediaStreamingAudioChannelTypeDto audioChannelType, MediaStreamingTransportTypeDto transportType = default, bool? startMediaStreaming = null)
        {
            MediaStreamingTransport = transportType.Equals(default) ? MediaStreamingTransportTypeDto.Websocket : transportType;
            MediaStreamingContent = contentType;
            MediaStreamingAudioChannel = audioChannelType;
            StartMediaStreaming = startMediaStreaming;
        }

        /// <summary> Transport URL for media streaming. </summary>
        public Uri TransportUri { get; set; }
        /// <summary> The type of tranport to be used for media streaming, eg. Websocket. </summary>
        public MediaStreamingTransportTypeDto MediaStreamingTransport { get; }
        /// <summary> Content type to stream, eg. audio, audio/video. </summary>
        public MediaStreamingContentTypeDto MediaStreamingContent { get; }
        /// <summary> Audio channel type to stream, eg. unmixed audio, mixed audio. </summary>
        public MediaStreamingAudioChannelTypeDto MediaStreamingAudioChannel { get; }
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
