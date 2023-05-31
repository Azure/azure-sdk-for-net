// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Data.SchemaRegistry;
using System;

namespace Microsoft.Azure.Data.SchemaRegistry.JsonSchema
{
    /// <summary>
    /// This abstract class must be implemented in order to use the <see cref="SchemaRegistryJsonSerializer"/>. It allows
    /// any available library to be used to generate schemas from .NET types and validate objects against schemas.
    /// </summary>
    /// <remarks>
    /// Defining <see cref="GenerateSchemaFromType(Type)"/> is required. However, defining <see cref="ThrowIfNotValidAgainstSchema(object, Type, string)"/>
    /// is optional.
    /// </remarks>
    public abstract class SchemaRegistryJsonSchemaGenerator
    {
        /// <summary>
        /// Validates that <paramref name="data"/> is valid according to <paramref name="schemaDefinition"/>, and throws an exception otherwise.
        /// </summary>
        /// <param name="data">The data to use for serialization or the data that was deserialized.</param>
        /// <param name="dataType">The type of the data to serialize or the type of the deserialized data.</param>
        /// <param name="schemaDefinition">The JSON schema definition retrieved using <see cref="SchemaRegistryClient"/>.</param>
        public abstract void ThrowIfNotValidAgainstSchema(Object data, Type dataType, string schemaDefinition);

        /// <summary>
        /// Generates a JSON schema from <paramref name="dataType"/>.
        /// </summary>
        /// <param name="dataType">The type of the data to serialize.</param>
        /// <returns>The generated JSON schema in string format.</returns>
        public abstract string GenerateSchemaFromType(Type dataType);
    }
}
