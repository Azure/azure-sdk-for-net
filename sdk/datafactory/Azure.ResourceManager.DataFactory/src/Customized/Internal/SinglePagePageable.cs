// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;

namespace Azure.ResourceManager.DataFactory
{
    // Generic single-page Pageable<T> that restores the pre-MPG (AutoRest) Pageable<T>/AsyncPageable<T>
    // back-compat surface for DataFactory operations the MPG generator emits as a single Response<Wrapper>.
    //
    // Why custom code instead of a spec decorator: the affected operations are POST "query" actions
    // (Factories.queryByFactory -> GetPipelineRuns, queryByPipelineRun -> GetActivityRun,
    // triggersQueryByFactory / triggerRunsQueryByFactory, listOutboundNetworkDependenciesEndpoints, ...).
    // In swagger they were x-ms-pageable with nextLinkName:null -- a single page with no continuation token.
    // The TypeSpec @list / @@markAsPageable decorators only model GET list operations that carry
    // @nextLink/@items, so they cannot reproduce a no-continuation POST query; and the GA surface exposes
    // these under hand-curated method names (GetActivityRun, GetPipelineRuns, GetTriggers, ...) that need a
    // resource-level customization regardless. This wrapper materializes the single response value (already
    // an IReadOnlyList<TItem>) into a one-page Pageable<TItem> so those customizations keep the original
    // signature without touching the wire format.
    internal sealed class SinglePagePageable<T> : Pageable<T>
    {
        private readonly Response _rawResponse;
        private readonly IReadOnlyList<T> _values;

        public SinglePagePageable(IReadOnlyList<T> values, Response rawResponse)
        {
            _values = values ?? new List<T>();
            _rawResponse = rawResponse;
        }

        public override IEnumerable<Page<T>> AsPages(string continuationToken = null, int? pageSizeHint = null)
        {
            yield return Page<T>.FromValues(_values, null, _rawResponse);
        }
    }
}
