// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class LuisParameters : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            if (Optional.IsDefined(Query))
            {
                writer.WritePropertyName("query");
                writer.WriteStringValue(Query);
            }
            if (Optional.IsDefined(CallingOptions))
            {
                writer.WritePropertyName("callingOptions");
                writer.WriteObjectValue(CallingOptions);
            }
            writer.WritePropertyName("targetProjectKind");
            writer.WriteStringValue(TargetProjectKind.ToString());
            if (Optional.IsDefined(ApiVersion))
            {
                writer.WritePropertyName("apiVersion");
                writer.WriteStringValue(ApiVersion);
            }
            foreach (var item in AdditionalProperties)
            {
                writer.WritePropertyName(item.Key);
                writer.WriteObjectValue(item.Value);
            }
            writer.WriteEndObject();
        }
    }
}
