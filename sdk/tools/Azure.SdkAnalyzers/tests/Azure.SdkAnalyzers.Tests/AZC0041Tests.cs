// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
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

            await Verifier.CreateAnalyzer(code).RunAsync();
        }

        [Test]
        public async Task ReportsNumericCompilerWarningPragma()
        {
            string code = @"
#pragma warning disable {|AZC0041:0618|}
namespace Azure.Test { public class TestClient { } }
";

            await Verifier.CreateAnalyzer(code).RunAsync();
        }

        [TestCase("AZC\\u0030007")]
        public async Task ReportsEscapedGovernedPragma(string diagnosticId)
        {
            string code = $@"
#pragma warning disable {{|AZC0041:{diagnosticId}|}}
namespace Azure.Test {{ public class TestClient {{ }} }}
";

            await Verifier.CreateAnalyzer(code).RunAsync();
        }

        [Test]
        public async Task ReportsEachGovernedIdInMixedPragma()
        {
            string code = @"
#pragma warning disable {|AZC0041:AZC0007|}, CA1822, {|AZC0041:CS0618|}
namespace Azure.Test { public class TestClient { } }
";

            await Verifier.CreateAnalyzer(code).RunAsync();
        }

        [Test]
        public async Task DoesNotReportUngovernedPragma()
        {
            string code = @"
#pragma warning disable CA1822
namespace Azure.Test { public class TestClient { } }
";

            await Verifier.CreateAnalyzer(code).RunAsync();
        }

        [Test]
        public async Task ReportsGlobalPragma()
        {
            string code = @"
{|AZC0041:#pragma warning disable|}
namespace Azure.Test { public class TestClient { } }
";

            await Verifier.CreateAnalyzer(code).RunAsync();
        }

        [Test]
        public async Task DoesNotReportRestorePragma()
        {
            string code = @"
#pragma warning restore AZC0007
namespace Azure.Test { public class TestClient { } }
";

            await Verifier.CreateAnalyzer(code).RunAsync();
        }

        [TestCase("SuppressMessage")]
        [TestCase("SuppressMessageAttribute")]
        public async Task ReportsSuppressionAttribute(string attributeName)
        {
            string code = $@"
using System.Diagnostics.CodeAnalysis;
namespace Azure.Test
{{
    [{attributeName}(""Usage"", {{|AZC0041:""AZC0015:Unexpected return type""|}}, Justification = ""Required"")]
    public class TestClient {{ }}
}}
";

            await Verifier.CreateAnalyzer(code).RunAsync();
        }

        [TestCase("checkId: {|AZC0041:\"AZC0015\"|}, category: \"Usage\"")]
        [TestCase("\"Usage\", checkId: {|AZC0041:\"AZC0015\"|}")]
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

            await Verifier.CreateAnalyzer(code).RunAsync();
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

            await Verifier.CreateAnalyzer(code).RunAsync();
        }

        [Test]
        public async Task ReportsAssemblyGlobalSuppression()
        {
            string code = @"
using System.Diagnostics.CodeAnalysis;
[assembly: SuppressMessage(""Usage"", {|AZC0041:""AZC0034""|}, Scope = ""type"", Target = ""~T:Azure.Test.TestClient"")]
namespace Azure.Test { public class TestClient { } }
";

            await Verifier.CreateAnalyzer(code).RunAsync();
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

            await Verifier.CreateAnalyzer(code).RunAsync();
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

            await Verifier.CreateAnalyzer(code).RunAsync();
        }
    }
}
