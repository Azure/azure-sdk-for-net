// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// Representation of a publisher plan for marketplace RPs.
    /// </summary>
    public sealed partial class Plan
    {
        /// <summary>
        /// Serialize the input Sku object.
        /// </summary>
        /// <param name="writer"> Input Json writer. </param>
        /// <param name="value"> Input Plan object. </param>
        internal static void Serialize(Utf8JsonWriter writer, Plan value)
        {
            if (writer is null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(value.Name))
            {
                writer.WritePropertyName("name");
                writer.WriteStringValue(value.Name);
            }
            if (Optional.IsDefined(value.Publisher))
            {
                writer.WritePropertyName("publisher");
                writer.WriteStringValue(value.Publisher);
            }
            if (Optional.IsDefined(value.Product))
            {
                writer.WritePropertyName("product");
                writer.WriteStringValue(value.Product);
            }
            if (Optional.IsDefined(value.PromotionCode))
            {
                writer.WritePropertyName("promotionCode");
                writer.WriteStringValue(value.PromotionCode);
            }
            if (Optional.IsDefined(value.Version))
            {
                writer.WritePropertyName("version");
                writer.WriteStringValue(value.Version);
            }
            writer.WriteEndObject();
        }

        /// <summary>
        /// Deserialize the input Json object.
        /// </summary>
        /// <param name="element"> The Json object need to be deserialized. </param>
        internal static Plan Deserialize(JsonElement element)
        {
            Optional<string> name = default;
            Optional<string> publisher = default;
            Optional<string> product = default;
            Optional<string> promotionCode = default;
            Optional<string> version = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("publisher"))
                {
                    publisher = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("product"))
                {
                    product = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("promotionCode"))
                {
                    promotionCode = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("version"))
                {
                    version = property.Value.GetString();
                    continue;
                }
            }
            return new Plan(name.Value, publisher.Value, product.Value, promotionCode.Value, version.Value);
        }
    }
}
