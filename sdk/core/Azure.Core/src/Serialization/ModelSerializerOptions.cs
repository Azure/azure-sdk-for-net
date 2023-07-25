// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// Provides the client options for serializing models.
    /// </summary>
    public struct ModelSerializerOptions
    {
        /// <summary>
        /// .
        /// </summary>
        public static readonly ModelSerializerOptions AzureServiceDefault = new ModelSerializerOptions(ModelSerializerFormat.Wire);

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSerializerOptions" /> class. Defaults to Data format "D".
        /// </summary>
        public ModelSerializerOptions() : this(ModelSerializerFormat.Json) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSerializerOptions" /> class.
        /// </summary>
        /// <param name="format">String that determines Format of serialized model. "D" = data format which means IgnoreReadOnly and IgnoreAdditionalProperties are false, "W" = wire format which means both properties are true. Default is "D".</param>
        public ModelSerializerOptions(ModelSerializerFormat format)
        {
            Format = format;
        }

        /// <summary>
        /// Gets the <see cref="ModelSerializerFormat"/> that determines Format of serialized model.
        /// </summary>
        public ModelSerializerFormat Format { get; }

        /// <summary>
        /// Gets or sets a factory method that returns a <see cref="ObjectSerializer"/> based on the provided <see cref="Type"/>.
        /// Should return null if the type is not supported.
        /// </summary>
        public Func<Type, ObjectSerializer?>? TypeResolver { get; set; }
    }
}
