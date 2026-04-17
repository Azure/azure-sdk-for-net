// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;

namespace Azure.SdkAnalyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class SuppressionPolicyAnalyzer : DiagnosticAnalyzer
    {
        internal const string AllowListFileName = "SuppressionAllowList.txt";

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } =
            ImmutableArray.Create(Descriptors.AZC0021);

        public override void Initialize(AnalysisContext context)
        {
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
            context.EnableConcurrentExecution();

            context.RegisterCompilationStartAction(compilationStartContext =>
            {
                var allowList = LoadAllowList(compilationStartContext.Options.AdditionalFiles);

                // If no controlled rules exist, nothing to enforce
                if (allowList.Count == 0)
                {
                    return;
                }

                string assemblyName = compilationStartContext.Compilation.AssemblyName ?? string.Empty;

                var suppressMessageType = compilationStartContext.Compilation.GetTypeByMetadataName(
                    "System.Diagnostics.CodeAnalysis.SuppressMessageAttribute");

                compilationStartContext.RegisterSyntaxNodeAction(
                    nodeContext => AnalyzePragma(nodeContext, allowList, assemblyName),
                    SyntaxKind.PragmaWarningDirectiveTrivia);

                compilationStartContext.RegisterSyntaxNodeAction(
                    nodeContext => AnalyzeAttribute(nodeContext, allowList, assemblyName, suppressMessageType),
                    SyntaxKind.Attribute);
            });
        }

        private static void AnalyzePragma(
            SyntaxNodeAnalysisContext context,
            Dictionary<string, List<string>> allowList,
            string assemblyName)
        {
            var pragma = (PragmaWarningDirectiveTriviaSyntax)context.Node;

            // Only flag #pragma warning disable, not restore
            if (!pragma.DisableOrRestoreKeyword.IsKind(SyntaxKind.DisableKeyword))
            {
                return;
            }

            // Blanket #pragma warning disable (no error codes) — flag it if any controlled rules exist
            if (pragma.ErrorCodes.Count == 0)
            {
                context.ReportDiagnostic(Diagnostic.Create(
                    Descriptors.AZC0021,
                    pragma.GetLocation(),
                    "(blanket suppression)",
                    assemblyName));
                return;
            }

            foreach (var errorCode in pragma.ErrorCodes)
            {
                string ruleId = errorCode.ToString().Trim();

                if (!IsControlledRule(ruleId, allowList))
                {
                    continue;
                }

                if (!IsPackageAllowed(ruleId, assemblyName, allowList))
                {
                    context.ReportDiagnostic(Diagnostic.Create(
                        Descriptors.AZC0021,
                        errorCode.GetLocation(),
                        ruleId,
                        assemblyName));
                }
            }
        }

        private static void AnalyzeAttribute(
            SyntaxNodeAnalysisContext context,
            Dictionary<string, List<string>> allowList,
            string assemblyName,
            INamedTypeSymbol suppressMessageType)
        {
            if (suppressMessageType == null)
            {
                return;
            }

            var attributeSyntax = (AttributeSyntax)context.Node;

            // Resolve the attribute type semantically
            var symbolInfo = context.SemanticModel.GetSymbolInfo(attributeSyntax, context.CancellationToken);
            var attributeConstructor = symbolInfo.Symbol as IMethodSymbol;
            if (attributeConstructor == null)
            {
                return;
            }

            if (!SymbolEqualityComparer.Default.Equals(attributeConstructor.ContainingType, suppressMessageType))
            {
                return;
            }

            // SuppressMessage has constructor: SuppressMessage(string category, string checkId)
            // The second argument is the checkId, which may be in format "RuleId:Description"
            string ruleId = ExtractRuleIdFromAttribute(attributeSyntax, context.SemanticModel);
            if (string.IsNullOrEmpty(ruleId))
            {
                return;
            }

            if (!IsControlledRule(ruleId, allowList))
            {
                return;
            }

            if (!IsPackageAllowed(ruleId, assemblyName, allowList))
            {
                context.ReportDiagnostic(Diagnostic.Create(
                    Descriptors.AZC0021,
                    attributeSyntax.GetLocation(),
                    ruleId,
                    assemblyName));
            }
        }

        private static string ExtractRuleIdFromAttribute(AttributeSyntax attribute, SemanticModel semanticModel)
        {
            if (attribute.ArgumentList == null || attribute.ArgumentList.Arguments.Count < 2)
            {
                return null;
            }

            // The second positional argument is the checkId
            var checkIdArg = attribute.ArgumentList.Arguments[1];

            var constantValue = semanticModel.GetConstantValue(checkIdArg.Expression);
            if (!constantValue.HasValue || !(constantValue.Value is string checkId))
            {
                return null;
            }

            // checkId may be "AZC0004:Some description" — extract just the rule ID
            int colonIndex = checkId.IndexOf(':');
            if (colonIndex >= 0)
            {
                return checkId.Substring(0, colonIndex).Trim();
            }

            return checkId.Trim();
        }

        internal static Dictionary<string, List<string>> LoadAllowList(ImmutableArray<AdditionalText> additionalFiles)
        {
            var allowList = new Dictionary<string, List<string>>(StringComparer.OrdinalIgnoreCase);

            var allowListFile = additionalFiles.FirstOrDefault(f =>
                f.Path.EndsWith(AllowListFileName, StringComparison.OrdinalIgnoreCase));

            if (allowListFile == null)
            {
                return allowList;
            }

            var text = allowListFile.GetText();
            if (text == null)
            {
                return allowList;
            }

            foreach (var line in text.Lines)
            {
                string entry = line.ToString().Trim();

                // Skip empty lines and comments
                if (string.IsNullOrEmpty(entry) || entry.StartsWith("#"))
                {
                    continue;
                }

                int separatorIndex = entry.IndexOf(':');
                if (separatorIndex <= 0 || separatorIndex >= entry.Length - 1)
                {
                    continue;
                }

                string ruleId = entry.Substring(0, separatorIndex).Trim();
                string packagePattern = entry.Substring(separatorIndex + 1).Trim();

                if (string.IsNullOrEmpty(ruleId) || string.IsNullOrEmpty(packagePattern))
                {
                    continue;
                }

                if (!allowList.TryGetValue(ruleId, out var patterns))
                {
                    patterns = new List<string>();
                    allowList[ruleId] = patterns;
                }

                patterns.Add(packagePattern);
            }

            return allowList;
        }

        private static bool IsControlledRule(string ruleId, Dictionary<string, List<string>> allowList)
        {
            return allowList.ContainsKey(ruleId);
        }

        private static bool IsPackageAllowed(string ruleId, string packageName, Dictionary<string, List<string>> allowList)
        {
            if (!allowList.TryGetValue(ruleId, out var patterns))
            {
                return false;
            }

            foreach (var pattern in patterns)
            {
                if (MatchesGlob(packageName, pattern))
                {
                    return true;
                }
            }

            return false;
        }

        internal static bool MatchesGlob(string value, string pattern)
        {
            if (string.IsNullOrEmpty(pattern))
            {
                return false;
            }

            // Exact match (case-insensitive)
            if (string.Equals(value, pattern, StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            // Trailing wildcard: "Azure.ResourceManager.*"
            if (pattern.EndsWith("*"))
            {
                string prefix = pattern.Substring(0, pattern.Length - 1);
                return value.StartsWith(prefix, StringComparison.OrdinalIgnoreCase);
            }

            return false;
        }
    }
}
