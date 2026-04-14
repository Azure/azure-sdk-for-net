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
    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(ConfigureAwaitCodeFixProvider)), Shared]
    public class ConfigureAwaitCodeFixProvider : CodeFixProvider
    {
        public sealed override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create("AZC0101");

        public sealed override FixAllProvider GetFixAllProvider() => WellKnownFixAllProviders.BatchFixer;

        public sealed override async Task RegisterCodeFixesAsync(CodeFixContext context)
        {
            SyntaxNode root = await context.Document.GetSyntaxRootAsync(context.CancellationToken).ConfigureAwait(false);
            if (root is null)
            {
                return;
            }

            Diagnostic diagnostic = context.Diagnostics.First();

            // The diagnostic span covers "ConfigureAwait(true)" — find the invocation
            SyntaxNode node = root.FindNode(diagnostic.Location.SourceSpan);
            InvocationExpressionSyntax invocation = node.AncestorsAndSelf().OfType<InvocationExpressionSyntax>()
                .FirstOrDefault(i => i.Expression is MemberAccessExpressionSyntax m && m.Name.Identifier.Text == "ConfigureAwait");

            if (invocation == null)
            {
                return;
            }

            context.RegisterCodeFix(
                CodeAction.Create(
                    title: "Use ConfigureAwait(false)",
                    createChangedDocument: c => ReplaceWithFalseAsync(context.Document, invocation.Span, c),
                    equivalenceKey: "AZC0101_UseConfigureAwaitFalse"),
                diagnostic);
        }

        private static async Task<Document> ReplaceWithFalseAsync(Document document, Microsoft.CodeAnalysis.Text.TextSpan invocationSpan, CancellationToken cancellationToken)
        {
            SyntaxNode root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
            if (root is null)
            {
                return document;
            }

            // Re-locate the invocation from the current root using the original span
            InvocationExpressionSyntax invocation = root.FindNode(invocationSpan)
                .AncestorsAndSelf()
                .OfType<InvocationExpressionSyntax>()
                .FirstOrDefault(i => i.Expression is MemberAccessExpressionSyntax m && m.Name.Identifier.Text == "ConfigureAwait");

            if (invocation == null)
            {
                return document;
            }

            // Replace the last argument (true) with false
            ArgumentSyntax lastArg = invocation.ArgumentList.Arguments.Last();
            LiteralExpressionSyntax falseLiteral = SyntaxFactory.LiteralExpression(SyntaxKind.FalseLiteralExpression)
                .WithTriviaFrom(lastArg.Expression);

            ArgumentSyntax newArg = lastArg.WithExpression(falseLiteral);
            SyntaxNode newRoot = root.ReplaceNode(lastArg, newArg);

            return document.WithSyntaxRoot(newRoot);
        }
    }
}
