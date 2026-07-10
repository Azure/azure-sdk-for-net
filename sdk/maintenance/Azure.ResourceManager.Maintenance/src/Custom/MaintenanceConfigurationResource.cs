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
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.Maintenance
{
    // The generator now models this delete as non-generic ArmOperation, but the shipped SDK returned ArmOperation<MaintenanceConfigurationResource>.
    [CodeGenSuppress("DeleteAsync", typeof(WaitUntil), typeof(CancellationToken))]
    [CodeGenSuppress("Delete", typeof(WaitUntil), typeof(CancellationToken))]
    public partial class MaintenanceConfigurationResource
    {
        /// <summary> Delete Configuration record. </summary>
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
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<MaintenanceConfigurationData> typedResponse = Response.FromValue(MaintenanceConfigurationData.FromResponse(response), response);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Delete, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                MaintenanceArmOperation<MaintenanceConfigurationResource> operation = new MaintenanceArmOperation<MaintenanceConfigurationResource>(Response.FromValue(new MaintenanceConfigurationResource(Client, typedResponse.Value), typedResponse.GetRawResponse()), rehydrationToken);
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

        /// <summary> Delete Configuration record. </summary>
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
                Response response = Pipeline.ProcessMessage(message, context);
                Response<MaintenanceConfigurationData> typedResponse = Response.FromValue(MaintenanceConfigurationData.FromResponse(response), response);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Delete, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                MaintenanceArmOperation<MaintenanceConfigurationResource> operation = new MaintenanceArmOperation<MaintenanceConfigurationResource>(Response.FromValue(new MaintenanceConfigurationResource(Client, typedResponse.Value), typedResponse.GetRawResponse()), rehydrationToken);
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
