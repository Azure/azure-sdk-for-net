// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Simplification;

namespace Microsoft.CodeSimplifier
{
    // From Roslyn FAQ: https://github.com/dotnet/roslyn/blob/56f605c41915317ccdb925f66974ee52282609e7/src/Samples/CSharp/APISampleUnitTests/FAQ.cs
    public class SimplifyNamesAnnotionRewriter : CSharpSyntaxRewriter
    {
        private SyntaxNode AnnotateNodeWithSimplifyAnnotation(SyntaxNode node)
        {
            return node.WithAdditionalAnnotations(Simplifier.Annotation);
        }

        public override SyntaxNode VisitAliasQualifiedName(AliasQualifiedNameSyntax node)
        {
            // not descending into node to simplify the whole expression
            return AnnotateNodeWithSimplifyAnnotation(node);
        }

        public override SyntaxNode VisitQualifiedName(QualifiedNameSyntax node)
        {
            // not descending into node to simplify the whole expression
            return AnnotateNodeWithSimplifyAnnotation(node);
        }

        public override SyntaxNode VisitMemberAccessExpression(MemberAccessExpressionSyntax node)
        {
            // not descending into node to simplify the whole expression
            return AnnotateNodeWithSimplifyAnnotation(node);
        }

        public override SyntaxNode VisitIdentifierName(IdentifierNameSyntax node)
        {
            // not descending into node to simplify the whole expression
            return AnnotateNodeWithSimplifyAnnotation(node);
        }

        public override SyntaxNode VisitGenericName(GenericNameSyntax node)
        {
            // not descending into node to simplify the whole expression
            return AnnotateNodeWithSimplifyAnnotation(node);
        }
    }
}
