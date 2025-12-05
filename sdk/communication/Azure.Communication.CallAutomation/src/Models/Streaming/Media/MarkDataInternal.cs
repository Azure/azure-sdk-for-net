// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json.Serialization;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Streaming mark data.
    /// </summary>
    internal class MarkDataInternal
    {
        /// <summary>
        /// The id of this mark data
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The status of this mark data
        /// </summary>
        [JsonPropertyName("status")]
        public MarkStatus Status { get; set; }
    }
}
