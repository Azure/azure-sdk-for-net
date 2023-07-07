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
        /// Consructor for ModelSerializerOptions. Takes in a string that determines Format of serialized model. "D" = data format which means IgnoreReadOnly and IgnoreAdditionalProperties are false, "W" = wire format which means both properties are true. Default is "D".
        /// </summary>
        /// <param name="format"></param>
        public ModelSerializerOptions(string format = "D")
        {
            //throw ArgumentException if not "D" or "W"
            Format = ValidateFormat(format);
        }

        /// <summary>
        /// String that determines Format of serialized model. "D" = data format which means IgnoreReadOnly and IgnoreAdditionalProperties are false, "W" = wire format which means both properties are true. Default is "D".
        /// </summary>
        public string Format { get; }

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
            if (x != "D" && x != "W")
            {
                throw new ArgumentException("Format must be either 'D' or 'W'.");
            }
            return x;
        }
    }
}
