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
using System.Collections.ObjectModel;

namespace Microsoft.Azure.Management.DataFactories.Runtime
{
    internal sealed class ActivityConfigurationConverter : JsonConverter
    {
        private const string TableToken = "table";
        private const string LinkedServiceToken = "linkedService";
        private const string PipelineToken = "pipeline";
        private const string InputsToken = "inputs";
        private const string OutputsToken = "outputs";

        private DatasetConverter datasetConverter;
        private LinkedServiceConverter linkedServiceConverter;
        private PipelineConverter pipelineConverter;

        public ActivityConfigurationConverter()
        {
            this.datasetConverter = new DatasetConverter();
            linkedServiceConverter = new LinkedServiceConverter();
            pipelineConverter = new PipelineConverter();
        }

        public override bool CanConvert(Type objectType)
        {
            return objectType == typeof(ActivityConfiguration);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            Collection<ResolvedTable> inputs = new Collection<ResolvedTable>();
            Collection<ResolvedTable> outputs = new Collection<ResolvedTable>();

            ActivityConfiguration activityConfiguration = new ActivityConfiguration();

            JObject jObject = JObject.Load(reader);
            JToken inputsJToken;
            JToken outputsJToken;
            JToken pipelineJToken;

            if (jObject.TryGetValue(InputsToken, StringComparison.OrdinalIgnoreCase, out inputsJToken))
            {
                activityConfiguration.Inputs = inputs;
                foreach (JObject resolvedTable in inputsJToken.Children<JObject>())
                {
                    inputs.Add(GetResolvedTable(resolvedTable));
                }
            }

            if (jObject.TryGetValue(OutputsToken, StringComparison.OrdinalIgnoreCase, out outputsJToken))
            {
                activityConfiguration.Outputs = outputs;
                foreach (JObject resolvedTable in outputsJToken.Children<JObject>())
                {
                    outputs.Add(GetResolvedTable(resolvedTable));
                }
            }

            if (jObject.TryGetValue(PipelineToken, StringComparison.OrdinalIgnoreCase, out pipelineJToken))
            {
                activityConfiguration.Pipeline = GetPipeline(pipelineJToken);
            }

            return activityConfiguration;
        }

        private ResolvedTable GetResolvedTable(JObject jObject)
        {
            ResolvedTable resolvedTable = new ResolvedTable();

            JToken datasetJToken;
            JToken linkedServiceJToken;

            if (jObject.TryGetValue(TableToken, StringComparison.OrdinalIgnoreCase, out datasetJToken))
            {
                Core.Models.Dataset internalDataset = Core.DataFactoryManagementClient.DeserializeInternalDatasetJson(datasetJToken.ToString());
                resolvedTable.Dataset = this.datasetConverter.ToWrapperType(internalDataset);
            }

            if (jObject.TryGetValue(LinkedServiceToken, StringComparison.OrdinalIgnoreCase, out linkedServiceJToken))
            {
                Core.Models.LinkedService internalLinkedService = Core.DataFactoryManagementClient.DeserializeInternalLinkedServiceJson(linkedServiceJToken.ToString());
                resolvedTable.LinkedService = linkedServiceConverter.ToWrapperType(internalLinkedService);
            }

            return resolvedTable;
        }

        private Models.Pipeline GetPipeline(JToken jToken)
        {
            Core.Models.Pipeline internalPipeline = Core.DataFactoryManagementClient.DeserializeInternalPipelineJson(jToken.ToString());
            return pipelineConverter.ToWrapperType(internalPipeline);
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
