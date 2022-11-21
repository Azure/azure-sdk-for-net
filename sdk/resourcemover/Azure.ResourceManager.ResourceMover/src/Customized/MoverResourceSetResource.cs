// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.ResourceMover.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.ResourceMover
{
    /// <summary>
    /// A Class representing a MoverResourceSet along with the instance operations that can be performed on it.
    /// If you have a <see cref="ResourceIdentifier" /> you can construct a <see cref="MoverResourceSetResource" />
    /// from an instance of <see cref="ArmClient" /> using the GetMoverResourceSetResource method.
    /// Otherwise you can get one from its parent resource <see cref="ResourceGroupResource" /> using the GetMoverResourceSet method.
    /// </summary>
    public partial class MoverResourceSetResource : ArmResource
    {
        /// <summary>
        /// Add a tag to the current resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Migrate/moveCollections/{moveCollectionName}
        /// Operation Id: MoveCollections_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual async Task<Response<MoverResourceSetResource>> AddTagAsync(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = _moverResourceSetMoveCollectionsClientDiagnostics.CreateScope("MoverResourceSetResource.AddTag");
            scope.Start();
            try
            {
                var current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                var patch = new MoverResourceSetPatch
                {
                    Identity = current.Identity
                };
                foreach (var tag in current.Tags)
                {
                    patch.Tags.Add(tag);
                }
                patch.Tags[key] = value;
                var result = await UpdateAsync(patch, cancellationToken: cancellationToken).ConfigureAwait(false);
                return result;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Add a tag to the current resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Migrate/moveCollections/{moveCollectionName}
        /// Operation Id: MoveCollections_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="value"> The value for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> or <paramref name="value"/> is null. </exception>
        public virtual Response<MoverResourceSetResource> AddTag(string key, string value, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));
            Argument.AssertNotNull(value, nameof(value));

            using var scope = _moverResourceSetMoveCollectionsClientDiagnostics.CreateScope("MoverResourceSetResource.AddTag");
            scope.Start();
            try
            {
                var current = Get(cancellationToken: cancellationToken).Value.Data;
                var patch = new MoverResourceSetPatch
                {
                    Identity = current.Identity
                };
                foreach (var tag in current.Tags)
                {
                    patch.Tags.Add(tag);
                }
                patch.Tags[key] = value;
                var result = Update(patch, cancellationToken: cancellationToken);
                return result;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Migrate/moveCollections/{moveCollectionName}
        /// Operation Id: MoveCollections_Get
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual async Task<Response<MoverResourceSetResource>> SetTagsAsync(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _moverResourceSetMoveCollectionsClientDiagnostics.CreateScope("MoverResourceSetResource.SetTags");
            scope.Start();
            try
            {
                var current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                var patch = new MoverResourceSetPatch
                {
                    Identity = current.Identity
                };
                patch.Tags.ReplaceWith(tags);
                var result = await UpdateAsync(patch, cancellationToken: cancellationToken).ConfigureAwait(false);
                return result;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Replace the tags on the resource with the given set.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Migrate/moveCollections/{moveCollectionName}
        /// Operation Id: MoveCollections_Get
        /// </summary>
        /// <param name="tags"> The set of tags to use as replacement. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="tags"/> is null. </exception>
        public virtual Response<MoverResourceSetResource> SetTags(IDictionary<string, string> tags, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(tags, nameof(tags));

            using var scope = _moverResourceSetMoveCollectionsClientDiagnostics.CreateScope("MoverResourceSetResource.SetTags");
            scope.Start();
            try
            {
                var current = Get(cancellationToken: cancellationToken).Value.Data;
                var patch = new MoverResourceSetPatch
                {
                    Identity = current.Identity
                };
                patch.Tags.ReplaceWith(tags);
                var result = Update(patch, cancellationToken: cancellationToken);
                return result;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Migrate/moveCollections/{moveCollectionName}
        /// Operation Id: MoveCollections_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual async Task<Response<MoverResourceSetResource>> RemoveTagAsync(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _moverResourceSetMoveCollectionsClientDiagnostics.CreateScope("MoverResourceSetResource.RemoveTag");
            scope.Start();
            try
            {
                var current = (await GetAsync(cancellationToken: cancellationToken).ConfigureAwait(false)).Value.Data;
                var patch = new MoverResourceSetPatch
                {
                    Identity = current.Identity
                };
                foreach (var tag in current.Tags)
                {
                    patch.Tags.Add(tag);
                }
                patch.Tags.Remove(key);
                var result = await UpdateAsync(patch, cancellationToken: cancellationToken).ConfigureAwait(false);
                return result;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Removes a tag by key from the resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Migrate/moveCollections/{moveCollectionName}
        /// Operation Id: MoveCollections_Get
        /// </summary>
        /// <param name="key"> The key for the tag. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="key"/> is null. </exception>
        public virtual Response<MoverResourceSetResource> RemoveTag(string key, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(key, nameof(key));

            using var scope = _moverResourceSetMoveCollectionsClientDiagnostics.CreateScope("MoverResourceSetResource.RemoveTag");
            scope.Start();
            try
            {
                var current = Get(cancellationToken: cancellationToken).Value.Data;
                var patch = new MoverResourceSetPatch
                {
                    Identity = current.Identity
                };
                foreach (var tag in current.Tags)
                {
                    patch.Tags.Add(tag);
                }
                patch.Tags.Remove(key);
                var result = Update(patch, cancellationToken: cancellationToken);
                return result;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of unresolved dependencies.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Migrate/moveCollections/{moveCollectionName}/unresolvedDependencies
        /// Operation Id: UnresolvedDependencies_Get
        /// </summary>
        /// <param name="dependencyLevel"> Defines the dependency level. </param>
        /// <param name="orderby"> OData order by query option. For example, you can use $orderby=Count desc. </param>
        /// <param name="filter"> The filter to apply on the operation. For example, $apply=filter(count eq 2). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="MoverUnresolvedDependency" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<MoverUnresolvedDependency> GetUnresolvedDependenciesAsync(MoverDependencyLevel? dependencyLevel = null, string orderby = null, string filter = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<MoverUnresolvedDependency>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _unresolvedDependenciesClientDiagnostics.CreateScope("MoverResourceSetResource.GetUnresolvedDependencies");
                scope.Start();
                try
                {
                    var response = await _unresolvedDependenciesRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, dependencyLevel, orderby, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<MoverUnresolvedDependency>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _unresolvedDependenciesClientDiagnostics.CreateScope("MoverResourceSetResource.GetUnresolvedDependencies");
                scope.Start();
                try
                {
                    var response = await _unresolvedDependenciesRestClient.GetNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, dependencyLevel, orderby, filter, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateAsyncEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Gets a list of unresolved dependencies.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Migrate/moveCollections/{moveCollectionName}/unresolvedDependencies
        /// Operation Id: UnresolvedDependencies_Get
        /// </summary>
        /// <param name="dependencyLevel"> Defines the dependency level. </param>
        /// <param name="orderby"> OData order by query option. For example, you can use $orderby=Count desc. </param>
        /// <param name="filter"> The filter to apply on the operation. For example, $apply=filter(count eq 2). </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="MoverUnresolvedDependency" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<MoverUnresolvedDependency> GetUnresolvedDependencies(MoverDependencyLevel? dependencyLevel = null, string orderby = null, string filter = null, CancellationToken cancellationToken = default)
        {
            Page<MoverUnresolvedDependency> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _unresolvedDependenciesClientDiagnostics.CreateScope("MoverResourceSetResource.GetUnresolvedDependencies");
                scope.Start();
                try
                {
                    var response = _unresolvedDependenciesRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, dependencyLevel, orderby, filter, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<MoverUnresolvedDependency> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _unresolvedDependenciesClientDiagnostics.CreateScope("MoverResourceSetResource.GetUnresolvedDependencies");
                scope.Start();
                try
                {
                    var response = _unresolvedDependenciesRestClient.GetNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, dependencyLevel, orderby, filter, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value, response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }
    }
}
