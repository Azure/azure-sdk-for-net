// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager.PolicyInsights.Models;

namespace Azure.ResourceManager.PolicyInsights.Mocking
{
    // Small helpers used by the SummarizePolicyStates back-compat shims to wrap
    // a single-call Response<SummarizeResults> envelope as a
    // Pageable<PolicySummary> / AsyncPageable<PolicySummary> (matching the GA
    // method shape that autorest produced for these summarize operations).
    internal static class CompatHelpers
    {
        public static Pageable<PolicySummary> AsPageable(Func<CancellationToken, Response<SummarizeResults>> fetch, CancellationToken cancellationToken)
        {
            return new SinglePagePageable(() => fetch(cancellationToken));
        }

        public static AsyncPageable<PolicySummary> AsAsyncPageableAsync(Func<CancellationToken, Task<Response<SummarizeResults>>> fetchAsync, CancellationToken cancellationToken)
        {
            return new SinglePageAsyncPageable(ct => fetchAsync(ct), cancellationToken);
        }

        private sealed class SinglePagePageable : Pageable<PolicySummary>
        {
            private readonly Func<Response<SummarizeResults>> _fetch;

            public SinglePagePageable(Func<Response<SummarizeResults>> fetch)
            {
                _fetch = fetch;
            }

            public override IEnumerable<Page<PolicySummary>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                Response<SummarizeResults> response = _fetch();
                IReadOnlyList<PolicySummary> values = (response.Value?.Value as IReadOnlyList<PolicySummary>) ?? Array.Empty<PolicySummary>();
                yield return Page<PolicySummary>.FromValues(values, null, response.GetRawResponse());
            }
        }

        private sealed class SinglePageAsyncPageable : AsyncPageable<PolicySummary>
        {
            private readonly Func<CancellationToken, Task<Response<SummarizeResults>>> _fetchAsync;
            private readonly CancellationToken _cancellationToken;

            public SinglePageAsyncPageable(Func<CancellationToken, Task<Response<SummarizeResults>>> fetchAsync, CancellationToken cancellationToken)
            {
                _fetchAsync = fetchAsync;
                _cancellationToken = cancellationToken;
            }

            public override async IAsyncEnumerable<Page<PolicySummary>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                Response<SummarizeResults> response = await _fetchAsync(_cancellationToken).ConfigureAwait(false);
                IReadOnlyList<PolicySummary> values = (response.Value?.Value as IReadOnlyList<PolicySummary>) ?? Array.Empty<PolicySummary>();
                yield return Page<PolicySummary>.FromValues(values, null, response.GetRawResponse());
            }
        }
    }
}
