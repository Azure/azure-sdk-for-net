// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Hangup
    /// </summary>
    [CodeGenModel("Hangup", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
#pragma warning disable AZC0012 // Avoid single word type names
    public partial class Hangup
#pragma warning restore AZC0012 // Avoid single word type names
    {
        /// <summary>
        /// Reason
        /// </summary>
        [CodeGenMember("Reason")]
        public string Reason { get; set; }
    }
}
