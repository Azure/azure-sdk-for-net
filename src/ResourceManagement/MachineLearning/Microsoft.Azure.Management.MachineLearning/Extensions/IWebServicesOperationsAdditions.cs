﻿// 
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

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
    }
}
