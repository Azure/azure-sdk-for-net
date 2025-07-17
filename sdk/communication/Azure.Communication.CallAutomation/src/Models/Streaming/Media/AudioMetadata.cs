// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Metadata for Audio Streaming.
    /// </summary>
    public class AudioMetadata : StreamingData
    {
        internal AudioMetadata(AudioMetadataInternal audioMetadataInternal)
        {
            MediaSubscriptionId = audioMetadataInternal.MediaSubscriptionId;
            Encoding = audioMetadataInternal.Encoding;
            SampleRate = audioMetadataInternal.SampleRate;
            Channels = (AudioChannel)audioMetadataInternal.Channels;
        }

        /// <summary>
        /// A unique identifier for the media subscription.
        /// </summary>
        public string MediaSubscriptionId { get; }

        /// <summary>
        /// The format used to encode the audio. Currently, only "pcm" (Pulse Code Modulation) is supported.
        /// </summary>
        public string Encoding { get; }
        /// <summary>
        /// The number of samples per second in the audio. Supported values are 16kHz or 24kHz.
        /// </summary>
        public int SampleRate { get; }
        /// <summary>
        /// Specifies the number of audio channels in the audio configuration.
        /// Currently, only "mono" (single channel) is supported.
        /// </summary>
        public AudioChannel Channels { get; }
    }
}
