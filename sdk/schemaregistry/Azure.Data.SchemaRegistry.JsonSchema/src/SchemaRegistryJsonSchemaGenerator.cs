// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Data.SchemaRegistry;
using System;

namespace Azure.Data.SchemaRegistry.JsonSchema
{
    /// <summary>
    /// This abstract class must be implemented in order to use the <see cref="SchemaRegistryJsonSerializer"/>. It allows
    /// any available library to be used to generate schemas from .NET types and validate objects against schemas.
    /// </summary>
    /// <remarks>
    /// Defining both <see cref="GenerateSchema(Type)"/> and <see cref="Validate(object, Type, string)"/> is required. If you
    /// do not wish to validate, then evaluate all schemas as valid.
    /// </remarks>
    public abstract class SchemaRegistryJsonSchemaGenerator
    {
        /// <summary>
        /// Validates that <paramref name="data"/> is valid according to <paramref name="schemaDefinition"/>. If the object is not valid,
        /// this method should throw an exception. This exception will be set as an <see cref="Exception.InnerException"/> and thrown by the
        /// <see cref="SchemaRegistryJsonSerializer"/>.
        /// </summary>
        /// <remarks>
        /// If you have more than one validation exception, consider wrapping them in an <see cref="AggregateException"/>.
        /// </remarks>
        /// <param name="data">The data to use for serialization or the data that was deserialized.</param>
        /// <param name="dataType">The type of the data to serialize or the type of the deserialized data.</param>
        /// <param name="schemaDefinition">The JSON schema definition retrieved using <see cref="SchemaRegistryClient"/>.</param>
        public abstract void Validate(Object data, Type dataType, string schemaDefinition);

        /// <summary>
        /// Generates a JSON schema from <paramref name="dataType"/> and returns it as a string. This method is used by the serialize call
        /// to determine if the type matches an existing schema in the Schema Registry. Any exceptions thrown by this method will be set as an
        /// <see cref="Exception.InnerException"/> and thrown by the <see cref="SchemaRegistryJsonSerializer"/>.
        /// </summary>
        /// <param name="dataType">The type of the data to serialize.</param>
        /// <returns>The generated JSON schema in string format.</returns>
        public abstract string GenerateSchema(Type dataType);
    }
}
