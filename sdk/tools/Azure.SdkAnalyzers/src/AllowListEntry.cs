// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.SdkAnalyzers
{
    /// <summary>
    /// A parsed entry from a per-package allow-list file (<c>eng/analyzerallowlist/&lt;Project&gt;.txt</c>).
    /// See <c>eng/analyzerallowlist/README.md</c> for the file format.
    /// </summary>
    internal sealed class AllowListEntry
    {
        public AllowListEntry(string code, string target, int lineNumber)
        {
            Code = code ?? throw new ArgumentNullException(nameof(code));
            Target = target;
            LineNumber = lineNumber;
        }

        public string Code { get; }

        /// <summary>DocId of the target symbol, or <c>null</c> for a whole-assembly entry.</summary>
        public string Target { get; }

        public int LineNumber { get; }

        public bool IsScoped => Target != null;
    }
}
