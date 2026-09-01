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
        // Only files marked by AnalyzerAllowList.targets can act as the migration backlog.
        private const string SkipListMarker =
            "build_metadata.AdditionalFiles.AzureSdkCodeAnalysisSuppressionSkipValidation";

        private const string ShippingLibraryProperty = "build_property.IsShippingClientLibrary";
        private const string ProjectNameProperty = "build_property.MSBuildProjectName";
        private const string SuppressMessageAttributeName =
            "System.Diagnostics.CodeAnalysis.SuppressMessageAttribute";
        private const string UnconditionalSuppressMessageAttributeName =
            "System.Diagnostics.CodeAnalysis.UnconditionalSuppressMessageAttribute";
        internal const string BarePragmaMessage =
            "A bare #pragma warning disable is not allowed. Remove it, rebuild to identify the hidden warnings, and fix or centrally approve each specific diagnostic.";
        internal const string TrimOrAotSuppressionMessage =
            "Trim and AOT suppressions must use [UnconditionalSuppressMessage] so they are preserved in the shipped assembly for customer publish.";

        private static readonly ImmutableHashSet<string> s_suppressionAttributeNames =
            ImmutableHashSet.Create(
                StringComparer.Ordinal,
                SuppressMessageAttributeName,
                UnconditionalSuppressMessageAttributeName);

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
                    compilationContext.RegisterCompilationEndAction(_ => { });
                    return;
                }

                compilationContext.RegisterSyntaxNodeAction(AnalyzePragma, SyntaxKind.PragmaWarningDirectiveTrivia);
                compilationContext.RegisterSyntaxNodeAction(AnalyzeAttribute, SyntaxKind.Attribute);
            });
        }

        internal static bool ShouldSkipProject(AnalyzerOptions options, CancellationToken cancellationToken)
        {
            // Projects outside shipping-library scope skip AZC0041.
            if (!options.AnalyzerConfigOptionsProvider.GlobalOptions.TryGetValue(
                ShippingLibraryProperty,
                out string isShippingClientLibrary) ||
                !string.Equals(isShippingClientLibrary, "true", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            // Find the marked migration backlog.
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

                // Multiple marked files are ambiguous, so fail closed.
                if (skipList != null)
                {
                    return false;
                }

                skipList = file;
            }

            // A missing backlog means migration is complete, so enforce AZC0041.
            if (skipList == null)
            {
                return false;
            }

            // Missing project identity or unreadable content fails closed.
            if (!options.AnalyzerConfigOptionsProvider.GlobalOptions.TryGetValue(
                ProjectNameProperty,
                out string projectName))
            {
                return false;
            }

            SourceText text = skipList.GetText(cancellationToken);
            if (text == null)
            {
                return false;
            }

            foreach (TextLine line in text.Lines)
            {
                string entry = line.ToString().Trim();
                if (entry.Length == 0 || entry.StartsWith("#", StringComparison.Ordinal))
                {
                    continue;
                }

                if (string.Equals(entry, projectName, StringComparison.Ordinal))
                {
                    // Backlogged projects skip AZC0041.
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
                context.ReportDiagnostic(Diagnostic.Create(Descriptors.AZC0041, pragma.GetLocation(), BarePragmaMessage));
                return;
            }

            // Governance is independent of scoped-suppression support.
            foreach (ExpressionSyntax errorCode in pragma.ErrorCodes)
            {
                string diagnosticId = NormalizePragmaDiagnosticId(errorCode);
                ReportSuppression(context, errorCode.GetLocation(), diagnosticId);
            }
        }

        private static void AnalyzeAttribute(SyntaxNodeAnalysisContext context)
        {
            var attribute = (AttributeSyntax)context.Node;

            // Semantic resolution handles aliases, qualified names, and assembly attributes.
            IMethodSymbol constructor =
                context.SemanticModel.GetSymbolInfo(attribute, context.CancellationToken).Symbol as IMethodSymbol;
            if (constructor == null)
            {
                return;
            }

            string attributeName = constructor.ContainingType.ToDisplayString();
            if (!s_suppressionAttributeNames.Contains(attributeName))
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

            // Suppression attributes permit values such as "AZC0015:Unexpected return type".
            string diagnosticId = checkId.Split(':')[0].Trim();
            if (diagnosticId.Length == 0)
            {
                return;
            }

            // Trim and AOT tools read these suppressions from the shipped assembly.
            if (string.Equals(attributeName, UnconditionalSuppressMessageAttributeName, StringComparison.Ordinal) &&
                IsTrimOrAotDiagnosticId(diagnosticId))
            {
                return;
            }

            ReportSuppression(context, checkIdArgument.Expression.GetLocation(), diagnosticId);
        }

        private static void ReportSuppression(SyntaxNodeAnalysisContext context, Location location, string diagnosticId)
        {
            string message = IsTrimOrAotDiagnosticId(diagnosticId)
                ? TrimOrAotSuppressionMessage
                : $"Suppression for diagnostic '{diagnosticId}' must be declared in eng/analyzerallowlist";

            context.ReportDiagnostic(Diagnostic.Create(
                Descriptors.AZC0041,
                location,
                message));
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
                    // `name = value` assigns an attribute property, not a constructor parameter.
                    continue;
                }

                string parameterName = argument.NameColon?.Name.Identifier.ValueText;
                if (parameterName == null && i < constructor.Parameters.Length)
                {
                    // Positional arguments bind to constructor parameters by index.
                    parameterName = constructor.Parameters[i].Name;
                }

                if (string.Equals(parameterName, "checkId", StringComparison.Ordinal))
                {
                    return argument;
                }
            }

            return null;
        }

        // Normalize numeric compiler warnings to CS#### and preserve other source forms.
        private static string NormalizePragmaDiagnosticId(ExpressionSyntax errorCode)
        {
            if (errorCode is IdentifierNameSyntax identifier)
            {
                // ValueText resolves escaped identifiers such as `AZC\u0030007` to `AZC0007`.
                return identifier.Identifier.ValueText;
            }

            if (errorCode is LiteralExpressionSyntax literal && literal.Token.Value is int compilerWarningNumber)
            {
                // Both `618` and `0618` represent compiler warning `CS0618`.
                return "CS" + compilerWarningNumber.ToString("0000", CultureInfo.InvariantCulture);
            }

            return errorCode.ToString().Trim();
        }

        private static bool IsTrimOrAotDiagnosticId(string diagnosticId)
        {
            return diagnosticId.Length == 6 &&
                diagnosticId.StartsWith("IL", StringComparison.OrdinalIgnoreCase) &&
                (diagnosticId[2] == '2' || diagnosticId[2] == '3') &&
                char.IsDigit(diagnosticId[3]) &&
                char.IsDigit(diagnosticId[4]) &&
                char.IsDigit(diagnosticId[5]);
        }
    }
}
