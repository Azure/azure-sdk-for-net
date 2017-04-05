// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Azure.Management.MachineLearning.WebServices.Models;
using Microsoft.Rest.Azure;

namespace Microsoft.Azure.Management.MachineLearning.WebServices
{
    public partial interface IWebServicesOperations
    {
        Task<AzureOperationResponse<WebService>> CreateOrUpdateWebServiceWithProperRequestIdAsync(WebService createOrUpdatePayload, string resourceGroupName, string webServiceName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        Task<AzureOperationResponse<WebService>> PatchWebServiceWithProperRequestIdAsync(WebService patchPayload, string resourceGroupName, string webServiceName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        Task<AzureOperationResponse> RemoveWebServiceWitProperRequestIdAsync(string resourceGroupName, string webServiceName, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));

        Task<AsyncOperationStatus> CreateRegionalPropertiesWithProperRequestIdAsync(string resourceGroupName, string webServiceName, string region, Dictionary<string, List<string>> customHeaders = null, CancellationToken cancellationToken = default(CancellationToken));
}
}
