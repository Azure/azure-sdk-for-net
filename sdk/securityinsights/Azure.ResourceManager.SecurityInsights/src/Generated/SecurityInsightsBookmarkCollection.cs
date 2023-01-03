// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

[assembly: CodeGenSuppressType("SecurityInsightsBookmarkCollection")]
namespace Azure.ResourceManager.SecurityInsights
{
    /// <summary>
    /// A class representing a collection of <see cref="SecurityInsightsBookmarkResource" /> and their operations.
<<<<<<<< HEAD:sdk/securityinsights/Azure.ResourceManager.SecurityInsights/src/Generated/SecurityInsightsBookmarkCollection.cs
    /// Each <see cref="SecurityInsightsBookmarkResource" /> in the collection will belong to the same instance of <see cref="ResourceGroupResource" />.
    /// To get a <see cref="SecurityInsightsBookmarkCollection" /> instance call the GetSecurityInsightsBookmarks method from an instance of <see cref="ResourceGroupResource" />.
========
    /// Each <see cref="SecurityInsightsBookmarkResource" /> in the collection will belong to the same instance of <see cref="OperationalInsightsWorkspaceSecurityInsightsResource" />.
    /// To get a <see cref="SecurityInsightsBookmarkCollection" /> instance call the GetSecurityInsightsBookmarks method from an instance of <see cref="OperationalInsightsWorkspaceSecurityInsightsResource" />.
>>>>>>>> upstream/main:sdk/securityinsights/Azure.ResourceManager.SecurityInsights/src/Customized/SecurityInsightsBookmarkCollection.cs
    /// </summary>
    public partial class SecurityInsightsBookmarkCollection : ArmCollection, IEnumerable<SecurityInsightsBookmarkResource>, IAsyncEnumerable<SecurityInsightsBookmarkResource>
    {
        private readonly ClientDiagnostics _securityInsightsBookmarkBookmarksClientDiagnostics;
        private readonly BookmarksRestOperations _securityInsightsBookmarkBookmarksRestClient;
<<<<<<<< HEAD:sdk/securityinsights/Azure.ResourceManager.SecurityInsights/src/Generated/SecurityInsightsBookmarkCollection.cs
        private readonly string _workspaceName;
========
>>>>>>>> upstream/main:sdk/securityinsights/Azure.ResourceManager.SecurityInsights/src/Customized/SecurityInsightsBookmarkCollection.cs

        /// <summary> Initializes a new instance of the <see cref="SecurityInsightsBookmarkCollection"/> class for mocking. </summary>
        protected SecurityInsightsBookmarkCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="SecurityInsightsBookmarkCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
<<<<<<<< HEAD:sdk/securityinsights/Azure.ResourceManager.SecurityInsights/src/Generated/SecurityInsightsBookmarkCollection.cs
        /// <param name="workspaceName"> The name of the workspace. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="workspaceName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="workspaceName"/> is an empty string, and was expected to be non-empty. </exception>
        internal SecurityInsightsBookmarkCollection(ArmClient client, ResourceIdentifier id, string workspaceName) : base(client, id)
        {
            _workspaceName = workspaceName;
========
        internal SecurityInsightsBookmarkCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
>>>>>>>> upstream/main:sdk/securityinsights/Azure.ResourceManager.SecurityInsights/src/Customized/SecurityInsightsBookmarkCollection.cs
            _securityInsightsBookmarkBookmarksClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.SecurityInsights", SecurityInsightsBookmarkResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(SecurityInsightsBookmarkResource.ResourceType, out string securityInsightsBookmarkBookmarksApiVersion);
            _securityInsightsBookmarkBookmarksRestClient = new BookmarksRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, securityInsightsBookmarkBookmarksApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != OperationalInsightsWorkspaceSecurityInsightsResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, OperationalInsightsWorkspaceSecurityInsightsResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates or updates the bookmark.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/bookmarks/{bookmarkId}
        /// Operation Id: Bookmarks_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="bookmarkId"> Bookmark ID. </param>
        /// <param name="data"> The bookmark. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="bookmarkId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="bookmarkId"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<SecurityInsightsBookmarkResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string bookmarkId, SecurityInsightsBookmarkData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(bookmarkId, nameof(bookmarkId));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _securityInsightsBookmarkBookmarksClientDiagnostics.CreateScope("SecurityInsightsBookmarkCollection.CreateOrUpdate");
            scope.Start();
            try
            {
<<<<<<<< HEAD:sdk/securityinsights/Azure.ResourceManager.SecurityInsights/src/Generated/SecurityInsightsBookmarkCollection.cs
                var response = await _securityInsightsBookmarkBookmarksRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, _workspaceName, bookmarkId, data, cancellationToken).ConfigureAwait(false);
========
                var response = await _securityInsightsBookmarkBookmarksRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, bookmarkId, data, cancellationToken).ConfigureAwait(false);
>>>>>>>> upstream/main:sdk/securityinsights/Azure.ResourceManager.SecurityInsights/src/Customized/SecurityInsightsBookmarkCollection.cs
                var operation = new SecurityInsightsArmOperation<SecurityInsightsBookmarkResource>(Response.FromValue(new SecurityInsightsBookmarkResource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Creates or updates the bookmark.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/bookmarks/{bookmarkId}
        /// Operation Id: Bookmarks_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="bookmarkId"> Bookmark ID. </param>
        /// <param name="data"> The bookmark. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="bookmarkId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="bookmarkId"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<SecurityInsightsBookmarkResource> CreateOrUpdate(WaitUntil waitUntil, string bookmarkId, SecurityInsightsBookmarkData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(bookmarkId, nameof(bookmarkId));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _securityInsightsBookmarkBookmarksClientDiagnostics.CreateScope("SecurityInsightsBookmarkCollection.CreateOrUpdate");
            scope.Start();
            try
            {
<<<<<<<< HEAD:sdk/securityinsights/Azure.ResourceManager.SecurityInsights/src/Generated/SecurityInsightsBookmarkCollection.cs
                var response = _securityInsightsBookmarkBookmarksRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, _workspaceName, bookmarkId, data, cancellationToken);
========
                var response = _securityInsightsBookmarkBookmarksRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, bookmarkId, data, cancellationToken);
>>>>>>>> upstream/main:sdk/securityinsights/Azure.ResourceManager.SecurityInsights/src/Customized/SecurityInsightsBookmarkCollection.cs
                var operation = new SecurityInsightsArmOperation<SecurityInsightsBookmarkResource>(Response.FromValue(new SecurityInsightsBookmarkResource(Client, response), response.GetRawResponse()));
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a bookmark.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/bookmarks/{bookmarkId}
        /// Operation Id: Bookmarks_Get
        /// </summary>
        /// <param name="bookmarkId"> Bookmark ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="bookmarkId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="bookmarkId"/> is null. </exception>
        public virtual async Task<Response<SecurityInsightsBookmarkResource>> GetAsync(string bookmarkId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(bookmarkId, nameof(bookmarkId));

            using var scope = _securityInsightsBookmarkBookmarksClientDiagnostics.CreateScope("SecurityInsightsBookmarkCollection.Get");
            scope.Start();
            try
            {
<<<<<<<< HEAD:sdk/securityinsights/Azure.ResourceManager.SecurityInsights/src/Generated/SecurityInsightsBookmarkCollection.cs
                var response = await _securityInsightsBookmarkBookmarksRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, _workspaceName, bookmarkId, cancellationToken).ConfigureAwait(false);
========
                var response = await _securityInsightsBookmarkBookmarksRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, bookmarkId, cancellationToken).ConfigureAwait(false);
>>>>>>>> upstream/main:sdk/securityinsights/Azure.ResourceManager.SecurityInsights/src/Customized/SecurityInsightsBookmarkCollection.cs
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SecurityInsightsBookmarkResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a bookmark.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/bookmarks/{bookmarkId}
        /// Operation Id: Bookmarks_Get
        /// </summary>
        /// <param name="bookmarkId"> Bookmark ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="bookmarkId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="bookmarkId"/> is null. </exception>
        public virtual Response<SecurityInsightsBookmarkResource> Get(string bookmarkId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(bookmarkId, nameof(bookmarkId));

            using var scope = _securityInsightsBookmarkBookmarksClientDiagnostics.CreateScope("SecurityInsightsBookmarkCollection.Get");
            scope.Start();
            try
            {
<<<<<<<< HEAD:sdk/securityinsights/Azure.ResourceManager.SecurityInsights/src/Generated/SecurityInsightsBookmarkCollection.cs
                var response = _securityInsightsBookmarkBookmarksRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, _workspaceName, bookmarkId, cancellationToken);
========
                var response = _securityInsightsBookmarkBookmarksRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, bookmarkId, cancellationToken);
>>>>>>>> upstream/main:sdk/securityinsights/Azure.ResourceManager.SecurityInsights/src/Customized/SecurityInsightsBookmarkCollection.cs
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new SecurityInsightsBookmarkResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets all bookmarks.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/bookmarks
        /// Operation Id: Bookmarks_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="SecurityInsightsBookmarkResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<SecurityInsightsBookmarkResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            async Task<Page<SecurityInsightsBookmarkResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _securityInsightsBookmarkBookmarksClientDiagnostics.CreateScope("SecurityInsightsBookmarkCollection.GetAll");
                scope.Start();
                try
                {
<<<<<<<< HEAD:sdk/securityinsights/Azure.ResourceManager.SecurityInsights/src/Generated/SecurityInsightsBookmarkCollection.cs
                    var response = await _securityInsightsBookmarkBookmarksRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, _workspaceName, cancellationToken: cancellationToken).ConfigureAwait(false);
========
                    var response = await _securityInsightsBookmarkBookmarksRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
>>>>>>>> upstream/main:sdk/securityinsights/Azure.ResourceManager.SecurityInsights/src/Customized/SecurityInsightsBookmarkCollection.cs
                    return Page.FromValues(response.Value.Value.Select(value => new SecurityInsightsBookmarkResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<SecurityInsightsBookmarkResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _securityInsightsBookmarkBookmarksClientDiagnostics.CreateScope("SecurityInsightsBookmarkCollection.GetAll");
                scope.Start();
                try
                {
<<<<<<<< HEAD:sdk/securityinsights/Azure.ResourceManager.SecurityInsights/src/Generated/SecurityInsightsBookmarkCollection.cs
                    var response = await _securityInsightsBookmarkBookmarksRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, _workspaceName, cancellationToken: cancellationToken).ConfigureAwait(false);
========
                    var response = await _securityInsightsBookmarkBookmarksRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken).ConfigureAwait(false);
>>>>>>>> upstream/main:sdk/securityinsights/Azure.ResourceManager.SecurityInsights/src/Customized/SecurityInsightsBookmarkCollection.cs
                    return Page.FromValues(response.Value.Value.Select(value => new SecurityInsightsBookmarkResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Gets all bookmarks.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/bookmarks
        /// Operation Id: Bookmarks_List
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="SecurityInsightsBookmarkResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<SecurityInsightsBookmarkResource> GetAll(CancellationToken cancellationToken = default)
        {
            Page<SecurityInsightsBookmarkResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _securityInsightsBookmarkBookmarksClientDiagnostics.CreateScope("SecurityInsightsBookmarkCollection.GetAll");
                scope.Start();
                try
                {
<<<<<<<< HEAD:sdk/securityinsights/Azure.ResourceManager.SecurityInsights/src/Generated/SecurityInsightsBookmarkCollection.cs
                    var response = _securityInsightsBookmarkBookmarksRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, _workspaceName, cancellationToken: cancellationToken);
========
                    var response = _securityInsightsBookmarkBookmarksRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
>>>>>>>> upstream/main:sdk/securityinsights/Azure.ResourceManager.SecurityInsights/src/Customized/SecurityInsightsBookmarkCollection.cs
                    return Page.FromValues(response.Value.Value.Select(value => new SecurityInsightsBookmarkResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<SecurityInsightsBookmarkResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _securityInsightsBookmarkBookmarksClientDiagnostics.CreateScope("SecurityInsightsBookmarkCollection.GetAll");
                scope.Start();
                try
                {
<<<<<<<< HEAD:sdk/securityinsights/Azure.ResourceManager.SecurityInsights/src/Generated/SecurityInsightsBookmarkCollection.cs
                    var response = _securityInsightsBookmarkBookmarksRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, _workspaceName, cancellationToken: cancellationToken);
========
                    var response = _securityInsightsBookmarkBookmarksRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name, cancellationToken: cancellationToken);
>>>>>>>> upstream/main:sdk/securityinsights/Azure.ResourceManager.SecurityInsights/src/Customized/SecurityInsightsBookmarkCollection.cs
                    return Page.FromValues(response.Value.Value.Select(value => new SecurityInsightsBookmarkResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            return PageableHelpers.CreateEnumerable(FirstPageFunc, NextPageFunc);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/bookmarks/{bookmarkId}
        /// Operation Id: Bookmarks_Get
        /// </summary>
        /// <param name="bookmarkId"> Bookmark ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="bookmarkId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="bookmarkId"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string bookmarkId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(bookmarkId, nameof(bookmarkId));

            using var scope = _securityInsightsBookmarkBookmarksClientDiagnostics.CreateScope("SecurityInsightsBookmarkCollection.Exists");
            scope.Start();
            try
            {
<<<<<<<< HEAD:sdk/securityinsights/Azure.ResourceManager.SecurityInsights/src/Generated/SecurityInsightsBookmarkCollection.cs
                var response = await _securityInsightsBookmarkBookmarksRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, _workspaceName, bookmarkId, cancellationToken: cancellationToken).ConfigureAwait(false);
========
                var response = await _securityInsightsBookmarkBookmarksRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, bookmarkId, cancellationToken: cancellationToken).ConfigureAwait(false);
>>>>>>>> upstream/main:sdk/securityinsights/Azure.ResourceManager.SecurityInsights/src/Customized/SecurityInsightsBookmarkCollection.cs
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.OperationalInsights/workspaces/{workspaceName}/providers/Microsoft.SecurityInsights/bookmarks/{bookmarkId}
        /// Operation Id: Bookmarks_Get
        /// </summary>
        /// <param name="bookmarkId"> Bookmark ID. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="bookmarkId"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="bookmarkId"/> is null. </exception>
        public virtual Response<bool> Exists(string bookmarkId, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(bookmarkId, nameof(bookmarkId));

            using var scope = _securityInsightsBookmarkBookmarksClientDiagnostics.CreateScope("SecurityInsightsBookmarkCollection.Exists");
            scope.Start();
            try
            {
<<<<<<<< HEAD:sdk/securityinsights/Azure.ResourceManager.SecurityInsights/src/Generated/SecurityInsightsBookmarkCollection.cs
                var response = _securityInsightsBookmarkBookmarksRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, _workspaceName, bookmarkId, cancellationToken: cancellationToken);
========
                var response = _securityInsightsBookmarkBookmarksRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, bookmarkId, cancellationToken: cancellationToken);
>>>>>>>> upstream/main:sdk/securityinsights/Azure.ResourceManager.SecurityInsights/src/Customized/SecurityInsightsBookmarkCollection.cs
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<SecurityInsightsBookmarkResource> IEnumerable<SecurityInsightsBookmarkResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<SecurityInsightsBookmarkResource> IAsyncEnumerable<SecurityInsightsBookmarkResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
