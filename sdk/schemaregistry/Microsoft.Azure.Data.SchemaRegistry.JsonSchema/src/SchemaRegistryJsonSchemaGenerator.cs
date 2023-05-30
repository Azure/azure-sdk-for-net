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
    /// Defining <see cref="GenerateSchemaFromObject(Type)"/> is required. However, defining <see cref="ValidateAgainstSchema(object, Type, string)"/>
    /// is optional.
    /// </remarks>
    public abstract class SchemaRegistryJsonSchemaGenerator
    {
        /// <summary>
        /// Validates that <paramref name="data"/> is valid according to <paramref name="schemaDefinition"/>.
        /// </summary>
        /// <param name="data">The data to use for serialization or the data that was deserialized.</param>
        /// <param name="dataType">The type of the data to serialize or the type of the deserialized data.</param>
        /// <param name="schemaDefinition">The JSON schema definition retrieved using <see cref="SchemaRegistryClient"/></param>
        /// <returns> <c>true</c> if <paramref name="data"/> is valid, <c>false</c> otherwise.</returns>
        public virtual bool ValidateAgainstSchema(Object data, Type dataType, string schemaDefinition)
        {
            return true;
        }

        /// <summary>
        /// Generates a JSON schema from <paramref name="dataType"/>.
        /// </summary>
        /// <param name="dataType">The type of the data to serialize.</param>
        /// <returns>The generated JSON schema in string format.</returns>
        public abstract string GenerateSchemaFromObject(Type dataType);
    }
}
