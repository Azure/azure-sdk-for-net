// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.HybridCompute.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.HybridCompute
{
    [CodeGenSuppress("GetAsync", typeof(InstanceViewTypes?), typeof(CancellationToken))]
    [CodeGenSuppress("Get", typeof(InstanceViewTypes?), typeof(CancellationToken))]
    public partial class HybridComputeMachineResource
    {
        /// <summary>
        /// Gets the model view or instance view of a hybrid machine.
        /// </summary>
        public virtual async Task<Response<HybridComputeMachineResource>> GetAsync(InstanceViewTypes? expand, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _machinesClientDiagnostics.CreateScope("HybridComputeMachineResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _machinesRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand?.ToString(), context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<HybridComputeMachineData> response = Response.FromValue(HybridComputeMachineData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new HybridComputeMachineResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the model view or instance view of a hybrid machine.
        /// </summary>
        public virtual Response<HybridComputeMachineResource> Get(InstanceViewTypes? expand, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _machinesClientDiagnostics.CreateScope("HybridComputeMachineResource.Get");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _machinesRestClient.CreateGetRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, expand?.ToString(), context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<HybridComputeMachineData> response = Response.FromValue(HybridComputeMachineData.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return Response.FromValue(new HybridComputeMachineResource(Client, response.Value), response.GetRawResponse());
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Gets the model view or instance view of a hybrid machine.
        /// This overload uses a string <paramref name="expand"/> for backward compatibility.
        /// Use <see cref="Get(InstanceViewTypes?, CancellationToken)"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<HybridComputeMachineResource>> GetAsync(string expand = default, CancellationToken cancellationToken = default)
            => GetAsync(string.IsNullOrEmpty(expand) ? default(InstanceViewTypes?) : new InstanceViewTypes(expand), cancellationToken);

        /// <summary>
        /// Gets the model view or instance view of a hybrid machine.
        /// This overload uses a string <paramref name="expand"/> for backward compatibility.
        /// Use <see cref="Get(InstanceViewTypes?, CancellationToken)"/> instead.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<HybridComputeMachineResource> Get(string expand = default, CancellationToken cancellationToken = default)
            => Get(string.IsNullOrEmpty(expand) ? default(InstanceViewTypes?) : new InstanceViewTypes(expand), cancellationToken);

        /// <summary>
        /// Returns the Azure Arc PrivateLinkScope's validation details for a given machine.
        /// This method was renamed to <see cref="GetValidationDetailsForMachineAsync(CancellationToken)"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Task<Response<PrivateLinkScopeValidationDetails>> GetValidationDetailsForMachinePrivateLinkScopeAsync(CancellationToken cancellationToken = default)
            => GetValidationDetailsForMachineAsync(cancellationToken);

        /// <summary>
        /// Returns the Azure Arc PrivateLinkScope's validation details for a given machine.
        /// This method was renamed to <see cref="GetValidationDetailsForMachine(CancellationToken)"/>.
        /// </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<PrivateLinkScopeValidationDetails> GetValidationDetailsForMachinePrivateLinkScope(CancellationToken cancellationToken = default)
            => GetValidationDetailsForMachine(cancellationToken);
    }
}
