// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.ResourceManager;
using Azure.ResourceManager.DataFactory.Models;

#pragma warning disable CS1591

namespace Azure.ResourceManager.DataFactory
{
    public partial class DataFactoryResource
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryResource>> GetAsync(string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetAsync(ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryResource> Get(string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return Get(ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryTriggerResource>> GetDataFactoryTriggerAsync(string triggerName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryTriggerAsync(triggerName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryTriggerResource> GetDataFactoryTrigger(string triggerName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetDataFactoryTrigger(triggerName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryIntegrationRuntimeResource>> GetDataFactoryIntegrationRuntimeAsync(string integrationRuntimeName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryIntegrationRuntimeAsync(integrationRuntimeName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryIntegrationRuntimeResource> GetDataFactoryIntegrationRuntime(string integrationRuntimeName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetDataFactoryIntegrationRuntime(integrationRuntimeName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryLinkedServiceResource>> GetDataFactoryLinkedServiceAsync(string linkedServiceName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryLinkedServiceAsync(linkedServiceName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryLinkedServiceResource> GetDataFactoryLinkedService(string linkedServiceName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetDataFactoryLinkedService(linkedServiceName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryDatasetResource>> GetDataFactoryDatasetAsync(string datasetName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryDatasetAsync(datasetName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryDatasetResource> GetDataFactoryDataset(string datasetName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetDataFactoryDataset(datasetName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryPipelineResource>> GetDataFactoryPipelineAsync(string pipelineName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryPipelineAsync(pipelineName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryPipelineResource> GetDataFactoryPipeline(string pipelineName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetDataFactoryPipeline(pipelineName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryDataFlowResource>> GetDataFactoryDataFlowAsync(string dataFlowName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryDataFlowAsync(dataFlowName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryDataFlowResource> GetDataFactoryDataFlow(string dataFlowName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetDataFactoryDataFlow(dataFlowName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryManagedVirtualNetworkResource>> GetDataFactoryManagedVirtualNetworkAsync(string managedVirtualNetworkName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryManagedVirtualNetworkAsync(managedVirtualNetworkName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryManagedVirtualNetworkResource> GetDataFactoryManagedVirtualNetwork(string managedVirtualNetworkName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetDataFactoryManagedVirtualNetwork(managedVirtualNetworkName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryServiceCredentialResource>> GetDataFactoryServiceCredentialAsync(string credentialName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryServiceCredentialAsync(credentialName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryServiceCredentialResource> GetDataFactoryServiceCredential(string credentialName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetDataFactoryServiceCredential(credentialName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryPrivateEndpointConnectionResource>> GetDataFactoryPrivateEndpointConnectionAsync(string privateEndpointConnectionName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryPrivateEndpointConnectionAsync(privateEndpointConnectionName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryPrivateEndpointConnectionResource> GetDataFactoryPrivateEndpointConnection(string privateEndpointConnectionName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetDataFactoryPrivateEndpointConnection(privateEndpointConnectionName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryChangeDataCaptureResource>> GetDataFactoryChangeDataCaptureAsync(string changeDataCaptureName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryChangeDataCaptureAsync(changeDataCaptureName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryChangeDataCaptureResource> GetDataFactoryChangeDataCapture(string changeDataCaptureName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetDataFactoryChangeDataCapture(changeDataCaptureName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }
    }
}
