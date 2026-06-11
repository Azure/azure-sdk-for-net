// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Azure.SdkAnalyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class ArrowPublicApiAnalyzer : SymbolAnalyzerBase
    {
        private const string ArrowRootNamespace = "Apache.Arrow";
        private const string ArrowNamespacePrefix = "Apache.Arrow.";

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = ImmutableArray.Create(Descriptors.AZC0040);

        public override SymbolKind[] SymbolKinds { get; } =
            [SymbolKind.NamedType, SymbolKind.Method, SymbolKind.Property, SymbolKind.Field, SymbolKind.Event];

        public override void Analyze(SymbolAnalysisContext context)
        {
            var symbol = context.Symbol;

            if (!IsPublicApi(symbol) || !AnalyzerUtils.IsSdkCode(symbol))
            {
                return;
            }

            switch (symbol)
            {
                case INamedTypeSymbol namedType:
                    AnalyzeNamedType(context, namedType);
                    break;
                case IMethodSymbol method:
                    AnalyzeMethod(context, method);
                    break;
                case IPropertySymbol property:
                    AnalyzeProperty(context, property);
                    break;
                case IFieldSymbol field:
                    AnalyzeField(context, field);
                    break;
                case IEventSymbol @event:
                    AnalyzeEvent(context, @event);
                    break;
            }
        }

        private static void AnalyzeNamedType(SymbolAnalysisContext context, INamedTypeSymbol namedType)
        {
            var location = namedType.Locations.FirstOrDefault();

            ReportIfArrow(context, namedType.BaseType, namedType, location);

            foreach (var implemented in namedType.Interfaces)
            {
                ReportIfArrow(context, implemented, namedType, location);
            }

            AnalyzeTypeParameterConstraints(context, namedType.TypeParameters, namedType, location);

            if (namedType.TypeKind == TypeKind.Delegate && namedType.DelegateInvokeMethod is { } invoke)
            {
                ReportIfArrow(context, invoke.ReturnType, namedType, location);
                foreach (var parameter in invoke.Parameters)
                {
                    ReportIfArrow(context, parameter.Type, namedType, location);
                }
            }
        }

        private static void AnalyzeMethod(SymbolAnalysisContext context, IMethodSymbol method)
        {
            // Property and event accessors are reported through their associated symbol.
            if (method.AssociatedSymbol != null)
            {
                return;
            }

            var location = method.Locations.FirstOrDefault();

            ReportIfArrow(context, method.ReturnType, method, location);

            foreach (var parameter in method.Parameters)
            {
                ReportIfArrow(context, parameter.Type, method, parameter.Locations.FirstOrDefault());
            }

            AnalyzeTypeParameterConstraints(context, method.TypeParameters, method, location);
        }

        private static void AnalyzeTypeParameterConstraints(
            SymbolAnalysisContext context,
            ImmutableArray<ITypeParameterSymbol> typeParameters,
            ISymbol member,
            Location location)
        {
            foreach (var typeParameter in typeParameters)
            {
                foreach (var constraint in typeParameter.ConstraintTypes)
                {
                    ReportIfArrow(context, constraint, member, location);
                }
            }
        }

        private static void AnalyzeProperty(SymbolAnalysisContext context, IPropertySymbol property)
        {
            var location = property.Locations.FirstOrDefault();

            ReportIfArrow(context, property.Type, property, location);

            foreach (var parameter in property.Parameters)
            {
                ReportIfArrow(context, parameter.Type, property, parameter.Locations.FirstOrDefault() ?? location);
            }
        }

        private static void AnalyzeField(SymbolAnalysisContext context, IFieldSymbol field)
        {
            ReportIfArrow(context, field.Type, field, field.Locations.FirstOrDefault());
        }

        private static void AnalyzeEvent(SymbolAnalysisContext context, IEventSymbol @event)
        {
            ReportIfArrow(context, @event.Type, @event, @event.Locations.FirstOrDefault());
        }

        private static void ReportIfArrow(SymbolAnalysisContext context, ITypeSymbol exposedType, ISymbol member, Location location)
        {
            if (location == null)
            {
                return;
            }

            var arrowType = FindArrowType(exposedType, new HashSet<ITypeSymbol>(SymbolEqualityComparer.Default));
            if (arrowType != null)
            {
                context.ReportDiagnostic(Diagnostic.Create(
                    Descriptors.AZC0040,
                    location,
                    member.Name,
                    arrowType.ToDisplayString()));
            }
        }

        private static ITypeSymbol FindArrowType(ITypeSymbol type, HashSet<ITypeSymbol> visited)
        {
            if (type == null || !visited.Add(type))
            {
                return null;
            }

            switch (type)
            {
                case IArrayTypeSymbol array:
                    return FindArrowType(array.ElementType, visited);
                case IPointerTypeSymbol pointer:
                    return FindArrowType(pointer.PointedAtType, visited);
                case ITypeParameterSymbol:
                    // Constraints are analyzed at the declaration site (type/method) to report once at a stable location.
                    return null;
                case INamedTypeSymbol named:
                    if (IsArrowType(named))
                    {
                        return named;
                    }

                    foreach (var argument in named.TypeArguments)
                    {
                        var found = FindArrowType(argument, visited);
                        if (found != null)
                        {
                            return found;
                        }
                    }

                    return null;
                default:
                    return IsArrowType(type) ? type : null;
            }
        }

        private static bool IsArrowType(ITypeSymbol type)
        {
            if (type?.ContainingNamespace is not INamespaceSymbol containingNamespace || containingNamespace.IsGlobalNamespace)
            {
                return false;
            }

            var namespaceName = containingNamespace.ToDisplayString();
            return namespaceName == ArrowRootNamespace || namespaceName.StartsWith(ArrowNamespacePrefix, StringComparison.Ordinal);
        }
    }
}
