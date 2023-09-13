// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System;

namespace Azure.Core
{
    [AttributeUsage(AttributeTargets.Property)]
    internal class CodeGenMemberSerializationHooksAttribute : Attribute
    {
        /// <summary>
        /// Gets or sets the method name to use when serializing the property value (property name excluded)
        /// The signature of the serialization hook method must be or compatible with when invoking:
        /// private void SerializeHook(Utf8JsonWriter writer);
        /// </summary>
        public string? SerializationValueHook { get; set; }
        /// <summary>
        /// Gets or sets the method name to use when deserializing the property value from the JSON
        /// private static void DeserializationHook(JsonProperty property, ref TypeOfTheProperty propertyValue); // if the property is required
        /// private static void DeserializationHook(JsonProperty property, ref Optional&lt;TypeOfTheProperty&gt; propertyValue); // if the property is optional
        /// </summary>
        public string? DeserializationValueHook { get; set; }

        public CodeGenMemberSerializationHooksAttribute()
        {
        }
    }
}
