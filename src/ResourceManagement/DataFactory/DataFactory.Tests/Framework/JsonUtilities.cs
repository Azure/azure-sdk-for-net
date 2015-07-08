// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace DataFactory.Tests.Framework
{
    /// <summary>
    /// Misc utilities that facilitate working with JSON.
    /// </summary>
    public static class JsonUtilities
    {
        // JSON.NET uses case-insensitive property name deserialization. These fields are used by the custom
        // deserialization logic to replicate (be consistent with) this behavior.
        // These two fields should match (i.e. don't change one without changing the other).
        public const StringComparison PropertyNameComparison = StringComparison.OrdinalIgnoreCase;
        public static StringComparer PropertyNameComparer = StringComparer.OrdinalIgnoreCase;

        /// <summary>
        /// Type property name required by Hydra to resolve polymorphic property types.
        /// Appears in our user-facing JSON.
        /// </summary>
        public const string Type = "type";

        public const string HubName = "hubName";

        public const string ExtendedProperties = "extendedProperties";

        /// <summary>
        /// ReferenceId (id) is the property identifying the resource entity. 
        /// Appears in our user-facing JSON on GET calls.
        /// </summary>
        public const string ReferenceId = "id";

        /// <summary>
        /// Type property name, optionally used by JSON.NET to resolve polymorphic property types. 
        /// For internal use only, does not appear in our user-facing JSON.
        /// </summary>
        public const string JsonDotNetType = "$type";

        public const string PropertyNameProperties = "Properties";
        public const string TypePropertyNameProperties = "TypeProperties";
        public const string ExtendedPropertyNameProperties = "ExtendedProperties";
        public const string PropertyNameActivities = "Activities";
        public const string PropertyNameName = "Name";
        public const string PropertyNameId = "Id";
        public const string PropertyNameDescription = "Description";

        public const string EncryptedStringSentinel = "$EncryptedString$";

        public static JsonSerializerSettings Settings = new JsonSerializerSettings()
        {
            MissingMemberHandling = MissingMemberHandling.Error,// Throw an error if the JSON includes invalid tokens that are not a part of the object.
            Formatting = Formatting.Indented, // indenting makes the JSON easier to read for manual troubleshooting.
            ContractResolver = new CamelCasePropertyNamesContractResolver(),
            NullValueHandling = NullValueHandling.Ignore
        };

        /// <summary>
        /// Moves the tokens with the given names from the source to the target.
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <param name="tokenNames"></param>
        public static void MoveJTokens(JObject source, JObject target, params string[] tokenNames)
        {
            foreach (string tokenName in tokenNames)
            {
                JToken token = GetAndRemoveJToken(source, tokenName);
                if (token != null)
                {
                    target.Add(((JProperty)token.Parent).Name, token);
                }
            }
        }

        /// <summary>
        /// Returns the JToken inside of the given JObject with the given name, removing
        /// it from the JObject. Returns null if not found.
        /// </summary>
        /// <param name="jObject"></param>
        /// <param name="tokenName"></param>
        /// <returns></returns>
        public static JToken GetAndRemoveJToken(JObject jObject, string tokenName)
        {
            JToken token;
            if (jObject.TryGetValue(tokenName, PropertyNameComparison, out token))
            {
                token.Parent.Remove();
            }
            return token;
        }

        /// <summary>
        /// Returns the JToken (cast to a JObject) inside of the given JObject with the given name, removing
        /// it from the JObject. Returns null if not found. Throws an error if the JToken is not a JObject
        /// </summary>
        /// <param name="jObject"></param>
        /// <param name="tokenName"></param>
        /// <returns></returns>
        public static JObject GetAndRemoveJObject(JObject jObject, string tokenName)
        {
            JToken token = GetAndRemoveJToken(jObject, tokenName);
            if (token != null && token.Type != JTokenType.Object)
            {
                throw new JsonSerializationException(
                    "Token " + tokenName + " is of type " + token.Type + ", but JObject was expected");
            }

            return token as JObject;
        }

        /// <summary>
        /// Returns the DataMember property info of the given type.
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<Tuple<PropertyInfo, DataMemberAttribute>> GetDataMemberPropertyInfo(Type type)
        {
            var result = new List<Tuple<PropertyInfo, DataMemberAttribute>>();
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Instance | BindingFlags.Public | BindingFlags.GetProperty);

            foreach (PropertyInfo property in properties)
            {
                DataMemberAttribute dataMemberAttribute = (DataMemberAttribute)property.GetCustomAttributes(true).FirstOrDefault(ca => ca is DataMemberAttribute);

                if (dataMemberAttribute != null)
                {
                    result.Add(new Tuple<PropertyInfo, DataMemberAttribute>(property, dataMemberAttribute));
                }
            }

            return result;
        }

        /// <summary>
        /// Returns the DataMamber property names of the given type.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public static IEnumerable<string> GetDataMemberPropertyNames(Type type)
        {
            return GetDataMemberPropertyInfo(type).Select(prop => prop.Item1.Name);
        }

        /// <summary>
        /// Returns the given property name, applying to it any transforms specified by 
        /// the given serializer's settings (i.e. converting it to camelCase).
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="serializer"></param>
        /// <returns></returns>
        public static string GetPropertyName(string propertyName, JsonSerializer serializer)
        {
            if (!string.IsNullOrEmpty(propertyName) && serializer != null
                && serializer.ContractResolver is CamelCasePropertyNamesContractResolver)
            {
                propertyName = GetCamelCaseString(propertyName);
            }

            return propertyName;
        }

        /// <summary>
        /// Returns the given property name, applying to it any transforms specified by 
        /// the given serializer's settings (i.e. converting it to camelCase).
        /// </summary>
        /// <param name="propertyName"></param>
        /// <param name="serializerSettings"></param>
        /// <returns></returns>
        public static string GetPropertyName(string propertyName, JsonSerializerSettings serializerSettings)
        {
            if (!string.IsNullOrEmpty(propertyName) && serializerSettings != null
                && serializerSettings.ContractResolver is CamelCasePropertyNamesContractResolver)
            {
                propertyName = GetCamelCaseString(propertyName);
            }

            return propertyName;
        }

        private static string GetCamelCaseString(string propertyName)
        {
            if (!string.IsNullOrEmpty(propertyName))
            {
                // Change the property name to camelCase.
                char[] chars = propertyName.ToCharArray();
                chars[0] = char.ToLower(chars[0], CultureInfo.CurrentCulture);
                return new string(chars);
            }

            return propertyName;
        }

        /// <summary>
        /// Writes to the given writer the given property names, transformed as appropriate according to the
        /// given serializer's settings (i.e. converted to camelCase).
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="propertyName"></param>
        /// <param name="serializer"></param>
        public static void WritePropertyName(JsonWriter writer, string propertyName, JsonSerializer serializer)
        {
            propertyName = GetPropertyName(propertyName, serializer);
            writer.WritePropertyName(propertyName);
        }

        /// <summary>
        /// Returns whether the given property value is non-default. For an IEnumerable, null and empty are both considered defaults.
        /// </summary>
        /// <param name="propertyValue"></param>
        /// <returns></returns>
        public static bool PropertyHasNonDefaultValue<T>(T propertyValue)
        {
            return PropertyHasNonDefaultValue(typeof(T), propertyValue);
        }

        /// <summary>
        /// Returns whether the given property value is non-default. For an IEnumerable, null and empty are both considered defaults.
        /// </summary>
        /// <param name="propertyType"></param>
        /// <param name="propertyValue"></param>
        /// <returns></returns>
        private static bool PropertyHasNonDefaultValue(Type propertyType, object propertyValue)
        {
            if (propertyValue == null || propertyValue.Equals(GetDefaultValue(propertyType)))
            {
                return false;
            }

            // If the value is polymorphic, consider it to be non-default 
            // (even if it doesn't contain properties with non-default values).
            if (!propertyType.IsInterface && propertyType != propertyValue.GetType())
            {
                return true;
            }

            IEnumerable enumerableValue = propertyValue as IEnumerable;
            if (enumerableValue == null)
            {
                // Check nested properties for non-default values.
                if (propertyType.IsClass)
                {
                    IEnumerable<PropertyInfo> childProperties =
                        GetDataMemberPropertyInfo(propertyValue.GetType()).Select(tuple => tuple.Item1);

                    foreach (PropertyInfo childPropertyInfo in childProperties)
                    {
                        object childPropertyValue = childPropertyInfo.GetValue(propertyValue, null);
                        if (PropertyHasNonDefaultValue(childPropertyInfo.PropertyType, childPropertyValue))
                        {
                            return true;
                        }
                    }
                    return false;
                }
            }
            else
            {
                // See if the IEnumerable has any members
                return enumerableValue.Cast<object>().Any();
            }

            return true;
        }


        private static object GetDefaultValue(Type type)
        {
            return type.IsValueType ? Activator.CreateInstance(type) : null;
        }

        public static void WriteReferenceId(
            JsonWriter writer,
            string referenceIdBase,
            string resourceType,
            string resourceName,
            JsonSerializer serializer)
        {
            if (!string.IsNullOrEmpty(referenceIdBase))
            {
                WriteReferenceId(
                    writer,
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "{0}/{1}/{2}",
                        referenceIdBase,
                        resourceType,
                        resourceName),
                    serializer);
            }
        }

        public static void WriteReferenceId(JsonWriter writer, string referenceId, JsonSerializer serializer)
        {
            if (!string.IsNullOrEmpty(referenceId))
            {
                WritePropertyName(writer, ReferenceId, serializer);
                writer.WriteValue(referenceId);
            }
        }

        /// <summary>
        /// Returns whether the given type name matches the given short type name (should be a const) with or without the long namespace prefix. 
        /// </summary>
        /// <param name="actualTypeName"></param>
        /// <param name="shortTypeName"></param>
        /// <returns></returns>
        public static bool IsTypeNameMatch(string actualTypeName, string shortTypeName)
        {
            return string.Equals(actualTypeName, shortTypeName, JsonUtilities.PropertyNameComparison);
        }

        /// <summary>
        /// Writes the given type name, prefaced with the long namespace prefix.
        /// </summary>
        /// <param name="writer"></param>
        /// <param name="shortTypeName"></param>
        /// <param name="serializer"></param>
        public static void WriteTypeName(JsonWriter writer, string shortTypeName, JsonSerializer serializer)
        {
            JsonUtilities.WritePropertyName(writer, JsonUtilities.Type, serializer);
            writer.WriteValue(shortTypeName);
        }
    }
}
