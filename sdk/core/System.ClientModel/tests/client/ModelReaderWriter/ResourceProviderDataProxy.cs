// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ClientModel.Primitives;
using System.ClientModel.Tests.Client.Models.ResourceManager.Resources;
using System.Collections.Generic;
using System.Text.Json;
using ClientModel.Tests.ClientShared;

namespace System.ClientModel.Tests.Client
{
    /// <summary>
    /// Overrides the default serialization of <see cref="ResourceProviderData"/>.
    /// Only change is we omit the "id" property from the serialization.
    /// </summary>
    public class ResourceProviderDataProxy : IJsonModel<ResourceProviderData>
    {
        private void Write(ResourceProviderData model, Utf8JsonWriter writer, ModelReaderWriterOptions options)
        {
            writer.WriteStartObject();
            if (OptionalProperty.IsDefined(model.Namespace))
            {
                writer.WritePropertyName("namespace"u8);
                writer.WriteStringValue(model.Namespace);
            }
            if (OptionalProperty.IsCollectionDefined(model.ResourceTypes))
            {
                writer.WritePropertyName("resourceTypes"u8);
                writer.WriteStartArray();
                foreach (var item in model.ResourceTypes)
                {
                    writer.WriteObjectValue(item);
                }
                writer.WriteEndArray();
            }
            if (OptionalProperty.IsDefined(model.RegistrationState))
            {
                writer.WritePropertyName("registrationState"u8);
                writer.WriteStringValue(model.RegistrationState);
            }
            if (OptionalProperty.IsDefined(model.RegistrationPolicy))
            {
                writer.WritePropertyName("registrationPolicy"u8);
                writer.WriteStringValue(model.RegistrationPolicy);
            }
            if (OptionalProperty.IsDefined(model.ProviderAuthorizationConsentState))
            {
                writer.WritePropertyName("providerAuthorizationConsentState"u8);
                writer.WriteStringValue(model.ProviderAuthorizationConsentState.ToString());
            }
            writer.WriteEndObject();
        }

        private static ResourceProviderData DeserializeResourceProviderData(JsonElement element, ModelReaderWriterOptions options)
        {
            options ??= ModelReaderWriterHelper.WireOptions;

            OptionalProperty<string> id = "TestValue";
            OptionalProperty<string> @namespace = default;
            OptionalProperty<string> registrationState = default;
            OptionalProperty<string> registrationPolicy = default;
            OptionalProperty<IReadOnlyList<ProviderResourceType>> resourceTypes = default;
            OptionalProperty<ProviderAuthorizationConsentState> providerAuthorizationConsentState = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"u8))
                {
                    continue;
                }
                if (property.NameEquals("namespace"u8))
                {
                    @namespace = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("registrationState"u8))
                {
                    registrationState = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("registrationPolicy"u8))
                {
                    registrationPolicy = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("resourceTypes"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    List<ProviderResourceType> array = new List<ProviderResourceType>();
                    foreach (var item in property.Value.EnumerateArray())
                    {
                        array.Add(ProviderResourceType.DeserializeProviderResourceType(item, options));
                    }
                    resourceTypes = array;
                    continue;
                }
                if (property.NameEquals("providerAuthorizationConsentState"u8))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    providerAuthorizationConsentState = new ProviderAuthorizationConsentState(property.Value.GetString());
                    continue;
                }
            }
            return new ResourceProviderData(id.Value, @namespace.Value, registrationState.Value, registrationPolicy.Value, OptionalProperty.ToList(resourceTypes), OptionalProperty.ToNullable(providerAuthorizationConsentState));
        }

        ResourceProviderData IJsonModel<ResourceProviderData>.Create(ref Utf8JsonReader reader, ModelReaderWriterOptions options)
        {
            using var doc = JsonDocument.ParseValue(ref reader);
            return DeserializeResourceProviderData(doc.RootElement, options);
        }

        ResourceProviderData IPersistableModel<ResourceProviderData>.Create(BinaryData data, ModelReaderWriterOptions options)
        {
            using var doc = JsonDocument.Parse(data);
            return DeserializeResourceProviderData(doc.RootElement, options);
        }

        string IPersistableModel<ResourceProviderData>.GetFormatFromOptions(ModelReaderWriterOptions options) => "J";

        void IJsonModel<ResourceProviderData>.Write(Utf8JsonWriter writer, ModelReaderWriterOptions options) => Write((ResourceProviderData)options.ProxiedModel!, writer, options);

        BinaryData IPersistableModel<ResourceProviderData>.Write(ModelReaderWriterOptions options)
        {
            throw new NotImplementedException();
        }
    }
}
