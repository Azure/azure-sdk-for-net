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
namespace Microsoft.Hadoop.Avro.Utils
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using Microsoft.Hadoop.Avro.Schema;

    /// <summary>
    /// Generates CSharp code from an Avro schema.
    /// </summary>
    internal static class CodeGenerator
    {
        /// <summary>
        /// Searches a schema for other schemas that can be used for code generation.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <returns>A list of schemas that can be used for code generation.</returns>
        public static IEnumerable<TypeSchema> ResolveCodeGeneratingSchemas(TypeSchema schema)
        {
            if (schema == null)
            {
                throw new ArgumentNullException("schema");
            }

            var result = new List<TypeSchema>();
            GetSchemas(schema, result);
            return result;
        }

        /// <summary>
        /// Searches a JSON schema for other schemas that can be used for code generation.
        /// </summary>
        /// <param name="jsonSchema">The schema.</param>
        /// <returns>A list of schemas that can be used for code generation.</returns>
        public static IEnumerable<TypeSchema> ResolveCodeGeneratingSchemas(string jsonSchema)
        {
            if (string.IsNullOrEmpty(jsonSchema))
            {
                throw new ArgumentException(
                    string.Format(CultureInfo.InvariantCulture, "Empty schema can not be used for code generation."));
            }

            var rootSchema = new JsonSchemaBuilder().BuildSchema(Utilities.RemoveComments(jsonSchema));
            return ResolveCodeGeneratingSchemas(rootSchema);
        }

        /// <summary>
        /// Parses a schema and generates code from it and writes it to the stream.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="defaultNamespace">The default namespace.</param>
        /// <param name="forceNamespace">Determines whether the defaultNamespace should be used.</param>
        /// <param name="stream">The stream.</param>
        public static void Generate(Schema schema, string defaultNamespace, bool forceNamespace, Stream stream)
        {
            if (schema == null)
            {
                throw new ArgumentNullException("schema");
            }

            if (defaultNamespace == null)
            {
                throw new ArgumentNullException("defaultNamespace");
            }

            if (stream == null)
            {
                throw new ArgumentNullException("stream");
            }

            GeneratorCore.Generate(schema, defaultNamespace, forceNamespace, stream);
        }

        private static void GetSchemas(TypeSchema typeSchema, List<TypeSchema> result)
        {
            if (typeSchema == null)
            {
                throw new ArgumentNullException("typeSchema");
            }

            if (result.Contains(typeSchema))
            {
                return;
            }

            var arraySchema = typeSchema as ArraySchema;
            if (arraySchema != null)
            {
                GetSchemas(arraySchema.ItemSchema, result);
                return;
            }

            var mapSchema = typeSchema as MapSchema;
            if (mapSchema != null)
            {
                GetSchemas(mapSchema.ValueSchema, result);
                return;
            }

            var unionSchema = typeSchema as UnionSchema;
            if (unionSchema != null && unionSchema.IsNullable() == false)
            {
                foreach (var item in unionSchema.Schemas)
                {
                    GetSchemas(item, result);
                }
                return;
            }

            var namedSchema = typeSchema as NamedSchema;
            if (namedSchema == null)
            {
                return;
            }

            if (typeSchema is FixedSchema == false)
            {
                result.Add(namedSchema);
            }

            var recordSchema = typeSchema as RecordSchema;
            if (recordSchema != null)
            {
                foreach (var field in recordSchema.Fields)
                {
                    GetSchemas(field.TypeSchema, result);
                }
            }
        }
    }
}