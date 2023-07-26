// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// Provides the client options for serializing models.
    /// </summary>
    public class ModelSerializerOptions
    {
        /// <summary>
        /// Default options for communicating with Azure service.
        /// </summary>
        public static readonly ModelSerializerOptions DefaultAzureOptions = new ModelSerializerOptions(ModelSerializerFormat.Wire);

        /// <summary>
        /// Delegate to specify a specific <see cref="ObjectSerializer"/> for a given <see cref="Type"/>.
        /// </summary>
        /// <param name="type">The <see cref="Type"/> to look up.</param>
        /// <returns></returns>
        public delegate ObjectSerializer? ObjectSerializerFactory(Type type);

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSerializerOptions" /> class. Defaults to Data format <see cref="ModelSerializerFormat.Json"/>.
        /// </summary>
        public ModelSerializerOptions() : this(ModelSerializerFormat.Json) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSerializerOptions" /> class.
        /// </summary>
        /// <param name="format">String that determines Format of serialized model..</param>
        public ModelSerializerOptions(ModelSerializerFormat format)
        {
            Format = format;
        }

        /// <summary>
        /// Gets the <see cref="ModelSerializerFormat"/> that determines Format of serialized model.
        /// </summary>
        public ModelSerializerFormat Format { get; }

        /// <summary>
        /// Gets or sets a factory method that returns an <see cref="ObjectSerializer"/> based on the provided <see cref="Type"/>.
        /// Should return null if the type is not supported.
        /// </summary>
        public ObjectSerializerFactory? TypeResolver { get; set; }
    }
}
