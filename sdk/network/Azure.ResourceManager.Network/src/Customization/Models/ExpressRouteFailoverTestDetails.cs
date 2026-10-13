// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Globalization;

namespace Azure.ResourceManager.Network.Models
{
    /// <summary> Compatibility declaration for the ExpressRouteFailoverTestDetails type. </summary>
    public partial class ExpressRouteFailoverTestDetails
    {
        // Native dates own storage; retain the migration's string names as round-trip aliases.
        /// <summary> Gets the end time in round-trip format. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and might be removed in a future version, use EndOn instead", false)]
        public string EndTime => EndOn?.ToString("O", CultureInfo.InvariantCulture);
        /// <summary> Gets the start time in round-trip format. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and might be removed in a future version, use StartOn instead", false)]
        public string StartTime => StartOn?.ToString("O", CultureInfo.InvariantCulture);
    }
}
