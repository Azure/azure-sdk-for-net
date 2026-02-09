// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;

namespace Azure.AI.VoiceLive
{
    /// <summary> Azure semantic end-of-utterance detection (default). </summary>
    public partial class AzureSemanticEouDetectionMultilingual
    {
        /// <summary> Gets or sets the Timeout. </summary>
        internal float? TimeoutMs { get; set; }

        /// <summary> Gets or sets the Timeout. </summary>
        public TimeSpan Timeout
        {
            get => TimeSpan.FromMilliseconds(TimeoutMs ?? 0);
            set => TimeoutMs = (float)value.TotalMilliseconds;
        }
    }
}
