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
        /// Enumerator representing format of the serialized model.
        /// </summary>
        public readonly partial struct Format
        {
            /// <summary>
            /// Specifies the data format where IgnoreReadOnly and IgnoreAdditionalProperties are false.
            /// </summary>
            public static readonly string Data = "D";

            /// <summary>
            /// Specifies the wire format IgnoreReadOnly and IgnoreAdditionalProperties are true.
            /// </summary>
            public static readonly string Wire = "W";

            /// <summary>
            /// todo
            /// </summary>
            public Format()
            {
            }
        }

        /// <summary>
        /// Consructor for ModelSerializerOptions. Takes in a string that determines Format of serialized model. "D" = data format which means IgnoreReadOnly and IgnoreAdditionalProperties are false, "W" = wire format which means both properties are true. Default is "D".
        /// </summary>
        /// <param name="format"></param>
        public ModelSerializerOptions(string format = "D")
        {
            //throw ArgumentException if not "D" or "W"
            FormatType = ValidateFormat(format);
        }

        /// <summary>
        /// String that determines Format of serialized model. "D" = data format which means IgnoreReadOnly and IgnoreAdditionalProperties are false, "W" = wire format which means both properties are true. Default is "D".
        /// </summary>
        public string FormatType { get; }

        /// <summary>
        /// Dictionary that holds all the serializers for the different model types.
        /// </summary>
        public Dictionary<Type, ObjectSerializer> Serializers { get; } = new Dictionary<Type, ObjectSerializer>();

        private string ValidateFormat(string x)
        {
            if (x != "D" && x != "W")
            {
                throw new ArgumentException("Format must be either 'Data' or 'Wire'.");
            }
            return x;
        }
    }
}
