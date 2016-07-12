// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

namespace Microsoft.Azure.Management.ResourceManager
{
    using Microsoft.Azure.Management.ResourceManager.Models;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    public static class SafeJsonConvert
    {
        public static string SerializeObject(object obj, JsonSerializerSettings settings)
        {
            if (obj != null && obj is Deployment)
            {
                Deployment deployment = (Deployment)obj;

                if (deployment.Properties != null)
                {
                    if (deployment.Properties.Template is string)
                    {
                        deployment.Properties.Template = JObject.Parse((string)deployment.Properties.Template);
                    }
                    if (deployment.Properties.Parameters is string)
                    {
                        var templateParameters = JObject.Parse((string)deployment.Properties.Parameters);
                        if (templateParameters["$schema"] != null)
                        {
                            deployment.Properties.Parameters = templateParameters["parameters"];
                        }
                    }
                }
            }

            return Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(obj, settings);
        }

        public static string SerializeObject(object obj, params JsonConverter[] converters)
        {
            return Microsoft.Rest.Serialization.SafeJsonConvert.SerializeObject(obj, converters);
        }

        public static T DeserializeObject<T>(string json, params JsonConverter[] converters)
        {
            return Microsoft.Rest.Serialization.SafeJsonConvert.DeserializeObject<T>(json, converters);
        }

        public static T DeserializeObject<T>(string json, JsonSerializerSettings settings)
        {
            return Microsoft.Rest.Serialization.SafeJsonConvert.DeserializeObject<T>(json, settings);
        }

    }
}
