// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Testing;
using NUnit.Framework;

namespace Azure.SdkAnalyzers.Tests
{
    public class AZC0021Tests
    {
        private const string AllowListWithControlledRule = @"
# Test allow list
AZC0004:Azure.Storage.*
AZC0004:Azure.Messaging.EventHubs
SA1636:Azure.Core
";

        private static CSharpAnalyzerTest<SuppressionPolicyAnalyzer, DefaultVerifier> CreateTest(
            string source,
            string? allowList = null,
            string assemblyName = "Azure.TestProject")
        {
            var test = new CSharpAnalyzerTest<SuppressionPolicyAnalyzer, DefaultVerifier>
            {
                ReferenceAssemblies = AzureTestReferences.DefaultReferenceAssemblies,
                TestCode = source,
                TestBehaviors = TestBehaviors.SkipGeneratedCodeCheck,
                SolutionTransforms =
                {
                    (solution, projectId) =>
                    {
                        return solution.WithProjectAssemblyName(projectId, assemblyName);
                    }
                }
            };

            if (allowList != null)
            {
                test.TestState.AdditionalFiles.Add(("SuppressionAllowList.txt", allowList));
            }

            return test;
        }

        [Test]
        public async Task PragmaDisable_ControlledRule_NotAllowed_ProducesDiagnostic()
        {
            const string code = @"
#pragma warning disable {|AZC0021:AZC0004|}
namespace Azure.TestProject
{
    public class MyClass { }
}
#pragma warning restore AZC0004
";

            var test = CreateTest(code, AllowListWithControlledRule);
            await test.RunAsync();
        }

        [Test]
        public async Task PragmaDisable_ControlledRule_Allowed_NoDiagnostic()
        {
            const string code = @"
#pragma warning disable AZC0004
namespace Azure.Storage.Blobs
{
    public class MyClass { }
}
#pragma warning restore AZC0004
";

            var test = CreateTest(code, AllowListWithControlledRule, assemblyName: "Azure.Storage.Blobs");
            await test.RunAsync();
        }

        [Test]
        public async Task PragmaDisable_ControlledRule_NonMatchingPackage_ProducesDiagnostic()
        {
            const string code = @"
#pragma warning disable {|AZC0021:AZC0004|}
namespace Azure.Identity
{
    public class MyClass { }
}
#pragma warning restore AZC0004
";

            var test = CreateTest(code, AllowListWithControlledRule, assemblyName: "Azure.Identity");
            await test.RunAsync();
        }

        [Test]
        public async Task PragmaDisable_UncontrolledRule_NoDiagnostic()
        {
            const string code = @"
#pragma warning disable CS0168
namespace Azure.TestProject
{
    public class MyClass { }
}
#pragma warning restore CS0168
";

            var test = CreateTest(code, AllowListWithControlledRule);
            await test.RunAsync();
        }

        [Test]
        public async Task PragmaRestore_DoesNotTrigger()
        {
            const string code = @"
#pragma warning restore AZC0004
namespace Azure.TestProject
{
    public class MyClass { }
}
";

            var test = CreateTest(code, AllowListWithControlledRule);
            await test.RunAsync();
        }

        [Test]
        public async Task GlobPattern_WildcardMatches()
        {
            const string code = @"
#pragma warning disable AZC0004
namespace Azure.Storage.Blobs
{
    public class MyClass { }
}
#pragma warning restore AZC0004
";

            var test = CreateTest(code, AllowListWithControlledRule, assemblyName: "Azure.Storage.Blobs");
            await test.RunAsync();
        }

        [Test]
        public async Task ExactPackageMatch()
        {
            const string code = @"
#pragma warning disable AZC0004
namespace Azure.Messaging.EventHubs
{
    public class MyClass { }
}
#pragma warning restore AZC0004
";

            var test = CreateTest(code, AllowListWithControlledRule, assemblyName: "Azure.Messaging.EventHubs");
            await test.RunAsync();
        }

        [Test]
        public async Task SuppressMessage_ControlledRule_NotAllowed_ProducesDiagnostic()
        {
            const string code = @"
using System.Diagnostics.CodeAnalysis;

namespace Azure.TestProject
{
    public class MyClass
    {
        [{|AZC0021:SuppressMessage(""Usage"", ""AZC0004:Provide async and sync"")|}]
        public void MyMethod() { }
    }
}
";

            var test = CreateTest(code, AllowListWithControlledRule);
            await test.RunAsync();
        }

        [Test]
        public async Task SuppressMessage_ControlledRule_Allowed_NoDiagnostic()
        {
            const string code = @"
using System.Diagnostics.CodeAnalysis;

namespace Azure.Storage.Blobs
{
    public class MyClass
    {
        [SuppressMessage(""Usage"", ""AZC0004:Provide async and sync"")]
        public void MyMethod() { }
    }
}
";

            var test = CreateTest(code, AllowListWithControlledRule, assemblyName: "Azure.Storage.Blobs");
            await test.RunAsync();
        }

        [Test]
        public async Task SuppressMessage_UncontrolledRule_NoDiagnostic()
        {
            const string code = @"
using System.Diagnostics.CodeAnalysis;

namespace Azure.TestProject
{
    public class MyClass
    {
        [SuppressMessage(""Usage"", ""CA1234:Some other rule"")]
        public void MyMethod() { }
    }
}
";

            var test = CreateTest(code, AllowListWithControlledRule);
            await test.RunAsync();
        }

        [Test]
        public async Task SuppressMessage_FullNamespace_ProducesDiagnostic()
        {
            const string code = @"
namespace Azure.TestProject
{
    public class MyClass
    {
        [{|AZC0021:System.Diagnostics.CodeAnalysis.SuppressMessage(""Usage"", ""AZC0004:Provide async"")|}]
        public void MyMethod() { }
    }
}
";

            var test = CreateTest(code, AllowListWithControlledRule);
            await test.RunAsync();
        }

        [Test]
        public async Task NoAllowList_NoDiagnostic()
        {
            const string code = @"
#pragma warning disable AZC0004
namespace Azure.TestProject
{
    public class MyClass { }
}
#pragma warning restore AZC0004
";

            var test = CreateTest(code, allowList: null!);
            await test.RunAsync();
        }

        [Test]
        public async Task EmptyAllowList_NoDiagnostic()
        {
            const string code = @"
#pragma warning disable AZC0004
namespace Azure.TestProject
{
    public class MyClass { }
}
#pragma warning restore AZC0004
";

            var test = CreateTest(code, allowList: "# Only comments\n");
            await test.RunAsync();
        }

        [Test]
        public async Task MultipleRuleIds_InSinglePragma_ReportsEachControlledRule()
        {
            const string code = @"
#pragma warning disable {|AZC0021:AZC0004|}, CS0168
namespace Azure.TestProject
{
    public class MyClass { }
}
#pragma warning restore AZC0004, CS0168
";

            var test = CreateTest(code, AllowListWithControlledRule);
            await test.RunAsync();
        }

        [Test]
        public async Task BlanketPragmaDisable_ProducesDiagnostic()
        {
            const string code = @"
{|AZC0021:#pragma warning disable|}
namespace Azure.TestProject
{
    public class MyClass { }
}
#pragma warning restore
";

            var test = CreateTest(code, AllowListWithControlledRule);
            await test.RunAsync();
        }

        [Test]
        public async Task AssemblyLevel_SuppressMessage_ProducesDiagnostic()
        {
            const string code = @"
using System.Diagnostics.CodeAnalysis;

[assembly: {|AZC0021:SuppressMessage(""Usage"", ""AZC0004:Provide async and sync"")|}]
namespace Azure.TestProject
{
    public class MyClass { }
}
";

            var test = CreateTest(code, AllowListWithControlledRule);
            await test.RunAsync();
        }

        [Test]
        public async Task SuppressMessage_RuleIdWithoutDescription_ProducesDiagnostic()
        {
            const string code = @"
using System.Diagnostics.CodeAnalysis;

namespace Azure.TestProject
{
    public class MyClass
    {
        [{|AZC0021:SuppressMessage(""Usage"", ""AZC0004"")|}]
        public void MyMethod() { }
    }
}
";

            var test = CreateTest(code, AllowListWithControlledRule);
            await test.RunAsync();
        }

        [Test]
        public async Task CaseInsensitive_RuleIdMatching()
        {
            const string code = @"
#pragma warning disable {|AZC0021:azc0004|}
namespace Azure.TestProject
{
    public class MyClass { }
}
#pragma warning restore azc0004
";

            var test = CreateTest(code, AllowListWithControlledRule);
            await test.RunAsync();
        }
    }
}
