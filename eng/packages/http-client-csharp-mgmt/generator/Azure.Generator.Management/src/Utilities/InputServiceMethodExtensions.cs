// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Linq;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;

namespace Azure.Generator.Management.Utilities
{
    internal static class InputServiceMethodExtensions
    {
        public static bool IsLongRunningOperation(this InputServiceMethod method)
        {
            return method is InputLongRunningServiceMethod || method is InputLongRunningPagingServiceMethod;
        }

        public static OperationFinalStateVia GetOperationFinalStateVia(this InputServiceMethod method)
        {
            if (method is InputLongRunningServiceMethod lroMethod)
            {
                return (OperationFinalStateVia)lroMethod.LongRunningServiceMetadata.FinalStateVia;
            }
            else if (method is InputLongRunningPagingServiceMethod lroPagingMethod)
            {
                return (OperationFinalStateVia)lroPagingMethod.LongRunningServiceMetadata.FinalStateVia;
            }
            return OperationFinalStateVia.Location;
        }

        public static CSharpType? GetResponseBodyType(this InputServiceMethod method)
        {
            // For long-running operations, get the response body type from LongRunningServiceMetadata.ReturnType
            if (method is InputLongRunningServiceMethod lroMethod)
            {
                var returnType = lroMethod.LongRunningServiceMetadata.ReturnType;
                return returnType is null ? null : UnwrapArrayModel(returnType);
            }

            var operationResponses = method.Operation.Responses;
            var response = operationResponses.FirstOrDefault(r => !r.IsErrorResponse);
            var responseBodyType = response?.BodyType;
            return responseBodyType is null ? null : UnwrapArrayModel(responseBodyType);
        }

        /// <summary>
        /// Unwraps a model that contains a single array property, returning the array type directly.
        /// This allows models like { result: FooDependency[] } to be treated as FooDependency[] for Pageable conversion.
        /// </summary>
        private static CSharpType? UnwrapArrayModel(InputType inputType)
        {
            // Check if the input type is a model type
            if (inputType is InputModelType modelType)
            {
                // Get all non-discriminator properties
                var properties = modelType.Properties.Where(p => !p.IsDiscriminator).ToArray();

                // If there's exactly one property and it's a list type, unwrap to that list type
                if (properties.Length == 1 && properties[0].Type != null)
                {
                    var propertyType = properties[0].Type;
                    var csharpPropertyType = ManagementClientGenerator.Instance.TypeFactory.CreateCSharpType(propertyType);

                    // Check if it's a list type by examining the CSharpType
                    if (csharpPropertyType != null && csharpPropertyType.IsList)
                    {
                        return csharpPropertyType;
                    }
                }
            }

            return ManagementClientGenerator.Instance.TypeFactory.CreateCSharpType(inputType);
        }
    }
}