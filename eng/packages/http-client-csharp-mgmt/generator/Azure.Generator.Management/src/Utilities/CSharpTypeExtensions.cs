// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager;
using Microsoft.TypeSpec.Generator.Primitives;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.Generator.Management.Utilities
{
    internal static class CSharpTypeExtensions
    {
        /// <summary>
        /// The set of primitive types that have a direct <c>RequestContent.Create</c> overload.
        /// </summary>
        private static readonly HashSet<Type> _requestContentPrimitiveTypes = new()
        {
            typeof(string),
            typeof(BinaryData),
            typeof(Stream),
            typeof(byte[]),
            typeof(ReadOnlyMemory<byte>),
        };

        /// <summary>
        /// Returns true if the type is a primitive type that can be passed directly to
        /// <c>RequestContent.Create(value)</c> without model serialization.
        /// </summary>
        public static bool CanCreateRequestContent(this CSharpType type)
        {
            return type.IsFrameworkType && _requestContentPrimitiveTypes.Contains(type.FrameworkType);
        }
        public static CSharpType WrapAsync(this CSharpType type, bool isAsync)
        {
            return isAsync
                ? new CSharpType(typeof(Task<>), type)
                : type;
        }

        public static CSharpType WrapResponse(this CSharpType? type, bool isLongRunning)
        {
            if (isLongRunning)
            {
                return type is not null
                    ? new CSharpType(typeof(ArmOperation<>), type)
                    : typeof(ArmOperation);
            }
            else
            {
                return type is not null
                    ? new CSharpType(typeof(Response<>), type)
                    : typeof(Response);
            }
        }

        public static bool IsModelType(this CSharpType type)
        {
            return ManagementClientGenerator.Instance.OutputLibrary.IsModelType(type);
        }

        public static string GetXmlDocTypeName(this CSharpType type)
        {
            // TODO: Remove this workaround when the base C# generator supports formatting generated methods as XML doc cref elements.
            // https://github.com/microsoft/typespec/issues/11202
            var typeName = GetTypeName(type);
            if (type.Arguments.Count > 0)
            {
                typeName = $"{typeName}{{{string.Join(", ", type.Arguments.Select(GetXmlDocTypeName))}}}";
            }

            // For nullable value types, we need to append '?' to the type name for XML documentation
            if (type.IsValueType && type.IsNullable)
            {
                return $"{typeName}?";
            }
            return typeName;
        }

        private static string GetTypeName(CSharpType type)
        {
            if (type.IsFrameworkType && GetFrameworkTypeAlias(type.FrameworkType) is { } frameworkTypeAlias)
            {
                return frameworkTypeAlias;
            }

            if (type.Arguments.Count > 0 && type.IsFrameworkType)
            {
                return StripGenericArity(type.FrameworkType.Name);
            }

            if (string.IsNullOrEmpty(type.Namespace))
            {
                return StripGenericArity(type.Name);
            }

            return $"{type.Namespace}.{StripGenericArity(type.Name)}";
        }

        private static string StripGenericArity(string typeName)
        {
            var arityIndex = typeName.IndexOf('`');
            return arityIndex < 0 ? typeName : typeName[..arityIndex];
        }

        private static string? GetFrameworkTypeAlias(Type frameworkType) => frameworkType switch
        {
            _ when frameworkType == typeof(bool) => "bool",
            _ when frameworkType == typeof(byte) => "byte",
            _ when frameworkType == typeof(sbyte) => "sbyte",
            _ when frameworkType == typeof(char) => "char",
            _ when frameworkType == typeof(decimal) => "decimal",
            _ when frameworkType == typeof(double) => "double",
            _ when frameworkType == typeof(float) => "float",
            _ when frameworkType == typeof(int) => "int",
            _ when frameworkType == typeof(uint) => "uint",
            _ when frameworkType == typeof(long) => "long",
            _ when frameworkType == typeof(ulong) => "ulong",
            _ when frameworkType == typeof(object) => "object",
            _ when frameworkType == typeof(short) => "short",
            _ when frameworkType == typeof(ushort) => "ushort",
            _ when frameworkType == typeof(string) => "string",
            _ => null
        };
    }
}
