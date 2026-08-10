// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ComponentModel;

namespace Azure.ResourceManager.AppService.Models
{
    /// <summary> Current DNS type. </summary>
    [Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace.")]
    [EditorBrowsable(EditorBrowsableState.Never)]
    public enum AppServiceDnsType
    {
        /// <summary> AzureDns. </summary>
        AzureDns,
        /// <summary> DefaultDomainRegistrarDns. </summary>
        DefaultDomainRegistrarDns
    }
}
