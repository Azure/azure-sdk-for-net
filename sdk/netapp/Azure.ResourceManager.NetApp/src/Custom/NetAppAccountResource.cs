// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.NetApp;
using Azure.ResourceManager.NetApp.Models;

namespace Azure.ResourceManager.NetApp
{
    public partial class NetAppAccountResource: ArmResource
    {
        private VaultsRestOperations _vaultsRestClient;
        private ClientDiagnostics _vaultsClientDiagnostics;

        private ClientDiagnostics VaultsClientDiagnostics => _vaultsClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.NetApp", NetAppAccountResource.ResourceType.Namespace, Diagnostics);
        private VaultsRestOperations VaultsRestClient => _vaultsRestClient ??= new VaultsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, GetApiVersionOrNull(NetAppAccountResource.ResourceType));

        //        //
        //        /// <summary> Initializes a new instance of the <see cref="NetAppAccountResource"/> class. </summary>
        //        /// <param name="client"> The client parameters to use in these operations. </param>
        //        /// <param name="id"> The identifier of the resource that is the target of operations. </param>
        //        internal NetAppAccountResource(ArmClient client, ResourceIdentifier id) : base(client, id)
        //        {
        //            _netAppAccountAccountsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.NetApp", ResourceType.Namespace, Diagnostics);
        //            TryGetApiVersion(ResourceType, out string netAppAccountAccountsApiVersion);
        //            _netAppAccountAccountsRestClient = new AccountsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, netAppAccountAccountsApiVersion);
        //            _vaultsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.NetApp", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        //            _vaultsRestClient = new VaultsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint);
        //            _netAppVolumeGroupVolumeGroupsClientDiagnostics = new ClientDiagnostics("Azure.ResourceManager.NetApp", NetAppVolumeGroupResource.ResourceType.Namespace, Diagnostics);
        //            TryGetApiVersion(NetAppVolumeGroupResource.ResourceType, out string netAppVolumeGroupVolumeGroupsApiVersion);
        //            _netAppVolumeGroupVolumeGroupsRestClient = new VolumeGroupsRestOperations(Pipeline, Diagnostics.ApplicationId, Endpoint, netAppVolumeGroupVolumeGroupsApiVersion);
        //#if DEBUG
        //            ValidateResourceId(Id);
        //#endif
        //        }
        private string GetApiVersionOrNull(ResourceType resourceType)
        {
            TryGetApiVersion(resourceType, out string apiVersion);
            return apiVersion;
        }

        /// <summary>
        /// List vaults for a Netapp Account
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/vaults</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Vaults_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="NetAppVault" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<NetAppVault> GetVaultsAsync(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => VaultsRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            return PageableHelpers.CreateAsyncPageable(FirstPageRequest, null, NetAppVault.DeserializeNetAppVault, VaultsClientDiagnostics, Pipeline, "NetAppAccountResource.GetVaults", "value", null, cancellationToken);
        }

        /// <summary>
        /// List vaults for a Netapp Account
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.NetApp/netAppAccounts/{accountName}/vaults</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Vaults_List</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="NetAppVault" /> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<NetAppVault> GetVaults(CancellationToken cancellationToken = default)
        {
            HttpMessage FirstPageRequest(int? pageSizeHint) => VaultsRestClient.CreateListRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name);
            return PageableHelpers.CreatePageable(FirstPageRequest, null, NetAppVault.DeserializeNetAppVault, VaultsClientDiagnostics, Pipeline, "NetAppAccountResource.GetVaults", "value", null, cancellationToken);
        }
    }
}
