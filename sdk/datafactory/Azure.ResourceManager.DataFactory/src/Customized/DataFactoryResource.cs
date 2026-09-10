// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.ResourceManager.DataFactory
{
    // This partial restores pre-MPG DataFactoryResource API surface:
    //   Back-compat string ifNoneMatch overloads ([EditorBrowsable(Never)]) that delegate to the
    //   ETag-based generated methods.
    public partial class DataFactoryResource
    {
        /// <summary> Gets a factory. </summary>
        /// <param name="ifNoneMatch"> ETag of the factory entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryResource>> GetAsync(string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetAsync(ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a factory. </summary>
        /// <param name="ifNoneMatch"> ETag of the factory entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryResource> Get(string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return Get(ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        /// <summary> Gets a trigger. </summary>
        /// <param name="triggerName"> The trigger name. </param>
        /// <param name="ifNoneMatch"> ETag of the trigger entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryTriggerResource>> GetDataFactoryTriggerAsync(string triggerName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryTriggerAsync(triggerName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a trigger. </summary>
        /// <param name="triggerName"> The trigger name. </param>
        /// <param name="ifNoneMatch"> ETag of the trigger entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryTriggerResource> GetDataFactoryTrigger(string triggerName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetDataFactoryTrigger(triggerName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        /// <summary> Gets a integration runtime. </summary>
        /// <param name="integrationRuntimeName"> The integration runtime name. </param>
        /// <param name="ifNoneMatch"> ETag of the integration runtime entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryIntegrationRuntimeResource>> GetDataFactoryIntegrationRuntimeAsync(string integrationRuntimeName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryIntegrationRuntimeAsync(integrationRuntimeName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a integration runtime. </summary>
        /// <param name="integrationRuntimeName"> The integration runtime name. </param>
        /// <param name="ifNoneMatch"> ETag of the integration runtime entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryIntegrationRuntimeResource> GetDataFactoryIntegrationRuntime(string integrationRuntimeName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetDataFactoryIntegrationRuntime(integrationRuntimeName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        /// <summary> Gets a linked service. </summary>
        /// <param name="linkedServiceName"> The linked service name. </param>
        /// <param name="ifNoneMatch"> ETag of the linked service entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryLinkedServiceResource>> GetDataFactoryLinkedServiceAsync(string linkedServiceName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryLinkedServiceAsync(linkedServiceName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a linked service. </summary>
        /// <param name="linkedServiceName"> The linked service name. </param>
        /// <param name="ifNoneMatch"> ETag of the linked service entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryLinkedServiceResource> GetDataFactoryLinkedService(string linkedServiceName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetDataFactoryLinkedService(linkedServiceName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        /// <summary> Gets a dataset. </summary>
        /// <param name="datasetName"> The dataset name. </param>
        /// <param name="ifNoneMatch"> ETag of the dataset entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryDatasetResource>> GetDataFactoryDatasetAsync(string datasetName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryDatasetAsync(datasetName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a dataset. </summary>
        /// <param name="datasetName"> The dataset name. </param>
        /// <param name="ifNoneMatch"> ETag of the dataset entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryDatasetResource> GetDataFactoryDataset(string datasetName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetDataFactoryDataset(datasetName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        /// <summary> Gets a pipeline. </summary>
        /// <param name="pipelineName"> The pipeline name. </param>
        /// <param name="ifNoneMatch"> ETag of the pipeline entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryPipelineResource>> GetDataFactoryPipelineAsync(string pipelineName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryPipelineAsync(pipelineName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a pipeline. </summary>
        /// <param name="pipelineName"> The pipeline name. </param>
        /// <param name="ifNoneMatch"> ETag of the pipeline entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryPipelineResource> GetDataFactoryPipeline(string pipelineName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetDataFactoryPipeline(pipelineName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        /// <summary> Gets a data flow. </summary>
        /// <param name="dataFlowName"> The data flow name. </param>
        /// <param name="ifNoneMatch"> ETag of the data flow entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryDataFlowResource>> GetDataFactoryDataFlowAsync(string dataFlowName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryDataFlowAsync(dataFlowName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a data flow. </summary>
        /// <param name="dataFlowName"> The data flow name. </param>
        /// <param name="ifNoneMatch"> ETag of the data flow entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryDataFlowResource> GetDataFactoryDataFlow(string dataFlowName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetDataFactoryDataFlow(dataFlowName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        /// <summary> Gets a managed virtual network. </summary>
        /// <param name="managedVirtualNetworkName"> The managed virtual network name. </param>
        /// <param name="ifNoneMatch"> ETag of the managed virtual network entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryManagedVirtualNetworkResource>> GetDataFactoryManagedVirtualNetworkAsync(string managedVirtualNetworkName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryManagedVirtualNetworkAsync(managedVirtualNetworkName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a managed virtual network. </summary>
        /// <param name="managedVirtualNetworkName"> The managed virtual network name. </param>
        /// <param name="ifNoneMatch"> ETag of the managed virtual network entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryManagedVirtualNetworkResource> GetDataFactoryManagedVirtualNetwork(string managedVirtualNetworkName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetDataFactoryManagedVirtualNetwork(managedVirtualNetworkName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        /// <summary> Gets a credential. </summary>
        /// <param name="credentialName"> The credential name. </param>
        /// <param name="ifNoneMatch"> ETag of the credential entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryServiceCredentialResource>> GetDataFactoryServiceCredentialAsync(string credentialName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryServiceCredentialAsync(credentialName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a credential. </summary>
        /// <param name="credentialName"> The credential name. </param>
        /// <param name="ifNoneMatch"> ETag of the credential entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryServiceCredentialResource> GetDataFactoryServiceCredential(string credentialName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetDataFactoryServiceCredential(credentialName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        /// <summary> Gets a private endpoint connection. </summary>
        /// <param name="privateEndpointConnectionName"> The private endpoint connection name. </param>
        /// <param name="ifNoneMatch"> ETag of the private endpoint connection entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryPrivateEndpointConnectionResource>> GetDataFactoryPrivateEndpointConnectionAsync(string privateEndpointConnectionName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryPrivateEndpointConnectionAsync(privateEndpointConnectionName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a private endpoint connection. </summary>
        /// <param name="privateEndpointConnectionName"> The private endpoint connection name. </param>
        /// <param name="ifNoneMatch"> ETag of the private endpoint connection entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryPrivateEndpointConnectionResource> GetDataFactoryPrivateEndpointConnection(string privateEndpointConnectionName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetDataFactoryPrivateEndpointConnection(privateEndpointConnectionName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        /// <summary> Gets a change data capture. </summary>
        /// <param name="changeDataCaptureName"> The change data capture name. </param>
        /// <param name="ifNoneMatch"> ETag of the change data capture entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryChangeDataCaptureResource>> GetDataFactoryChangeDataCaptureAsync(string changeDataCaptureName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryChangeDataCaptureAsync(changeDataCaptureName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a change data capture. </summary>
        /// <param name="changeDataCaptureName"> The change data capture name. </param>
        /// <param name="ifNoneMatch"> ETag of the change data capture entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryChangeDataCaptureResource> GetDataFactoryChangeDataCapture(string changeDataCaptureName, string ifNoneMatch, CancellationToken cancellationToken = default)
        {
            return GetDataFactoryChangeDataCapture(changeDataCaptureName, ifNoneMatch != null ? new ETag(ifNoneMatch) : (ETag?)null, cancellationToken);
        }

        /// <summary> Gets a collection of DataFactoryManagedIdentityCredentials in the DataFactoryResource. </summary>
        /// <returns> An object representing collection of DataFactoryManagedIdentityCredentials and their operations over a DataFactoryManagedIdentityCredentialResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual DataFactoryManagedIdentityCredentialCollection GetDataFactoryManagedIdentityCredentials()
        {
            return GetCachedClient(client => new DataFactoryManagedIdentityCredentialCollection(client, Id));
        }

        /// <summary> Gets a credential. </summary>
        /// <param name="credentialName"> Credential name. </param>
        /// <param name="ifNoneMatch"> ETag of the credential entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credentialName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="credentialName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<DataFactoryManagedIdentityCredentialResource>> GetDataFactoryManagedIdentityCredentialAsync(string credentialName, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            return await GetDataFactoryManagedIdentityCredentials().GetAsync(credentialName, ifNoneMatch, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Gets a credential. </summary>
        /// <param name="credentialName"> Credential name. </param>
        /// <param name="ifNoneMatch"> ETag of the credential entity. Should only be specified for get. If the ETag matches the existing entity tag, or if * was provided, then no content will be returned. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="credentialName"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="credentialName"/> is an empty string, and was expected to be non-empty. </exception>
        [ForwardsClientCalls]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<DataFactoryManagedIdentityCredentialResource> GetDataFactoryManagedIdentityCredential(string credentialName, string ifNoneMatch = null, CancellationToken cancellationToken = default)
        {
            return GetDataFactoryManagedIdentityCredentials().Get(credentialName, ifNoneMatch, cancellationToken);
        }
    }
}
