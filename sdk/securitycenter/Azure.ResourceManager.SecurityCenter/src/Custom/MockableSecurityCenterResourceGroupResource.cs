// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter.Mocking
{
    public partial class MockableSecurityCenterResourceGroupResource
    {
        private ClientDiagnostics _allowedConnectionsClientDiagnostics;
        private AllowedConnections _allowedConnectionsRestClient;
        private ClientDiagnostics _topologyClientDiagnostics;
        private Topology _topologyRestClient;

        private ClientDiagnostics AllowedConnectionsClientDiagnostics => _allowedConnectionsClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.SecurityCenter.Mocking", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private AllowedConnections AllowedConnectionsRestClient => _allowedConnectionsRestClient ??= new AllowedConnections(AllowedConnectionsClientDiagnostics, Pipeline, Endpoint, "2020-01-01");
        private ClientDiagnostics TopologyClientDiagnostics => _topologyClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.SecurityCenter.Mocking", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private Topology TopologyRestClient => _topologyRestClient ??= new Topology(TopologyClientDiagnostics, Pipeline, Endpoint, "2020-01-01");

        /// <summary> Gets an allowed connection compatibility model. </summary>
        /// <param name="ascLocation"> The location where ASC stores the data of the subscription. </param>
        /// <param name="connectionType"> The allowed connection type. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SecurityCenterAllowedConnection>> GetAllowedConnectionAsync(AzureLocation ascLocation, SecurityCenterConnectionType connectionType, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            using DiagnosticScope scope = AllowedConnectionsClientDiagnostics.CreateScope("MockableSecurityCenterResourceGroupResource.GetAllowedConnection");
            scope.Start();
            try
            {
                Response response = await AllowedConnectionsRestClient.Pipeline.ProcessMessageAsync(AllowedConnectionsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.Name, ascLocation, connectionType.ToString(), context), context).ConfigureAwait(false);
                return Response.FromValue(new SecurityCenterAllowedConnection(SecurityCenterAllowedConnectionData.FromResponse(response)), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets an allowed connection compatibility model. </summary>
        /// <param name="ascLocation"> The location where ASC stores the data of the subscription. </param>
        /// <param name="connectionType"> The allowed connection type. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SecurityCenterAllowedConnection> GetAllowedConnection(AzureLocation ascLocation, SecurityCenterConnectionType connectionType, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            using DiagnosticScope scope = AllowedConnectionsClientDiagnostics.CreateScope("MockableSecurityCenterResourceGroupResource.GetAllowedConnection");
            scope.Start();
            try
            {
                Response response = AllowedConnectionsRestClient.Pipeline.ProcessMessage(AllowedConnectionsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.Name, ascLocation, connectionType.ToString(), context), context);
                return Response.FromValue(new SecurityCenterAllowedConnection(SecurityCenterAllowedConnectionData.FromResponse(response)), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a topology compatibility model. </summary>
        /// <param name="ascLocation"> The location where ASC stores the data of the subscription. </param>
        /// <param name="topologyResourceName"> Name of a topology resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<Models.SecurityTopologyResource>> GetTopologyAsync(AzureLocation ascLocation, string topologyResourceName, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            using DiagnosticScope scope = TopologyClientDiagnostics.CreateScope("MockableSecurityCenterResourceGroupResource.GetTopology");
            scope.Start();
            try
            {
                Response response = await TopologyRestClient.Pipeline.ProcessMessageAsync(TopologyRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.Name, ascLocation, topologyResourceName, context), context).ConfigureAwait(false);
                return Response.FromValue(new Models.SecurityTopologyResource(SecurityTopologyResourceData.FromResponse(response)), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a topology compatibility model. </summary>
        /// <param name="ascLocation"> The location where ASC stores the data of the subscription. </param>
        /// <param name="topologyResourceName"> Name of a topology resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<Models.SecurityTopologyResource> GetTopology(AzureLocation ascLocation, string topologyResourceName, CancellationToken cancellationToken = default)
        {
            RequestContext context = new RequestContext { CancellationToken = cancellationToken };
            using DiagnosticScope scope = TopologyClientDiagnostics.CreateScope("MockableSecurityCenterResourceGroupResource.GetTopology");
            scope.Start();
            try
            {
                Response response = TopologyRestClient.Pipeline.ProcessMessage(TopologyRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.Name, ascLocation, topologyResourceName, context), context);
                return Response.FromValue(new Models.SecurityTopologyResource(SecurityTopologyResourceData.FromResponse(response)), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
