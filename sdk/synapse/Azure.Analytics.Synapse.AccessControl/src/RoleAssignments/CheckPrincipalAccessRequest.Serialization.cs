// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text.Json;
using Azure.Core;

namespace Azure.Analytics.Synapse.AccessControl
{
    public partial class CheckPrincipalAccessRequest : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("subject");
            writer.WriteObjectValue(Subject);
            writer.WritePropertyName("actions");
            writer.WriteStartArray();
            foreach (var item in Actions)
            {
                writer.WriteObjectValue(item);
            }
            writer.WriteEndArray();
            writer.WritePropertyName("scope");
            writer.WriteStringValue(Scope);
            writer.WriteEndObject();
        }
    }
}
