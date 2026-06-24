// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Text.Json;
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
        private ClientDiagnostics _discoveredSecuritySolutionsClientDiagnostics;
        private DiscoveredSecuritySolutions _discoveredSecuritySolutionsRestClient;
        private ClientDiagnostics _securitySolutionsClientDiagnostics;
        private SecuritySolutions _securitySolutionsRestClient;
        private ClientDiagnostics _topologyClientDiagnostics;
        private Topology _topologyRestClient;

        private ClientDiagnostics AllowedConnectionsClientDiagnostics => _allowedConnectionsClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.SecurityCenter.Mocking", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private AllowedConnections AllowedConnectionsRestClient => _allowedConnectionsRestClient ??= new AllowedConnections(AllowedConnectionsClientDiagnostics, Pipeline, Endpoint, "2020-01-01");
        private ClientDiagnostics DiscoveredSecuritySolutionsClientDiagnostics => _discoveredSecuritySolutionsClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.SecurityCenter.Mocking", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private DiscoveredSecuritySolutions DiscoveredSecuritySolutionsRestClient => _discoveredSecuritySolutionsRestClient ??= new DiscoveredSecuritySolutions(DiscoveredSecuritySolutionsClientDiagnostics, Pipeline, Endpoint, "2020-01-01");
        private ClientDiagnostics SecuritySolutionsClientDiagnostics => _securitySolutionsClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.SecurityCenter.Mocking", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private SecuritySolutions SecuritySolutionsRestClient => _securitySolutionsRestClient ??= new SecuritySolutions(SecuritySolutionsClientDiagnostics, Pipeline, Endpoint, "2020-01-01");
        private ClientDiagnostics TopologyClientDiagnostics => _topologyClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.SecurityCenter.Mocking", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private Topology TopologyRestClient => _topologyRestClient ??= new Topology(TopologyClientDiagnostics, Pipeline, Endpoint, "2020-01-01");

        /// <summary> Gets a specific discovered security solution. </summary>
        /// <param name="ascLocation"> The location where ASC stores the data of the subscription. </param>
        /// <param name="discoveredSecuritySolutionName"> Name of a discovered security solution. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<DiscoveredSecuritySolution>> GetDiscoveredSecuritySolutionAsync(AzureLocation ascLocation, string discoveredSecuritySolutionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(discoveredSecuritySolutionName, nameof(discoveredSecuritySolutionName));

            using DiagnosticScope scope = DiscoveredSecuritySolutionsClientDiagnostics.CreateScope("ResourceGroupResource.GetDiscoveredSecuritySolution");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = DiscoveredSecuritySolutionsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, ascLocation, discoveredSecuritySolutionName, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                return Response.FromValue(DeserializeDiscoveredSecuritySolution(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a specific discovered security solution. </summary>
        /// <param name="ascLocation"> The location where ASC stores the data of the subscription. </param>
        /// <param name="discoveredSecuritySolutionName"> Name of a discovered security solution. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<DiscoveredSecuritySolution> GetDiscoveredSecuritySolution(AzureLocation ascLocation, string discoveredSecuritySolutionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(discoveredSecuritySolutionName, nameof(discoveredSecuritySolutionName));

            using DiagnosticScope scope = DiscoveredSecuritySolutionsClientDiagnostics.CreateScope("ResourceGroupResource.GetDiscoveredSecuritySolution");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = DiscoveredSecuritySolutionsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, ascLocation, discoveredSecuritySolutionName, context);
                Response response = Pipeline.ProcessMessage(message, context);
                return Response.FromValue(DeserializeDiscoveredSecuritySolution(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a specific security solution. </summary>
        /// <param name="ascLocation"> The location where ASC stores the data of the subscription. </param>
        /// <param name="securitySolutionName"> Name of the security solution. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SecuritySolution>> GetSecuritySolutionAsync(AzureLocation ascLocation, string securitySolutionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(securitySolutionName, nameof(securitySolutionName));

            using DiagnosticScope scope = SecuritySolutionsClientDiagnostics.CreateScope("ResourceGroupResource.GetSecuritySolution");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = SecuritySolutionsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, ascLocation, securitySolutionName, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                return Response.FromValue(DeserializeSecuritySolution(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a specific security solution. </summary>
        /// <param name="ascLocation"> The location where ASC stores the data of the subscription. </param>
        /// <param name="securitySolutionName"> Name of the security solution. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SecuritySolution> GetSecuritySolution(AzureLocation ascLocation, string securitySolutionName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(securitySolutionName, nameof(securitySolutionName));

            using DiagnosticScope scope = SecuritySolutionsClientDiagnostics.CreateScope("ResourceGroupResource.GetSecuritySolution");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = SecuritySolutionsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, ascLocation, securitySolutionName, context);
                Response response = Pipeline.ProcessMessage(message, context);
                return Response.FromValue(DeserializeSecuritySolution(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a specific topology component. </summary>
        /// <param name="ascLocation"> The location where ASC stores the data of the subscription. </param>
        /// <param name="topologyResourceName"> Name of a topology resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SecurityTopologyResource>> GetTopologyAsync(AzureLocation ascLocation, string topologyResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(topologyResourceName, nameof(topologyResourceName));

            using DiagnosticScope scope = TopologyClientDiagnostics.CreateScope("ResourceGroupResource.GetTopology");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = TopologyRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, ascLocation, topologyResourceName, context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                return Response.FromValue(DeserializeSecurityTopologyResource(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets a specific topology component. </summary>
        /// <param name="ascLocation"> The location where ASC stores the data of the subscription. </param>
        /// <param name="topologyResourceName"> Name of a topology resource. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SecurityTopologyResource> GetTopology(AzureLocation ascLocation, string topologyResourceName, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(topologyResourceName, nameof(topologyResourceName));

            using DiagnosticScope scope = TopologyClientDiagnostics.CreateScope("ResourceGroupResource.GetTopology");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = TopologyRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, ascLocation, topologyResourceName, context);
                Response response = Pipeline.ProcessMessage(message, context);
                return Response.FromValue(DeserializeSecurityTopologyResource(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets allowed traffic between Azure resources based on connection type. </summary>
        /// <param name="ascLocation"> The location where ASC stores the data of the subscription. </param>
        /// <param name="connectionType"> The allowed connection type. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<SecurityCenterAllowedConnection>> GetAllowedConnectionAsync(AzureLocation ascLocation, SecurityCenterConnectionType connectionType, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = AllowedConnectionsClientDiagnostics.CreateScope("ResourceGroupResource.GetAllowedConnection");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = AllowedConnectionsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, ascLocation, connectionType.ToString(), context);
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                return Response.FromValue(DeserializeSecurityCenterAllowedConnection(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Gets allowed traffic between Azure resources based on connection type. </summary>
        /// <param name="ascLocation"> The location where ASC stores the data of the subscription. </param>
        /// <param name="connectionType"> The allowed connection type. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<SecurityCenterAllowedConnection> GetAllowedConnection(AzureLocation ascLocation, SecurityCenterConnectionType connectionType, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = AllowedConnectionsClientDiagnostics.CreateScope("ResourceGroupResource.GetAllowedConnection");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = AllowedConnectionsRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, ascLocation, connectionType.ToString(), context);
                Response response = Pipeline.ProcessMessage(message, context);
                return Response.FromValue(DeserializeSecurityCenterAllowedConnection(response), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private static DiscoveredSecuritySolution DeserializeDiscoveredSecuritySolution(Response response)
        {
            using JsonDocument document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return DiscoveredSecuritySolution.DeserializeDiscoveredSecuritySolution(document.RootElement, ModelSerializationExtensions.WireOptions);
        }

        private static SecuritySolution DeserializeSecuritySolution(Response response)
        {
            using JsonDocument document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return SecuritySolution.DeserializeSecuritySolution(document.RootElement, ModelSerializationExtensions.WireOptions);
        }

        private static SecurityTopologyResource DeserializeSecurityTopologyResource(Response response)
        {
            using JsonDocument document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return SecurityTopologyResource.DeserializeSecurityTopologyResource(document.RootElement, ModelSerializationExtensions.WireOptions);
        }

        private static SecurityCenterAllowedConnection DeserializeSecurityCenterAllowedConnection(Response response)
        {
            using JsonDocument document = JsonDocument.Parse(response.Content, ModelSerializationExtensions.JsonDocumentOptions);
            return SecurityCenterAllowedConnection.DeserializeSecurityCenterAllowedConnection(document.RootElement, ModelSerializationExtensions.WireOptions);
        }
    }
}
