// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using Models;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;

    /// <summary>
    /// An immutable representation of a host name binding.
    /// </summary>
    /// <remarks>
    /// (Beta: This functionality is in preview and as such is subject to change in non-backwards compatible ways in future releases, including removal, regardless of any compatibility expectations set by the containing library version number.)
    /// </remarks>
    public interface IHostNameBinding  :
        IHasInner<Models.HostNameBindingInner>,
        IExternalChildResource<Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding,Microsoft.Azure.Management.AppService.Fluent.IWebAppBase>,
        IResource
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