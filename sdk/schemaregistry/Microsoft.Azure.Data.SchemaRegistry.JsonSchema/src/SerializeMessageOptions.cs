// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Serialization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Microsoft.Azure.Data.SchemaRegistry.JsonSchema
{
    /// <summary>
    /// The options to use when serializing a message using the <see cref="SchemaRegistryJsonSerializer"/>.
    /// </summary>
    public class SerializeMessageOptions
    {
        /// <summary>
        /// Allows the user to pass in an <see cref="ObjectSerializer"/>, such as a <see cref="JsonObjectSerializer"/>,
        /// with configured options.
        /// </summary>
        public ObjectSerializer ObjectSerializer { get; set; }
    }
}
