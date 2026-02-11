// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.ResourceManager.GuestConfiguration.Models;

namespace Azure.ResourceManager.GuestConfiguration
{
    public partial class GuestConfigurationVMwarevSphereAssignmentResource
    {
        /// <summary> Get a report for the guest configuration assignment, by reportId. </summary>
        /// <param name="reportId"> The GUID for the guest configuration assignment report. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual async Task<Response<GuestConfigurationAssignmentReport>> GetGuestConfigurationConnectedVMwarevSphereAssignmentsReportAsync(string reportId, CancellationToken cancellationToken = default)
        {
            return await GetReportAsync(reportId, cancellationToken).ConfigureAwait(false);
        }

        /// <summary> Get a report for the guest configuration assignment, by reportId. </summary>
        /// <param name="reportId"> The GUID for the guest configuration assignment report. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Response<GuestConfigurationAssignmentReport> GetGuestConfigurationConnectedVMwarevSphereAssignmentsReport(string reportId, CancellationToken cancellationToken = default)
        {
            return GetReport(reportId, cancellationToken);
        }

        /// <summary> List all reports for the guest configuration assignment, latest report first. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<GuestConfigurationAssignmentReport> GetGuestConfigurationConnectedVMwarevSphereAssignmentsReportsAsync(CancellationToken cancellationToken = default)
        {
            return new SinglePageAsyncPageable<GuestConfigurationAssignmentReport>(async () =>
            {
                var response = await GetReportsAsync(cancellationToken).ConfigureAwait(false);
                return (response.Value.Value, response.GetRawResponse());
            });
        }

        /// <summary> List all reports for the guest configuration assignment, latest report first. </summary>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<GuestConfigurationAssignmentReport> GetGuestConfigurationConnectedVMwarevSphereAssignmentsReports(CancellationToken cancellationToken = default)
        {
            return new SinglePagePageable<GuestConfigurationAssignmentReport>(() =>
            {
                var response = GetReports(cancellationToken);
                return (response.Value.Value, response.GetRawResponse());
            });
        }
    }
}
