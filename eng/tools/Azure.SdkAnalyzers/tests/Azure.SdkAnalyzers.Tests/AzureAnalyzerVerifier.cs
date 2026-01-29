// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Testing;
using Microsoft.CodeAnalysis.Testing.Verifiers;

namespace Azure.SdkAnalyzers.Tests
{
    public static class AzureAnalyzerVerifier<TAnalyzer> where TAnalyzer : DiagnosticAnalyzer, new()
    {
        private static readonly ReferenceAssemblies DefaultReferenceAssemblies =
            ReferenceAssemblies.Default.AddPackages(ImmutableArray.Create(
                new PackageIdentity("Azure.Core", "1.35.0"),
                new PackageIdentity("Microsoft.Bcl.AsyncInterfaces", "1.1.1"),
                new PackageIdentity("System.Text.Json", "4.7.2"),
                new PackageIdentity("System.Threading.Tasks.Extensions", "4.5.4")));

        public static CSharpAnalyzerTest<TAnalyzer, NUnitVerifier> CreateAnalyzer(string source, LanguageVersion languageVersion = LanguageVersion.Latest, Type[]? additionalReferences = null)
        {
            var test = new CSharpAnalyzerTest<TAnalyzer, NUnitVerifier>
            {
                ReferenceAssemblies = DefaultReferenceAssemblies,
                SolutionTransforms = {(solution, projectId) =>
                {
                    var project = solution.GetProject(projectId);
                    var parseOptions = (CSharpParseOptions?)project?.ParseOptions;
                    if (parseOptions != null && solution != null && project != null)
                    {
                        return solution.WithProjectParseOptions(projectId, parseOptions.WithLanguageVersion(languageVersion));
                    }
                    return solution!;
                }},
                TestCode = source,
                TestBehaviors = TestBehaviors.SkipGeneratedCodeCheck
            };

            if (additionalReferences != null)
            {
                foreach (var reference in additionalReferences)
                {
                    test.TestState.AdditionalReferences.Add(reference.Assembly);
                }
            }

            return test;
        }

        public static Task VerifyAnalyzerAsync(string source, LanguageVersion languageVersion = LanguageVersion.Latest, Type[]? additionalReferences = null)
            => CreateAnalyzer(source, languageVersion, additionalReferences).RunAsync(CancellationToken.None);
    }
}
