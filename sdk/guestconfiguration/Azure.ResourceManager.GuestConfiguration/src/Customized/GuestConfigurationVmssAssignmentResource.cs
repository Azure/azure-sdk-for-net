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
using Azure.ResourceManager.GuestConfiguration.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.GuestConfiguration
{
    // The generator now models this delete as non-generic ArmOperation, but the shipped SDK returned ArmOperation<GuestConfigurationVmssAssignmentResource>.
    [CodeGenSuppress("DeleteAsync", typeof(WaitUntil), typeof(CancellationToken))]
    [CodeGenSuppress("Delete", typeof(WaitUntil), typeof(CancellationToken))]
    public partial class GuestConfigurationVmssAssignmentResource
    {
        /// <summary> Delete a guest configuration assignment for VMSS. </summary>
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
                Response response = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Delete, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                GuestConfigurationArmOperation<GuestConfigurationVmssAssignmentResource> operation = new GuestConfigurationArmOperation<GuestConfigurationVmssAssignmentResource>(Response.FromValue(new GuestConfigurationVmssAssignmentResource(Client, Id), response), rehydrationToken);
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
                Response response = Pipeline.ProcessMessage(message, context);
                RequestUriBuilder uri = message.Request.Uri;
                RehydrationToken rehydrationToken = NextLinkOperationImplementation.GetRehydrationToken(RequestMethod.Delete, uri.ToUri(), uri.ToString(), "None", null, OperationFinalStateVia.OriginalUri.ToString());
                GuestConfigurationArmOperation<GuestConfigurationVmssAssignmentResource> operation = new GuestConfigurationArmOperation<GuestConfigurationVmssAssignmentResource>(Response.FromValue(new GuestConfigurationVmssAssignmentResource(Client, Id), response), rehydrationToken);
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
    }
}
