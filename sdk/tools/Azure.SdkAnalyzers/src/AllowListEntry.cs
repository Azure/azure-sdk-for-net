// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.SdkAnalyzers
{
    /// <summary>The kind of scope a parsed allow-list entry applies to.</summary>
    internal enum AllowListScopeKind
    {
        /// <summary>A bare <c>nowarn:CODE</c> entry — injected into <c>$(NoWarn)</c> by MSBuild, not handled here.</summary>
        WholeAssembly,

        /// <summary>A <c>nowarn:CODE DocId</c> entry — matched at the site of the target symbol.</summary>
        Symbol,

        /// <summary>A <c>nowarn:CODE SourceGenerated</c> entry — matched at any site inside a <c>*.g.cs</c> source-generator file.</summary>
        SourceGenerated,
    }

    /// <summary>
    /// A parsed entry from a per-package allow-list file (<c>eng/analyzerallowlist/&lt;Project&gt;.txt</c>).
    /// See <c>eng/analyzerallowlist/README.md</c> for the file format.
    /// </summary>
    internal sealed class AllowListEntry
    {
        public AllowListEntry(string code, string target, AllowListScopeKind scope, int lineNumber)
        {
            Code = code ?? throw new ArgumentNullException(nameof(code));
            Target = target;
            Scope = scope;
            LineNumber = lineNumber;
        }

        public string Code { get; }

        /// <summary>DocId of the target symbol for <see cref="AllowListScopeKind.Symbol"/> scope; otherwise <c>null</c>.</summary>
        public string Target { get; }

        public AllowListScopeKind Scope { get; }

        public int LineNumber { get; }

        public bool IsScoped => Scope != AllowListScopeKind.WholeAssembly;
    }
}
