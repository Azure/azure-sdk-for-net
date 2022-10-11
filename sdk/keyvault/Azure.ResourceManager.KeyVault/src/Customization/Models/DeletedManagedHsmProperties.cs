// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.KeyVault.Models
{
    /// <summary> Properties of the deleted managed HSM. </summary>
    public partial class DeletedManagedHsmProperties
    {
        /// <summary> The deleted date. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public DateTimeOffset? DeletionOn => DeletedOn;
    }
}
