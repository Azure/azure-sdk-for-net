// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Linq;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Options for the Start transcription Request.
    /// </summary>
    public class StartTranscriptionOptions
    {
        /// <summary> Defines Locale for the transcription e,g en-US. </summary>
        public string Locale { get; set; }

        /// <summary> The value to identify context of the operation. </summary>
        public string OperationContext { get; set; }
    }
}
