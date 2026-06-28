// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.AppService.Models
{
    public partial class SiteAuthSettingsV2 : IJsonModel<SiteAuthSettingsV2>
    {
        void IJsonModel<SiteAuthSettingsV2>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<SiteAuthSettingsV2>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(SiteAuthSettingsV2)} does not support writing '{format}' format.");
            }

            base.JsonModelWriteCore(writer, options);

            if (Kind != null)
            {
                writer.WritePropertyName("kind"u8);
                writer.WriteStringValue(Kind);
            }

            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (Platform != null)
            {
                writer.WritePropertyName("platform"u8);
                ((IJsonModel<AuthPlatform>)Platform).Write(writer, options);
            }
            if (GlobalValidation != null)
            {
                writer.WritePropertyName("globalValidation"u8);
                ((IJsonModel<GlobalValidation>)GlobalValidation).Write(writer, options);
            }
            if (IdentityProviders != null)
            {
                writer.WritePropertyName("identityProviders"u8);
                ((IJsonModel<AppServiceIdentityProviders>)IdentityProviders).Write(writer, options);
            }
            if (Login != null)
            {
                writer.WritePropertyName("login"u8);
                ((IJsonModel<WebAppLoginInfo>)Login).Write(writer, options);
            }
            if (HttpSettings != null)
            {
                writer.WritePropertyName("httpSettings"u8);
                ((IJsonModel<AppServiceHttpSettings>)HttpSettings).Write(writer, options);
            }
            writer.WriteEndObject();

            if (options.Format != "W" && _serializedAdditionalRawData != null)
            {
                foreach (var kv in _serializedAdditionalRawData)
                {
                    writer.WritePropertyName(kv.Key);
#if NET6_0_OR_GREATER
                    writer.WriteRawValue(kv.Value);
#else
                    using (JsonDocument document = JsonDocument.Parse(kv.Value))
                    {
                        JsonSerializer.Serialize(writer, document.RootElement);
                    }
#endif
                }
            }
        }

        SiteAuthSettingsV2 IJsonModel<SiteAuthSettingsV2>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return DeserializeSiteAuthSettingsV2(doc.RootElement, options);
        }

        internal static SiteAuthSettingsV2 DeserializeSiteAuthSettingsV2(JsonElement element, ModelReaderWriterOptions options = null)
        {
            options ??= new ModelReaderWriterOptions("W");
            if (element.ValueKind == JsonValueKind.Null)
            {
                return null;
            }
            ResourceIdentifier id = default;
            string name = default;
            ResourceType resourceType = default;
            SystemData systemData = default;
            string kind = default;
            AuthPlatform platform = default;
            GlobalValidation globalValidation = default;
            AppServiceIdentityProviders identityProviders = default;
            WebAppLoginInfo login = default;
            AppServiceHttpSettings httpSettings = default;
            Dictionary<string, BinaryData> raw = new Dictionary<string, BinaryData>();

            foreach (var prop in element.EnumerateObject())
            {
                if (prop.NameEquals("id"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null) continue;
                    id = new ResourceIdentifier(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("name"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null) continue;
                    name = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("type"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null) continue;
                    resourceType = new ResourceType(prop.Value.GetString());
                    continue;
                }
                if (prop.NameEquals("systemData"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null) continue;
                    systemData = ModelReaderWriter.Read<SystemData>(BinaryData.FromString(prop.Value.GetRawText()), ModelSerializationExtensions.WireOptions, AzureResourceManagerAppServiceContext.Default);
                    continue;
                }
                if (prop.NameEquals("kind"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null) continue;
                    kind = prop.Value.GetString();
                    continue;
                }
                if (prop.NameEquals("properties"u8))
                {
                    if (prop.Value.ValueKind == JsonValueKind.Null) continue;
                    foreach (var inner in prop.Value.EnumerateObject())
                    {
                        if (inner.Value.ValueKind == JsonValueKind.Null) continue;
                        var bin = BinaryData.FromString(inner.Value.GetRawText());
                        if (inner.NameEquals("platform"u8))
                        {
                            platform = ModelReaderWriter.Read<AuthPlatform>(bin, options, AzureResourceManagerAppServiceContext.Default);
                        }
                        else if (inner.NameEquals("globalValidation"u8))
                        {
                            globalValidation = ModelReaderWriter.Read<GlobalValidation>(bin, options, AzureResourceManagerAppServiceContext.Default);
                        }
                        else if (inner.NameEquals("identityProviders"u8))
                        {
                            identityProviders = ModelReaderWriter.Read<AppServiceIdentityProviders>(bin, options, AzureResourceManagerAppServiceContext.Default);
                        }
                        else if (inner.NameEquals("login"u8))
                        {
                            login = ModelReaderWriter.Read<WebAppLoginInfo>(bin, options, AzureResourceManagerAppServiceContext.Default);
                        }
                        else if (inner.NameEquals("httpSettings"u8))
                        {
                            httpSettings = ModelReaderWriter.Read<AppServiceHttpSettings>(bin, options, AzureResourceManagerAppServiceContext.Default);
                        }
                    }
                    continue;
                }
                raw[prop.Name] = BinaryData.FromString(prop.Value.GetRawText());
            }
            return new SiteAuthSettingsV2(id, name, resourceType, systemData, kind, platform, globalValidation, identityProviders, login, httpSettings, raw);
        }

        BinaryData IPersistableModel<SiteAuthSettingsV2>.Write(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<SiteAuthSettingsV2>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerAppServiceContext.Default);
                default:
                    throw new FormatException($"The model {nameof(SiteAuthSettingsV2)} does not support writing '{options.Format}' format.");
            }
        }

        SiteAuthSettingsV2 IPersistableModel<SiteAuthSettingsV2>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<SiteAuthSettingsV2>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                {
                    using JsonDocument document = JsonDocument.Parse(data);
                    return DeserializeSiteAuthSettingsV2(document.RootElement, options);
                }
                default:
                    throw new FormatException($"The model {nameof(SiteAuthSettingsV2)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<SiteAuthSettingsV2>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
