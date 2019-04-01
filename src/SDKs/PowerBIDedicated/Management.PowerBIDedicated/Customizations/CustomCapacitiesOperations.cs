// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Microsoft.Azure.Management.PowerBIDedicated.Models;
using Microsoft.Rest.Azure;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Microsoft.Azure.Management.PowerBIDedicated
{
    public class CustomCapacitiesOperations : ICapacitiesOperations
    {
        private readonly ICapacitiesOperations innerCapacityOperations;
        private readonly PowerBIDedicatedManagementClient client;

        internal CustomCapacitiesOperations(ICapacitiesOperations inner, PowerBIDedicatedManagementClient client)
        {
            this.innerCapacityOperations = inner;
            this.client = client;
        }

        public PowerBIDedicatedManagementClient Client => client;

        /// <inheritdoc/>
        public async Task<AzureOperationResponse<DedicatedCapacity>> GetDetailsWithHttpMessagesAsync(string resourceGroupName, string dedicatedCapacityName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await innerCapacityOperations
                .GetDetailsWithHttpMessagesAsync(resourceGroupName, dedicatedCapacityName, customHeaders, cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<AzureOperationResponse<DedicatedCapacity>> CreateWithHttpMessagesAsync(string resourceGroupName, string dedicatedCapacityName, DedicatedCapacity capacityParameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await innerCapacityOperations
                .CreateWithHttpMessagesAsync(resourceGroupName, dedicatedCapacityName, capacityParameters, customHeaders, cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<AzureOperationResponse> DeleteWithHttpMessagesAsync(string resourceGroupName, string dedicatedCapacityName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await innerCapacityOperations
                .DeleteWithHttpMessagesAsync(resourceGroupName, dedicatedCapacityName, customHeaders, cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<AzureOperationResponse<DedicatedCapacity>> UpdateWithHttpMessagesAsync(string resourceGroupName, string dedicatedCapacityName, DedicatedCapacityUpdateParameters capacityUpdateParameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            AzureOperationResponse<DedicatedCapacity> _response = await BeginUpdateWithHttpMessagesAsync(resourceGroupName, dedicatedCapacityName, capacityUpdateParameters, customHeaders, cancellationToken).ConfigureAwait(false);
            if (_response.Response.StatusCode != System.Net.HttpStatusCode.OK)
                return await Client.GetPutOrPatchOperationResultAsync(_response, customHeaders, cancellationToken).ConfigureAwait(false);
            return _response;
        }

        /// <inheritdoc/>
        public async Task<AzureOperationResponse> SuspendWithHttpMessagesAsync(string resourceGroupName, string dedicatedCapacityName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await innerCapacityOperations
                .SuspendWithHttpMessagesAsync(resourceGroupName, dedicatedCapacityName, customHeaders, cancellationToken)
                .ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<AzureOperationResponse> ResumeWithHttpMessagesAsync(string resourceGroupName, string dedicatedCapacityName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await innerCapacityOperations
                    .ResumeWithHttpMessagesAsync(resourceGroupName, dedicatedCapacityName, customHeaders, cancellationToken)
                    .ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<AzureOperationResponse<IEnumerable<DedicatedCapacity>>> ListByResourceGroupWithHttpMessagesAsync(string resourceGroupName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await innerCapacityOperations
                    .ListByResourceGroupWithHttpMessagesAsync(resourceGroupName, customHeaders, cancellationToken)
                    .ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<AzureOperationResponse<IEnumerable<DedicatedCapacity>>> ListWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await innerCapacityOperations
                    .ListWithHttpMessagesAsync(customHeaders, cancellationToken)
                    .ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<AzureOperationResponse<SkuEnumerationForNewResourceResult>> ListSkusWithHttpMessagesAsync(Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await innerCapacityOperations
                    .ListSkusWithHttpMessagesAsync(customHeaders, cancellationToken)
                    .ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<AzureOperationResponse<SkuEnumerationForExistingResourceResult>> ListSkusForCapacityWithHttpMessagesAsync(string resourceGroupName, string dedicatedCapacityName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await innerCapacityOperations
                    .ListSkusForCapacityWithHttpMessagesAsync(resourceGroupName, dedicatedCapacityName, customHeaders, cancellationToken)
                    .ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<AzureOperationResponse<DedicatedCapacity>> BeginCreateWithHttpMessagesAsync(string resourceGroupName, string dedicatedCapacityName, DedicatedCapacity capacityParameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await innerCapacityOperations
                    .BeginCreateWithHttpMessagesAsync(resourceGroupName, dedicatedCapacityName, capacityParameters, customHeaders, cancellationToken)
                    .ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<AzureOperationResponse> BeginDeleteWithHttpMessagesAsync(string resourceGroupName, string dedicatedCapacityName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await innerCapacityOperations
                    .BeginDeleteWithHttpMessagesAsync(resourceGroupName, dedicatedCapacityName, customHeaders, cancellationToken)
                    .ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<AzureOperationResponse<DedicatedCapacity>> BeginUpdateWithHttpMessagesAsync(string resourceGroupName, string dedicatedCapacityName, DedicatedCapacityUpdateParameters capacityUpdateParameters, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await innerCapacityOperations
                    .BeginUpdateWithHttpMessagesAsync(resourceGroupName, dedicatedCapacityName, capacityUpdateParameters, customHeaders, cancellationToken)
                    .ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<AzureOperationResponse> BeginSuspendWithHttpMessagesAsync(string resourceGroupName, string dedicatedCapacityName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await innerCapacityOperations
                    .BeginSuspendWithHttpMessagesAsync(resourceGroupName, dedicatedCapacityName, customHeaders, cancellationToken)
                    .ConfigureAwait(false);
        }

        /// <inheritdoc/>
        public async Task<AzureOperationResponse> BeginResumeWithHttpMessagesAsync(string resourceGroupName, string dedicatedCapacityName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken))
        {
            return await innerCapacityOperations
                    .BeginResumeWithHttpMessagesAsync(resourceGroupName, dedicatedCapacityName, customHeaders, cancellationToken)
                    .ConfigureAwait(false);
        }
    }
}