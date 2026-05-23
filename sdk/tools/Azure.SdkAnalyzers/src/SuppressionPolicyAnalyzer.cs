// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.IO;
using System.Linq;
using System.Threading;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.CodeAnalysis.Diagnostics;
using Microsoft.CodeAnalysis.Text;

namespace Azure.SdkAnalyzers
{
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public class SuppressionPolicyAnalyzer : DiagnosticAnalyzer
    {
        // Cache to avoid re-parsing on every IDE keystroke.
        // Roslyn reuses the same SourceText instance when the file hasn't changed.
        private static SourceText s_cachedSourceText;
        private static AllowList s_cachedAllowList;

        public override ImmutableArray<DiagnosticDescriptor> SupportedDiagnostics { get; } =
            ImmutableArray.Create(Descriptors.AZC0021);

        public override void Initialize(AnalysisContext context)
        {
            context.ConfigureGeneratedCodeAnalysis(GeneratedCodeAnalysisFlags.None);
            context.EnableConcurrentExecution();

            context.RegisterCompilationStartAction(compilationStartContext =>
            {
                var allowList = LoadAllowList(compilationStartContext.Options.AdditionalFiles);

                // If no controlled codes exist, nothing to enforce
                if (allowList == null || allowList.IsEmpty)
                {
                    return;
                }

                var suppressMessageType = compilationStartContext.Compilation.GetTypeByMetadataName(
                    "System.Diagnostics.CodeAnalysis.SuppressMessageAttribute");

                compilationStartContext.RegisterSyntaxNodeAction(
                    nodeContext => AnalyzePragma(nodeContext, allowList),
                    SyntaxKind.PragmaWarningDirectiveTrivia);

                compilationStartContext.RegisterSyntaxNodeAction(
                    nodeContext => AnalyzeAttribute(nodeContext, allowList, suppressMessageType),
                    SyntaxKind.Attribute);
            });
        }

        private static void AnalyzePragma(
            SyntaxNodeAnalysisContext context,
            AllowList allowList)
        {
            var pragma = (PragmaWarningDirectiveTriviaSyntax)context.Node;

            // Only flag #pragma warning disable, not restore
            if (!pragma.DisableOrRestoreKeyword.IsKind(SyntaxKind.DisableKeyword))
            {
                return;
            }

            // Blanket #pragma warning disable (no error codes) — flag it if any controlled codes exist
            if (pragma.ErrorCodes.Count == 0)
            {
                context.ReportDiagnostic(Diagnostic.Create(
                    Descriptors.AZC0021,
                    pragma.GetLocation(),
                    "(blanket suppression)",
                    string.Empty));
                return;
            }

            foreach (var errorCode in pragma.ErrorCodes)
            {
                string code = errorCode.ToString().Trim();

                if (!allowList.IsControlledCode(code))
                {
                    continue;
                }

                var symbol = GetEnclosingSymbol(context.SemanticModel, pragma.SpanStart, context.CancellationToken);
                string key = BuildLookupKey(code, symbol);

                if (!allowList.Contains(key))
                {
                    context.ReportDiagnostic(Diagnostic.Create(
                        Descriptors.AZC0021,
                        errorCode.GetLocation(),
                        code,
                        symbol?.ToDisplayString() ?? string.Empty));
                }
            }
        }

        private static void AnalyzeAttribute(
            SyntaxNodeAnalysisContext context,
            AllowList allowList,
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
            string code = ExtractRuleIdFromAttribute(attributeSyntax, context.SemanticModel);
            if (string.IsNullOrEmpty(code))
            {
                return;
            }

            if (!allowList.IsControlledCode(code))
            {
                return;
            }

            // Get the symbol the attribute is applied to
            var targetSymbol = GetAttributeTargetSymbol(context.SemanticModel, attributeSyntax, context.CancellationToken);
            string key = BuildLookupKey(code, targetSymbol);

            if (!allowList.Contains(key))
            {
                context.ReportDiagnostic(Diagnostic.Create(
                    Descriptors.AZC0021,
                    attributeSyntax.GetLocation(),
                    code,
                    targetSymbol?.ToDisplayString() ?? string.Empty));
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

        /// <summary>
        /// Build the lookup key for allow-list matching: CODE:DOCID (with parameters stripped).
        /// </summary>
        internal static string BuildLookupKey(string code, ISymbol symbol)
        {
            if (symbol == null)
            {
                return code + ":";
            }

            string docId = symbol.GetDocumentationCommentId();
            if (string.IsNullOrEmpty(docId))
            {
                return code + ":";
            }

            string strippedDocId = StripParameters(docId);
            return code + ":" + strippedDocId;
        }

        /// <summary>
        /// Strip method parameter lists from documentation comment IDs.
        /// M:Namespace.Type.Method(System.Int32) → M:Namespace.Type.Method
        /// </summary>
        internal static string StripParameters(string docId)
        {
            int parenIndex = docId.IndexOf('(');
            if (parenIndex > 0)
            {
                return docId.Substring(0, parenIndex);
            }
            return docId;
        }

        /// <summary>
        /// Find the enclosing symbol for a pragma directive.
        /// Pragmas are trivia — walk up from the position to find the nearest member/type declaration.
        /// </summary>
        internal static ISymbol GetEnclosingSymbol(SemanticModel semanticModel, int position, CancellationToken cancellationToken)
        {
            var root = semanticModel.SyntaxTree.GetRoot(cancellationToken);
            var token = root.FindToken(position);
            var node = token.Parent;

            while (node != null)
            {
                if (node is MemberDeclarationSyntax memberDecl && !(node is NamespaceDeclarationSyntax))
                {
                    var symbol = semanticModel.GetDeclaredSymbol(memberDecl, cancellationToken);
                    if (symbol != null)
                    {
                        return symbol;
                    }
                }

                if (node is BaseTypeDeclarationSyntax typeDecl)
                {
                    return semanticModel.GetDeclaredSymbol(typeDecl, cancellationToken);
                }

                node = node.Parent;
            }

            // File-level pragma — try to get the containing namespace or type
            // from the first declaration after the pragma
            var firstDecl = root.DescendantNodes().OfType<BaseNamespaceDeclarationSyntax>().FirstOrDefault();
            if (firstDecl != null)
            {
                return semanticModel.GetDeclaredSymbol(firstDecl, cancellationToken);
            }

            return null;
        }

        /// <summary>
        /// Get the symbol that a [SuppressMessage] attribute is applied to.
        /// </summary>
        private static ISymbol GetAttributeTargetSymbol(SemanticModel semanticModel, AttributeSyntax attribute, CancellationToken cancellationToken)
        {
            // Walk up to the attribute list, then to the declaration it's attached to
            var parent = attribute.Parent; // AttributeListSyntax
            if (parent?.Parent is MemberDeclarationSyntax memberDecl)
            {
                return semanticModel.GetDeclaredSymbol(memberDecl, cancellationToken);
            }

            if (parent?.Parent is BaseTypeDeclarationSyntax typeDecl)
            {
                return semanticModel.GetDeclaredSymbol(typeDecl, cancellationToken);
            }

            // Assembly-level attribute: [assembly: SuppressMessage(...)]
            if (parent is AttributeListSyntax attrList && attrList.Target?.Identifier.IsKind(SyntaxKind.AssemblyKeyword) == true)
            {
                return semanticModel.Compilation.Assembly;
            }

            // Fallback: try the grandparent as a generic declaration
            if (parent?.Parent != null)
            {
                return semanticModel.GetDeclaredSymbol(parent.Parent, cancellationToken);
            }

            return null;
        }

        internal static AllowList LoadAllowList(ImmutableArray<AdditionalText> additionalFiles)
        {
            var allowListFile = additionalFiles.FirstOrDefault(f =>
            {
                string dir = Path.GetDirectoryName(f.Path);
                return dir != null && dir.EndsWith("analyzerallowlist", StringComparison.OrdinalIgnoreCase);
            });

            if (allowListFile == null)
            {
                return null;
            }

            var sourceText = allowListFile.GetText();
            if (sourceText == null)
            {
                return null;
            }

            // Cache: avoid re-parsing when SourceText hasn't changed
            var cached = Volatile.Read(ref s_cachedSourceText);
            if (ReferenceEquals(sourceText, cached))
            {
                return Volatile.Read(ref s_cachedAllowList);
            }

            var entries = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
            var controlledCodes = new HashSet<string>(StringComparer.OrdinalIgnoreCase);

            foreach (var line in sourceText.Lines)
            {
                string entry = line.ToString().Trim();

                // Skip empty lines, comments, and nowarn: entries (consumed by MSBuild only)
                if (string.IsNullOrEmpty(entry) || entry[0] == '#')
                {
                    continue;
                }

                if (entry.StartsWith("nowarn:", StringComparison.OrdinalIgnoreCase))
                {
                    continue;
                }

                // Expected format: CODE:PREFIX:FullyQualifiedName (e.g., AZC0002:M:Namespace.Type.Method)
                int colonIndex = entry.IndexOf(':');
                if (colonIndex <= 0 || colonIndex >= entry.Length - 1)
                {
                    continue;
                }

                string code = entry.Substring(0, colonIndex);
                controlledCodes.Add(code);
                entries.Add(entry);
            }

            var result = new AllowList(entries, controlledCodes);

            // Update cache (benign race is acceptable)
            Volatile.Write(ref s_cachedAllowList, result);
            Volatile.Write(ref s_cachedSourceText, sourceText);

            return result;
        }

        /// <summary>
        /// Parsed allow-list with fast O(1) lookups for both controlled codes and specific entries.
        /// </summary>
        internal sealed class AllowList
        {
            private readonly HashSet<string> _entries;
            private readonly HashSet<string> _controlledCodes;

            public AllowList(HashSet<string> entries, HashSet<string> controlledCodes)
            {
                _entries = entries;
                _controlledCodes = controlledCodes;
            }

            public bool IsEmpty => _controlledCodes.Count == 0;

            /// <summary>
            /// Check if a diagnostic code appears in any allow-list entry.
            /// Fast path: codes not in the list are skipped entirely.
            /// </summary>
            public bool IsControlledCode(string code) => _controlledCodes.Contains(code);

            /// <summary>
            /// Check if a specific CODE:SYMBOL entry is in the allow-list.
            /// </summary>
            public bool Contains(string key) => _entries.Contains(key);
        }
    }
}
