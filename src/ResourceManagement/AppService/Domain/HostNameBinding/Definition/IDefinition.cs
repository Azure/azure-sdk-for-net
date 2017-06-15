// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent.HostNameBinding.Definition
{
    using Microsoft.Azure.Management.AppService.Fluent;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.AppService.Fluent.Models;

    /// <summary>
    /// The stage of a hostname binding definition allowing domain to be specified.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithDomain<ParentT> 
    {
        /// <summary>
        /// Binds to a 3rd party domain.
        /// </summary>
        /// <param name="domain">The 3rd party domain name.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.HostNameBinding.Definition.IWithSubDomain<ParentT> WithThirdPartyDomain(string domain);

        /// <summary>
        /// Binds to a domain purchased from Azure.
        /// </summary>
        /// <param name="domain">The domain purchased from Azure.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.HostNameBinding.Definition.IWithSubDomain<ParentT> WithAzureManagedDomain(IAppServiceDomain domain);
    }

    /// <summary>
    /// The final stage of the hostname binding definition.
    /// At this stage, any remaining optional settings can be specified, or the hostname binding definition
    /// can be attached to the parent web app definition using  WithAttach.attach().
    /// </summary>
    /// <typeparam name="ParentT">The return type of  WithAttach.attach().</typeparam>
    public interface IWithAttach<ParentT>  :
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<ParentT>
    {
    }

    /// <summary>
    /// The stage of a hostname binding definition allowing sub-domain to be specified.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithSubDomain<ParentT> 
    {
        /// <summary>
        /// Specifies the sub-domain to bind to.
        /// </summary>
        /// <param name="subDomain">The sub-domain name excluding the top level domain, e.g., ".</param>
        /// <",>"www".</",>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.HostNameBinding.Definition.IWithHostNameDnsRecordType<ParentT> WithSubDomain(string subDomain);
    }

    /// <summary>
    /// The entirety of a hostname binding definition.
    /// </summary>
    /// <typeparam name="ParentT">The return type of the final  Attachable.attach().</typeparam>
    public interface IDefinition<ParentT>  :
        Microsoft.Azure.Management.AppService.Fluent.HostNameBinding.Definition.IBlank<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.HostNameBinding.Definition.IWithDomain<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.HostNameBinding.Definition.IWithSubDomain<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.HostNameBinding.Definition.IWithHostNameDnsRecordType<ParentT>,
        Microsoft.Azure.Management.AppService.Fluent.HostNameBinding.Definition.IWithAttach<ParentT>
    {
    }

    /// <summary>
    /// The first stage of a host name binding definition.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IBlank<ParentT>  :
        Microsoft.Azure.Management.AppService.Fluent.HostNameBinding.Definition.IWithDomain<ParentT>
    {
    }

    /// <summary>
    /// The stage of a hostname binding definition allowing DNS record type to be set.
    /// </summary>
    /// <typeparam name="ParentT">The stage of the parent definition to return to after attaching this definition.</typeparam>
    public interface IWithHostNameDnsRecordType<ParentT> 
    {
        /// <summary>
        /// Specifies the DNS record type.
        /// </summary>
        /// <param name="hostNameDnsRecordType">The DNS record type.</param>
        /// <return>The next stage of the definition.</return>
        Microsoft.Azure.Management.AppService.Fluent.HostNameBinding.Definition.IWithAttach<ParentT> WithDnsRecordType(CustomHostNameDnsRecordType hostNameDnsRecordType);
    }
}