// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.ResourceManager.NetApp.Models;

namespace Azure.ResourceManager.NetApp
{
    // The spec now generates the GA ETag shape. The remaining custom member restores the
    // GA setter for IsRestoring, which is read-only in the current service contract.
    public partial class NetAppVolumeData
    {
        // The new spec marks isRestoring as read-only; restore the GA setter for source compat.
        /// <summary> Restoring. </summary>
        public bool? IsRestoring
        {
            get
            {
                return Properties is null ? default : Properties.IsRestoring;
            }
            [EditorBrowsable(EditorBrowsableState.Never)]
            set
            {
                // Setter retained for backward compatibility; isRestoring is read-only on the
                // service, so the value is not propagated to the request payload.
            }
        }
    }
}
