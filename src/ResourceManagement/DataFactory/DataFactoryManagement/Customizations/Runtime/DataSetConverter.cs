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

using Microsoft.Azure.Management.DataFactories.Conversion;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;

namespace Microsoft.Azure.Management.DataFactories.Runtime
{
    internal sealed class DataSetConverter : JsonConverter
    {
        private const string TableToken = "table";
        private const string LinkedServiceToken = "linkedService";

        private TableConverter tableConverter;
        private LinkedServiceConverter linkedServiceConverter;

        public DataSetConverter()
        {
            tableConverter = new TableConverter();
            linkedServiceConverter = new LinkedServiceConverter();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(DataSet);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            DataSet dataSet = new DataSet();

            JObject jObject = JObject.Load(reader);
            JToken tableJToken;
            JToken linkedServiceJToken;

            if (jObject.TryGetValue(TableToken, StringComparison.OrdinalIgnoreCase, out tableJToken))
            {
                Core.Models.Table internalTable = Core.DataFactoryManagementClient.DeserializeInternalTableJson(tableJToken.ToString());
                dataSet.Table = tableConverter.ToWrapperType(internalTable);
            }

            if (jObject.TryGetValue(LinkedServiceToken, StringComparison.OrdinalIgnoreCase, out linkedServiceJToken))
            {
                Core.Models.LinkedService internalLinkedService = Core.DataFactoryManagementClient.DeserializeInternalLinkedServiceJson(linkedServiceJToken.ToString());
                dataSet.LinkedService = linkedServiceConverter.ToWrapperType(internalLinkedService);
            }

            return dataSet;
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
