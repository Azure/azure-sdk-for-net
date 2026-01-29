// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.CodeAnalysis;
using System;

namespace Azure.SdkAnalyzers
{
    public class AnalyzerUtils
    {
        public static bool IsSdkCode(ISymbol symbol)
        {
            return symbol != null && IsSdkNamespace(symbol.ContainingNamespace);
        }

        private static bool IsSdkNamespace(INamespaceSymbol namespaceSymbol)
        {
            if (namespaceSymbol is null || namespaceSymbol.IsGlobalNamespace)
            {
                return false;
            }

            // Walk up to find the root
            INamespaceSymbol current = namespaceSymbol;
            INamespaceSymbol secondLevel = null;
            INamespaceSymbol topLevel = null;

            while (current != null && !current.IsGlobalNamespace)
            {
                secondLevel = topLevel;
                topLevel = current;
                current = current.ContainingNamespace;
            }

            // Check if top level is "Azure"
            if (topLevel?.Name.Equals("Azure", StringComparison.Ordinal) == false)
            {
                return false;
            }

            // Check if second level is "Core"
            return secondLevel?.Name.Equals("Core", StringComparison.Ordinal) != true;
        }
    }
}
