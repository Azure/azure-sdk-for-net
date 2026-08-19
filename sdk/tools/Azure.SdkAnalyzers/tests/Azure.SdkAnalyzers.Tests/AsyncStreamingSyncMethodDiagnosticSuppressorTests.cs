// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Testing;
using NUnit.Framework;

namespace Azure.SdkAnalyzers.Tests
{
    public class AsyncStreamingSyncMethodDiagnosticSuppressorTests
    {
        [Test]
        public void SupportedSuppressions_TargetsAzc0004()
        {
            var suppressor = new AsyncStreamingSyncMethodDiagnosticSuppressor();

            Assert.That(
                suppressor.SupportedSuppressions.Single().SuppressedDiagnosticId,
                Is.EqualTo("AZC0004"));
        }

        [Test]
        public async Task SuppressesAsyncStreamingMethod()
        {
            const string source = @"
using System.Threading.Tasks;

namespace System.ClientModel
{
    public abstract class AsyncStreamingClientResult<T> { }
}

public class SomeClient
{
    public virtual Task<System.ClientModel.AsyncStreamingClientResult<string>> StreamAsync() => null;
}";

            Diagnostic diagnostic = await GetAzc0004DiagnosticAsync(source);

            Assert.That(diagnostic.IsSuppressed, Is.True);
        }

        [Test]
        public async Task SuppressesDerivedAsyncStreamingMethod()
        {
            const string source = @"
using System.Threading.Tasks;

namespace System.ClientModel
{
    public abstract class AsyncStreamingClientResult<T> { }
}

public class CustomStreamingResult<T> : System.ClientModel.AsyncStreamingClientResult<T> { }

public class SomeClient
{
    public virtual Task<CustomStreamingResult<string>> StreamAsync() => null;
}";

            Diagnostic diagnostic = await GetAzc0004DiagnosticAsync(source);

            Assert.That(diagnostic.IsSuppressed, Is.True);
        }

        [Test]
        public async Task DoesNotSuppressOrdinaryAsyncMethod()
        {
            const string source = @"
using System.Threading.Tasks;

public class SomeClient
{
    public virtual Task<string> GetAsync() => null;
}";

            Diagnostic diagnostic = await GetAzc0004DiagnosticAsync(source);

            Assert.That(diagnostic.IsSuppressed, Is.False);
        }

        [Test]
        public async Task DoesNotSuppressSameNamedTypeFromAnotherNamespace()
        {
            const string source = @"
using System.Threading.Tasks;

namespace OtherNamespace
{
    public abstract class AsyncStreamingClientResult<T> { }
}

public class SomeClient
{
    public virtual Task<OtherNamespace.AsyncStreamingClientResult<string>> StreamAsync() => null;
}";

            Diagnostic diagnostic = await GetAzc0004DiagnosticAsync(source);

            Assert.That(diagnostic.IsSuppressed, Is.False);
        }

        private static async Task<Diagnostic> GetAzc0004DiagnosticAsync(string source)
        {
            var refAssemblies = await AzureTestReferences.DefaultReferenceAssemblies.ResolveAsync(
                LanguageNames.CSharp,
                CancellationToken.None);

            SyntaxTree tree = CSharpSyntaxTree.ParseText(source);
            CSharpCompilation compilation = CSharpCompilation.Create(
                "TestAssembly",
                new[] { tree },
                refAssemblies,
                new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

            ImmutableArray<DiagnosticAnalyzer> analyzers = ImmutableArray.Create<DiagnosticAnalyzer>(
                new TestAzc0004Analyzer(),
                new AsyncStreamingSyncMethodDiagnosticSuppressor());
            var options = new CompilationWithAnalyzersOptions(
                new AnalyzerOptions(ImmutableArray<AdditionalText>.Empty),
                onAnalyzerException: null,
                concurrentAnalysis: false,
                logAnalyzerExecutionTime: false,
                reportSuppressedDiagnostics: true);

            ImmutableArray<Diagnostic> diagnostics = await compilation
                .WithAnalyzers(analyzers, options)
                .GetAllDiagnosticsAsync(CancellationToken.None);

            return diagnostics.Single(diagnostic => diagnostic.Id == "AZC0004");
        }

#pragma warning disable RS1036
#pragma warning disable RS2008
        [DiagnosticAnalyzer(LanguageNames.CSharp)]
        private sealed class TestAzc0004Analyzer : DiagnosticAnalyzer
        {
            private static readonly DiagnosticDescriptor s_descriptor = new(
                id: "AZC0004",
                title: "Test AZC0004",
                messageFormat: "Provide a synchronous variant",
                category: "Test",
                defaultSeverity: DiagnosticSeverity.Warning,
                isEnabledByDefault: true);

            public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics =>
                ImmutableArray.Create(s_descriptor);

            public override void Initialize(AnalysisContext context)
            {
                context.EnableConcurrentExecution();
                context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
                context.RegisterSyntaxNodeAction(AnalyzeMethod, SyntaxKind.MethodDeclaration);
            }

            private static void AnalyzeMethod(SyntaxNodeAnalysisContext context)
            {
                var declaration = (MethodDeclarationSyntax)context.Node;
                if (declaration.Identifier.ValueText.EndsWith("Async"))
                {
                    context.ReportDiagnostic(Diagnostic.Create(
                        s_descriptor,
                        declaration.Identifier.GetLocation()));
                }
            }
        }
#pragma warning restore RS2008
#pragma warning restore RS1036
    }
}
