// Copyright (c) Microsoft Corporation
// All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License"); you may not
// use this file except in compliance with the License.  You may obtain a copy
// of the License at http://www.apache.org/licenses/LICENSE-2.0
// 
// THIS CODE IS PROVIDED *AS IS* BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED, INCLUDING WITHOUT LIMITATION ANY IMPLIED
// WARRANTIES OR CONDITIONS OF TITLE, FITNESS FOR A PARTICULAR PURPOSE,
// MERCHANTABLITY OR NON-INFRINGEMENT.
// 
// See the Apache Version 2.0 License for specific language governing
// permissions and limitations under the License.
namespace Microsoft.Hadoop.Avro.Schema
{
    using System;
    using System.Collections.Generic;
    using Newtonsoft.Json;

    /// <summary>
    ///     Represents a fixed schema.
    ///     For more details please see <a href="http://avro.apache.org/docs/current/spec.html#Fixed">the specification</a>.
    /// </summary>
    public sealed class FixedSchema : NamedSchema
    {
        private readonly int size;

        internal FixedSchema(NamedEntityAttributes namedEntityAttributes, int size, Type runtimeType)
            : this(namedEntityAttributes, size, runtimeType, new Dictionary<string, string>())
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="FixedSchema" /> class.
        /// </summary>
        /// <param name="namedEntityAttributes">The named schema attributes.</param>
        /// <param name="size">The size.</param>
        /// <param name="runtimeType">Type of the runtime.</param>
        /// <param name="attributes">The attributes.</param>
        internal FixedSchema(
            NamedEntityAttributes namedEntityAttributes,
            int size,
            Type runtimeType,
            Dictionary<string, string> attributes) : base(namedEntityAttributes, runtimeType, attributes)
        {
            if (size <= 0)
            {
                throw new ArgumentOutOfRangeException("size");
            }

            this.size = size;
        }

        /// <summary>
        ///     Gets the size.
        /// </summary>
        public int Size
        {
            get { return this.size; }
        }

        /// <summary>
        ///     Converts current not to JSON according to the avro specification.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="seenSchemas">The seen schemas.</param>
        internal override void ToJsonSafe(JsonTextWriter writer, HashSet<NamedSchema> seenSchemas)
        {
            if (seenSchemas.Contains(this))
            {
                writer.WriteValue(this.FullName);
                return;
            }

            seenSchemas.Add(this);
            writer.WriteStartObject();
            writer.WriteProperty("type", "fixed");
            writer.WriteProperty("name", this.FullName);
            writer.WriteOptionalProperty("aliases", this.Aliases);
            writer.WriteProperty("size", this.Size);
            writer.WriteEndObject();
        }
    }
}
