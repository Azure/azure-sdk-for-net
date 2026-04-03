// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402 // File may only contain a single type

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Azure.ResourceManager.Hci
{
    /// <summary> Helper for casting Pageable types. </summary>
    internal static class PageableHelpers
    {
        public static Pageable<TDest> CastPageable<TSource, TDest>(Pageable<TSource> source) where TDest : TSource
        {
            throw new System.NotSupportedException("This type is obsolete and should not be used.");
        }

        public static AsyncPageable<TDest> CastAsyncPageable<TSource, TDest>(AsyncPageable<TSource> source) where TDest : TSource
        {
            throw new System.NotSupportedException("This type is obsolete and should not be used.");
        }

        private class CastingPageable<TSource, TDest> : Pageable<TDest> where TDest : TSource
        {
            private readonly Pageable<TSource> _inner;

            public CastingPageable(Pageable<TSource> inner)
            {
                _inner = inner;
            }

            public override IEnumerable<Page<TDest>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                foreach (var page in _inner.AsPages(continuationToken, pageSizeHint))
                {
                    var items = new List<TDest>();
                    foreach (var item in page.Values)
                    {
                        items.Add((TDest)(object)item);
                    }
                    yield return Page<TDest>.FromValues(items, page.ContinuationToken, page.GetRawResponse());
                }
            }
        }

        private class CastingAsyncPageable<TSource, TDest> : AsyncPageable<TDest> where TDest : TSource
        {
            private readonly AsyncPageable<TSource> _inner;

            public CastingAsyncPageable(AsyncPageable<TSource> inner)
            {
                _inner = inner;
            }

#pragma warning disable AZC0100 // ConfigureAwait(false) must be used - IAsyncEnumerable doesn't support it
            public override async IAsyncEnumerable<Page<TDest>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                await foreach (var page in _inner.AsPages(continuationToken, pageSizeHint))
                {
                    var items = new List<TDest>();
                    foreach (var item in page.Values)
                    {
                        items.Add((TDest)(object)item);
                    }
                    yield return Page<TDest>.FromValues(items, page.ContinuationToken, page.GetRawResponse());
                }
            }
#pragma warning restore AZC0100
        }
    }

    /// <summary> Helper wrapper for NullableResponse. </summary>
    internal class NullableResponseWrapper<T> : NullableResponse<T>
    {
        private readonly T _value;
        private readonly Response _response;

        internal NullableResponseWrapper(T value, Response response)
        {
            _value = value;
            _response = response;
        }

        public override bool HasValue => _value != null;
        public override T Value => _value;
        public override Response GetRawResponse() => _response;
    }

    /// <summary> Helper wrapper for ArmOperation. </summary>
    internal class ArmOperationWrapper<TSource, TDest> : Azure.ResourceManager.ArmOperation<TDest> where TDest : TSource
    {
        private readonly Azure.ResourceManager.ArmOperation<TSource> _inner;

        internal ArmOperationWrapper(Azure.ResourceManager.ArmOperation<TSource> inner)
        {
            _inner = inner;
        }

        public override string Id => _inner.Id;
        public override TDest Value => throw new System.NotSupportedException("This type is obsolete and should not be used.");
        public override bool HasValue => _inner.HasValue;
        public override bool HasCompleted => _inner.HasCompleted;
        public override Response GetRawResponse() => _inner.GetRawResponse();
        public override Response UpdateStatus(System.Threading.CancellationToken cancellationToken = default) => _inner.UpdateStatus(cancellationToken);
        public override System.Threading.Tasks.ValueTask<Response> UpdateStatusAsync(System.Threading.CancellationToken cancellationToken = default) => _inner.UpdateStatusAsync(cancellationToken);
    }
}
