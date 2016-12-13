// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.AppService.Fluent
{
    using HostNameBinding.UpdateDefinition;
    using Microsoft.Azure.Management.AppService.Fluent.Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ResourceActions;
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Text.RegularExpressions;
    using System.Threading;
    using System.Threading.Tasks;

    /// <summary>
    /// Implementation for HostNameBinding and its create and update interfaces.
    /// </summary>
    /// <typeparam name="Fluent">The fluent interface of the parent web app.</typeparam>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50LmFwcHNlcnZpY2UuaW1wbGVtZW50YXRpb24uSG9zdE5hbWVCaW5kaW5nSW1wbA==
    internal partial class HostNameBindingImpl<FluentT, FluentImplT> :
        IndexableWrapper<Microsoft.Azure.Management.AppService.Fluent.Models.HostNameBindingInner>,
        ICreatable<Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding>,
        IHostNameBinding,
        HostNameBinding.Definition.IDefinition<WebAppBase.Definition.IWithHostNameSslBinding<FluentT>>,
        IUpdateDefinition<WebAppBase.Update.IUpdate<FluentT>>
        where FluentImplT : IWebAppBase
    {
        private WebAppsOperations client;
        private FluentImplT parent;
        private string domainName;
        private string name;

        string ICreatable<IHostNameBinding>.Name
        {
            get
            {
                return this.Name();
            }
        }

        string IExternalChildResource<Microsoft.Azure.Management.AppService.Fluent.IHostNameBinding, Microsoft.Azure.Management.AppService.Fluent.IWebAppBase>.Id
        {
            get
            {
                return this.Id();
            }
        }

        ///GENMHASH:6A2970A94B2DD4A859B00B9B9D9691AD:A96EEE048AFB7EAC724AC09421CBB824
        public Region Region()
        {
            return Resource.Fluent.Core.Region.Create(Inner.Location);
        }

        ///GENMHASH:4B19A5F1B35CA91D20F63FBB66E86252:783B8B84020BF7A1FA8A58B407A27A05
        public IReadOnlyDictionary<string, string> Tags()
        {
            return new ReadOnlyDictionary<string, string>(Inner.Tags);
        }

        ///GENMHASH:4C616F44C9C4BFD93594B6D9092A394A:0AC8A05BCD3A6B7CBD7958C57BCC894F
        public string WebAppName()
        {
            return Inner.SiteName;
        }

        ///GENMHASH:6512D3749B75699084BD4F008D90C101:1006227322BF1ED668B3D3B04C2C1A00
        public HostNameBindingImpl<FluentT, FluentImplT> WithSubDomain(string subDomain)
        {
            this.name = NormalizeHostNameBindingName(subDomain, domainName);
            return this;
        }

        ///GENMHASH:F340B9C68B7C557DDB54F615FEF67E89:0D9EEC636DF1E11A81923129881E6F92
        public string RegionName()
        {
            return Inner.Location;
        }

        ///GENMHASH:FD5D5A8D6904B467321E345BE1FA424E:8AB87020DE6C711CD971F3D80C33DD83
        public IWebAppBase Parent
        {
            get
            {
                return parent;
            }
        }

        ///GENMHASH:F256BA36B49E86A329FE6E9053FAA2C2:30BCCB9C5D6F49D3148D3A9D412D6197
        public HostNameBindingImpl<FluentT, FluentImplT> WithThirdPartyDomain(string domain)
        {
            Inner.HostNameType = Models.HostNameType.Verified;
            this.domainName = domain;

            return this;
        }

        ///GENMHASH:32A8B56FE180FA4429482D706189DEA2:3785204345CF88A369A14E3305BB659F
        public async Task<IHostNameBinding> CreateAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            var hostNameBindingInner = parent is IDeploymentSlot
                    ? await client.CreateOrUpdateHostNameBindingSlotAsync(parent.ResourceGroupName, ((IDeploymentSlot)parent).Parent.Name, name, Inner, parent.Name)
                    : await client.CreateOrUpdateHostNameBindingAsync(parent.ResourceGroupName, parent.Name, name, Inner);
            SetInner(hostNameBindingInner);

            return this;
        }

        ///GENMHASH:8442F1C1132907DE46B62B277F4EE9B7:E3457FB289E9A7DFF460A938FF6FD7DA
        public string Type()
        {
            return Inner.Type;
        }

        ///GENMHASH:5E4C278C0FA45BB98AA6EAEE080D4953:FC16212D06A7CCEE646CE7693B370B6F
        public IHostNameBinding Create()
        {
            return CreateAsync().Result;
        }

        ///GENMHASH:1AF7DCAA563064BE5F57020487ABA63B:9EB989BD7CA88C88EBCC64DAB83581CD
        private string NormalizeHostNameBindingName(string hostname, string domainName)
        {
            if (!hostname.EndsWith(domainName))
            {
                hostname = hostname + "." + domainName;
            }
            if (hostname.StartsWith("@"))
            {
                hostname = hostname.Replace("@.", "");
            }
            return hostname;
        }

        ///GENMHASH:027705B70337BE533ED77421800E496A:3479885A232C974264B5B36BDBB0BC94
        public HostNameBindingImpl<FluentT, FluentImplT> WithDnsRecordType(CustomHostNameDnsRecordType hostNameDnsRecordType)
        {
            var regex = new Regex("([.\\w-]+)\\.([\\w-]+\\.\\w+)");
            var matcher = regex.Match(name);
            if (hostNameDnsRecordType == CustomHostNameDnsRecordType.CName && !matcher.Success)
            {
                throw new ArgumentException("root hostname cannot be assigned with a CName record");
            }
            Inner.CustomHostNameDnsRecordType = hostNameDnsRecordType;
            return this;
        }

        ///GENMHASH:391F429F2F6335F8A114F6E5D4A7CE4F:D5DE9C8F381EEA2FECB193111C19E3AD
        public string AzureResourceName()
        {
            return Inner.AzureResourceName;
        }

        ///GENMHASH:24340C987C56F99E226AF26D83E77627:7AF4C6011A58443A74EDBD12E2EA8E0D
        public AzureResourceType AzureResourceType()
        {
            return Inner.AzureResourceType.GetValueOrDefault();
        }

        ///GENMHASH:405D133ADB31FC54FCFE6E63CC7CE6DF:528163E8A39CE260ED65B356ABCB872C
        internal HostNameBindingImpl(HostNameBindingInner innerObject, FluentImplT parent, WebAppsOperations client)
                : base(innerObject)
        {
            this.parent = parent;
            this.client = client;
            this.name = innerObject.Name;
            if (name != null && name.Contains("/"))
            {
                this.name = name.Replace(parent.Name + "/", "");
            }
        }

        ///GENMHASH:ACA2D5620579D8158A29586CA1FF4BC6:A3CF7B3DC953F353AAE8083D72F74056
        public string Id()
        {
            return Inner.Id;
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:992852B5097545C1876518403FBE36D3
        public FluentImplT Attach()
        {
            parent.WithHostNameBinding(this);
            return parent;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:2436A145BB7A20817F8EDCB98EB71DCC
        public string Name()
        {
            return name;
        }

        ///GENMHASH:A701DC349A4F821FC206F08C4A471087:61F78AD55A4BB349399340E2341849F0
        public HostNameType HostNameType()
        {
            return Inner.HostNameType.GetValueOrDefault();
        }

        ///GENMHASH:3C4657168E780E36F1CE2B07D32C5B18:20A09597173832F7AFC3EB433FE6EE44
        public string DomainId()
        {
            return Inner.DomainId;
        }

        ///GENMHASH:59BD08590AE4E08698EC46108AE16392:3DDC5ABFBDE5AEE9DE057925DDE8EFA7
        public CustomHostNameDnsRecordType DnsRecordType()
        {
            return Inner.CustomHostNameDnsRecordType.GetValueOrDefault();
        }

        ///GENMHASH:8F156E891E25FA23FCB8AE0E23601BEC:7FF0A8A46536F20F09EC2FE338F3B99E
        public HostNameBindingImpl<FluentT, FluentImplT> WithAzureManagedDomain(IAppServiceDomain domain)
        {
            Inner.DomainId = domain.Id;
            Inner.HostNameType = Models.HostNameType.Managed;
            this.domainName = domain.Name;

            return this;
        }

        ///GENMHASH:A50A011CA652E846C1780DCE98D171DE:3B4125CAAD58112F3DE1E3F8B2B754D5
        public string HostName()
        {
            return Inner.HostNameBindingName;
        }

        ///GENMHASH:9E6C2387B371ABFFE71039FB9CDF745F:E5EF1EA4BA2D309DA43A37720754443C
        public string ToString()
        {
            String suffix;
            if (AzureResourceType() == Models.AzureResourceType.TrafficManager)
            {
                suffix = ".Trafficmanager.Net";
            }
            else
            {
                suffix = ".Azurewebsites.Net";
            }
            return name + ": " + DnsRecordType() + " " + AzureResourceName() + suffix;
        }

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:E0D0D53840F0C86DC4B91B99218C81C9
        public HostNameBindingImpl<FluentT, FluentImplT> Refresh()
        {
            if (parent is IDeploymentSlot)
            {
                this.SetInner(client.GetHostNameBindingSlot(Parent.ResourceGroupName, ((IDeploymentSlot)parent).Parent.Name, parent.Name, name));
            }
            else
            {
                this.SetInner(client.GetHostNameBinding(parent.ResourceGroupName, parent.Name, name));
            }

            return this;
        }

        IHostNameBinding IRefreshable<IHostNameBinding>.Refresh()
        {
            // TODO - ans - ??
            throw new NotImplementedException();
        }
    }
}