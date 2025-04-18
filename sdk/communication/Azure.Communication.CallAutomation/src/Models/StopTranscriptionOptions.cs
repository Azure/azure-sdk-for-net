// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Options for the stop transcription Request.
    /// </summary>
    public class StopTranscriptionOptions
    {
        /// <summary> The value to identify context of the operation. </summary>
        public string OperationContext { get; set; }
    }
}
