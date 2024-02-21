// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.SecurityCenter.Models
{
    /// <summary> The sensitivity label. </summary>
    public partial class SensitivityLabel
    {
        /// <summary> Indicates whether the label is enabled or not. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Enabled { get { return IsEnabled; } set { IsEnabled = value; } }
    }
}
