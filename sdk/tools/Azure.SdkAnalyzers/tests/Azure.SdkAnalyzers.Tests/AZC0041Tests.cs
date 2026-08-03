// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
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
        [TestCase("AZC0012")]
        [TestCase("AZC0014")]
        [TestCase("AZC0015")]
        [TestCase("AZC0030")]
        [TestCase("AZC0034")]
        [TestCase("AZC0035")]
        [TestCase("CS0618")]
        [TestCase("AAIP001")]
        [TestCase("OPENAI001")]
        [TestCase("OPENAICUA001")]
        public async Task ReportsGovernedPragma(string diagnosticId)
        {
            string code = $@"
#pragma warning disable {{|AZC0041:{diagnosticId}|}}
namespace Azure.Test {{ public class TestClient {{ }} }}
";

            await VerifyAnalyzerAsync(code);
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
        public async Task ReportsEscapedGovernedPragma(string diagnosticId)
        {
            string code = $@"
#pragma warning disable {{|AZC0041:{diagnosticId}|}}
namespace Azure.Test {{ public class TestClient {{ }} }}
";

            await VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task ReportsEachGovernedIdInMixedPragma()
        {
            string code = @"
#pragma warning disable {|AZC0041:AZC0007|}, CA1822, {|AZC0041:CS0618|}
namespace Azure.Test { public class TestClient { } }
";

            await VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task ReportsSelfSuppressionBeforeGovernedSuppression()
        {
            string code = @"
#pragma warning disable AZC0041
#pragma warning disable AZC0007
namespace Azure.Test { public class TestClient { } }
";

            var refAssemblies = await AzureTestReferences.DefaultReferenceAssemblies.ResolveAsync(
                Microsoft.CodeAnalysis.LanguageNames.CSharp, CancellationToken.None);
            var syntaxTree = Microsoft.CodeAnalysis.CSharp.CSharpSyntaxTree.ParseText(code);
            var compilation = Microsoft.CodeAnalysis.CSharp.CSharpCompilation.Create(
                "TestAssembly",
                new[] { syntaxTree },
                refAssemblies,
                new Microsoft.CodeAnalysis.CSharp.CSharpCompilationOptions(
                    Microsoft.CodeAnalysis.OutputKind.DynamicallyLinkedLibrary));
            var withAnalyzers = ((Microsoft.CodeAnalysis.Compilation)compilation).WithAnalyzers(
                ImmutableArray.Create<Microsoft.CodeAnalysis.Diagnostics.DiagnosticAnalyzer>(
                    new Azure.SdkAnalyzers.CodeAnalysisSuppressionAnalyzer()));

            var diagnostics = await withAnalyzers.GetAnalyzerDiagnosticsAsync(CancellationToken.None);
            Assert.That(diagnostics.Count(diagnostic => diagnostic.Id == nameof(Descriptors.AZC0041)), Is.EqualTo(2));
        }

        [Test]
        public async Task DoesNotReportUngovernedPragma()
        {
            string code = @"
#pragma warning disable CA1822
namespace Azure.Test { public class TestClient { } }
";

            await VerifyAnalyzerAsync(code);
        }

        [Test]
        public async Task ReportsGlobalPragma()
        {
            string code = @"
{|AZC0041:#pragma warning disable|}
namespace Azure.Test { public class TestClient { } }
";

            await VerifyAnalyzerAsync(code);
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

        [TestCase("SuppressMessage")]
        [TestCase("SuppressMessageAttribute")]
        public async Task DoesNotReportSelfSuppressionAttribute(string attributeName)
        {
            string code = $@"
using System.Diagnostics.CodeAnalysis;
namespace Azure.Test
{{
    [{attributeName}(""Usage"", ""AZC0041:Self suppression"", Justification = ""Required"")]
    public class TestClient {{ }}
}}
";

            // Roslyn applies SuppressMessage after analyzer execution, so an attribute targeting
            // AZC0041 also suppresses the diagnostic raised for that same attribute.
            await VerifyAnalyzerAsync(code);
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

        [Test]
        public async Task ReportsUnconditionalSuppressionAttribute()
        {
            string code = @"
#pragma warning disable CS0436
using System.Diagnostics.CodeAnalysis;

namespace System.Diagnostics.CodeAnalysis
{
    [System.AttributeUsage(System.AttributeTargets.All, AllowMultiple = true)]
    public sealed class UnconditionalSuppressMessageAttribute : System.Attribute
    {
        public UnconditionalSuppressMessageAttribute(string category, string checkId) { }
    }
}

namespace Azure.Test
{
    [UnconditionalSuppressMessage(""Usage"", {|AZC0041:""AZC0015""|})]
    public class TestClient { }
}
";

            await VerifyAnalyzerAsync(code);
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
        public async Task DoesNotReportUngovernedSuppressionAttribute()
        {
            string code = @"
using System.Diagnostics.CodeAnalysis;
namespace Azure.Test
{
    [SuppressMessage(""Usage"", ""CA1822"", Justification = ""Required"")]
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
        public void DoesNotSkipForUnmarkedFileWithBacklogName()
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
                new TestOptionsProvider(projectName, markedPaths));
            return CodeAnalysisSuppressionAnalyzer.ShouldSkipProject(options, CancellationToken.None);
        }

        private static Task VerifyAnalyzerAsync(string code)
        {
            var test = Verifier.CreateAnalyzer(code);

            // AZC0041 intentionally reports the pragma inserted by the test framework's generic
            // suppression check, because NotConfigurable diagnostics cannot be pragma-disabled.
            test.TestBehaviors |= TestBehaviors.SkipSuppressionCheck;
            return test.RunAsync();
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

            // Simulate the project property and AdditionalFile metadata emitted by MSBuild.
            public TestOptionsProvider(string projectName, HashSet<string> markedPaths)
            {
                _markedPaths = markedPaths;
                GlobalOptions = new TestOptions("build_property.MSBuildProjectName", projectName);
            }

            public override AnalyzerConfigOptions GlobalOptions { get; }

            public override AnalyzerConfigOptions GetOptions(SyntaxTree tree) => TestOptions.Empty;

            public override AnalyzerConfigOptions GetOptions(AdditionalText textFile) =>
                _markedPaths.Contains(textFile.Path)
                    ? new TestOptions(
                        "build_metadata.AdditionalFiles.AzureSdkCodeAnalysisSuppressionSkipValidation",
                        "true")
                    : TestOptions.Empty;
        }

        private sealed class TestOptions : AnalyzerConfigOptions
        {
            public static readonly TestOptions Empty = new(null, null);

            private readonly string? _key;
            private readonly string? _value;

            public TestOptions(string? key, string? value)
            {
                _key = key;
                _value = value;
            }

            public override bool TryGetValue(string key, out string value)
            {
                if (key == _key)
                {
                    value = _value!;
                    return true;
                }

                value = null!;
                return false;
            }
        }
    }
}
