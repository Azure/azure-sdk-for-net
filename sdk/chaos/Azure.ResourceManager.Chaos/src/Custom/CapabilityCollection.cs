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

namespace Azure.ResourceManager.Chaos
{
    /// <summary>
    /// A class representing a collection of <see cref="CapabilityResource" /> and their operations.
    /// Each <see cref="CapabilityResource" /> in the collection will belong to the same instance of <see cref="TargetResource" />.
    /// To get a <see cref="CapabilityCollection" /> instance call the GetCapabilities method from an instance of <see cref="TargetResource" />.
    /// </summary>
    public partial class CapabilityCollection : ArmCollection, IEnumerable<CapabilityResource>, IAsyncEnumerable<CapabilityResource>
    {
        /// <summary>
        /// Create or update a Capability resource that extends a Target resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{parentProviderNamespace}/{parentResourceType}/{parentResourceName}/providers/Microsoft.Chaos/targets/{targetName}/capabilities/{capabilityName}
        /// Operation Id: Capabilities_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="capabilityName"> String that represents a Capability resource name. </param>
        /// <param name="data"> Capability resource to be created or updated. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="capabilityName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="capabilityName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<CapabilityResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string capabilityName, CapabilityData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(capabilityName, nameof(capabilityName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _capabilityClientDiagnostics.CreateScope("CapabilityCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _capabilityRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.ResourceType.Namespace, Id.Parent.ResourceType.GetLastType(), Id.Parent.Name, Id.Name, capabilityName, data, cancellationToken).ConfigureAwait(false);
                var operation = new ChaosArmOperation<CapabilityResource>(Response.FromValue(new CapabilityResource(Client, response), response.GetRawResponse()));
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
        /// Create or update a Capability resource that extends a Target resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{parentProviderNamespace}/{parentResourceType}/{parentResourceName}/providers/Microsoft.Chaos/targets/{targetName}/capabilities/{capabilityName}
        /// Operation Id: Capabilities_CreateOrUpdate
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="capabilityName"> String that represents a Capability resource name. </param>
        /// <param name="data"> Capability resource to be created or updated. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="capabilityName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="capabilityName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<CapabilityResource> CreateOrUpdate(WaitUntil waitUntil, string capabilityName, CapabilityData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(capabilityName, nameof(capabilityName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _capabilityClientDiagnostics.CreateScope("CapabilityCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _capabilityRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.ResourceType.Namespace, Id.Parent.ResourceType.GetLastType(), Id.Parent.Name, Id.Name, capabilityName, data, cancellationToken);
                var operation = new ChaosArmOperation<CapabilityResource>(Response.FromValue(new CapabilityResource(Client, response), response.GetRawResponse()));
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
        /// Get a Capability resource that extends a Target resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{parentProviderNamespace}/{parentResourceType}/{parentResourceName}/providers/Microsoft.Chaos/targets/{targetName}/capabilities/{capabilityName}
        /// Operation Id: Capabilities_Get
        /// </summary>
        /// <param name="capabilityName"> String that represents a Capability resource name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="capabilityName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="capabilityName"/> is null. </exception>
        public virtual async Task<Response<CapabilityResource>> GetAsync(string capabilityName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(capabilityName, nameof(capabilityName));

            using var scope = _capabilityClientDiagnostics.CreateScope("CapabilityCollection.Get");
            scope.Start();
            try
            {
                var response = await _capabilityRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.ResourceType.Namespace, Id.Parent.ResourceType.GetLastType(), Id.Parent.Name, Id.Name, capabilityName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new CapabilityResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get a Capability resource that extends a Target resource.
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{parentProviderNamespace}/{parentResourceType}/{parentResourceName}/providers/Microsoft.Chaos/targets/{targetName}/capabilities/{capabilityName}
        /// Operation Id: Capabilities_Get
        /// </summary>
        /// <param name="capabilityName"> String that represents a Capability resource name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="capabilityName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="capabilityName"/> is null. </exception>
        public virtual Response<CapabilityResource> Get(string capabilityName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(capabilityName, nameof(capabilityName));

            using var scope = _capabilityClientDiagnostics.CreateScope("CapabilityCollection.Get");
            scope.Start();
            try
            {
                var response = _capabilityRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.ResourceType.Namespace, Id.Parent.ResourceType.GetLastType(), Id.Parent.Name, Id.Name, capabilityName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new CapabilityResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Get a list of Capability resources that extend a Target resource..
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{parentProviderNamespace}/{parentResourceType}/{parentResourceName}/providers/Microsoft.Chaos/targets/{targetName}/capabilities
        /// Operation Id: Capabilities_List
        /// </summary>
        /// <param name="continuationToken"> String that sets the continuation token. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="CapabilityResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<CapabilityResource> GetAllAsync(string continuationToken = null, CancellationToken cancellationToken = default)
        {
            async Task<Page<CapabilityResource>> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _capabilityClientDiagnostics.CreateScope("CapabilityCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _capabilityRestClient.ListAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.ResourceType.Namespace, Id.Parent.ResourceType.GetLastType(), Id.Parent.Name, Id.Name, continuationToken, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new CapabilityResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            async Task<Page<CapabilityResource>> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _capabilityClientDiagnostics.CreateScope("CapabilityCollection.GetAll");
                scope.Start();
                try
                {
                    var response = await _capabilityRestClient.ListNextPageAsync(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.ResourceType.Namespace, Id.Parent.ResourceType.GetLastType(), Id.Parent.Name, Id.Name, continuationToken, cancellationToken: cancellationToken).ConfigureAwait(false);
                    return Page.FromValues(response.Value.Value.Select(value => new CapabilityResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Get a list of Capability resources that extend a Target resource..
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{parentProviderNamespace}/{parentResourceType}/{parentResourceName}/providers/Microsoft.Chaos/targets/{targetName}/capabilities
        /// Operation Id: Capabilities_List
        /// </summary>
        /// <param name="continuationToken"> String that sets the continuation token. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="CapabilityResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<CapabilityResource> GetAll(string continuationToken = null, CancellationToken cancellationToken = default)
        {
            Page<CapabilityResource> FirstPageFunc(int? pageSizeHint)
            {
                using var scope = _capabilityClientDiagnostics.CreateScope("CapabilityCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _capabilityRestClient.List(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.ResourceType.Namespace, Id.Parent.ResourceType.GetLastType(), Id.Parent.Name, Id.Name, continuationToken, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new CapabilityResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            }
            Page<CapabilityResource> NextPageFunc(string nextLink, int? pageSizeHint)
            {
                using var scope = _capabilityClientDiagnostics.CreateScope("CapabilityCollection.GetAll");
                scope.Start();
                try
                {
                    var response = _capabilityRestClient.ListNextPage(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.ResourceType.Namespace, Id.Parent.ResourceType.GetLastType(), Id.Parent.Name, Id.Name, continuationToken, cancellationToken: cancellationToken);
                    return Page.FromValues(response.Value.Value.Select(value => new CapabilityResource(Client, value)), response.Value.NextLink, response.GetRawResponse());
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{parentProviderNamespace}/{parentResourceType}/{parentResourceName}/providers/Microsoft.Chaos/targets/{targetName}/capabilities/{capabilityName}
        /// Operation Id: Capabilities_Get
        /// </summary>
        /// <param name="capabilityName"> String that represents a Capability resource name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="capabilityName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="capabilityName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string capabilityName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(capabilityName, nameof(capabilityName));

            using var scope = _capabilityClientDiagnostics.CreateScope("CapabilityCollection.Exists");
            scope.Start();
            try
            {
                var response = await _capabilityRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.ResourceType.Namespace, Id.Parent.ResourceType.GetLastType(), Id.Parent.Name, Id.Name, capabilityName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// Request Path: /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/{parentProviderNamespace}/{parentResourceType}/{parentResourceName}/providers/Microsoft.Chaos/targets/{targetName}/capabilities/{capabilityName}
        /// Operation Id: Capabilities_Get
        /// </summary>
        /// <param name="capabilityName"> String that represents a Capability resource name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="capabilityName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="capabilityName"/> is null. </exception>
        public virtual Response<bool> Exists(string capabilityName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(capabilityName, nameof(capabilityName));

            using var scope = _capabilityClientDiagnostics.CreateScope("CapabilityCollection.Exists");
            scope.Start();
            try
            {
                var response = _capabilityRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.ResourceType.Namespace, Id.Parent.ResourceType.GetLastType(), Id.Parent.Name, Id.Name, capabilityName, cancellationToken: cancellationToken);
                return Response.FromValue(response.Value != null, response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
