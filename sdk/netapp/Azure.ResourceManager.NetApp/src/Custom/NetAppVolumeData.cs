// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.NetApp.Models;
using Microsoft.TypeSpec.Generator.Customizations;
using ETag = Azure.ETag;

namespace Azure.ResourceManager.NetApp
{
    // The new spec models Volume with TrackedResource<VolumeProperties, false> (no eTag template
    // arg) and IsRestoring as a read-only property. The previously shipped (autorest) SDK exposed
    // ETag as Azure.Core.ETag? and IsRestoring with a setter. Restore both via custom partial.
    public partial class NetAppVolumeData
    {
        // Replace the generated `string ETag` with the GA-shipped `Azure.Core.ETag?` shape.
        /// <summary> If etag is provided in the response body, it may also be provided as a header per the normal etag convention. </summary>
        [CodeGenMember("ETag")]
        public ETag? ETag { get; }

        // The new spec marks isRestoring as read-only; restore the GA setter for source compat.
        /// <summary> Restoring. </summary>
        [CodeGenMember("IsRestoring")]
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
