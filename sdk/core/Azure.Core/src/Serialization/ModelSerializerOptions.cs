// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

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
        public ModelSerializerOptions(ModelSerializerOptions format)
        {
            Format = format;
            Serializers = new Dictionary<Type, ObjectSerializer>();
        }

        /// <summary>
        /// Gets the <see cref="ModelSerializerFormat"/> that determines Format of serialized model.
        /// </summary>
        public ModelSerializerFormat Format { get; }

        /// <summary>
        /// Dictionary that holds all the serializers for the different model types.
        /// </summary>
        public Dictionary<Type, ObjectSerializer> Serializers { get; internal set; }
    }
}
