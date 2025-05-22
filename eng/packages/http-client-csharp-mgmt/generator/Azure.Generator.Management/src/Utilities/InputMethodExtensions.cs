// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using Azure.Core;
using Microsoft.TypeSpec.Generator.Input;
using Microsoft.TypeSpec.Generator.Primitives;

namespace Azure.Generator.Management.Utilities
{
    internal static class InputMethodExtensions
    {
        public static bool IsLongRunningOperation(this InputServiceMethod method)
        {
            return method is InputLongRunningServiceMethod || method is InputLongRunningPagingServiceMethod;
        }

        public static InputType? GetResponseBodyInputType(this InputServiceMethod method)
        {
            var operationResponses = method.Operation.Responses;
            var response = operationResponses.FirstOrDefault(r => !r.IsErrorResponse);
            return response?.BodyType;
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

        public static CSharpType? GetResponseBodyCSharpType(this InputServiceMethod method)
        {
            var responseBodyType = method.GetResponseBodyInputType();
            return responseBodyType is null ? null : ManagementClientGenerator.Instance.TypeFactory.CreateCSharpType(responseBodyType);
        }

        public static CSharpType GetOperationMethodReturnType(this InputServiceMethod method, bool isAsync, CSharpType resourceClientCSharpType, CSharpType resourceDataType)
        {
            bool isLongRunningOperation = method.IsLongRunningOperation();
            var responseBodyCSharpType = method.GetResponseBodyCSharpType();
            CSharpType rawReturnType = method.GetOperationMethodRawReturnType(resourceClientCSharpType, resourceDataType);

            if (isLongRunningOperation)
            {
                if (responseBodyCSharpType is not null)
                {
                    return isAsync ? new CSharpType(typeof(System.Threading.Tasks.Task<>), new CSharpType(typeof(Azure.ResourceManager.ArmOperation<>), rawReturnType)) : new CSharpType(typeof(Azure.ResourceManager.ArmOperation<>), rawReturnType);
                }
                else
                {
                    return isAsync ? new CSharpType(typeof(System.Threading.Tasks.Task<>), typeof(Azure.ResourceManager.ArmOperation)) : typeof(Azure.ResourceManager.ArmOperation);
                }
            }
            return isAsync ? new CSharpType(typeof(System.Threading.Tasks.Task<>), new CSharpType(typeof(Azure.Response<>), rawReturnType)) : new CSharpType(typeof(Azure.Response<>), rawReturnType);
        }

        private static CSharpType GetOperationMethodRawReturnType(this InputServiceMethod method, CSharpType resourceClientCSharpType, CSharpType resourceDataType)
        {
            var responseBodyCSharpType = method.GetResponseBodyCSharpType();
            CSharpType genericReturnType = resourceClientCSharpType;

            if (responseBodyCSharpType is not null && responseBodyCSharpType != resourceDataType)
            {
                genericReturnType = responseBodyCSharpType;
            }

            return genericReturnType;
        }
    }
}
