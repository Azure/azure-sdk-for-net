// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;

namespace Azure.Provisioning.Search
{
    /// <summary> A data exfiltration scenario that is disabled for the search service. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("This type is obsoleted and will be removed in a future versions, please use SearchDataExfiltrationProtection instead.")]
    public enum SearchDisabledDataExfiltrationOption
    {
        /// <summary> Indicates that all data exfiltration scenarios are disabled. </summary>
        All,
    }
}
