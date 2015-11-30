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
using Microsoft.Azure.Management.DataFactories.Conversion;
using Microsoft.Azure.Management.DataFactories.Registration.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Microsoft.Azure.Management.DataFactories.Models
{
    public abstract class TypeProperties : IRegisteredType
    {
        private static readonly DictionaryConverter DictionaryConverter = new DictionaryConverter();

        protected TypeProperties()
        {
        }

        internal static TypeProperties DeserializeObject(string json, Type type)
        {
            return (TypeProperties)JsonConvert.DeserializeObject(
                    json,
                    type,
                    Converters());
        }

        internal string SerializeObject()
        {
            return JsonConvert.SerializeObject(
                this,
                Formatting.Indented,
                new JsonSerializerSettings()
                    {
                        Converters = Converters(), 
                        NullValueHandling = NullValueHandling.Ignore, 
                        ContractResolver = new CamelCasePropertyNamesContractResolver(), 
                        ReferenceLoopHandling = ReferenceLoopHandling.Serialize
                    });
        }

        private static JsonConverter[] Converters()
        {
            return new JsonConverter[]
                       {
                           new TypePropertiesConverter(), DataFactoryManagementClient.CompressionConverter,
                           DataFactoryManagementClient.CopyLocationConverter,
                           DataFactoryManagementClient.CopyTranslatorConverter,
                           DataFactoryManagementClient.PartitionValueConverter,
                           DataFactoryManagementClient.StorageFormatConverter, TypeProperties.DictionaryConverter
                       };
        }
    }
}
