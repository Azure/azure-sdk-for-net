// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// <auto-generated/>

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.AppService
{
    /// <summary>
    /// A class representing a collection of <see cref="StaticSiteResource"/> and their operations.
    /// Each <see cref="StaticSiteResource"/> in the collection will belong to the same instance of <see cref="ResourceGroupResource"/>.
    /// To get a <see cref="StaticSiteCollection"/> instance call the GetStaticSites method from an instance of <see cref="ResourceGroupResource"/>.
    /// </summary>
    public partial class StaticSiteCollection : ArmCollection, IEnumerable<StaticSiteResource>, IAsyncEnumerable<StaticSiteResource>
    {
        private readonly ClientDiagnostics _staticSiteClientDiagnostics;
        private readonly StaticSitesRestOperations _staticSiteRestClient;

        /// <summary> Initializes a new instance of the <see cref="StaticSiteCollection"/> class for mocking. </summary>
        protected StaticSiteCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="StaticSiteCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal StaticSiteCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _staticSiteClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.AppService", StaticSiteResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(StaticSiteResource.ResourceType, out string staticSiteApiVersion);
            _staticSiteRestClient = new StaticSitesRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, staticSiteApiVersion);
#if DEBUG
			ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ResourceGroupResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ResourceGroupResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Description for Creates a new static site in an existing resource group, or updates an existing static site.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/staticSites/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StaticSites_CreateOrUpdateStaticSite</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="StaticSiteResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="name"> Name of the static site to create or update. </param>
        /// <param name="data"> A JSON representation of the staticsite properties. See example. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<StaticSiteResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string name, StaticSiteData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _staticSiteClientDiagnostics.CreateScope("StaticSiteCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _staticSiteRestClient.CreateOrUpdateStaticSiteAsync(Id.SubscriptionId, Id.ResourceGroupName, name, data, cancellationToken).ConfigureAwait(false);
                var operation = new AppServiceArmOperation<StaticSiteResource>(new StaticSiteOperationSource(Client), _staticSiteClientDiagnostics, Pipeline, _staticSiteRestClient.CreateCreateOrUpdateStaticSiteRequest(Id.SubscriptionId, Id.ResourceGroupName, name, data).Request, response, OperationFinalStateVia.Location);
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
        /// Description for Creates a new static site in an existing resource group, or updates an existing static site.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/staticSites/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StaticSites_CreateOrUpdateStaticSite</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="StaticSiteResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="name"> Name of the static site to create or update. </param>
        /// <param name="data"> A JSON representation of the staticsite properties. See example. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<StaticSiteResource> CreateOrUpdate(WaitUntil waitUntil, string name, StaticSiteData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _staticSiteClientDiagnostics.CreateScope("StaticSiteCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _staticSiteRestClient.CreateOrUpdateStaticSite(Id.SubscriptionId, Id.ResourceGroupName, name, data, cancellationToken);
                var operation = new AppServiceArmOperation<StaticSiteResource>(new StaticSiteOperationSource(Client), _staticSiteClientDiagnostics, Pipeline, _staticSiteRestClient.CreateCreateOrUpdateStaticSiteRequest(Id.SubscriptionId, Id.ResourceGroupName, name, data).Request, response, OperationFinalStateVia.Location);
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
        /// Description for Gets the details of a static site.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/staticSites/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StaticSites_GetStaticSite</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="StaticSiteResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> Name of the static site. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<Response<StaticSiteResource>> GetAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _staticSiteClientDiagnostics.CreateScope("StaticSiteCollection.Get");
            scope.Start();
            try
            {
                var response = await _staticSiteRestClient.GetStaticSiteAsync(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new StaticSiteResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Gets the details of a static site.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/staticSites/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StaticSites_GetStaticSite</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="StaticSiteResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> Name of the static site. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<StaticSiteResource> Get(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _staticSiteClientDiagnostics.CreateScope("StaticSiteCollection.Get");
            scope.Start();
            try
            {
                var response = _staticSiteRestClient.GetStaticSite(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new StaticSiteResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Description for Gets all static sites in the specified resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/staticSites</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StaticSites_GetStaticSitesByResourceGroup</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="StaticSiteResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="StaticSiteResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<StaticSiteResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _staticSiteRestClient.CreateGetStaticSitesByResourceGroupRequest(Id.SubscriptionId, Id.ResourceGroupName);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _staticSiteRestClient.CreateGetStaticSitesByResourceGroupNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new StaticSiteResource(Client, StaticSiteData.DeserializeStaticSiteData(e)), _staticSiteClientDiagnostics, Pipeline, "StaticSiteCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Description for Gets all static sites in the specified resource group.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/staticSites</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StaticSites_GetStaticSitesByResourceGroup</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="StaticSiteResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="StaticSiteResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<StaticSiteResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _staticSiteRestClient.CreateGetStaticSitesByResourceGroupRequest(Id.SubscriptionId, Id.ResourceGroupName);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _staticSiteRestClient.CreateGetStaticSitesByResourceGroupNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new StaticSiteResource(Client, StaticSiteData.DeserializeStaticSiteData(e)), _staticSiteClientDiagnostics, Pipeline, "StaticSiteCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/staticSites/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StaticSites_GetStaticSite</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="StaticSiteResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> Name of the static site. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _staticSiteClientDiagnostics.CreateScope("StaticSiteCollection.Exists");
            scope.Start();
            try
            {
                var response = await _staticSiteRestClient.GetStaticSiteAsync(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/staticSites/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StaticSites_GetStaticSite</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="StaticSiteResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> Name of the static site. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual Response<bool> Exists(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _staticSiteClientDiagnostics.CreateScope("StaticSiteCollection.Exists");
            scope.Start();
            try
            {
                var response = _staticSiteRestClient.GetStaticSite(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/staticSites/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StaticSites_GetStaticSite</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="StaticSiteResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> Name of the static site. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual async Task<NullableResponse<StaticSiteResource>> GetIfExistsAsync(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _staticSiteClientDiagnostics.CreateScope("StaticSiteCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _staticSiteRestClient.GetStaticSiteAsync(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<StaticSiteResource>(response.GetRawResponse());
                return Response.FromValue(new StaticSiteResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Tries to get details for this resource from the service.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Web/staticSites/{name}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>StaticSites_GetStaticSite</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2024-11-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="StaticSiteResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="name"> Name of the static site. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="name"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="name"/> is null. </exception>
        public virtual NullableResponse<StaticSiteResource> GetIfExists(string name, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(name, nameof(name));

            using var scope = _staticSiteClientDiagnostics.CreateScope("StaticSiteCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _staticSiteRestClient.GetStaticSite(Id.SubscriptionId, Id.ResourceGroupName, name, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<StaticSiteResource>(response.GetRawResponse());
                return Response.FromValue(new StaticSiteResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<StaticSiteResource> IEnumerable<StaticSiteResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<StaticSiteResource> IAsyncEnumerable<StaticSiteResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
