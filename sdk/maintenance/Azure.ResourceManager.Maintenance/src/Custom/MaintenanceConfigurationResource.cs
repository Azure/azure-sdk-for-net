// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.Maintenance.Models;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Maintenance
{
    [CodeGenSuppress("Delete", typeof(WaitUntil), typeof(CancellationToken))]
    [CodeGenSuppress("DeleteAsync", typeof(WaitUntil), typeof(CancellationToken))]

    public partial class MaintenanceConfigurationResource
    {
        /// <summary>
        /// Delete Configuration record
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Maintenance/maintenanceConfigurations/{resourceName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> MaintenanceConfigurationOperationGroup_Delete. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-10-01-preview. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="MaintenanceConfigurationResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation<MaintenanceConfigurationResource>> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _maintenanceConfigurationsClientDiagnostics.CreateScope("MaintenanceConfigurationResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _maintenanceConfigurationsRestClient.CreateDeleteExRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<MaintenanceConfigurationData> response = Response.FromValue(MaintenanceConfigurationData.FromResponse(result), result);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Delete, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                MaintenanceArmOperation<MaintenanceConfigurationResource> operation = new MaintenanceArmOperation<MaintenanceConfigurationResource>(Response.FromValue(new MaintenanceConfigurationResource(Client, response.Value), response.GetRawResponse()), rehydrationToken);
                if (waitUntil == WaitUntil.Completed)
                {
                    await operation.WaitForCompletionAsync(cancellationToken).ConfigureAwait(false);
                }
                return operation;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary>
        /// Delete Configuration record
        /// <list type="bullet">
        /// <item>
        /// <term> Request Path. </term>
        /// <description> /subscriptions/{subscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Maintenance/maintenanceConfigurations/{resourceName}. </description>
        /// </item>
        /// <item>
        /// <term> Operation Id. </term>
        /// <description> MaintenanceConfigurationOperationGroup_Delete. </description>
        /// </item>
        /// <item>
        /// <term> Default Api Version. </term>
        /// <description> 2025-10-01-preview. </description>
        /// </item>
        /// <item>
        /// <term> Resource. </term>
        /// <description> <see cref="MaintenanceConfigurationResource"/>. </description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. For more information on long-running operations, please see <see href="https://github.com/Azure/azure-sdk-for-net/blob/main/sdk/core/Azure.Core/samples/LongRunningOperations.md"> Azure.Core Long-Running Operation samples</see>. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<MaintenanceConfigurationResource> Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _maintenanceConfigurationsClientDiagnostics.CreateScope("MaintenanceConfigurationResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _maintenanceConfigurationsRestClient.CreateDeleteExRequest(Guid.Parse(Id.SubscriptionId), Id.ResourceGroupName, Id.Name, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<MaintenanceConfigurationData> response = Response.FromValue(MaintenanceConfigurationData.FromResponse(result), result);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Delete, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                MaintenanceArmOperation<MaintenanceConfigurationResource> operation = new MaintenanceArmOperation<MaintenanceConfigurationResource>(Response.FromValue(new MaintenanceConfigurationResource(Client, response.Value), response.GetRawResponse()), rehydrationToken);
                if (waitUntil == WaitUntil.Completed)
                {
                    operation.WaitForCompletion(cancellationToken);
                }
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
