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
        private Dictionary<Type, ObjectSerializer>? _serializers;

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
        }

        /// <summary>
        /// ModelSerializerFormat that determines Format of serialized model. "D" = data format which means IgnoreReadOnly and IgnoreAdditionalProperties are false, "W" = wire format which means both properties are true. Default is "D".
        /// </summary>
        public ModelSerializerFormat Format;

        /// <summary>
        /// Dictionary that holds all the serializers for the different model types.
        /// </summary>
        public Dictionary<Type, ObjectSerializer> Serializers
        {
            get { return _serializers ??= new Dictionary<Type, ObjectSerializer>(); }
            internal set { _serializers = value; }
        }

        private string ValidateFormat(string x)
        {
            if (x != ModelSerializerFormat.Data && x != ModelSerializerFormat.Wire)
            {
                throw new ArgumentException($"Format must be either '{ModelSerializerFormat.Data}' or '{ModelSerializerFormat.Wire}'.");
            }
            return x;
        }
    }
}
