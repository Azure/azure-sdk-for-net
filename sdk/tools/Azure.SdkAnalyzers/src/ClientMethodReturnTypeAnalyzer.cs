// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Azure.SdkAnalyzers
{
    /// <summary>
    /// AZC0015: client service methods (async methods and their synchronous counterparts) must
    /// return one of the approved client result types. Azure.Core clients use the
    /// Response/Pageable/Operation family; System.ClientModel clients use the ClientResult /
    /// CollectionResult family.
    /// </summary>
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class ClientMethodReturnTypeAnalyzer : SymbolAnalyzerBase
    {
        private const string ClientSuffix = "Client";
        private const string AsyncSuffix = "Async";
        private const string TaskTypeName = "Task";
        private const string SystemThreadingTasksNamespace = "System.Threading.Tasks";
        private const string AzureNamespace = "Azure";
        private const string SystemClientModelNamespace = "System.ClientModel";

        public override SymbolKind[] SymbolKinds { get; } = new[] { SymbolKind.NamedType };

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } =
            ImmutableArray.Create(Descriptors.AZC0015);

        public override void Analyze(SymbolAnalysisContext context)
        {
            var type = (INamedTypeSymbol)context.Symbol;
            if (type.TypeKind != TypeKind.Class ||
                !type.Name.EndsWith(ClientSuffix, StringComparison.Ordinal) ||
                !IsPubliclyAccessible(type))
            {
                return;
            }

            foreach (var member in type.GetMembers())
            {
                var method = member as IMethodSymbol;
                if (method == null ||
                    method.DeclaredAccessibility != Accessibility.Public ||
                    method.AssociatedSymbol is IPropertySymbol ||
                    !method.Name.EndsWith(AsyncSuffix, StringComparison.Ordinal))
                {
                    continue;
                }

                CheckReturnType(context, method);

                // The synchronous counterpart is expected to return the sync equivalent, so validate it too.
                string syncName = method.Name.Substring(0, method.Name.Length - AsyncSuffix.Length);
                IMethodSymbol syncMethod = FindMatchingSyncMethod(type, syncName, method);
                if (syncMethod != null)
                {
                    CheckReturnType(context, syncMethod);
                }
            }
        }

        private static bool IsPubliclyAccessible(INamedTypeSymbol type)
        {
            for (INamedTypeSymbol current = type; current != null; current = current.ContainingType)
            {
                if (current.DeclaredAccessibility != Accessibility.Public)
                {
                    return false;
                }
            }

            return true;
        }

        private static void CheckReturnType(SymbolAnalysisContext context, IMethodSymbol method)
        {
            if (!IsValidClientReturnType(method.ReturnType))
            {
                context.ReportDiagnostic(Diagnostic.Create(
                    Descriptors.AZC0015,
                    method.Locations.FirstOrDefault(),
                    method.ReturnType.ToDisplayString()));
            }
        }

        private static bool IsValidClientReturnType(ITypeSymbol returnType)
        {
            ITypeSymbol unwrapped = returnType;
            if (returnType is INamedTypeSymbol named &&
                named.IsGenericType &&
                named.TypeArguments.Length == 1 &&
                named.Name == TaskTypeName &&
                named.ContainingNamespace != null &&
                named.ContainingNamespace.ToDisplayString() == SystemThreadingTasksNamespace)
            {
                unwrapped = named.TypeArguments[0];
            }

            // Azure.Core return types.
            if (IsOrInheritsFrom(unwrapped, "Response", AzureNamespace) ||
                IsOrInheritsFrom(unwrapped, "NullableResponse", AzureNamespace) ||
                IsOrInheritsFrom(unwrapped, "Operation", AzureNamespace) ||
                IsOrInheritsFrom(returnType, "Pageable", AzureNamespace) ||
                IsOrInheritsFrom(returnType, "AsyncPageable", AzureNamespace))
            {
                return true;
            }

            // System.ClientModel (unbranded/SCM) return types.
            if (IsOrInheritsFrom(unwrapped, "ClientResult", SystemClientModelNamespace) ||
                IsOrInheritsFrom(returnType, "CollectionResult", SystemClientModelNamespace) ||
                IsOrInheritsFrom(returnType, "AsyncCollectionResult", SystemClientModelNamespace))
            {
                return true;
            }

            return false;
        }

        private static bool IsOrInheritsFrom(ITypeSymbol type, string typeName, string namespaceFullName)
        {
            for (ITypeSymbol current = type; current != null; current = current.BaseType)
            {
                if (current.Name == typeName &&
                    current.ContainingNamespace != null &&
                    current.ContainingNamespace.ToDisplayString() == namespaceFullName)
                {
                    return true;
                }
            }

            return false;
        }

        private static IMethodSymbol FindMatchingSyncMethod(INamedTypeSymbol type, string syncName, IMethodSymbol asyncMethod)
        {
            foreach (var candidate in type.GetMembers(syncName).OfType<IMethodSymbol>())
            {
                if (candidate.DeclaredAccessibility == Accessibility.Public &&
                    candidate.TypeParameters.Length == asyncMethod.TypeParameters.Length &&
                    ParametersMatch(candidate, asyncMethod))
                {
                    return candidate;
                }
            }

            return null;
        }

        private static bool ParametersMatch(IMethodSymbol candidate, IMethodSymbol asyncMethod)
        {
            if (candidate.Parameters.Length != asyncMethod.Parameters.Length)
            {
                return false;
            }

            for (int i = 0; i < candidate.Parameters.Length; i++)
            {
                IParameterSymbol a = candidate.Parameters[i];
                IParameterSymbol b = asyncMethod.Parameters[i];
                if (a.RefKind != b.RefKind ||
                    a.IsParams != b.IsParams ||
                    !SymbolEqualityComparer.Default.Equals(a.Type, b.Type))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
