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
    [CodeGenSuppress("Exists", typeof(string), typeof(CancellationToken))]
    [CodeGenSuppress("ExistsAsync", typeof(string), typeof(CancellationToken))]
    public partial class PolicyFragmentContractCollection
    {
        /// <summary> Checks whether the resource exists. </summary>
        /// <param name="id"> The resource identifier. </param>
        /// <param name="format"> The export format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> is empty. </exception>
        public virtual async Task<Response<bool>> ExistsAsync(string id, PolicyFragmentContentFormat? format = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));

            return await CollectionExistsCompatibility.SendAsync(
                _policyFragmentClientDiagnostics, Pipeline, "PolicyFragmentContractCollection.Exists",
                context => format.HasValue
                    ? _policyFragmentRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, id, format?.ToString(), context)
                    : _policyFragmentRestClient.CreateGetEntityTagRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, id, context),
                !format.HasValue, PolicyFragmentContractData.FromResponse, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Checks whether the resource exists. </summary>
        /// <param name="id"> The resource identifier. </param>
        /// <param name="format"> The export format. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="id"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="id"/> is empty. </exception>
        public virtual Response<bool> Exists(string id, PolicyFragmentContentFormat? format = default, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));

            return CollectionExistsCompatibility.Send(
                _policyFragmentClientDiagnostics, Pipeline, "PolicyFragmentContractCollection.Exists",
                context => format.HasValue
                    ? _policyFragmentRestClient.CreateGetRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, id, format?.ToString(), context)
                    : _policyFragmentRestClient.CreateGetEntityTagRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, id, context),
                !format.HasValue, PolicyFragmentContractData.FromResponse, cancellationToken);
        }
    }
}
