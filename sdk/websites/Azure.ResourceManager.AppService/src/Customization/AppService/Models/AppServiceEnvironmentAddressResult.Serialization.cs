// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Net;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.AppService.Models
{
    // ROOT CAUSE: AppServiceEnvironmentAddressResult is a GA compatibility shim (see
    // AppServiceEnvironmentAddressResult.cs) re-introduced to preserve the 1.5.0 public surface
    // returned by AppServiceEnvironmentResource.GetVipInfo*. The TypeSpec emitter generates this
    // shape as a different resource type, so the GA-named model is hand-declared on the SDK side.
    // Because there is no generator-emitted JsonModel implementation for the hand-declared type,
    // IJsonModel/IPersistableModel must also be hand-maintained here. Removing this file would
    // leave the shim un-(de)serializable and break callers that still consume the GA model.
    public partial class AppServiceEnvironmentAddressResult : IJsonModel<AppServiceEnvironmentAddressResult>
    {
        void IJsonModel<AppServiceEnvironmentAddressResult>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            JsonModelWriteCore(writer, options);
            writer.WriteEndObject();
        }

        /// <param name="writer"> The JSON writer. </param>
        /// <param name="options"> The client options for reading and writing models. </param>
        protected override void JsonModelWriteCore(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<AppServiceEnvironmentAddressResult>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(AppServiceEnvironmentAddressResult)} does not support writing '{format}' format.");
            }

            base.JsonModelWriteCore(writer, options);

            if (Kind != null)
            {
                writer.WritePropertyName("kind"u8);
                writer.WriteStringValue(Kind);
            }

            writer.WritePropertyName("properties"u8);
            writer.WriteStartObject();
            if (ServiceIPAddress != null)
            {
                writer.WritePropertyName("serviceIpAddress"u8);
                writer.WriteStringValue(ServiceIPAddress.ToString());
            }
            if (InternalIPAddress != null)
            {
                writer.WritePropertyName("internalIpAddress"u8);
                writer.WriteStringValue(InternalIPAddress.ToString());
            }
            if (OutboundIPAddresses != null && OutboundIPAddresses.Count > 0)
            {
                writer.WritePropertyName("outboundIpAddresses"u8);
                writer.WriteStartArray();
                foreach (var ip in OutboundIPAddresses)
                {
                    writer.WriteStringValue(ip?.ToString());
                }
                writer.WriteEndArray();
            }
            if (VirtualIPMappings != null && VirtualIPMappings.Count > 0)
            {
                writer.WritePropertyName("vipMappings"u8);
                writer.WriteStartArray();
                foreach (var item in VirtualIPMappings)
                {
                    ((IJsonModel<VirtualIPMapping>)item).Write(writer, options);
                }
                writer.WriteEndArray();
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

        AppServiceEnvironmentAddressResult IJsonModel<AppServiceEnvironmentAddressResult>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using JsonDocument doc = JsonDocument.ParseValue(ref reader);
            return DeserializeAppServiceEnvironmentAddressResult(doc.RootElement, options);
        }

        internal static AppServiceEnvironmentAddressResult DeserializeAppServiceEnvironmentAddressResult(JsonElement element, ModelReaderWriterOptions options = null)
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
            IPAddress serviceIp = default;
            IPAddress internalIp = default;
            List<IPAddress> outbound = new List<IPAddress>();
            List<VirtualIPMapping> vipMappings = new List<VirtualIPMapping>();
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
                        if (inner.NameEquals("serviceIpAddress"u8) && inner.Value.ValueKind != JsonValueKind.Null)
                        {
                            serviceIp = IPAddress.Parse(inner.Value.GetString());
                        }
                        else if (inner.NameEquals("internalIpAddress"u8) && inner.Value.ValueKind != JsonValueKind.Null)
                        {
                            internalIp = IPAddress.Parse(inner.Value.GetString());
                        }
                        else if (inner.NameEquals("outboundIpAddresses"u8) && inner.Value.ValueKind != JsonValueKind.Null)
                        {
                            foreach (var item in inner.Value.EnumerateArray())
                            {
                                outbound.Add(item.ValueKind == JsonValueKind.Null ? null : IPAddress.Parse(item.GetString()));
                            }
                        }
                        else if (inner.NameEquals("vipMappings"u8) && inner.Value.ValueKind != JsonValueKind.Null)
                        {
                            foreach (var item in inner.Value.EnumerateArray())
                            {
                                vipMappings.Add(ModelReaderWriter.Read<VirtualIPMapping>(BinaryData.FromString(item.GetRawText()), options, AzureResourceManagerAppServiceContext.Default));
                            }
                        }
                    }
                    continue;
                }
                raw[prop.Name] = BinaryData.FromString(prop.Value.GetRawText());
            }
            return new AppServiceEnvironmentAddressResult(id, name, resourceType, systemData, kind, serviceIp, internalIp, outbound, vipMappings, raw);
        }

        BinaryData IPersistableModel<AppServiceEnvironmentAddressResult>.Write(ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<AppServiceEnvironmentAddressResult>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureResourceManagerAppServiceContext.Default);
                default:
                    throw new FormatException($"The model {nameof(AppServiceEnvironmentAddressResult)} does not support writing '{options.Format}' format.");
            }
        }

        AppServiceEnvironmentAddressResult IPersistableModel<AppServiceEnvironmentAddressResult>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            string format = options.Format == "W" ? ((IPersistableModel<AppServiceEnvironmentAddressResult>)this).GetFormatFromOptions(options) : options.Format;
            switch (format)
            {
                case "J":
                {
                    using JsonDocument document = JsonDocument.Parse(data);
                    return DeserializeAppServiceEnvironmentAddressResult(document.RootElement, options);
                }
                default:
                    throw new FormatException($"The model {nameof(AppServiceEnvironmentAddressResult)} does not support reading '{options.Format}' format.");
            }
        }

        string IPersistableModel<AppServiceEnvironmentAddressResult>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";
    }
}
