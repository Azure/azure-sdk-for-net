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
    /// End-to-end tests for <see cref="AllowListDiagnosticSuppressor"/>: build a
    /// compilation, attach a fake analyzer that fires <c>AZC0034</c> on every type,
    /// attach the suppressor with an allow-list AdditionalText, and verify that
    /// only the scoped targets are reported as <see cref="Diagnostic.IsSuppressed"/>.
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
            // No matching AdditionalFile at all.
            IReadOnlyList<Diagnostic> diagnostics = await RunAsync(source, allowListText: null);

            Assert.That(diagnostics.Where(d => d.Id == "AZC0034").All(d => !d.IsSuppressed), Is.True);
        }

        [Test]
        public async Task WholeAssemblyEntry_DoesNotTriggerSuppression()
        {
            // The build pipeline handles whole-assembly entries via $(NoWarn); the
            // suppressor should ignore them and leave the diagnostics alone (so the
            // build's NoWarn injection is what masks them, not double-suppression).
            const string source = @"
namespace TestNs
{
    public class A { }
}";
            string allowList = "nowarn:AZC0034";
            IReadOnlyList<Diagnostic> diagnostics = await RunAsync(source, allowList);

            Diagnostic d = SingleFor(diagnostics, "A");
            Assert.That(d.IsSuppressed, Is.False,
                "Whole-assembly nowarn entries are handled by $(NoWarn) injection at build time, " +
                "not by the suppressor.");
        }

        [Test]
        public async Task UnknownDiagnosticId_NotSuppressed()
        {
            // Code in the allow-list isn't in SupportedSuppressions; suppression should be a no-op.
            const string source = @"
namespace TestNs
{
    public class A { }
}";
            string allowList = "nowarn:TESTXXXX T:TestNs.A";
            IReadOnlyList<Diagnostic> diagnostics = await RunAsync(source, allowList);

            Diagnostic d = SingleFor(diagnostics, "A");
            Assert.That(d.IsSuppressed, Is.False);
        }

        // ------------- Severity / warn-as-error scenarios --------------------
        //
        // Findings from these tests (intentionally documented in code):
        //   1. WarnAsError DOES NOT block suppression. The suppressor still
        //      runs, and a Suppression on a promoted-to-Error diagnostic is
        //      honored — the warning never reaches the compiler's error list.
        //   2. The DESCRIPTOR severity is what matters. If the analyzer ships
        //      with DiagnosticSeverity.Error in its DiagnosticDescriptor, then
        //      the suppressor is bypassed entirely.

        /// <summary>
        /// Baseline: the test analyzer reports AZC0034 as Warning (its default).
        /// Suppression works as expected.
        /// </summary>
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

        /// <summary>
        /// Blanket WarnAsError via <see cref="ReportDiagnostic.Error"/>
        /// (the equivalent of repo-wide <c>TreatWarningsAsErrors+</c>).
        /// Suppression STILL works — the diagnostic is reported with
        /// Severity=Error AND IsSuppressed=true, and a suppressed Error is
        /// invisible to the compiler's error count.
        /// </summary>
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
            Assert.That(d.Severity, Is.EqualTo(DiagnosticSeverity.Error),
                "WarnAsError should have promoted the diagnostic.");
            Assert.That(d.IsSuppressed, Is.True,
                "Roslyn invokes suppressors based on the descriptor's default severity, " +
                "not the effective post-WarnAsError severity. A suppressed diagnostic " +
                "still won't fail the build.");
        }

        /// <summary>
        /// Per-id WarnAsError (compiler equivalent of <c>/warnaserror+:AZC0034</c>).
        /// Same result as the blanket case — suppression still works.
        /// </summary>
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

        /// <summary>
        /// Compiler-emitted CS0618 (use of obsolete API). This is fundamentally
        /// different from analyzer-emitted diagnostics — it's reported by the
        /// C# compiler itself, not by any IDiagnosticAnalyzer instance.
        /// Documenting whether DiagnosticSuppressor can suppress it informs the
        /// fix path for Azure.ResourceManager.Batch / Azure.ResourceManager.ContainerRegistry.
        /// </summary>
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

            // The compiler emits CS0618 at the OldType.Make() call site inside Consumer.
            Diagnostic cs0618 = diagnostics.Single(d => d.Id == "CS0618");
            Assert.That(cs0618.IsSuppressed, Is.True,
                "Compiler-emitted CS0618 should be suppressible via DiagnosticSuppressor when scoped to the consuming type.");
        }

        /// <summary>
        /// Same as above but with blanket WarnAsError. If both this test and
        /// <see cref="WarnAsErrorAll_DoesNotBlockSuppression"/> pass, then csc-side
        /// failures must be due to discovery / wiring, not severity at all.
        /// </summary>
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
            Assert.That(cs0618.IsSuppressed, Is.True,
                "Compiler-emitted CS0618 should be suppressible even after WarnAsError promotion.");
        }

        /// <summary>
        /// The actual blocker: when the analyzer's <see cref="DiagnosticDescriptor"/>
        /// declares <c>DiagnosticSeverity.Error</c> (rather than Warning), Roslyn
        /// skips the suppressor entirely — there's no way to suppress it via
        /// <see cref="DiagnosticSuppressor"/>. This matches the production
        /// AZC0034 descriptor in Azure.ClientSdk.Analyzers (azure-sdk-tools).
        /// </summary>
        [Test]
        public async Task DescriptorSeverityError_BlocksSuppression()
        {
            const string source = @"
namespace TestNs
{
    public class A { }
}";
            // AZC0035 is in AllowListDiagnosticSuppressor.SupportedDiagnosticIds too —
            // here we hook it up to a Error-severity descriptor in our test analyzer
            // to isolate whether descriptor severity is what blocks suppression.
            string allowList = "nowarn:AZC0035 T:TestNs.A";
            IReadOnlyList<Diagnostic> diagnostics = await RunAsync(
                source,
                allowList,
                useErrorSeverityDescriptor: true);

            Diagnostic d = diagnostics.Single(x => x.Id == "AZC0035");
            Assert.That(d.Severity, Is.EqualTo(DiagnosticSeverity.Error));
            Assert.That(d.IsSuppressed, Is.False,
                "Diagnostics whose descriptor declares Error severity cannot be " +
                "suppressed via DiagnosticSuppressor.");
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

        /// <summary>
        /// Fires AZC0034 (one of the suppressor's SupportedDiagnosticIds) on every
        /// named type. The message embeds the type name so tests can locate
        /// individual diagnostics. The exact text of AZC0034 doesn't matter here —
        /// we just need the same ID so the suppressor recognizes it.
        /// </summary>
#pragma warning disable RS1036 // EnforceExtendedAnalyzerRules not relevant for a test-only synthetic analyzer
#pragma warning disable RS2008 // Release-tracking not relevant for a test-only synthetic analyzer
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
        /// <summary>
        /// Same as <see cref="TestTypeAzc0034Analyzer"/> but the descriptor declares
        /// <see cref="DiagnosticSeverity.Error"/>. Used to pin down whether
        /// descriptor-level Error severity blocks suppression.
        /// </summary>
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

        /// <summary>
        /// In-memory <see cref="AdditionalText"/> for the allow-list content.
        /// </summary>
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

        /// <summary>
        /// Options provider that surfaces <c>build_metadata.AdditionalFiles.AzureSdkAllowList=true</c>
        /// for the one path that matches; the suppressor uses that metadata to identify
        /// its input file among all AdditionalFiles.
        /// </summary>
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
