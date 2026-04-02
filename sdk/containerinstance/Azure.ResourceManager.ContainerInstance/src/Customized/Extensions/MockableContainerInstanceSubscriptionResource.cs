// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using Azure;
using Azure.Core;
using Azure.ResourceManager.ContainerInstance.Models;

namespace Azure.ResourceManager.ContainerInstance.Mocking
{
    /// <summary> Backward-compat shim methods for MockableContainerInstanceSubscriptionResource. </summary>
    public partial class MockableContainerInstanceSubscriptionResource
    {
        /// <summary> Gets container group profiles in a subscription. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ContainerGroupProfileResource> GetContainerGroupProfiles(System.Threading.CancellationToken cancellationToken = default)
        {
            return new WrappedProfilePageable(GetCGProfiles(cancellationToken), Client);
        }

        /// <summary> Gets container group profiles in a subscription. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ContainerGroupProfileResource> GetContainerGroupProfilesAsync(System.Threading.CancellationToken cancellationToken = default)
        {
            return new WrappedProfileAsyncPageable(GetCGProfilesAsync(cancellationToken), Client);
        }

        /// <summary> Get the list of cached images. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<CachedImages> GetCachedImagesWithLocation(AzureLocation location, System.Threading.CancellationToken cancellationToken = default)
        {
            return GetCachedImages(location, cancellationToken);
        }

        /// <summary> Get the list of cached images. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<CachedImages> GetCachedImagesWithLocationAsync(AzureLocation location, System.Threading.CancellationToken cancellationToken = default)
        {
            return GetCachedImagesAsync(location, cancellationToken);
        }

        /// <summary> Get the list of capabilities. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ContainerCapabilities> GetCapabilitiesWithLocation(AzureLocation location, System.Threading.CancellationToken cancellationToken = default)
        {
            return GetCapabilities(location, cancellationToken);
        }

        /// <summary> Get the list of capabilities. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ContainerCapabilities> GetCapabilitiesWithLocationAsync(AzureLocation location, System.Threading.CancellationToken cancellationToken = default)
        {
            return GetCapabilitiesAsync(location, cancellationToken);
        }

        /// <summary> Get usage. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<ContainerInstanceUsage> GetUsagesWithLocation(AzureLocation location, System.Threading.CancellationToken cancellationToken = default)
        {
            return GetUsage(location, cancellationToken);
        }

        /// <summary> Get usage. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<ContainerInstanceUsage> GetUsagesWithLocationAsync(AzureLocation location, System.Threading.CancellationToken cancellationToken = default)
        {
            return GetUsageAsync(location, cancellationToken);
        }

        #region Helper wrapper types

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
#pragma warning disable AZC0100
                await foreach (Page<CGProfileResource> page in _inner.AsPages(continuationToken, pageSizeHint))
#pragma warning restore AZC0100
                {
                    var values = page.Values.Select(v => new ContainerGroupProfileResource(_client, v.Data)).ToList();
                    yield return Page<ContainerGroupProfileResource>.FromValues(values, page.ContinuationToken, page.GetRawResponse());
                }
            }
        }

        #endregion
    }
}
