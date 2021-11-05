// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Azure.Core;
using Azure.Core.Serialization;

namespace Azure.DigitalTwins.Core
{
    /// <summary>
    /// A collection of relationships which relate digital twins together.
    /// </summary>
    /// <typeparam name="T">The type of the individual items in the collection.</typeparam>
    internal class RelationshipCollection<T>
    {
        /// <summary>
        /// The relationship items.
        /// </summary>
        internal IReadOnlyList<T> Value { get; }

        /// <summary>
        /// A URI to retrieve the next page of relationships.
        /// </summary>
        internal string NextLink { get; }

        /// <summary>
        /// Initializes a new instance of RelationshipColletion.
        /// </summary>
        internal RelationshipCollection()
        {
            Value = new ChangeTrackingList<T>();
        }

        /// <summary>
        /// Initializes a new instance of RelationshipCollection.
        /// </summary>
        /// <param name="value">The relationship objects.</param>
        /// <param name="nextLink">A URI to retrieve the next page of relationships.</param>
        internal RelationshipCollection(IReadOnlyList<T> value, string nextLink)
        {
            Value = value;
            NextLink = nextLink;
        }

        /// <summary>
        /// Deserialize the JSON element into a RelationshipCollection instance and deserialize each item in the collection into type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="element">The JSON element to be deserialized into a RelationshipCollection.</param>
        /// <param name="objectSerializer">The object serializer instance used to deserialize the items in the collection.</param>
        /// <returns>A collection of relationships deserialized into type <typeparamref name="T"/>.</returns>
        internal static RelationshipCollection<T> DeserializeRelationshipCollection(JsonElement element, ObjectSerializer objectSerializer)
        {
            Optional<IReadOnlyList<T>> value = default;
            Optional<string> nextLink = default;
            foreach (JsonProperty property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        property.ThrowNonNullablePropertyIsNull();
                        continue;
                    }
                    var array = new List<T>();
                    foreach (JsonElement item in property.Value.EnumerateArray())
                    {
                        using MemoryStream streamedObject = StreamHelper.WriteToStream(item, objectSerializer, default);
                        T obj = (T)objectSerializer.Deserialize(streamedObject, typeof(T), default);
                        array.Add(obj);
                    }
                    value = array;
                    continue;
                }
                if (property.NameEquals("nextLink"))
                {
                    nextLink = property.Value.GetString();
                    continue;
                }
            }
            return new RelationshipCollection<T>(Optional.ToList(value), nextLink.Value);
        }
    }
}
