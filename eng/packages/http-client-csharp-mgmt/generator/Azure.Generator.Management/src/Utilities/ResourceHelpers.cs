// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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
    }
}
