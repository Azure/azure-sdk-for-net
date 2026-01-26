// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Text;
using Microsoft.CodeAnalysis;
using static Azure.SdkAnalyzers.AnalyzerUtils;

namespace Azure.SdkAnalyzers
{
    public static class INamespaceSymbolExtensions
    {
        public static StringBuilder GetFullNamespaceName(this INamespaceSymbol namespaceSymbol)
        {
            var namespaceName = new StringBuilder();
            while (namespaceSymbol is { IsGlobalNamespace: false })
            {
                if (namespaceName.Length > 0)
                {
                    namespaceName.Insert(0, '.');
                }
                namespaceName.Insert(0, namespaceSymbol.Name);
                namespaceSymbol = namespaceSymbol.ContainingNamespace;
            }
            return namespaceName;
        }

        internal static Namespaces GetAllNamespaces(this INamespaceSymbol namespaceSymbol)
        {
            var namespaces = new Namespaces();
            while (namespaceSymbol is { IsGlobalNamespace: false })
            {
                namespaces.Add(namespaceSymbol.Name);
                namespaceSymbol = namespaceSymbol.ContainingNamespace;
            }
            namespaces.Reverse();
            return namespaces;
        }
    }
}
