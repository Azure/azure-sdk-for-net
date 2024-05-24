// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    [CodeGenModel("MediaStreamingSubscriptionState", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    [JsonConverter(typeof(EquatableEnumJsonConverter<MediaStreamingSubscriptionState>))]
    public readonly partial struct MediaStreamingSubscriptionState : IEquatable<MediaStreamingSubscriptionState>
    {
    }
}
