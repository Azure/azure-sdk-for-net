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
    /// AZC0004: public asynchronous client methods must have a synchronous counterpart unless
    /// their result type is inherently asynchronous.
    /// </summary>
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class ClientMethodSyncAnalyzer : SymbolAnalyzerBase
    {
        private const string AsyncSuffix = "Async";
        private const string ClientSuffix = "Client";

        public override SymbolKind[] SymbolKinds { get; } = new[] { SymbolKind.NamedType };

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } =
            ImmutableArray.Create(Descriptors.AZC0004);

        public override void Analyze(SymbolAnalysisContext context)
        {
            var type = (INamedTypeSymbol)context.Symbol;
            if (type.TypeKind != TypeKind.Class ||
                !type.Name.EndsWith(ClientSuffix, StringComparison.Ordinal) ||
                !IsPubliclyAccessible(type))
            {
                return;
            }

            foreach (IMethodSymbol method in type.GetMembers().OfType<IMethodSymbol>())
            {
                if (method.DeclaredAccessibility != Accessibility.Public ||
                    method.AssociatedSymbol is IPropertySymbol ||
                    !method.Name.EndsWith(AsyncSuffix, StringComparison.Ordinal) ||
                    AsyncStreamingResultTypeHelper.IsAsyncStreamingMethod(method, context.Compilation))
                {
                    continue;
                }

                string syncName = method.Name.Substring(0, method.Name.Length - AsyncSuffix.Length);
                if (!type.GetMembers(syncName).OfType<IMethodSymbol>().Any(candidate =>
                    candidate.DeclaredAccessibility == Accessibility.Public &&
                    SignaturesMatch(candidate, method)))
                {
                    context.ReportDiagnostic(Diagnostic.Create(
                        Descriptors.AZC0004,
                        method.Locations.FirstOrDefault()));
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

        private static bool SignaturesMatch(IMethodSymbol candidate, IMethodSymbol asyncMethod)
        {
            if (candidate.TypeParameters.Length != asyncMethod.TypeParameters.Length ||
                candidate.Parameters.Length != asyncMethod.Parameters.Length)
            {
                return false;
            }

            for (int i = 0; i < candidate.TypeParameters.Length; i++)
            {
                if (!string.Equals(
                    candidate.TypeParameters[i].Name,
                    asyncMethod.TypeParameters[i].Name,
                    StringComparison.Ordinal))
                {
                    return false;
                }
            }

            for (int i = 0; i < candidate.Parameters.Length; i++)
            {
                IParameterSymbol candidateParameter = candidate.Parameters[i];
                IParameterSymbol asyncParameter = asyncMethod.Parameters[i];
                if (!string.Equals(candidateParameter.Name, asyncParameter.Name, StringComparison.Ordinal) ||
                    candidateParameter.RefKind != asyncParameter.RefKind ||
                    candidateParameter.IsParams != asyncParameter.IsParams ||
                    !TypesMatch(candidateParameter.Type, asyncParameter.Type))
                {
                    return false;
                }
            }

            return true;
        }

        private static bool TypesMatch(ITypeSymbol left, ITypeSymbol right)
        {
            if (left is ITypeParameterSymbol leftTypeParameter)
            {
                return right is ITypeParameterSymbol rightTypeParameter &&
                    string.Equals(leftTypeParameter.Name, rightTypeParameter.Name, StringComparison.Ordinal);
            }

            if (left is IArrayTypeSymbol leftArray)
            {
                return right is IArrayTypeSymbol rightArray &&
                    leftArray.Rank == rightArray.Rank &&
                    TypesMatch(leftArray.ElementType, rightArray.ElementType);
            }

            if (left is INamedTypeSymbol leftNamed && leftNamed.IsGenericType)
            {
                if (right is not INamedTypeSymbol rightNamed ||
                    !rightNamed.IsGenericType ||
                    !SymbolEqualityComparer.Default.Equals(leftNamed.OriginalDefinition, rightNamed.OriginalDefinition) ||
                    leftNamed.TypeArguments.Length != rightNamed.TypeArguments.Length)
                {
                    return false;
                }

                for (int i = 0; i < leftNamed.TypeArguments.Length; i++)
                {
                    if (!TypesMatch(leftNamed.TypeArguments[i], rightNamed.TypeArguments[i]))
                    {
                        return false;
                    }
                }

                return true;
            }

            return SymbolEqualityComparer.Default.Equals(left, right);
        }
    }
}
