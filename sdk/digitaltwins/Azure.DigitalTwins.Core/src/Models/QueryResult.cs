// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using Azure.Core.Serialization;

namespace Azure.DigitalTwins.Core
{
    /// <summary>
    /// The results of a query operation.
    /// </summary>
    /// <typeparam name="T">The type of the individual items in the collection.</typeparam>
    internal partial class QueryResult<T>
    {
        /// <summary>
        /// The query results.
        /// </summary>
        internal IReadOnlyList<T> Value { get; }

        /// <summary>
        /// A token which can be used to construct a new QuerySpecification to retrieve the next set of results.
        /// </summary>
        internal string ContinuationToken { get; }

        /// <summary>
        /// Initializes a new instance of QueryResult.
        /// </summary>
        /// <param name="value">The query results.</param>
        /// <param name="continuationToken">A token which can be used to construct a new QuerySpecification to retrieve the next set of results.</param>
        internal QueryResult(IReadOnlyList<T> value, string continuationToken)
        {
            Value = value;
            ContinuationToken = continuationToken;
        }

        /// <summary>
        /// Deserialize the JSON element into a QueryResult instance and deserialize each item in the collection into type <typeparamref name="T"/>.
        /// </summary>
        /// <param name="element">The JSON element to be deserialized into a QueryResult.</param>
        /// <param name="objectSerializer">The object serializer instance used to deserialize the items in the collection.</param>
        /// <param name="defaultObjectSerializer">The out of the box object serializer to interact with the JsonElement (serialize/deserialize into and out of streams).</param>
        /// <returns>A collection of query results deserialized into type <typeparamref name="T"/>.</returns>
        internal static QueryResult<T> DeserializeQueryResult(JsonElement element, ObjectSerializer objectSerializer, ObjectSerializer defaultObjectSerializer)
        {
            IReadOnlyList<T> items = default;
            string continuationToken = default;

            foreach (JsonProperty property in element.EnumerateObject())
            {
                if (property.NameEquals("value"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }

                    var array = new List<T>();

                    foreach (JsonElement item in property.Value.EnumerateArray())
                    {
                        // defaultObjectSerializer of type JsonObjectSerializer needs to be used to serialize the JsonElement into a stream.
                        // Using any other ObjectSerializer (ex: NewtonsoftJsonObjectSerializer) won't be able to deserialize the JsonElement into
                        // a MemoryStream correctly.
                        using MemoryStream streamedObject = StreamHelper.WriteToStream(item, defaultObjectSerializer, default);

                        // To deserialize the stream object into the generic type of T, the provided ObjectSerializer will be used.
                        T obj = (T)objectSerializer.Deserialize(streamedObject, typeof(T), default);
                        array.Add(obj);
                    }

                    items = array;
                    continue;
                }
                if (property.NameEquals("continuationToken"))
                {
                    if (property.Value.ValueKind == JsonValueKind.Null)
                    {
                        continue;
                    }
                    continuationToken = property.Value.GetString();
                    continue;
                }
            }
            return new QueryResult<T>(items, continuationToken);
        }
    }
}
