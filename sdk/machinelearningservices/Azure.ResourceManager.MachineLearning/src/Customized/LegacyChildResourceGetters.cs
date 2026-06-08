// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

#pragma warning disable SA1402 // Backward-compat child-resource getters are grouped to keep related shims together.

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.MachineLearning.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning
{
    [CodeGenSuppress("GetOutboundNetworkDependenciesEndpointsAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetOutboundNetworkDependenciesEndpoints", typeof(CancellationToken))]
    public partial class MachineLearningWorkspaceResource
    {
        internal const string LegacyManagedNetworkName = "default";

        // Customized: preserve legacy MachineLearning-prefixed child resource getters.
        /// <summary> Deletes this workspace. </summary>
        [ForwardsClientCalls]
        public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken) => DeleteAsync(waitUntil, default(bool?), cancellationToken);
        /// <summary> Deletes this workspace. </summary>
        [ForwardsClientCalls]
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken) => Delete(waitUntil, default(bool?), cancellationToken);
        public virtual MachineLearningCodeContainerCollection GetMachineLearningCodeContainers() => GetCodeContainers();
        /// <summary> Gets a code container. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningCodeContainerResource>> GetMachineLearningCodeContainerAsync(string name, CancellationToken cancellationToken = default) => GetCodeContainerAsync(name, cancellationToken);
        /// <summary> Gets a code container. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningCodeContainerResource> GetMachineLearningCodeContainer(string name, CancellationToken cancellationToken = default) => GetCodeContainer(name, cancellationToken);
        /// <summary> Gets component containers. </summary>
        public virtual MachineLearningComponentContainerCollection GetMachineLearningComponentContainers() => GetComponentContainers();
        /// <summary> Gets a component container. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningComponentContainerResource>> GetMachineLearningComponentContainerAsync(string name, CancellationToken cancellationToken = default) => GetComponentContainerAsync(name, cancellationToken);
        /// <summary> Gets a component container. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningComponentContainerResource> GetMachineLearningComponentContainer(string name, CancellationToken cancellationToken = default) => GetComponentContainer(name, cancellationToken);
        /// <summary> Gets data containers. </summary>
        public virtual MachineLearningDataContainerCollection GetMachineLearningDataContainers() => GetDataContainers();
        /// <summary> Gets a data container. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningDataContainerResource>> GetMachineLearningDataContainerAsync(string name, CancellationToken cancellationToken = default) => GetDataContainerAsync(name, cancellationToken);
        /// <summary> Gets a data container. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningDataContainerResource> GetMachineLearningDataContainer(string name, CancellationToken cancellationToken = default) => GetDataContainer(name, cancellationToken);
        /// <summary> Gets environment containers. </summary>
        public virtual MachineLearningEnvironmentContainerCollection GetMachineLearningEnvironmentContainers() => GetEnvironmentContainers();
        /// <summary> Gets an environment container. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningEnvironmentContainerResource>> GetMachineLearningEnvironmentContainerAsync(string name, CancellationToken cancellationToken = default) => GetEnvironmentContainerAsync(name, cancellationToken);
        /// <summary> Gets an environment container. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningEnvironmentContainerResource> GetMachineLearningEnvironmentContainer(string name, CancellationToken cancellationToken = default) => GetEnvironmentContainer(name, cancellationToken);
        /// <summary> Gets model containers. </summary>
        public virtual MachineLearningModelContainerCollection GetMachineLearningModelContainers() => GetModelContainers();
        /// <summary> Gets a model container. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningModelContainerResource>> GetMachineLearningModelContainerAsync(string name, CancellationToken cancellationToken = default) => GetModelContainerAsync(name, cancellationToken);
        /// <summary> Gets a model container. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningModelContainerResource> GetMachineLearningModelContainer(string name, CancellationToken cancellationToken = default) => GetModelContainer(name, cancellationToken);
        /// <summary> Gets compute resources. </summary>
        public virtual MachineLearningComputeCollection GetMachineLearningComputes() => GetComputeResources();
        /// <summary> Gets a compute resource. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningComputeResource>> GetMachineLearningComputeAsync(string computeName, CancellationToken cancellationToken = default) => GetComputeResourceAsync(computeName, cancellationToken);
        /// <summary> Gets a compute resource. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningComputeResource> GetMachineLearningCompute(string computeName, CancellationToken cancellationToken = default) => GetComputeResource(computeName, cancellationToken);
        /// <summary> Gets jobs. </summary>
        public virtual MachineLearningJobCollection GetMachineLearningJobs() => GetJobBases();
        /// <summary> Gets a job. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningJobResource>> GetMachineLearningJobAsync(string id, CancellationToken cancellationToken = default) => GetJobBaseAsync(id, cancellationToken);
        /// <summary> Gets a job. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningJobResource> GetMachineLearningJob(string id, CancellationToken cancellationToken = default) => GetJobBase(id, cancellationToken);
        /// <summary> Gets workspace connections. </summary>
        public virtual MachineLearningWorkspaceConnectionCollection GetMachineLearningWorkspaceConnections() => GetWorkspaceConnectionPropertiesV2BasicResources();
        /// <summary> Gets a workspace connection. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningWorkspaceConnectionResource>> GetMachineLearningWorkspaceConnectionAsync(string connectionName, CancellationToken cancellationToken = default) => GetWorkspaceConnectionPropertiesV2BasicResourceAsync(connectionName, cancellationToken);
        /// <summary> Gets a workspace connection. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningWorkspaceConnectionResource> GetMachineLearningWorkspaceConnection(string connectionName, CancellationToken cancellationToken = default) => GetWorkspaceConnectionPropertiesV2BasicResource(connectionName, cancellationToken);
        /// <summary> Gets outbound rules. </summary>
        public virtual MachineLearningOutboundRuleBasicCollection GetMachineLearningOutboundRuleBasics()
        {
            ResourceIdentifier managedNetworkId = ManagedNetworkSettingsPropertiesBasicResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, LegacyManagedNetworkName);
            return new MachineLearningOutboundRuleBasicCollection(Client, managedNetworkId);
        }
        /// <summary> Gets an outbound rule. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningOutboundRuleBasicResource>> GetMachineLearningOutboundRuleBasicAsync(string ruleName, CancellationToken cancellationToken = default) => GetMachineLearningOutboundRuleBasics().GetAsync(ruleName, cancellationToken);
        /// <summary> Gets an outbound rule. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningOutboundRuleBasicResource> GetMachineLearningOutboundRuleBasic(string ruleName, CancellationToken cancellationToken = default) => GetMachineLearningOutboundRuleBasics().Get(ruleName, cancellationToken);
        /// <summary> Called by Client (Portal, CLI, etc) to get a list of all external outbound dependencies (FQDNs) programmatically. </summary>
        public virtual AsyncPageable<MachineLearningFqdnEndpoints> GetOutboundNetworkDependenciesEndpointsAsync(CancellationToken cancellationToken = default) => new OutboundNetworkDependenciesEndpointsAsyncPageable(this, cancellationToken);
        /// <summary> Called by Client (Portal, CLI, etc) to get a list of all external outbound dependencies (FQDNs) programmatically. </summary>
        public virtual Pageable<MachineLearningFqdnEndpoints> GetOutboundNetworkDependenciesEndpoints(CancellationToken cancellationToken = default)
        {
            Response<ExternalFQDNResponse> response = GetOutboundNetworkDependenciesEndpointsResponse(cancellationToken);
            return Pageable<MachineLearningFqdnEndpoints>.FromPages(new[]
            {
                Page<MachineLearningFqdnEndpoints>.FromValues(ToFqdnEndpoints(response.Value), null, response.GetRawResponse())
            });
        }
        /// <summary> Provisions the managed network. </summary>
        [ForwardsClientCalls]
        public virtual Task<ArmOperation<Models.ManagedNetworkProvisionStatus>> ProvisionManagedNetworkManagedNetworkProvisionAsync(WaitUntil waitUntil, Models.ManagedNetworkProvisionContent content, CancellationToken cancellationToken = default) => ProvisionManagedNetworkAsync(waitUntil, content, cancellationToken);
        /// <summary> Provisions the managed network. </summary>
        [ForwardsClientCalls]
        public virtual ArmOperation<Models.ManagedNetworkProvisionStatus> ProvisionManagedNetworkManagedNetworkProvision(WaitUntil waitUntil, Models.ManagedNetworkProvisionContent content, CancellationToken cancellationToken = default) => ProvisionManagedNetwork(waitUntil, content, cancellationToken);

        private async Task<Response<ExternalFQDNResponse>> GetOutboundNetworkDependenciesEndpointsResponseAsync(CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _workspacesClientDiagnostics.CreateScope("MachineLearningWorkspaceResource.GetOutboundNetworkDependenciesEndpoints");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _workspacesRestClient.CreateGetOutboundNetworkDependenciesEndpointsRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                return Response.FromValue(ExternalFQDNResponse.FromResponse(result), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Response<ExternalFQDNResponse> GetOutboundNetworkDependenciesEndpointsResponse(CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _workspacesClientDiagnostics.CreateScope("MachineLearningWorkspaceResource.GetOutboundNetworkDependenciesEndpoints");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _workspacesRestClient.CreateGetOutboundNetworkDependenciesEndpointsRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response result = Pipeline.ProcessMessage(message, context);
                return Response.FromValue(ExternalFQDNResponse.FromResponse(result), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private static IReadOnlyList<MachineLearningFqdnEndpoints> ToFqdnEndpoints(ExternalFQDNResponse response)
        {
            List<MachineLearningFqdnEndpoints> endpoints = new List<MachineLearningFqdnEndpoints>();
            if (response?.Value is null)
            {
                return endpoints;
            }

            foreach (FQDNEndpointsPropertyBag item in response.Value)
            {
                if (item?.Properties is not null)
                {
                    endpoints.Add(item.Properties);
                }
            }

            return endpoints;
        }

        private sealed class OutboundNetworkDependenciesEndpointsAsyncPageable : AsyncPageable<MachineLearningFqdnEndpoints>
        {
            private readonly MachineLearningWorkspaceResource _workspace;

            public OutboundNetworkDependenciesEndpointsAsyncPageable(MachineLearningWorkspaceResource workspace, CancellationToken cancellationToken)
                : base(cancellationToken)
            {
                _workspace = workspace;
            }

            public override async IAsyncEnumerable<Page<MachineLearningFqdnEndpoints>> AsPages(string continuationToken = null, int? pageSizeHint = null)
            {
                Response<ExternalFQDNResponse> response = await _workspace.GetOutboundNetworkDependenciesEndpointsResponseAsync(CancellationToken).ConfigureAwait(false);
                yield return Page<MachineLearningFqdnEndpoints>.FromValues(ToFqdnEndpoints(response.Value), null, response.GetRawResponse());
            }
        }
    }

    public partial class MachineLearningCodeContainerResource
    {
        // Customized: preserve legacy MachineLearning-prefixed child resource getters.
        public virtual MachineLearningCodeVersionCollection GetMachineLearningCodeVersions() => GetCodeVersions();
        /// <summary> Gets a code version. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningCodeVersionResource>> GetMachineLearningCodeVersionAsync(string version, CancellationToken cancellationToken = default) => GetCodeVersionAsync(version, cancellationToken);
        /// <summary> Gets a code version. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningCodeVersionResource> GetMachineLearningCodeVersion(string version, CancellationToken cancellationToken = default) => GetCodeVersion(version, cancellationToken);
    }

    public partial class MachineLearningComponentContainerResource
    {
        // Customized: preserve legacy MachineLearning-prefixed child resource getters.
        public virtual MachineLearningComponentVersionCollection GetMachineLearningComponentVersions() => GetComponentVersions();
        /// <summary> Gets a component version. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningComponentVersionResource>> GetMachineLearningComponentVersionAsync(string version, CancellationToken cancellationToken = default) => GetComponentVersionAsync(version, cancellationToken);
        /// <summary> Gets a component version. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningComponentVersionResource> GetMachineLearningComponentVersion(string version, CancellationToken cancellationToken = default) => GetComponentVersion(version, cancellationToken);
    }

    public partial class MachineLearningDataContainerResource
    {
        // Customized: preserve legacy MachineLearning-prefixed child resource getters.
        public virtual MachineLearningDataVersionCollection GetMachineLearningDataVersions() => GetDataVersions();
        /// <summary> Gets a data version. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningDataVersionResource>> GetMachineLearningDataVersionAsync(string version, CancellationToken cancellationToken = default) => GetDataVersionAsync(version, cancellationToken);
        /// <summary> Gets a data version. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningDataVersionResource> GetMachineLearningDataVersion(string version, CancellationToken cancellationToken = default) => GetDataVersion(version, cancellationToken);
    }

    public partial class MachineLearningEnvironmentContainerResource
    {
        // Customized: preserve legacy MachineLearning-prefixed child resource getters.
        public virtual MachineLearningEnvironmentVersionCollection GetMachineLearningEnvironmentVersions() => GetEnvironmentVersions();
        /// <summary> Gets an environment version. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningEnvironmentVersionResource>> GetMachineLearningEnvironmentVersionAsync(string version, CancellationToken cancellationToken = default) => GetEnvironmentVersionAsync(version, cancellationToken);
        /// <summary> Gets an environment version. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningEnvironmentVersionResource> GetMachineLearningEnvironmentVersion(string version, CancellationToken cancellationToken = default) => GetEnvironmentVersion(version, cancellationToken);
    }

    public partial class MachineLearningModelContainerResource
    {
        // Customized: preserve legacy MachineLearning-prefixed child resource getters.
        public virtual MachineLearningModelVersionCollection GetMachineLearningModelVersions() => GetModelVersions();
        /// <summary> Gets a model version. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningModelVersionResource>> GetMachineLearningModelVersionAsync(string version, CancellationToken cancellationToken = default) => GetModelVersionAsync(version, cancellationToken);
        /// <summary> Gets a model version. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningModelVersionResource> GetMachineLearningModelVersion(string version, CancellationToken cancellationToken = default) => GetModelVersion(version, cancellationToken);
    }

    public partial class MachineLearningRegistryResource
    {
        // Customized: preserve legacy MachineLearning-prefixed child resource getters.
        public virtual MachineLearningRegistryCodeContainerCollection GetMachineLearningRegistryCodeContainers() => GetRegistryCodeContainers();
        /// <summary> Gets a registry code container. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningRegistryCodeContainerResource>> GetMachineLearningRegistryCodeContainerAsync(string codeName, CancellationToken cancellationToken = default) => GetRegistryCodeContainerAsync(codeName, cancellationToken);
        /// <summary> Gets a registry code container. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningRegistryCodeContainerResource> GetMachineLearningRegistryCodeContainer(string codeName, CancellationToken cancellationToken = default) => GetRegistryCodeContainer(codeName, cancellationToken);
        /// <summary> Gets registry component containers. </summary>
        public virtual MachineLearninRegistryComponentContainerCollection GetMachineLearninRegistryComponentContainers() => GetRegistryComponentContainers();
        /// <summary> Gets a registry component container. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearninRegistryComponentContainerResource>> GetMachineLearninRegistryComponentContainerAsync(string componentName, CancellationToken cancellationToken = default) => GetRegistryComponentContainerAsync(componentName, cancellationToken);
        /// <summary> Gets a registry component container. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearninRegistryComponentContainerResource> GetMachineLearninRegistryComponentContainer(string componentName, CancellationToken cancellationToken = default) => GetRegistryComponentContainer(componentName, cancellationToken);
        /// <summary> Gets registry data containers. </summary>
        public virtual MachineLearningRegistryDataContainerCollection GetMachineLearningRegistryDataContainers() => GetRegistryDataContainers();
        /// <summary> Gets a registry data container. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningRegistryDataContainerResource>> GetMachineLearningRegistryDataContainerAsync(string name, CancellationToken cancellationToken = default) => GetRegistryDataContainerAsync(name, cancellationToken);
        /// <summary> Gets a registry data container. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningRegistryDataContainerResource> GetMachineLearningRegistryDataContainer(string name, CancellationToken cancellationToken = default) => GetRegistryDataContainer(name, cancellationToken);
        /// <summary> Gets registry environment containers. </summary>
        public virtual MachineLearningRegistryEnvironmentContainerCollection GetMachineLearningRegistryEnvironmentContainers() => GetRegistryEnvironmentContainers();
        /// <summary> Gets a registry environment container. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningRegistryEnvironmentContainerResource>> GetMachineLearningRegistryEnvironmentContainerAsync(string environmentName, CancellationToken cancellationToken = default) => GetRegistryEnvironmentContainerAsync(environmentName, cancellationToken);
        /// <summary> Gets a registry environment container. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningRegistryEnvironmentContainerResource> GetMachineLearningRegistryEnvironmentContainer(string environmentName, CancellationToken cancellationToken = default) => GetRegistryEnvironmentContainer(environmentName, cancellationToken);
        /// <summary> Gets registry model containers. </summary>
        public virtual MachineLearningRegistryModelContainerCollection GetMachineLearningRegistryModelContainers() => GetRegistryModelContainers();
        /// <summary> Gets a registry model container. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningRegistryModelContainerResource>> GetMachineLearningRegistryModelContainerAsync(string modelName, CancellationToken cancellationToken = default) => GetRegistryModelContainerAsync(modelName, cancellationToken);
        /// <summary> Gets a registry model container. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningRegistryModelContainerResource> GetMachineLearningRegistryModelContainer(string modelName, CancellationToken cancellationToken = default) => GetRegistryModelContainer(modelName, cancellationToken);
    }

    public partial class MachineLearningRegistryCodeContainerResource
    {
        // Customized: preserve legacy MachineLearning-prefixed child resource getters.
        public virtual MachineLearningRegistryCodeVersionCollection GetMachineLearningRegistryCodeVersions() => GetRegistryCodeVersions();
        /// <summary> Gets a registry code version. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningRegistryCodeVersionResource>> GetMachineLearningRegistryCodeVersionAsync(string version, CancellationToken cancellationToken = default) => GetRegistryCodeVersionAsync(version, cancellationToken);
        /// <summary> Gets a registry code version. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningRegistryCodeVersionResource> GetMachineLearningRegistryCodeVersion(string version, CancellationToken cancellationToken = default) => GetRegistryCodeVersion(version, cancellationToken);
    }

    public partial class MachineLearninRegistryComponentContainerResource
    {
        // Customized: preserve legacy MachineLearnin-prefixed child resource getters.
        public virtual MachineLearninRegistryComponentVersionCollection GetMachineLearninRegistryComponentVersions() => GetRegistryComponentVersions();
        /// <summary> Gets a registry component version. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearninRegistryComponentVersionResource>> GetMachineLearninRegistryComponentVersionAsync(string version, CancellationToken cancellationToken = default) => GetRegistryComponentVersionAsync(version, cancellationToken);
        /// <summary> Gets a registry component version. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearninRegistryComponentVersionResource> GetMachineLearninRegistryComponentVersion(string version, CancellationToken cancellationToken = default) => GetRegistryComponentVersion(version, cancellationToken);
    }

    public partial class MachineLearningRegistryDataContainerResource
    {
        // Customized: preserve legacy MachineLearning-prefixed child resource getters.
        public virtual MachineLearningRegistryDataVersionCollection GetMachineLearningRegistryDataVersions() => GetRegistryDataVersions();
        /// <summary> Gets a registry data version. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningRegistryDataVersionResource>> GetMachineLearningRegistryDataVersionAsync(string version, CancellationToken cancellationToken = default) => GetRegistryDataVersionAsync(version, cancellationToken);
        /// <summary> Gets a registry data version. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningRegistryDataVersionResource> GetMachineLearningRegistryDataVersion(string version, CancellationToken cancellationToken = default) => GetRegistryDataVersion(version, cancellationToken);
    }

    public partial class MachineLearningRegistryEnvironmentContainerResource
    {
        // Customized: preserve legacy MachineLearning-prefixed child resource getters.
        public virtual MachineLearningRegistryEnvironmentVersionCollection GetMachineLearningRegistryEnvironmentVersions() => GetRegistryEnvironmentVersions();
        /// <summary> Gets a registry environment version. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningRegistryEnvironmentVersionResource>> GetMachineLearningRegistryEnvironmentVersionAsync(string version, CancellationToken cancellationToken = default) => GetRegistryEnvironmentVersionAsync(version, cancellationToken);
        /// <summary> Gets a registry environment version. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningRegistryEnvironmentVersionResource> GetMachineLearningRegistryEnvironmentVersion(string version, CancellationToken cancellationToken = default) => GetRegistryEnvironmentVersion(version, cancellationToken);
    }

    public partial class MachineLearningRegistryModelContainerResource
    {
        // Customized: preserve legacy MachineLearning-prefixed child resource getters.
        public virtual MachineLearningRegistryModelVersionCollection GetMachineLearningRegistryModelVersions() => GetRegistryModelVersions();
        /// <summary> Gets a registry model version. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningRegistryModelVersionResource>> GetMachineLearningRegistryModelVersionAsync(string version, CancellationToken cancellationToken = default) => GetRegistryModelVersionAsync(version, cancellationToken);
        /// <summary> Gets a registry model version. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningRegistryModelVersionResource> GetMachineLearningRegistryModelVersion(string version, CancellationToken cancellationToken = default) => GetRegistryModelVersion(version, cancellationToken);
    }

    public partial class MachineLearningOutboundRuleBasicResource
    {
        // Customized: preserve legacy outbound rule resource ID shape.
        public static ResourceIdentifier CreateResourceIdentifier(string subscriptionId, string resourceGroupName, string workspaceName, string ruleName)
        {
            return CreateResourceIdentifier(subscriptionId, resourceGroupName, workspaceName, MachineLearningWorkspaceResource.LegacyManagedNetworkName, ruleName);
        }
    }
}

#pragma warning restore SA1402
