// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using System.Threading;
    using System.Threading.Tasks;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.AppService.Fluent.HostNameBinding.Definition;
    using Microsoft.Azure.Management.AppService.Fluent.HostNameBinding.UpdateDefinition;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Definition;
    using Microsoft.Azure.Management.AppService.Fluent.WebAppBase.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update;
    using Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions;
    using Microsoft.Rest;
    using System.Collections.Generic;

    internal partial class HostNameBindingImpl<FluentT, FluentImplT, DefAfterRegionT, DefAfterGroupT, UpdateT> 
    {
        /// <summary>
        /// Binds to a domain purchased from Azure.
        /// </summary>
        /// <param name="domain">The domain purchased from Azure.</param>
        /// <return>The next stage of the definition.</return>
        HostNameBinding.Definition.IWithSubDomain<WebAppBase.Definition.IWithCreate<FluentT>> HostNameBinding.Definition.IWithDomain<WebAppBase.Definition.IWithCreate<FluentT>>.WithAzureManagedDomain(IAppServiceDomain domain)
        {
            return this.WithAzureManagedDomain(domain) as HostNameBinding.Definition.IWithSubDomain<WebAppBase.Definition.IWithCreate<FluentT>>;
        }

        /// <summary>
        /// Binds to a 3rd party domain.
        /// </summary>
        /// <param name="domain">The 3rd party domain name.</param>
        /// <return>The next stage of the definition.</return>
        HostNameBinding.Definition.IWithSubDomain<WebAppBase.Definition.IWithCreate<FluentT>> HostNameBinding.Definition.IWithDomain<WebAppBase.Definition.IWithCreate<FluentT>>.WithThirdPartyDomain(string domain)
        {
            return this.WithThirdPartyDomain(domain) as HostNameBinding.Definition.IWithSubDomain<WebAppBase.Definition.IWithCreate<FluentT>>;
        }

        /// <summary>
        /// Binds to a domain purchased from Azure.
        /// </summary>
        /// <param name="domain">The domain purchased from Azure.</param>
        /// <return>The next stage of the definition.</return>
        HostNameBinding.UpdateDefinition.IWithSubDomain<WebAppBase.Update.IUpdate<FluentT>> HostNameBinding.UpdateDefinition.IWithDomain<WebAppBase.Update.IUpdate<FluentT>>.WithAzureManagedDomain(IAppServiceDomain domain)
        {
            return this.WithAzureManagedDomain(domain) as HostNameBinding.UpdateDefinition.IWithSubDomain<WebAppBase.Update.IUpdate<FluentT>>;
        }

        /// <summary>
        /// Binds to a 3rd party domain.
        /// </summary>
        /// <param name="domain">The 3rd party domain name.</param>
        /// <return>The next stage of the definition.</return>
        HostNameBinding.UpdateDefinition.IWithSubDomain<WebAppBase.Update.IUpdate<FluentT>> HostNameBinding.UpdateDefinition.IWithDomain<WebAppBase.Update.IUpdate<FluentT>>.WithThirdPartyDomain(string domain)
        {
            return this.WithThirdPartyDomain(domain) as HostNameBinding.UpdateDefinition.IWithSubDomain<WebAppBase.Update.IUpdate<FluentT>>;
        }

        /// <summary>
        /// Gets the resource ID string.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasId.Id
        {
            get
            {
                return this.Id();
            }
        }

        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IHasName.Name
        {
            get
            {
                return this.Name();
            }
        }

        /// <summary>
        /// Specifies the DNS record type.
        /// </summary>
        /// <param name="hostNameDnsRecordType">The DNS record type.</param>
        /// <return>The next stage of the definition.</return>
        HostNameBinding.Definition.IWithAttach<WebAppBase.Definition.IWithCreate<FluentT>> HostNameBinding.Definition.IWithHostNameDnsRecordType<WebAppBase.Definition.IWithCreate<FluentT>>.WithDnsRecordType(CustomHostNameDnsRecordType hostNameDnsRecordType)
        {
            return this.WithDnsRecordType(hostNameDnsRecordType) as HostNameBinding.Definition.IWithAttach<WebAppBase.Definition.IWithCreate<FluentT>>;
        }

        /// <summary>
        /// Specifies the DNS record type.
        /// </summary>
        /// <param name="hostNameDnsRecordType">The DNS record type.</param>
        /// <return>The next stage of the definition.</return>
        HostNameBinding.UpdateDefinition.IWithAttach<WebAppBase.Update.IUpdate<FluentT>> HostNameBinding.UpdateDefinition.IWithHostNameDnsRecordType<WebAppBase.Update.IUpdate<FluentT>>.WithDnsRecordType(CustomHostNameDnsRecordType hostNameDnsRecordType)
        {
            return this.WithDnsRecordType(hostNameDnsRecordType) as HostNameBinding.UpdateDefinition.IWithAttach<WebAppBase.Update.IUpdate<FluentT>>;
        }

        /// <summary>
        /// Gets the hostname to bind to.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding.HostName
        {
            get
            {
                return this.HostName();
            }
        }

        /// <summary>
        /// Gets the fully qualified ARM domain resource URI.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding.DomainId
        {
            get
            {
                return this.DomainId();
            }
        }

        /// <summary>
        /// Gets Azure resource type.
        /// </summary>
        Models.AzureResourceType Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding.AzureResourceType
        {
            get
            {
                return this.AzureResourceType();
            }
        }

        /// <summary>
        /// Gets the host name type.
        /// </summary>
        Models.HostNameType Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding.HostNameType
        {
            get
            {
                return this.HostNameType();
            }
        }

        /// <summary>
        /// Gets Azure resource name to bind to.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding.AzureResourceName
        {
            get
            {
                return this.AzureResourceName();
            }
        }

        /// <summary>
        /// Gets the web app name.
        /// </summary>
        string Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding.WebAppName
        {
            get
            {
                return this.WebAppName();
            }
        }

        /// <summary>
        /// Gets custom DNS record type.
        /// </summary>
        Models.CustomHostNameDnsRecordType Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding.DnsRecordType
        {
            get
            {
                return this.DnsRecordType();
            }
        }

        /// <summary>
        /// Attaches the child definition to the parent resource update.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        WebAppBase.Update.IUpdate<FluentT> Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Update.IInUpdate<WebAppBase.Update.IUpdate<FluentT>>.Attach()
        {
            return this.Attach() as WebAppBase.Update.IUpdate<FluentT>;
        }

        /// <summary>
        /// Execute the create request.
        /// </summary>
        /// <return>The create resource.</return>
        Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding>.Create()
        {
            return this.Create() as Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding;
        }

        /// <summary>
        /// Puts the request into the queue and allow the HTTP client to execute
        /// it when system resources are available.
        /// </summary>
        /// <return>An observable of the request.</return>
        async Task<IHostNameBinding> Microsoft.Azure.Management.ResourceManager.Fluent.Core.ResourceActions.ICreatable<Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding>.CreateAsync(CancellationToken cancellationToken, bool multiThreaded)
        {
            return await this.CreateAsync(cancellationToken);
        }

        /// <summary>
        /// Attaches the child definition to the parent resource definiton.
        /// </summary>
        /// <return>The next stage of the parent definition.</return>
        WebAppBase.Definition.IWithCreate<FluentT> Microsoft.Azure.Management.ResourceManager.Fluent.Core.ChildResource.Definition.IInDefinition<WebAppBase.Definition.IWithCreate<FluentT>>.Attach()
        {
            return this.Attach() as WebAppBase.Definition.IWithCreate<FluentT>;
        }

        /// <summary>
        /// Gets the name of the region the resource is in.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IResource.RegionName
        {
            get
            {
                return this.RegionName();
            }
        }

        /// <summary>
        /// Gets the tags for the resource.
        /// </summary>
        System.Collections.Generic.IReadOnlyDictionary<string,string> Microsoft.Azure.Management.ResourceManager.Fluent.Core.IResource.Tags
        {
            get
            {
                return this.Tags() as System.Collections.Generic.IReadOnlyDictionary<string,string>;
            }
        }

        /// <summary>
        /// Gets the region the resource is in.
        /// </summary>
        Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region Microsoft.Azure.Management.ResourceManager.Fluent.Core.IResource.Region
        {
            get
            {
                return this.Region() as Microsoft.Azure.Management.ResourceManager.Fluent.Core.Region;
            }
        }

        /// <summary>
        /// Gets the type of the resource.
        /// </summary>
        string Microsoft.Azure.Management.ResourceManager.Fluent.Core.IResource.Type
        {
            get
            {
                return this.Type();
            }
        }

        /// <summary>
        /// Specifies the sub-domain to bind to.
        /// </summary>
        /// <param name="subDomain">The sub-domain name excluding the top level domain, e.g., ".</param>
        /// <",>"www".</",>
        /// <return>The next stage of the definition.</return>
        HostNameBinding.Definition.IWithHostNameDnsRecordType<WebAppBase.Definition.IWithCreate<FluentT>> HostNameBinding.Definition.IWithSubDomain<WebAppBase.Definition.IWithCreate<FluentT>>.WithSubDomain(string subDomain)
        {
            return this.WithSubDomain(subDomain) as HostNameBinding.Definition.IWithHostNameDnsRecordType<WebAppBase.Definition.IWithCreate<FluentT>>;
        }

        /// <summary>
        /// Specifies the sub-domain to bind to.
        /// </summary>
        /// <param name="subDomain">The sub-domain name excluding the top level domain, e.g., ".</param>
        /// <",>"www".</",>
        /// <return>The next stage of the definition.</return>
        HostNameBinding.UpdateDefinition.IWithHostNameDnsRecordType<WebAppBase.Update.IUpdate<FluentT>> HostNameBinding.UpdateDefinition.IWithSubDomain<WebAppBase.Update.IUpdate<FluentT>>.WithSubDomain(string subDomain)
        {
            return this.WithSubDomain(subDomain) as HostNameBinding.UpdateDefinition.IWithHostNameDnsRecordType<WebAppBase.Update.IUpdate<FluentT>>;
        }
    }
}