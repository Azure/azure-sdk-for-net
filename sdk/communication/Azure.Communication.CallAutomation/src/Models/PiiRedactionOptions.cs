// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Communication.CallAutomation
{
    /// <summary> PII redaction configuration options. </summary>
    public class PiiRedactionOptions
    {
        /// <summary> Gets or sets a value indicating whether PII redaction is enabled. </summary>
        public bool? Enable { get; set; }
        /// <summary> Gets or sets the type of PII redaction to be used. </summary>
        public RedactionType? RedactionType { get; set; }
    }
}
