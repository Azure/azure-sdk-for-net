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
using Azure.ResourceManager;
using Azure.ResourceManager.MachineLearning.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning
{
    // Customized: preserve GA MachineLearning-prefixed child resource accessors over shorter generated
    // workspace child-resource accessors, which are not standalone REST operations that client.tsp can rename.
    [CodeGenSuppress("GetOutboundNetworkDependenciesEndpointsAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetOutboundNetworkDependenciesEndpoints", typeof(CancellationToken))]
    public partial class MachineLearningWorkspaceResource
    {
        internal const string LegacyManagedNetworkName = "default";

        // Customized: keep the historical MachineLearning* method names for source compatibility.
        /// <summary> Deletes this workspace. </summary>
        [ForwardsClientCalls]
        public virtual Task<ArmOperation> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken) => DeleteAsync(waitUntil, default(bool?), cancellationToken);
        /// <summary> Deletes this workspace. </summary>
        [ForwardsClientCalls]
        public virtual ArmOperation Delete(WaitUntil waitUntil, CancellationToken cancellationToken) => Delete(waitUntil, default(bool?), cancellationToken);
        public virtual MachineLearningCodeContainerCollection GetMachineLearningCodeContainers() => new MachineLearningCodeContainerCollection(Client, Id);
        /// <summary> Gets a code container. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningCodeContainerResource>> GetMachineLearningCodeContainerAsync(string name, CancellationToken cancellationToken = default) => GetMachineLearningCodeContainers().GetAsync(name, cancellationToken);
        /// <summary> Gets a code container. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningCodeContainerResource> GetMachineLearningCodeContainer(string name, CancellationToken cancellationToken = default) => GetMachineLearningCodeContainers().Get(name, cancellationToken);
        /// <summary> Gets component containers. </summary>
        public virtual MachineLearningComponentContainerCollection GetMachineLearningComponentContainers() => new MachineLearningComponentContainerCollection(Client, Id);
        /// <summary> Gets a component container. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningComponentContainerResource>> GetMachineLearningComponentContainerAsync(string name, CancellationToken cancellationToken = default) => GetMachineLearningComponentContainers().GetAsync(name, cancellationToken);
        /// <summary> Gets a component container. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningComponentContainerResource> GetMachineLearningComponentContainer(string name, CancellationToken cancellationToken = default) => GetMachineLearningComponentContainers().Get(name, cancellationToken);
        /// <summary> Gets data containers. </summary>
        public virtual MachineLearningDataContainerCollection GetMachineLearningDataContainers() => new MachineLearningDataContainerCollection(Client, Id);
        /// <summary> Gets a data container. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningDataContainerResource>> GetMachineLearningDataContainerAsync(string name, CancellationToken cancellationToken = default) => GetMachineLearningDataContainers().GetAsync(name, cancellationToken);
        /// <summary> Gets a data container. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningDataContainerResource> GetMachineLearningDataContainer(string name, CancellationToken cancellationToken = default) => GetMachineLearningDataContainers().Get(name, cancellationToken);
        /// <summary> Gets environment containers. </summary>
        public virtual MachineLearningEnvironmentContainerCollection GetMachineLearningEnvironmentContainers() => new MachineLearningEnvironmentContainerCollection(Client, Id);
        /// <summary> Gets an environment container. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningEnvironmentContainerResource>> GetMachineLearningEnvironmentContainerAsync(string name, CancellationToken cancellationToken = default) => GetMachineLearningEnvironmentContainers().GetAsync(name, cancellationToken);
        /// <summary> Gets an environment container. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningEnvironmentContainerResource> GetMachineLearningEnvironmentContainer(string name, CancellationToken cancellationToken = default) => GetMachineLearningEnvironmentContainers().Get(name, cancellationToken);
        /// <summary> Gets model containers. </summary>
        public virtual MachineLearningModelContainerCollection GetMachineLearningModelContainers() => new MachineLearningModelContainerCollection(Client, Id);
        /// <summary> Gets a model container. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningModelContainerResource>> GetMachineLearningModelContainerAsync(string name, CancellationToken cancellationToken = default) => GetMachineLearningModelContainers().GetAsync(name, cancellationToken);
        /// <summary> Gets a model container. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningModelContainerResource> GetMachineLearningModelContainer(string name, CancellationToken cancellationToken = default) => GetMachineLearningModelContainers().Get(name, cancellationToken);
        /// <summary> Gets compute resources. </summary>
        public virtual MachineLearningComputeCollection GetMachineLearningComputes() => new MachineLearningComputeCollection(Client, Id);
        /// <summary> Gets a compute resource. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningComputeResource>> GetMachineLearningComputeAsync(string computeName, CancellationToken cancellationToken = default) => GetMachineLearningComputes().GetAsync(computeName, cancellationToken);
        /// <summary> Gets a compute resource. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningComputeResource> GetMachineLearningCompute(string computeName, CancellationToken cancellationToken = default) => GetMachineLearningComputes().Get(computeName, cancellationToken);
        /// <summary> Gets jobs. </summary>
        public virtual MachineLearningJobCollection GetMachineLearningJobs() => new MachineLearningJobCollection(Client, Id);
        /// <summary> Gets a job. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningJobResource>> GetMachineLearningJobAsync(string id, CancellationToken cancellationToken = default) => GetMachineLearningJobs().GetAsync(id, cancellationToken);
        /// <summary> Gets a job. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningJobResource> GetMachineLearningJob(string id, CancellationToken cancellationToken = default) => GetMachineLearningJobs().Get(id, cancellationToken);
        /// <summary> Gets workspace connections. </summary>
        public virtual MachineLearningWorkspaceConnectionCollection GetMachineLearningWorkspaceConnections() => new MachineLearningWorkspaceConnectionCollection(Client, Id);
        /// <summary> Gets a workspace connection. </summary>
        [ForwardsClientCalls]
        public virtual Task<Response<MachineLearningWorkspaceConnectionResource>> GetMachineLearningWorkspaceConnectionAsync(string connectionName, CancellationToken cancellationToken = default) => GetMachineLearningWorkspaceConnections().GetAsync(connectionName, cancellationToken);
        /// <summary> Gets a workspace connection. </summary>
        [ForwardsClientCalls]
        public virtual Response<MachineLearningWorkspaceConnectionResource> GetMachineLearningWorkspaceConnection(string connectionName, CancellationToken cancellationToken = default) => GetMachineLearningWorkspaceConnections().Get(connectionName, cancellationToken);
        /// <summary> Gets outbound rules. </summary>
        public virtual MachineLearningOutboundRuleBasicCollection GetMachineLearningOutboundRuleBasics()
        {
            ResourceIdentifier managedNetworkId = MachineLearningManagedNetworkSettingsResource.CreateResourceIdentifier(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, LegacyManagedNetworkName);
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
            Response<MachineLearningExternalFqdnResult> response = GetOutboundNetworkDependenciesEndpointsResponse(cancellationToken);
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

        private async Task<Response<MachineLearningExternalFqdnResult>> GetOutboundNetworkDependenciesEndpointsResponseAsync(CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _workspacesClientDiagnostics.CreateScope("MachineLearningWorkspaceResource.GetOutboundNetworkDependenciesEndpoints");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _workspacesRestClient.CreateGetOutboundNetworkDependenciesEndpointsRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                return Response.FromValue(MachineLearningExternalFqdnResult.FromResponse(result), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private Response<MachineLearningExternalFqdnResult> GetOutboundNetworkDependenciesEndpointsResponse(CancellationToken cancellationToken)
        {
            using DiagnosticScope scope = _workspacesClientDiagnostics.CreateScope("MachineLearningWorkspaceResource.GetOutboundNetworkDependenciesEndpoints");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _workspacesRestClient.CreateGetOutboundNetworkDependenciesEndpointsRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, context);
                Response result = Pipeline.ProcessMessage(message, context);
                return Response.FromValue(MachineLearningExternalFqdnResult.FromResponse(result), result);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        private static IReadOnlyList<MachineLearningFqdnEndpoints> ToFqdnEndpoints(MachineLearningExternalFqdnResult response)
        {
            List<MachineLearningFqdnEndpoints> endpoints = new List<MachineLearningFqdnEndpoints>();
            if (response?.Value is null)
            {
                return endpoints;
            }

            foreach (MachineLearningFqdnEndpointGroup item in response.Value)
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
                Response<MachineLearningExternalFqdnResult> response = await _workspace.GetOutboundNetworkDependenciesEndpointsResponseAsync(CancellationToken).ConfigureAwait(false);
                yield return Page<MachineLearningFqdnEndpoints>.FromValues(ToFqdnEndpoints(response.Value), null, response.GetRawResponse());
            }
        }
    }
}
