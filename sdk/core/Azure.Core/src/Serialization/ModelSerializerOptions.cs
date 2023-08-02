// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.Core.Serialization
{
    /// <summary>
    /// Provides the client options for serializing models.
    /// </summary>
    public class ModelSerializerOptions
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSerializerOptions" /> class using a default for of <see cref="ModelSerializerFormat.Json"/>.
        /// </summary>
        public ModelSerializerOptions()
            : this(ModelSerializerFormat.JsonValue) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSerializerOptions" /> class.
        /// </summary>
        /// <param name="format"> The format to serialize to and deserialize from. </param>
        public ModelSerializerOptions(ModelSerializerFormat format)
        {
            Format = format;
        }

        /// <summary>
        /// Gets the <see cref="ModelSerializerFormat"/> that determines Format of serialized model.
        /// </summary>
        public ModelSerializerFormat Format { get; }

        /// <summary>
        /// Dictionary that holds all the serializers for the different model types.
        /// </summary>
        public Dictionary<Type, ObjectSerializer> Serializers { get; } = new Dictionary<Type, ObjectSerializer>();
    }
}
