// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.ResourceManager.ApiManagement.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.ApiManagement
{
    [CodeGenSuppress("Exists", typeof(PolicyName), typeof(CancellationToken))]
    [CodeGenSuppress("ExistsAsync", typeof(PolicyName), typeof(CancellationToken))]
    public partial class ApiManagementPolicyCollection
    {
        /// <summary> Checks whether the resource exists. </summary>
        /// <param name="policyId"> The resource identifier. </param>
        /// <param name="format"> The export format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response<bool>> ExistsAsync(PolicyName policyId, PolicyExportFormat? format = default, CancellationToken cancellationToken = default)
        {
            return await CollectionExistsCompatibility.SendAsync(
                _policyClientDiagnostics, Pipeline, "ApiManagementPolicyCollection.Exists",
                context => format.HasValue
                    ? _policyRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, policyId.ToString(), format?.ToString(), context)
                    : _policyRestClient.CreateGetEntityTagRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, policyId.ToString(), context),
                !format.HasValue, PolicyContractData.FromResponse, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Checks whether the resource exists. </summary>
        /// <param name="policyId"> The resource identifier. </param>
        /// <param name="format"> The export format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response<bool> Exists(PolicyName policyId, PolicyExportFormat? format = default, CancellationToken cancellationToken = default)
        {
            return CollectionExistsCompatibility.Send(
                _policyClientDiagnostics, Pipeline, "ApiManagementPolicyCollection.Exists",
                context => format.HasValue
                    ? _policyRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, policyId.ToString(), format?.ToString(), context)
                    : _policyRestClient.CreateGetEntityTagRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, policyId.ToString(), context),
                !format.HasValue, PolicyContractData.FromResponse, cancellationToken);
        }
    }
}
