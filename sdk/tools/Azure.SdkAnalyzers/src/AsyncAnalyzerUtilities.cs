// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Runtime.CompilerServices;
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
        private INamedTypeSymbol NotifyCompletionTypeSymbol { get; }
        private INamedTypeSymbol TaskAsyncEnumerableExtensionsSymbol { get; }
        private INamedTypeSymbol AzureTaskExtensionsType { get; }

        public AsyncAnalyzerUtilities(Compilation compilation)
        {
            BooleanTypeSymbol = compilation.GetSpecialType(SpecialType.System_Boolean);
            TaskTypeSymbol = compilation.GetTypeByMetadataName(typeof(Task).FullName);
            TaskOfTTypeSymbol = compilation.GetTypeByMetadataName(typeof(Task<>).FullName);
            ValueTaskTypeSymbol = compilation.GetTypeByMetadataName(typeof(ValueTask).FullName);
            ValueTaskOfTTypeSymbol = compilation.GetTypeByMetadataName(typeof(ValueTask<>).FullName);
            NotifyCompletionTypeSymbol = compilation.GetTypeByMetadataName(typeof(INotifyCompletion).FullName);
            TaskAsyncEnumerableExtensionsSymbol = compilation.GetTypeByMetadataName("System.Threading.Tasks.TaskAsyncEnumerableExtensions");
            AzureTaskExtensionsType = compilation.GetTypeByMetadataName("Azure.Core.Pipeline.TaskExtensions");
        }

        public bool IsAsyncParameter(IParameterSymbol parameter)
            => parameter.Name == "async" && SymbolEqualityComparer.Default.Equals(parameter.Type, BooleanTypeSymbol);

        public bool IsEnsureCompleted(IMethodSymbol method)
            => AzureTaskExtensionsType != null &&
               method.Name == "EnsureCompleted" &&
               method.IsExtensionMethod &&
               method.Parameters.Length == 1 &&
               SymbolEqualityComparer.Default.Equals(method.ReceiverType, AzureTaskExtensionsType);

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

            if (method.Parameters.Length == 2 && SymbolEqualityComparer.Default.Equals(method.ReceiverType, TaskAsyncEnumerableExtensionsSymbol))
            {
                return true;
            }

            return false;
        }

        public bool IsGetAwaiter(IMethodSymbol method)
        {
            if (method.Name != nameof(Task.GetAwaiter))
            {
                return false;
            }

            if (!(method.Parameters.Length == 0 || method.Parameters.Length == 1 && method.IsExtensionMethod))
            {
                return false;
            }

            if (method.ReturnsVoid || !(method.ReturnType is INamedTypeSymbol returnType))
            {
                return false;
            }

            if (!returnType.AllInterfaces.Contains(NotifyCompletionTypeSymbol))
            {
                return false;
            }

            var hasGetResult = false;
            var hasIsCompleted = false;
            foreach (var member in returnType.GetMembers())
            {
                hasGetResult |= IsAwaiterGetResultMethod(member);
                hasIsCompleted |= IsIsCompletedProperty(member);

                if (hasIsCompleted && hasGetResult)
                {
                    return true;
                }
            }

            return false;
        }

        public bool IsAwaiterGetResultMethod(ISymbol symbol)
            => symbol.Name == nameof(TaskAwaiter.GetResult) &&
               IsAwaiterAccessibleMember(symbol) &&
               symbol is IMethodSymbol getResultCandidate &&
               getResultCandidate.Parameters.Length == 0;

        private bool IsIsCompletedProperty(ISymbol symbol)
            => symbol.Name == nameof(TaskAwaiter.IsCompleted) &&
               IsAwaiterAccessibleMember(symbol) &&
               symbol is IPropertySymbol property &&
               property.IsReadOnly &&
               SymbolEqualityComparer.Default.Equals(property.GetMethod.ReturnType, BooleanTypeSymbol);

        private static bool IsAwaiterAccessibleMember(ISymbol symbol) =>
            symbol.DeclaredAccessibility switch {
                Accessibility.Public => true,
                Accessibility.ProtectedOrInternal => true,
                Accessibility.Internal => true,
                _ => false
            };

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
