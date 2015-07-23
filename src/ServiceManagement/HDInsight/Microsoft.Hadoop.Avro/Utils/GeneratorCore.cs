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
    using System.IO;
    using System.Text;

    using Microsoft.Hadoop.Avro.Schema;
    using Microsoft.Hadoop.Avro.Utils.Templates;

    /// <summary>
    /// Generates CSharp code from an Avro schema.
    /// </summary>
    internal sealed class GeneratorCore
    {
        /// <summary>
        /// Reads the schema and generates the code to the stream.
        /// </summary>
        /// <param name="schema">The schema.</param>
        /// <param name="defaultNamespace">The default namespace.</param>
        /// <param name="forceNamespace">Determines whether the defaultNamespace should be used.</param>
        /// <param name="stream">The stream.</param>
        public static void Generate(Schema schema, string defaultNamespace, bool forceNamespace, Stream stream)
        {
            var recordSchema = schema as RecordSchema;
            var enumSchema = schema as EnumSchema;
            string code;
            if (recordSchema != null)
            {
                code = GenerateCore(recordSchema, defaultNamespace, forceNamespace);
            }
            else if (enumSchema != null)
            {
                code = GenerateCore(enumSchema, defaultNamespace, forceNamespace);
            }
            else
            {
                throw new ArgumentException("Unsupported schema: only record and enum schemas are supported.");
            }

            var encoding = new UTF8Encoding();
            byte[] bytes = encoding.GetBytes(code);
            stream.Write(bytes, 0, bytes.Length);
        }

        private static string GenerateCore(RecordSchema schema, string defaultNamespace, bool forceNamespace)
        {
            return new ClassTemplate(schema, defaultNamespace, forceNamespace).TransformText();
        }

        private static string GenerateCore(EnumSchema schema, string defaultNamespace, bool forceNamespace)
        {
            return new EnumTemplate(schema, defaultNamespace, forceNamespace).TransformText();
        }
    }
}
