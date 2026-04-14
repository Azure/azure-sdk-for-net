// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Operations;

namespace Azure.SdkAnalyzers
{
    /// <summary>
    /// Analyzes async/sync patterns in method bodies.
    /// Reports: AZC0101 (ConfigureAwait(true)).
    /// </summary>
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public sealed class AsyncPatternAnalyzer : DiagnosticAnalyzer
    {
        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } =
            ImmutableArray.Create(Descriptors.AZC0101);

        public override void Initialize(AnalysisContext context)
        {
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze | GeneratedCodeAnalysisFlags.ReportDiagnostics);
            context.EnableConcurrentExecution();
            context.RegisterCompilationStartAction(CompilationStart);
        }

        private static void CompilationStart(CompilationStartAnalysisContext context)
        {
            var asyncUtilities = new AsyncAnalyzerUtilities(context.Compilation);

            context.RegisterOperationAction(
                ctx => AnalyzeMethodBody(ctx, asyncUtilities),
                OperationKind.MethodBody);
            context.RegisterOperationAction(
                ctx => AnalyzeAnonymousFunction(ctx, asyncUtilities),
                OperationKind.AnonymousFunction);
        }

        private static void AnalyzeMethodBody(OperationAnalysisContext context, AsyncAnalyzerUtilities asyncUtilities)
        {
            var method = (IMethodSymbol) context.ContainingSymbol;
            var methodBody = (IMethodBodyOperation)context.Operation;
            MethodBodyAnalyzer.Run(context.ReportDiagnostic, asyncUtilities, method, methodBody.BlockBody ?? methodBody.ExpressionBody);
        }

        private static void AnalyzeAnonymousFunction(OperationAnalysisContext context, AsyncAnalyzerUtilities asyncUtilities)
        {
            var operation = (IAnonymousFunctionOperation) context.Operation;
            var method = operation.Symbol;
            if (method.ContainingSymbol.Kind != SymbolKind.Method)
            {
                MethodBodyAnalyzer.Run(context.ReportDiagnostic, asyncUtilities, method, operation.Body);
            }
        }
    }
}
