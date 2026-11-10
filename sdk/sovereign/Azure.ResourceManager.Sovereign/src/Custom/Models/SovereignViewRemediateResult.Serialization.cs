// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Sovereign.Models
{
    [CodeGenSuppress("DeserializeSovereignViewRemediateResult", typeof(JsonElement), typeof(ModelReaderWriterOptions))]
    public partial class SovereignViewRemediateResult
    {
        internal static SovereignViewRemediateResult DeserializeSovereignViewRemediateResult(JsonElement element, ModelReaderWriterOptions options)
        {
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }

            string remediationId = default;
            ResponseError error = default;
            IDictionary<string, BinaryData> additionalBinaryDataProperties = new ChangeTrackingDictionary<string, BinaryData>();
            foreach (JsonProperty property in element.EnumerateObject())
            {
                if (property.NameEquals("remediationId"))
                {
                    remediationId = property.Value.GetString();
                }
                else if (property.NameEquals("error"))
                {
                    if (property.Value.ValueKind != JsonValueKind.Null)
                    {
                        error = ModelReaderWriter.Read<ResponseError>(BinaryData.FromString(property.Value.GetRawText()),
                            ModelSerializationExtensions.WireOptions, AzureResourceManagerSovereignContext.Default);
                    }
                }
                else if (options.Format != "W")
                {
                    additionalBinaryDataProperties.Add(property.Name, BinaryData.FromString(property.Value.GetRawText()));
                }
            }

            // A successful ARM polling response may carry the action result under properties.
            // Leave LRO status/error handling to the standard ARM operation implementation.
            if (remediationId == null &&
                element.TryGetProperty("status", out JsonElement status) &&
                status.ValueKind == JsonValueKind.String &&
                string.Equals(status.GetString(), "Succeeded", StringComparison.OrdinalIgnoreCase) &&
                element.TryGetProperty("properties", out JsonElement properties) &&
                properties.ValueKind == JsonValueKind.Object &&
                properties.TryGetProperty("remediationId", out JsonElement nestedId))
            {
                remediationId = nestedId.GetString();
            }

            return new SovereignViewRemediateResult(remediationId, error, additionalBinaryDataProperties);
        }
    }
}
