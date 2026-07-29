// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Immutable;
using System.Globalization;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Azure.SdkAnalyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public sealed class CodeAnalysisSuppressionAnalyzer : DiagnosticAnalyzer
    {
        private static readonly ImmutableHashSet<string> s_suppressionAttributeNames =
            ImmutableHashSet.Create(
                StringComparer.Ordinal,
                "System.Diagnostics.CodeAnalysis.SuppressMessageAttribute",
                "System.Diagnostics.CodeAnalysis.UnconditionalSuppressMessageAttribute");

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } =
            ImmutableArray.Create(Descriptors.AZC0041);

        public override void Initialize(AnalysisContext context)
        {
            context.EnableConcurrentExecution();
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
            context.RegisterSyntaxNodeAction(AnalyzePragma, SyntaxKind.PragmaWarningDirectiveTrivia);
            context.RegisterSyntaxNodeAction(AnalyzeAttribute, SyntaxKind.Attribute);
        }

        private static void AnalyzePragma(SyntaxNodeAnalysisContext context)
        {
            var pragma = (PragmaWarningDirectiveTriviaSyntax)context.Node;
            if (!pragma.DisableOrRestoreKeyword.IsKind(SyntaxKind.DisableKeyword))
            {
                return;
            }

            if (pragma.ErrorCodes.Count == 0)
            {
                context.ReportDiagnostic(Diagnostic.Create(Descriptors.AZC0041, pragma.GetLocation(), "all warnings"));
                return;
            }

            foreach (ExpressionSyntax errorCode in pragma.ErrorCodes)
            {
                string diagnosticId = NormalizePragmaDiagnosticId(errorCode);
                if (AllowListDiagnosticSuppressor.SupportedDiagnosticIds.Contains(diagnosticId))
                {
                    context.ReportDiagnostic(Diagnostic.Create(Descriptors.AZC0041, errorCode.GetLocation(), diagnosticId));
                }
            }
        }

        private static void AnalyzeAttribute(SyntaxNodeAnalysisContext context)
        {
            var attribute = (AttributeSyntax)context.Node;
            SymbolInfo symbolInfo = context.SemanticModel.GetSymbolInfo(attribute, context.CancellationToken);
            IMethodSymbol constructor = symbolInfo.Symbol as IMethodSymbol;
            if (constructor == null && !symbolInfo.CandidateSymbols.IsDefaultOrEmpty)
            {
                constructor = symbolInfo.CandidateSymbols[0] as IMethodSymbol;
            }

            if (constructor == null || !s_suppressionAttributeNames.Contains(constructor.ContainingType.ToDisplayString()))
            {
                return;
            }

            AttributeArgumentSyntax checkIdArgument = GetCheckIdArgument(attribute, constructor);
            if (checkIdArgument == null)
            {
                return;
            }

            Optional<object> constant = context.SemanticModel.GetConstantValue(checkIdArgument.Expression, context.CancellationToken);
            if (!constant.HasValue || !(constant.Value is string checkId))
            {
                return;
            }

            string diagnosticId = checkId.Split(':')[0].Trim();
            if (AllowListDiagnosticSuppressor.SupportedDiagnosticIds.Contains(diagnosticId))
            {
                context.ReportDiagnostic(Diagnostic.Create(Descriptors.AZC0041, checkIdArgument.Expression.GetLocation(), diagnosticId));
            }
        }

        private static AttributeArgumentSyntax GetCheckIdArgument(AttributeSyntax attribute, IMethodSymbol constructor)
        {
            if (attribute.ArgumentList == null)
            {
                return null;
            }

            int positionalIndex = 0;
            foreach (AttributeArgumentSyntax argument in attribute.ArgumentList.Arguments)
            {
                if (argument.NameEquals != null)
                {
                    continue;
                }

                string parameterName;
                if (argument.NameColon != null)
                {
                    parameterName = argument.NameColon.Name.Identifier.ValueText;
                }
                else
                {
                    parameterName = positionalIndex < constructor.Parameters.Length
                        ? constructor.Parameters[positionalIndex].Name
                        : null;
                    positionalIndex++;
                }

                if (string.Equals(parameterName, "checkId", StringComparison.Ordinal))
                {
                    return argument;
                }
            }

            return null;
        }

        private static string NormalizePragmaDiagnosticId(ExpressionSyntax errorCode)
        {
            if (errorCode is IdentifierNameSyntax identifier)
            {
                return identifier.Identifier.ValueText;
            }

            if (errorCode is LiteralExpressionSyntax literal && literal.Token.Value is int compilerWarningNumber)
            {
                return "CS" + compilerWarningNumber.ToString("0000", CultureInfo.InvariantCulture);
            }

            return errorCode.ToString().Trim();
        }
    }
}
