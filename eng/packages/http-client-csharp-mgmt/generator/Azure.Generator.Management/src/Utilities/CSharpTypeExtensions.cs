// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.ResourceManager;
using Azure.ResourceManager.Models;
using Microsoft.TypeSpec.Generator.Primitives;
using Microsoft.TypeSpec.Generator.Providers;
using System;
using System.Collections.Generic;
using System.IO;
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
            // For nullable value types, we need to append '?' to the type name for XML documentation
            if (type.IsValueType && type.IsNullable)
            {
                return $"{type.Name}?";
            }
            return type.Name;
        }

        /// <summary>
        /// Returns true if <paramref name="type"/> is, or derives from, <see cref="TrackedResourceData"/>.
        /// Walks both generated <see cref="Microsoft.TypeSpec.Generator.Providers.ModelProvider"/> base types
        /// (via <c>ManagementClientGenerator.Instance.TypeFactory.CSharpTypeMap</c>) and framework base types.
        /// </summary>
        public static bool DerivesFromTrackedResourceData(this CSharpType type)
        {
            var visited = new HashSet<CSharpType>();
            CSharpType? current = type;
            while (current is not null && visited.Add(current))
            {
                if (current.IsFrameworkType && current.FrameworkType == typeof(TrackedResourceData))
                {
                    return true;
                }

                if (ManagementClientGenerator.Instance.TypeFactory.CSharpTypeMap.TryGetValue(current, out var typeProvider)
                    && typeProvider is ModelProvider modelProvider)
                {
                    current = modelProvider.BaseType;
                }
                else if (current.IsFrameworkType && current.FrameworkType.BaseType is { } frameworkBase)
                {
                    current = new CSharpType(frameworkBase);
                }
                else
                {
                    current = null;
                }
            }
            return false;
        }
    }
}
