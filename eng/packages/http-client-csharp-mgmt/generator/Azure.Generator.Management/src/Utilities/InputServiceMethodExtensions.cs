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
            // Check if the input type is a model with a single array property
            var arrayPropertyName = GetArrayPropertyName(inputType);
            if (arrayPropertyName != null)
            {
                // Get the property type and convert it to CSharpType
                var modelType = (InputModelType)inputType;
                var property = modelType.Properties.First(p => !p.IsDiscriminator);
                return ManagementClientGenerator.Instance.TypeFactory.CreateCSharpType(property.Type!);
            }

            return ManagementClientGenerator.Instance.TypeFactory.CreateCSharpType(inputType);
        }

        /// <summary>
        /// Checks if an InputType is a model containing a single array property, and returns the property name if so.
        /// Returns null if the type is not a wrapped array model.
        /// </summary>
        public static string? GetArrayPropertyName(InputType? inputType)
        {
            if (inputType is InputModelType modelType)
            {
                // Get all non-discriminator properties
                var properties = modelType.Properties.Where(p => !p.IsDiscriminator).ToArray();

                // If there's exactly one property and it's a list type, return the property name
                if (properties.Length == 1 && properties[0].Type != null)
                {
                    var propertyType = properties[0].Type;
                    var csharpPropertyType = ManagementClientGenerator.Instance.TypeFactory.CreateCSharpType(propertyType);

                    if (csharpPropertyType != null && csharpPropertyType.IsList)
                    {
                        return properties[0].Name;
                    }
                }
            }

            return null;
        }
    }
}