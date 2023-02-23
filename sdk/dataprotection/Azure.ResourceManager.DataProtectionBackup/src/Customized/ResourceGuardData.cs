// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.DataProtectionBackup
{
    /// <summary> A class representing the ResourceGuard data model. </summary>
    public partial class ResourceGuardData
    {
        /// <summary> Input Managed Identity Details. </summary>
        [Obsolete("This property is obsolete and will be removed in a future release. Please do not use it any longer.", false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ManagedServiceIdentity Identity { get; set; }
    }
}
