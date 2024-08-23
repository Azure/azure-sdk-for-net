// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.Threading;
using System.Threading.Tasks;
using Autorest.CSharp.Core;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.ApiManagement.Models;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.ApiManagement
{
    public partial class ApiManagementServiceResource
    {
        /// <summary>
        /// Upgrades an API Management service to the Stv2 platform. For details refer to https://aka.ms/apim-migrate-stv2. This change is not reversible. This is long running operation and could take several minutes to complete.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/migrateToStv2</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ApiManagementService_MigrateToStv2</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-08-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ApiManagementServiceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<ArmOperation<ApiManagementServiceResource>> MigrateToStv2Async(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _apiManagementServiceClientDiagnostics.CreateScope("ApiManagementServiceResource.MigrateToStv2");
            scope.Start();
            try
            {
                var response = await _apiManagementServiceRestClient.MigrateToStv2Async(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, null, cancellationToken).ConfigureAwait(false);
                var operation = new ApiManagementArmOperation<ApiManagementServiceResource>(new ApiManagementServiceOperationSource(Client), _apiManagementServiceClientDiagnostics, Pipeline, _apiManagementServiceRestClient.CreateMigrateToStv2Request(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, null).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Upgrades an API Management service to the Stv2 platform. For details refer to https://aka.ms/apim-migrate-stv2. This change is not reversible. This is long running operation and could take several minutes to complete.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.ApiManagement/service/{serviceName}/migrateToStv2</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>ApiManagementService_MigrateToStv2</description>
        /// </item>
        /// <item>
        /// <term>Default Api Version</term>
        /// <description>2022-08-01</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="ApiManagementServiceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual ArmOperation<ApiManagementServiceResource> MigrateToStv2(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using var scope = _apiManagementServiceClientDiagnostics.CreateScope("ApiManagementServiceResource.MigrateToStv2");
            scope.Start();
            try
            {
                var response = _apiManagementServiceRestClient.MigrateToStv2(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, null, cancellationToken);
                var operation = new ApiManagementArmOperation<ApiManagementServiceResource>(new ApiManagementServiceOperationSource(Client), _apiManagementServiceClientDiagnostics, Pipeline, _apiManagementServiceRestClient.CreateMigrateToStv2Request(Id.SubscriptionId, Id.ResourceGroupName, Id.Name, null).Request, response, OperationFinalStateVia.Location);
                if (waitUntil == WaitUntil.Completed)
                    operation.WaitForCompletion(cancellationToken);
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }
    }
}
