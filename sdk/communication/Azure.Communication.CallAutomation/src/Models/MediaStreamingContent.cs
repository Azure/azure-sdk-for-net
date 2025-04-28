// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using System.Text.Json.Serialization;
using System;

namespace Azure.Communication.CallAutomation
{
    /// <summary>
    /// Media streaming content.
    /// </summary>
    [CodeGenModel("MediaStreamingContentType", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    [JsonConverter(typeof(EquatableEnumJsonConverter<MediaStreamingContent>))]
    public readonly partial struct MediaStreamingContent : IEquatable<MediaStreamingContent>
    {
    }
}
