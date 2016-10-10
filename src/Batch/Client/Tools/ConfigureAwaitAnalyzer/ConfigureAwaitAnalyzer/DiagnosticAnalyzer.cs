// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

namespace ConfigureAwaitAnalyzer
{
    using System;
    using System.Collections.Immutable;
    using System.Linq;
    using Microsoft.CodeAnalysis;
    using Microsoft.CodeAnalysis.CSharp;
    using Microsoft.CodeAnalysis.CSharp.Syntax;
    using Microsoft.CodeAnalysis.Diagnostics;

    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class ConfigureAwaitAnalyzer : DiagnosticAnalyzer
    {
        public const string DiagnosticId = "ConfigureAwaitAnalyzer";

        internal const string Title = "ConfigureAwaitFalseChecker";
        internal const string MessageFormat = "'await' expressions must include ConfigureAwait(false)";
        internal const string Description = "Ensures that all await expressions include ConfigureAwait(false)";
        private const string Category = "Usage";

        private static readonly DiagnosticDescriptor Rule = new DiagnosticDescriptor(
            DiagnosticId,
            Title,
            MessageFormat,
            Category,
            DiagnosticSeverity.Warning,
            isEnabledByDefault: true,
            description: Description);

        private const string ConfigureAwait = "ConfigureAwait";

        public struct AnalysisResult
        {
            public bool HasConfigureAwaitFalse { get; }
            public Location Location { get; }

            public AnalysisResult(bool hasConfigureAwaitFalse, Location location)
            {
                this.HasConfigureAwaitFalse = hasConfigureAwaitFalse;
                this.Location = location;
            }
        }

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics => ImmutableArray.Create(Rule);

        public override void Initialize(AnalysisContext context)
        {
            context.RegisterSyntaxNodeAction(Analyze, SyntaxKind.AwaitExpression);
        }

        private static void Analyze(SyntaxNodeAnalysisContext context)
        {
            var awaitNode = (AwaitExpressionSyntax)context.Node;
            AnalysisResult analysisResult = HasConfigureAwaitFalse(awaitNode);
            if (!analysisResult.HasConfigureAwaitFalse)
            {
                context.ReportDiagnostic(Diagnostic.Create(Rule, analysisResult.Location));
            }
        }

        private static AnalysisResult HasConfigureAwaitFalse(AwaitExpressionSyntax awaitNode)
        {
            InvocationExpressionSyntax configureAwaitExpression = FindConfigureAwaitExpression(awaitNode);
            bool hasConfigureAwaitFalse = configureAwaitExpression != null && IsExpressionConfigureAwaitFalse(configureAwaitExpression);
            return new AnalysisResult(hasConfigureAwaitFalse, awaitNode.GetLocation());
        }

        private static InvocationExpressionSyntax FindConfigureAwaitExpression(SyntaxNode node)
        {
            foreach (SyntaxNode childNode in node.ChildNodes())
            {
                //Find the first node which is an invocation expression
                if (childNode is InvocationExpressionSyntax)
                {
                    return (InvocationExpressionSyntax)childNode;
                }
                return FindConfigureAwaitExpression(childNode);
            }

            return null;
        }

        /// <summary>
        /// Checks to see if the expression already contains ConfigureAwait(false)
        /// </summary>
        private static bool IsExpressionConfigureAwaitFalse(InvocationExpressionSyntax invocationExpression)
        {
            var memberAccessExpression = invocationExpression.Expression as MemberAccessExpressionSyntax;

            bool isConfigureAwait = memberAccessExpression?.Name.Identifier.Text.Equals(ConfigureAwait, StringComparison.Ordinal) == true;
            bool hasFalseParameter = invocationExpression.ArgumentList.Arguments.Count == 1 &&
                                     invocationExpression.ArgumentList.Arguments.Single().Expression.IsKind(SyntaxKind.FalseLiteralExpression);

            return isConfigureAwait && hasFalseParameter;
        }
    }
}
