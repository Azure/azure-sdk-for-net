// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System.Text.Json.Serialization;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The possible Dtmf Tones.
    /// </summary>
    [CodeGenModel("VoiceKind", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    [JsonConverter(typeof(EquatableEnumJsonConverter<VoiceKind>))]
    public readonly partial struct VoiceKind
    {
    }
}
