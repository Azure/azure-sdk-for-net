// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.GuestConfiguration.Models;

namespace Azure.ResourceManager.GuestConfiguration
{
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
    }
}
