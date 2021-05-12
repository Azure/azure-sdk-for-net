// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.Calling.Server
{
    /// <summary>
    /// Gets or sets the tone info
    /// </summary>
    public partial class ToneInfo
    {
        /// <summary>
        /// Gets or sets the sequence id. This id can be used to determine if the same tone
        /// was played multiple times or if any tones were missed.
        /// </summary>
        public uint SequenceId { get; set; }

        /// <summary>
        /// Gets or sets the tone detected.
        /// </summary>
        public ToneValue Tone { get; set; }

        /// <summary> Initializes a new instance of <see cref="ToneInfo"/>. </summary>
        /// <param name="sequenceId">Communication Identifier.</param>
        /// <param name="tone"> Participant Id. </param>
        internal ToneInfo(uint sequenceId, ToneValue tone)
        {
            SequenceId = sequenceId;
            Tone = tone;
        }
    }
}
