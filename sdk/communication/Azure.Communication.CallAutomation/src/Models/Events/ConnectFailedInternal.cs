// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json.Serialization;
using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The connect failed event internal.
    /// </summary>
    [CodeGenModel("ConnectFailed", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    internal partial class ConnectFailedInternal : CallAutomationEventBase
    {
        /// <summary>
        /// Reason code.
        /// </summary>
        public MediaEventReasonCode ReasonCode { get; internal set; }
    }
}
