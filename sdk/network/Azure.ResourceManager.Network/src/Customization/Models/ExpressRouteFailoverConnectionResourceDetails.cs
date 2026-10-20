// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using System.Globalization;

namespace Azure.ResourceManager.Network.Models
{
    public partial class ExpressRouteFailoverConnectionResourceDetails
    {
        // The native date owns storage; retain the migration's string name as a round-trip alias.
        /// <summary> Gets the last update time in round-trip format. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        [Obsolete("This property is obsolete and might be removed in a future version, use LastUpdatedOn instead", false)]
        public string LastUpdatedTime => LastUpdatedOn?.ToString("O", CultureInfo.InvariantCulture);
    }
}
