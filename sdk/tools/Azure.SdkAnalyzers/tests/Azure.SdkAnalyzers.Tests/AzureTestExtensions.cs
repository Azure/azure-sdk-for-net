// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.CodeAnalysis.CSharp.Testing;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Testing;

namespace Azure.SdkAnalyzers.Tests
{
    public static class AzureTestExtensions
    {
        public static CSharpAnalyzerTest<TAnalyzer, DefaultVerifier> WithSources<TAnalyzer>(this CSharpAnalyzerTest<TAnalyzer, DefaultVerifier> test, params string[] sources)
            where TAnalyzer : DiagnosticAnalyzer, new()
        {
            foreach (var source in sources)
            {
                test.TestState.Sources.Add(source);
            }
            return test;
        }

        public static CSharpAnalyzerTest<TAnalyzer, DefaultVerifier> WithDisabledDiagnostics<TAnalyzer>(this CSharpAnalyzerTest<TAnalyzer, DefaultVerifier> test, params string[] diagnostics)
            where TAnalyzer : DiagnosticAnalyzer, new()
        {
            test.DisabledDiagnostics.AddRange(diagnostics);
            return test;
        }
    }
}
