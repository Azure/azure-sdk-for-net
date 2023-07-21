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
        public ModelSerializerOptions() : this(ModelSerializerFormat.Data) { }

        /// <summary>
        /// Initializes a new instance of the <see cref="ModelSerializerOptions" /> class.
        /// </summary>
        /// <param name="format">String that determines Format of serialized model. "D" = data format which means IgnoreReadOnly and IgnoreAdditionalProperties are false, "W" = wire format which means both properties are true. Default is "D".</param>
        public ModelSerializerOptions(string format = "D")
        {
            //throw ArgumentException if not "D" or "W"
            Format = ValidateFormat(format);
            Serializers = new Dictionary<Type, ObjectSerializer>();
        }

        /// <summary>
        /// ModelSerializerFormat that determines Format of serialized model. "D" = data format which means IgnoreReadOnly and IgnoreAdditionalProperties are false, "W" = wire format which means both properties are true. Default is "D".
        /// </summary>
        public ModelSerializerFormat Format;

        /// <summary>
        /// Dictionary that holds all the serializers for the different model types.
        /// </summary>
        public Dictionary<Type, ObjectSerializer> Serializers { get; internal set; }

        private string ValidateFormat(string x)
        {
            if (x != ModelSerializerFormat.Data &&
                x != ModelSerializerFormat.Wire &&
                // TODO: standardized an allow JSON Merge PATCH
                x != "P")
            {
                throw new ArgumentException($"Format must be either '{ModelSerializerFormat.Data}' or '{ModelSerializerFormat.Wire}'.");
            }
            return x;
        }
    }
}
