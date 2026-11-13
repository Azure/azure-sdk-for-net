// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.OperationalInsights.Models;

namespace Azure.ResourceManager.OperationalInsights
{
    // Backward-compat justification: the GA SDK kept obsolete enum-shaped aliases for the newer boolean table retention flags.
    public partial class OperationalInsightsTableData
    {
        /// <summary> True - Value originates from workspace retention in days, False - Customer specific. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This property is obsolete and will be removed in a future release, please use `IsRetentionInDaysAsDefault` instead", false)]
        public RetentionInDaysAsDefaultState? RetentionInDaysAsDefault => IsRetentionInDaysAsDefault is null ? default : IsRetentionInDaysAsDefault.Value ? RetentionInDaysAsDefaultState.True : RetentionInDaysAsDefaultState.False;

        /// <summary> True - Value originates from retention in days, False - Customer specific. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [System.Obsolete("This property is obsolete and will be removed in a future release, please use `IsTotalRetentionInDaysAsDefault` instead", false)]
        public TotalRetentionInDaysAsDefaultState? TotalRetentionInDaysAsDefault => IsTotalRetentionInDaysAsDefault is null ? default : IsTotalRetentionInDaysAsDefault.Value ? TotalRetentionInDaysAsDefaultState.True : TotalRetentionInDaysAsDefaultState.False;
    }
}
