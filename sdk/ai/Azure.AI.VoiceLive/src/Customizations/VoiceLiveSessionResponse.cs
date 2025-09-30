// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;

namespace Azure.AI.VoiceLive
{
    /// <summary> Base for session configuration in the response. </summary>
    public partial class VoiceLiveSessionResponse : VoiceLiveSessionOptions
    {
        /// <summary> The agent configuration for the session, if applicable. </summary>
        internal RespondingAgentOptions Agent { get; }
    }
}
