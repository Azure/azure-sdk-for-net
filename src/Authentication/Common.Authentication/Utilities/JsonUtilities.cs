// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Common.Authentication.Properties;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace Microsoft.Azure.Common.Authentication
{
    public static class JsonUtilities
    {
        [SuppressMessage("Microsoft.Design", "CA1031:DoNotCatchGeneralExceptionTypes", Justification = "Handling the failure by returning the original string.")]
        public static string TryFormatJson(string str)
        {
            try
            {
                object parsedJson = JsonConvert.DeserializeObject(str);
                return JsonConvert.SerializeObject(parsedJson, Formatting.Indented);
            }
            catch
            {
                // can't parse JSON, return the original string
                return str;
            }
        }

        public static Dictionary<string, object> DeserializeJson(string jsonString, bool throwExceptionOnFailure = false)
        {
            Dictionary<string, object> result = new Dictionary<string,object>();
            if (jsonString == null)
            {
                return null;
            }
            if (String.IsNullOrWhiteSpace(jsonString))
            {
                return result;
            }

            try
            {
                JToken responseDoc = JToken.Parse(jsonString);

                if (responseDoc != null && responseDoc.Type == JTokenType.Object)
                {
                    result = DeserializeJObject(responseDoc as JObject);
                }
            }
            catch
            {
                if (throwExceptionOnFailure)
                {
                    throw;
                }
                result = null;
            }
            return result;
        }

        private static Dictionary<string, object> DeserializeJObject(JObject jsonObject)
        {
            Dictionary<string, object> result = new Dictionary<string, object>();
            if (jsonObject == null || jsonObject.Type == JTokenType.Null)
            {
                return result;
            }
            foreach (var property in jsonObject)
            {
                if (property.Value.Type == JTokenType.Object)
                {
                    result[property.Key] = DeserializeJObject(property.Value as JObject);
                }
                else if (property.Value.Type == JTokenType.Array)
                {
                    result[property.Key] = DeserializeJArray(property.Value as JArray);
                }
                else
                {
                    result[property.Key] = DeserializeJValue(property.Value as JValue);
                }
            }
            return result;
        }

        private static List<object> DeserializeJArray(JArray jsonArray)
        {
            List<object> result = new List<object>();
            if (jsonArray == null || jsonArray.Type == JTokenType.Null)
            {
                return result;
            }
            foreach (var token in jsonArray)
            {
                if (token.Type == JTokenType.Object)
                {
                    result.Add(DeserializeJObject(token as JObject));
                }
                else if (token.Type == JTokenType.Array)
                {
                    result.Add(DeserializeJArray(token as JArray));
                }
                else
                {
                    result.Add(DeserializeJValue(token as JValue));
                }
            }
            return result;
        }

        private static object DeserializeJValue(JValue jsonObject)
        {
            if (jsonObject == null || jsonObject.Type == JTokenType.Null)
            {
                return null;
            }
            
            return jsonObject.Value;
        }

        public static string Patch(string originalJsonString, string patchJsonString)
        {
            if (string.IsNullOrWhiteSpace(originalJsonString))
            {
                return patchJsonString;
            }
            else if (string.IsNullOrWhiteSpace(patchJsonString))
            {
                return originalJsonString;
            }

            JToken originalJson = JToken.Parse(originalJsonString);
            JToken patchJson = JToken.Parse(patchJsonString);

            if (originalJson != null && originalJson.Type == JTokenType.Object &&
                patchJson != null && patchJson.Type == JTokenType.Object)
            {
                PatchJObject(originalJson as JObject, patchJson as JObject);
            }
            else if (originalJson != null && originalJson.Type == JTokenType.Array &&
                patchJson != null && patchJson.Type == JTokenType.Array)
            {
                originalJson = patchJson;
            }
            else if (originalJson != null && patchJson != null && originalJson.Type == patchJson.Type)
            {
                originalJson = patchJson;
            }
            else
            {
                throw new ArgumentException(string.Format(Resources.UnableToPatchJson, originalJson, patchJson));
            }

            return originalJson.ToString(Formatting.None);
        }

        private static void PatchJObject(JObject originalJsonObject, JObject patchJsonObject)
        {
            foreach (var patchProperty in patchJsonObject)
            {
                if (originalJsonObject[patchProperty.Key] != null)
                {
                    JToken originalJson = originalJsonObject[patchProperty.Key];
                    JToken patchJson = patchProperty.Value;

                    if (originalJson != null && originalJson.Type == JTokenType.Object &&
                        patchJson != null && patchJson.Type == JTokenType.Object)
                    {
                        PatchJObject(originalJson as JObject, patchJson as JObject);
                    }
                    else if (originalJson != null && originalJson.Type == JTokenType.Array &&
                        patchJson != null && patchJson.Type == JTokenType.Array)
                    {
                        originalJsonObject[patchProperty.Key] = patchJson;
                    }
                    else if (originalJson != null && patchJson != null && originalJson.Type == patchJson.Type)
                    {
                        originalJsonObject[patchProperty.Key] = patchJson;
                    }
                    else
                    {
                        throw new ArgumentException(string.Format(Resources.UnableToPatchJson, originalJson, patchJson));
                    }
                }
                else
                {
                    originalJsonObject[patchProperty.Key] = patchProperty.Value;
                }
            }
        }
    }
}
