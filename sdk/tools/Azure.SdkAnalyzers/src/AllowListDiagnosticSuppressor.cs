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
    /// Programmatic <see cref="DiagnosticSuppressor"/> that honors per-package
    /// allow-list entries from <c>eng/analyzerallowlist/&lt;Project&gt;.txt</c>.
    /// </summary>
    /// <remarks>
    /// <para>
    /// The build pipeline (<c>eng/AnalyzerAllowList.targets</c>) handles whole-assembly
    /// entries (<c>nowarn:CODE</c>) by injecting them into <c>$(NoWarn)</c>. This
    /// suppressor handles the <em>scoped</em> form — entries with a target DocId
    /// (<c>nowarn:CODE T:Foo</c>, <c>nowarn:CODE M:Foo.Bar</c>,
    /// <c>nowarn:CODE N:Foo.Models</c>) — and suppresses matching diagnostics
    /// in-place. The result is the same as adding a per-symbol
    /// <c>[SuppressMessage]</c> attribute, but without touching the project's source.
    /// </para>
    /// <para>
    /// The set of diagnostic IDs this suppressor can scope is fixed at build time
    /// via <see cref="SupportedDiagnosticIds"/>. Roslyn requires
    /// <see cref="SupportedSuppressions"/> to be a stable, non-changing array, so new
    /// codes need to be added here explicitly.
    /// </para>
    /// </remarks>
    [DiagnosticAnalyzer(LanguageNames.CSharp)]
    public sealed class AllowListDiagnosticSuppressor : DiagnosticSuppressor
    {
        /// <summary>
        /// Diagnostic IDs that this suppressor knows how to suppress via scoped
        /// allow-list entries. Add new IDs here as point-suppression replaces
        /// assembly-wide <c>nowarn:</c> entries for them.
        /// </summary>
        private static readonly string[] SupportedDiagnosticIds = new[]
        {
            "AZC0007",
            "AZC0030",
            "AZC0034",
            "AZC0035",
            "CS0618",
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

            // Bucket scoped entries by diagnostic id so we don't re-scan the whole file
            // for each reported diagnostic.
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
                    // Defensive: SupportedSuppressions and SupportedDiagnosticIds should agree;
                    // skip silently if they don't rather than throwing inside an analyzer.
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

            char kind = docId[0];

            // Namespace targets get the "namespace and descendants" treatment — we don't
            // walk source spans, we just check the chain of enclosing symbols at the
            // diagnostic location.
            if (kind == 'N')
            {
                return NamespaceContainsLocation(docId, location, compilation);
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

        private static bool NamespaceContainsLocation(string docId, Location location, Compilation compilation)
        {
            // Strip "N:" prefix to get the target namespace's display name.
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

            SyntaxNode root = tree.GetRoot();
            SyntaxNode node = root.FindNode(location.SourceSpan, getInnermostNodeForTie: true);

            // Walk up from the diagnostic node, accumulating namespace-declaration names.
            // For nested namespaces the names appear inner-first, so we build a stack and
            // then check if any suffix of the joined chain matches the target. This also
            // handles the dotted-form `namespace Foo.Bar { }` since the syntax already
            // exposes the full dotted name as a single declaration.
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

            // Build the fully-qualified enclosing namespace by joining outer-to-inner.
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
