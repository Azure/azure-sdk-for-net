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
    public partial class AppComplianceReportSnapshotCollection : ArmCollection, IEnumerable<AppComplianceReportSnapshotResource>, IAsyncEnumerable<AppComplianceReportSnapshotResource>
    {
        /// <summary>
        /// Get the AppComplianceAutomation snapshot list.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.AppComplianceAutomation/reports/{reportName}/snapshots</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Snapshot_List</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppComplianceReportSnapshotResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="options"> A property bag which contains all the parameters of this method except the LRO qualifier and request context parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> An async collection of <see cref="AppComplianceReportSnapshotResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual AsyncPageable<AppComplianceReportSnapshotResource> GetAllAsync(AppComplianceReportSnapshotCollectionGetAllOptions options, CancellationToken cancellationToken = default)
            => GetAllAsync(options.SkipToken, options.Top, options.Select, options.Filter, options.Orderby, options.OfferGuid, options.ReportCreatorTenantId, cancellationToken);

        /// <summary>
        /// Get the AppComplianceAutomation snapshot list.
        /// <list type="bullet">
        /// <item>
        /// <term>Request Path</term>
        /// <description>/providers/Microsoft.AppComplianceAutomation/reports/{reportName}/snapshots</description>
        /// </item>
        /// <item>
        /// <term>Operation Id</term>
        /// <description>Snapshot_List</description>
        /// </item>
        /// <item>
        /// <term>Resource</term>
        /// <description><see cref="AppComplianceReportSnapshotResource"/></description>
        /// </item>
        /// </list>
        /// </summary>
        /// <param name="options"> A property bag which contains all the parameters of this method except the LRO qualifier and request context parameter. </param>
        /// <param name="cancellationToken"> The cancellation token to use. </param>
        /// <returns> A collection of <see cref="AppComplianceReportSnapshotResource"/> that may take multiple service requests to iterate over. </returns>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual Pageable<AppComplianceReportSnapshotResource> GetAll(AppComplianceReportSnapshotCollectionGetAllOptions options, CancellationToken cancellationToken = default)
            => GetAll(options.SkipToken, options.Top, options.Select, options.Filter, options.Orderby, options.OfferGuid, options.ReportCreatorTenantId, cancellationToken);
    }
}
