// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    [CodeGenModel("MediaStreamingStatusDetails", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    [JsonConverter(typeof(EquatableEnumJsonConverter<MediaStreamingStatusDetails>))]
    public readonly partial struct MediaStreamingStatusDetails : IEquatable<MediaStreamingStatusDetails>
    {
    }
}
