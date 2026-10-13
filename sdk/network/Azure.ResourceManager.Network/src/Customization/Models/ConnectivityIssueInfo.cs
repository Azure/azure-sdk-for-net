// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Azure.ResourceManager.Network.Models
{
    public partial class ConnectivityIssueInfo
    {
        // Generation restores the 1.15 names. Preserve the 1.16.1/1.17 renames as
        // deprecated aliases sharing native enum storage and the original list/dictionaries.
        /// <summary> The type of issue. </summary>
        [WirePath("type")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and might be removed in a future version, please use `ConnectivityIssueType` instead", false)]
        public ConnectivityIssueType? Type => ConnectivityIssueType;

        /// <summary> Provides additional context on the issue. </summary>
        [WirePath("context")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and might be removed in a future version, please use `Contexts` instead", false)]
        public IReadOnlyList<IDictionary<string, string>> Context => Contexts;
    }
}
