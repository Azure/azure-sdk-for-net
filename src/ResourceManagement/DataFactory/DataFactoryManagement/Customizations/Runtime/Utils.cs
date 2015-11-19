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
using System;
using System.Collections.Generic;

namespace Microsoft.Azure.Management.DataFactories.Runtime
{
    internal static class Utils
    {
        private static readonly LinkedServiceConverter LinkedServiceConverter = GetLinkedServiceConverter();
        private static readonly DatasetConverter DatasetConverter = GetDatasetConverter();
        private static readonly PipelineConverter PipelineConverter = GetPipelineConverter();

        internal static JsonConverter[] GetAllConverters()
        {
            return new JsonConverter[] { LinkedServiceConverter, PipelineConverter, DatasetConverter };
        }

        internal static JsonConverter[] GetConverters(
            bool includelinkedServiceConverter = false,
            bool includeDatasetConverter = false,
            bool includePipelineConverter = false)
        {
            var converters = new List<JsonConverter>();

            if (includelinkedServiceConverter)
            {
                converters.Add(LinkedServiceConverter);
            }

            if (includeDatasetConverter)
            {
                converters.Add(DatasetConverter);
            }

            if (includePipelineConverter)
            {
                converters.Add(PipelineConverter);
            }

            return converters.ToArray();
        }
        
        private static LinkedServiceConverter GetLinkedServiceConverter()
        {
            return new LinkedServiceConverter();
        }

        private static DatasetConverter GetDatasetConverter()
        {
            return new DatasetConverter();
        }

        private static PipelineConverter GetPipelineConverter()
        {
            return new PipelineConverter();
        }

        public static ActivityConfiguration GetActivityConfiguration(string configuration)
        {
            JsonSerializerSettings settings = ConversionCommon.DefaultSerializerSettings;
            settings.MissingMemberHandling = MissingMemberHandling.Ignore;

            foreach (JsonConverter jsonConverter in Utils.GetConverters(true, true, true))
            {
                settings.Converters.Add(jsonConverter);
            }

            ActivityConfiguration activityConfiguration = JsonConvert.DeserializeObject<ActivityConfiguration>(configuration, settings);
            return activityConfiguration;
        }
    }
}
