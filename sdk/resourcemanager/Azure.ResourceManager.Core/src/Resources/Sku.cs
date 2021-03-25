// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.Resources.Models;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing SKU for resource
    /// </summary>
    public sealed class Sku : IEquatable<Sku>, IComparable<Sku>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Sku"/> class.
        /// </summary>
        /// <param name="name"> SKU's name. </param>
        /// <param name="tier"> SKU's tier. </param>
        /// <param name="family"> SKU's family. </param>
        /// <param name="size"> SKU's size. </param>
        /// <param name="capacity"> SKU's capacity. </param>
        internal Sku(string name, string tier, string family, string size, long? capacity = null)
        {
            Name = name;
            Tier = tier;
            Family = family;
            Size = size;
            Capacity = capacity;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Sku"/> class.
        /// </summary>
        /// <param name="sku"> The sku to copy from. </param>
        internal Sku(ResourceManager.Resources.Models.Sku sku)
            : this(sku.Name, sku.Tier, sku.Family, sku.Size, sku.Capacity)
        {
        }

        /// <summary>
        /// Gets the Name.
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Gets the Tier.
        /// </summary>
        public string Tier { get; private set; }

        /// <summary>
        /// Gets the Family.
        /// </summary>
        public string Family { get; private set; }

        /// <summary>
        /// Gets the Size.
        /// </summary>
        public string Size { get; private set; }

        /// <summary>
        /// Gets the Capacity.
        /// </summary>
        public long? Capacity { get; private set; }

        /// <summary>
        /// Compares this <see cref="Sku"/> with another instance.
        /// </summary>
        /// <param name="other"> <see cref="Sku"/> object to compare. </param>
        /// <returns> -1 for less than, 0 for equals, 1 for greater than. </returns>
        public int CompareTo(Sku other)
        {
            if (other == null)
                return 1;

            if (object.ReferenceEquals(this, other))
                return 0;

            int compareResult = 0;
            if ((compareResult = string.Compare(Name, other.Name, StringComparison.InvariantCultureIgnoreCase)) == 0 &&
                (compareResult = string.Compare(Family, other.Family, StringComparison.InvariantCultureIgnoreCase)) == 0 &&
                (compareResult = string.Compare(Size, other.Size, StringComparison.InvariantCultureIgnoreCase)) == 0 &&
                (compareResult = string.Compare(Tier, other.Tier, StringComparison.InvariantCultureIgnoreCase)) == 0)
            {
                return Nullable.Compare<long>(Capacity, other.Capacity);
            }

            return compareResult;
        }

        /// <summary>
        /// Compares this <see cref="Sku"/> instance with another object and determines if they are equals.
        /// </summary>
        /// <param name="other"> <see cref="Sku"/> object to compare. </param>
        /// <returns> True if they are equals, otherwise false. </returns>
        public bool Equals(Sku other)
        {
            if (other == null)
                return false;

            if (object.ReferenceEquals(this, other))
                return true;

            return string.Equals(Name, other.Name, StringComparison.InvariantCultureIgnoreCase) &&
                string.Equals(Family, other.Family, StringComparison.InvariantCultureIgnoreCase) &&
                string.Equals(Size, other.Size, StringComparison.InvariantCultureIgnoreCase) &&
                string.Equals(Tier, other.Tier, StringComparison.InvariantCultureIgnoreCase) &&
                long.Equals(Capacity, other.Capacity);
        }

        /// <summary>
        /// Serialize the input Sku object.
        /// </summary>
        /// <param name="writer"> Input Json writer. </param>
        /// <param name="value"> Input Sku object. </param>
        internal static void Serialize(Utf8JsonWriter writer, Sku value)
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
            if (Optional.IsDefined(value.Tier))
            {
                writer.WritePropertyName("tier");
                writer.WriteStringValue(value.Tier);
            }
            if (Optional.IsDefined(value.Size))
            {
                writer.WritePropertyName("size");
                writer.WriteStringValue(value.Size);
            }
            if (Optional.IsDefined(value.Family))
            {
                writer.WritePropertyName("family");
                writer.WriteStringValue(value.Family);
            }
            if (Optional.IsDefined(value.Capacity))
            {
                writer.WritePropertyName("capacity");
                writer.WriteNumberValue(value.Capacity.Value);
            }
            writer.WriteEndObject();
        }

        /// <summary>
        /// Deserialize the input Json object.
        /// </summary>
        /// <param name="element"> The Json object need to be deserialized. </param>
        internal static Sku Deserialize(JsonElement element)
        {
            Optional<string> name = default;
            Optional<string> tier = default;
            Optional<string> size = default;
            Optional<string> family = default;
            Optional<string> model = default;
            Optional<int> capacity = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("name"))
                {
                    name = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("tier"))
                {
                    tier = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("size"))
                {
                    size = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("family"))
                {
                    family = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("model"))
                {
                    model = property.Value.GetString();
                    continue;
                }
                if (property.NameEquals("capacity"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    capacity = property.Value.GetInt32();
                    continue;
                }
            }

            return new Sku(name.Value, tier.Value, family.Value, size.Value, Optional.ToNullable(capacity));
        }
    }
}
