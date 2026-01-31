// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Testing;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.SdkAnalyzers.Tests
{
    public static class AzureCodeFixVerifier<TAnalyzer, TCodeFix>
        where TAnalyzer : DiagnosticAnalyzer, new()
        where TCodeFix : CodeFixProvider, new()
    {
        public static CSharpCodeFixTest<TAnalyzer, TCodeFix, DefaultVerifier> CreateCodeFixTest(
            string source,
            string fixedSource,
            int codeActionIndex = 0,
            LanguageVersion languageVersion = LanguageVersion.Latest)
        {
            CSharpCodeFixTest<TAnalyzer, TCodeFix, DefaultVerifier> test = new CSharpCodeFixTest<TAnalyzer, TCodeFix, DefaultVerifier>
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
                FixedCode = fixedSource,
                CodeActionIndex = codeActionIndex,
                TestBehaviors = TestBehaviors.SkipGeneratedCodeCheck
            };

            // Always add CodeGenTypeAttribute to support Generated code scenarios
            test.TestState.Sources.Add((AzureTestReferences.CodeGenTypeAttributeFilePath, AzureTestReferences.CodeGenTypeAttributeSource));
            test.FixedState.Sources.Add((AzureTestReferences.CodeGenTypeAttributeFilePath, AzureTestReferences.CodeGenTypeAttributeSource));

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
                ReferenceAssemblies = AzureTestReferences.DefaultReferenceAssemblies,
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
                TestBehaviors = TestBehaviors.SkipGeneratedCodeCheck
            };

            // Add CodeGenTypeAttribute to both test and fixed states
            test.TestState.Sources.Add((AzureTestReferences.CodeGenTypeAttributeFilePath, AzureTestReferences.CodeGenTypeAttributeSource));
            test.TestState.Sources.Add((sourceFilePath, source));

            // Set both expected output files after the fix
            test.FixedState.Sources.Add((AzureTestReferences.CodeGenTypeAttributeFilePath, AzureTestReferences.CodeGenTypeAttributeSource));
            test.FixedState.Sources.Add((fixedGeneratedFilePath, fixedGeneratedSource));
            test.FixedState.Sources.Add((customFilePath, customSource));

            await test.RunAsync(CancellationToken.None);
        }

        public static async Task VerifyNoCodeFixOfferedAsync(
            string source,
            string sourceFilePath,
            LanguageVersion languageVersion = LanguageVersion.Latest)
        {
            CSharpCodeFixTest<TAnalyzer, TCodeFix, DefaultVerifier> test = new()
            {
                ReferenceAssemblies = AzureTestReferences.DefaultReferenceAssemblies,
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
                TestBehaviors = TestBehaviors.SkipGeneratedCodeCheck,
                NumberOfFixAllIterations = 0 // Expect 0 fixes to be offered
            };

            // Add CodeGenTypeAttribute to both test and fixed states
            test.TestState.Sources.Add((AzureTestReferences.CodeGenTypeAttributeFilePath, AzureTestReferences.CodeGenTypeAttributeSource));
            test.TestState.Sources.Add((sourceFilePath, source));

            // Fixed state should be identical to test state (no changes)
            test.FixedState.Sources.Add((AzureTestReferences.CodeGenTypeAttributeFilePath, AzureTestReferences.CodeGenTypeAttributeSource));
            test.FixedState.Sources.Add((sourceFilePath, source));

            await test.RunAsync(CancellationToken.None);
        }
    }
}
