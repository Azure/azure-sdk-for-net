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
            public static readonly string Data = "Data";

            /// <summary>
            /// Specifies the wire format IgnoreReadOnly and IgnoreAdditionalProperties are true.
            /// </summary>
            public static readonly string Wire = "Wire";

            /// <summary>
            /// todo
            /// </summary>
            public Format()
            {
            }
        }

        /// <summary>
        /// Consructor for ModelSerializerOptions. Takes in a string that determines Format of serialized model. "Data" = data format which means IgnoreReadOnly and IgnoreAdditionalProperties are false, "Wire" = wire format which means both properties are true. Default is "Data".
        /// </summary>
        /// <param name="format"></param>
        public ModelSerializerOptions(string format = "Data")
        {
            //throw ArgumentException if not "Data" or "Wire"
            FormatType = ValidateFormat(format);
        }

        /// <summary>
        /// String that determines Format of serialized model. "Data" = data format which means IgnoreReadOnly and IgnoreAdditionalProperties are false, "Wire" = wire format which means both properties are true. Default is "Data".
        /// </summary>
        public string FormatType { get; }

        /// <summary>
        /// Bool that determines if Json will be PrettyPrinted. Default is false.
        /// </summary>
        public bool PrettyPrint { get; set; }

        /// <summary>
        /// Dictionary that holds all the serializers for the different model types.
        /// </summary>
        public Dictionary<Type, ObjectSerializer> Serializers { get; } = new Dictionary<Type, ObjectSerializer>();

        /// <summary>
        /// NameHint for Xml Models
        /// </summary>
        public string? NameHint { get; set; }

        private string ValidateFormat(string x)
        {
            if (x != "Data" && x != "Wire")
            {
                throw new ArgumentException("Format must be either 'Data' or 'Wire'.");
            }
            return x;
        }
    }
}
