// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.NetApp
{
    /// <summary>
    /// A class representing the NetAppAccount data model.
    /// </summary>
    public partial class NetAppAccountData : TrackedResourceData
    {
        /// <summary> Domain for NFSv4 user ID mapping. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string NfsV4IdDomain
        {
            get => NfsV4IDDomain;
            set => NfsV4IDDomain = value;
        }
    }
}
