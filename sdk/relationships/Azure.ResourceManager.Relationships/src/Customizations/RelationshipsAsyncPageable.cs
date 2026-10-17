// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Relationships
{
    // Remove this adapter after regenerating with the fixes for:
    // https://github.com/Azure/azure-sdk-for-net/issues/63507 (relative continuation tokens).
    // https://github.com/Azure/azure-sdk-for-net/issues/63508 (enumeration cancellation).
    internal sealed class RelationshipsAsyncPageable<T> : AsyncPageable<T> where T : notnull
    {
        private readonly Func<CancellationToken, AsyncPageable<T>> _sourceFactory;
        private readonly Uri _endpoint;

        internal RelationshipsAsyncPageable(Func<CancellationToken, AsyncPageable<T>> sourceFactory, Uri endpoint, CancellationToken cancellationToken)
            : base(cancellationToken)
        {
            _sourceFactory = sourceFactory;
            _endpoint = endpoint;
        }

        public override IAsyncEnumerable<Page<T>> AsPages(string continuationToken = default, int? pageSizeHint = default) =>
            EnumeratePagesAsync(continuationToken, pageSizeHint, CancellationToken);

        private async IAsyncEnumerable<Page<T>> EnumeratePagesAsync(
            string continuationToken,
            int? pageSizeHint,
            [EnumeratorCancellation] CancellationToken cancellationToken = default)
        {
            // The compiler combines the method and enumeration tokens. Construct a fresh source
            // with that effective token: forwarding WithCancellation alone would still be ignored
            // by the generated iterator and resource wrapper. Each enumeration owns its context.
            AsyncPageable<T> source = _sourceFactory(cancellationToken);
            await foreach (Page<T> page in source.AsPages(RelationshipsPaging.NormalizeContinuationToken(continuationToken, _endpoint), pageSizeHint)
                .WithCancellation(cancellationToken).ConfigureAwait(false))
            {
                yield return page;
            }
        }
    }
}
