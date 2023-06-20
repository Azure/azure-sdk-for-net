// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// This abstract class allows any available library to be used to generate schemas from .NET types and validate
    /// objects against schemas.
    /// </summary>
    /// <remarks>
    /// Defining both <see cref="GenerateSchema(Type)"/> and <see cref="Validate(object, Type, T)"/> is required. If you
    /// do not wish to validate, then evaluate all schemas as valid.
    /// </remarks>
    public abstract class SchemaValidator<T>
    {
        /// <summary>
        /// Validates that <paramref name="data"/> is valid according to <paramref name="schemaDefinition"/>. If the object is not valid,
        /// this method should throw an exception.
        /// </summary>
        /// <remarks>
        /// If you have more than one validation exception, consider wrapping them in an <see cref="AggregateException"/>.
        /// </remarks>
        /// <param name="data">The data to use for serialization or the data that was deserialized.</param>
        /// <param name="dataType">The type of the data to serialize or the type of the deserialized data.</param>
        /// <param name="schemaDefinition">The schema definition to validate against.</param>
        public abstract void Validate(Object data, Type dataType, T schemaDefinition);

        /// <summary>
        /// Generates a schema from <paramref name="dataType"/> and returns it as a type of <typeparamref name="T"/>.
        /// </summary>
        /// <param name="dataType">The type of the data to serialize.</param>
        /// <returns>The generated schema in string format.</returns>
        public abstract T GenerateSchema(Type dataType);
    }
}
