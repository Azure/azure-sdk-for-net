// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Testing;
using System.Collections.Immutable;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.SdkAnalyzers.Tests
{
    public static class AzureCodeFixVerifier<TAnalyzer, TCodeFix>
        where TAnalyzer : DiagnosticAnalyzer, new()
        where TCodeFix : CodeFixProvider, new()
    {
        private static readonly ReferenceAssemblies DefaultReferenceAssemblies =
            ReferenceAssemblies.Default.AddPackages(ImmutableArray.Create(
                new PackageIdentity("Azure.Core", "1.35.0"),
                new PackageIdentity("Microsoft.Bcl.AsyncInterfaces", "1.1.1"),
                new PackageIdentity("System.Text.Json", "4.7.2"),
                new PackageIdentity("System.Threading.Tasks.Extensions", "4.5.4")));

        private static CSharpCodeFixTest<TAnalyzer, TCodeFix, DefaultVerifier> CreateCodeFixTest(
            string source,
            string fixedSource,
            int codeActionIndex = 0,
            LanguageVersion languageVersion = LanguageVersion.Latest)
        {
            CSharpCodeFixTest<TAnalyzer, TCodeFix, DefaultVerifier> test = new CSharpCodeFixTest<TAnalyzer, TCodeFix, DefaultVerifier>
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
                FixedCode = fixedSource,
                CodeActionIndex = codeActionIndex,
                TestBehaviors = TestBehaviors.SkipGeneratedCodeCheck
            };

            return test;
        }

        public static async Task VerifyCodeFixAsync(
            string source,
            string fixedSource,
            int codeActionIndex = 0,
            LanguageVersion languageVersion = LanguageVersion.Latest)
        {
            CSharpCodeFixTest<TAnalyzer, TCodeFix, DefaultVerifier> test = CreateCodeFixTest(source, fixedSource, codeActionIndex, languageVersion);
            await test.RunAsync(CancellationToken.None);
        }

        public static async Task VerifyCodeFixCreatesMultipleFilesAsync(
            string source,
            string sourceFilePath,
            string fixedGeneratedSource,
            string fixedGeneratedFilePath,
            string customSource,
            string customFilePath,
            int codeActionIndex = 0,
            LanguageVersion languageVersion = LanguageVersion.Latest)
        {
            CSharpCodeFixTest<TAnalyzer, TCodeFix, DefaultVerifier> test = new()
            {
                ReferenceAssemblies = DefaultReferenceAssemblies,
                SolutionTransforms = {(solution, projectId) =>
                {
                    Project? project = solution.GetProject(projectId);
                    CSharpParseOptions? parseOptions = (CSharpParseOptions?)project?.ParseOptions;
                    if (parseOptions != null && solution != null && project != null)
                    {
                        return solution.WithProjectParseOptions(projectId, parseOptions.WithLanguageVersion(languageVersion));
                    }
                    return solution!;
                }},
                CodeActionIndex = codeActionIndex,
                TestBehaviors = TestBehaviors.SkipGeneratedCodeCheck,
                CompilerDiagnostics = CompilerDiagnostics.None // Don't compile since Custom file references missing assembly
            };

            // Set the source files - include the Custom file as empty so the fix "modifies" it instead of creating it
            test.TestState.Sources.Add((sourceFilePath, source));
            test.TestState.Sources.Add((customFilePath, string.Empty)); // Empty initial Custom file

            // Set both expected output files after the fix
            test.FixedState.Sources.Add((fixedGeneratedFilePath, fixedGeneratedSource));
            test.FixedState.Sources.Add((customFilePath, customSource));

            await test.RunAsync(CancellationToken.None);
        }
    }
}
