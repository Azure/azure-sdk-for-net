// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.Resources;
using Azure.ResourceManager.SecurityCenter.Models;

namespace Azure.ResourceManager.SecurityCenter.Mocking
{
    // Preserves GA resource-group mockable extension methods that aggregated location-scoped operations or accepted extended-resource path segments differently from the generated TypeSpec resource model.
    public partial class MockableSecurityCenterResourceGroupResource
    {
        private ClientDiagnostics _allowedConnectionsClientDiagnostics;
        private AllowedConnections _allowedConnectionsRestClient;
        private ClientDiagnostics _topologyClientDiagnostics;
        private TopologyResources _topologyRestClient;

        private ClientDiagnostics AllowedConnectionsClientDiagnostics => _allowedConnectionsClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.SecurityCenter.Mocking", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private AllowedConnections AllowedConnectionsRestClient => _allowedConnectionsRestClient ??= new AllowedConnections(AllowedConnectionsClientDiagnostics, Pipeline, Endpoint, "2020-01-01");
        private ClientDiagnostics TopologyClientDiagnostics => _topologyClientDiagnostics ??= new ClientDiagnostics("Azure.ResourceManager.SecurityCenter.Mocking", ProviderConstants.DefaultProviderNamespace, Diagnostics);
        private TopologyResources TopologyRestClient => _topologyRestClient ??= new TopologyResources(TopologyClientDiagnostics, Pipeline, Endpoint, "2020-01-01");

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

        /// <summary> Gets a server vulnerability assessment on an extended resource. </summary>
        public virtual Task<Response<ServerVulnerabilityAssessmentResource>> GetServerVulnerabilityAssessmentAsync(string resourceNamespace, string resourceType, string resourceName, CancellationToken cancellationToken = default)
            => Client.GetServerVulnerabilityAssessment(CreateExtendedResourceIdentifier(Id, resourceNamespace, resourceType, resourceName)).GetAsync(cancellationToken);

        /// <summary> Gets a server vulnerability assessment on an extended resource. </summary>
        public virtual Response<ServerVulnerabilityAssessmentResource> GetServerVulnerabilityAssessment(string resourceNamespace, string resourceType, string resourceName, CancellationToken cancellationToken = default)
            => Client.GetServerVulnerabilityAssessment(CreateExtendedResourceIdentifier(Id, resourceNamespace, resourceType, resourceName)).Get(cancellationToken);

        /// <summary> Gets a server vulnerability assessment compatibility collection on an extended resource. </summary>
        public virtual ServerVulnerabilityAssessmentCollection GetServerVulnerabilityAssessments(string resourceNamespace, string resourceType, string resourceName)
            => new ServerVulnerabilityAssessmentCollection(Client, CreateExtendedResourceIdentifier(Id, resourceNamespace, resourceType, resourceName));

        /// <summary> Gets an adaptive network hardening compatibility resource. </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Response<AdaptiveNetworkHardeningResource> GetAdaptiveNetworkHardening(string resourceNamespace, string resourceType, string resourceName, string adaptiveNetworkHardeningResourceName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetAdaptiveNetworkHardeningResource(ResourceIdentifier id) instead.");

        /// <summary> Gets an adaptive network hardening compatibility resource. </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Task<Response<AdaptiveNetworkHardeningResource>> GetAdaptiveNetworkHardeningAsync(string resourceNamespace, string resourceType, string resourceName, string adaptiveNetworkHardeningResourceName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetAdaptiveNetworkHardeningResource(ResourceIdentifier id) instead.");

        /// <summary> Gets an adaptive network hardening compatibility collection. </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual AdaptiveNetworkHardeningCollection GetAdaptiveNetworkHardenings(string resourceNamespace, string resourceType, string resourceName)
            => throw new NotSupportedException("This API is no longer supported by the service. No direct collection replacement is available.");

        /// <summary> Gets a custom assessment automation compatibility resource. </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Response<CustomAssessmentAutomationResource> GetCustomAssessmentAutomation(string customAssessmentAutomationName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetCustomAssessmentAutomations(ResourceIdentifier scope) instead.");

        /// <summary> Gets a custom assessment automation compatibility resource. </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Task<Response<CustomAssessmentAutomationResource>> GetCustomAssessmentAutomationAsync(string customAssessmentAutomationName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetCustomAssessmentAutomations(ResourceIdentifier scope) instead.");

        /// <summary> Gets a custom assessment automation compatibility collection. </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual CustomAssessmentAutomationCollection GetCustomAssessmentAutomations()
            => throw new NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetCustomAssessmentAutomations(ResourceIdentifier scope) instead.");

        /// <summary> Gets a custom entity store assignment compatibility resource. </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Response<CustomEntityStoreAssignmentResource> GetCustomEntityStoreAssignment(string customEntityStoreAssignmentName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetCustomEntityStoreAssignments(ResourceIdentifier scope) instead.");

        /// <summary> Gets a custom entity store assignment compatibility resource. </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Task<Response<CustomEntityStoreAssignmentResource>> GetCustomEntityStoreAssignmentAsync(string customEntityStoreAssignmentName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetCustomEntityStoreAssignments(ResourceIdentifier scope) instead.");

        /// <summary> Gets a custom entity store assignment compatibility collection. </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual CustomEntityStoreAssignmentCollection GetCustomEntityStoreAssignments()
            => throw new NotSupportedException("This API is no longer supported by the service. Use ArmClient.GetCustomEntityStoreAssignments(ResourceIdentifier scope) instead.");

        /// <summary> Gets a software inventory compatibility collection. </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual SoftwareInventoryCollection GetSoftwareInventories(string resourceNamespace, string resourceType, string resourceName)
            => throw new NotSupportedException("This API is no longer supported by the service. No direct replacement is available.");

        /// <summary> Gets a software inventory compatibility resource. </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Response<SoftwareInventoryResource> GetSoftwareInventory(string resourceNamespace, string resourceType, string resourceName, string softwareName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported by the service. No direct replacement is available.");

        /// <summary> Gets a software inventory compatibility resource. </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Task<Response<SoftwareInventoryResource>> GetSoftwareInventoryAsync(string resourceNamespace, string resourceType, string resourceName, string softwareName, CancellationToken cancellationToken = default)
            => throw new NotSupportedException("This API is no longer supported by the service. No direct replacement is available.");

        /// <summary> Gets an external security solution compatibility model. </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Task<Response<ExternalSecuritySolution>> GetExternalSecuritySolutionAsync(AzureLocation ascLocation, string externalSecuritySolutionsName, CancellationToken cancellationToken = default)
            => GetAsync(ascLocation, externalSecuritySolutionsName, cancellationToken);

        /// <summary> Gets an external security solution compatibility model. </summary>
        [System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
        public virtual Response<ExternalSecuritySolution> GetExternalSecuritySolution(AzureLocation ascLocation, string externalSecuritySolutionsName, CancellationToken cancellationToken = default)
            => Get(ascLocation, externalSecuritySolutionsName, cancellationToken);

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
                return Response.FromValue(new Models.SecurityTopologyResource(SecurityTopologyData.FromResponse(response)), response);
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
                return Response.FromValue(new Models.SecurityTopologyResource(SecurityTopologyData.FromResponse(response)), response);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
