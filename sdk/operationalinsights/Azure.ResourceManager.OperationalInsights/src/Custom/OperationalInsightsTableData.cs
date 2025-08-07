// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.Core;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.OperationalInsights.Models;

namespace Azure.ResourceManager.OperationalInsights
{
    /// <summary>
    /// A class representing the OperationalInsightsTable data model.
    /// Workspace data table definition.
    /// </summary>
    public partial class OperationalInsightsTableData : ResourceData
    {
        /// <summary> True - Value originates from workspace retention in days, False - Customer specific. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future release, please use `IsRetentionInDaysAsDefault` instead", false)]
        public RetentionInDaysAsDefaultState? RetentionInDaysAsDefault => new RetentionInDaysAsDefaultState(IsRetentionInDaysAsDefault.ToString());
        /// <summary> True - Value originates from retention in days, False - Customer specific. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and will be removed in a future release, please use `IsTotalRetentionInDaysAsDefault` instead", false)]
        public TotalRetentionInDaysAsDefaultState? TotalRetentionInDaysAsDefault => new TotalRetentionInDaysAsDefaultState(IsTotalRetentionInDaysAsDefault.ToString());
    }
}
