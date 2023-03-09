// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The remove participant event internal.
    /// </summary>
    [CodeGenModel("ParticipantRemoved", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    internal partial class ParticipantRemovedInternal
    {
    }
}
