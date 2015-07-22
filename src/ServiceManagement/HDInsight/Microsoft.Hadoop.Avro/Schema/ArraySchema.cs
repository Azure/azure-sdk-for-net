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
    ///     Schema representing an array.
    ///     For more details please see <a href="http://avro.apache.org/docs/current/spec.html#Arrays">the specification</a>.
    /// </summary>
    public sealed class ArraySchema : TypeSchema
    {
        private readonly TypeSchema itemSchema;

        /// <summary>
        ///     Initializes a new instance of the <see cref="ArraySchema" /> class.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="runtimeType">Type of the runtime.</param>
        /// <param name="attributes">The attributes.</param>
        internal ArraySchema(
            TypeSchema item,
            Type runtimeType,
            Dictionary<string, string> attributes)
            : base(runtimeType, attributes)
        {
            if (item == null)
            {
                throw new ArgumentNullException("item");
            }

            this.itemSchema = item;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ArraySchema"/> class.
        /// </summary>
        /// <param name="item">The item.</param>
        /// <param name="runtimeType">Type of the runtime.</param>
        internal ArraySchema(
            TypeSchema item,
            Type runtimeType)
            : this(item, runtimeType, new Dictionary<string, string>())
        {
        }

        /// <summary>
        ///     Gets the item schema.
        /// </summary>
        public TypeSchema ItemSchema
        {
            get { return this.itemSchema; }
        }

        /// <summary>
        ///     Converts current not to JSON according to the avro specification.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="seenSchemas">The seen schemas.</param>
        internal override void ToJsonSafe(JsonTextWriter writer, HashSet<NamedSchema> seenSchemas)
        {
            writer.WriteStartObject();
            writer.WriteProperty("type", "array");
            writer.WritePropertyName("items");
            this.itemSchema.ToJson(writer, seenSchemas);
            writer.WriteEndObject();
        }

        /// <summary>
        /// Gets the type of the schema as string.
        /// </summary>
        internal override string Type
        {
            get { return Token.Array; }
        }
    }
}