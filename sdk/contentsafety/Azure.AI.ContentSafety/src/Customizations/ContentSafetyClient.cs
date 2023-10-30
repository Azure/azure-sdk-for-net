// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;

namespace Azure.AI.ContentSafety
{
    public partial class ContentSafetyClient
    {
        /// <summary> Analyze Text. </summary>
        public virtual async Task<Response<AnalyzeTextResult>> AnalyzeTextAsync(string text, CancellationToken cancellationToken = default)
        {
            return await AnalyzeTextAsync(new AnalyzeTextOptions(text), cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Analyze Text. </summary>
        public virtual Response<AnalyzeTextResult> AnalyzeText(string text, CancellationToken cancellationToken = default)
        {
            return AnalyzeText(new AnalyzeTextOptions(text), cancellationToken);
        }
    }
}
