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
    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(TaskCompletionSourceCodeFixProvider)), Shared]
    public class TaskCompletionSourceCodeFixProvider : CodeFixProvider
    {
        private const string RunContinuationsAsynchronously = "TaskCreationOptions.RunContinuationsAsynchronously";

        public sealed override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create("AZC0013");

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

            ObjectCreationExpressionSyntax objectCreation = node.AncestorsAndSelf()
                .OfType<ObjectCreationExpressionSyntax>()
                .FirstOrDefault();

            if (objectCreation == null)
            {
                return;
            }

            context.RegisterCodeFix(
                CodeAction.Create(
                    title: "Add TaskCreationOptions.RunContinuationsAsynchronously",
                    createChangedDocument: c => AddRunContinuationsAsynchronouslyAsync(context.Document, objectCreation, c),
                    equivalenceKey: "AZC0013_AddRunContinuationsAsynchronously"),
                diagnostic);
        }

        private static async Task<Document> AddRunContinuationsAsynchronouslyAsync(
            Document document,
            ObjectCreationExpressionSyntax objectCreation,
            CancellationToken cancellationToken)
        {
            SyntaxNode root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);
            SemanticModel semanticModel = await document.GetSemanticModelAsync(cancellationToken).ConfigureAwait(false);

            ExpressionSyntax runContinuationsExpr = SyntaxFactory.ParseExpression(RunContinuationsAsynchronously);

            ObjectCreationExpressionSyntax newCreation;

            if (objectCreation.ArgumentList == null || objectCreation.ArgumentList.Arguments.Count == 0)
            {
                // Case 1: new TaskCompletionSource<T>()
                // → new TaskCompletionSource<T>(TaskCreationOptions.RunContinuationsAsynchronously)
                ArgumentListSyntax newArgList = SyntaxFactory.ArgumentList(
                    SyntaxFactory.SingletonSeparatedList(
                        SyntaxFactory.Argument(runContinuationsExpr)));
                newCreation = objectCreation.WithArgumentList(newArgList);
            }
            else
            {
                // Find the TaskCreationOptions argument
                int taskCreationOptionsArgIndex = -1;
                for (int i = 0; i < objectCreation.ArgumentList.Arguments.Count; i++)
                {
                    ArgumentSyntax arg = objectCreation.ArgumentList.Arguments[i];
                    TypeInfo typeInfo = semanticModel.GetTypeInfo(arg.Expression, cancellationToken);
                    ITypeSymbol resolvedType = typeInfo.Type ?? typeInfo.ConvertedType;
                    if (resolvedType?.Name == "TaskCreationOptions" &&
                        resolvedType.ContainingNamespace?.ToDisplayString() == "System.Threading.Tasks")
                    {
                        taskCreationOptionsArgIndex = i;
                        break;
                    }
                }

                if (taskCreationOptionsArgIndex == -1)
                {
                    // Case 2: new TaskCompletionSource<T>(stateObj) — no TaskCreationOptions arg
                    // → new TaskCompletionSource<T>(stateObj, TaskCreationOptions.RunContinuationsAsynchronously)
                    SeparatedSyntaxList<ArgumentSyntax> newArgs = objectCreation.ArgumentList.Arguments.Add(
                        SyntaxFactory.Argument(runContinuationsExpr));
                    newCreation = objectCreation.WithArgumentList(
                        objectCreation.ArgumentList.WithArguments(newArgs));
                }
                else
                {
                    // Case 3: Has TaskCreationOptions but missing RunContinuationsAsynchronously
                    // → prepend: TaskCreationOptions.RunContinuationsAsynchronously | <existing>
                    ArgumentSyntax existingArg = objectCreation.ArgumentList.Arguments[taskCreationOptionsArgIndex];
                    string existingText = existingArg.Expression.WithoutLeadingTrivia().ToFullString();
                    ExpressionSyntax combinedExpr = SyntaxFactory.ParseExpression(
                        $"{RunContinuationsAsynchronously} | {existingText}");
                    ArgumentSyntax newArg = existingArg.WithExpression(combinedExpr);
                    SeparatedSyntaxList<ArgumentSyntax> newArgs = objectCreation.ArgumentList.Arguments.Replace(existingArg, newArg);
                    newCreation = objectCreation.WithArgumentList(
                        objectCreation.ArgumentList.WithArguments(newArgs));
                }
            }

            return document.WithSyntaxRoot(root.ReplaceNode(objectCreation, newCreation));
        }
    }
}
