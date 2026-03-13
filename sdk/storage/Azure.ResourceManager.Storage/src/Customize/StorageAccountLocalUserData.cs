// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.Storage.Models;

namespace Azure.ResourceManager.Storage
{
    public partial class StorageAccountLocalUserData
    {
        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.allowAclAuthorization")]
        public bool? IsAclAuthorizationAllowed
        {
            get => Properties is null ? default : Properties.IsAclAuthorizationAllowed;
            set
            {
                if (Properties is null)
                {
                    Properties = new LocalUserProperties();
                }
                Properties.IsAclAuthorizationAllowed = value;
            }
        }

        [EditorBrowsable(EditorBrowsableState.Never)]
        [WirePath("properties.isNFSv3Enabled")]
        public bool? IsNfsV3Enabled
        {
            get => Properties is null ? default : Properties.IsNfsV3Enabled;
            set
            {
                if (Properties is null)
                {
                    Properties = new LocalUserProperties();
                }
                Properties.IsNfsV3Enabled = value;
            }
        }
    }
}
