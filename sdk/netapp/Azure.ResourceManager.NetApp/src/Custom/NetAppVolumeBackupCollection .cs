﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;

namespace Azure.ResourceManager.NetApp
{
    /// <summary>
    /// A class representing a collection of <see cref="NetAppVolumeBackupResource" /> and their operations.
    /// Each <see cref="NetAppVolumeBackupResource" /> in the collection will belong to the same instance of <see cref="NetAppVolumeResource" />.
    /// To get a <see cref="NetAppVolumeBackupCollection" /> instance call the GetNetAppVolumeBackups method from an instance of <see cref="NetAppVolumeResource" />.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class NetAppVolumeBackupCollection : ArmCollection, IEnumerable<NetAppVolumeBackupResource>, IAsyncEnumerable<NetAppVolumeBackupResource>
    {
        private readonly ClientDiagnostics _netAppVolumeBackupBackupsClientDiagnostics;
        private readonly BackupsRestOperations _netAppVolumeBackupBackupsRestClient;

        /// <summary> Initializes a new instance of the <see cref="NetAppVolumeBackupCollection"/> class for mocking. </summary>
        protected NetAppVolumeBackupCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="NetAppVolumeBackupCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal NetAppVolumeBackupCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _netAppVolumeBackupBackupsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.NetApp", NetAppVolumeBackupResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(NetAppVolumeBackupResource.ResourceType, out string netAppVolumeBackupBackupsApiVersion);
            _netAppVolumeBackupBackupsRestClient = new BackupsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, netAppVolumeBackupBackupsApiVersion);
#if DEBUG
            ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != NetAppVolumeResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, NetAppVolumeResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Create a backup for the volume
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/capacityPools/{poolName}/volumes/{volumeName}/backups/{backupName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Backups_Create</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="backupName"> The name of the backup. </param>
        /// <param name="data"> Backup object supplied in the body of the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="backupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="backupName"/> or <paramref name="data"/> is null. </exception>
        public virtual async Task<ArmOperation<NetAppVolumeBackupResource>> CreateOrUpdateAsync(WaitUntil waitUntil, string backupName, NetAppBackupData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(backupName, nameof(backupName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _netAppVolumeBackupBackupsClientDiagnostics.CreateScope("NetAppVolumeBackupCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = await _netAppVolumeBackupBackupsRestClient.CreateAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, backupName, data, cancellationToken).ConfigureAwait(false);
                var operation = new NetAppArmOperation<NetAppVolumeBackupResource>(new NetAppVolumeBackupOperationSource(Client), _netAppVolumeBackupBackupsClientDiagnostics, Pipeline, _netAppVolumeBackupBackupsRestClient.CreateCreateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, backupName, data).Request, response, OperationFinalStateVia.Location);
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
        /// Create a backup for the volume
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/capacityPools/{poolName}/volumes/{volumeName}/backups/{backupName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Backups_Create</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="backupName"> The name of the backup. </param>
        /// <param name="data"> Backup object supplied in the body of the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="backupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="backupName"/> or <paramref name="data"/> is null. </exception>
        public virtual ArmOperation<NetAppVolumeBackupResource> CreateOrUpdate(WaitUntil waitUntil, string backupName, NetAppBackupData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(backupName, nameof(backupName));
            Argument.AssertNotNull(data, nameof(data));

            using var scope = _netAppVolumeBackupBackupsClientDiagnostics.CreateScope("NetAppVolumeBackupCollection.CreateOrUpdate");
            scope.Start();
            try
            {
                var response = _netAppVolumeBackupBackupsRestClient.Create(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, backupName, data, cancellationToken);
                var operation = new NetAppArmOperation<NetAppVolumeBackupResource>(new NetAppVolumeBackupOperationSource(Client), _netAppVolumeBackupBackupsClientDiagnostics, Pipeline, _netAppVolumeBackupBackupsRestClient.CreateCreateRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, backupName, data).Request, response, OperationFinalStateVia.Location);
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
        /// Gets the specified backup of the volume
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/capacityPools/{poolName}/volumes/{volumeName}/backups/{backupName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Backups_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="backupName"> The name of the backup. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="backupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="backupName"/> is null. </exception>
        public virtual async Task<Response<NetAppVolumeBackupResource>> GetAsync(string backupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(backupName, nameof(backupName));

            using var scope = _netAppVolumeBackupBackupsClientDiagnostics.CreateScope("NetAppVolumeBackupCollection.Get");
            scope.Start();
            try
            {
                var response = await _netAppVolumeBackupBackupsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, backupName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new NetAppVolumeBackupResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the specified backup of the volume
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/capacityPools/{poolName}/volumes/{volumeName}/backups/{backupName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Backups_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="backupName"> The name of the backup. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="backupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="backupName"/> is null. </exception>
        public virtual Response<NetAppVolumeBackupResource> Get(string backupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(backupName, nameof(backupName));

            using var scope = _netAppVolumeBackupBackupsClientDiagnostics.CreateScope("NetAppVolumeBackupCollection.Get");
            scope.Start();
            try
            {
                var response = _netAppVolumeBackupBackupsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, backupName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new NetAppVolumeBackupResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List all backups for a volume
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/capacityPools/{poolName}/volumes/{volumeName}/backups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Backups_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="NetAppVolumeBackupResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<NetAppVolumeBackupResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _netAppVolumeBackupBackupsRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => new NetAppVolumeBackupResource(Client, NetAppBackupData.DeserializeNetAppBackupData(e)), _netAppVolumeBackupBackupsClientDiagnostics, Pipeline, "NetAppVolumeBackupCollection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// List all backups for a volume
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/capacityPools/{poolName}/volumes/{volumeName}/backups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Backups_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="NetAppVolumeBackupResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<NetAppVolumeBackupResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _netAppVolumeBackupBackupsRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, null, e => new NetAppVolumeBackupResource(Client, NetAppBackupData.DeserializeNetAppBackupData(e)), _netAppVolumeBackupBackupsClientDiagnostics, Pipeline, "NetAppVolumeBackupCollection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/capacityPools/{poolName}/volumes/{volumeName}/backups/{backupName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Backups_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="backupName"> The name of the backup. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="backupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="backupName"/> is null. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string backupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(backupName, nameof(backupName));

            using var scope = _netAppVolumeBackupBackupsClientDiagnostics.CreateScope("NetAppVolumeBackupCollection.Exists");
            scope.Start();
            try
            {
                var response = await _netAppVolumeBackupBackupsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, backupName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/capacityPools/{poolName}/volumes/{volumeName}/backups/{backupName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Backups_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="backupName"> The name of the backup. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="backupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="backupName"/> is null. </exception>
        public virtual Response<bool> Exists(string backupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(backupName, nameof(backupName));

            using var scope = _netAppVolumeBackupBackupsClientDiagnostics.CreateScope("NetAppVolumeBackupCollection.Exists");
            scope.Start();
            try
            {
                var response = _netAppVolumeBackupBackupsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, backupName, cancellationToken: cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/capacityPools/{poolName}/volumes/{volumeName}/backups/{backupName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Backups_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="backupName"> The name of the backup. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="backupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="backupName"/> is null. </exception>
        public virtual async Task<NullableResponse<NetAppVolumeBackupResource>> GetIfExistsAsync(string backupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(backupName, nameof(backupName));

            using var scope = _netAppVolumeBackupBackupsClientDiagnostics.CreateScope("NetAppVolumeBackupCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _netAppVolumeBackupBackupsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, backupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<NetAppVolumeBackupResource>(response.GetRawResponse());
                return Response.FromValue(new NetAppVolumeBackupResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/capacityPools/{poolName}/volumes/{volumeName}/backups/{backupName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Backups_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="backupName"> The name of the backup. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="backupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="backupName"/> is null. </exception>
        public virtual NullableResponse<NetAppVolumeBackupResource> GetIfExists(string backupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(backupName, nameof(backupName));

            using var scope = _netAppVolumeBackupBackupsClientDiagnostics.CreateScope("NetAppVolumeBackupCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _netAppVolumeBackupBackupsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Parent.Name, Id.Parent.Name, Id.Name, backupName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<NetAppVolumeBackupResource>(response.GetRawResponse());
                return Response.FromValue(new NetAppVolumeBackupResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<NetAppVolumeBackupResource> IEnumerable<NetAppVolumeBackupResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<NetAppVolumeBackupResource> IAsyncEnumerable<NetAppVolumeBackupResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
