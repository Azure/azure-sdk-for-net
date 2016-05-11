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
using Microsoft.Azure.Management.MachineLearning.WebServices.Models;
using Microsoft.Rest;
using Newtonsoft.Json;

namespace Microsoft.Azure.Management.MachineLearning.WebServices.Util
{
    public static class ModelsSerializationUtil
    {
        private static readonly AzureMLWebServicesManagementClient AmlClient = new AzureMLWebServicesManagementClient(new TokenCredentials("random"));

        public static WebService GetAzureMLWebServiceFromJsonDefinition(string jsonDefinition)
        {
            const string ParamName = nameof(jsonDefinition);

            if (string.IsNullOrWhiteSpace(jsonDefinition))
            {
                throw new ArgumentException(@"The Azure ML web service definition is not specified.", ParamName);
            }

            return JsonConvert.DeserializeObject<WebService>(jsonDefinition, ModelsSerializationUtil.AmlClient.DeserializationSettings);
        }

        public static string GetAzureMLWebServiceDefinitionJsonFromObject(WebService webService)
        {
            if (webService == null)
            {
                throw new ArgumentNullException(nameof(webService));
            }

            return JsonConvert.SerializeObject(webService, ModelsSerializationUtil.AmlClient.SerializationSettings);
        }
    }
}
