// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure;

namespace Azure.Containers.Apps.Sandbox
{
    internal sealed class ResourceAsyncPageable<TModel, TResource> : AsyncPageable<TResource>
        where TModel : class
        where TResource : class
    {
        private readonly AsyncPageable<TModel> _source;
        private readonly Func<TModel, TResource> _createResource;

        internal ResourceAsyncPageable(AsyncPageable<TModel> source, Func<TModel, TResource> createResource)
        {
            _source = source;
            _createResource = createResource;
        }

        public override async IAsyncEnumerable<Page<TResource>> AsPages(string continuationToken = default, int? pageSizeHint = default)
        {
            await foreach (Page<TModel> page in _source.AsPages(continuationToken, pageSizeHint).ConfigureAwait(false))
            {
                List<TResource> resources = new List<TResource>();
                foreach (TModel model in page.Values)
                {
                    resources.Add(_createResource(model));
                }

                yield return Page<TResource>.FromValues(resources, page.ContinuationToken, page.GetRawResponse());
            }
        }
    }
}
