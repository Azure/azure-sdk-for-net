// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Text;
using NUnit.Framework;
using Verifier = Azure.SdkAnalyzers.Tests.AzureAnalyzerVerifier<Azure.SdkAnalyzers.CodeAnalysisSuppressionAnalyzer>;

namespace Azure.SdkAnalyzers.Tests
{
    public class AZC0041Tests
    {
        [TestCase("AZC0007")]
        [TestCase("CA1822")]
        [TestCase("CS0618")]
        [TestCase("SYSLIB0011")]
        [TestCase("FUTURE0001")]
        public async Task ReportsAnyWarningPragma(string diagnosticId)
        {
            string code = $@"
#pragma warning disable {{|AZC0041:{diagnosticId}|}}
namespace Azure.Test {{ public class TestClient {{ }} }}
";

            await VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task ReportsTrimOrAotPragmaWithActionableMessage()
        {
            string code = @"
#pragma warning disable IL2026
namespace Azure.Test { public class TestClient { } }
";

            await VerifyUnsuppressedAnalyzerAsync(
                code,
                UnsuppressedResult(
                    2,
                    25,
                    2,
                    31,
                    "IL2026",
                    CodeAnalysisSuppressionAnalyzer.TrimOrAotSuppressionMessage));
        }

        [Test]
        public async Task ReportsNumericCompilerWarningPragma()
        {
            string code = @"
#pragma warning disable {|AZC0041:0618|}
namespace Azure.Test { public class TestClient { } }
";

            await VerifyAnalyzerAsync(code);
        }

        [TestCase("AZC\\u0030007")]
        public async Task ReportsEscapedWarningPragma(string diagnosticId)
        {
            string code = $@"
#pragma warning disable {{|AZC0041:{diagnosticId}|}}
namespace Azure.Test {{ public class TestClient {{ }} }}
";

            await VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task ReportsEachIdInMixedPragma()
        {
            string code = @"
#pragma warning disable {|AZC0041:AZC0007|}, {|AZC0041:CA1822|}, {|AZC0041:CS0618|}
namespace Azure.Test { public class TestClient { } }
";

            await VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task ReportsSelfSuppressionBeforeAnotherSuppression()
        {
            string code = @"
#pragma warning disable AZC0041
#pragma warning disable AZC0007
namespace Azure.Test { public class TestClient { } }
";

            await VerifyUnsuppressedAnalyzerAsync(
                code,
                UnsuppressedResult(2, 25, 2, 32, "AZC0041"),
                UnsuppressedResult(3, 25, 3, 32, "AZC0007"));
        }

        [Test]
        public async Task ReportsBarePragmaWithActionableMessage()
        {
            string code = @"
#pragma warning disable
namespace Azure.Test { public class TestClient { } }
";

            var test = Verifier.CreateAnalyzer(code);
            EnableSuppressionValidation(test);
            test.CompilerDiagnostics = CompilerDiagnostics.All;
            SuppressDocumentationWarnings(test);
            test.TestBehaviors |= TestBehaviors.SkipSuppressionCheck;
            test.ExpectedDiagnostics.Add(
                new DiagnosticResult(nameof(Descriptors.AZC0041), DiagnosticSeverity.Warning)
                    .WithSpan(2, 1, 2, 24)
                    .WithMessage(CodeAnalysisSuppressionAnalyzer.BarePragmaMessage));
            await test.RunAsync();
        }

        [Test]
        public async Task DoesNotReportRestorePragma()
        {
            string code = @"
#pragma warning restore AZC0007
namespace Azure.Test { public class TestClient { } }
";

            await VerifyAnalyzerAsync(code);
        }

        [TestCase("SuppressMessage", "AZC0015")]
        [TestCase("SuppressMessageAttribute", "AZC0015")]
        public async Task ReportsSuppressionAttribute(string attributeName, string diagnosticId)
        {
            string code = $@"
using System.Diagnostics.CodeAnalysis;
namespace Azure.Test
{{
    [{attributeName}(""Usage"", {{|AZC0041:""{diagnosticId}:Unexpected return type""|}}, Justification = ""Required"")]
    public class TestClient {{ }}
}}
";

            await VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task ReportsTrimOrAotSuppressionAttributeWithActionableMessage()
        {
            string code = @"
using System.Diagnostics.CodeAnalysis;
namespace Azure.Test
{
    [SuppressMessage(""Trimming"", ""IL2026"")]
    public class TestClient { }
}
";

            await VerifyUnsuppressedAnalyzerAsync(
                code,
                UnsuppressedResult(
                    5,
                    34,
                    5,
                    42,
                    "IL2026",
                    CodeAnalysisSuppressionAnalyzer.TrimOrAotSuppressionMessage));
        }

        [TestCase("SuppressMessage")]
        [TestCase("SuppressMessageAttribute")]
        public async Task ReportsSelfSuppressionAttribute(string attributeName)
        {
            string code = $@"
using System.Diagnostics.CodeAnalysis;
namespace Azure.Test
{{
    [{attributeName}(""Usage"", ""AZC0041:Self suppression"", Justification = ""Required"")]
    public class TestClient {{ }}
}}
";

            int startColumn = attributeName == "SuppressMessage" ? 31 : 40;
            await VerifyUnsuppressedAnalyzerAsync(
                code,
                UnsuppressedResult(5, startColumn, 5, startColumn + 26, "AZC0041"));
        }

        [Test]
        public async Task ReportsAssemblyWideSelfSuppressionAttribute()
        {
            string code = @"
using System.Diagnostics.CodeAnalysis;
[assembly: SuppressMessage(""Usage"", ""AZC0041"")]
namespace Azure.Test { public class TestClient { } }
";

            await VerifyUnsuppressedAnalyzerAsync(
                code,
                UnsuppressedResult(3, 37, 3, 46, "AZC0041"));
        }

        [TestCase("checkId: {|AZC0041:\"AZC0015\"|}, category: \"Usage\"")]
        [TestCase("\"Usage\", checkId: {|AZC0041:\"AZC0015\"|}")]
        [TestCase("category: \"Usage\", {|AZC0041:\"AZC0015\"|}")]
        public async Task ReportsNamedCheckIdSuppressionAttribute(string arguments)
        {
            string code = $@"
using System.Diagnostics.CodeAnalysis;
namespace Azure.Test
{{
    [SuppressMessage({arguments})]
    public class TestClient {{ }}
}}
";

            await VerifyAnalyzerAsync(code);
        }

        [TestCase("AZC0015")]
        [TestCase("AZC0041")]
        public async Task ReportsGovernedUnconditionalSuppressionAttribute(string diagnosticId)
        {
            string code = $@"
#pragma warning disable CS0436
using System.Diagnostics.CodeAnalysis;

namespace System.Diagnostics.CodeAnalysis
{{
    [System.AttributeUsage(System.AttributeTargets.All, AllowMultiple = true)]
    public sealed class UnconditionalSuppressMessageAttribute : System.Attribute
    {{
        public UnconditionalSuppressMessageAttribute(string category, string checkId) {{ }}
    }}
}}

namespace Azure.Test
{{
    [UnconditionalSuppressMessage(""Usage"", ""{diagnosticId}"")]
    public class TestClient {{ }}
}}
";

            await VerifyUnsuppressedAnalyzerAsync(
                code,
                UnsuppressedResult(2, 25, 2, 31, "CS0436"),
                UnsuppressedResult(16, 44, 16, 46 + diagnosticId.Length, diagnosticId));
        }

        [TestCase("Trimming", "IL2026")]
        [TestCase("ReflectionAnalysis", "IL2026:RequiresUnreferencedCode")]
        [TestCase("AOT", "IL3050")]
        public async Task DoesNotReportTrimOrAotUnconditionalSuppressionAttribute(
            string category,
            string diagnosticId)
        {
            string code = $@"
using System.Diagnostics.CodeAnalysis;

namespace System.Diagnostics.CodeAnalysis
{{
    [System.AttributeUsage(System.AttributeTargets.All, AllowMultiple = true)]
    public sealed class UnconditionalSuppressMessageAttribute : System.Attribute
    {{
        public UnconditionalSuppressMessageAttribute(string category, string checkId) {{ }}
    }}
}}

namespace Azure.Test
{{
    [UnconditionalSuppressMessage(""{category}"", ""{diagnosticId}"")]
    public class TestClient {{ }}
}}
";

            await VerifyAnalyzerAsync(code, "CS0436");
        }

        [Test]
        public async Task ReportsAssemblyGlobalSuppression()
        {
            string code = @"
using System.Diagnostics.CodeAnalysis;
[assembly: SuppressMessage(""Usage"", {|AZC0041:""AZC0034""|}, Scope = ""type"", Target = ""~T:Azure.Test.TestClient"")]
namespace Azure.Test { public class TestClient { } }
";

            await VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task ReportsAnySuppressionAttribute()
        {
            string code = @"
using System.Diagnostics.CodeAnalysis;
namespace Azure.Test
{
    [SuppressMessage(""Usage"", {|AZC0041:""FUTURE0001""|}, Justification = ""Required"")]
    public class TestClient { }
}
";

            await VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task DoesNotReportGeneratedCode()
        {
            string code = @"
// <auto-generated/>
#pragma warning disable AZC0007
using System.Diagnostics.CodeAnalysis;
[assembly: SuppressMessage(""Usage"", ""AZC0015"")]
namespace Azure.Test { public class TestClient { } }
";

            await VerifyAnalyzerAsync(code);
        }

        [Test]
        public void SkipsProjectInMigrationBacklog()
        {
            bool result = ShouldSkipProject(
                "Azure.Test",
                ("backlog.txt", "\n# Migration backlog\n\n  Azure.Test  \n", true));

            Assert.That(result, Is.True);
        }

        [Test]
        public void DoesNotSkipProjectNotInMigrationBacklog()
        {
            bool result = ShouldSkipProject(
                "Azure.Test",
                ("backlog.txt", "Azure.Test.Other", true));

            Assert.That(result, Is.False);
        }

        [Test]
        public void DoesNotSkipShippingProjectWhenMigrationBacklogIsAbsent()
        {
            bool result = ShouldSkipProject("Azure.Test");

            Assert.That(result, Is.False);
        }

        [Test]
        public void SkipsNonShippingProject()
        {
            bool result = ShouldSkipProject("Azure.Test", false);

            Assert.That(result, Is.True);
        }

        [Test]
        public void SkipsProjectWhenShippingScopeIsAbsent()
        {
            bool result = ShouldSkipProject("Azure.Test", isShippingClientLibrary: null);

            Assert.That(result, Is.True);
        }

        [Test]
        public void DoesNotSkipShippingProjectForUnmarkedFileWithBacklogName()
        {
            bool result = ShouldSkipProject(
                "Azure.Test",
                ("CodeAnalysisSuppressionSkipValidation.txt", "Azure.Test", false));

            Assert.That(result, Is.False);
        }

        [Test]
        public void DoesNotSkipWhenMultipleBacklogFilesAreMarked()
        {
            bool result = ShouldSkipProject(
                "Azure.Test",
                ("first.txt", "Azure.Test", true),
                ("second.txt", "Azure.Test", true));

            Assert.That(result, Is.False);
        }

        private static bool ShouldSkipProject(
            string projectName,
            params (string Path, string Text, bool Marked)[] files)
        {
            return ShouldSkipProject(projectName, true, files);
        }

        private static bool ShouldSkipProject(
            string projectName,
            bool? isShippingClientLibrary,
            params (string Path, string Text, bool Marked)[] files)
        {
            var additionalFiles = ImmutableArray.CreateBuilder<AdditionalText>();
            var markedPaths = new HashSet<string>();
            foreach ((string path, string text, bool marked) in files)
            {
                additionalFiles.Add(new InMemoryAdditionalText(path, text));
                if (marked)
                {
                    markedPaths.Add(path);
                }
            }

            var options = new AnalyzerOptions(
                additionalFiles.ToImmutable(),
                new TestOptionsProvider(projectName, isShippingClientLibrary, markedPaths));
            return CodeAnalysisSuppressionAnalyzer.ShouldSkipProject(options, CancellationToken.None);
        }

        private static Task VerifyAnalyzerAsync(string code, params string[] suppressedCompilerWarnings)
        {
            var test = Verifier.CreateAnalyzer(code);
            EnableSuppressionValidation(test);
            // AZC0041 carries Roslyn's Compiler tag so SuppressMessage cannot disable enforcement.
            // Include compiler-tagged diagnostics in analyzer-test verification.
            test.CompilerDiagnostics = CompilerDiagnostics.All;
            SuppressDocumentationWarnings(test);
            foreach (string diagnosticId in suppressedCompilerWarnings)
            {
                SuppressCompilerWarning(test, diagnosticId);
            }

            // AZC0041 intentionally reports the pragma inserted by the test framework's generic
            // suppression check, because NotConfigurable diagnostics cannot be pragma-disabled.
            test.TestBehaviors |= TestBehaviors.SkipSuppressionCheck;
            return test.RunAsync();
        }

        private static Task VerifyUnsuppressedAnalyzerAsync(string code, params DiagnosticResult[] expected)
        {
            var test = Verifier.CreateAnalyzer(code);
            EnableSuppressionValidation(test);
            test.CompilerDiagnostics = CompilerDiagnostics.All;
            SuppressDocumentationWarnings(test);
            test.TestBehaviors |= TestBehaviors.SkipSuppressionCheck;
            test.ExpectedDiagnostics.AddRange(expected);
            return test.RunAsync();
        }

        private static void EnableSuppressionValidation(
            Microsoft.CodeAnalysis.CSharp.Testing.CSharpAnalyzerTest<CodeAnalysisSuppressionAnalyzer, DefaultVerifier> test)
        {
            // Shipping scope activates AZC0041; the marked file supplies only backlog entries.
            test.TestState.AdditionalFiles.Add((
                "CodeAnalysisSuppressionSkipValidation.txt",
                ""));
            test.TestState.AnalyzerConfigFiles.Add((
                "/.globalconfig",
                "is_global = true\n" +
                "build_property.IsShippingClientLibrary = true\n" +
                "build_property.MSBuildProjectName = Azure.Test\n" +
                "build_metadata.AdditionalFiles.AzureSdkCodeAnalysisSuppressionSkipValidation = true"));
        }

        private static DiagnosticResult UnsuppressedResult(
            int startLine,
            int startColumn,
            int endLine,
            int endColumn,
            string diagnosticId,
            string? message = null) =>
            new DiagnosticResult(nameof(Descriptors.AZC0041), DiagnosticSeverity.Warning)
                .WithSpan(startLine, startColumn, endLine, endColumn)
                .WithMessage(message ??
                    $"Suppression for diagnostic '{diagnosticId}' must be declared in eng/analyzerallowlist")
                .WithIsSuppressed(false);

        private static void SuppressDocumentationWarnings(
            Microsoft.CodeAnalysis.CSharp.Testing.CSharpAnalyzerTest<CodeAnalysisSuppressionAnalyzer, DefaultVerifier> test)
        {
            // Compiler-tagged AZC0041 requires CompilerDiagnostics.All in this test framework.
            // Centrally suppress unrelated CS1591 noise so expected results remain AZC0041-focused.
            SuppressCompilerWarning(test, "CS1591");
        }

        private static void SuppressCompilerWarning(
            Microsoft.CodeAnalysis.CSharp.Testing.CSharpAnalyzerTest<CodeAnalysisSuppressionAnalyzer, DefaultVerifier> test,
            string diagnosticId)
        {
            test.SolutionTransforms.Add((solution, projectId) =>
            {
                CompilationOptions options = solution.GetProject(projectId)!.CompilationOptions!;
                return solution.WithProjectCompilationOptions(
                    projectId,
                    options.WithSpecificDiagnosticOptions(
                        options.SpecificDiagnosticOptions.SetItem(diagnosticId, ReportDiagnostic.Suppress)));
            });
        }

        private sealed class InMemoryAdditionalText : AdditionalText
        {
            private readonly SourceText _text;

            public InMemoryAdditionalText(string path, string text)
            {
                Path = path;
                _text = SourceText.From(text);
            }

            public override string Path { get; }

            public override SourceText GetText(CancellationToken cancellationToken = default) => _text;
        }

        private sealed class TestOptionsProvider : AnalyzerConfigOptionsProvider
        {
            private readonly HashSet<string> _markedPaths;

            // Simulate the project properties and AdditionalFile metadata emitted by MSBuild.
            public TestOptionsProvider(
                string projectName,
                bool? isShippingClientLibrary,
                HashSet<string> markedPaths)
            {
                _markedPaths = markedPaths;
                GlobalOptions = new TestOptions(
                    ("build_property.MSBuildProjectName", projectName),
                    isShippingClientLibrary.HasValue
                        ? ("build_property.IsShippingClientLibrary",
                            isShippingClientLibrary.Value ? "true" : "false")
                        : (null, null));
            }

            public override AnalyzerConfigOptions GlobalOptions { get; }

            public override AnalyzerConfigOptions GetOptions(SyntaxTree tree) => TestOptions.Empty;

            public override AnalyzerConfigOptions GetOptions(AdditionalText textFile) =>
                _markedPaths.Contains(textFile.Path)
                    ? new TestOptions(
                        ("build_metadata.AdditionalFiles.AzureSdkCodeAnalysisSuppressionSkipValidation",
                        "true"))
                    : TestOptions.Empty;
        }

        private sealed class TestOptions : AnalyzerConfigOptions
        {
            public static readonly TestOptions Empty = new();

            private readonly Dictionary<string, string> _options = new();

            public TestOptions(params (string? Key, string? Value)[] options)
            {
                foreach ((string? key, string? value) in options)
                {
                    if (key != null && value != null)
                    {
                        _options[key] = value;
                    }
                }
            }

            public override bool TryGetValue(string key, out string value)
            {
                return _options.TryGetValue(key, out value!);
            }
        }
    }
}
