// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
#if!NET45
using System.Reflection;
#endif


namespace Microsoft.Rest.Serialization
{
    /// <summary>
    /// Helper class for JsonConverters.
    /// </summary>
    public static class JsonConverterHelper
    {
        /// <summary>
        /// Serializes properties of the value object into JsonWriter.
        /// </summary>
        /// <param name="writer">The JSON writer.</param>
        /// <param name="value">The value to serialize.</param>
        /// <param name="serializer">The JSON serializer.</param>
        public static void SerializeProperties(JsonWriter writer, object value, JsonSerializer serializer)
        {
            SerializeProperties(writer, value, serializer, null);
        }

        /// <summary>
        /// Serializes properties of the value object into JsonWriter.
        /// </summary>
        /// <param name="writer">The JSON writer.</param>
        /// <param name="value">The value to serialize.</param>
        /// <param name="serializer">The JSON serializer.</param>
        /// <param name="filter">If specified filters JsonProperties to be serialized.</param>
        public static void SerializeProperties(JsonWriter writer, object value, JsonSerializer serializer,
            Predicate<JsonProperty> filter)
        {
            if (writer == null)
            {
                throw new ArgumentNullException("writer");
            }
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }
            if (serializer == null)
            {
                throw new ArgumentNullException("serializer");
            }

            var contract = (JsonObjectContract) serializer.ContractResolver.ResolveContract(value.GetType());
            foreach (JsonProperty property in contract.Properties
                .Where(p => filter == null || filter(p)))
            {
                object memberValue = property.ValueProvider.GetValue(value);

                // Skipping properties with null value if NullValueHandling is set to Ignore
                if (serializer.NullValueHandling == NullValueHandling.Ignore &&
                    memberValue == null)
                {
                    continue;
                }

                // Skipping properties with JsonIgnore attribute, non-readable, and 
                // ShouldSerialize returning false when set
                if (!property.Ignored && property.Readable &&
                    (property.ShouldSerialize == null || property.ShouldSerialize(memberValue)))
                {
                    string propertyName = property.PropertyName;
                    if (property.PropertyName.StartsWith("properties.", StringComparison.OrdinalIgnoreCase))
                    {
                        propertyName = property.PropertyName.Substring("properties.".Length);
                    }
                    writer.WritePropertyName(propertyName);
                    serializer.Serialize(writer, memberValue);
                }
            }
        }

        public static string GetPropertyName(this JsonProperty property, out string[] parentPath)
        {
            if (property == null)
            {
                throw new ArgumentNullException("property");
            }

            string propertyName = property.PropertyName;
            parentPath = new string[0];

            if (!string.IsNullOrEmpty(propertyName))
            {
                string[] hierarchy = Regex.Split(propertyName, @"(?<!\\)\.")
                    .Select(p => p?.Replace("\\.", ".")).ToArray();
                if (hierarchy.Length > 1)
                {
                    propertyName = hierarchy.Last();
                    parentPath = hierarchy.Take(hierarchy.Length - 1).ToArray();
                }
            }

            return propertyName;            
        }
    }
}