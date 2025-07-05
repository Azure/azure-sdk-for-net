// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using System.Text.Json.Serialization;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// The media streaming status for media streaming update in events.
    /// </summary>
    [CodeGenModel("MediaStreamingStatus", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    [JsonConverter(typeof(EquatableEnumJsonConverter<MediaStreamingStatus>))]
    public readonly partial struct MediaStreamingStatus : IEquatable<MediaStreamingStatus>
    {
    }
}
