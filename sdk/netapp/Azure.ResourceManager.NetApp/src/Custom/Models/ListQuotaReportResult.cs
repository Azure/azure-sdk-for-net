// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// Backward-compat: QuotaReportRecords was IReadOnlyList in old API, now IList.

#nullable disable

using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Azure.ResourceManager.NetApp.Models
{
    public partial class ListQuotaReportResult
    {
        /// <summary> List of quota report records. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public IReadOnlyList<NetAppVolumeQuotaReport> QuotaReportRecords
        {
            get
            {
                var list = Properties?.QuotaReportRecords;
                return list is null ? null : list.ToList().AsReadOnly();
            }
        }
    }
}
