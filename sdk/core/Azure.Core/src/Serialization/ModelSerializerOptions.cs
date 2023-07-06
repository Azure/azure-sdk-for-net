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
        /// String that determines Format of serialized model. "D" = data format which means both properties are false, "W" = wire format which means both properties are true Default is "D".
        /// </summary>
        public string Format
        {
            get
            {
                return "D";
            }
        }

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
    }
}
