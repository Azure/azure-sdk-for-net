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
        /// Initializes a new instance of the <see cref="ModelSerializerOptions" /> class. Takes in a string that determines Format of serialized model. "D" = data format which means IgnoreReadOnly and IgnoreAdditionalProperties are false, "W" = wire format which means both properties are true. Default is "D".
        /// </summary>
        /// <param name="format"></param>
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
        public Dictionary<Type, ObjectSerializer> Serializers { get; } = new Dictionary<Type, ObjectSerializer>();

        private string ValidateFormat(string x)
        {
            if (x != ModelSerializerFormat.Data && x != ModelSerializerFormat.Wire)
            {
                throw new ArgumentException("Format must be either 'ModelSerializerFormat.Data' or 'ModelSerializerFormat.Wire'.");
            }
            return x;
        }
    }
}
