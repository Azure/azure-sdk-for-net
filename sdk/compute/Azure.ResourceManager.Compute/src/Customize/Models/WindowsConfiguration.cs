// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.ComponentModel;

namespace Azure.ResourceManager.Compute.Models
{
    // Backward-compat shim. v1.14.0 baseline exposed both `EnableAutomaticUpdates` and
    // `IsAutomaticUpdatesEnabled` for the same wire field; the Is* form is the new
    // canonical name and Enable* is kept as a deprecated alias for source compatibility.
    public partial class WindowsConfiguration
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? EnableAutomaticUpdates
        {
            get => IsAutomaticUpdatesEnabled;
            set => IsAutomaticUpdatesEnabled = value;
        }
    }
}
