// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The incoming call event internal.
    /// </summary>
    [CodeGenModel("IncomingCall", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    internal partial class IncomingCallInternal
    {
    }
}
