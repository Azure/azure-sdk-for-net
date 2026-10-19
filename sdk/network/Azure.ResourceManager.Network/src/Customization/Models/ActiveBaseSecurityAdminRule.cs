// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.ResourceManager.Network.Models
{
    public abstract partial class ActiveBaseSecurityAdminRule
    {
        /// <summary> Initializes a new instance of the ActiveBaseSecurityAdminRule class. </summary>
        protected ActiveBaseSecurityAdminRule()
        {
        }

        // This protected overload shipped in 1.17.0; external subclasses can call it.
        /// <summary> Initializes a new instance of the ActiveBaseSecurityAdminRule class. </summary>
        protected ActiveBaseSecurityAdminRule(bool _) { }
    }
}
