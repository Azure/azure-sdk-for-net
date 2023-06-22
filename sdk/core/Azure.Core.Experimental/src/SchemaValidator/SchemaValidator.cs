// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Experimental.SchemaValidator
{
    /// <summary>
    /// This abstract class allows any available library to be used to generate schemas from .NET types and validate
    /// objects against schemas.
    /// </summary>
    /// <remarks>
    /// Defining both <see cref="GenerateSchema(Type)"/> and <see cref="IsValid(object, Type, string)"/> is required. If you
    /// do not wish to validate, then evaluate all schemas as valid.
    /// </remarks>
    public abstract class SchemaValidator
    {
        /// <summary>
        /// Validates that <paramref name="data"/> is valid according to <paramref name="schemaDefinition"/>. If the object is not valid,
        /// this method can either return false or throw an exception, depending on the needs of the application.
        /// </summary>
        /// <remarks>
        /// If you have more than one validation exception, consider wrapping them in an <see cref="AggregateException"/>.
        /// </remarks>
        /// <param name="data">The data to validate.</param>
        /// <param name="dataType">The type of data to validate.</param>
        /// <param name="schemaDefinition">The schema definition to validate against.</param>
        public abstract bool IsValid(object data, Type dataType, string schemaDefinition);

        /// <summary>
        /// Generates a schema from <paramref name="dataType"/> and returns it as a string.
        /// </summary>
        /// <param name="dataType">The type of the data to use when generating the schema.</param>
        /// <returns>The generated schema in string format.</returns>
        public abstract string GenerateSchema(Type dataType);
    }
}
