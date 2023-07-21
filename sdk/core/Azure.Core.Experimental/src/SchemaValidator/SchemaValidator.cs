﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Core
{
    /// <summary>
    /// This abstract class allows any available library to be used to generate schemas from .NET types and validate
    /// objects against schemas.
    /// </summary>
    /// <remarks>
    /// Defining both <see cref="GenerateSchema(Type)"/> and <see cref="TryValidate(object, Type, string, out IEnumerable{Exception})"/> is required. If you
    /// do not wish to validate, then evaluate all schemas as valid.
    /// </remarks>
    public abstract class SchemaValidator
    {
        /// <summary>
        /// Validates that <paramref name="data"/> is valid according to <paramref name="schemaDefinition"/>.
        /// </summary>
        /// <param name="data">The data to validate.</param>
        /// <param name="dataType">The type of data to validate.</param>
        /// <param name="schemaDefinition">The schema definition to validate against.</param>
        /// <param name="validationErrors">When this method returns, contains the validation errors if <paramref name="data"/> was invalid according to
        /// the <paramref name="schemaDefinition"/>.</param>
        /// <returns></returns>
        public abstract bool TryValidate(object data, Type dataType, string schemaDefinition, out IEnumerable<Exception> validationErrors);

        /// <summary>
        /// Validates that <paramref name="data"/> is valid according to <paramref name="schemaDefinition"/>. If the object is not valid,
        /// this method throws an <see cref="AggregateException"/> containing all of the validation errors.
        /// </summary>
        /// <param name="data">The data to validate.</param>
        /// <param name="dataType">The type of data to validate.</param>
        /// <param name="schemaDefinition">The schema definition to validate against.</param>
        /// <exception cref="AggregateException"> <paramref name="data"/> is not valid according to the <paramref name="schemaDefinition"/>.</exception>
        public virtual void Validate(object data, Type dataType, string schemaDefinition)
        {
            if (!TryValidate(data, dataType, schemaDefinition, out var errors))
            {
                throw new AggregateException("The validate method determined the object was invalid according to the schema.", errors);
            }
        }

        /// <summary>
        /// Generates a schema from <paramref name="dataType"/> and returns it as a string.
        /// </summary>
        /// <param name="dataType">The type of the data to use when generating the schema.</param>
        /// <returns>The generated schema in string format.</returns>
        public abstract string GenerateSchema(Type dataType);
    }
}
