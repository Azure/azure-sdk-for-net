// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager;

// Backward-compat: type alias for renamed resource type (ApiCompat TypesMustExist)
// Old name: ContainerGroupProfileCollection, New name: CGProfileCollection

namespace Azure.ResourceManager.ContainerInstance
{
    /// <summary> Backward compatibility alias for <see cref="CGProfileCollection"/>. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class ContainerGroupProfileCollection : CGProfileCollection,
        IEnumerable<ContainerGroupProfileResource>,
        IAsyncEnumerable<ContainerGroupProfileResource>
    {
        /// <summary> Initializes a new instance for mocking. </summary>
        protected ContainerGroupProfileCollection()
        {
        }

        /// <summary> Initializes a new instance for backward compatibility. </summary>
        internal ContainerGroupProfileCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
        }

        /// <summary> Creates or updates a container group profile. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual ArmOperation<ContainerGroupProfileResource> CreateOrUpdate(WaitUntil waitUntil, string containerGroupProfileName, ContainerGroupProfileData data, CancellationToken cancellationToken = default)
        {
            ArmOperation<CGProfileResource> operation = base.CreateOrUpdate(waitUntil, containerGroupProfileName, data, cancellationToken);
            return new ProfileArmOperationWrapper(operation, Client);
        }

        /// <summary> Creates or updates a container group profile. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual async Task<ArmOperation<ContainerGroupProfileResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string containerGroupProfileName, ContainerGroupProfileData data, CancellationToken cancellationToken = default)
        {
            ArmOperation<CGProfileResource> operation = await base.CreateOrUpdateAsync(waitUntil, containerGroupProfileName, data, cancellationToken).ConfigureAwait(false);
            return new ProfileArmOperationWrapper(operation, Client);
        }

        /// <summary> Gets the specified container group profile. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual Response<ContainerGroupProfileResource> Get(string containerGroupProfileName, CancellationToken cancellationToken = default)
        {
            Response<CGProfileResource> response = base.Get(containerGroupProfileName, cancellationToken);
            return Response.FromValue(new ContainerGroupProfileResource(Client, response.Value.Data), response.GetRawResponse());
        }

        /// <summary> Gets the specified container group profile. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual async Task<Response<ContainerGroupProfileResource>> GetAsync(string containerGroupProfileName, CancellationToken cancellationToken = default)
        {
            Response<CGProfileResource> response = await base.GetAsync(containerGroupProfileName, cancellationToken).ConfigureAwait(false);
            return Response.FromValue(new ContainerGroupProfileResource(Client, response.Value.Data), response.GetRawResponse());
        }

        /// <summary> Gets all container group profiles. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual Pageable<ContainerGroupProfileResource> GetAll(CancellationToken cancellationToken = default)
        {
            return new WrappedProfilePageable(base.GetAll(cancellationToken), Client);
        }

        /// <summary> Gets all container group profiles. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual AsyncPageable<ContainerGroupProfileResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return new WrappedProfileAsyncPageable(base.GetAllAsync(cancellationToken), Client);
        }

        /// <summary> Tries to get the resource if it exists. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual NullableResponse<ContainerGroupProfileResource> GetIfExists(string containerGroupProfileName, CancellationToken cancellationToken = default)
        {
            NullableResponse<CGProfileResource> response = base.GetIfExists(containerGroupProfileName, cancellationToken);
            return new WrappedProfileNullableResponse(response, Client);
        }

        /// <summary> Tries to get the resource if it exists. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public new virtual async Task<NullableResponse<ContainerGroupProfileResource>> GetIfExistsAsync(string containerGroupProfileName, CancellationToken cancellationToken = default)
        {
            NullableResponse<CGProfileResource> response = await base.GetIfExistsAsync(containerGroupProfileName, cancellationToken).ConfigureAwait(false);
            return new WrappedProfileNullableResponse(response, Client);
        }

        IEnumerator<ContainerGroupProfileResource> IEnumerable<ContainerGroupProfileResource>.GetEnumerator()
        {
            foreach (CGProfileResource item in (IEnumerable<CGProfileResource>)this)
            {
                yield return new ContainerGroupProfileResource(Client, item.Data);
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => ((IEnumerable<ContainerGroupProfileResource>)this).GetEnumerator();

        async IAsyncEnumerator<ContainerGroupProfileResource> IAsyncEnumerable<ContainerGroupProfileResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            await foreach (CGProfileResource item in ((IAsyncEnumerable<CGProfileResource>)this).WithCancellation(cancellationToken).ConfigureAwait(false))
            {
                yield return new ContainerGroupProfileResource(Client, item.Data);
            }
        }

        #region Helper wrapper types

        private sealed class ProfileArmOperationWrapper : ArmOperation<ContainerGroupProfileResource>
        {
            private readonly ArmOperation<CGProfileResource> _inner;
            private readonly ArmClient _client;

            public ProfileArmOperationWrapper(ArmOperation<CGProfileResource> inner, ArmClient client)
            {
                _inner = inner;
                _client = client;
            }

            public override string Id => _inner.Id;
            public override ContainerGroupProfileResource Value => new ContainerGroupProfileResource(_client, _inner.Value.Data);
            public override bool HasValue => _inner.HasValue;
            public override bool HasCompleted => _inner.HasCompleted;
            public override Response GetRawResponse() => _inner.GetRawResponse();
            public override Response UpdateStatus(CancellationToken cancellationToken = default) => _inner.UpdateStatus(cancellationToken);
            public override ValueTask<Response> UpdateStatusAsync(CancellationToken cancellationToken = default) => _inner.UpdateStatusAsync(cancellationToken);
        }

        private sealed class WrappedProfilePageable : Pageable<ContainerGroupProfileResource>
        {
            private readonly Pageable<CGProfileResource> _inner;
            private readonly ArmClient _client;

            public WrappedProfilePageable(Pageable<CGProfileResource> inner, ArmClient client)
            {
                _inner = inner;
                _client = client;
            }

            public override IEnumerable<Page<ContainerGroupProfileResource>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                foreach (Page<CGProfileResource> page in _inner.AsPages(continuationToken, pageSizeHint))
                {
                    var values = page.Values.Select(v => new ContainerGroupProfileResource(_client, v.Data)).ToList();
                    yield return Page<ContainerGroupProfileResource>.FromValues(values, page.ContinuationToken, page.GetRawResponse());
                }
            }
        }

        private sealed class WrappedProfileAsyncPageable : AsyncPageable<ContainerGroupProfileResource>
        {
            private readonly AsyncPageable<CGProfileResource> _inner;
            private readonly ArmClient _client;

            public WrappedProfileAsyncPageable(AsyncPageable<CGProfileResource> inner, ArmClient client)
            {
                _inner = inner;
                _client = client;
            }

#pragma warning disable CS8424
            public override async IAsyncEnumerable<Page<ContainerGroupProfileResource>> AsPages(string continuationToken = null, int? pageSizeHint = null)
#pragma warning restore CS8424
            {
                await foreach (Page<CGProfileResource> page in _inner.AsPages(continuationToken, pageSizeHint).ConfigureAwait(false))
                {
                    var values = page.Values.Select(v => new ContainerGroupProfileResource(_client, v.Data)).ToList();
                    yield return Page<ContainerGroupProfileResource>.FromValues(values, page.ContinuationToken, page.GetRawResponse());
                }
            }
        }

        private sealed class WrappedProfileNullableResponse : NullableResponse<ContainerGroupProfileResource>
        {
            private readonly NullableResponse<CGProfileResource> _inner;
            private readonly ArmClient _client;

            public WrappedProfileNullableResponse(NullableResponse<CGProfileResource> inner, ArmClient client)
            {
                _inner = inner;
                _client = client;
            }

            public override bool HasValue => _inner.HasValue;

            public override ContainerGroupProfileResource Value =>
                _inner.HasValue
                    ? new ContainerGroupProfileResource(_client, _inner.Value.Data)
                    : throw new InvalidOperationException("Response does not contain a value.");

            public override Response GetRawResponse() => _inner.GetRawResponse();
        }

        #endregion
    }
}
