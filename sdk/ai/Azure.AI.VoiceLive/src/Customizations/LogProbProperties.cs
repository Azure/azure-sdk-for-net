// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;

namespace Azure.AI.VoiceLive
{
    /// <summary> A single log probability entry for a token. </summary>
    public partial class LogProbProperties
    {
        /// <summary> The bytes that were used to generate the log probability. </summary>
        [CodeGenMember("Bytes")]
        public BinaryData Bytes { get; }
    }
}
