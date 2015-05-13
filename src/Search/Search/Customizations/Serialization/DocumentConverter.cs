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
using System.Linq;
using Microsoft.Azure.Search.Models;
using Microsoft.Spatial;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Azure.Search.Serialization
{
    /// <summary>
    /// Deserializes JSON objects and arrays to .NET types instead of JObject and JArray.
    /// </summary>
    internal class DocumentConverter : JsonConverter
    {
        private static readonly string[] EmptyStringArray = new string[0];

        public override bool CanRead
        {
            get { return true; }
        }

        public override bool CanWrite
        {
            get { return false; }
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(Document).IsAssignableFrom(objectType);
        }

        public override object ReadJson(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            var result = new Document();
            JObject bag = serializer.Deserialize<JObject>(reader);

            foreach (JProperty field in bag.Properties())
            {
                // Skip OData @search annotations. These are deserialized separately.
                if (field.Name.StartsWith("@search.", StringComparison.Ordinal))
                {
                    continue;
                }

                object value;
                if (field.Value == null)
                {
                    value = null;
                }
                else if (field.Value is JArray)
                {
                    JArray array = (JArray)field.Value;

                    if (array.Count == 0)
                    {
                        // Assume string arrays for now.
                        value = EmptyStringArray;
                    }
                    else
                    {
                        value = array.Select(t => t.Value<string>()).ToArray();
                    }
                }
                else if (field.Value is JObject)
                {
                    var tokenReader = new JTokenReader(field.Value);
                    
                    // Assume GeoPoint for now.
                    value = serializer.Deserialize<GeographyPoint>(tokenReader);
                }
                else
                {
                    value = field.Value.ToObject(typeof(object), serializer);
                }

                result[field.Name] = value;
            }

            return result;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
