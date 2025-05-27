// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
            var operationResponses = method.Operation.Responses;
            var response = operationResponses.FirstOrDefault(r => !r.IsErrorResponse);
            var responseBodyType = response?.BodyType;
            return responseBodyType is null ? null : ManagementClientGenerator.Instance.TypeFactory.CreateCSharpType(responseBodyType);
        }

        public static CSharpType GetOperationMethodReturnType(this InputServiceMethod method, bool isAsync, CSharpType resourceClientCSharpType, CSharpType resourceDataType)
        {
            bool isLongRunningOperation = method.IsLongRunningOperation();
            var responseBodyCSharpType = method.GetResponseBodyType();

            // Determine the content type for the operation
            CSharpType? contentType = DetermineContentType(responseBodyCSharpType, resourceClientCSharpType, resourceDataType);

            // Determine the appropriate wrapper type based on operation characteristics
            CSharpType wrapperType;
            if (isLongRunningOperation)
            {
                wrapperType = contentType is not null
                    ? new CSharpType(typeof(Azure.ResourceManager.ArmOperation<>), contentType)
                    : typeof(Azure.ResourceManager.ArmOperation);
            }
            else
            {
                wrapperType = contentType is not null ? new CSharpType(typeof(Azure.Response<>), contentType) : typeof(Azure.Response);
            }

            // Add Task<> wrapper if async
            return isAsync
                ? new CSharpType(typeof(System.Threading.Tasks.Task<>), wrapperType)
                : wrapperType;
        }

        private static CSharpType? DetermineContentType(CSharpType? responseBodyCSharpType, CSharpType resourceClientCSharpType, CSharpType resourceDataType)
        {
            // Use response body type if it exists and differs from the resource data type,
            // otherwise use the resource client type
            return (responseBodyCSharpType != resourceDataType)
                ? responseBodyCSharpType
                : resourceClientCSharpType;
        }
    }
}