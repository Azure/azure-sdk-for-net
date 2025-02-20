// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// UserConsent
    /// </summary>
    [CodeGenModel("UserConsent", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    public partial class UserConsent
    {
        /// <summary>
        /// Recording
        /// </summary>
        [CodeGenMember("Recording")]
        public int? Recording { get; }
    }
}
