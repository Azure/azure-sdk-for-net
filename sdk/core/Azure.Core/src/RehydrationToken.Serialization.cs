// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Diagnostics;
using System.Text.Json;

namespace Azure.Core
{
    public partial struct RehydrationToken : IJsonModel<RehydrationToken>, IJsonModel<object>
    {
        internal RehydrationToken DeserializeRehydrationToken(JsonElement element, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RehydrationToken>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RehydrationToken)} does not support '{format}' format.");
            }

            if (element.ValueKind == JsonValueKind.Null)
            {
                throw new InvalidOperationException("Cannot deserialize a null value to a non-nullable RehydrationToken");
            }

            string id = NextLinkOperationImplementation.NotSet;
            string version = string.Empty;
            string headerSource = string.Empty;
            string nextRequestUri = string.Empty;
            string initialUri = string.Empty;
            RequestMethod requestMethod = default;
            string? lastKnownLocation = null;
            string finalStateVia = string.Empty;

            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    var idString = property.Value.GetString();
                    Debug.Assert(idString is not null);
                    id = idString!;
                }
                if (property.NameEquals("version"u8))
                {
                    var versionString = property.Value.GetString();
                    Debug.Assert(versionString is not null);
                    version = versionString!;
                    continue;
                }
                if (property.NameEquals("headerSource"u8))
                {
                    var headerSourceString = property.Value.GetString();
                    Debug.Assert(headerSourceString is not null);
                    headerSource = headerSourceString!;
                    continue;
                }
                if (property.NameEquals("nextRequestUri"u8))
                {
                    var nextRequestUriString = property.Value.GetString();
                    Debug.Assert(nextRequestUriString is not null);
                    nextRequestUri = nextRequestUriString!;
                    continue;
                }
                if (property.NameEquals("initialUri"u8))
                {
                    var initialUriString = property.Value.GetString();
                    Debug.Assert(initialUriString is not null);
                    initialUri = initialUriString!;
                    continue;
                }
                if (property.NameEquals("requestMethod"u8))
                {
                    var requestMethodString = property.Value.GetString();
                    Debug.Assert(requestMethodString is not null);
                    requestMethod = new RequestMethod(requestMethodString!);
                    continue;
                }
                if (property.NameEquals("lastKnownLocation"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    lastKnownLocation = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("finalStateVia"u8))
                {
                    var finalStateViaString = property.Value.GetString();
                    Debug.Assert(finalStateViaString is not null);
                    finalStateVia = finalStateViaString!;
                    continue;
                }
            }
            return new RehydrationToken(id, version, headerSource, nextRequestUri, initialUri, requestMethod, lastKnownLocation, finalStateVia);
        }

        void IJsonModel<RehydrationToken>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            writer.WritePropertyName("id"u8);
            writer.WriteStringValue(Id);
            writer.WritePropertyName("version"u8);
            writer.WriteStringValue(Version);
            writer.WritePropertyName("headerSource"u8);
            writer.WriteStringValue(HeaderSource);
            writer.WritePropertyName("nextRequestUri"u8);
            writer.WriteStringValue(NextRequestUri);
            writer.WritePropertyName("initialUri"u8);
            writer.WriteStringValue(InitialUri);
            writer.WritePropertyName("requestMethod"u8);
            writer.WriteStringValue(RequestMethod.ToString());
            writer.WritePropertyName("lastKnownLocation"u8);
            writer.WriteStringValue(LastKnownLocation);
            writer.WritePropertyName("finalStateVia"u8);
            writer.WriteStringValue(FinalStateVia);
            writer.WriteEndObject();
        }

        RehydrationToken IJsonModel<RehydrationToken>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RehydrationToken>)this).GetFormatFromOptions(options) : options.Format;
            if (format != "J")
            {
                throw new FormatException($"The model {nameof(RehydrationToken)} does not support '{format}' format.");
            }

            using JsonDocument document = JsonDocument.ParseValue(ref reader);
            return DeserializeRehydrationToken(document.RootElement, options);
        }

        BinaryData IPersistableModel<RehydrationToken>.Write(ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RehydrationToken>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    return ModelReaderWriter.Write(this, options, AzureCoreContext.Default);
                default:
                    throw new FormatException($"The model {nameof(RehydrationToken)} does not support '{options.Format}' format.");
            }
        }

        RehydrationToken IPersistableModel<RehydrationToken>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            var format = options.Format == "W" ? ((IPersistableModel<RehydrationToken>)this).GetFormatFromOptions(options) : options.Format;

            switch (format)
            {
                case "J":
                    {
                        using JsonDocument document = JsonDocument.Parse(data);
                        return DeserializeRehydrationToken(document.RootElement, options);
                    }
                default:
                    throw new FormatException($"The model {nameof(RehydrationToken)} does not support '{options.Format}' format.");
            }
        }

        string IPersistableModel<RehydrationToken>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        BinaryData IPersistableModel<object>.Write(ModelReaderWriterOptions options)
            => ((IPersistableModel<RehydrationToken>)this).Write(options);

        object IPersistableModel<object>.Create(BinaryData data, ModelReaderWriterOptions options)
            => ((IPersistableModel<RehydrationToken>)this).Create(data, options);

        string IPersistableModel<object>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        void IJsonModel<object>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options)
            => ((IJsonModel<RehydrationToken>)this).Write(writer, options);

        object IJsonModel<object>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
            => ((IJsonModel<RehydrationToken>)this).Create(ref reader, options);
    }
}
