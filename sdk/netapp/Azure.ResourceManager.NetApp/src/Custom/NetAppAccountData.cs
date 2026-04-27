// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System.ComponentModel;
using Azure.ResourceManager.Models;

namespace Azure.ResourceManager.NetApp
{
    // The generated NetAppAccountData does not surface `NfsV4IdDomain` directly because the
    // matching @@clientName decorator on AccountProperties.nfsV4IDDomain renames the underlying
    // property; this shim re-flattens it onto the outer data type for source compatibility.
    public partial class NetAppAccountData : TrackedResourceData
    {
        /// <summary> Domain for NFSv4 user ID mapping. </summary>
        [EditorBrowsable(EditorBrowsableState.Never)]
        public string NfsV4IdDomain
        {
            get => Properties?.NfsV4IdDomain;
            set
            {
                if (Properties is null)
                    Properties = new Models.AccountProperties();
                Properties.NfsV4IdDomain = value;
            }
        }
    }
}
