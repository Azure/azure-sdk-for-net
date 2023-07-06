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
        /// .
        /// </summary>
        public static readonly ModelSerializerOptions AzureSerivceDefault = new ModelSerializerOptions()
        {
            IgnoreAdditionalProperties = true,
            IgnoreReadOnlyProperties = true,
        };

        /// <summary>
        /// Bool that determines if ReadOnlyProperties will be serialized. Default is false.
        /// </summary>
        public bool IgnoreReadOnlyProperties { get; set; }

        /// <summary>
        /// Bool that determines if AdditionalProperties will be serialized. Default is false.
        /// </summary>
        public bool IgnoreAdditionalProperties { get; set; }

        /// <summary>
        /// Bool that determines if Json will be PrettyPrinted. Default is false.
        /// </summary>
        public bool PrettyPrint { get; set; }

        /// <summary>
        /// Dictionary that holds all the serializers for the different model types.
        /// </summary>
        public Dictionary<Type, ObjectSerializer> Serializers { get; internal set; } = new Dictionary<Type, ObjectSerializer>();

        /// <summary>
        /// NameHint for Xml Models
        /// </summary>
        public string? NameHint { get; set; }
    }
}
