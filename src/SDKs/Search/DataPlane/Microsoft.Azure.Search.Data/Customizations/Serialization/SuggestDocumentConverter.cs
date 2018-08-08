// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Serialization
{
    using System;
    using System.Reflection;
    using Microsoft.Azure.Search.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    /// Deserializes SuggestResult instances from OData-compliant JSON.
    /// </summary>
    /// <typeparam name="TDoc">
    /// The CLR type that maps to the index schema. Instances of this type can be stored as documents in the index.
    /// </typeparam>
    internal class SuggestDocumentConverter<TDoc> : JsonConverter
        where TDoc : class
    {
        public override bool CanRead
        {
            get
            {
                return true;
            }
        }

        public override bool CanWrite
        {
            get
            {
                return false;
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(SuggestDocument).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }

        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            var result = new SuggestDocument();

            JObject propertyBag = serializer.Deserialize<JObject>(reader);
            JToken text = propertyBag["@search.text"];

            result.Text = text.Value<string>();

            var docReader = new JTokenReader(propertyBag);
            result.Document = serializer.Deserialize<TDoc>(docReader);
            return result;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
