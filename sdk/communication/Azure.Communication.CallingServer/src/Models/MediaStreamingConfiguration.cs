// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Communication.CallingServer
{
    /// <summary> The MediaStreamingConfiguration. </summary>
    public class MediaStreamingConfiguration
    {
        /// <summary> Initializes a new instance of MediaStreamingConfiguration. </summary>
        public MediaStreamingConfiguration(Uri transportUrl, MediaStreamingTransportType transportType,
            MediaStreamingContentType contentType, MediaStreamingAudioChannelType audioChannelType)
        {
            TransportUrl = transportUrl;
            TransportType = transportType;
            ContentType = contentType;
            AudioChannelType = audioChannelType;
        }

        /// <summary> Transport URL for media streaming. </summary>
        public Uri TransportUrl { get; }
        /// <summary> The type of tranport to be used for media streaming, eg. Websocket. </summary>
        public MediaStreamingTransportType TransportType { get; }
        /// <summary> Content type to stream, eg. audio, audio/video. </summary>
        public MediaStreamingContentType ContentType { get; }
        /// <summary> Audio channel type to stream, eg. unmixed audio, mixed audio. </summary>
        public MediaStreamingAudioChannelType AudioChannelType { get; }
    }
}
