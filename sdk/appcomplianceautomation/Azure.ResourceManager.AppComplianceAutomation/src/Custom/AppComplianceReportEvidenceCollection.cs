// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using System.Threading;
using Azure.ResourceManager.AppComplianceAutomation.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.AppComplianceAutomation
{
    public partial class AppComplianceReportEvidenceCollection : ArmCollection, IEnumerable<AppComplianceReportEvidenceResource>, IAsyncEnumerable<AppComplianceReportEvidenceResource>
    {
        /// <summary>
        /// Returns a paginated list of evidences for a specified report.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.AppComplianceAutomation/reports/{reportName}/evidences</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Evidence_ListByReport</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppComplianceReportEvidenceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="options"> A property bag which contains all the parameters of this method except the LRO qualifier and request context parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AppComplianceReportEvidenceResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<AppComplianceReportEvidenceResource> GetAllAsync(AppComplianceReportEvidenceCollectionGetAllOptions options, CancellationToken cancellationToken = default)
            => GetAllAsync(options.SkipToken, options.Top, options.Select, options.Filter, options.Orderby, options.OfferGuid, options.ReportCreatorTenantId, cancellationToken);

        /// <summary>
        /// Returns a paginated list of evidences for a specified report.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.AppComplianceAutomation/reports/{reportName}/evidences</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Evidence_ListByReport</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppComplianceReportEvidenceResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="options"> A property bag which contains all the parameters of this method except the LRO qualifier and request context parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AppComplianceReportEvidenceResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<AppComplianceReportEvidenceResource> GetAll(AppComplianceReportEvidenceCollectionGetAllOptions options, CancellationToken cancellationToken = default)
            => GetAll(options.SkipToken, options.Top, options.Select, options.Filter, options.Orderby, options.OfferGuid, options.ReportCreatorTenantId, cancellationToken);
    }
}
