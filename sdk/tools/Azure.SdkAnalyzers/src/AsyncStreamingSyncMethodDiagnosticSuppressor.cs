// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable enable

using System.Collections.Immutable;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Azure.SdkAnalyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public sealed class AsyncStreamingSyncMethodDiagnosticSuppressor : DiagnosticSuppressor
    {
        private static readonly SuppressionDescriptor s_suppression = new(
            id: "AZSDKSPAZC0004",
            suppressedDiagnosticId: "AZC0004",
            justification: "AsyncStreamingClientResult has no synchronous counterpart.");

        public override ImmutableArray<SuppressionDescriptor> SupportedSuppressions =>
            ImmutableArray.Create(s_suppression);

        public override void ReportSuppressions(SuppressionAnalysisContext context)
        {
            foreach (Diagnostic diagnostic in context.ReportedDiagnostics)
            {
                SyntaxTree? syntaxTree = diagnostic.Location.SourceTree;
                if (syntaxTree is null)
                {
                    continue;
                }

                SyntaxNode node = syntaxTree.GetRoot(context.CancellationToken)
                    .FindNode(diagnostic.Location.SourceSpan, getInnermostNodeForTie: true);
                MethodDeclarationSyntax? methodDeclaration = node.FirstAncestorOrSelf<MethodDeclarationSyntax>();
                if (methodDeclaration is null)
                {
                    continue;
                }

                SemanticModel semanticModel = context.GetSemanticModel(syntaxTree);
                if (semanticModel.GetDeclaredSymbol(methodDeclaration, context.CancellationToken) is IMethodSymbol method &&
                    AsyncStreamingResultTypeHelper.IsAsyncStreamingMethod(method, context.Compilation))
                {
                    context.ReportSuppression(Suppression.Create(s_suppression, diagnostic));
                }
            }
        }
    }
}
