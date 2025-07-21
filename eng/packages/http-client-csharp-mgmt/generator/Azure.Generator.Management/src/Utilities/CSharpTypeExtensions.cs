// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Primitives;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Azure.Generator.Management.Utilities
{
    internal static class CSharpTypeExtensions
    {
        public static CSharpType WrapAsync(this CSharpType type, bool isAsync)
        {
            return isAsync
                ? new CSharpType(typeof(System.Threading.Tasks.Task<>), type)
                : type;
        }

        public static CSharpType WrapResponse(this CSharpType? type, bool isLongRunning)
        {
            if (isLongRunning)
            {
                return type is not null
                    ? new CSharpType(typeof(Azure.ResourceManager.ArmOperation<>), type)
                    : typeof(Azure.ResourceManager.ArmOperation);
            }
            else
            {
                return type is not null
                    ? new CSharpType(typeof(Azure.Response<>), type)
                    : typeof(Azure.Response);
            }
        }

        public static CSharpType UnWrap(this CSharpType type)
        {
            var currentType = type;

            // Unwrap Task<T>
            if (currentType.IsFrameworkType && currentType.IsGenericType && currentType.FrameworkType.GetGenericTypeDefinition() == typeof(Task<>))
            {
                currentType = currentType.Arguments[0];
            }

            // Unwrap Response<T> or ArmOperation<T>
            if (currentType.IsFrameworkType && currentType.IsGenericType)
            {
                var genericDef = currentType.FrameworkType.GetGenericTypeDefinition();
                if (genericDef == typeof(Azure.Response<>) || genericDef == typeof(Azure.ResourceManager.ArmOperation<>))
                {
                    currentType = currentType.Arguments[0];
                }
            }

            return currentType;
        }
    }
}
