// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Resources;
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

        private static ResourceIdentifier CreateExtendedResourceIdentifier(ResourceIdentifier resourceGroupId, string resourceNamespace, string resourceType, string resourceName)
            => new ResourceIdentifier($"{resourceGroupId}/providers/{resourceNamespace}/{resourceType}/{resourceName}");

        /// <summary> Gets alerts across all Security Center locations for this resource group. </summary>
        public virtual AsyncPageable<SecurityAlertData> GetAlertsByResourceGroupAsync(CancellationToken cancellationToken = default)
            => new ResourceGroupAlertsAsyncPageable(Client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{Id.SubscriptionId}")), this, cancellationToken);

        /// <summary> Gets alerts across all Security Center locations for this resource group. </summary>
        public virtual Pageable<SecurityAlertData> GetAlertsByResourceGroup(CancellationToken cancellationToken = default)
            => new ResourceGroupAlertsPageable(Client.GetSubscriptionResource(new ResourceIdentifier($"/subscriptions/{Id.SubscriptionId}")), this, cancellationToken);

        /// <summary> Gets JIT network access policies across all Security Center locations for this resource group. </summary>
        public virtual AsyncPageable<JitNetworkAccessPolicyResource> GetJitNetworkAccessPoliciesAsync(CancellationToken cancellationToken = default)
            => GetJitNetworkAccessPoliciesByResourceGroupAsync(cancellationToken);

        /// <summary> Gets JIT network access policies across all Security Center locations for this resource group. </summary>
        public virtual Pageable<JitNetworkAccessPolicyResource> GetJitNetworkAccessPolicies(CancellationToken cancellationToken = default)
            => GetJitNetworkAccessPoliciesByResourceGroup(cancellationToken);

        private sealed class ResourceGroupAlertsPageable : Pageable<SecurityAlertData>
        {
            private readonly SubscriptionResource _subscriptionResource;
            private readonly MockableSecurityCenterResourceGroupResource _resourceGroupResource;
            private readonly CancellationToken _cancellationToken;

            public ResourceGroupAlertsPageable(SubscriptionResource subscriptionResource, MockableSecurityCenterResourceGroupResource resourceGroupResource, CancellationToken cancellationToken)
            {
                _subscriptionResource = subscriptionResource;
                _resourceGroupResource = resourceGroupResource;
                _cancellationToken = cancellationToken;
            }

            public override IEnumerable<Page<SecurityAlertData>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                foreach (SecurityCenterLocationResource location in _subscriptionResource.GetSecurityCenterLocations().GetAll(_cancellationToken))
                {
                    foreach (Page<ResourceGroupSecurityAlertResource> page in _resourceGroupResource.GetResourceGroupSecurityAlerts(location.Id.Name).GetAll(_cancellationToken).AsPages(continuationToken, pageSizeHint))
                    {
                        List<SecurityAlertData> values = new List<SecurityAlertData>();
                        foreach (ResourceGroupSecurityAlertResource alert in page.Values)
                        {
                            values.Add(alert.Data);
                        }
                        yield return Page<SecurityAlertData>.FromValues(values, page.ContinuationToken, page.GetRawResponse());
                    }
                }
            }
        }

        private sealed class ResourceGroupAlertsAsyncPageable : AsyncPageable<SecurityAlertData>
        {
            private readonly SubscriptionResource _subscriptionResource;
            private readonly MockableSecurityCenterResourceGroupResource _resourceGroupResource;
            private readonly CancellationToken _cancellationToken;

            public ResourceGroupAlertsAsyncPageable(SubscriptionResource subscriptionResource, MockableSecurityCenterResourceGroupResource resourceGroupResource, CancellationToken cancellationToken)
            {
                _subscriptionResource = subscriptionResource;
                _resourceGroupResource = resourceGroupResource;
                _cancellationToken = cancellationToken;
            }

            public override async IAsyncEnumerable<Page<SecurityAlertData>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                await foreach (SecurityCenterLocationResource location in _subscriptionResource.GetSecurityCenterLocations().GetAllAsync(_cancellationToken).ConfigureAwait(false))
                {
                    await foreach (Page<ResourceGroupSecurityAlertResource> page in _resourceGroupResource.GetResourceGroupSecurityAlerts(location.Id.Name).GetAllAsync(_cancellationToken).AsPages(continuationToken, pageSizeHint).ConfigureAwait(false))
                    {
                        List<SecurityAlertData> values = new List<SecurityAlertData>();
                        foreach (ResourceGroupSecurityAlertResource alert in page.Values)
                        {
                            values.Add(alert.Data);
                        }
                        yield return Page<SecurityAlertData>.FromValues(values, page.ContinuationToken, page.GetRawResponse());
                    }
                }
            }
        }

        /// <summary> Gets a server vulnerability assessment on an extended resource. </summary>
        public virtual Task<Response<ServerVulnerabilityAssessmentResource>> GetServerVulnerabilityAssessmentAsync(string resourceNamespace, string resourceType, string resourceName, CancellationToken cancellationToken = default)
            => Client.GetServerVulnerabilityAssessment(CreateExtendedResourceIdentifier(Id, resourceNamespace, resourceType, resourceName)).GetAsync(cancellationToken);

        /// <summary> Gets a server vulnerability assessment on an extended resource. </summary>
        public virtual Response<ServerVulnerabilityAssessmentResource> GetServerVulnerabilityAssessment(string resourceNamespace, string resourceType, string resourceName, CancellationToken cancellationToken = default)
            => Client.GetServerVulnerabilityAssessment(CreateExtendedResourceIdentifier(Id, resourceNamespace, resourceType, resourceName)).Get(cancellationToken);

        /// <summary> Gets a server vulnerability assessment compatibility collection on an extended resource. </summary>
        public virtual ServerVulnerabilityAssessmentCollection GetServerVulnerabilityAssessments(string resourceNamespace, string resourceType, string resourceName)
            => new ServerVulnerabilityAssessmentCollection(Client, CreateExtendedResourceIdentifier(Id, resourceNamespace, resourceType, resourceName));

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
