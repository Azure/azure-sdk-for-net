// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.NetApp.Models
{
    /// <summary> Patch for backup policy. </summary>
    public partial class NetAppBackupPolicyPatch
    {
        // Backward compatibility: v1.15.0 exposed this required-location ctor. The TypeSpec model
        // declares `location?: string` (optional), so the generator no longer emits a public ctor.
        // This is the only public ctor (do not hide with [EditorBrowsable(Never)] per migration rules).
        // Chain to base(location) so Tags is initialized by TrackedResourceData.
        /// <summary> Initializes a new instance of <see cref="NetAppBackupPolicyPatch"/>. </summary>
        /// <param name="location"> The location. </param>
        public NetAppBackupPolicyPatch(AzureLocation location) : base(location) { }

        /// <summary> Compatibility shim for the former property name. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool? Enabled
        {
            get => IsEnabled;
            set => IsEnabled = value;
        }
    }
}
