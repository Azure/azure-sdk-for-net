// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Diagnostics;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Azure.Search.Documents
{
    /// <summary>
    /// Helper base <see cref="JsonConverterFactory"/> for exposing
    /// <see cref="JsonConverter{T}"/> that correspond to wrappers around our
    /// model types.
    /// </summary>
    internal abstract class ModelConverterFactory : JsonConverterFactory
    {
        /// <summary>
        /// Type of the wrapper around our model type (i.e.,
        /// <C>typeof(SearchResults{})</C> for example).
        /// </summary>
        protected abstract Type GenericType { get; }

        /// <summary>
        /// Type of the JsonConverter for our GenericType.
        /// </summary>
        protected abstract Type GenericConverterType { get; }

        /// <summary>
        /// Determine whether we need to construct the converter with our
        /// JsonSerializerOptions.  The default value is false.
        /// </summary>
        protected virtual bool ConstructWithOptions => false;

        /// <summary>
        /// Checks if this converter can be used to convert JSON to the given
        /// type.
        /// </summary>
        /// <param name="typeToConvert">The type we want to convert to.</param>
        /// <returns>Whether the type can be converted.</returns>
        public override bool CanConvert(Type typeToConvert) =>
            typeToConvert != null &&
            typeToConvert.IsGenericType &&
            typeToConvert.GetGenericTypeDefinition() == GenericType;

        /// <summary>
        /// Create a concrete <see cref="JsonConverter{T}"/> for the desired
        /// model type.
        /// </summary>
        /// <param name="typeToConvert">
        /// The closed type we want to convert to.
        /// </param>
        /// <param name="options">Serialization options.</param>
        /// <returns>A converter for the closed type.</returns>
        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            Debug.Assert(CanConvert(typeToConvert));
            Debug.Assert(typeToConvert.GetGenericArguments()?.Length == 1);
            Type modelType = typeToConvert.GetGenericArguments()[0];
            Type converterType = GenericConverterType.MakeGenericType(new[] { modelType });

            // Create an instance of the closed type (and pass in the options
            // if requested)
            JsonConverter converter;
            if (ConstructWithOptions)
            {
                converter = (JsonConverter)Activator.CreateInstance(
                    converterType,
                    BindingFlags.Instance | BindingFlags.Public,
                    binder: null,
                    args: new object[] { options },
                    culture: null);
            }
            else
            {
                converter = (JsonConverter)Activator.CreateInstance(converterType);
            }
            return converter;
        }
    }
}
