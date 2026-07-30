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
using Azure.ResourceManager.MachineLearning.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.MachineLearning
{
    // Customized: restore public methods for collection-body actions. Generation currently emits only
    // REST request builders that accept RequestContent, so custom code serializes the enumerable body.
    [CodeGenSuppress("UpdateCustomServicesAsync", typeof(IEnumerable<CustomService>), typeof(CancellationToken))]
    [CodeGenSuppress("UpdateCustomServices", typeof(IEnumerable<CustomService>), typeof(CancellationToken))]
    [CodeGenSuppress("UpdateDataMountsAsync", typeof(IEnumerable<MachineLearningComputeInstanceDataMount>), typeof(CancellationToken))]
    [CodeGenSuppress("UpdateDataMounts", typeof(IEnumerable<MachineLearningComputeInstanceDataMount>), typeof(CancellationToken))]
    public partial class MachineLearningComputeResource
    {
        /// <summary> Updates the custom services list. The list of custom services provided shall be overwritten. </summary>
        /// <param name="customServices"> New list of Custom Services. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> UpdateCustomServicesAsync(IEnumerable<CustomService> customServices, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(customServices, nameof(customServices));

            using DiagnosticScope scope = _computeClientDiagnostics.CreateScope("ComputeResource.UpdateCustomServices");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                RequestContent content = MachineLearningSerializationHelpers.CreateEnumerableContent(customServices);
                HttpMessage message = _computeRestClient.CreateUpdateCustomServicesRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, content, context);
                return await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Updates the custom services list. The list of custom services provided shall be overwritten. </summary>
        /// <param name="customServices"> New list of Custom Services. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response UpdateCustomServices(IEnumerable<CustomService> customServices, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(customServices, nameof(customServices));

            using DiagnosticScope scope = _computeClientDiagnostics.CreateScope("ComputeResource.UpdateCustomServices");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                RequestContent content = MachineLearningSerializationHelpers.CreateEnumerableContent(customServices);
                HttpMessage message = _computeRestClient.CreateUpdateCustomServicesRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, content, context);
                return Pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Update Data Mounts of a Machine Learning compute. </summary>
        /// <param name="dataMounts"> The parameters for creating or updating a machine learning workspace. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<Response> UpdateDataMountsAsync(IEnumerable<MachineLearningComputeInstanceDataMount> dataMounts, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(dataMounts, nameof(dataMounts));

            using DiagnosticScope scope = _computeClientDiagnostics.CreateScope("ComputeResource.UpdateDataMounts");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                RequestContent content = MachineLearningSerializationHelpers.CreateEnumerableContent(dataMounts);
                HttpMessage message = _computeRestClient.CreateUpdateDataMountsRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, content, context);
                return await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Update Data Mounts of a Machine Learning compute. </summary>
        /// <param name="dataMounts"> The parameters for creating or updating a machine learning workspace. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Response UpdateDataMounts(IEnumerable<MachineLearningComputeInstanceDataMount> dataMounts, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(dataMounts, nameof(dataMounts));

            using DiagnosticScope scope = _computeClientDiagnostics.CreateScope("ComputeResource.UpdateDataMounts");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                RequestContent content = MachineLearningSerializationHelpers.CreateEnumerableContent(dataMounts);
                HttpMessage message = _computeRestClient.CreateUpdateDataMountsRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, content, context);
                return Pipeline.ProcessMessage(message, context);
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
