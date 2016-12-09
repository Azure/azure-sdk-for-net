// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using HostNameBinding.Definition;
    using HostNameBinding.UpdateDefinition;
    using WebAppBase.Definition;
    using WebAppBase.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using Microsoft.Rest;
    using System.Collections.Generic;

    internal partial class HostNameBindingImpl<FluentT,FluentImplT> 
    {
        /// <summary>
        /// Binds to a domain purchased from Azure.
        /// </summary>
        /// <param name="domain">The domain purchased from Azure.</param>
        HostNameBinding.Definition.IWithSubDomain<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>> HostNameBinding.Definition.IWithDomain<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>>.WithAzureManagedDomain(IAppServiceDomain domain)
        {
            return this.WithAzureManagedDomain(domain) as HostNameBinding.Definition.IWithSubDomain<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>>;
        }

        /// <summary>
        /// Binds to a 3rd party domain.
        /// </summary>
        /// <param name="domain">The 3rd party domain name.</param>
        HostNameBinding.Definition.IWithSubDomain<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>> HostNameBinding.Definition.IWithDomain<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>>.WithThirdPartyDomain(string domain)
        {
            return this.WithThirdPartyDomain(domain) as HostNameBinding.Definition.IWithSubDomain<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>>;
        }

        /// <summary>
        /// Binds to a domain purchased from Azure.
        /// </summary>
        /// <param name="domain">The domain purchased from Azure.</param>
        HostNameBinding.UpdateDefinition.IWithSubDomain<WebAppBase.Update.IUpdate<FluentT>> HostNameBinding.UpdateDefinition.IWithDomain<WebAppBase.Update.IUpdate<FluentT>>.WithAzureManagedDomain(IAppServiceDomain domain)
        {
            return this.WithAzureManagedDomain(domain) as HostNameBinding.UpdateDefinition.IWithSubDomain<WebAppBase.Update.IUpdate<FluentT>>;
        }

        /// <summary>
        /// Binds to a 3rd party domain.
        /// </summary>
        /// <param name="domain">The 3rd party domain name.</param>
        HostNameBinding.UpdateDefinition.IWithSubDomain<WebAppBase.Update.IUpdate<FluentT>> HostNameBinding.UpdateDefinition.IWithDomain<WebAppBase.Update.IUpdate<FluentT>>.WithThirdPartyDomain(string domain)
        {
            return this.WithThirdPartyDomain(domain) as HostNameBinding.UpdateDefinition.IWithSubDomain<WebAppBase.Update.IUpdate<FluentT>>;
        }

        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        string Microsoft.Azure.Management.Resource.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id();
            }
        }

        /// <summary>
        /// Specifies the DNS record type.
        /// </summary>
        /// <param name="hostNameDnsRecordType">The DNS record type.</param>
        HostNameBinding.Definition.IWithAttach<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>> HostNameBinding.Definition.IWithHostNameDnsRecordType<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>>.WithDnsRecordType(CustomHostNameDnsRecordType hostNameDnsRecordType)
        {
            return this.WithDnsRecordType(hostNameDnsRecordType) as HostNameBinding.Definition.IWithAttach<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>>;
        }

        /// <summary>
        /// Specifies the DNS record type.
        /// </summary>
        /// <param name="hostNameDnsRecordType">The DNS record type.</param>
        HostNameBinding.UpdateDefinition.IWithAttach<WebAppBase.Update.IUpdate<FluentT>> HostNameBinding.UpdateDefinition.IWithHostNameDnsRecordType<WebAppBase.Update.IUpdate<FluentT>>.WithDnsRecordType(CustomHostNameDnsRecordType hostNameDnsRecordType)
        {
            return this.WithDnsRecordType(hostNameDnsRecordType) as HostNameBinding.UpdateDefinition.IWithAttach<WebAppBase.Update.IUpdate<FluentT>>;
        }

        string Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding.WebAppName
        {
            get
            {
                return this.WebAppName();
            }
        }

        Microsoft.Azure.Management.AppService.Fluent.Models.AzureResourceType Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding.AzureResourceType
        {
            get
            {
                return this.AzureResourceType();
            }
        }

        Microsoft.Azure.Management.AppService.Fluent.Models.CustomHostNameDnsRecordType Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding.DnsRecordType
        {
            get
            {
                return this.DnsRecordType();
            }
        }

        Microsoft.Azure.Management.AppService.Fluent.Models.HostNameType Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding.HostNameType
        {
            get
            {
                return this.HostNameType();
            }
        }

        string Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding.DomainId
        {
            get
            {
                return this.DomainId();
            }
        }

        string Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding.HostName
        {
            get
            {
                return this.HostName();
            }
        }

        string Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding.AzureResourceName
        {
            get
            {
                return this.AzureResourceName();
            }
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        WebAppBase.Update.IUpdate<FluentT> Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update.IInUpdate<WebAppBase.Update.IUpdate<FluentT>>.Attach()
        {
            return this.Attach() as WebAppBase.Update.IUpdate<FluentT>;
        }

        /// <summary>
        /// Execute the create request.
        /// </summary>
        Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding>.Create()
        {
            return this.Create() as Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding;
        }

        /// <summary>
        /// Puts the request into the queue and allow the HTTP client to execute
        /// it when system resources are available.
        /// </summary>
        async Task<Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions.IIndexable> Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding>.CreateAsync(CancellationToken cancellationToken, bool multiThreaded = true)
        {
            return await this.CreateAsync(cancellationToken) as Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions.IIndexable;
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        WebAppBase.Definition.IWithHostNameSslBinding<FluentT> Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition.IInDefinition<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>>.Attach()
        {
            return this.Attach() as WebAppBase.Definition.IWithHostNameSslBinding<FluentT>;
        }

        Microsoft.Azure.Management.Resource.Fluent.Core.Region Microsoft.Azure.Management.Resource.Fluent.Core.IResource.Region
        {
            get
            {
                return this.Region() as Microsoft.Azure.Management.Resource.Fluent.Core.Region;
            }
        }

        string Microsoft.Azure.Management.Resource.Fluent.Core.IResource.Type
        {
            get
            {
                return this.Type();
            }
        }

        System.Collections.Generic.IReadOnlyDictionary<string,string> Microsoft.Azure.Management.Resource.Fluent.Core.IResource.Tags
        {
            get
            {
                return this.Tags() as System.Collections.Generic.IReadOnlyDictionary<string,string>;
            }
        }

        string Microsoft.Azure.Management.Resource.Fluent.Core.IResource.RegionName
        {
            get
            {
                return this.RegionName();
            }
        }

        /// <summary>
        /// Specifies the sub-domain to bind to.
        /// </summary>
        /// <param name="subDomain">The sub-domain name excluding the top level domain, e.g., ".</param>
        /// <",>"www".</",>
        HostNameBinding.Definition.IWithHostNameDnsRecordType<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>> HostNameBinding.Definition.IWithSubDomain<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>>.WithSubDomain(string subDomain)
        {
            return this.WithSubDomain(subDomain) as HostNameBinding.Definition.IWithHostNameDnsRecordType<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>>;
        }

        /// <summary>
        /// Specifies the sub-domain to bind to.
        /// </summary>
        /// <param name="subDomain">The sub-domain name excluding the top level domain, e.g., ".</param>
        /// <",>"www".</",>
        HostNameBinding.UpdateDefinition.IWithHostNameDnsRecordType<WebAppBase.Update.IUpdate<FluentT>> HostNameBinding.UpdateDefinition.IWithSubDomain<WebAppBase.Update.IUpdate<FluentT>>.WithSubDomain(string subDomain)
        {
            return this.WithSubDomain(subDomain) as HostNameBinding.UpdateDefinition.IWithHostNameDnsRecordType<WebAppBase.Update.IUpdate<FluentT>>;
        }
    }
}