// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.GuestConfiguration.Models;
using Microsoft.TypeSpec.Generator.Customizations;

namespace Azure.ResourceManager.GuestConfiguration
{
    [CodeGenSuppress("GetReportsAsync", typeof(CancellationToken))]
    [CodeGenSuppress("GetReports", typeof(CancellationToken))]
    public partial class GuestConfigurationVmAssignmentResource
    {
        /// <summary>
        /// List all reports for the guest configuration assignment, latest report first.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual AsyncPageable<GuestConfigurationAssignmentReport> GetReportsAsync(CancellationToken cancellationToken = default)
        {
            return new SinglePageAsyncPageable<GuestConfigurationAssignmentReport>(async () =>
            {
                using DiagnosticScope scope = _guestConfigurationAssignmentReportsClientDiagnostics.CreateScope("GuestConfigurationVmAssignmentResource.GetReports");
                scope.Start();
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    HttpMessage message = _guestConfigurationAssignmentReportsRestClient.CreateGetReportsRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
                    Response result = await Pipeline.ProcessMessageAsync(message, context).ConfigureAwait(false);
                    var reportList = GuestConfigurationAssignmentReportList.FromResponse(result);
                    return ((IList<GuestConfigurationAssignmentReport>)reportList.Value, result);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            });
        }

        /// <summary>
        /// List all reports for the guest configuration assignment, latest report first.
        /// </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        public virtual Pageable<GuestConfigurationAssignmentReport> GetReports(CancellationToken cancellationToken = default)
        {
            return new SinglePagePageable<GuestConfigurationAssignmentReport>(() =>
            {
                using DiagnosticScope scope = _guestConfigurationAssignmentReportsClientDiagnostics.CreateScope("GuestConfigurationVmAssignmentResource.GetReports");
                scope.Start();
                try
                {
                    RequestContext context = new RequestContext { CancellationToken = cancellationToken };
                    HttpMessage message = _guestConfigurationAssignmentReportsRestClient.CreateGetReportsRequest(Id.SubscriptionId, Id.ResourceGroupName, Id.Parent.Name, Id.Name, context);
                    Response result = Pipeline.ProcessMessage(message, context);
                    var reportList = GuestConfigurationAssignmentReportList.FromResponse(result);
                    return ((IList<GuestConfigurationAssignmentReport>)reportList.Value, result);
                }
                catch (Exception e)
                {
                    scope.Failed(e);
                    throw;
                }
            });
        }
    }
}
