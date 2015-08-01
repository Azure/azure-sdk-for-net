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
using System.Collections.Generic;
using System.Linq;
using Microsoft.Azure.Management.DataFactories.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.Management.DataFactories.Conversion
{
    internal class TypePropertiesConverter : PolymorphicTypeConverter<TypeProperties>
    {
        private readonly CamelCasePropertyNamesContractResolver camelCaseResolver =
            new CamelCasePropertyNamesContractResolver();

        protected override object ReadJsonWrapper(
            JsonReader reader,
            Type objectType,
            object existingValue,
            JsonSerializer serializer)
        {
            JObject obj = JObject.Load(reader);
            TypeProperties target = (TypeProperties)Activator.CreateInstance(objectType);
            serializer.Populate(obj.CreateReader(), target);

            var genericTarget = target as IGenericTypeProperties;
            if (genericTarget == null)
            {
                return target;
            }

            List<string> props = objectType.GetProperties(ConversionCommon.DefaultBindingFlags)
                    .Select(p => this.camelCaseResolver.GetResolvedPropertyName(p.Name))
                    .ToList();

            genericTarget.ServiceExtraProperties = new Dictionary<string, JToken>();
            foreach (KeyValuePair<string, JToken> kvp in obj)
            {
                // Extra properties returned by the server but not present in the client model
                // do not get deserialized; add them after the fact
                if (!props.Contains(this.camelCaseResolver.GetResolvedPropertyName(kvp.Key)))
                {
                    genericTarget.ServiceExtraProperties.Add(kvp.Key, kvp.Value);
                }
            }

            return genericTarget as TypeProperties;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            TypeProperties typeProperties = (TypeProperties)value;
            IDictionary<string, JToken> propertyBag = null;

            var genericTypeProperties = typeProperties as IGenericTypeProperties;
            if (genericTypeProperties != null)
            {
                // Remove properties in the property bag from the object to serialize
                propertyBag = genericTypeProperties.ServiceExtraProperties;
                genericTypeProperties.ServiceExtraProperties = null;
                typeProperties = genericTypeProperties as TypeProperties;
            }
            
            // Remove this converter from the list of converters used for serialization, 
            // otherwise JObject.FromObject() will throw an exception
            serializer.Converters.Remove(this);

            JObject obj = JObject.FromObject(typeProperties, serializer);

            if (propertyBag != null)
            {
                // add the properties that were in the property bag
                foreach (KeyValuePair<string, JToken> property in propertyBag)
                {
                    obj.Add(property.Key, property.Value);
                }
            }

            writer.WriteToken(obj.CreateReader());

            if (genericTypeProperties != null)
            {
                genericTypeProperties.ServiceExtraProperties = propertyBag;
            }
        }
    }
}
