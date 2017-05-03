// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// An immutable representation of a host name binding.
    /// </summary>
    public interface IHostNameBinding  :
        IBeta,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasInner<Models.HostNameBindingInner>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IExternalChildResource<Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding,Microsoft.Azure.Management.AppService.Fluent.IWebAppBase>,
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.IResource
    {
        /// <summary>
        /// Gets the web app name.
        /// </summary>
        string WebAppName { get; }

        /// <summary>
        /// Gets the host name type.
        /// </summary>
        Models.HostNameType HostNameType { get; }

        /// <summary>
        /// Gets custom DNS record type.
        /// </summary>
        Models.CustomHostNameDnsRecordType DnsRecordType { get; }

        /// <summary>
        /// Gets the fully qualified ARM domain resource URI.
        /// </summary>
        string DomainId { get; }

        /// <summary>
        /// Gets the hostname to bind to.
        /// </summary>
        string HostName { get; }

        /// <summary>
        /// Gets Azure resource type.
        /// </summary>
        Models.AzureResourceType AzureResourceType { get; }

        /// <summary>
        /// Gets Azure resource name to bind to.
        /// </summary>
        string AzureResourceName { get; }
    }
}