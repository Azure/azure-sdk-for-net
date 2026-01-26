// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Buffers;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Azure.SdkAnalyzers
{
    internal class AnalyzerUtils
    {
        internal static bool IsNotSdkCode(ISymbol symbol) => !IsSdkCode(symbol);

        internal static bool IsSdkCode(ISymbol symbol)
        {
            using var namespaces = symbol.ContainingNamespace.GetAllNamespaces();
            return IsSdkNamespace(namespaces);
        }

        internal static bool IsNotSdkCode(SyntaxNode node, SemanticModel model) => !IsSdkCode(node, model);

        internal static bool IsSdkCode(SyntaxNode node, SemanticModel model)
        {
            var symbol = model.GetDeclaredSymbol(node);
            if (symbol != null)
            {
                return IsSdkCode(symbol);
            }

            using var namespaces = GetNamespace(node);
            return IsSdkNamespace(namespaces);
        }

        private static bool IsSdkNamespace(Namespaces namespaces) => namespaces.Count >= 2 && namespaces[0] == "Azure" && namespaces[1] != "Core";

        private static Namespaces GetNamespace(SyntaxNode node)
        {
            var namespaces = new Namespaces();

            var parent = node.Parent;

            while (parent != null &&
                    parent is not NamespaceDeclarationSyntax
                    && parent is not FileScopedNamespaceDeclarationSyntax)
            {
                parent = parent.Parent;
            }

            if (parent is BaseNamespaceDeclarationSyntax namespaceParent)
            {
                namespaces.Add(namespaceParent.Name.ToString());

                while (true)
                {
                    if (namespaceParent.Parent is not NamespaceDeclarationSyntax parentNamespace)
                    {
                        break;
                    }

                    namespaces.Add(parentNamespace.Name.ToString());
                    namespaceParent = parentNamespace;
                }
            }

            namespaces.Reverse();

            return namespaces;
        }

        internal class Namespaces : IDisposable
        {
            private int count;
            private readonly string[] namespaces = ArrayPool<string>.Shared.Rent(10);

            public int Count => this.count;

            public void Add(string name)
            {
                this.namespaces[this.count++] = name;
            }

            public string this[int i]
            {
                get => this.namespaces[i];
            }

            public void Reverse()
            {
                Array.Reverse(this.namespaces, 0, this.count);
            }

            public void Dispose()
            {
                ArrayPool<string>.Shared.Return(this.namespaces);
            }
        }
    }
}
