// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using Azure;

namespace Azure.ResourceManager.DataFactory
{
    // Generic single-page Pageable<T> used to convert MPG-emitted paged operations back to the
    // upstream Pageable<T> back-compat surface.
    //
    // Spec/generator context: several DataFactory list operations are marked as paged in swagger via
    // x-ms-pageable (e.g. Factories.queryByPipelineRun -> GetActivityRun, Triggers.queryByFactory ->
    // GetTriggers, IntegrationRuntimes.listOutboundNetworkDependenciesEndpoints, etc.) but the
    // TypeSpec models do not carry that marker. As a result the MPG generator emits a single
    // non-paged Response<Wrapper> call rather than a true Pageable<TItem>. The pre-MPG AutoRest SDK
    // returned Pageable<TItem>/AsyncPageable<TItem>, so consumers iterate with `foreach`. This helper
    // wraps the single-response value (already materialized into an IReadOnlyList<TItem>) into a
    // one-page Pageable<TItem>, allowing the resource-level customizations to expose the original
    // signature without modifying the wire format.
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
