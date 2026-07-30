// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Immutable;
using System.Globalization;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Text;

namespace Azure.SdkAnalyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public sealed class CodeAnalysisSuppressionAnalyzer : DiagnosticAnalyzer
    {
        private const string SkipListMarker =
            "build_metadata.AdditionalFiles.AzureSdkCodeAnalysisSuppressionSkipValidation";
        private const string ProjectNameProperty = "build_property.MSBuildProjectName";

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
            context.RegisterCompilationStartAction(compilationContext =>
            {
                if (ShouldSkipProject(compilationContext.Options, compilationContext.CancellationToken))
                {
                    // Roslyn requires every compilation-start branch to register an action.
                    // Keep skipped projects free of syntax analysis while satisfying that contract.
                    compilationContext.RegisterCompilationEndAction(_ => { });
                    return;
                }

                compilationContext.RegisterSyntaxNodeAction(AnalyzePragma, SyntaxKind.PragmaWarningDirectiveTrivia);
                compilationContext.RegisterSyntaxNodeAction(AnalyzeAttribute, SyntaxKind.Attribute);
            });
        }

        internal static bool ShouldSkipProject(AnalyzerOptions options, CancellationToken cancellationToken)
        {
            if (!options.AnalyzerConfigOptionsProvider.GlobalOptions.TryGetValue(
                ProjectNameProperty,
                out string projectName))
            {
                return false;
            }

            AdditionalText skipList = null;
            foreach (AdditionalText file in options.AdditionalFiles)
            {
                if (!options.AnalyzerConfigOptionsProvider.GetOptions(file).TryGetValue(
                    SkipListMarker,
                    out string marker) ||
                    !string.Equals(marker, "true", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                // Multiple marked files make the authoritative backlog ambiguous. Fail closed.
                if (skipList != null)
                {
                    return false;
                }

                skipList = file;
            }

            SourceText text = skipList?.GetText(cancellationToken);
            if (text == null)
            {
                return false;
            }

            foreach (TextLine line in text.Lines)
            {
                string entry = line.ToString().Trim();
                if (entry.Length != 0 &&
                    !entry.StartsWith("#", StringComparison.Ordinal) &&
                    string.Equals(entry, projectName, StringComparison.Ordinal))
                {
                    return true;
                }
            }

            return false;
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
            IMethodSymbol constructor =
                context.SemanticModel.GetSymbolInfo(attribute, context.CancellationToken).Symbol as IMethodSymbol;
            if (constructor == null ||
                !s_suppressionAttributeNames.Contains(constructor.ContainingType.ToDisplayString()))
            {
                return;
            }

            AttributeArgumentSyntax checkIdArgument = GetCheckIdArgument(attribute, constructor);
            if (checkIdArgument == null)
            {
                return;
            }

            Optional<object> constant =
                context.SemanticModel.GetConstantValue(checkIdArgument.Expression, context.CancellationToken);
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

            for (int i = 0; i < attribute.ArgumentList.Arguments.Count; i++)
            {
                AttributeArgumentSyntax argument = attribute.ArgumentList.Arguments[i];
                if (argument.NameEquals != null)
                {
                    continue;
                }

                string parameterName = argument.NameColon?.Name.Identifier.ValueText;
                if (parameterName == null && i < constructor.Parameters.Length)
                {
                    parameterName = constructor.Parameters[i].Name;
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
