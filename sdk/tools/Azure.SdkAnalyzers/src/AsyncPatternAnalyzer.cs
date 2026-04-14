// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
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
        private AsyncAnalyzerUtilities _asyncUtilities;

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } =
            ImmutableArray.Create(Descriptors.AZC0101);

        public override void Initialize(AnalysisContext context)
        {
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.Analyze | GeneratedCodeAnalysisFlags.ReportDiagnostics);
            context.EnableConcurrentExecution();
            context.RegisterCompilationStartAction(CompilationStart);
        }

        private void CompilationStart(CompilationStartAnalysisContext context)
        {
            _asyncUtilities = new AsyncAnalyzerUtilities(context.Compilation);

            context.RegisterSyntaxNodeAction(AnalyzeArrowExpressionClause, SyntaxKind.ArrowExpressionClause);
            context.RegisterOperationAction(AnalyzeMethodBody, OperationKind.MethodBody);
            context.RegisterOperationAction(AnalyzeAnonymousFunction, OperationKind.AnonymousFunction);
        }

        private void AnalyzeArrowExpressionClause(SyntaxNodeAnalysisContext context)
        {
            if (!(context.ContainingSymbol is IMethodSymbol method) || method.MethodKind != MethodKind.PropertyGet)
            {
                return;
            }

            var operation = context.SemanticModel.GetOperation(context.Node, context.CancellationToken);
            if (operation is IBlockOperation block && block.Parent == null)
            {
                MethodBodyAnalyzer.Run(context.ReportDiagnostic, context.Compilation, _asyncUtilities, method, block);
            }
        }

        private void AnalyzeMethodBody(OperationAnalysisContext context)
        {
            var method = (IMethodSymbol) context.ContainingSymbol;
            var methodBody = (IMethodBodyOperation)context.Operation;
            MethodBodyAnalyzer.Run(context.ReportDiagnostic, context.Compilation, _asyncUtilities, method, methodBody.BlockBody ?? methodBody.ExpressionBody);
        }

        private void AnalyzeAnonymousFunction(OperationAnalysisContext context)
        {
            var operation = (IAnonymousFunctionOperation) context.Operation;
            var method = operation.Symbol;
            if (method.ContainingSymbol.Kind != SymbolKind.Method)
            {
                MethodBodyAnalyzer.Run(context.ReportDiagnostic, context.Compilation, _asyncUtilities, method, operation.Body);
            }
        }
    }
}
