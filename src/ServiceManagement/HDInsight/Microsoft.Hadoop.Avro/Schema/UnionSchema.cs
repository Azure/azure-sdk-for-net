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
    using System.Collections.ObjectModel;
    using System.Linq;
    using Newtonsoft.Json;

    /// <summary>
    ///     Class representing a union schema.
    ///     For more details please see <a href="http://avro.apache.org/docs/current/spec.html#Unions">the specification</a>.
    /// </summary>
    public sealed class UnionSchema : TypeSchema
    {
        private readonly List<TypeSchema> schemas;

        /// <summary>
        ///     Initializes a new instance of the <see cref="UnionSchema" /> class.
        /// </summary>
        /// <param name="schemas">The schemas.</param>
        /// <param name="runtimeType">Type of the runtime.</param>
        /// <param name="attributes">The attributes.</param>
        internal UnionSchema(
            List<TypeSchema> schemas,
            Type runtimeType,
            Dictionary<string, string> attributes)
            : base(runtimeType, attributes)
        {
            if (schemas == null)
            {
                throw new ArgumentNullException("schemas");
            }

            this.schemas = schemas;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="UnionSchema" /> class.
        /// </summary>
        /// <param name="schemas">The schemas.</param>
        /// <param name="runtimeType">Type of the runtime.</param>
        internal UnionSchema(
            List<TypeSchema> schemas,
            Type runtimeType)
            : this(schemas, runtimeType, new Dictionary<string, string>())
        {
        }

        /// <summary>
        ///     Gets the schemas.
        /// </summary>
        public ReadOnlyCollection<TypeSchema> Schemas
        {
            get { return this.schemas.AsReadOnly(); }
        }

        internal override void ToJsonSafe(JsonTextWriter writer, HashSet<NamedSchema> seenSchemas)
        {
            writer.WriteStartArray();

            var existingSchemas = new List<TypeSchema>();
            for (int i = 0; i < this.schemas.Count; i++)
            {
                var typeSchema = this.schemas[i];

                // according to avro spec http://avro.apache.org/docs/current/spec.html#Unions
                // Unions may not contain more than one schema with the same type, except for the named types record, fixed and enum. 
                // For example, unions containing two array types or two map types are not permitted, but two types with different names are permitted            
                if (existingSchemas.Any(s => IsSameTypeAs(s, typeSchema)))
                {
                    continue;
                }
                
                existingSchemas.Add(typeSchema);
                typeSchema.ToJson(writer, seenSchemas);
            }
            
            writer.WriteEndArray();
        }

        /// <summary>
        /// Gets the type of the schema as string.
        /// </summary>
        internal override string Type
        {
            get { return Token.Union; }
        }

        /// <summary>
        /// according to avro spec http://avro.apache.org/docs/current/spec.html#Unions
        ///  Unions may not contain more than one schema with the same type, except for the named types record, fixed and enum. 
        ///  For example, unions containing two array types or two map types are not permitted, but two types with different names are permitted                            
        /// </summary>
        /// <param name="existingSchema">the schema that's already processed.</param>
        /// <param name="typeSchema">the schema to check whether it's duplicate according to avro union spec.</param>
        /// <returns>true if existingSchema is same type as typeSchema according to avro spec on union</returns>
        internal static bool IsSameTypeAs(TypeSchema existingSchema, TypeSchema typeSchema)
        {
            // only add ArraySchema at most once based on above Avro spec for union
            var arraySchema = typeSchema as ArraySchema;
            var mapSchema = typeSchema as MapSchema;
            if (arraySchema != null)
            {
                // find previous array schema index with the same ItemSchema
                return existingSchema is ArraySchema 
                    && IsSameTypeAs(((ArraySchema) existingSchema).ItemSchema, arraySchema.ItemSchema);
            }
            
            if (mapSchema != null)
            {
                // find previous map schema index with the same ItemSchema
                return existingSchema is MapSchema
                    && IsSameTypeAs(((MapSchema) existingSchema).KeySchema, mapSchema.KeySchema)
                    && IsSameTypeAs(((MapSchema) existingSchema).ValueSchema, mapSchema.ValueSchema);
            }

            return existingSchema.Type == typeSchema.Type;
        }
    }
}
