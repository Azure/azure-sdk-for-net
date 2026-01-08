// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.IO;

namespace Azure.AI.Speech.Transcription
{
    #pragma warning disable SCM0005
    /// <summary> Metadata for a transcription request. </summary>
    public partial class TranscriptionOptions
    {
        /// <summary> Initializes a new instance of <see cref="TranscriptionOptions"/> with an audio URI. </summary>
        /// <param name="audioUri"> The URL of the audio to be transcribed. </param>
        public TranscriptionOptions(Uri audioUri):this()
        {
            AudioUri = audioUri;
        }

        /// <summary> Initializes a new instance of <see cref="TranscriptionOptions"/> with an audio stream. </summary>
        /// <param name="audioStream"> The audio stream to be transcribed. </param>
        public TranscriptionOptions(Stream audioStream):this()
        {
            AudioStream = audioStream;
        }

        /// <summary> Initializes a new instance of <see cref="TranscriptionOptions"/>. </summary>
        public TranscriptionOptions()
        {
            Locales = new ChangeTrackingList<string>();
            Models = new ChangeTrackingDictionary<string, Uri>();
            ActiveChannels = new ChangeTrackingList<int>();
        }

        /// <summary> The URL of the audio to be transcribed. The audio must be shorter than 2 hours in audio duration and smaller than 250 MB in size. If both Audio and AudioUrl are provided, Audio is used. </summary>
        public Uri AudioUri { get;  }
        internal Stream AudioStream { get; }
    }
    #pragma warning restore SCM0005
}
