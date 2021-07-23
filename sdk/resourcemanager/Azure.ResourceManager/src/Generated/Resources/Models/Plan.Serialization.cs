// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Resources.Models
{
    /// <summary>
    /// Representation of a publisher plan for marketplace RPs.
    /// </summary>
    public sealed partial class Plan : IUtf8JsonSerializable
    {
        /// <summary>
        /// Serialize the input Plan object.
        /// </summary>
        /// <param name="writer"> Input Json writer. </param>
        void IUtf8JsonSerializable.Write(Utf8JsonWriter writer)
        {
            if (writer is null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(Name))
            {
                writer.WritePropertyName("name");
                writer.WriteStringValue(Name);
            }
            if (Optional.IsDefined(Publisher))
            {
                writer.WritePropertyName("publisher");
                writer.WriteStringValue(Publisher);
            }
            if (Optional.IsDefined(Product))
            {
                writer.WritePropertyName("product");
                writer.WriteStringValue(Product);
            }
            if (Optional.IsDefined(PromotionCode))
            {
                writer.WritePropertyName("promotionCode");
                writer.WriteStringValue(PromotionCode);
            }
            if (Optional.IsDefined(Version))
            {
                writer.WritePropertyName("version");
                writer.WriteStringValue(Version);
            }
            writer.WriteEndObject();
        }

        /// <summary>
        /// Deserialize the input Json object.
        /// </summary>
        /// <param name="element"> The Json object need to be deserialized. </param>
        internal static Plan DeserializePlan(JsonElement element)
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
