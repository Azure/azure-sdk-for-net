// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using NUnit.Framework;

namespace Azure.SdkAnalyzers.Tests
{
    [TestFixture]
    public class AnalyzerUtilsTests
    {
        [Test]
        public void IsSdkCode_AzureCoreNamespace_ReturnsFalse()
        {
            var compilation = CreateCompilation("namespace Azure.Core { public class Test { } }");
            var symbol = GetTypeSymbol(compilation);

            var result = AnalyzerUtils.IsSdkCode(symbol);

            Assert.That(result, Is.False);
        }

        [Test]
        public void IsSdkCode_AzureCoreSubNamespace_ReturnsFalse()
        {
            var compilation = CreateCompilation("namespace Azure.Core.Extensions { public class Test { } }");
            var symbol = GetTypeSymbol(compilation);

            var result = AnalyzerUtils.IsSdkCode(symbol);

            Assert.That(result, Is.False);
        }

        [Test]
        public void IsSdkCode_AzureCoreDeepSubNamespace_ReturnsFalse()
        {
            var compilation = CreateCompilation("namespace Azure.Core.Extensions.Hosting { public class Test { } }");
            var symbol = GetTypeSymbol(compilation);

            var result = AnalyzerUtils.IsSdkCode(symbol);

            Assert.That(result, Is.False);
        }

        [Test]
        public void IsSdkCode_AzureDataNamespace_ReturnsTrue()
        {
            var compilation = CreateCompilation("namespace Azure.Data.Tables { public class Test { } }");
            var symbol = GetTypeSymbol(compilation);

            var result = AnalyzerUtils.IsSdkCode(symbol);

            Assert.That(result, Is.True);
        }

        [Test]
        public void IsSdkCode_AzureStorageNamespace_ReturnsTrue()
        {
            var compilation = CreateCompilation("namespace Azure.Storage.Blobs { public class Test { } }");
            var symbol = GetTypeSymbol(compilation);

            var result = AnalyzerUtils.IsSdkCode(symbol);

            Assert.That(result, Is.True);
        }

        [Test]
        public void IsSdkCode_AzureMessagingNamespace_ReturnsTrue()
        {
            var compilation = CreateCompilation("namespace Azure.Messaging.ServiceBus { public class Test { } }");
            var symbol = GetTypeSymbol(compilation);

            var result = AnalyzerUtils.IsSdkCode(symbol);

            Assert.That(result, Is.True);
        }

        [Test]
        public void IsSdkCode_AzureOnlyNamespace_ReturnsTrue()
        {
            // Azure alone (no second level) should still be considered SDK code
            var compilation = CreateCompilation("namespace Azure { public class Test { } }");
            var symbol = GetTypeSymbol(compilation);

            var result = AnalyzerUtils.IsSdkCode(symbol);

            Assert.That(result, Is.True);
        }

        [Test]
        public void IsSdkCode_GlobalNamespace_ReturnsFalse()
        {
            var compilation = CreateCompilation("public class Test { }");
            var symbol = GetTypeSymbol(compilation);

            var result = AnalyzerUtils.IsSdkCode(symbol);

            Assert.That(result, Is.False);
        }

        [Test]
        public void IsSdkCode_NonAzureNamespace_ReturnsFalse()
        {
            var compilation = CreateCompilation("namespace Microsoft.Azure.Something { public class Test { } }");
            var symbol = GetTypeSymbol(compilation);

            var result = AnalyzerUtils.IsSdkCode(symbol);

            Assert.That(result, Is.False);
        }

        [Test]
        public void IsSdkCode_SystemNamespace_ReturnsFalse()
        {
            var compilation = CreateCompilation("namespace System.Text { public class Test { } }");
            var symbol = GetTypeSymbol(compilation);

            var result = AnalyzerUtils.IsSdkCode(symbol);

            Assert.That(result, Is.False);
        }

        [Test]
        public void IsSdkCode_AzureCorelikeName_ReturnsTrue()
        {
            // Namespace like "Azure.CoreServices" has "Core" prefix but not exact match
            var compilation = CreateCompilation("namespace Azure.CoreServices.Something { public class Test { } }");
            var symbol = GetTypeSymbol(compilation);

            var result = AnalyzerUtils.IsSdkCode(symbol);

            Assert.That(result, Is.True);
        }

        [Test]
        public void IsSdkCode_DeepAzureNamespace_WithCoreInMiddle_ReturnsFalse()
        {
            // Azure.Data.Core.Tables - "Core" is third level, not second
            var compilation = CreateCompilation("namespace Azure.Data.Core.Tables { public class Test { } }");
            var symbol = GetTypeSymbol(compilation);

            var result = AnalyzerUtils.IsSdkCode(symbol);

            Assert.That(result, Is.True);
        }

        [Test]
        public void IsSdkCode_NullSymbol_ReturnsFalse()
        {
            var result = AnalyzerUtils.IsSdkCode((ISymbol)null!);

            Assert.That(result, Is.False);
        }

        [Test]
        public void IsSdkCode_AzureTwoLevel_ReturnsTrue()
        {
            // Azure with any second level (except Core) should return true
            var compilation = CreateCompilation("namespace Azure.Security { public class Test { } }");
            var symbol = GetTypeSymbol(compilation);

            var result = AnalyzerUtils.IsSdkCode(symbol);

            Assert.That(result, Is.True);
        }

        [Test]
        public void IsSdkCode_AzureSingleWord_ReturnsTrue()
        {
            // Azure.Data (exactly two levels)
            var compilation = CreateCompilation("namespace Azure.Data { public class Test { } }");
            var symbol = GetTypeSymbol(compilation);

            var result = AnalyzerUtils.IsSdkCode(symbol);

            Assert.That(result, Is.True);
        }

        [Test]
        public void IsSdkCode_CasesSensitive_CoreWithDifferentCasing_ReturnsTrue()
        {
            // Azure.core (lowercase) should not be excluded
            var compilation = CreateCompilation("namespace Azure.core { public class Test { } }");
            var symbol = GetTypeSymbol(compilation);

            var result = AnalyzerUtils.IsSdkCode(symbol);

            Assert.That(result, Is.True);
        }

        [Test]
        public void IsSdkCode_FooAzureCore_ReturnsFalse()
        {
            // Foo.Azure.Core - top level is "Foo", not "Azure"
            var compilation = CreateCompilation("namespace Foo.Azure.Core { public class Test { } }");
            var symbol = GetTypeSymbol(compilation);

            var result = AnalyzerUtils.IsSdkCode(symbol);

            Assert.That(result, Is.False);
        }

        private static CSharpCompilation CreateCompilation(string code)
        {
            var syntaxTree = CSharpSyntaxTree.ParseText(code);
            var references = new[] { MetadataReference.CreateFromFile(typeof(object).Assembly.Location) };
            return CSharpCompilation.Create("TestAssembly", new[] { syntaxTree }, references);
        }

        private static ISymbol GetTypeSymbol(CSharpCompilation compilation)
        {
            var tree = compilation.SyntaxTrees.First();
            var model = compilation.GetSemanticModel(tree);
            var classDecl = tree.GetRoot().DescendantNodes().OfType<ClassDeclarationSyntax>().First();
            return model.GetDeclaredSymbol(classDecl)!;
        }
    }
}