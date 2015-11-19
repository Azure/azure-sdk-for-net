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
    using System.Linq;
    using System.Text.RegularExpressions;

    using Microsoft.Hadoop.Avro.Schema;
    using Microsoft.Hadoop.Avro.Utils.Templates;

    internal static class Utilities
    {
        private static readonly string[] CSharpReservedWords =
            {
                "abstract", "as", "base", "bool", "break", "byte",
                "case", "catch", "char", "checked", "class", "const",
                "continue", "decimal", "default", "delegate", "do",
                "double", "else", "enum", "event", "explicit", "extern",
                "false", "finally", "fixed", "float", "for", "foreach",
                "goto", "if", "implicit", "in", "int", "interface",
                "internal", "is", "lock", "long", "namespace", "new",
                "null", "object", "operator", "out", "override",
                "params", "private", "protected", "public", "readonly",
                "ref", "return", "sbyte", "sealed", "short", "sizeof",
                "stackalloc", "static", "string", "struct", "switch",
                "this", "throw", "true", "try", "typeof", "uint",
                "ulong", "unchecked", "unsafe", "ushort", "using",
                "virtual", "void", "volatile", "while"
            };

        private static readonly Dictionary<Type, string> TypesNames = new Dictionary<Type, string>
        {
            { typeof(void), "void" },
            { typeof(object), "object" },
            { typeof(bool), "bool" },
            { typeof(byte), "byte" },
            { typeof(int), "int" },
            { typeof(long), "long" },
            { typeof(float), "float" },
            { typeof(double), "double" },
            { typeof(string), "string" },
            { typeof(byte[]), "byte[]" }
        };

        public static string GetAlias(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            if (TypesNames.ContainsKey(type))
            {
                return TypesNames[type];
            }
            return type.ToString();
        }

        public static string Validate(string token)
        {
            if (token == null)
            {
                throw new ArgumentNullException("token");
            }

            if (token.Split('.').Intersect(CSharpReservedWords).Any())
            {
                throw new InvalidOperationException(
                    string.Format(CultureInfo.InvariantCulture, "Use of C# keywords in schema is prohibited: '{0}'.", token));
            }

            return token;
        }

        public static string RemoveComments(string source)
        {
            return Regex.Replace(
                source,
                @"/\*(.*?)\*/|//(.*?)\r?\n|""((\\[^\n]|[^""\n])*)""",
                match =>
                match.Value.StartsWith("/", StringComparison.Ordinal)
                    ? (match.Value.StartsWith("//", StringComparison.Ordinal) ? Environment.NewLine : string.Empty)
                    : match.Value,
                RegexOptions.Singleline);
        }

        public static string GetNamespace(ITemplate template, string schemaNamespace)
        {
            return Validate(template.ForceNamespace
                       ? template.UserDefinedNamespace
                       : string.IsNullOrEmpty(schemaNamespace)
                            ? template.UserDefinedNamespace
                            : schemaNamespace);
        }

        #region Extension methods

        public static bool IsNullable(this UnionSchema schema)
        {
            if (schema == null)
            {
                throw new ArgumentNullException("schema");
            }

            if (schema.Schemas.Count != 2)
            {
                return false;
            }

            if (schema.Schemas[0] is PrimitiveTypeSchema && schema.Schemas[1] is NullSchema)
            {
                return true;
            }

            if (schema.Schemas[1] is PrimitiveTypeSchema && schema.Schemas[0] is NullSchema)
            {
                return true;
            }

            return false;
        }

        public static string FirstLetterToLower(this string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                return input;
            }
            var asArray = input.ToCharArray();
            asArray[0] = char.ToLowerInvariant(asArray[0]);
            return new string(asArray);
        }

        #endregion extension methods
    }
}