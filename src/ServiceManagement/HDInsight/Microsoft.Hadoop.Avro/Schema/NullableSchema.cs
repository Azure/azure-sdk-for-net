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
    /// Artificial node for nullable types.
    /// </summary>
    internal sealed class NullableSchema : TypeSchema
    {
        private readonly TypeSchema valueSchema;

        /// <summary>
        /// Initializes a new instance of the <see cref="NullableSchema" /> class.
        /// </summary>
        /// <param name="nullableType">Type of the nullable.</param>
        /// <param name="attributes">The attributes.</param>
        /// <param name="valueSchema">The value type schema.</param>
        internal NullableSchema(
            Type nullableType,
            IDictionary<string, string> attributes,
            TypeSchema valueSchema)
            : base(nullableType, attributes)
        {
            this.valueSchema = valueSchema;
        }

        internal NullableSchema(
            Type nullableType,
            TypeSchema valueSchema)
            : this(nullableType, new Dictionary<string, string>(), valueSchema)
        {
        }

        public TypeSchema ValueSchema
        {
            get { return this.valueSchema; }
        }

        internal override string Type
        {
            get { return this.valueSchema.Type; }
        }

        internal override void ToJsonSafe(JsonTextWriter writer, HashSet<NamedSchema> seenSchemas)
        {
            this.valueSchema.ToJsonSafe(writer, seenSchemas);
        }
    }
}
