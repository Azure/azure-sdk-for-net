// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using System.Text.Json.Serialization;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The media streaming status details for media streaming update in events.
    /// </summary>
    [CodeGenModel("MediaStreamingStatusDetails", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    [JsonConverter(typeof(EquatableEnumJsonConverter<MediaStreamingStatusDetails>))]
    public readonly partial struct MediaStreamingStatusDetails : IEquatable<MediaStreamingStatusDetails>
    {
    }
}
