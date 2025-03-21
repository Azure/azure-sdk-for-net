// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

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

namespace Azure.ResourceManager.Sql
{
    /// <summary>
    /// A class representing a collection of <see cref="DistributedAvailabilityGroupResource"/> and their operations.
    /// Each <see cref="DistributedAvailabilityGroupResource"/> in the collection will belong to the same instance of <see cref="ManagedInstanceResource"/>.
    /// To get a <see cref="DistributedAvailabilityGroupCollection"/> instance call the GetDistributedAvailabilityGroups method from an instance of <see cref="ManagedInstanceResource"/>.
    /// </summary>
    public partial class DistributedAvailabilityGroupCollection : ArmCollection, IEnumerable<DistributedAvailabilityGroupResource>, IAsyncEnumerable<DistributedAvailabilityGroupResource>
    {
        private readonly ClientDiagnostics _distributedAvailabilityGroupClientDiagnostics;
        private readonly DistributedAvailabilityGroupsRestOperations _distributedAvailabilityGroupRestClient;

        /// <summary> Initializes a new instance of the <see cref="DistributedAvailabilityGroupCollection"/> class for mocking. </summary>
        protected DistributedAvailabilityGroupCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="DistributedAvailabilityGroupCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal DistributedAvailabilityGroupCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _distributedAvailabilityGroupClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.Sql", DistributedAvailabilityGroupResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(DistributedAvailabilityGroupResource.ResourceType, out string distributedAvailabilityGroupApiVersion);
            _distributedAvailabilityGroupRestClient = new DistributedAvailabilityGroupsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, distributedAvailabilityGroupApiVersion);
#if DEBUG
            ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != ManagedInstanceResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, ManagedInstanceResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Creates a distributed availability group between Sql On-Prem and Sql Managed Instance.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/distributedAvailabilityGroups/{distributedAvailabilityGroupName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DistributedAvailabilityGroups_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-11-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DistributedAvailabilityGroupResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="distributedAvailabilityGroupName"> The distributed availability group name. </param>
        /// <param name="data"> The distributed availability group info. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="distributedAvailabilityGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="distributedAvailabilityGroupName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<DistributedAvailabilityGroupResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string distributedAvailabilityGroupName, DistributedAvailabilityGroupData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(distributedAvailabilityGroupName, nameof(distributedAvailabilityGroupName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _distributedAvailabilityGroupClientDiagnostics.CreateScope("DistributedAvailabilityGroupCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _distributedAvailabilityGroupRestClient.CreateOrUpdateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, distributedAvailabilityGroupName, data, cancellationToken).ConfigureAwait(false);
                var operation = new SqlArmOperation<DistributedAvailabilityGroupResource>(new DistributedAvailabilityGroupOperationSource(Client), _distributedAvailabilityGroupClientDiagnostics, Pipeline, _distributedAvailabilityGroupRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, distributedAvailabilityGroupName, data).Request, response, OperationFinalStateVia.Location);
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
        /// Creates a distributed availability group between Sql On-Prem and Sql Managed Instance.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/distributedAvailabilityGroups/{distributedAvailabilityGroupName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DistributedAvailabilityGroups_CreateOrUpdate</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-11-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DistributedAvailabilityGroupResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="distributedAvailabilityGroupName"> The distributed availability group name. </param>
        /// <param name="data"> The distributed availability group info. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="distributedAvailabilityGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="distributedAvailabilityGroupName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<DistributedAvailabilityGroupResource> CreateOrUpdate(WaitUntil waitUntil, string distributedAvailabilityGroupName, DistributedAvailabilityGroupData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(distributedAvailabilityGroupName, nameof(distributedAvailabilityGroupName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _distributedAvailabilityGroupClientDiagnostics.CreateScope("DistributedAvailabilityGroupCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _distributedAvailabilityGroupRestClient.CreateOrUpdate(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, distributedAvailabilityGroupName, data, cancellationToken);
                var operation = new SqlArmOperation<DistributedAvailabilityGroupResource>(new DistributedAvailabilityGroupOperationSource(Client), _distributedAvailabilityGroupClientDiagnostics, Pipeline, _distributedAvailabilityGroupRestClient.CreateCreateOrUpdateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, distributedAvailabilityGroupName, data).Request, response, OperationFinalStateVia.Location);
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
        /// Gets a distributed availability group info.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/distributedAvailabilityGroups/{distributedAvailabilityGroupName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DistributedAvailabilityGroups_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-11-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DistributedAvailabilityGroupResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="distributedAvailabilityGroupName"> The distributed availability group name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="distributedAvailabilityGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="distributedAvailabilityGroupName"/> is null. </exception>
        public virtual async Task<Response<DistributedAvailabilityGroupResource>> GetAsync(string distributedAvailabilityGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(distributedAvailabilityGroupName, nameof(distributedAvailabilityGroupName));

            using var scope = _distributedAvailabilityGroupClientDiagnostics.CreateScope("DistributedAvailabilityGroupCollection.Get");
            scope.Start();
            try
            {
                var response = await _distributedAvailabilityGroupRestClient.GetOriginalAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, distributedAvailabilityGroupName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DistributedAvailabilityGroupResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a distributed availability group info.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/distributedAvailabilityGroups/{distributedAvailabilityGroupName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DistributedAvailabilityGroups_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-11-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DistributedAvailabilityGroupResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="distributedAvailabilityGroupName"> The distributed availability group name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="distributedAvailabilityGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="distributedAvailabilityGroupName"/> is null. </exception>
        public virtual Response<DistributedAvailabilityGroupResource> Get(string distributedAvailabilityGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(distributedAvailabilityGroupName, nameof(distributedAvailabilityGroupName));

            using var scope = _distributedAvailabilityGroupClientDiagnostics.CreateScope("DistributedAvailabilityGroupCollection.Get");
            scope.Start();
            try
            {
                var response = _distributedAvailabilityGroupRestClient.GetOriginal(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, distributedAvailabilityGroupName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new DistributedAvailabilityGroupResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets a list of a distributed availability groups in instance.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/distributedAvailabilityGroups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DistributedAvailabilityGroups_ListByInstance</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-11-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DistributedAvailabilityGroupResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="DistributedAvailabilityGroupResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DistributedAvailabilityGroupResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _distributedAvailabilityGroupRestClient.CreateListOriginalByInstanceRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _distributedAvailabilityGroupRestClient.CreateListOriginalByInstanceNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => new DistributedAvailabilityGroupResource(Client, DistributedAvailabilityGroupData.DeserializeDistributedAvailabilityGroupData(e)), _distributedAvailabilityGroupClientDiagnostics, Pipeline, "DistributedAvailabilityGroupCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Gets a list of a distributed availability groups in instance.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/distributedAvailabilityGroups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DistributedAvailabilityGroups_ListByInstance</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-11-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DistributedAvailabilityGroupResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="DistributedAvailabilityGroupResource"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DistributedAvailabilityGroupResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _distributedAvailabilityGroupRestClient.CreateListOriginalByInstanceRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            HttpMessage NextPageRequest(int? pageSizeHint, string nextLink) => _distributedAvailabilityGroupRestClient.CreateListOriginalByInstanceNextPageRequest(nextLink, Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => new DistributedAvailabilityGroupResource(Client, DistributedAvailabilityGroupData.DeserializeDistributedAvailabilityGroupData(e)), _distributedAvailabilityGroupClientDiagnostics, Pipeline, "DistributedAvailabilityGroupCollection.GetAll", "value", "nextLink", cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/distributedAvailabilityGroups/{distributedAvailabilityGroupName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DistributedAvailabilityGroups_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-11-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DistributedAvailabilityGroupResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="distributedAvailabilityGroupName"> The distributed availability group name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="distributedAvailabilityGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="distributedAvailabilityGroupName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string distributedAvailabilityGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(distributedAvailabilityGroupName, nameof(distributedAvailabilityGroupName));

            using var scope = _distributedAvailabilityGroupClientDiagnostics.CreateScope("DistributedAvailabilityGroupCollection.Exists");
            scope.Start();
            try
            {
                var response = await _distributedAvailabilityGroupRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, distributedAvailabilityGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/distributedAvailabilityGroups/{distributedAvailabilityGroupName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DistributedAvailabilityGroups_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-11-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DistributedAvailabilityGroupResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="distributedAvailabilityGroupName"> The distributed availability group name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="distributedAvailabilityGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="distributedAvailabilityGroupName"/> is null. </exception>
        public virtual Response<bool> Exists(string distributedAvailabilityGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(distributedAvailabilityGroupName, nameof(distributedAvailabilityGroupName));

            using var scope = _distributedAvailabilityGroupClientDiagnostics.CreateScope("DistributedAvailabilityGroupCollection.Exists");
            scope.Start();
            try
            {
                var response = _distributedAvailabilityGroupRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, distributedAvailabilityGroupName, cancellationToken: cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/distributedAvailabilityGroups/{distributedAvailabilityGroupName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DistributedAvailabilityGroups_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-11-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DistributedAvailabilityGroupResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="distributedAvailabilityGroupName"> The distributed availability group name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="distributedAvailabilityGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="distributedAvailabilityGroupName"/> is null. </exception>
        public virtual async Task<NullableResponse<DistributedAvailabilityGroupResource>> GetIfExistsAsync(string distributedAvailabilityGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(distributedAvailabilityGroupName, nameof(distributedAvailabilityGroupName));

            using var scope = _distributedAvailabilityGroupClientDiagnostics.CreateScope("DistributedAvailabilityGroupCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _distributedAvailabilityGroupRestClient.GetOriginalAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, distributedAvailabilityGroupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<DistributedAvailabilityGroupResource>(response.GetRawResponse());
                return Response.FromValue(new DistributedAvailabilityGroupResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Sql/managedInstances/{managedInstanceName}/distributedAvailabilityGroups/{distributedAvailabilityGroupName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>DistributedAvailabilityGroups_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2021-11-01-preview</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DistributedAvailabilityGroupResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="distributedAvailabilityGroupName"> The distributed availability group name. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="distributedAvailabilityGroupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="distributedAvailabilityGroupName"/> is null. </exception>
        public virtual NullableResponse<DistributedAvailabilityGroupResource> GetIfExists(string distributedAvailabilityGroupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(distributedAvailabilityGroupName, nameof(distributedAvailabilityGroupName));

            using var scope = _distributedAvailabilityGroupClientDiagnostics.CreateScope("DistributedAvailabilityGroupCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _distributedAvailabilityGroupRestClient.GetOriginal(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, distributedAvailabilityGroupName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<DistributedAvailabilityGroupResource>(response.GetRawResponse());
                return Response.FromValue(new DistributedAvailabilityGroupResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<DistributedAvailabilityGroupResource> IEnumerable<DistributedAvailabilityGroupResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<DistributedAvailabilityGroupResource> IAsyncEnumerable<DistributedAvailabilityGroupResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
