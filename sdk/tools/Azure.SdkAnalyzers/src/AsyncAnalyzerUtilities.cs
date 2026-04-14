// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;

namespace Azure.SdkAnalyzers
{
    internal sealed class AsyncAnalyzerUtilities
    {
        private INamedTypeSymbol BooleanTypeSymbol { get; }
        private INamedTypeSymbol TaskTypeSymbol { get; }
        private INamedTypeSymbol TaskOfTTypeSymbol { get; }
        private INamedTypeSymbol ValueTaskTypeSymbol { get; }
        private INamedTypeSymbol ValueTaskOfTTypeSymbol { get; }
        private INamedTypeSymbol TaskAsyncEnumerableExtensionsSymbol { get; }

        public AsyncAnalyzerUtilities(Compilation compilation)
        {
            BooleanTypeSymbol = compilation.GetSpecialType(SpecialType.System_Boolean);
            TaskTypeSymbol = compilation.GetTypeByMetadataName(typeof(Task).FullName);
            TaskOfTTypeSymbol = compilation.GetTypeByMetadataName(typeof(Task<>).FullName);
            ValueTaskTypeSymbol = compilation.GetTypeByMetadataName(typeof(ValueTask).FullName);
            ValueTaskOfTTypeSymbol = compilation.GetTypeByMetadataName(typeof(ValueTask<>).FullName);
            TaskAsyncEnumerableExtensionsSymbol = compilation.GetTypeByMetadataName("System.Threading.Tasks.TaskAsyncEnumerableExtensions");
        }

        public bool IsAsyncParameter(IParameterSymbol parameter)
            => parameter.Name == "async" && SymbolEqualityComparer.Default.Equals(parameter.Type, BooleanTypeSymbol);

        public bool IsConfigureAwait(IMethodSymbol method)
        {
            if (method.Name != nameof(Task.ConfigureAwait))
            {
                return false;
            }

            if (method.Parameters.Length == 1 && IsTaskType(method.ReceiverType))
            {
                return true;
            }

            // Extension method call: e.g. asyncEnumerable.ConfigureAwait(true)
            // For reduced extension calls, ContainingType or ReducedFrom.ContainingType
            // points to the static extensions class, not the receiver type.
            var containingType = method.ReducedFrom?.ContainingType ?? method.ContainingType;
            if (SymbolEqualityComparer.Default.Equals(containingType, TaskAsyncEnumerableExtensionsSymbol))
            {
                return true;
            }

            return false;
        }

        public bool IsTaskType(ITypeSymbol type)
        {
            if (type == null)
            {
                return false;
            }

            if (SymbolEqualityComparer.Default.Equals(type, TaskTypeSymbol) || SymbolEqualityComparer.Default.Equals(type, ValueTaskTypeSymbol))
            {
                return true;
            }

            if (type is INamedTypeSymbol namedType && namedType.IsGenericType)
            {
                var genericType = namedType.ConstructedFrom;
                if (SymbolEqualityComparer.Default.Equals(genericType, TaskOfTTypeSymbol) || SymbolEqualityComparer.Default.Equals(genericType, ValueTaskOfTTypeSymbol))
                {
                    return true;
                }
            }

            if (type.TypeKind == TypeKind.Error)
            {
                return type.Name.Equals("Task") || type.Name.Equals("ValueTask");
            }

            return false;
        }
    }
}
