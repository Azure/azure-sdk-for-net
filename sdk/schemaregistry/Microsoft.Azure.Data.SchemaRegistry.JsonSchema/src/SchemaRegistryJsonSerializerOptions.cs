﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.Json;

namespace Microsoft.Azure.Data.SchemaRegistry.JsonSchema
{
    /// <summary>
    /// The options to use with the <see cref="SchemaRegistryJsonSerializer"/>.
    /// </summary>
    public class SchemaRegistryJsonSerializerOptions
    {
        /// <summary>
        /// Allows the user to pass in an <see cref="ObjectSerializer"/> with configured options.
        /// The default is a <see cref="JsonObjectSerializer"/>.
        /// </summary>
        public ObjectSerializer ObjectSerializer { get; set; } = new JsonObjectSerializer();

        internal SchemaRegistryJsonSerializerOptions Clone()
        {
            return new()
            {
                ObjectSerializer = ObjectSerializer
            };
        }
    }
}
