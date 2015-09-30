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
using Microsoft.Azure.Management.DataFactories.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.Management.DataFactories.Conversion
{
    internal abstract class PolymorphicTypeConverter<T> : JsonConverter
    {
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            try
            {
                return this.ReadJsonWrapper(reader, objectType, existingValue, serializer);
            }
            catch (Exception)
            {
                // Suppress any exception during deserialization; 
                // we should assume that the service sends back valid JSON, 
                // so return null if there is any problem deserializing.
                return null;
            }
        }

        protected abstract object ReadJsonWrapper(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer);

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            JObject obj = JObject.FromObject(
                value,
                new JsonSerializer()
                    {
                        NullValueHandling = NullValueHandling.Ignore,
                        MissingMemberHandling = MissingMemberHandling.Ignore,
                        ContractResolver = new CamelCasePropertyNamesContractResolver()
                    });
 
            string typeName = GetTypeName(value.GetType());
            obj.Add(DataFactoryConstants.KeyPolymorphicType, new JValue(typeName));
            
            writer.WriteToken(obj.CreateReader());
        }

        public override bool CanConvert(Type objectType)
        {
            return typeof(T).IsAssignableFrom(objectType);
        }

        /// <summary>
        /// Get a name to use during serialization of a type. 
        /// </summary>
        /// <param name="type">The type to get a name for.</param>
        /// <returns>The name to use during serialization for <paramref name="type"/>.</returns>
        protected static string GetTypeName(Type type)
        {
            object typeNameAttribute = type.GetCustomAttributes(typeof(AdfTypeNameAttribute), true).FirstOrDefault();
            if (typeNameAttribute != null)
            {
                return ((AdfTypeNameAttribute)typeNameAttribute).TypeName;
            }

            return type.Name;
        }
    }
}
