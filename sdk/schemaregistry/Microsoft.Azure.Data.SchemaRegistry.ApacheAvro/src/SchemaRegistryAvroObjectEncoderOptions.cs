// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.Data.SchemaRegistry.ApacheAvro
{
    /// <summary>
    /// Options for <see cref="SchemaRegistryAvroEncoder"/>.
    /// </summary>
    public class SchemaRegistryAvroObjectEncoderOptions
    {
        /// <summary>
        /// Gets or sets the automatic registration of schemas flag.
        /// When true, automatically registers the provided schema with the SchemaRegistry during serialization.
        /// When false, the schema is only acquired from the SchemaRegistry.
        /// The default is false.
        /// </summary>
        public bool AutoRegisterSchemas { get; set; }
    }
}
