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
    [ExportCodeFixProvider(LanguageNames.CSharp, Name = nameof(RequestContextCodeFixProvider)), Shared]
    public class RequestContextCodeFixProvider : CodeFixProvider
    {
        public sealed override ImmutableArray<string> FixableDiagnosticIds => ImmutableArray.Create("AZC0020");

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

            // The diagnostic is reported on the argument syntax — the ObjectCreation is a descendant
            ObjectCreationExpressionSyntax objectCreation = node.DescendantNodesAndSelf()
                .OfType<ObjectCreationExpressionSyntax>()
                .FirstOrDefault();

            if (objectCreation == null)
            {
                return;
            }

            // Find the CancellationToken parameter name from the containing method/lambda
            SemanticModel semanticModel = await context.Document.GetSemanticModelAsync(context.CancellationToken).ConfigureAwait(false);
            string tokenParamName = FindCancellationTokenParameterName(objectCreation, semanticModel);

            if (tokenParamName == null)
            {
                return;
            }

            context.RegisterCodeFix(
                CodeAction.Create(
                    title: $"Propagate {tokenParamName} to RequestContext",
                    createChangedDocument: c => PropagateCancellationTokenAsync(context.Document, objectCreation, tokenParamName, c),
                    equivalenceKey: "AZC0020_PropagateCancellationToken"),
                diagnostic);
        }

        private static string FindCancellationTokenParameterName(SyntaxNode node, SemanticModel semanticModel)
        {
            // Walk up to the containing method/lambda/local function
            foreach (SyntaxNode ancestor in node.Ancestors())
            {
                switch (ancestor)
                {
                    case SimpleLambdaExpressionSyntax lambda:
                        return GetCancellationTokenParam(lambda.Parameter, semanticModel);

                    case ParenthesizedLambdaExpressionSyntax lambda:
                        return GetCancellationTokenParam(lambda.ParameterList.Parameters, semanticModel);

                    case AnonymousMethodExpressionSyntax anonymous when anonymous.ParameterList != null:
                        return GetCancellationTokenParam(anonymous.ParameterList.Parameters, semanticModel);

                    case LocalFunctionStatementSyntax localFunction:
                        return GetCancellationTokenParam(localFunction.ParameterList.Parameters, semanticModel);

                    case MethodDeclarationSyntax method:
                        return GetCancellationTokenParam(method.ParameterList.Parameters, semanticModel);
                }
            }

            return null;
        }

        private static string GetCancellationTokenParam(ParameterSyntax parameter, SemanticModel semanticModel)
        {
            if (parameter.Type != null)
            {
                string typeName = parameter.Type.ToString();
                if (typeName == "CancellationToken" || typeName == "System.Threading.CancellationToken")
                {
                    return parameter.Identifier.Text;
                }
            }

            // Fall back to semantic model for type-inferred parameters (e.g. lambdas)
            if (semanticModel != null)
            {
                IParameterSymbol symbol = semanticModel.GetDeclaredSymbol(parameter) as IParameterSymbol;
                if (symbol?.Type?.Name == "CancellationToken" &&
                    symbol.Type.ContainingNamespace?.ToDisplayString() == "System.Threading")
                {
                    return parameter.Identifier.Text;
                }
            }

            return null;
        }

        private static string GetCancellationTokenParam(SeparatedSyntaxList<ParameterSyntax> parameters, SemanticModel semanticModel = null)
        {
            foreach (ParameterSyntax param in parameters)
            {
                if (param.Type != null)
                {
                    string typeName = param.Type.ToString();
                    if (typeName == "CancellationToken" || typeName == "System.Threading.CancellationToken")
                    {
                        return param.Identifier.Text;
                    }
                }

                // Fall back to semantic model if type syntax isn't clear
                if (semanticModel != null)
                {
                    IParameterSymbol symbol = semanticModel.GetDeclaredSymbol(param) as IParameterSymbol;
                    if (symbol?.Type?.Name == "CancellationToken" &&
                        symbol.Type.ContainingNamespace?.ToDisplayString() == "System.Threading")
                    {
                        return param.Identifier.Text;
                    }
                }
            }

            return null;
        }

        private static async Task<Document> PropagateCancellationTokenAsync(
            Document document,
            ObjectCreationExpressionSyntax objectCreation,
            string tokenParamName,
            CancellationToken cancellationToken)
        {
            SyntaxNode root = await document.GetSyntaxRootAsync(cancellationToken).ConfigureAwait(false);

            ExpressionSyntax tokenExpression = SyntaxFactory.IdentifierName(tokenParamName);

            AssignmentExpressionSyntax ctAssignment = SyntaxFactory.AssignmentExpression(
                SyntaxKind.SimpleAssignmentExpression,
                SyntaxFactory.IdentifierName("CancellationToken"),
                tokenExpression);

            if (objectCreation.Initializer != null)
            {
                // Check if CancellationToken is already in the initializer (set to wrong value like None/default)
                InitializerExpressionSyntax initializer = objectCreation.Initializer;
                for (int i = 0; i < initializer.Expressions.Count; i++)
                {
                    if (initializer.Expressions[i] is AssignmentExpressionSyntax assignment &&
                        assignment.Left is IdentifierNameSyntax id &&
                        id.Identifier.Text == "CancellationToken")
                    {
                        // Replace the value
                        AssignmentExpressionSyntax newAssignment = assignment.WithRight(
                            tokenExpression.WithTriviaFrom(assignment.Right));
                        InitializerExpressionSyntax newInitializer = initializer.WithExpressions(
                            initializer.Expressions.Replace(initializer.Expressions[i], newAssignment));
                        ObjectCreationExpressionSyntax newCreation = objectCreation.WithInitializer(newInitializer);
                        return document.WithSyntaxRoot(root.ReplaceNode(objectCreation, newCreation));
                    }
                }

                // CancellationToken not in initializer — add it
                SeparatedSyntaxList<ExpressionSyntax> newExpressions = initializer.Expressions.Add(ctAssignment);
                InitializerExpressionSyntax updatedInitializer = initializer.WithExpressions(newExpressions);
                ObjectCreationExpressionSyntax updatedCreation = objectCreation.WithInitializer(updatedInitializer);
                return document.WithSyntaxRoot(root.ReplaceNode(objectCreation, updatedCreation));
            }
            else
            {
                // No initializer — create one and remove the argument list (empty parens)
                InitializerExpressionSyntax newInitializer = SyntaxFactory.InitializerExpression(
                    SyntaxKind.ObjectInitializerExpression,
                    SyntaxFactory.SingletonSeparatedList<ExpressionSyntax>(ctAssignment))
                    .WithLeadingTrivia(SyntaxFactory.Space);

                ObjectCreationExpressionSyntax newCreation = objectCreation
                    .WithArgumentList(null)
                    .WithInitializer(newInitializer);

                return document.WithSyntaxRoot(root.ReplaceNode(objectCreation, newCreation));
            }
        }
    }
}
