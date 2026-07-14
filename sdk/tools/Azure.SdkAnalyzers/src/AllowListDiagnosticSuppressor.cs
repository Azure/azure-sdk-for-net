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
using Microsoft.CodeAnalysis.Text;

namespace Azure.SdkAnalyzers
{
    /// <summary>
    /// Honors scoped allow-list entries (<c>nowarn:CODE T:Foo</c> etc.) in
    /// <c>eng/analyzerallowlist/&lt;Project&gt;.txt</c>. Whole-assembly entries are
    /// handled separately by <c>eng/AnalyzerAllowList.targets</c> via
    /// <c>$(NoWarn)</c> injection.
    /// </summary>
    /// <remarks>
    /// <see cref="SupportedDiagnosticIds"/> is fixed at build time; add new IDs to
    /// opt them into scoped suppression.
    /// </remarks>
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public sealed class AllowListDiagnosticSuppressor : DiagnosticSuppressor
    {
        private static readonly string[] SupportedDiagnosticIds = new[]
        {
            "AZC0007",
            "AZC0014",
            "AZC0030",
            "AZC0034",
            "AZC0035",
            "CS0618",
            "AAIP001"
        };

        private const string SuppressionIdPrefix = "AZSDKSP";
        private const string AllowListMetadataKey = "build_metadata.AdditionalFiles.AzureSdkAllowList";

        private static readonly ImmutableArray<SuppressionDescriptor> s_supportedSuppressions =
            BuildSuppressionDescriptors();

        public override ImmutableArray<SuppressionDescriptor> SupportedSuppressions => s_supportedSuppressions;

        public override void ReportSuppressions(SuppressionAnalysisContext context)
        {
            if (context.ReportedDiagnostics.IsDefaultOrEmpty)
            {
                return;
            }

            IReadOnlyList<AllowListEntry> entries = LoadAllowListEntries(context);
            if (entries.Count == 0)
            {
                return;
            }

            Dictionary<string, List<AllowListEntry>> scopedByCode = BuildScopedIndex(entries);
            if (scopedByCode.Count == 0)
            {
                return;
            }

            Dictionary<SuppressionKey, SuppressionDescriptor> descriptorIndex = BuildDescriptorIndex();
            Compilation compilation = context.Compilation;

            foreach (Diagnostic diagnostic in context.ReportedDiagnostics)
            {
                if (!scopedByCode.TryGetValue(diagnostic.Id, out List<AllowListEntry> candidates))
                {
                    continue;
                }

                AllowListEntry match = FindMatchingEntry(candidates, diagnostic, compilation);
                if (match == null)
                {
                    continue;
                }

                if (!descriptorIndex.TryGetValue(new SuppressionKey(diagnostic.Id), out SuppressionDescriptor descriptor))
                {
                    continue;
                }

                context.ReportSuppression(Suppression.Create(descriptor, diagnostic));
            }
        }

        private static IReadOnlyList<AllowListEntry> LoadAllowListEntries(SuppressionAnalysisContext context)
        {
            AdditionalText allowListFile = FindAllowListFile(context);
            if (allowListFile == null)
            {
                return Array.Empty<AllowListEntry>();
            }

            SourceText text = allowListFile.GetText(context.CancellationToken);
            if (text == null)
            {
                return Array.Empty<AllowListEntry>();
            }

            return AllowListParser.Parse(text.ToString());
        }

        private static AdditionalText FindAllowListFile(SuppressionAnalysisContext context)
        {
            foreach (AdditionalText file in context.Options.AdditionalFiles)
            {
                AnalyzerConfigOptions options = context.Options.AnalyzerConfigOptionsProvider.GetOptions(file);
                if (options.TryGetValue(AllowListMetadataKey, out string marker) &&
                    string.Equals(marker, "true", StringComparison.OrdinalIgnoreCase))
                {
                    return file;
                }
            }

            return null;
        }

        private static Dictionary<string, List<AllowListEntry>> BuildScopedIndex(
            IReadOnlyList<AllowListEntry> entries)
        {
            var index = new Dictionary<string, List<AllowListEntry>>(StringComparer.OrdinalIgnoreCase);
            foreach (AllowListEntry entry in entries)
            {
                if (!entry.IsScoped)
                {
                    continue;
                }

                if (!index.TryGetValue(entry.Code, out List<AllowListEntry> bucket))
                {
                    bucket = new List<AllowListEntry>();
                    index[entry.Code] = bucket;
                }

                bucket.Add(entry);
            }

            return index;
        }

        private static AllowListEntry FindMatchingEntry(
            List<AllowListEntry> candidates,
            Diagnostic diagnostic,
            Compilation compilation)
        {
            Location location = diagnostic.Location;
            if (location == null || location.Kind == LocationKind.None)
            {
                return null;
            }

            foreach (AllowListEntry entry in candidates)
            {
                if (TargetMatchesLocation(entry.Target, location, compilation))
                {
                    return entry;
                }
            }

            return null;
        }

        private static bool TargetMatchesLocation(string docId, Location location, Compilation compilation)
        {
            if (string.IsNullOrEmpty(docId) || docId.Length < 3 || docId[1] != ':')
            {
                return false;
            }

            // Namespace targets match the namespace and all descendants.
            if (docId[0] == 'N')
            {
                return NamespaceContainsLocation(docId, location);
            }

            ImmutableArray<ISymbol> symbols = DocumentationCommentId.GetSymbolsForDeclarationId(docId, compilation);
            if (symbols.IsDefaultOrEmpty)
            {
                return false;
            }

            foreach (ISymbol symbol in symbols)
            {
                if (LocationFallsInsideSymbol(location, symbol))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool NamespaceContainsLocation(string docId, Location location)
        {
            string targetNs = docId.Substring(2);
            if (string.IsNullOrEmpty(targetNs))
            {
                return false;
            }

            SyntaxTree tree = location.SourceTree;
            if (tree == null)
            {
                return false;
            }

            SyntaxNode node = tree.GetRoot().FindNode(location.SourceSpan, getInnermostNodeForTie: true);

            // Build the fully-qualified enclosing namespace from outer to inner.
            var enclosing = new Stack<string>();
            for (SyntaxNode current = node; current != null; current = current.Parent)
            {
                string name = TryGetNamespaceName(current);
                if (name != null)
                {
                    enclosing.Push(name);
                }
            }

            if (enclosing.Count == 0)
            {
                return false;
            }

            string fullNs = string.Join(".", enclosing);
            return fullNs.Equals(targetNs, StringComparison.Ordinal) ||
                   fullNs.StartsWith(targetNs + ".", StringComparison.Ordinal);
        }

        private static string TryGetNamespaceName(SyntaxNode node)
        {
            switch (node)
            {
                case NamespaceDeclarationSyntax ns:
                    return ns.Name.ToString();
                case FileScopedNamespaceDeclarationSyntax fsns:
                    return fsns.Name.ToString();
                default:
                    return null;
            }
        }

        private static bool LocationFallsInsideSymbol(Location location, ISymbol symbol)
        {
            SyntaxTree tree = location.SourceTree;
            if (tree == null)
            {
                return false;
            }

            TextSpan span = location.SourceSpan;
            foreach (SyntaxReference reference in symbol.DeclaringSyntaxReferences)
            {
                if (reference.SyntaxTree != tree)
                {
                    continue;
                }

                if (reference.Span.Contains(span))
                {
                    return true;
                }
            }

            return false;
        }

        private static ImmutableArray<SuppressionDescriptor> BuildSuppressionDescriptors()
        {
            var builder = ImmutableArray.CreateBuilder<SuppressionDescriptor>(SupportedDiagnosticIds.Length);
            foreach (string id in SupportedDiagnosticIds)
            {
                builder.Add(new SuppressionDescriptor(
                    id: SuppressionIdPrefix + id,
                    suppressedDiagnosticId: id,
                    justification: "Suppressed by an approved entry in eng/analyzerallowlist/<Project>.txt."));
            }

            return builder.MoveToImmutable();
        }

        private static Dictionary<SuppressionKey, SuppressionDescriptor> BuildDescriptorIndex()
        {
            var index = new Dictionary<SuppressionKey, SuppressionDescriptor>();
            foreach (SuppressionDescriptor descriptor in s_supportedSuppressions)
            {
                index[new SuppressionKey(descriptor.SuppressedDiagnosticId)] = descriptor;
            }

            return index;
        }

        private readonly struct SuppressionKey : IEquatable<SuppressionKey>
        {
            public SuppressionKey(string id) => Id = id;

            public string Id { get; }

            public bool Equals(SuppressionKey other) =>
                string.Equals(Id, other.Id, StringComparison.OrdinalIgnoreCase);

            public override bool Equals(object obj) => obj is SuppressionKey k && Equals(k);

            public override int GetHashCode() =>
                Id == null ? 0 : StringComparer.OrdinalIgnoreCase.GetHashCode(Id);
        }
    }
}
