// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

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
