// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Appservice.Fluent
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;

    /// <summary>
    /// A host name binding object.
    /// </summary>
    public interface IHostNameBinding  :
        IWrapper<Microsoft.Azure.Management.AppService.Fluent.Models.HostNameBindingInner>,
        IExternalChildResource<Microsoft.Azure.Management.Appservice.Fluent.IHostNameBinding,Microsoft.Azure.Management.Appservice.Fluent.IWebAppBase<object>>,
        IResource
    {
        string WebAppName { get; }

        Microsoft.Azure.Management.AppService.Fluent.Models.HostNameType HostNameType { get; }

        Microsoft.Azure.Management.AppService.Fluent.Models.CustomHostNameDnsRecordType DnsRecordType { get; }

        string DomainId { get; }

        string HostName { get; }

        Microsoft.Azure.Management.AppService.Fluent.Models.AzureResourceType AzureResourceType { get; }

        string AzureResourceName { get; }
    }
}