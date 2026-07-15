// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Provisioning.OperationalInsights
{
    // Preserve the previously shipped orphan enum for backward compatibility.
    /// <summary>
    /// True - Value originates from retention in days, False - Customer specific.
    /// </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is deprecated and it will be removed in a future version.")]
    public enum TotalRetentionInDaysAsDefaultState
    {
        /// <summary> Value originates from retention in days. </summary>
        True = 0,

        /// <summary> Value is customer specific. </summary>
        False = 1,
    }
}
