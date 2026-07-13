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
    public class ModelFactoryAnalyzer : DiagnosticAnalyzer
    {
        private const string ClientSuffix = "Client";
        private const string ModelFactorySuffix = "ModelFactory";

        private const string AzureNamespace = "Azure";
        private const string SystemClientModelNamespace = "System.ClientModel";
        private const string SystemNamespace = "System";
        private const string PageableTypeName = "Pageable";
        private const string AsyncPageableTypeName = "AsyncPageable";
        private const string ResponseTypeName = "Response";
        private const string NullableResponseTypeName = "NullableResponse";
        private const string OperationTypeName = "Operation";
        private const string TaskTypeName = "Task";
        private const string ClientResultTypeName = "ClientResult";
        private const string CollectionResultTypeName = "CollectionResult";
        private const string AsyncCollectionResultTypeName = "AsyncCollectionResult";
        private const string PageableOperationTypeName = "PageableOperation";

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } = ImmutableArray.Create(
            Descriptors.AZC0035
        );

        public override void Initialize(AnalysisContext context)
        {
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze | GeneratedCodeAnalysisFlags.ReportDiagnostics);
            context.EnableConcurrentExecution();
            context.RegisterCompilationAction(AnalyzeCompilation);
        }

        private static void AnalyzeCompilation(CompilationAnalysisContext context)
        {
            var outputModels = new HashSet<ITypeSymbol>(SymbolEqualityComparer.Default);
            var modelFactoryMethods = new HashSet<ITypeSymbol>(SymbolEqualityComparer.Default);

            // Find all client classes and extract output models from their methods
            // Only process types defined in the current source tree (not dependencies)
            foreach (var namedType in GetAllTypes(context.Compilation.GlobalNamespace))
            {
                if (!SymbolEqualityComparer.Default.Equals(namedType.ContainingAssembly, context.Compilation.Assembly))
                {
                    continue;
                }

                if (IsClientType(namedType))
                {
                    ExtractOutputModelsFromClientType(namedType, outputModels);
                }
                else if (IsModelFactoryType(namedType))
                {
                    ExtractReturnTypesFromModelFactory(namedType, modelFactoryMethods);
                }
            }

            // Check if all output models have corresponding model factory methods
            foreach (var outputModel in outputModels)
            {
                // Only flag models defined in the current compilation's assembly.
                // External (referenced-assembly) types are owned by another
                // library and aren't part of this assembly's model-factory contract.
                if (!SymbolEqualityComparer.Default.Equals(outputModel.ContainingAssembly, context.Compilation.Assembly))
                {
                    continue;
                }

                if (!modelFactoryMethods.Contains(outputModel))
                {
                    // Find a location to report the diagnostic - use the first location of the type
                    var location = outputModel.Locations.FirstOrDefault();
                    if (location != null)
                    {
                        var diagnostic = Diagnostic.Create(
                            Descriptors.AZC0035,
                            location,
                            outputModel.Name);
                        context.ReportDiagnostic(diagnostic);
                    }
                }
            }
        }

        private static bool IsClientType(INamedTypeSymbol namedType)
        {
            return namedType.TypeKind == TypeKind.Class &&
                   namedType.Name.EndsWith(ClientSuffix) &&
                   namedType.DeclaredAccessibility == Accessibility.Public;
        }

        private static bool IsModelFactoryType(INamedTypeSymbol namedType)
        {
            return namedType.TypeKind == TypeKind.Class &&
                   namedType.Name.EndsWith(ModelFactorySuffix) &&
                   namedType.IsStatic &&
                   namedType.DeclaredAccessibility == Accessibility.Public;
        }

        private static void ExtractOutputModelsFromClientType(INamedTypeSymbol clientType, HashSet<ITypeSymbol> outputModels)
        {
            foreach (var member in clientType.GetMembers())
            {
                if (member is IMethodSymbol method && method.DeclaredAccessibility == Accessibility.Public)
                {
                    // Skip property accessors as they are not client methods
                    if (method.AssociatedSymbol is IPropertySymbol)
                    {
                        continue;
                    }

                    var outputModel = ExtractOutputModelFromReturnType(method.ReturnType);
                    if (outputModel != null)
                    {
                        outputModels.Add(outputModel);
                    }
                }
            }
        }

        private static void ExtractReturnTypesFromModelFactory(INamedTypeSymbol factoryType, HashSet<ITypeSymbol> modelFactoryMethods)
        {
            foreach (var member in factoryType.GetMembers())
            {
                if (member is IMethodSymbol method &&
                    method.DeclaredAccessibility == Accessibility.Public &&
                    method.IsStatic)
                {
                    // Add the return type of the factory method
                    modelFactoryMethods.Add(method.ReturnType);
                }
            }
        }

        private static ITypeSymbol ExtractOutputModelFromReturnType(ITypeSymbol returnType)
        {
            ITypeSymbol unwrappedType = returnType;

            // Unwrap Task<T>
            if (returnType is INamedTypeSymbol namedType &&
                namedType.IsGenericType &&
                namedType.Name == TaskTypeName)
            {
                unwrappedType = namedType.TypeArguments.FirstOrDefault();
                if (unwrappedType == null) return null;
            }

            ITypeSymbol modelType = null;

            // Check for Azure client method return types and extract the model type
            if (IsOrImplements(unwrappedType, ResponseTypeName, AzureNamespace) ||
                IsOrImplements(unwrappedType, NullableResponseTypeName, AzureNamespace) ||
                IsOrImplements(unwrappedType, ClientResultTypeName, SystemClientModelNamespace) ||
                IsOrImplements(unwrappedType, OperationTypeName, AzureNamespace) ||
                IsOrImplements(unwrappedType, PageableTypeName, AzureNamespace) ||
                IsOrImplements(unwrappedType, AsyncPageableTypeName, AzureNamespace) ||
                IsOrImplements(unwrappedType, CollectionResultTypeName, SystemClientModelNamespace) ||
                IsOrImplements(unwrappedType, AsyncCollectionResultTypeName, SystemClientModelNamespace) ||
                IsOrImplements(unwrappedType, PageableOperationTypeName, AzureNamespace))
            {
                if (unwrappedType is INamedTypeSymbol genericType && genericType.IsGenericType)
                {
                    modelType = genericType.TypeArguments.FirstOrDefault();
                }
            }

            // Only return user-defined types, not built-in types
            if (modelType != null && IsUserDefinedModelType(modelType))
            {
                return modelType;
            }

            return null;
        }

        private static bool IsUserDefinedModelType(ITypeSymbol typeSymbol)
        {
            // Filter out System types, unless defined in System.ClientModel
            var containingNamespace = typeSymbol.ContainingNamespace?.ToString() ?? string.Empty;

            if (containingNamespace == SystemNamespace || containingNamespace.StartsWith($"{SystemNamespace}.")
                && containingNamespace != SystemClientModelNamespace
                && (!containingNamespace.StartsWith($"{SystemClientModelNamespace}.")))
            {
                return false;
            }

            // Filter out built-in types
            if (typeSymbol.SpecialType != SpecialType.None)
            {
                return false;
            }

            // Only consider class and struct types, but not enums
            if (typeSymbol.TypeKind != TypeKind.Class && typeSymbol.TypeKind != TypeKind.Struct)
            {
                return false;
            }

            // Filter out client types - they are not models
            if (typeSymbol.Name.EndsWith(ClientSuffix))
            {
                return false;
            }

            // Filter out types that can be easily instantiated (have public constructors with all properties settable)
            if (CanBeConstructedUsingPublicApis(typeSymbol))
            {
                return false;
            }

            return true;
        }

        private static bool CanBeConstructedUsingPublicApis(ITypeSymbol typeSymbol)
        {
            if (!(typeSymbol is INamedTypeSymbol namedType))
            {
                return false;
            }

            // Check if there is at least one public constructor
            var publicConstructors = namedType.Constructors.Where(c => c.DeclaredAccessibility == Accessibility.Public).ToList();
            if (!publicConstructors.Any())
            {
                return false;
            }

            // Get all instance properties
            var properties = namedType.GetMembers()
                .OfType<IPropertySymbol>()
                .Where(p => !p.IsStatic)
                .ToList();

            // If there are no properties, it can be constructed via public constructor
            if (!properties.Any())
            {
                return true;
            }

            // Get properties that don't have public setters - these must be set via constructor
            var propertiesNeedingConstructor = properties
                .Where(p => p.SetMethod?.DeclaredAccessibility != Accessibility.Public)
                .ToList();

            // If all properties have public setters, the type can be constructed
            if (!propertiesNeedingConstructor.Any())
            {
                return true;
            }

            // Check if at least one public constructor can set all properties that need constructor parameters
            foreach (var constructor in publicConstructors)
            {
                bool allPropertiesCanBeSet = true;

                foreach (var property in propertiesNeedingConstructor)
                {
                    // Check if this constructor has a parameter that can set this property
                    bool hasMatchingParameter = constructor.Parameters.Any(p =>
                        string.Equals(p.Name, property.Name, StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(p.Name, property.Name.Substring(0, 1).ToLower() + property.Name.Substring(1), StringComparison.Ordinal));

                    if (!hasMatchingParameter)
                    {
                        allPropertiesCanBeSet = false;
                        break;
                    }
                }

                // If this constructor can set all required properties, the type can be constructed
                if (allPropertiesCanBeSet)
                {
                    return true;
                }
            }

            // No constructor can set all required properties
            return false;
        }

        private static bool IsOrImplements(ITypeSymbol typeSymbol, string typeName, string namespaceName)
        {
            if (typeSymbol.Name == typeName && GetFullNamespaceName(typeSymbol.ContainingNamespace) == namespaceName)
            {
                return true;
            }

            if (typeSymbol.BaseType != null)
            {
                return IsOrImplements(typeSymbol.BaseType, typeName, namespaceName);
            }

            return false;
        }

        private static string GetFullNamespaceName(INamespaceSymbol namespaceSymbol)
        {
            if (namespaceSymbol.IsGlobalNamespace)
            {
                return "";
            }

            var parts = new List<string>();
            var current = namespaceSymbol;
            while (current != null && !current.IsGlobalNamespace)
            {
                parts.Insert(0, current.Name);
                current = current.ContainingNamespace;
            }

            return string.Join(".", parts);
        }

        private static IEnumerable<INamedTypeSymbol> GetAllTypes(INamespaceSymbol namespaceSymbol)
        {
            foreach (var type in namespaceSymbol.GetTypeMembers())
            {
                yield return type;
            }

            foreach (var childNamespace in namespaceSymbol.GetNamespaceMembers())
            {
                foreach (var type in GetAllTypes(childNamespace))
                {
                    yield return type;
                }
            }
        }
    }
}
