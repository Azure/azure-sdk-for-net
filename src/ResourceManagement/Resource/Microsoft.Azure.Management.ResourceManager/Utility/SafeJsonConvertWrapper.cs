// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.
//
// This is a wrapper class for Microsoft.Rest.Serialization.SafeJsonConvert. We create this class to support string values to
// Deployment.Properties.Template and Deployment.Properties.Parameters. The string values must be valid JSON payloads for tempalte
// and parameters respectively. 
//

namespace Microsoft.Azure.Management.ResourceManager
{
    using Microsoft.Azure.Management.ResourceManager.Models;
    using Microsoft.Rest;
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
                        try
                        {
                            deployment.Properties.Template = JObject.Parse((string)deployment.Properties.Template);
                        }
                        catch (JsonException ex)
                        {
                            throw new SerializationException("Unable to serialize template.", ex);
                        }
                    }
                    if (deployment.Properties.Parameters is string)
                    {
                        try
                        {
                            var templateParameters = JObject.Parse((string)deployment.Properties.Parameters);

                            if (templateParameters["$schema"] != null && templateParameters["parameters"] != null)
                            {
                                deployment.Properties.Parameters = templateParameters["parameters"];
                            }
                        }
                        catch (JsonException ex)
                        {
                            throw new SerializationException("Unable to serialize template parameters.", ex);
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
