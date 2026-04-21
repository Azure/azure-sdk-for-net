// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp
{
    public partial class SnapshotPolicyData
    {
        /// <summary> Compatibility shim for the former property name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Enabled
        {
            get => IsEnabled;
            set => IsEnabled = value;
        }
    }
}
