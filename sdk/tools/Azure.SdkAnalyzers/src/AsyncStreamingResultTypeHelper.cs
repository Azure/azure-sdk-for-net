// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.CodeAnalysis;

namespace Azure.SdkAnalyzers
{
    internal static class AsyncStreamingResultTypeHelper
    {
        private const string AsyncStreamingClientResultMetadataName = "System.ClientModel.AsyncStreamingClientResult`1";
        private const string TaskMetadataName = "System.Threading.Tasks.Task`1";

        public static bool IsAsyncStreamingMethod(IMethodSymbol method, Compilation compilation)
        {
            INamedTypeSymbol taskType = compilation.GetTypeByMetadataName(TaskMetadataName);
            INamedTypeSymbol asyncStreamingClientResultType =
                compilation.GetTypeByMetadataName(AsyncStreamingClientResultMetadataName);

            if (taskType == null ||
                asyncStreamingClientResultType == null ||
                method.ReturnType is not INamedTypeSymbol returnType ||
                !SymbolEqualityComparer.Default.Equals(returnType.OriginalDefinition, taskType) ||
                returnType.TypeArguments[0] is not INamedTypeSymbol resultType)
            {
                return false;
            }

            for (INamedTypeSymbol current = resultType; current != null; current = current.BaseType)
            {
                if (SymbolEqualityComparer.Default.Equals(
                    current.OriginalDefinition,
                    asyncStreamingClientResultType))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
