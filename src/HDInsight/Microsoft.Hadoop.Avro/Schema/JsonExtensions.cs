// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.Hadoop.Avro.Schema
{
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Globalization;
    using System.Linq;
    using System.Runtime.Serialization;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;

    /// <summary>
    ///     Extensions for JToken.
    /// </summary>
    internal static class JsonExtensions
    {
        /// <summary>
        ///     Gets the required property.
        /// </summary>
        /// <typeparam name="T">Type of property value.</typeparam>
        /// <param name="token">The token.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>Value of the property.</returns>
        public static T RequiredProperty<T>(this JToken token, string propertyName)
        {
            return ReadProperty<T>(token, propertyName, false);
        }

        /// <summary>
        ///     Gets the optional property.
        /// </summary>
        /// <typeparam name="T">Type of property value.</typeparam>
        /// <param name="token">The token.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <returns>Value of the property.</returns>
        public static T OptionalProperty<T>(this JToken token, string propertyName)
        {
            return ReadProperty<T>(token, propertyName, true);
        }

        /// <summary>
        ///     Gets the required array property.
        /// </summary>
        /// <typeparam name="T">Type of elements.</typeparam>
        /// <param name="token">The token.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="func">The function for property value conversion.</param>
        /// <returns>List of property values.</returns>
        public static List<T> RequiredArrayProperty<T>(this JToken token, string propertyName, Func<JToken, int, T> func)
        {
            return ReadArrayProperty(token, propertyName, false, func);
        }

        /// <summary>
        ///     Gets the optional array property.
        /// </summary>
        /// <typeparam name="T">Type of elements.</typeparam>
        /// <param name="token">The token.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="func">The function for property value conversion.</param>
        /// <returns>List of property values.</returns>
        public static List<T> OptionalArrayProperty<T>(this JToken token, string propertyName, Func<JToken, int, T> func)
        {
            return ReadArrayProperty(token, propertyName, true, func);
        }

        /// <summary>
        ///     Gets the attributes that are not in specified set.
        /// </summary>
        /// <param name="obj">The JSON object.</param>
        /// <param name="attributes">The attributes.</param>
        /// <returns>Set of additional attributes.</returns>
        public static Dictionary<string, string> GetAttributesNotIn(this JObject obj, HashSet<string> attributes)
        {
            if (obj == null)
            {
                throw new ArgumentNullException("obj");
            }

            if (attributes == null)
            {
                throw new ArgumentNullException("attributes");
            }

            var result = new Dictionary<string, string>();

            obj.Children<JProperty>()
               .Where(child => !attributes.Contains(child.Name))
               .ToList()
               .ForEach(child => result.Add(child.Name, child.Value.ToString()));

            return result;
        }

        /// <summary>
        ///     Reads the property.
        /// </summary>
        /// <typeparam name="T">Type of the property.</typeparam>
        /// <param name="token">The token.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="isOptional">
        ///     If set to <c>true</c> the property [is optional].
        /// </param>
        /// <returns>Property value.</returns>
        /// <exception cref="System.Runtime.Serialization.SerializationException">Thrown when property can not be parsed properly.</exception>
        private static T ReadProperty<T>(JToken token, string propertyName, bool isOptional)
        {
            if (token == null)
            {
                throw new ArgumentNullException("token");
            }

            if (propertyName == null)
            {
                throw new ArgumentNullException("propertyName");
            }

            JToken value = token[propertyName];
            if (value == null)
            {
                if (isOptional)
                {
                    return default(T);
                }
                throw new SerializationException(
                    string.Format(CultureInfo.InvariantCulture, "Property with name '{0}' does not exist.", propertyName));
            }

            return value.Value<T>();
        }

        /// <summary>
        ///     Reads the array property.
        /// </summary>
        /// <typeparam name="T">Type of property.</typeparam>
        /// <param name="token">The token.</param>
        /// <param name="propertyName">Name of the property.</param>
        /// <param name="isOptional">
        ///     If set to <c>true</c> the property [is optional].
        /// </param>
        /// <param name="func">The function.</param>
        /// <returns>List of values.</returns>
        /// <exception cref="System.Runtime.Serialization.SerializationException">Thrown when property can not be parsed properly.</exception>
        private static List<T> ReadArrayProperty<T>(JToken token, string propertyName, bool isOptional, Func<JToken, int, T> func)
        {
            if (token == null)
            {
                throw new ArgumentNullException("token");
            }

            if (propertyName == null)
            {
                throw new ArgumentNullException("propertyName");
            }

            if (func == null)
            {
                throw new ArgumentNullException("func");
            }

            var result = new List<T>();

            JToken value = token[propertyName];
            if (value == null)
            {
                if (isOptional)
                {
                    return result;
                }

                throw new SerializationException(
                    string.Format(CultureInfo.InvariantCulture, "Property with name '{0}' does not exist.", propertyName));
            }

            if (value.Type != JTokenType.Array)
            {
                throw new SerializationException(
                    string.Format(CultureInfo.InvariantCulture, "Property with name '{0}' has invalid value.", propertyName));
            }

            return value.Children().Select(func).ToList();
        }

        /// <summary>
        ///     Writes the optional property.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public static void WriteOptionalProperty(this JsonTextWriter writer, string name, string value)
        {
            if (!string.IsNullOrEmpty(value))
            {
                writer.WritePropertyName(name);
                writer.WriteValue(value);
            }
        }

        /// <summary>
        ///     Writes the optional property.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="name">The name.</param>
        /// <param name="collection">The collection.</param>
        public static void WriteOptionalProperty(this JsonTextWriter writer, string name, ICollection<string> collection)
        {
            if (collection.Count != 0)
            {
                writer.WritePropertyName(name);
                writer.WriteStartArray();
                foreach (var item in collection)
                {
                    writer.WriteValue(item);
                }
                writer.WriteEndArray();
            }
        }

        /// <summary>
        ///     Writes the property.
        /// </summary>
        /// <typeparam name="T">Type of property.</typeparam>
        /// <param name="writer">The writer.</param>
        /// <param name="name">The name.</param>
        /// <param name="value">The value.</param>
        public static void WriteProperty<T>(this JsonTextWriter writer, string name, T value)
        {
            writer.WritePropertyName(name);
            writer.WriteValue(value);
        }
    }
}
