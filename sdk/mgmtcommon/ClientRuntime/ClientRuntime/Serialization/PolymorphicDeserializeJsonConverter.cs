// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.Rest.Serialization
{
    /// <summary>
    /// JsonConverter that handles deserialization for polymorphic objects
    /// based on discriminator field.
    /// </summary>
    /// <typeparam name="T">The base type.</typeparam>
    public class PolymorphicDeserializeJsonConverter<T> : PolymorphicJsonConverter where T : class
    {
        /// <summary>
        /// Initializes an instance of the PolymorphicDeserializeJsonConverter.
        /// </summary>
        /// <param name="discriminatorField">The JSON field used as a discriminator</param>
        public PolymorphicDeserializeJsonConverter(string discriminatorField)
        {
            if (discriminatorField == null)
            {
                throw new ArgumentNullException("discriminatorField");
            }
            Discriminator = discriminatorField;
        }

        /// <summary>
        /// Returns false.
        /// </summary>
        public override bool CanWrite
        {
            get { return false; }
        }

        /// <summary>
        /// Returns true if the object being deserialized is assignable to the base type. False otherwise.
        /// </summary>
        /// <param name="objectType">The type of the object to check.</param>
        /// <returns>True if the object being deserialized is assignable to the base type. False otherwise.</returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(T).GetTypeInfo().IsAssignableFrom(objectType.GetTypeInfo());
        }

        /// <summary>
        /// Case insensitive (and reduced version) of JToken.SelectToken which unfortunately does not offer
        /// such functionality and has made all potential extension points `internal`.
        /// </summary>
        private JToken SelectTokenCaseInsensitive(JObject obj, string path)
        {
            JToken result = obj;
            foreach (var pathComponent in path.Split('.'))
            {
                result = (result as JObject)?
                    .Properties()
                    .FirstOrDefault(p => string.Equals(p.Name, pathComponent, StringComparison.OrdinalIgnoreCase))?
                    .Value;
            }
            return result;
        }

        /// <summary>
        /// Reads a JSON field and deserializes into an appropriate object based on discriminator
        /// field and object name. If JsonObject attribute is available, its value is used instead.
        /// </summary>
        /// <param name="reader">The JSON reader.</param>
        /// <param name="objectType">The type of the object.</param>
        /// <param name="existingValue">The existing value.</param>
        /// <param name="serializer">The JSON serializer.</param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader,
            Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            JObject item = JObject.Load(reader);
            string typeDiscriminator = (string)item[Discriminator];
            Type resultType = GetDerivedType(objectType, typeDiscriminator) ?? objectType;

            // create instance of correct type
            var contract = (JsonObjectContract)serializer.ContractResolver.ResolveContract(resultType);
            var result = contract.DefaultCreator();

            // parse properties
            var queriedKeys = new HashSet<string> { Discriminator };
            var additionalPropertiesTargets = new List<JsonProperty>();
            foreach (var expectedProperty in contract.Properties)
            {
                if (!expectedProperty.Ignored)
                {
                    queriedKeys.Add(expectedProperty.PropertyName);
                    var property = SelectTokenCaseInsensitive(item, expectedProperty.PropertyName);
                    if (property != null)
                    {
                        object propertyValue;
                        if (expectedProperty.Converter?.CanRead == true)
                        {
                            propertyValue = expectedProperty.Converter.ReadJson(
                                new JTokenReader(property),
                                expectedProperty.PropertyType,
                                expectedProperty.ValueProvider.GetValue(result),
                                serializer);
                        }
                        else
                        {
                            propertyValue = property.ToObject(expectedProperty.PropertyType, serializer);
                        }

                        expectedProperty.ValueProvider.SetValue(result, propertyValue);
                    }
                }
                if (expectedProperty.IsJsonExtensionData())
                {
                    additionalPropertiesTargets.Add(expectedProperty);
                }
            }

            // populate additional properties
            var dict = new Dictionary<string, object>();
            foreach (var property in item.Properties())
            {
                if (!queriedKeys.Contains(property.Name))
                {
                    dict[property.Name] = property.Value.ToObject<object>();
                }
            }
            foreach (var additionalPropertiesTarget in additionalPropertiesTargets)
            {
                additionalPropertiesTarget.ValueProvider.SetValue(result, dict);
            }

            return result;
        }

        /// <summary>
        /// Throws NotSupportedException.
        /// </summary>
        /// <param name="writer">The JSON writer.</param>
        /// <param name="value">The value to serialize.</param>
        /// <param name="serializer">The JSON serializer.</param>
        public override void WriteJson(JsonWriter writer,
            object value, JsonSerializer serializer)
        {
            throw new NotSupportedException();
        }
    }
}