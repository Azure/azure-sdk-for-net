// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.ResourceManager.DataFactory.Models;

namespace Azure.ResourceManager.DataFactory
{
    public partial class DataFactoryResource : ArmResource
    {
        /// <summary>
        /// Query pipeline runs in the factory based on input filter conditions.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataFactory/factories/{factoryName}/queryPipelineRuns</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PipelineRuns_QueryByFactory</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2018-06-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> Parameters to filter the pipeline run. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <returns> An async collection of <see cref="DataFactoryPipelineRunInfo"/> that may take multiple service requests to iterate over. </returns>
        public virtual AsyncPageable<DataFactoryPipelineRunInfo> GetPipelineRunsAsync(RunFilterContent content, CancellationToken cancellationToken = default)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            HttpMessage FirstPageRequest(int? pageSizeHint) => _pipelineRunsRestClient.CreateQueryByFactoryRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, content);
            HttpMessage NextPageRequest(int? pageSizeHint, string continuationToken) => _pipelineRunsRestClient.CreateQueryByFactoryNextPageRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, content, continuationToken);
            return GeneratorPageableHelpers.CreateAsyncPageable(FirstPageRequest, NextPageRequest, e => DataFactoryPipelineRunInfo.DeserializeDataFactoryPipelineRunInfo(e), _pipelineRunsClientDiagnostics, Pipeline, "DataFactoryResource.GetPipelineRuns", "value", "continuationToken", cancellationToken);
        }

        /// <summary>
        /// Query pipeline runs in the factory based on input filter conditions.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataFactory/factories/{factoryName}/queryPipelineRuns</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>PipelineRuns_QueryByFactory</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2018-06-01</description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="content"> Parameters to filter the pipeline run. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="content"/> is null. </exception>
        /// <returns> A collection of <see cref="DataFactoryPipelineRunInfo"/> that may take multiple service requests to iterate over. </returns>
        public virtual Pageable<DataFactoryPipelineRunInfo> GetPipelineRuns(RunFilterContent content, CancellationToken cancellationToken = default)
        {
            if (content == null)
            {
                throw new ArgumentNullException(nameof(content));
            }

            HttpMessage FirstPageRequest(int? pageSizeHint) => _pipelineRunsRestClient.CreateQueryByFactoryRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, content);
            HttpMessage NextPageRequest(int? pageSizeHint, string continuationToken) => _pipelineRunsRestClient.CreateQueryByFactoryNextPageRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, content, continuationToken);
            return GeneratorPageableHelpers.CreatePageable(FirstPageRequest, NextPageRequest, e => DataFactoryPipelineRunInfo.DeserializeDataFactoryPipelineRunInfo(e), _pipelineRunsClientDiagnostics, Pipeline, "DataFactoryResource.GetPipelineRuns", "value", "continuationToken", cancellationToken);
        }

        /// <summary> Gets a collection of DataFactoryManagedIdentityCredentialResources in the DataFactory. </summary>
        /// <returns> An object representing collection of DataFactoryManagedIdentityCredentialResources and their operations over a DataFactoryManagedIdentityCredentialResource. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual DataFactoryManagedIdentityCredentialCollection GetDataFactoryManagedIdentityCredentials()
        {
            return GetCachedClient(client => new DataFactoryManagedIdentityCredentialCollection(client, Id));
        }

        /// <summary>
        /// Gets a credential.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataFactory/factories/{factoryName}/credentials/{credentialName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CredentialOperations_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2018-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DataFactoryManagedIdentityCredentialResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
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

        /// <summary>
        /// Gets a credential.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.DataFactory/factories/{factoryName}/credentials/{credentialName}</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>CredentialOperations_Get</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2018-06-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="DataFactoryManagedIdentityCredentialResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
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
