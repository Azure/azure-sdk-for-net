// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Rest.Azure
{
    /// <summary>
    /// JsonConverter that provides custom deserialization for TypedErrorInfo objects.
    /// </summary>
    public class TypedErrorInfoJsonConverter : JsonConverter
    {
        /// <summary>
        /// Returns true if the object being serialized is a TypedErrorInfo.
        /// </summary>
        /// <param name="objectType">The type of the object to check.</param>
        /// <returns>True if the object being serialized is a TypedErrorInfo. False otherwise.</returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(TypedErrorInfo) == objectType;
        }

        /// <summary>
        /// Deserializes an object from a JSON string.
        /// </summary>
        /// <param name="reader">The JSON reader.</param>
        /// <param name="objectType">The type of the object.</param>
        /// <param name="existingValue">The existing value.</param>
        /// <param name="serializer">The JSON serializer.</param>
        /// <returns></returns>
        public override object ReadJson(JsonReader reader,
            Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (reader == null)
            {
                throw new ArgumentNullException("reader");
            }
            if (objectType == null)
            {
                throw new ArgumentNullException("objectType");
            }
            if (serializer == null)
            {
                throw new ArgumentNullException("serializer");
            }
            if (reader.TokenType == JsonToken.Null)
            {
                return null;
            }

            JObject jObject = JObject.Load(reader);
            var typedErrorInfo = jObject.ToObject<TypedErrorInfo>(serializer.WithoutConverter(this));
            Type errorInfoType = GetTypedErrorInfoType(jObject["type"]?.Value<string>());
            if (errorInfoType != null)
            {
                // deserialize to the strongly typed error object
                // and keep the original JObject info as well in case the strongly typed error is not up-to-date
                var strongTypedErrorInfo = jObject.ToObject(errorInfoType, serializer.WithoutConverter(this));
                ((TypedErrorInfo)strongTypedErrorInfo).Info = typedErrorInfo.Info;
                return strongTypedErrorInfo;
            }

            return typedErrorInfo;
        }

        /// <summary>
        /// Serializes an object into a JSON string adding Properties. 
        /// </summary>
        /// <param name="writer">The JSON writer.</param>
        /// <param name="value">The value to serialize.</param>
        /// <param name="serializer">The JSON serializer.</param>
        public override void WriteJson(JsonWriter writer,
            object value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets the derived type of TypedErrorInfo that matches the specified name.
        /// </summary>
        /// <param name="typeName">The derived type name.</param>
        /// <returns></returns>
        private static Type GetTypedErrorInfoType(string typeName)
        {
            var baseType = typeof(TypedErrorInfo);
            return baseType.GetTypeInfo().Assembly.DefinedTypes.FirstOrDefault(t => t.IsSubclassOf(baseType) && string.Equals(t.Name, typeName, StringComparison.OrdinalIgnoreCase))?.AsType();
        }
    }
}