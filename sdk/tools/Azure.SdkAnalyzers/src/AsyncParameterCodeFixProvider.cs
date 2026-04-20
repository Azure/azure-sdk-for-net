// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Immutable;
using System.Composition;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CodeActions;
using Microsoft.CodeAnalysis.CodeFixes;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace Azure.SdkAnalyzers
{
    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(AsyncParameterCodeFixProvider)), Shared]
    public class AsyncParameterCodeFixProvider : CodeFixProvider
    {
        public sealed override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create("AZC0108");

        public sealed override FixAllProvider GetFixAllProvider() => WellKnownFixAllProviders.BatchFixer;

        public sealed override async Task RegisterCodeFixesAsync(CodeFixContext context)
        {
            SyntaxNode root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);
            if (root is null)
            {
                return;
            }

            Diagnostic diagnostic = context.Diagnostics.First();
            SyntaxNode node = root.FindNode(diagnostic.Location.SourceSpan);

            // The diagnostic is on the boolean literal argument (true/false)
            LiteralExpressionSyntax literal = node.DescendantNodesAndSelf()
                .OfType<LiteralExpressionSyntax>()
                .FirstOrDefault(l => l.IsKind(SyntaxKind.TrueLiteralExpression) || l.IsKind(SyntaxKind.FalseLiteralExpression));

            if (literal == null)
            {
                return;
            }

            // Only offer the fix if the containing method has a 'bool async' parameter
            string asyncParamName = FindAsyncParameterName(literal);
            if (asyncParamName == null)
            {
                return;
            }

            context.RegisterCodeFix(
                CodeAction.Create(
                    title: $"Forward '{asyncParamName}' parameter",
                    createChangedDocument: c => ForwardAsyncParameterAsync(context.Document, literal, asyncParamName, c),
                    equivalenceKey: "AZC0108_ForwardAsyncParameter"),
                diagnostic);
        }

        private static string FindAsyncParameterName(SyntaxNode node)
        {
            foreach (SyntaxNode ancestor in node.Ancestors())
            {
                ParameterListSyntax parameterList = null;

                switch (ancestor)
                {
                    case MethodDeclarationSyntax method:
                        parameterList = method.ParameterList;
                        break;
                    case LocalFunctionStatementSyntax localFunc:
                        parameterList = localFunc.ParameterList;
                        break;
                    case ParenthesizedLambdaExpressionSyntax lambda:
                        parameterList = lambda.ParameterList;
                        break;
                }

                if (parameterList != null)
                {
                    ParameterSyntax asyncParam = parameterList.Parameters
                        .FirstOrDefault(p => p.Type != null &&
                            (p.Type.ToString() == "bool" || p.Type.ToString() == "Boolean" || p.Type.ToString() == "System.Boolean") &&
                            p.Identifier.Text == "async");

                    if (asyncParam != null)
                    {
                        return asyncParam.Identifier.Text;
                    }

                    // Stop at the first method-like ancestor
                    return null;
                }
            }

            return null;
        }

        private static async Task<Document> ForwardAsyncParameterAsync(
            Document document,
            LiteralExpressionSyntax literal,
            string asyncParamName,
            CancellationToken cancellationToken)
        {
            SyntaxNode root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);

            IdentifierNameSyntax asyncIdentifier = SyntaxFactory.IdentifierName(asyncParamName)
                .WithTriviaFrom(literal);

            return document.WithSyntaxRoot(root.ReplaceNode(literal, asyncIdentifier));
        }
    }
}
