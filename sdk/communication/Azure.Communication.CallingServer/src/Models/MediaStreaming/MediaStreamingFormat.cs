// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallingServer
{
    /// <summary>
    /// The Streaming Format model.
    /// </summary>
    public class MediaStreamingFormat
    {
        /// <summary>
        /// The Encoding.
        /// </summary>
        public string Encoding { get; }
        /// <summary>
        /// Sample Rate.
        /// </summary>
        public int SampleRate { get; }
        /// <summary>
        /// Channels.
        /// </summary>
        public int Channels { get; }
        /// <summary>
        /// Length.
        /// </summary>
        public double Length { get; }

        internal MediaStreamingFormat(string encoding, int sampleRate, int channels, double length)
        {
            Encoding = encoding;
            SampleRate = sampleRate;
            Channels = channels;
            Length = length;
        }
    }
}
