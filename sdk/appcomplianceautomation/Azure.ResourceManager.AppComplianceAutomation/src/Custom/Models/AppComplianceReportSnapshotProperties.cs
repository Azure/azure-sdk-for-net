// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using Azure.ResourceManager.AppComplianceAutomation;
using Azure.ResourceManager.Models;

// NOTE: The following customization is intentionally retained for backward compatibility.
namespace Azure.ResourceManager.AppComplianceAutomation.Models
{
    public partial class AppComplianceReportSnapshotProperties
    {
        /// <summary> Initializes a new instance of <see cref="AppComplianceReportSnapshotProperties"/>. </summary>
        public AppComplianceReportSnapshotProperties()
        {
            ComplianceResults = new ChangeTrackingList<AppComplianceResult>();
        }
    }
}
