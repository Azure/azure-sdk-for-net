// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure;

namespace Azure.Containers.Apps.Sandbox
{
    internal sealed class ResourcePageable<TModel, TResource> : Pageable<TResource>
        where TModel : class
        where TResource : class
    {
        private readonly Pageable<TModel> _source;
        private readonly Func<TModel, TResource> _createResource;

        internal ResourcePageable(Pageable<TModel> source, Func<TModel, TResource> createResource)
        {
            _source = source;
            _createResource = createResource;
        }

        public override IEnumerable<Page<TResource>> AsPages(string continuationToken = default, int? pageSizeHint = default)
        {
            foreach (Page<TModel> page in _source.AsPages(continuationToken, pageSizeHint))
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
