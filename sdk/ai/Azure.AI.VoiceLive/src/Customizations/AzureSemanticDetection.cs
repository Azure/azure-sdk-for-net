// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.VoiceLive
{
    /// <summary> Azure semantic end-of-utterance detection (default). </summary>
    public partial class AzureSemanticDetection
    {
        /// <summary> Gets or sets the Timeout. </summary>
        internal float? TimeoutMs { get; set; }

        /// <summary> Gets or sets the Timeout. </summary>
        public TimeSpan Timeout
        {
            get => TimeSpan.FromMilliseconds(TimeoutMs ?? 0);
            set => TimeoutMs = (float)value.TotalMilliseconds;
        }

        /// <summary> Gets or sets the SecondaryTimeout. </summary>
        internal float? SecondaryTimeoutMs { get; set; }

        /// <summary> Gets or sets the SecondaryTimeout. </summary>
        public TimeSpan SecondaryTimeout
        {
            get => TimeSpan.FromMilliseconds(SecondaryTimeoutMs ?? 0);
            set => SecondaryTimeoutMs = (float)value.TotalMilliseconds;
        }
    }
}
