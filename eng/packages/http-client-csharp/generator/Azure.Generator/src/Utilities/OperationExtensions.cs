// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.TypeSpec.Generator.Input;
using System;
using System.Linq;

namespace Azure.Generator.Utilities
{
    internal static class OperationExtensions
    {
        public static string GetHttpPath(this InputOperation operation)
        {
            var path = operation.Path;
            // Do not trim the tenant resource path '/'.
            return (path?.Length == 1 ? path : path?.TrimEnd('/')) ??
                throw new InvalidOperationException($"Cannot get HTTP path from operation {operation.Name}");
        }

        public static InputOperationResponse? GetServiceResponse(this InputOperation operation, int code = 200)
        {
            return operation.Responses.FirstOrDefault(r => r.StatusCodes.Contains(code));
        }
    }
}
