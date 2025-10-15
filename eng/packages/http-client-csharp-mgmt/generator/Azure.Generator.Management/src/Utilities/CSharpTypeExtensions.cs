// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.ResourceManager;
using Microsoft.TypeSpec.Generator.Primitives;
using System.Threading.Tasks;

namespace Azure.Generator.Management.Utilities
{
    internal static class CSharpTypeExtensions
    {
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
            return ManagementClientGenerator.Instance.OutputLibrary.IsModelFactoryModelType(type);
        }
    }
}
