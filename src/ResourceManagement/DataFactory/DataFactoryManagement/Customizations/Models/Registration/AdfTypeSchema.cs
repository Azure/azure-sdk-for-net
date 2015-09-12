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
using Microsoft.Azure.Management.DataFactories.Conversion;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.Management.DataFactories.Registration.Models
{
    /// <summary>
    /// Schema for a registered type.
    /// </summary>
    public class AdfTypeSchema
    {
        /// <summary>
        /// Type-specific properties for the custom type.
        /// </summary>
        public IDictionary<string, AdfSchemaProperty> Properties { get; set; }

        /// <summary>
        /// Name of the required properties for the type.
        /// </summary>
        public IList<string> Required { get; set; }

        /// <summary>
        /// Definition of the references used in type properties.
        /// </summary>
        public IDictionary<string, AdfSchemaProperty> Definitions { get; set; }

        private static readonly Lazy<JsonConverter[]> Converters = new Lazy<JsonConverter[]>(GetConverters);

        public AdfTypeSchema()
        {
            this.Properties = new Dictionary<string, AdfSchemaProperty>();
            this.Required = new List<string>();
            this.Definitions = new Dictionary<string, AdfSchemaProperty>();
        }

        internal static AdfTypeSchema Deserialize(string json)
        {
            return JsonConvert.DeserializeObject<AdfTypeSchema>(json, GetConverters());
        }

        internal string Serialize()
        {
            return JsonConvert.SerializeObject(
                this,
                Formatting.Indented,
                new JsonSerializerSettings()
                    {
                        Converters = AdfTypeSchema.Converters.Value,
                        ContractResolver = new CamelCasePropertyNamesContractResolver(), 
                        NullValueHandling = NullValueHandling.Ignore
                    });
        }
        
        private static JsonConverter[] GetConverters()
        {
            return new JsonConverter[] { new DictionaryConverter() };
        }
    }
}
