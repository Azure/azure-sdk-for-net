// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using Azure.Core;

[assembly: CodeGenSuppressType("ManagedServiceIdentity")]
namespace Azure.ResourceManager.Models
{
    [JsonConverter(typeof(ManagedServiceIdentityConverter))]
    public partial class ManagedServiceIdentity : IJsonModel<ManagedServiceIdentity>
    {
        internal void Write(Utf8JsonWriter writer, ModelReaderWriterOptions options, JsonSerializerOptions jOptions = default)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ManagedServiceIdentity>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ManagedServiceIdentity)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            JsonSerializer.Serialize(writer, ManagedServiceIdentityType, jOptions);
            if (options.Format != "W" && Optional.IsDefined(PrincipalId))
            {
                writer.WritePropertyName("principalId"u8);
                writer.WriteStringValue(PrincipalId.Value);
            }
            if (options.Format != "W" && Optional.IsDefined(TenantId))
            {
                writer.WritePropertyName("tenantId"u8);
                writer.WriteStringValue(TenantId.Value);
            }
            if (Optional.IsCollectionDefined(UserAssignedIdentities))
            {
                writer.WritePropertyName("userAssignedIdentities"u8);
                writer.WriteStartObject();
                foreach (var item in UserAssignedIdentities)
                {
                    writer.WritePropertyName(item.Key);
                    JsonSerializer.Serialize(writer, item.Value);
                }
                writer.WriteEndObject();
            }
            writer.WriteEndObject();
        }

        void IJsonModel<ManagedServiceIdentity>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            Write(writer, options, null);
        }

        ManagedServiceIdentity IJsonModel<ManagedServiceIdentity>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ManagedServiceIdentity>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ManagedServiceIdentity)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeManagedServiceIdentity(document.RootElement, options);
        }

        BinaryData IPersistableModel<ManagedServiceIdentity>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ManagedServiceIdentity>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerContext.Default);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(ManagedServiceIdentity)} does not support '{options.Format}' format.");
            }
        }

        private BinaryData SerializeBicep(ModelReaderWriterOptions options)
        {
            StringBuilder builder = new StringBuilder();
            BicepModelReaderWriterOptions bicepOptions = options as BicepModelReaderWriterOptions;
            IDictionary<string, string> propertyOverrides = null;
            bool hasObjectOverride = bicepOptions != null && bicepOptions.PropertyOverrides.TryGetValue(this, out propertyOverrides);
            bool hasPropertyOverride = false;
            string propertyOverride = null;
            builder.AppendLine("{");

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(ManagedServiceIdentityType), out propertyOverride);
            if (Optional.IsDefined(ManagedServiceIdentityType) || hasPropertyOverride)
            {
                builder.Append("  type:");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($" {propertyOverride}");
                }
                else
                {
                    builder.AppendLine($" '{ManagedServiceIdentityType}'");
                }
            }

            hasPropertyOverride = hasObjectOverride && propertyOverrides.TryGetValue(nameof(UserAssignedIdentities), out propertyOverride);
            if (UserAssignedIdentities.Any() || hasPropertyOverride)
            {
                builder.Append("  userAssignedIdentities:");
                builder.AppendLine(" {");
                if (hasPropertyOverride)
                {
                    builder.AppendLine($"    {propertyOverride}");
                }
                else
                {
                    foreach (var item in UserAssignedIdentities)
                    {
                        builder.Append($"    {item.Key}:");
                        AppendChildObject(builder, item.Value, options, 4, false);
                    }
                }

                builder.AppendLine("  }");
            }

            builder.AppendLine("}");
            return BinaryData.FromString(builder.ToString());
        }

        private void AppendChildObject(StringBuilder stringBuilder, object childObject, ModelReaderWriterOptions options, int spaces, bool indentFirstLine)
        {
            string indent = new string(' ', spaces);
            BinaryData data = ModelReaderWriter.Write(childObject, options, AzureResourceManagerContext.Default);
            string[] lines = data.ToString().Split(Environment.NewLine.ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
            bool inMultilineString = false;
            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                if (inMultilineString)
                {
                    if (line.Contains("'''"))
                    {
                        inMultilineString = false;
                    }
                    stringBuilder.AppendLine(line);
                    continue;
                }
                if (line.Contains("'''"))
                {
                    inMultilineString = true;
                    stringBuilder.AppendLine($"{indent}{line}");
                    continue;
                }
                if (i == 0 && !indentFirstLine)
                {
                    stringBuilder.AppendLine($" {line}");
                }
                else
                {
                    stringBuilder.AppendLine($"{indent}{line}");
                }
            }
        }

        internal static ManagedServiceIdentity DeserializeManagedServiceIdentity(JsonElement element, ModelReaderWriterOptions options, JsonSerializerOptions jOptions)
        {
            options ??= new ModelReaderWriterOptions("W");

            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            Guid? principalId = default;
            Guid? tenantId = default;
            ManagedServiceIdentityType type = default;
            IDictionary<ResourceIdentifier, UserAssignedIdentity> userAssignedIdentities = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("principalId"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null || property.Value.GetString().Length == 0)
                    {
                        continue;
                    }
                    principalId = property.Value.GetGuid();
                    continue;
                }
                if (property.NameEquals("tenantId"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null || property.Value.GetString().Length == 0)
                    {
                        continue;
                    }
                    tenantId = property.Value.GetGuid();
                    continue;
                }
                if (property.NameEquals("type"u8))
                {
                    type = JsonSerializer.Deserialize<ManagedServiceIdentityType>($"{{{property}}}", jOptions);
                    continue;
                }
                if (property.NameEquals("userAssignedIdentities"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    Dictionary<ResourceIdentifier, UserAssignedIdentity> dictionary = new Dictionary<ResourceIdentifier, UserAssignedIdentity>();
                    foreach (var property0 in property.Value.EnumerateObject())
                    {
                        dictionary.Add(new ResourceIdentifier(property0.Name), JsonSerializer.Deserialize<UserAssignedIdentity>(property0.Value.GetRawText()));
                    }
                    userAssignedIdentities = dictionary;
                    continue;
                }
            }
            return new ManagedServiceIdentity(principalId, tenantId, type, userAssignedIdentities ?? new ChangeTrackingDictionary<ResourceIdentifier, UserAssignedIdentity>());
        }

        internal static ManagedServiceIdentity DeserializeManagedServiceIdentity(JsonElement element, ModelReaderWriterOptions options = null)
        {
            return DeserializeManagedServiceIdentity(element, options, null);
        }

        ManagedServiceIdentity IPersistableModel<ManagedServiceIdentity>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<ManagedServiceIdentity>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeManagedServiceIdentity(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ManagedServiceIdentity)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<ManagedServiceIdentity>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal partial class ManagedServiceIdentityConverter : JsonConverter<ManagedServiceIdentity>
        {
            public override void Write(Utf8JsonWriter writer, ManagedServiceIdentity model, JsonSerializerOptions options)
            {
                model.Write(writer, new ModelReaderWriterOptions("W"), options);
            }
            public override ManagedServiceIdentity Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeManagedServiceIdentity(document.RootElement, null, options);
            }
        }
    }
}
