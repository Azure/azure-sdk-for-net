// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using BenchmarkDotNet.Attributes;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using System.Linq;

namespace Azure.SdkAnalyzers.Perf
{
    [MemoryDiagnoser]
    public class NamespaceBenchmark
    {
        [Params(0, 1, 2, 3, 4, 5, 6, 7, 8, 9)]
        public int Index;

        private readonly string[] testNamespaces =
        [
            "Azure.Data",
            "Azure.Data.Tables",
            "Azure.Data.Tables.Storage.Internal",
            "Azure.Core",
            "Azure.Core.Extensions",
            "Azure.Storage.Blobs",
            "Azure.Messaging.ServiceBus",
            "Microsoft.Azure.Something",
            "Azure",
            "System.Text"
        ];

        private INamespaceSymbol[] namespaceSymbols;
        private BaseNamespaceDeclarationSyntax[] namespaceSyntaxNodes;
        private SemanticModel[] semanticModels;

        [GlobalSetup]
        public void Setup()
        {
            // Create INamespaceSymbol instances for each test namespace
            namespaceSymbols = new INamespaceSymbol[testNamespaces.Length];
            for (int i = 0; i < testNamespaces.Length; i++)
            {
                var code = $"namespace {testNamespaces[i]} {{ public class Test {{ }} }}";
                var compilation = CreateCompilation(code);
                var tree = compilation.SyntaxTrees.First();
                var model = compilation.GetSemanticModel(tree);
                var classDecl = tree.GetRoot().DescendantNodes().OfType<ClassDeclarationSyntax>().First();
                var symbol = model.GetDeclaredSymbol(classDecl);
                namespaceSymbols[i] = symbol!.ContainingNamespace;
            }

            // Create BaseNamespaceDeclarationSyntax instances with semantic models
            namespaceSyntaxNodes = new BaseNamespaceDeclarationSyntax[testNamespaces.Length];
            semanticModels = new SemanticModel[testNamespaces.Length];
            for (int i = 0; i < testNamespaces.Length; i++)
            {
                var code = $"namespace {testNamespaces[i]} {{ public class Test {{ }} }}";
                var compilation = CreateCompilation(code);
                var tree = compilation.SyntaxTrees.First();
                semanticModels[i] = compilation.GetSemanticModel(tree);
                namespaceSyntaxNodes[i] = tree.GetRoot()
                    .DescendantNodes()
                    .OfType<BaseNamespaceDeclarationSyntax>()
                    .First();
            }
        }

        [Benchmark]
        public bool ISymbolTest()
        {
            return AnalyzerUtils.IsSdkCode(namespaceSymbols[Index]);
        }

        private static CSharpCompilation CreateCompilation(string code)
        {
            var syntaxTree = CSharpSyntaxTree.ParseText(code);
            var references = new[] { MetadataReference.CreateFromFile(typeof(object).Assembly.Location) };
            return CSharpCompilation.Create("TestAssembly", new[] { syntaxTree }, references);
        }
    }
}