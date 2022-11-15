// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class AnalysisParameters : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("targetProjectKind");
            writer.WriteStringValue(TargetProjectKind.ToString());
            if (Optional.IsDefined(ApiVersion))
            {
                writer.WritePropertyName("apiVersion");
                writer.WriteStringValue(ApiVersion);
            }
            writer.WriteEndObject();
        }
    }
}
