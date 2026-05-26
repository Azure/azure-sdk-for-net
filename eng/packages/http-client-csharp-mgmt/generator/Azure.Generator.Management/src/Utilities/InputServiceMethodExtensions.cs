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
            InputType? responseBodyType;
            if (method is InputLongRunningServiceMethod lroMethod)
            {
                responseBodyType = GetLongRunningResponseBodyType(lroMethod);
            }
            else
            {
                responseBodyType = GetOperationResponseBodyType(method);
            }
            return responseBodyType is null ? null : ManagementClientGenerator.Instance.TypeFactory.CreateCSharpType(responseBodyType);
        }

        private static InputType? GetLongRunningResponseBodyType(InputLongRunningServiceMethod method)
        {
            if (method.Operation.HttpMethod == "PATCH" && method.Operation.Responses.Any(IsSuccessfulNoContentResponse))
            {
                return null;
            }

            return method.LongRunningServiceMetadata.ReturnType;
        }

        private static InputType? GetOperationResponseBodyType(InputServiceMethod method)
        {
            var responses = method.Operation.Responses.Where(r => !r.IsErrorResponse);
            return responses.FirstOrDefault(r => r.BodyType is not null)?.BodyType
                ?? responses.FirstOrDefault()?.BodyType;
        }

        private static bool IsSuccessfulNoContentResponse(InputOperationResponse response)
        {
            return !response.IsErrorResponse
                && response.BodyType is null
                && response.StatusCodes.Any(statusCode => statusCode is 200 or 204);
        }
    }
}
