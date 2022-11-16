// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Text.Json;
using Azure.Core;

namespace Azure.AI.Language.Conversations
{
    public partial class ConversationTaskParameters : IUtf8JsonSerializable
    {
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("projectName");
            writer.WriteStringValue(ProjectName);
            writer.WritePropertyName("deploymentName");
            writer.WriteStringValue(DeploymentName);
            if (Optional.IsDefined(Verbose))
            {
                writer.WritePropertyName("verbose");
                writer.WriteBooleanValue(Verbose.Value);
            }
            if (Optional.IsDefined(IsLoggingEnabled))
            {
                writer.WritePropertyName("isLoggingEnabled");
                writer.WriteBooleanValue(IsLoggingEnabled.Value);
            }
            if (Optional.IsDefined(StringIndexType))
            {
                writer.WritePropertyName("stringIndexType");
                writer.WriteStringValue(StringIndexType.Value.ToString());
            }
            if (Optional.IsDefined(DirectTarget))
            {
                writer.WritePropertyName("directTarget");
                writer.WriteStringValue(DirectTarget);
            }
            if (Optional.IsCollectionDefined(TargetProjectParameters))
            {
                writer.WritePropertyName("targetProjectParameters");
                writer.WriteStartObject();
                foreach (var item in TargetProjectParameters)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteObjectValue(item.Value);
                }
                writer.WriteEndObject();
            }
            writer.WriteEndObject();
        }
    }
}
