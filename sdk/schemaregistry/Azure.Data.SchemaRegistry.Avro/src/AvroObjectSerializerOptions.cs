// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Data.SchemaRegistry.Avro
{
    /// <summary>
    /// Options for <see cref="AvroObjectSerializer"/>.
    /// </summary>
    public class AvroObjectSerializerOptions
    {
        /// <summary>
        /// When true, automatically registers the provided value's schema with the SchemaRegistry during serialization.
        /// When false, the schema is only acquired from the SchemaRegistry.
        /// </summary>
        public bool AutoRegisterSchemas { get; set; }
    }
}
