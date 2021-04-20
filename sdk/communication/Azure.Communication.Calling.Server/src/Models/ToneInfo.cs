// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.Calling.Server
{
    /// <summary>
    /// Gets or sets the tone info
    /// </summary>
    public class ToneInfo
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
    }

    /// <summary>
    /// Tone
    /// </summary>
    public enum ToneValue
    {
        /// <summary>
        /// Tone 0
        /// </summary>
        Tone0 = 0,

        /// <summary>
        /// Tone 1
        /// </summary>
        Tone1 = 1,

        /// <summary>
        /// Tone 2
        /// </summary>
        Tone2 = 2,

        /// <summary>
        /// Tone 3
        /// </summary>
        Tone3 = 3,

        /// <summary>
        /// Tone 4
        /// </summary>
        Tone4 = 4,

        /// <summary>
        /// Tone 5
        /// </summary>
        Tone5 = 5,

        /// <summary>
        /// Tone 6
        /// </summary>
        Tone6 = 6,

        /// <summary>
        /// Tone 7
        /// </summary>
        Tone7 = 7,

        /// <summary>
        /// Tone 8
        /// </summary>
        Tone8 = 8,

        /// <summary>
        /// Tone 9
        /// </summary>
        Tone9 = 9,

        /// <summary>
        /// Star tone.
        /// </summary>
        Star = 10,

        /// <summary>
        /// Pound tone.
        /// </summary>
        Pound = 11,

        /// <summary>
        /// A tone.
        /// </summary>
        A = 12,

        /// <summary>
        /// B tone.
        /// </summary>
        B = 13,

        /// <summary>
        /// C tone.
        /// </summary>
        C = 14,

        /// <summary>
        /// D tone.
        /// </summary>
        D = 15,

        /// <summary>
        /// Flash tone.
        /// </summary>
        Flash = 16
    }
}
