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
        // Per-package allow-list file using CODE:SYMBOL format
        private const string AllowListWithEntries = @"
# Allow-list for test package
#
# nowarn: entries (MSBuild only — ignored by analyzer)
nowarn:CS1591

# Inline suppression approvals
AZC0004:M:Azure.TestProject.AllowedClass.AllowedMethod
AZC0004:T:Azure.TestProject.AllowedType
AZC0015:M:Azure.TestProject.AllowedClass.OpenWrite
SA1636:P:Azure.TestProject.AllowedClass.Name
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
                // File must be in a path containing "analyzerallowlist" directory
                test.TestState.AdditionalFiles.Add(
                    ("eng/analyzerallowlist/Azure.TestProject.txt", allowList));
            }

            return test;
        }

        [Test]
        public async Task PragmaDisable_ControlledCode_NotInAllowList_ProducesDiagnostic()
        {
            // AZC0004 is controlled, but M:Azure.TestProject.MyClass.NotAllowed is not in the list
            const string code = @"
namespace Azure.TestProject
{
    public class MyClass
    {
#pragma warning disable {|AZC0021:AZC0004|}
        public void NotAllowed() { }
#pragma warning restore AZC0004
    }
}
";

            var test = CreateTest(code, AllowListWithEntries);
            await test.RunAsync();
        }

        [Test]
        public async Task PragmaDisable_ControlledCode_InAllowList_NoDiagnostic()
        {
            // AZC0004:M:Azure.TestProject.AllowedClass.AllowedMethod is in the list
            const string code = @"
namespace Azure.TestProject
{
    public class AllowedClass
    {
#pragma warning disable AZC0004
        public void AllowedMethod() { }
#pragma warning restore AZC0004
    }
}
";

            var test = CreateTest(code, AllowListWithEntries);
            await test.RunAsync();
        }

        [Test]
        public async Task PragmaDisable_UncontrolledCode_NoDiagnostic()
        {
            // CS0168 is not a controlled code — no enforcement
            const string code = @"
namespace Azure.TestProject
{
    public class MyClass
    {
#pragma warning disable CS0168
        public void MyMethod() { }
#pragma warning restore CS0168
    }
}
";

            var test = CreateTest(code, AllowListWithEntries);
            await test.RunAsync();
        }

        [Test]
        public async Task PragmaRestore_DoesNotTrigger()
        {
            const string code = @"
namespace Azure.TestProject
{
    public class MyClass
    {
#pragma warning restore AZC0004
        public void MyMethod() { }
    }
}
";

            var test = CreateTest(code, AllowListWithEntries);
            await test.RunAsync();
        }

        [Test]
        public async Task PragmaDisable_TypeLevel_InAllowList_NoDiagnostic()
        {
            // AZC0004:T:Azure.TestProject.AllowedType is in the list
            const string code = @"
namespace Azure.TestProject
{
#pragma warning disable AZC0004
    public class AllowedType { }
#pragma warning restore AZC0004
}
";

            var test = CreateTest(code, AllowListWithEntries);
            await test.RunAsync();
        }

        [Test]
        public async Task PragmaDisable_TypeLevel_NotInAllowList_ProducesDiagnostic()
        {
            const string code = @"
namespace Azure.TestProject
{
#pragma warning disable {|AZC0021:AZC0004|}
    public class NotAllowedType { }
#pragma warning restore AZC0004
}
";

            var test = CreateTest(code, AllowListWithEntries);
            await test.RunAsync();
        }

        [Test]
        public async Task MultipleRuleIds_InSinglePragma_ReportsOnlyControlled()
        {
            // AZC0004 is controlled (and not allowed for this symbol), CS0168 is uncontrolled
            const string code = @"
namespace Azure.TestProject
{
    public class MyClass
    {
#pragma warning disable {|AZC0021:AZC0004|}, CS0168
        public void NotAllowed() { }
#pragma warning restore AZC0004, CS0168
    }
}
";

            var test = CreateTest(code, AllowListWithEntries);
            await test.RunAsync();
        }

        [Test]
        public async Task BlanketPragmaDisable_ProducesDiagnostic()
        {
            const string code = @"
namespace Azure.TestProject
{
    public class MyClass
    {
{|AZC0021:#pragma warning disable|}
        public void MyMethod() { }
#pragma warning restore
    }
}
";

            var test = CreateTest(code, AllowListWithEntries);
            await test.RunAsync();
        }

        [Test]
        public async Task SuppressMessage_ControlledCode_NotInAllowList_ProducesDiagnostic()
        {
            const string code = @"
using System.Diagnostics.CodeAnalysis;

namespace Azure.TestProject
{
    public class MyClass
    {
        [{|AZC0021:SuppressMessage(""Usage"", ""AZC0004:Provide async and sync"")|}]
        public void NotAllowed() { }
    }
}
";

            var test = CreateTest(code, AllowListWithEntries);
            await test.RunAsync();
        }

        [Test]
        public async Task SuppressMessage_ControlledCode_InAllowList_NoDiagnostic()
        {
            // AZC0004:M:Azure.TestProject.AllowedClass.AllowedMethod is allowed
            const string code = @"
using System.Diagnostics.CodeAnalysis;

namespace Azure.TestProject
{
    public class AllowedClass
    {
        [SuppressMessage(""Usage"", ""AZC0004:Provide async and sync"")]
        public void AllowedMethod() { }
    }
}
";

            var test = CreateTest(code, AllowListWithEntries);
            await test.RunAsync();
        }

        [Test]
        public async Task SuppressMessage_UncontrolledCode_NoDiagnostic()
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

            var test = CreateTest(code, AllowListWithEntries);
            await test.RunAsync();
        }

        [Test]
        public async Task SuppressMessage_FullNamespace_NotInAllowList_ProducesDiagnostic()
        {
            const string code = @"
namespace Azure.TestProject
{
    public class MyClass
    {
        [{|AZC0021:System.Diagnostics.CodeAnalysis.SuppressMessage(""Usage"", ""AZC0004:Provide async"")|}]
        public void NotAllowed() { }
    }
}
";

            var test = CreateTest(code, AllowListWithEntries);
            await test.RunAsync();
        }

        [Test]
        public async Task SuppressMessage_RuleIdWithoutDescription_NotInAllowList_ProducesDiagnostic()
        {
            const string code = @"
using System.Diagnostics.CodeAnalysis;

namespace Azure.TestProject
{
    public class MyClass
    {
        [{|AZC0021:SuppressMessage(""Usage"", ""AZC0004"")|}]
        public void NotAllowed() { }
    }
}
";

            var test = CreateTest(code, AllowListWithEntries);
            await test.RunAsync();
        }

        [Test]
        public async Task NoAllowList_NoDiagnostic()
        {
            const string code = @"
namespace Azure.TestProject
{
    public class MyClass
    {
#pragma warning disable AZC0004
        public void MyMethod() { }
#pragma warning restore AZC0004
    }
}
";

            var test = CreateTest(code, allowList: null);
            await test.RunAsync();
        }

        [Test]
        public async Task EmptyAllowList_NoDiagnostic()
        {
            const string code = @"
namespace Azure.TestProject
{
    public class MyClass
    {
#pragma warning disable AZC0004
        public void MyMethod() { }
#pragma warning restore AZC0004
    }
}
";

            var test = CreateTest(code, allowList: "# Only comments and nowarn entries\nnowarn:CS1591\n");
            await test.RunAsync();
        }

        [Test]
        public async Task NowarnLines_IgnoredByAnalyzer()
        {
            // CS1591 appears only as a nowarn: entry — not a controlled code for the analyzer
            const string code = @"
namespace Azure.TestProject
{
    public class MyClass
    {
#pragma warning disable CS1591
        public void MyMethod() { }
#pragma warning restore CS1591
    }
}
";

            var test = CreateTest(code, AllowListWithEntries);
            await test.RunAsync();
        }

        [Test]
        public async Task PropertyLevel_InAllowList_NoDiagnostic()
        {
            // SA1636:P:Azure.TestProject.AllowedClass.Name is in the allow-list
            const string code = @"
namespace Azure.TestProject
{
    public class AllowedClass
    {
#pragma warning disable SA1636
        public string Name { get; set; }
#pragma warning restore SA1636
    }
}
";

            var test = CreateTest(code, AllowListWithEntries);
            await test.RunAsync();
        }

        [Test]
        public async Task CaseInsensitive_CodeMatching()
        {
            // azc0004 (lowercase) should still match the controlled code AZC0004
            const string code = @"
namespace Azure.TestProject
{
    public class MyClass
    {
#pragma warning disable {|AZC0021:azc0004|}
        public void NotAllowed() { }
#pragma warning restore azc0004
    }
}
";

            var test = CreateTest(code, AllowListWithEntries);
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

            var test = CreateTest(code, AllowListWithEntries);
            await test.RunAsync();
        }
    }
}
