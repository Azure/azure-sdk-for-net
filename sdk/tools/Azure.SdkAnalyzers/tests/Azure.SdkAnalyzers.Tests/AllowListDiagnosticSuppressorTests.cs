// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Text;
using NUnit.Framework;

namespace Azure.SdkAnalyzers.Tests
{
    /// <summary>
    /// In-process Roslyn tests for <see cref="AllowListDiagnosticSuppressor"/>.
    /// </summary>
    public class AllowListDiagnosticSuppressorTests
    {
        [Test]
        public async Task TypeTarget_SuppressesOnlyMatchingType()
        {
            const string source = @"
namespace TestNs
{
    public class Suppressed { }
    public class NotSuppressed { }
}";
            string allowList = @"
nowarn:AZC0034 T:TestNs.Suppressed
";
            IReadOnlyList<Diagnostic> diagnostics = await RunAsync(source, allowList);

            Diagnostic suppressed = SingleFor(diagnostics, "Suppressed");
            Assert.That(suppressed.IsSuppressed, Is.True, "AZC0034 on TestNs.Suppressed should be suppressed.");

            Diagnostic notSuppressed = SingleFor(diagnostics, "NotSuppressed");
            Assert.That(notSuppressed.IsSuppressed, Is.False, "AZC0034 on TestNs.NotSuppressed should NOT be suppressed.");
        }

        [Test]
        public async Task NamespaceTarget_SuppressesEveryTypeInNamespaceAndDescendants()
        {
            const string source = @"
namespace Outer
{
    public class Inside { }
    namespace Nested
    {
        public class AlsoInside { }
    }
}
namespace Sibling
{
    public class Outside { }
}";
            string allowList = @"
nowarn:AZC0034 N:Outer
";
            IReadOnlyList<Diagnostic> diagnostics = await RunAsync(source, allowList);

            Assert.That(SingleFor(diagnostics, "Inside").IsSuppressed, Is.True);
            Assert.That(SingleFor(diagnostics, "AlsoInside").IsSuppressed, Is.True);
            Assert.That(SingleFor(diagnostics, "Outside").IsSuppressed, Is.False);
        }

        [Test]
        public async Task NoAllowList_ReportsAllDiagnosticsUnsuppressed()
        {
            const string source = @"
namespace TestNs
{
    public class A { }
    public class B { }
}";
            IReadOnlyList<Diagnostic> diagnostics = await RunAsync(source, allowListText: null);

            Assert.That(diagnostics.Where(d => d.Id == "AZC0034").All(d => !d.IsSuppressed), Is.True);
        }

        [Test]
        public async Task WholeAssemblyEntry_DoesNotTriggerSuppression()
        {
            // Whole-assembly entries are handled by $(NoWarn) injection, not by this suppressor.
            const string source = @"
namespace TestNs
{
    public class A { }
}";
            string allowList = "nowarn:AZC0034";
            IReadOnlyList<Diagnostic> diagnostics = await RunAsync(source, allowList);

            Assert.That(SingleFor(diagnostics, "A").IsSuppressed, Is.False);
        }

        [Test]
        public async Task UnknownDiagnosticId_NotSuppressed()
        {
            const string source = @"
namespace TestNs
{
    public class A { }
}";
            string allowList = "nowarn:TESTXXXX T:TestNs.A";
            IReadOnlyList<Diagnostic> diagnostics = await RunAsync(source, allowList);

            Assert.That(SingleFor(diagnostics, "A").IsSuppressed, Is.False);
        }

        // WarnAsError does NOT block suppression — Roslyn dispatches to the suppressor
        // based on the descriptor's default severity, not the effective severity after
        // promotion. Descriptor-Error severity, however, bypasses the suppressor entirely.

        [Test]
        public async Task DefaultSeverityWarning_ScopedSuppressionWorks()
        {
            const string source = @"
namespace TestNs
{
    public class A { }
}";
            string allowList = "nowarn:AZC0034 T:TestNs.A";
            IReadOnlyList<Diagnostic> diagnostics = await RunAsync(source, allowList);
            Assert.That(SingleFor(diagnostics, "A").IsSuppressed, Is.True);
        }

        [Test]
        public async Task WarnAsErrorAll_DoesNotBlockSuppression()
        {
            const string source = @"
namespace TestNs
{
    public class A { }
}";
            string allowList = "nowarn:AZC0034 T:TestNs.A";
            IReadOnlyList<Diagnostic> diagnostics = await RunAsync(
                source,
                allowList,
                generalDiagnosticOption: ReportDiagnostic.Error);

            Diagnostic d = SingleFor(diagnostics, "A");
            Assert.That(d.Severity, Is.EqualTo(DiagnosticSeverity.Error));
            Assert.That(d.IsSuppressed, Is.True);
        }

        [Test]
        public async Task PerIdWarnAsError_DoesNotBlockSuppression()
        {
            const string source = @"
namespace TestNs
{
    public class A { }
}";
            string allowList = "nowarn:AZC0034 T:TestNs.A";
            IReadOnlyList<Diagnostic> diagnostics = await RunAsync(
                source,
                allowList,
                specificDiagnosticOptions: new Dictionary<string, ReportDiagnostic>
                {
                    ["AZC0034"] = ReportDiagnostic.Error,
                });

            Diagnostic d = SingleFor(diagnostics, "A");
            Assert.That(d.Severity, Is.EqualTo(DiagnosticSeverity.Error));
            Assert.That(d.IsSuppressed, Is.True);
        }

        [Test]
        public async Task CompilerCS0618_CanBeSuppressed()
        {
            const string source = @"
namespace TestNs
{
    [System.Obsolete(""use the new one"")]
    public class OldType
    {
        public static int Make() => 42;
    }

    public class Consumer
    {
        public int Use() => OldType.Make();
    }
}";
            string allowList = "nowarn:CS0618 T:TestNs.Consumer";
            IReadOnlyList<Diagnostic> diagnostics = await RunAsync(source, allowList);

            Diagnostic cs0618 = diagnostics.Single(d => d.Id == "CS0618");
            Assert.That(cs0618.IsSuppressed, Is.True);
        }

        [Test]
        public async Task CompilerCS0618_WithWarnAsError_CanBeSuppressed()
        {
            const string source = @"
namespace TestNs
{
    [System.Obsolete(""use the new one"")]
    public class OldType
    {
        public static int Make() => 42;
    }

    public class Consumer
    {
        public int Use() => OldType.Make();
    }
}";
            string allowList = "nowarn:CS0618 T:TestNs.Consumer";
            IReadOnlyList<Diagnostic> diagnostics = await RunAsync(
                source,
                allowList,
                generalDiagnosticOption: ReportDiagnostic.Error);

            Diagnostic cs0618 = diagnostics.Single(d => d.Id == "CS0618");
            Assert.That(cs0618.Severity, Is.EqualTo(DiagnosticSeverity.Error));
            Assert.That(cs0618.IsSuppressed, Is.True);
        }

        [Test]
        public async Task DescriptorSeverityError_BlocksSuppression()
        {
            const string source = @"
namespace TestNs
{
    public class A { }
}";
            string allowList = "nowarn:AZC0035 T:TestNs.A";
            IReadOnlyList<Diagnostic> diagnostics = await RunAsync(
                source,
                allowList,
                useErrorSeverityDescriptor: true);

            Diagnostic d = diagnostics.Single(x => x.Id == "AZC0035");
            Assert.That(d.Severity, Is.EqualTo(DiagnosticSeverity.Error));
            Assert.That(d.IsSuppressed, Is.False);
        }

        private static Diagnostic SingleFor(IReadOnlyList<Diagnostic> diagnostics, string typeName)
        {
            return diagnostics.Single(d => d.Id == "AZC0034" && d.GetMessage().Contains("'" + typeName + "'"));
        }

        private static async Task<IReadOnlyList<Diagnostic>> RunAsync(
            string source,
            string? allowListText,
            ReportDiagnostic generalDiagnosticOption = ReportDiagnostic.Default,
            IDictionary<string, ReportDiagnostic>? specificDiagnosticOptions = null,
            bool useErrorSeverityDescriptor = false)
        {
            var refAssemblies = await AzureTestReferences.DefaultReferenceAssemblies.ResolveAsync(
                LanguageNames.CSharp, CancellationToken.None);

            SyntaxTree tree = CSharpSyntaxTree.ParseText(source);
            var compilationOptions = new CSharpCompilationOptions(
                OutputKind.DynamicallyLinkedLibrary,
                generalDiagnosticOption: generalDiagnosticOption,
                specificDiagnosticOptions: specificDiagnosticOptions);
            CSharpCompilation compilation = CSharpCompilation.Create(
                "TestAssembly",
                new[] { tree },
                refAssemblies,
                compilationOptions);

            ImmutableArray<AdditionalText> additional;
            AnalyzerConfigOptionsProvider provider;
            if (allowListText != null)
            {
                additional = ImmutableArray.Create<AdditionalText>(new InMemoryAdditionalText("allowlist.txt", allowListText));
                provider = new AllowListMarkerOptionsProvider("allowlist.txt");
            }
            else
            {
                additional = ImmutableArray<AdditionalText>.Empty;
                provider = new AllowListMarkerOptionsProvider(null);
            }

            var options = new AnalyzerOptions(additional, provider);
            DiagnosticAnalyzer reporter = useErrorSeverityDescriptor
                ? (DiagnosticAnalyzer)new TestErrorSeverityAzc0034Analyzer()
                : new TestTypeAzc0034Analyzer();
            ImmutableArray<DiagnosticAnalyzer> analyzers = ImmutableArray.Create<DiagnosticAnalyzer>(
                reporter,
                new AllowListDiagnosticSuppressor());

            CompilationWithAnalyzersOptions cwaOptions = new(
                options: options,
                onAnalyzerException: null,
                concurrentAnalysis: false,
                logAnalyzerExecutionTime: false,
                reportSuppressedDiagnostics: true);

            CompilationWithAnalyzers withAnalyzers = ((Compilation)compilation).WithAnalyzers(analyzers, cwaOptions);
            ImmutableArray<Diagnostic> raw = await withAnalyzers.GetAllDiagnosticsAsync(CancellationToken.None);
            return raw;
        }

        // ----- Test infrastructure ------------------------------------------------

#pragma warning disable RS1036
#pragma warning disable RS2008
        [DiagnosticAnalyzer(LanguageNames.CSharp)]
        private sealed class TestTypeAzc0034Analyzer : DiagnosticAnalyzer
        {
            private static readonly DiagnosticDescriptor s_descriptor = new(
                id: "AZC0034",
                title: "Test AZC0034",
                messageFormat: "Type '{0}' conflicts with something",
                category: "Test",
                defaultSeverity: DiagnosticSeverity.Warning,
                isEnabledByDefault: true);

            public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics =>
                ImmutableArray.Create(s_descriptor);

            public override void Initialize(AnalysisContext context)
            {
                context.EnableConcurrentExecution();
                context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
                context.RegisterSyntaxNodeAction(AnalyzeType, SyntaxKind.ClassDeclaration);
            }

            private static void AnalyzeType(SyntaxNodeAnalysisContext context)
            {
                var decl = (TypeDeclarationSyntax)context.Node;
                context.ReportDiagnostic(Diagnostic.Create(
                    s_descriptor,
                    decl.Identifier.GetLocation(),
                    decl.Identifier.ValueText));
            }
        }
#pragma warning restore RS2008
#pragma warning restore RS1036

#pragma warning disable RS1036
#pragma warning disable RS2008
        [DiagnosticAnalyzer(LanguageNames.CSharp)]
        private sealed class TestErrorSeverityAzc0034Analyzer : DiagnosticAnalyzer
        {
            private static readonly DiagnosticDescriptor s_descriptor = new(
                id: "AZC0035",
                title: "Test AZC0035 (Error severity)",
                messageFormat: "Type '{0}' conflicts with something (error)",
                category: "Test",
                defaultSeverity: DiagnosticSeverity.Error,
                isEnabledByDefault: true);

            public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics =>
                ImmutableArray.Create(s_descriptor);

            public override void Initialize(AnalysisContext context)
            {
                context.EnableConcurrentExecution();
                context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
                context.RegisterSyntaxNodeAction(AnalyzeType, SyntaxKind.ClassDeclaration);
            }

            private static void AnalyzeType(SyntaxNodeAnalysisContext context)
            {
                var decl = (TypeDeclarationSyntax)context.Node;
                context.ReportDiagnostic(Diagnostic.Create(
                    s_descriptor,
                    decl.Identifier.GetLocation(),
                    decl.Identifier.ValueText));
            }
        }
#pragma warning restore RS2008
#pragma warning restore RS1036

        private sealed class InMemoryAdditionalText : AdditionalText
        {
            private readonly string _text;

            public InMemoryAdditionalText(string path, string text)
            {
                Path = path;
                _text = text;
            }

            public override string Path { get; }

            public override SourceText GetText(CancellationToken cancellationToken = default) =>
                SourceText.From(_text);
        }

        private sealed class AllowListMarkerOptionsProvider : AnalyzerConfigOptionsProvider
        {
            private readonly string? _allowListPath;

            public AllowListMarkerOptionsProvider(string? allowListPath) => _allowListPath = allowListPath;

            public override AnalyzerConfigOptions GlobalOptions { get; } = EmptyOptions.Instance;

            public override AnalyzerConfigOptions GetOptions(SyntaxTree tree) => EmptyOptions.Instance;

            public override AnalyzerConfigOptions GetOptions(AdditionalText textFile) =>
                _allowListPath != null && textFile.Path == _allowListPath
                    ? new MarkerOptions()
                    : EmptyOptions.Instance;

            private sealed class MarkerOptions : AnalyzerConfigOptions
            {
                public override bool TryGetValue(string key, out string value)
                {
                    if (key == "build_metadata.AdditionalFiles.AzureSdkAllowList")
                    {
                        value = "true";
                        return true;
                    }

                    value = null!;
                    return false;
                }
            }

            private sealed class EmptyOptions : AnalyzerConfigOptions
            {
                public static readonly EmptyOptions Instance = new();

                public override bool TryGetValue(string key, out string value)
                {
                    value = null!;
                    return false;
                }
            }
        }
    }
}
