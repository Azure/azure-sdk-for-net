// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Globalization;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Microsoft.Rest.Azure
{
    /// <summary>
    /// JsonConverter that provides custom deserialization for CloudError objects.
    /// </summary>
    public class CloudErrorJsonConverter : JsonConverter
    {
        private const string ErrorNode = "error";

        /// <summary>
        /// Returns true if the object being serialized is a CloudError.
        /// </summary>
        /// <param name="objectType">The type of the object to check.</param>
        /// <returns>True if the object being serialized is a CloudError. False otherwise.</returns>
        public override bool CanConvert(Type objectType)
        {
            return typeof(CloudError) == objectType;
        }

        /// <summary>
        /// Deserializes an object from a JSON string and flattens out Error property.
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

            JObject jObject = JObject.Load(reader);
            JProperty errorObject = jObject.Properties().FirstOrDefault(p => 
                ErrorNode.Equals(p.Name, StringComparison.OrdinalIgnoreCase));
            if (errorObject != null)
            {
                jObject = errorObject.Value as JObject;
            }
            return jObject.ToObject<CloudError>(serializer.WithoutConverter(this));
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
    }
}