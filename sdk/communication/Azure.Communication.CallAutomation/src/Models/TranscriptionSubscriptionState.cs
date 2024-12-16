// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json.Serialization;
using Azure.Core;

namespace Azure.Communication.CallAutomation
{
    [CodeGenModel("TranscriptionSubscriptionState", Usage = new string[] { "output" }, Formats = new string[] { "json" })]
    [JsonConverter(typeof(EquatableEnumJsonConverter<TranscriptionSubscriptionState>))]
    public readonly partial struct TranscriptionSubscriptionState : IEquatable<TranscriptionSubscriptionState>
    {
    }
}
