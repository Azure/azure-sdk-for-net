// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.SdkAnalyzers
{
    /// <summary>
    /// A single parsed entry from a per-package analyzer allow-list file
    /// (<c>eng/analyzerallowlist/&lt;Project&gt;.txt</c>).
    /// </summary>
    /// <remarks>
    /// File-format reminder:
    /// <code>
    /// nowarn:AZC0102                                       # whole-assembly
    /// nowarn:AZC0034 T:Azure.Foo.Bar                       # per-type
    /// nowarn:AZC0007 M:Azure.Foo.Bar.#ctor(System.String)  # per-member
    /// nowarn:CS0618 N:Azure.Foo.Models                     # namespace + descendants
    /// </code>
    /// The <see cref="Target"/> string is the Roslyn DocumentationCommentId for the
    /// symbol (the part after the optional leading <c>~</c>). When the target is
    /// <c>null</c> the entry is a whole-assembly suppression.
    /// </remarks>
    internal sealed class AllowListEntry
    {
        public AllowListEntry(string code, string target, int lineNumber)
        {
            Code = code ?? throw new ArgumentNullException(nameof(code));
            Target = target;
            LineNumber = lineNumber;
        }

        /// <summary>Diagnostic ID this entry suppresses (e.g., <c>AZC0034</c>, <c>CS0618</c>).</summary>
        public string Code { get; }

        /// <summary>
        /// DocumentationCommentId of the target symbol (e.g., <c>T:Azure.Foo</c>),
        /// or <c>null</c> for whole-assembly suppressions.
        /// </summary>
        public string Target { get; }

        /// <summary>1-based line number in the source allow-list file, for diagnostics.</summary>
        public int LineNumber { get; }

        /// <summary>True if this entry is scoped to a specific symbol (vs. whole-assembly).</summary>
        public bool IsScoped => Target != null;
    }
}
