// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

namespace Azure.Provisioning.AppService;

/// <summary>
/// Current DNS type.
/// </summary>
// Preserve the API shipped by the reflection-based generator for resource providers absent from the Microsoft.Web TypeSpec.
[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Never)]
[System.Obsolete("All domain registration APIs are moved to the new Azure.ResourceManager.DomainRegistration namespace.")]
public enum AppServiceDnsType
{
    /// <summary>
    /// AzureDns.
    /// </summary>
    AzureDns,

    /// <summary>
    /// DefaultDomainRegistrarDns.
    /// </summary>
    DefaultDomainRegistrarDns,
}
