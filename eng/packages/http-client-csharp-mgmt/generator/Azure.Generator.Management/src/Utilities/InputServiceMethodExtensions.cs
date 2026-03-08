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
                return returnType is null ? null : ManagementClientGenerator.Instance.TypeFactory.CreateCSharpType(returnType);
            }

            var operationResponses = method.Operation.Responses;
            var response = operationResponses.FirstOrDefault(r => !r.IsErrorResponse);
            var responseBodyType = response?.BodyType;
            return responseBodyType is null ? null : ManagementClientGenerator.Instance.TypeFactory.CreateCSharpType(responseBodyType);
        }

        /// <summary>
        /// Tries to extract a list type from a model-wrapped response (e.g., a model with a "value" array property).
        /// This handles the pattern used by ArmListSinglePageByParent where the response is a model like
        /// { value: Resource[], nextLink?: string } rather than a direct array.
        /// </summary>
        /// <param name="method">The input service method.</param>
        /// <param name="listType">The CSharpType of the list property (e.g., IList&lt;Resource&gt;).</param>
        /// <param name="listPropertySerializedName">The serialized name of the list property in JSON (e.g., "value").</param>
        /// <returns>True if the response body is a model wrapping a list; false otherwise.</returns>
        public static bool TryGetModelWrappedListType(this InputServiceMethod method, out CSharpType? listType, out string? listPropertySerializedName)
        {
            listType = null;
            listPropertySerializedName = null;

            var operationResponses = method.Operation.Responses;
            var response = operationResponses.FirstOrDefault(r => !r.IsErrorResponse);
            if (response?.BodyType is not InputModelType modelType)
            {
                return false;
            }

            // Look for a property whose type is an array - this is the list of items in a wrapped list result
            var arrayProperty = modelType.Properties.FirstOrDefault(p => p.Type is InputArrayType);
            if (arrayProperty is null)
            {
                return false;
            }

            listType = ManagementClientGenerator.Instance.TypeFactory.CreateCSharpType(arrayProperty.Type);
            listPropertySerializedName = arrayProperty.SerializedName;
            return true;
        }
    }
}