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
    /// Node for surrogate types.
    /// </summary>
    internal sealed class SurrogateSchema : TypeSchema
    {
        private readonly Type surrogateType;
        private readonly TypeSchema surrogateSchema;

        internal SurrogateSchema(Type originalType, Type surrogateType, TypeSchema surrogateSchema)
            : this(originalType, surrogateType, new Dictionary<string, string>(), surrogateSchema)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="SurrogateSchema" /> class.
        /// </summary>
        /// <param name="originalType">Type of the original.</param>
        /// <param name="surrogateType">Type of the surrogate.</param>
        /// <param name="attributes">The attributes.</param>
        /// <param name="surrogateSchema">The surrogate schema.</param>
        internal SurrogateSchema(
            Type originalType,
            Type surrogateType,
            IDictionary<string, string> attributes,
            TypeSchema surrogateSchema)
            : base(originalType, attributes)
        {
            if (originalType == null)
            {
                throw new ArgumentNullException("originalType");
            }
            if (surrogateType == null)
            {
                throw new ArgumentNullException("surrogateType");
            }
            if (surrogateSchema == null)
            {
                throw new ArgumentNullException("surrogateSchema");
            }

            this.surrogateType = surrogateType;
            this.surrogateSchema = surrogateSchema;
        }

        /// <summary>
        /// Gets the type of the original.
        /// </summary>
        public Type SurrogateType
        {
            get { return this.surrogateType; }
        }

        /// <summary>
        /// Gets the surrogate schema.
        /// </summary>
        public TypeSchema Surrogate
        {
            get { return this.surrogateSchema; }
        }

        /// <summary>
        /// Converts current not to JSON according to the avro specification.
        /// </summary>
        /// <param name="writer">The writer.</param>
        /// <param name="seenSchemas">The seen schemas.</param>
        internal override void ToJsonSafe(JsonTextWriter writer, HashSet<NamedSchema> seenSchemas)
        {
            this.surrogateSchema.ToJson(writer, seenSchemas);
        }

        /// <summary>
        /// Gets the type of the schema as string.
        /// </summary>
        internal override string Type
        {
            get { return this.surrogateSchema.Type; }
        }
    }
}
