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
using Azure.ResourceManager.Models;

[assembly: CodeGenSuppressType("ManagedServiceIdentity")]
namespace Azure.ResourceManager.Models
{
    [JsonConverter(typeof(ManagedServiceIdentityConverter))]
    public partial class ManagedServiceIdentity : IJsonModel<ManagedServiceIdentity>
    {
        private const string SystemAssignedUserAssignedV3Value = "SystemAssigned,UserAssigned";

        // This method checks if the format string in options.Format ends with the "|v3" suffix.
        // The "|v3" suffix indicates that the ManagedServiceIdentityType format is version 3.
        // If the suffix is present, it is removed, and the base format is returned via the 'format' parameter.
        // This allows the method to handle version-specific logic while preserving the base format.
        private static bool UseManagedServiceIdentityV3(ModelReaderWriterOptions options, out string format)
        {
            var originalFormat = options.Format.AsSpan();
            if (originalFormat.Length > 3)
            {
                var v3Format = "|v3".AsSpan();
                if (originalFormat.EndsWith(v3Format))
                {
                    format = originalFormat.Slice(0, originalFormat.Length - v3Format.Length).ToString();
                    return true;
                }
            }

            format = options.Format;
            return false;
        }

        void IJsonModel<ManagedServiceIdentity>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            var useManagedServiceIdentityV3 = UseManagedServiceIdentityV3(options, out string optionsFormat);
            var format = optionsFormat == "W" ? ((IPersistableModel<ManagedServiceIdentity>)this).GetFormatFromOptions(options) : optionsFormat;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ManagedServiceIdentity)} does not support '{format}' format.");
            }

            writer.WriteStartObject();
            writer.WritePropertyName("type"u8);
            if (useManagedServiceIdentityV3 && ManagedServiceIdentityType == ManagedServiceIdentityType.SystemAssignedUserAssigned)
            {
                writer.WriteStringValue(SystemAssignedUserAssignedV3Value);
            }
            else
            {
                writer.WriteStringValue(ManagedServiceIdentityType.ToString());
            }

            if (optionsFormat != "W" && Optional.IsDefined(PrincipalId))
            {
                writer.WritePropertyName("principalId"u8);
                writer.WriteStringValue(PrincipalId.Value);
            }
            if (optionsFormat != "W" && Optional.IsDefined(TenantId))
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
                    if (item.Value is null)
                    {
                        writer.WriteNullValue();
                    }
                    else
                    {
                        ((IJsonModel<UserAssignedIdentity>)item.Value).Write(writer, new ModelReaderWriterOptions(optionsFormat));
                    }
                }
                writer.WriteEndObject();
            }
            writer.WriteEndObject();
        }

        ManagedServiceIdentity IJsonModel<ManagedServiceIdentity>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            UseManagedServiceIdentityV3(options, out string optionsFormat);
            var format = optionsFormat == "W" ? ((IPersistableModel<ManagedServiceIdentity>)this).GetFormatFromOptions(options) : optionsFormat;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(ManagedServiceIdentity)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeManagedServiceIdentity(document.RootElement, options);
        }

        BinaryData IPersistableModel<ManagedServiceIdentity>.Write(ModelReaderWriterOptions options)
        {
            UseManagedServiceIdentityV3(options, out string optionsFormat);
            var format = optionsFormat == "W" ? ((IPersistableModel<ManagedServiceIdentity>)this).GetFormatFromOptions(options) : optionsFormat;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerContext.Default);
                case "bicep":
                    return SerializeBicep(options);
                default:
                    throw new FormatException($"The model {nameof(ManagedServiceIdentity)} does not support '{format}' format.");
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

        internal static ManagedServiceIdentity DeserializeManagedServiceIdentity(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");
            var useManagedServiceIdentityV3 = UseManagedServiceIdentityV3(options, out string format);
            options = new ModelReaderWriterOptions(format);

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
                    var propertyValue = property.Value.GetString();
                    if (useManagedServiceIdentityV3 && propertyValue == SystemAssignedUserAssignedV3Value)
                    {
                        type = ManagedServiceIdentityType.SystemAssignedUserAssigned;
                    }
                    else
                    {
                        type = new ManagedServiceIdentityType(propertyValue);
                    }
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
                        var data = new BinaryData(Encoding.UTF8.GetBytes(property0.Value.GetRawText()));
                        dictionary.Add(new ResourceIdentifier(property0.Name), ModelReaderWriter.Read<UserAssignedIdentity>(data, options, AzureResourceManagerContext.Default));
                    }
                    userAssignedIdentities = dictionary;
                    continue;
                }
            }
            return new ManagedServiceIdentity(principalId, tenantId, type, userAssignedIdentities ?? new ChangeTrackingDictionary<ResourceIdentifier, UserAssignedIdentity>());
        }

        ManagedServiceIdentity IPersistableModel<ManagedServiceIdentity>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            options ??= new ModelReaderWriterOptions("W");
            var useManagedServiceIdentityV3 = UseManagedServiceIdentityV3(options, out string optionsFormat);
            var format = optionsFormat == "W" ? ((IPersistableModel<ManagedServiceIdentity>)this).GetFormatFromOptions(options) : optionsFormat;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeManagedServiceIdentity(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(ManagedServiceIdentity)} does not support '{format}' format.");
            }
        }

        string IPersistableModel<ManagedServiceIdentity>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        internal partial class ManagedServiceIdentityConverter : JsonConverter<ManagedServiceIdentity>
        {
            private static readonly ModelReaderWriterOptions V3Options = new ModelReaderWriterOptions("W|v3");

            // This method checks if the ManagedServiceIdentityTypeV3Converter exists and it indicates that the ManagedServiceIdentityType format is version 3.
            // Then, the format string in options.Format should be "W|v3", otherwise the default options.Format is "W".
            // TODO: Remove this method when ManagedServiceIdentityTypeV3Converter is removed from the codebase after we apply the latest genertor changes.
            private bool UseManagedServiceIdentityV3(JsonSerializerOptions options)
                => options is not null && options.Converters.Any(x => x.ToString().EndsWith("ManagedServiceIdentityTypeV3Converter"));

            public override void Write(Utf8JsonWriter writer, ManagedServiceIdentity model, JsonSerializerOptions options)
            {
                ((IJsonModel<ManagedServiceIdentity>)model).Write(writer, UseManagedServiceIdentityV3(options) ? V3Options : new ModelReaderWriterOptions("W"));
            }
            public override ManagedServiceIdentity Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeManagedServiceIdentity(document.RootElement, UseManagedServiceIdentityV3(options) ? V3Options : null);
            }
        }
    }
}
