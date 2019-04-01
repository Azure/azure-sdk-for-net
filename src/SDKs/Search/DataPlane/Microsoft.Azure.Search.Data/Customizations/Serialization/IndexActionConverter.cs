// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Search.Serialization
{
    using System;
    using System.Reflection;
    using Microsoft.Azure.Search.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Converters;

    /// <summary>
    /// Serializes IndexAction instances so that the JSON is OData-compliant.
    /// </summary>
    /// <typeparam name="T">
    /// The CLR type that maps to the index schema. Instances of this type can be stored as documents in the index.
    /// </typeparam>
    internal class IndexActionConverter<T> : JsonConverter where T : class
    {
        public override bool CanRead
        {
            get
            {
                return false;
            }
        }

        public override bool CanWrite
        {
            get
            {
                return true;
            }
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(IndexActionBase<T>).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }

        public override object ReadJson(
            JsonReader reader, 
            Type objectType, 
            object existingValue, 
            JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            var action = (IndexActionBase<T>)value;

            var injectingWriter = new InjectingJsonWriter(writer);
            injectingWriter.OnStart = 
                w =>
                {
                    w.WritePropertyName("@search.action");

                    var converter = new StringEnumConverter();
                    converter.WriteJson(w, action.ActionType, serializer);
                };

            serializer.Serialize(injectingWriter, action.Document);
        }
    }
}
