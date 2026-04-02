// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable CS1591

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.ContainerInstance
{
    // Backward-compat stub: ContainerGroupProfileRevisionCollection was removed in TypeSpec migration.
    // Revisions are now accessed through CGProfileCollection.
    /// <summary> A class representing a collection of ContainerGroupProfileRevisionResource and their operations. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerGroupProfileRevisionCollection : ArmCollection,
        IEnumerable<ContainerGroupProfileRevisionResource>,
        IAsyncEnumerable<ContainerGroupProfileRevisionResource>
    {
        private CGProfileCollection _innerCollection;

        /// <summary> Initializes a new instance of <see cref="ContainerGroupProfileRevisionCollection"/> for mocking. </summary>
        protected ContainerGroupProfileRevisionCollection()
        {
        }

        /// <summary> Initializes a new instance of <see cref="ContainerGroupProfileRevisionCollection"/>. </summary>
        internal ContainerGroupProfileRevisionCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _innerCollection = new CGProfileCollection(client, id);
        }

        private CGProfileCollection InnerCollection => _innerCollection ??= new CGProfileCollection(Client, Id);

        /// <summary> Checks to see if the resource exists. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<bool> Exists(string revisionNumber, CancellationToken cancellationToken = default)
        {
            return InnerCollection.Exists(revisionNumber, cancellationToken);
        }

        /// <summary> Checks to see if the resource exists. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<bool>> ExistsAsync(string revisionNumber, CancellationToken cancellationToken = default)
        {
            return await InnerCollection.ExistsAsync(revisionNumber, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets the specified resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<ContainerGroupProfileRevisionResource> Get(string revisionNumber, CancellationToken cancellationToken = default)
        {
            Response<CGProfileResource> response = InnerCollection.Get(revisionNumber, cancellationToken);
            return Response.FromValue(new ContainerGroupProfileRevisionResource(Client, response.Value.Data), response.GetRawResponse());
        }

        /// <summary> Gets the specified resource. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<ContainerGroupProfileRevisionResource>> GetAsync(string revisionNumber, CancellationToken cancellationToken = default)
        {
            Response<CGProfileResource> response = await InnerCollection.GetAsync(revisionNumber, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new ContainerGroupProfileRevisionResource(Client, response.Value.Data), response.GetRawResponse());
        }

        /// <summary> Gets all resources in this collection. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ContainerGroupProfileRevisionResource> GetAll(CancellationToken cancellationToken = default)
        {
            return new WrappedPageable(InnerCollection.GetAll(cancellationToken), Client);
        }

        /// <summary> Gets all resources in this collection. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ContainerGroupProfileRevisionResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return new WrappedAsyncPageable(InnerCollection.GetAllAsync(cancellationToken), Client);
        }

        /// <summary> Tries to get the resource if it exists. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual NullableResponse<ContainerGroupProfileRevisionResource> GetIfExists(string revisionNumber, CancellationToken cancellationToken = default)
        {
            NullableResponse<CGProfileResource> response = InnerCollection.GetIfExists(revisionNumber, cancellationToken);
            if (response.HasValue)
            {
                return new WrappedNullableResponse(response, Client);
            }
            return new WrappedNullableResponse(response, Client);
        }

        /// <summary> Tries to get the resource if it exists. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<NullableResponse<ContainerGroupProfileRevisionResource>> GetIfExistsAsync(string revisionNumber, CancellationToken cancellationToken = default)
        {
            NullableResponse<CGProfileResource> response = await InnerCollection.GetIfExistsAsync(revisionNumber, cancellationToken).ConfigureAwait(false);
            return new WrappedNullableResponse(response, Client);
        }

        IEnumerator<ContainerGroupProfileRevisionResource> IEnumerable<ContainerGroupProfileRevisionResource>.GetEnumerator()
        {
            foreach (CGProfileResource item in InnerCollection)
            {
                yield return new ContainerGroupProfileRevisionResource(Client, item.Data);
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable<ContainerGroupProfileRevisionResource>)this).GetEnumerator();
        }

        async IAsyncEnumerator<ContainerGroupProfileRevisionResource> IAsyncEnumerable<ContainerGroupProfileRevisionResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            await foreach (CGProfileResource item in ((IAsyncEnumerable<CGProfileResource>)InnerCollection).WithCancellation(cancellationToken).ConfigureAwait(false))
            {
                yield return new ContainerGroupProfileRevisionResource(Client, item.Data);
            }
        }

        #region Helper wrapper types

        private sealed class WrappedPageable : Pageable<ContainerGroupProfileRevisionResource>
        {
            private readonly Pageable<CGProfileResource> _inner;
            private readonly ArmClient _client;

            public WrappedPageable(Pageable<CGProfileResource> inner, ArmClient client)
            {
                _inner = inner;
                _client = client;
            }

            public override IEnumerable<Page<ContainerGroupProfileRevisionResource>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                foreach (Page<CGProfileResource> page in _inner.AsPages(continuationToken, pageSizeHint))
                {
                    var values = page.Values.Select(v => new ContainerGroupProfileRevisionResource(_client, v.Data)).ToList();
                    yield return Page<ContainerGroupProfileRevisionResource>.FromValues(values, page.ContinuationToken, page.GetRawResponse());
                }
            }
        }

        private sealed class WrappedAsyncPageable : AsyncPageable<ContainerGroupProfileRevisionResource>
        {
            private readonly AsyncPageable<CGProfileResource> _inner;
            private readonly ArmClient _client;

            public WrappedAsyncPageable(AsyncPageable<CGProfileResource> inner, ArmClient client)
            {
                _inner = inner;
                _client = client;
            }

#pragma warning disable CS8424 // The EnumeratorCancellationAttribute on continuationToken (string) is inherited from base
            public override async IAsyncEnumerable<Page<ContainerGroupProfileRevisionResource>> AsPages(string continuationToken = null, int? pageSizeHint = null)
#pragma warning restore CS8424
            {
                await foreach (Page<CGProfileResource> page in _inner.AsPages(continuationToken, pageSizeHint).ConfigureAwait(false))
                {
                    var values = page.Values.Select(v => new ContainerGroupProfileRevisionResource(_client, v.Data)).ToList();
                    yield return Page<ContainerGroupProfileRevisionResource>.FromValues(values, page.ContinuationToken, page.GetRawResponse());
                }
            }
        }

        private sealed class WrappedNullableResponse : NullableResponse<ContainerGroupProfileRevisionResource>
        {
            private readonly NullableResponse<CGProfileResource> _inner;
            private readonly ArmClient _client;

            public WrappedNullableResponse(NullableResponse<CGProfileResource> inner, ArmClient client)
            {
                _inner = inner;
                _client = client;
            }

            public override bool HasValue => _inner.HasValue;

            public override ContainerGroupProfileRevisionResource Value =>
                _inner.HasValue
                    ? new ContainerGroupProfileRevisionResource(_client, _inner.Value.Data)
                    : throw new InvalidOperationException("Response does not contain a value.");

            public override Response GetRawResponse() => _inner.GetRawResponse();
        }

        #endregion
    }
}
