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

namespace Azure.ResourceManager.SecurityCenter
{
    // Compatibility customization: GA exposed CreateOrUpdate on the resource; the generated TypeSpec surface drops the singleton PUT.
    public partial class AdvancedThreatProtectionSettingResource
    {
        /// <summary>
        /// Creates or updates the Advanced Threat Protection settings on a specified resource.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="data"> Advanced Threat Protection Settings. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation<AdvancedThreatProtectionSettingResource>> CreateOrUpdateAsync(WaitUntil waitUntil, AdvancedThreatProtectionSettingData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _advancedThreatProtectionClientDiagnostics.CreateScope("AdvancedThreatProtectionSettingResource.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _advancedThreatProtectionRestClient.CreateCreateRequest(Id.Parent.ToString(), "current", AdvancedThreatProtectionSettingData.ToRequestContent(data), context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<AdvancedThreatProtectionSettingData> response = Response.FromValue(AdvancedThreatProtectionSettingData.FromResponse(result), result);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                SecurityCenterArmOperation<AdvancedThreatProtectionSettingResource> operation = new SecurityCenterArmOperation<AdvancedThreatProtectionSettingResource>(Response.FromValue(new AdvancedThreatProtectionSettingResource(Client, response.Value), response.GetRawResponse()), rehydrationToken);
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
        /// Creates or updates the Advanced Threat Protection settings on a specified resource.
        /// </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="data"> Advanced Threat Protection Settings. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<AdvancedThreatProtectionSettingResource> CreateOrUpdate(WaitUntil waitUntil, AdvancedThreatProtectionSettingData data, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNull(data, nameof(data));

            using DiagnosticScope scope = _advancedThreatProtectionClientDiagnostics.CreateScope("AdvancedThreatProtectionSettingResource.CreateOrUpdate");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _advancedThreatProtectionRestClient.CreateCreateRequest(Id.Parent.ToString(), "current", AdvancedThreatProtectionSettingData.ToRequestContent(data), context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<AdvancedThreatProtectionSettingData> response = Response.FromValue(AdvancedThreatProtectionSettingData.FromResponse(result), result);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Put, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                SecurityCenterArmOperation<AdvancedThreatProtectionSettingResource> operation = new SecurityCenterArmOperation<AdvancedThreatProtectionSettingResource>(Response.FromValue(new AdvancedThreatProtectionSettingResource(Client, response.Value), response.GetRawResponse()), rehydrationToken);
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
