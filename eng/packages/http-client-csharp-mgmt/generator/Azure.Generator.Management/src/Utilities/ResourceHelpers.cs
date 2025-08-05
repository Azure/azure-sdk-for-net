// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Generator.Management.Models;
using Microsoft.TypeSpec.Generator.Input.Extensions;

namespace Azure.Generator.Management.Utilities
{
    internal static class ResourceHelpers
    {
        public static string GetClientDiagnosticFieldName(string resourceName)
        {
            var fieldName = $"{resourceName}ClientDiagnostics".ToVariableName();

            return $"_{fieldName}";
        }

        public static string GetRestClientFieldName(string restClientName)
        {
            var fieldName = $"{restClientName}RestClient".ToVariableName();
            return $"_{fieldName}";
        }

        /// <summary>
        /// Gets the appropriate method name for a resource operation based on its kind.
        /// </summary>
        /// <param name="operationKind">The kind of resource operation.</param>
        /// <param name="isAsync">Whether this is an async method.</param>
        /// <returns>The method name to use, or null if no override is needed.</returns>
        public static string? GetOperationMethodName(ResourceOperationKind operationKind, bool isAsync)
        {
            return operationKind switch
            {
                ResourceOperationKind.Create => isAsync ? "CreateOrUpdateAsync" : "CreateOrUpdate",
                _ => null
            };
        }

        public static bool IsFakeLroMethod(ResourceOperationKind operationKind)
        {
            // Fake LRO methods are used for operations that are not true LROs but are treated as such for consistency.
            return operationKind == ResourceOperationKind.Create
                || operationKind == ResourceOperationKind.Delete;
        }
    }
}
