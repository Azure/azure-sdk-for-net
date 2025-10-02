// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    [CodeGenModel("PiiRedactionOptions")]
    internal partial class PiiRedactionOptionsInternal
    {
        [JsonPropertyName("enable")]
        public bool? Enable { get; set; }

        [JsonPropertyName("redactionType")]
        public RedactionType? RedactionType { get; set; }

        public PiiRedactionOptionsInternal() { }

        internal PiiRedactionOptionsInternal(bool? enable, RedactionType? redactionType)
        {
            Enable = enable;
            RedactionType = redactionType;
        }
    }
}
