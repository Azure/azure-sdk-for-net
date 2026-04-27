// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.ResourceManager.Compute.Models
{
    // The previous (AutoRest-based) generator emitted
    // [JsonConverter(typeof(KeyVaultSecretReferenceConverter))] on this model. The
    // new TypeSpec mgmt generator does not currently honor the
    // @useSystemTextJsonConverter TCGC decorator, so we restore the attribute and
    // its companion converter via customization to preserve the previous public
    // surface.
    [JsonConverter(typeof(KeyVaultSecretReferenceConverter))]
    public partial class KeyVaultSecretReference
    {
        internal partial class KeyVaultSecretReferenceConverter : JsonConverter<KeyVaultSecretReference>
        {
            public override void Write(Utf8JsonWriter writer, KeyVaultSecretReference model, JsonSerializerOptions options)
            {
                ((IJsonModel<KeyVaultSecretReference>)model).Write(writer, ModelSerializationExtensions.WireOptions);
            }

            public override KeyVaultSecretReference Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                using var document = JsonDocument.ParseValue(ref reader);
                return DeserializeKeyVaultSecretReference(document.RootElement, ModelSerializationExtensions.WireOptions);
            }
        }
    }
}
