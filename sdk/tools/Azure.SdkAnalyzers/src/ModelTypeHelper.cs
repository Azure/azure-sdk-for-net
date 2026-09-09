// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using Microsoft.CodeAnalysis;

namespace Azure.SdkAnalyzers
{
    /// <summary>
    /// Shared helper for recognizing SDK model types.
    /// </summary>
    internal static class ModelTypeHelper
    {
        private const string ModelsNamespaceName = "Models";
        private const string Utf8JsonSerializableInterfaceName = "IUtf8JsonSerializable";
        private const string JsonModelInterfaceName = "IJsonModel";
        private const string JsonElementTypeName = "JsonElement";
        private const string DeserializePrefix = "Deserialize";

        /// <summary>
        /// Determines whether a type is a serializable SDK model.
        /// </summary>
        /// <param name="symbol">The type to inspect.</param>
        /// <returns>True when the type is recognized as an SDK model.</returns>
        public static bool IsModelType(ITypeSymbol symbol)
        {
            if (symbol is not { TypeKind: TypeKind.Class })
            {
                return false;
            }

            // Some SDKs have models with no serialization member at all, and the generated
            // Models namespace is the only thing that identifies them.
            if (HasModelsNamespace(symbol))
            {
                return true;
            }

            if (symbol.Interfaces.Any(i => i.Name == Utf8JsonSerializableInterfaceName))
            {
                return true;
            }

            // Modern generated models serialize through System.ClientModel.Primitives.IJsonModel<T>,
            // which a model can also inherit from a base model or a derived interface.
            if (symbol.AllInterfaces.Any(IsJsonModelInterface))
            {
                return true;
            }

            return HasJsonElementDeserializer(symbol);
        }

        private static bool HasJsonElementDeserializer(ITypeSymbol symbol)
        {
            return symbol.GetMembers(DeserializePrefix + symbol.Name).Any(m =>
                m is IMethodSymbol { IsStatic: true } method &&
                method.Parameters.Length == 1 &&
                method.Parameters[0].Type.Name == JsonElementTypeName &&
                SymbolEqualityComparer.Default.Equals(method.ReturnType, symbol));
        }

        private static bool IsJsonModelInterface(INamedTypeSymbol interfaceSymbol)
        {
            return interfaceSymbol.Name == JsonModelInterfaceName &&
                   AnalyzerUtils.IsNamespace(interfaceSymbol.ContainingNamespace, "System", "ClientModel", "Primitives");
        }

        private static bool HasModelsNamespace(ITypeSymbol typeSymbol)
        {
            for (INamespaceSymbol namespaceSymbol = typeSymbol.ContainingNamespace;
                 namespaceSymbol != null;
                 namespaceSymbol = namespaceSymbol.ContainingNamespace)
            {
                if (namespaceSymbol.Name == ModelsNamespaceName)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
