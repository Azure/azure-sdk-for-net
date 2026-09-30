// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;

namespace Azure.ResourceManager.Relationships
{
    // Remove this adapter after regenerating with the fix for:
    // https://github.com/Azure/azure-sdk-for-net/issues/63507 (relative continuation tokens).
    internal sealed class RelationshipsPageable<T> : Pageable<T> where T : notnull
    {
        private readonly Pageable<T> _source;
        private readonly Uri _endpoint;

        internal RelationshipsPageable(Pageable<T> source, Uri endpoint)
        {
            _source = source;
            _endpoint = endpoint;
        }

        public override IEnumerable<Page<T>> AsPages(string continuationToken = default, int? pageSizeHint = default) =>
            _source.AsPages(RelationshipsPaging.NormalizeContinuationToken(continuationToken, _endpoint), pageSizeHint);
    }
}
