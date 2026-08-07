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
        // eng/AnalyzerAllowList.targets adds the central skip list as an AdditionalFile with
        // AzureSdkCodeAnalysisSuppressionSkipValidation="true". Its CompilerVisibleItemMetadata
        // entry exposes that value under this `build_metadata` analyzer-config key. Because
        // ShouldSkipProject ignores files without marker=true, a project-local file with the same
        // name cannot impersonate the central skip list.
        private const string SkipListMarker =
            "build_metadata.AdditionalFiles.AzureSdkCodeAnalysisSuppressionSkipValidation";

        // CompilerVisibleProperty exposes MSBuildProjectName under the `build_property` prefix.
        private const string ProjectNameProperty = "build_property.MSBuildProjectName";
        internal const string BarePragmaMessage =
            "A bare #pragma warning disable is not allowed. Remove it, rebuild to identify the hidden warnings, and fix or centrally approve each specific diagnostic.";

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

            // Check the project-level migration backlog before registering syntax analysis.
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

        // ShouldSkipProject checks if the current project should be skipped based on current skip-list
        // configuration.
        internal static bool ShouldSkipProject(AnalyzerOptions options, CancellationToken cancellationToken)
        {
            // Find the one AdditionalFile whose analyzer configuration contains marker=true.
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

            // Only shipping libraries receive the centrally marked backlog file. Projects that
            // merely load the broader analyzer assembly remain outside AZC0041 policy scope.
            if (skipList == null)
            {
                return true;
            }

            // Once central configuration is present, fail closed if required project identity or
            // file contents are unavailable so a wiring failure cannot silently disable policy.
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
                    // Skip comments and empty lines after trimming.
                    continue;
                }

                if (string.Equals(entry, projectName, StringComparison.Ordinal))
                {
                    // The current project is still awaiting migration, so skip AZC0041 analysis.
                    return true;
                }
            }

            return false;
        }

        // Analyze #pragma warning directives for locally declared suppressions.
        private static void AnalyzePragma(SyntaxNodeAnalysisContext context)
        {
            var pragma = (PragmaWarningDirectiveTriviaSyntax)context.Node;
            if (!pragma.DisableOrRestoreKeyword.IsKind(SyntaxKind.DisableKeyword))
            {
                // Restore directives do not declare a suppression.
                return;
            }

            if (pragma.ErrorCodes.Count == 0)
            {
                // A bare warning-disable pragma suppresses all warnings and is always disallowed.
                context.ReportDiagnostic(Diagnostic.Create(Descriptors.AZC0041, pragma.GetLocation(), BarePragmaMessage));
                return;
            }

            // Every local warning suppression is centrally governed. Report each ID independently
            // without coupling policy to the suppressor's narrower scoped-suppression capability.
            foreach (ExpressionSyntax errorCode in pragma.ErrorCodes)
            {
                string diagnosticId = NormalizePragmaDiagnosticId(errorCode);
                ReportSuppression(context, errorCode.GetLocation(), diagnosticId);
            }
        }

        // Analyze SuppressMessage and UnconditionalSuppressMessage attributes.
        private static void AnalyzeAttribute(SyntaxNodeAnalysisContext context)
        {
            var attribute = (AttributeSyntax)context.Node;

            // Resolve the constructor semantically so aliases, qualified names, and assembly-level
            // attributes are handled consistently.
            IMethodSymbol constructor =
                context.SemanticModel.GetSymbolInfo(attribute, context.CancellationToken).Symbol as IMethodSymbol;
            if (constructor == null ||
                !s_suppressionAttributeNames.Contains(constructor.ContainingType.ToDisplayString()))
            {
                // Ignore attributes that are not recognized suppression attributes.
                return;
            }

            // Find the constructor argument containing the diagnostic ID.
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
            if (diagnosticId.Length != 0)
            {
                ReportSuppression(context, checkIdArgument.Expression.GetLocation(), diagnosticId);
            }
        }

        private static void ReportSuppression(SyntaxNodeAnalysisContext context, Location location, string diagnosticId)
        {
            context.ReportDiagnostic(Diagnostic.Create(
                Descriptors.AZC0041,
                location,
                $"Suppression for diagnostic '{diagnosticId}' must be declared in eng/analyzerallowlist"));
        }

        // Locate checkId when supplied positionally or with the constructor's `name:` syntax.
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

        // Convert pragma error-code syntax into the canonical diagnostic ID used by the governed
        // ID set. Preserve identifier IDs, normalize numeric compiler warnings to `CS####`, and
        // return trimmed source text for any syntax Roslyn does not classify as either form.
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

            // Preserve forward compatibility with other pragma expression shapes.
            return errorCode.ToString().Trim();
        }
    }
}
