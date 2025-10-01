// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Text.Json;

namespace Azure.AI.VoiceLive
{
    /// <summary> The response resource. </summary>
    public partial class SessionResponse
    {
        /// <summary>
        /// supported voice identifiers and configurations.
        /// </summary>
        public VoiceProvider Voice { get; }

        /// <summary>
        /// Maximum number of output tokens for a single assistant response,
        /// inclusive of tool calls, that was used in this response.
        /// </summary>
        public MaxResponseOutputTokensOption MaxOutputTokens { get; }
    }
}
