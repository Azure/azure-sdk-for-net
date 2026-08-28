// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager;
using Azure.ResourceManager.GuestConfiguration.Models;
using Azure.ResourceManager.Resources;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.GuestConfiguration
{
    [CodeGenSuppress("Delete", typeof(WaitUntil), typeof(CancellationToken))]
    [CodeGenSuppress("DeleteAsync", typeof(WaitUntil), typeof(CancellationToken))]
    public partial class GuestConfigurationVmssAssignmentResource
    {
        /// <summary> Get a report for the VMSS guest configuration assignment, by reportId. </summary>
        /// <param name="id"> The GUID for the guest configuration assignment report. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<GuestConfigurationAssignmentReport>> GetReportAsync(string id, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));

            using DiagnosticScope scope = _guestConfigurationAssignmentReportsVMSSClientDiagnostics.CreateScope("GuestConfigurationVmssAssignmentResource.GetReport");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _guestConfigurationAssignmentReportsVMSSRestClient.CreateGetReportRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, id, Id.Name, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<GuestConfigurationAssignmentReport> response = Response.FromValue(GuestConfigurationAssignmentReport.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Get a report for the VMSS guest configuration assignment, by reportId. </summary>
        /// <param name="id"> The GUID for the guest configuration assignment report. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<GuestConfigurationAssignmentReport> GetReport(string id, CancellationToken cancellationToken = default)
        {
            Argument.AssertNotNullOrEmpty(id, nameof(id));

            using DiagnosticScope scope = _guestConfigurationAssignmentReportsVMSSClientDiagnostics.CreateScope("GuestConfigurationVmssAssignmentResource.GetReport");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                HttpMessage message = _guestConfigurationAssignmentReportsVMSSRestClient.CreateGetReportRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, id, Id.Name, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<GuestConfigurationAssignmentReport> response = Response.FromValue(GuestConfigurationAssignmentReport.FromResponse(result), result);
                if (response.Value == null)
                {
                    throw new RequestFailedException(response.GetRawResponse());
                }
                return response;
            }
            catch (Exception e)
            {
                scope.Failed(e);
                throw;
            }
        }

        /// <summary> Delete a guest configuration assignment for VMSS. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual async Task<ArmOperation<GuestConfigurationVmssAssignmentResource>> DeleteAsync(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _guestConfigurationAssignmentsVMSSClientDiagnostics.CreateScope("GuestConfigurationVmssAssignmentResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _guestConfigurationAssignmentsVMSSRestClient.CreateDeleteForVmssRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
                Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                Response<GuestConfigurationAssignmentData> response = Response.FromValue(GuestConfigurationAssignmentData.FromResponse(result), result);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Delete, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                GuestConfigurationArmOperation<GuestConfigurationVmssAssignmentResource> operation = new GuestConfigurationArmOperation<GuestConfigurationVmssAssignmentResource>(Response.FromValue(new GuestConfigurationVmssAssignmentResource(Client, response.Value), response.GetRawResponse()), rehydrationToken);
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

        /// <summary> Delete a guest configuration assignment for VMSS. </summary>
        /// <param name="waitUntil"> <see cref="WaitUntil.Completed"/> if the method should wait to return until the long-running operation has completed on the service; <see cref="WaitUntil.Started"/> if it should return after starting the operation. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual ArmOperation<GuestConfigurationVmssAssignmentResource> Delete(WaitUntil waitUntil, CancellationToken cancellationToken = default)
        {
            using DiagnosticScope scope = _guestConfigurationAssignmentsVMSSClientDiagnostics.CreateScope("GuestConfigurationVmssAssignmentResource.Delete");
            scope.Start();
            try
            {
                RequestContext context = new RequestContext
                {
                    CancellationToken = cancellationToken
                };
                HttpMessage message = _guestConfigurationAssignmentsVMSSRestClient.CreateDeleteForVmssRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
                Response result = Pipeline.ProcessMessage(message, context);
                Response<GuestConfigurationAssignmentData> response = Response.FromValue(GuestConfigurationAssignmentData.FromResponse(result), result);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Delete, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                GuestConfigurationArmOperation<GuestConfigurationVmssAssignmentResource> operation = new GuestConfigurationArmOperation<GuestConfigurationVmssAssignmentResource>(Response.FromValue(new GuestConfigurationVmssAssignmentResource(Client, response.Value), response.GetRawResponse()), rehydrationToken);
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
