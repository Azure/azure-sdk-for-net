// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;
using Azure.ResourceManager.AppService;

namespace Azure.ResourceManager.AppService.Models
{
    public partial class DefaultIdentity
    {
        /// <summary> Type of managed service identity. </summary>
        [WirePath("identityType")]
        [Obsolete("This property is deprecated and will be removed in a future release. Please use ManagedServiceIdentityType instead.")]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public Azure.ResourceManager.AppService.Models.ManagedServiceIdentityType? IdentityType
        {
            get
            {
                if (this.ManagedServiceIdentityType.HasValue)
                {
                    return (Azure.ResourceManager.AppService.Models.ManagedServiceIdentityType)this.ManagedServiceIdentityType.Value;
                }
                else
                {
                    return null;
                }
            }
            set
            {
                if (value.HasValue)
                {
                    this.ManagedServiceIdentityType = (AppServiceManagedServiceIdentityType)value.Value;
                }
                else
                {
                    this.ManagedServiceIdentityType = null;
                }
            }
        }
    }
}
