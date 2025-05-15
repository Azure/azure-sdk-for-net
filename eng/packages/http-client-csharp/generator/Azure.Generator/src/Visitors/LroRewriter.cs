// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Linq;
using System.Linq.Expressions;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.TypeSpec.Generator;

namespace Azure.Generator.Visitors
{
    internal class LroRewriter : CSharpSyntaxRewriter
    {
        // public override SyntaxNode? VisitInvocationExpression(InvocationExpressionSyntax node)
        // {
        //     if (node.Expression is not MemberAccessExpressionSyntax { Name.Identifier.Text: "ProcessMessage" } &&
        //         node.Expression is not MemberAccessExpressionSyntax { Name.Identifier.Text: "ProcessMessageAsync" })
        //     {
        //         // if the invocation is not ProcessMessage or ProcessMessageAsync, just return the original node
        //         return base.VisitInvocationExpression(node);
        //     }
        //
        //     // if (SemanticModel!.GetEnclosingSymbol(node.SpanStart) is IMethodSymbol methodSymbol
        //     //     && methodSymbol.Parameters.Any(p =>
        //     //         p.Type.Name == "WaitUntil"
        //     //         && p.Type.ContainingNamespace.ToDisplayString() == "Azure"))
        //     // {
        //     //     var syntaxRef = methodSymbol.DeclaringSyntaxReferences.FirstOrDefault();
        //     //     if (syntaxRef == null)
        //     //     {
        //     //         return base.VisitInvocationExpression(node);
        //     //     }
        //     //
        //     //     if (syntaxRef.GetSyntax() is not MethodDeclarationSyntax methodDecl)
        //     //     {
        //     //         return base.VisitInvocationExpression(node);
        //     //     }
        //     //
        //     //     bool isAsync = methodDecl.Modifiers
        //     //         .Any(m => m.IsKind(SyntaxKind.AsyncKeyword));
        //     //
        //     //     var createScope = methodDecl.DescendantNodes()
        //     //         .OfType<InvocationExpressionSyntax>()
        //     //         .FirstOrDefault(inv =>
        //     //         {
        //     //             if (inv.Expression is MemberAccessExpressionSyntax ma
        //     //                 && ma.Name.Identifier.Text == "CreateScope")
        //     //             {
        //     //                 var sym = SemanticModel.GetSymbolInfo(ma.Expression).Symbol;
        //     //                 return sym?.Name == "ClientDiagnostics";
        //     //             }
        //     //
        //     //             return false;
        //     //         });
        //     //     string? scopeLiteralText = null;
        //     //     var literal = createScope?.ArgumentList.Arguments
        //     //         .FirstOrDefault()
        //     //         ?.Expression as LiteralExpressionSyntax;
        //     //     if (literal != null && literal.IsKind(SyntaxKind.StringLiteralExpression))
        //     //     {
        //     //         scopeLiteralText = literal.Token.Text;
        //     //     }
        //     //
        //     //     var newInvoke = SyntaxFactory.InvocationExpression(
        //     //         SyntaxFactory.MemberAccessExpression(
        //     //             SyntaxKind.SimpleMemberAccessExpression,
        //     //             SyntaxFactory.IdentifierName("ProtocolOperationHelpers"),
        //     //             isAsync ? SyntaxFactory.IdentifierName("ProcessMessageAsync") : SyntaxFactory.IdentifierName("ProcessMessage")
        //     //         ),
        //     //         SyntaxFactory.ArgumentList().AddArguments(
        //     //                 SyntaxFactory.Argument(SyntaxFactory.IdentifierName("Pipeline")),
        //     //                 SyntaxFactory.Argument(SyntaxFactory.IdentifierName("message")),
        //     //                 SyntaxFactory.Argument(SyntaxFactory.IdentifierName("ClientDiagnostics")),
        //     //                 SyntaxFactory.Argument(SyntaxFactory.ParseExpression(scopeLiteralText!)),
        //     //                 SyntaxFactory.Argument(
        //     //                     SyntaxFactory.MemberAccessExpression(
        //     //                         SyntaxKind.SimpleMemberAccessExpression,
        //     //                         SyntaxFactory.IdentifierName("OperationFinalStateVia"),
        //     //                         SyntaxFactory.IdentifierName("OriginalUri"))),
        //     //                 SyntaxFactory.Argument(SyntaxFactory.IdentifierName("context")),
        //     //                 SyntaxFactory.Argument(SyntaxFactory.IdentifierName("waitUntil"))
        //     //         )
        //     //     );
        //     //
        //     //     return newInvoke;
        //     // }
        //     //
        //     // // if we don't have a waitUntil parameter, just return the original node
        //     // return base.VisitInvocationExpression(node);
        // }

        // public override SyntaxNode? VisitLocalDeclarationStatement(LocalDeclarationStatementSyntax node)
        // {
        //     // First let the base rewrite any child nodes (so your invocation gets replaced):
        //     var rewritten = (LocalDeclarationStatementSyntax)base.VisitLocalDeclarationStatement(node)!;
        //
        //     // Only consider single-variable declarations; skip everything else:
        //     if (rewritten.Declaration.Variables.Count != 1)
        //         return rewritten;
        //
        //     var variable = rewritten.Declaration.Variables[0];
        //     var init = variable.Initializer?.Value as InvocationExpressionSyntax;
        //     if (init is null)
        //         return rewritten;
        //
        //     // Check if this is one of the invocations you care about:
        //     // var symbol = SemanticModel.GetSymbolInfo(init).Symbol as IMethodSymbol;
        //     // if (symbol == null ||
        //     //     symbol.ContainingType.Name != "ProtocolOperationHelpers")
        //     // {
        //     //     return rewritten;
        //     // }
        //
        //     // Figure out the *semantic* return type of that invocation:
        //     var returnType = SemanticModel.GetTypeInfo(init).ConvertedType;
        //     if (returnType == null)
        //         return rewritten;
        //
        //     // Convert the return type back into syntax:
        //     var newTypeSyntax = SyntaxFactory.ParseTypeName(returnType.ToDisplayString())
        //         .WithTriviaFrom(rewritten.Declaration.Type);
        //
        //     // Replace the old type (often "var") with the explicit type:
        //     var newDeclaration = rewritten.Declaration.WithType(newTypeSyntax);
        //     return rewritten.WithDeclaration(newDeclaration);
        // }
    }
}