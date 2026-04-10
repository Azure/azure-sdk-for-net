// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ComponentModel;
using Azure.Core;

namespace Azure.ResourceManager.Compute.Models
{
    /// <summary> This type is obsolete. Cloud Services (classic) are no longer supported for new customers. </summary>
    [EditorBrowsable(EditorBrowsableState.Never)]
    [Obsolete("CloudService operations are no longer supported.")]
    public partial class UpdateDomainIdentifier
    {
        /// <summary> Initializes a new instance of UpdateDomainIdentifier. </summary>
        public UpdateDomainIdentifier()
        {
        }

        /// <summary> The resource ID. </summary>
        public ResourceIdentifier Id { get; }

        /// <summary> The name. </summary>
        public string Name { get; }
    }
}
