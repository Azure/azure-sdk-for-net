// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;
using System.IO;
using Newtonsoft.Json;

namespace Microsoft.Rest.Serialization
{
    /// <summary>
    /// Provides an alternative to JSON.NET's JsonConvert that does not inherit any settings from
    /// JsonConvert.DefaultSettings.
    /// </summary>
    public static class SafeJsonConvert
    {
        /// <summary>
        /// Deserializes the given JSON into an instance of type T.
        /// </summary>
        /// <typeparam name="T">The type to which to deserialize.</typeparam>
        /// <param name="json">The JSON to deserialize.</param>
        /// <param name="settings">JsonSerializerSettings to control deserialization.</param>
        /// <returns>An instance of type T deserialized from the given JSON.</returns>
        public static T DeserializeObject<T>(string json, JsonSerializerSettings settings)
        {
            if (json == null)
            {
                throw new ArgumentNullException("json");
            }

            // Use Create() instead of CreateDefault() here so that our own settings aren't merged with the defaults.  
            var serializer = JsonSerializer.Create(settings);
            serializer.CheckAdditionalContent = true;

            using (var reader = new JsonTextReader(new StringReader(json)))
            {
                return (T)serializer.Deserialize(reader, typeof(T));
            }
        }

        /// <summary>
        /// Deserializes the given JSON into an instance of type T using the given JsonConverters.
        /// </summary>
        /// <typeparam name="T">The type to which to deserialize.</typeparam>
        /// <param name="json">The JSON to deserialize.</param>
        /// <param name="converters">A collection of JsonConverters to control deserialization.</param>
        /// <returns>An instance of type T deserialized from the given JSON.</returns>
        public static T DeserializeObject<T>(string json, params JsonConverter[] converters)
        {
            return DeserializeObject<T>(json, SettingsFromConverters(converters));
        }

        /// <summary>
        /// Serializes the given object into JSON.
        /// </summary>
        /// <param name="obj">The object to serialize.</param>
        /// <param name="settings">JsonSerializerSettings to control serialization.</param>
        /// <returns>A string containing the JSON representation of the given object.</returns>
        public static string SerializeObject(object obj, JsonSerializerSettings settings)
        {
            // Use Create() instead of CreateDefault() here so that our own settings aren't merged with the defaults.  
            var serializer = JsonSerializer.Create(settings);
            var stringWriter = new StringWriter(CultureInfo.InvariantCulture);

            using (var jsonWriter = new JsonTextWriter(stringWriter) { Formatting = serializer.Formatting })
            {
                serializer.Serialize(jsonWriter, obj);
            }

            return stringWriter.ToString();
        }

        /// <summary>
        /// Serializes the given object into JSON using the given JsonConverters.
        /// </summary>
        /// <param name="obj">The object to serialize.</param>
        /// <param name="converters">A collection of JsonConverters to control serialization.</param>
        /// <returns>A string containing the JSON representation of the given object.</returns>
        public static string SerializeObject(object obj, params JsonConverter[] converters)
        {
            return SerializeObject(obj, SettingsFromConverters(converters));
        }

        private static JsonSerializerSettings SettingsFromConverters(JsonConverter[] converters)
        {
            return (converters != null && converters.Length > 0) ? 
                new JsonSerializerSettings() { Converters = converters } : null;
        }
    }
}
