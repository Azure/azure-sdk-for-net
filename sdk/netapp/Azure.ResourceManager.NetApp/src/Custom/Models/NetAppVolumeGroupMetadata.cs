// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;

namespace Azure.ResourceManager.NetApp.Models
{
    // Backward-compat: GA exposed `DeploymentSpecId` on this model. The new spec dropped
    // the field entirely (it's no longer on the wire), so the generator emits no property.
    // We keep a writable string here so existing user code compiles; the value is not
    // serialized. Spec change cannot fix this — restoring the property in TypeSpec would
    // re-introduce a field the service no longer supports.
    public partial class NetAppVolumeGroupMetadata
    {
        /// <summary> Application specific identifier of deployment rules for the volume group (no longer transmitted). </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string DeploymentSpecId { get; set; }
    }
}
