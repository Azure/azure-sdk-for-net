// 
// Copyright (c) Microsoft.  All rights reserved. 
// 
// Licensed under the Apache License, Version 2.0 (the "License"); 
// you may not use this file except in compliance with the License. 
// You may obtain a copy of the License at 
//   http://www.apache.org/licenses/LICENSE-2.0 
// 
// Unless required by applicable law or agreed to in writing, software 
// distributed under the License is distributed on an "AS IS" BASIS, 
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. 
// See the License for the specific language governing permissions and 
// limitations under the License. 
// 

using System;
using Microsoft.Azure.Search.Models;
using Newtonsoft.Json;

namespace Microsoft.Azure.Search.Serialization
{
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
            return typeof(IndexActionBase<T>).IsAssignableFrom(objectType);
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
                    w.WriteValue(SearchIndexClient.IndexActionTypeToString(action.ActionType));
                };

            serializer.Serialize(injectingWriter, action.Document);
        }
    }
}
