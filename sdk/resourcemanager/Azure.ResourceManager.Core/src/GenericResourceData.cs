// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Text.Json;
using Azure.Core;

namespace Azure.ResourceManager.Core
{
    /// <summary>
    /// A class representing the generic azure resource data model.
    /// </summary>
    public class GenericResourceData : TrackedResource<ResourceManager.Resources.Models.GenericResource>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GenericResourceData"/> class.
        /// </summary>
        /// <param name="genericResource"> The existing resource model to copy from. </param>
        /// <exception cref="ArgumentNullException">
        ///     <paramref name="genericResource"/> is null.
        /// </exception>
        public GenericResourceData(ResourceManager.Resources.Models.GenericResource genericResource)
            : base(genericResource.Id, genericResource.Location, genericResource)
        {
            if (genericResource is null)
                throw new ArgumentNullException(nameof(genericResource));

            Tags = new Dictionary<string, string>(StringComparer.InvariantCultureIgnoreCase);
            Tags.ReplaceWith(genericResource.Tags);

            if (Model.Sku != null)
                Sku = new Sku(Model.Sku);

            if (Model.Plan != null)
                Plan = new Plan(Model.Plan);

            Kind = Model.Kind;
            ManagedBy = Model.ManagedBy;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericResourceData"/> class.
        /// </summary>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        public GenericResourceData(ResourceIdentifier id)
            : base(id, LocationData.Default, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="GenericResourceData"/> class.
        /// </summary>
        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        /// <param name="location"> The location of the resource. </param>
        public GenericResourceData(ResourceIdentifier id, LocationData location)
            : base(id, location, null)
        {
        }

        /// <inheritdoc/>
        public override ResourceIdentifier Id { get; protected set; }

        /// <summary>
        /// Gets or sets who this resource is managed by.
        /// </summary>
        public string ManagedBy { get; set; }

        /// <summary>
        /// Gets or sets the sku.
        /// </summary>
        public Sku Sku { get; set; }

        /// <summary>
        /// Gets or sets the plan.
        /// </summary>
        public Plan Plan { get; set; }

        /// <summary>
        /// Gets or sets the kind.
        /// </summary>
        public string Kind { get; set; }

        /// <summary>
        /// Gets the Tags.
        /// </summary>
        public override IDictionary<string, string> Tags { get; }

        /// <summary>
        /// Converts from a <see cref="GenericResourceData"/> into the ResourceManager.Resources.Models.GenericResource.
        /// </summary>
        /// <param name="other"> The tracked resource convert from. </param>
        public static implicit operator ResourceManager.Resources.Models.GenericResource(GenericResourceData other)
        {
            if (other is null)
                return null;

            // Temp code. Following block will be removed
            other.Model.Tags.Clear();
            foreach (var tag in other.Tags)
            {
                other.Model.Tags.Add(tag);
            }

            return other.Model;
        }

        /// <summary>
        /// Serialize the input Sku object.
        /// </summary>
        /// <param name="writer"> Input Json writer. </param>
        /// <param name="value"> Input GenericResourceData object. </param>
        internal static void Serialize(Utf8JsonWriter writer, GenericResourceData value)
        {
            if (writer is null)
            {
                throw new ArgumentNullException(nameof(writer));
            }

            writer.WriteStartObject();
            if (Optional.IsDefined(value.Location))
            {
                writer.WritePropertyName("location");
                writer.WriteStringValue(value.Location);
            }
            if (Optional.IsCollectionDefined(value.Tags))
            {
                writer.WritePropertyName("tags");
                writer.WriteStartObject();
                foreach (var item in value.Tags)
                {
                    writer.WritePropertyName(item.Key);
                    writer.WriteStringValue(item.Value);
                }
                writer.WriteEndObject();
            }
            writer.WriteEndObject();
        }

        /// <summary>
        /// Deserialize the input Json object.
        /// </summary>
        /// <param name="element"> The Json object need to be deserialized. </param>
        internal static GenericResourceData Deserialize(JsonElement element)
        {
            Optional<ResourceIdentifier> id = default;
            Optional<string> location = default;
            foreach (var property in element.EnumerateObject())
            {
                if (property.NameEquals("id"))
                {
                    id = new ResourceIdentifier(property.Value.GetString());
                    continue;
                }
                if (property.NameEquals("location"))
                {
                    location = property.Value.GetString();
                    continue;
                }
            }
            return new GenericResourceData(id.Value, location.Value);
        }
    }
}
