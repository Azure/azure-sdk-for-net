// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.Speech.Transcription
{
    /// <summary>
    /// Enhanced mode properties for transcription.
    /// Enhanced mode is automatically enabled when this object is created and set on TranscriptionOptions.
    /// </summary>
    public partial class EnhancedModeProperties
    {
        private bool? _enabled = true;

        /// <summary>
        /// Gets or sets a value indicating whether enhanced mode is enabled.
        /// This is automatically set to true when EnhancedModeProperties is created.
        /// </summary>
        internal bool? Enabled
        {
            get => _enabled;
            set => _enabled = value;
        }
    }
}
