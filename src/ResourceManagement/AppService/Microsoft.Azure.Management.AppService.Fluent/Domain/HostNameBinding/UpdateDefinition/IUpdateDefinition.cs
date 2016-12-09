// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent.HostNameBinding.UpdateDefinition
{
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.AppService.Fluent;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;

    /// <summary>
    /// The stage of a hostname binding definition allowing DNS record type to be set.
    /// </summary>
    public interface IWithHostNameDnsRecordType<ParentT> 
    {
        /// <summary>
        /// Specifies the DNS record type.
        /// </summary>
        /// <param name="hostNameDnsRecordType">The DNS record type.</param>
        Microsoft.Azure.Management.AppService.Fluent.HostNameBinding.UpdateDefinition.IWithAttach<ParentT> WithDnsRecordType(CustomHostNameDnsRecordType hostNameDnsRecordType);
    }

    /// <summary>
    /// The stage of a hostname binding definition allowing sub-domain to be specified.
    /// </summary>
    public interface IWithSubDomain<ParentT> 
    {
        /// <summary>
        /// Specifies the sub-domain to bind to.
        /// </summary>
        /// <param name="subDomain">The sub-domain name excluding the top level domain, e.g., ".</param>
        /// <",>"www".</",>
        Microsoft.Azure.Management.AppService.Fluent.HostNameBinding.UpdateDefinition.IWithHostNameDnsRecordType<ParentT> WithSubDomain(string subDomain);
    }

    /// <summary>
    /// The stage of a hostname binding definition allowing domain to be specified.
    /// </summary>
    public interface IWithDomain<ParentT> 
    {
        /// <summary>
        /// Binds to a 3rd party domain.
        /// </summary>
        /// <param name="domain">The 3rd party domain name.</param>
        Microsoft.Azure.Management.AppService.Fluent.HostNameBinding.UpdateDefinition.IWithSubDomain<ParentT> WithThirdPartyDomain(string domain);

        /// <summary>
        /// Binds to a domain purchased from Azure.
        /// </summary>
        /// <param name="domain">The domain purchased from Azure.</param>
        Microsoft.Azure.Management.AppService.Fluent.HostNameBinding.UpdateDefinition.IWithSubDomain<ParentT> WithAzureManagedDomain(IAppServiceDomain domain);
    }

    /// <summary>
    /// The first stage of a host name binding definition.
    /// </summary>
    public interface IBlank<ParentT>  :
        IWithDomain<ParentT>
    {
    }

    /// <summary>
    /// The final stage of the hostname binding definition.
    /// <p>
    /// At this stage, any remaining optional settings can be specified, or the hostname binding definition
    /// can be attached to the parent web app  update using WithAttach.attach().
    /// </summary>
    public interface IWithAttach<ParentT>  :
        IInUpdate<ParentT>
    {
    }

    /// <summary>
    /// The entirety of a hostname binding definition as part of a web app update.
    /// </summary>
    public interface IUpdateDefinition<ParentT>  :
        IBlank<ParentT>,
        IWithDomain<ParentT>,
        IWithSubDomain<ParentT>,
        IWithHostNameDnsRecordType<ParentT>,
        IWithAttach<ParentT>
    {
    }
}