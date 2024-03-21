// Copyright (c) Microsoft Corporation. All rights reserved.
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
    /// A class representing a collection of <see cref="NetAppAccountBackupResource" /> and their operations.
    /// Each <see cref="NetAppAccountBackupResource" /> in the collection will belong to the same instance of <see cref="NetAppAccountResource" />.
    /// To get a <see cref="NetAppAccountBackupCollection" /> instance call the GetNetAppAccountBackups method from an instance of <see cref="NetAppAccountResource" />.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    public partial class NetAppAccountBackupCollection : ArmCollection, IEnumerable<NetAppAccountBackupResource>, IAsyncEnumerable<NetAppAccountBackupResource>
    {
        private readonly ClientDiagnostics _netAppAccountBackupAccountBackupsClientDiagnostics;
        private readonly AccountBackupsRestOperations _netAppAccountBackupAccountBackupsRestClient;

        /// <summary> Initializes a new instance of the <see cref="NetAppAccountBackupCollection"/> class for mocking. </summary>
        protected NetAppAccountBackupCollection()
        {
        }

        /// <summary> Initializes a new instance of the <see cref="NetAppAccountBackupCollection"/> class. </summary>
        /// <param name="client"> The client parameters to use in these operations. </param>
        /// <param name="id"> The identifier of the parent resource that is the target of operations. </param>
        internal NetAppAccountBackupCollection(ArmClient client, ResourceIdentifier id) : base(client, id)
        {
            _netAppAccountBackupAccountBackupsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.NetApp", NetAppAccountBackupResource.ResourceType.Namespace, Diagnostics);
            TryGetApiVersion(NetAppAccountBackupResource.ResourceType, out string netAppAccountBackupAccountBackupsApiVersion);
            _netAppAccountBackupAccountBackupsRestClient = new AccountBackupsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, netAppAccountBackupAccountBackupsApiVersion);
#if DEBUG
            ValidateResourceId(Id);
#endif
        }

        internal static void ValidateResourceId(ResourceIdentifier id)
        {
            if (id.ResourceType != NetAppAccountResource.ResourceType)
                throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, "Invalid resource type {0} expected {1}", id.ResourceType, NetAppAccountResource.ResourceType), nameof(id));
        }

        /// <summary>
        /// Gets the specified backup for a Netapp Account
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/accountBackups/{backupName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AccountBackups_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="backupName"> The name of the backup. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="backupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="backupName"/> is null. </exception>
        public virtual async Task<Response<NetAppAccountBackupResource>> GetAsync(string backupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(backupName, nameof(backupName));

            using var scope = _netAppAccountBackupAccountBackupsClientDiagnostics.CreateScope("NetAppAccountBackupCollection.Get");
            scope.Start();
            try
            {
                var response = await _netAppAccountBackupAccountBackupsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, backupName, cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new NetAppAccountBackupResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the specified backup for a Netapp Account
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/accountBackups/{backupName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AccountBackups_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="backupName"> The name of the backup. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="backupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="backupName"/> is null. </exception>
        public virtual Response<NetAppAccountBackupResource> Get(string backupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(backupName, nameof(backupName));

            using var scope = _netAppAccountBackupAccountBackupsClientDiagnostics.CreateScope("NetAppAccountBackupCollection.Get");
            scope.Start();
            try
            {
                var response = _netAppAccountBackupAccountBackupsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, backupName, cancellationToken);
                if (response.Value == null)
                    throw new RequestFailedException(response.GetRawResponse());
                return Response.FromValue(new NetAppAccountBackupResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// List all Backups for a Netapp Account
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/accountBackups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AccountBackups_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="NetAppAccountBackupResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<NetAppAccountBackupResource> GetAllAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _netAppAccountBackupAccountBackupsRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, null, e => new NetAppAccountBackupResource(Client, NetAppBackupData.DeserializeNetAppBackupData(e)), _netAppAccountBackupAccountBackupsClientDiagnostics, Pipeline, "NetAppAccountBackupCollection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// List all Backups for a Netapp Account
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/accountBackups</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AccountBackups_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="NetAppAccountBackupResource" /> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<NetAppAccountBackupResource> GetAll(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => _netAppAccountBackupAccountBackupsRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, null, e => new NetAppAccountBackupResource(Client, NetAppBackupData.DeserializeNetAppBackupData(e)), _netAppAccountBackupAccountBackupsClientDiagnostics, Pipeline, "NetAppAccountBackupCollection.GetAll", "value", null, cancellationToken);
        }

        /// <summary>
        /// Checks to see if the resource exists in azure.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/accountBackups/{backupName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AccountBackups_Get</description>
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

            using var scope = _netAppAccountBackupAccountBackupsClientDiagnostics.CreateScope("NetAppAccountBackupCollection.Exists");
            scope.Start();
            try
            {
                var response = await _netAppAccountBackupAccountBackupsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, backupName, cancellationToken: cancellationToken).ConfigureAwait(false);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/accountBackups/{backupName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AccountBackups_Get</description>
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

            using var scope = _netAppAccountBackupAccountBackupsClientDiagnostics.CreateScope("NetAppAccountBackupCollection.Exists");
            scope.Start();
            try
            {
                var response = _netAppAccountBackupAccountBackupsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, backupName, cancellationToken: cancellationToken);
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/accountBackups/{backupName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AccountBackups_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="backupName"> The name of the backup. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="backupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="backupName"/> is null. </exception>
        public virtual async Task<NullableResponse<NetAppAccountBackupResource>> GetIfExistsAsync(string backupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(backupName, nameof(backupName));

            using var scope = _netAppAccountBackupAccountBackupsClientDiagnostics.CreateScope("NetAppAccountBackupCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = await _netAppAccountBackupAccountBackupsRestClient.GetAsync(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, backupName, cancellationToken: cancellationToken).ConfigureAwait(false);
                if (response.Value == null)
                    return new NoValueResponse<NetAppAccountBackupResource>(response.GetRawResponse());
                return Response.FromValue(new NetAppAccountBackupResource(Client, response.Value), response.GetRawResponse());
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
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/accountBackups/{backupName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>AccountBackups_Get</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="backupName"> The name of the backup. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentException"> <paramref name="backupName"/> is an empty string, and was expected to be non-empty. </exception>
        /// <exception cref="ArgumentNullException"> <paramref name="backupName"/> is null. </exception>
        public virtual NullableResponse<NetAppAccountBackupResource> GetIfExists(string backupName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(backupName, nameof(backupName));

            using var scope = _netAppAccountBackupAccountBackupsClientDiagnostics.CreateScope("NetAppAccountBackupCollection.GetIfExists");
            scope.Start();
            try
            {
                var response = _netAppAccountBackupAccountBackupsRestClient.Get(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, backupName, cancellationToken: cancellationToken);
                if (response.Value == null)
                    return new NoValueResponse<NetAppAccountBackupResource>(response.GetRawResponse());
                return Response.FromValue(new NetAppAccountBackupResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        IEnumerator<NetAppAccountBackupResource> IEnumerable<NetAppAccountBackupResource>.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetAll().GetEnumerator();
        }

        IAsyncEnumerator<NetAppAccountBackupResource> IAsyncEnumerable<NetAppAccountBackupResource>.GetAsyncEnumerator(CancellationToken cancellationToken)
        {
            return GetAllAsync(cancellationToken: cancellationToken).GetAsyncEnumerator(cancellationToken);
        }
    }
}
