// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Testing;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.SdkAnalyzers.Tests
{
    public static class AzureAnalyzerVerifier<TAnalyzer> where TAnalyzer : DiagnosticAnalyzer, new()
    {
        public static CSharpAnalyzerTest<TAnalyzer, DefaultVerifier> CreateAnalyzer(string source, LanguageVersion languageVersion = LanguageVersion.Latest, Type[]? additionalReferences = null)
        {
            CSharpAnalyzerTest<TAnalyzer, DefaultVerifier> test = new CSharpAnalyzerTest<TAnalyzer, DefaultVerifier>
            {
                ReferenceAssemblies = AzureTestReferences.DefaultReferenceAssemblies,
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
