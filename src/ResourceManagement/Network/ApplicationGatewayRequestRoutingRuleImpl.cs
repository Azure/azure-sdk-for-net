// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using Models;
    using ApplicationGatewayRequestRoutingRule.Definition;
    using ApplicationGatewayRequestRoutingRule.UpdateDefinition;
    using ResourceManager.Fluent.Core;
    using System.Collections.Generic;
    using System.IO;
    using ResourceManager.Fluent.Core.ChildResourceActions;
    using ResourceManager.Fluent;
    using System.Linq;

    /// <summary>
    /// Implementation for ApplicationGatewayRequestRoutingRule.
    /// </summary>
    
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uQXBwbGljYXRpb25HYXRld2F5UmVxdWVzdFJvdXRpbmdSdWxlSW1wbA==
    internal partial class ApplicationGatewayRequestRoutingRuleImpl :
        ChildResource<ApplicationGatewayRequestRoutingRuleInner, ApplicationGatewayImpl, IApplicationGateway>,
        IApplicationGatewayRequestRoutingRule,
        IDefinition<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>,
        IUpdateDefinition<ApplicationGateway.Update.IUpdate>,
        ApplicationGatewayRequestRoutingRule.Update.IUpdate
    {
        private bool? associateWithPublicFrontend;

        
        ///GENMHASH:BF497059E01321BD53A7DF19D85F4D8E:C0847EA0CDA78F6D91EFD239C70F0FA7
        internal ApplicationGatewayRequestRoutingRuleImpl(ApplicationGatewayRequestRoutingRuleInner inner, ApplicationGatewayImpl parent) : base(inner, parent)
        {
        }

        #region Withers

        
        ///GENMHASH:75998168C8403D37D5B62BD1214010ED:C1A031BED4FEE36EA5917030CC573179
        public ApplicationGatewayRequestRoutingRuleImpl ToBackendFqdn(string fqdn)
        {
            Parent.UpdateBackend(EnsureBackend().Name()).WithFqdn(fqdn);
            return this;
        }

        
        ///GENMHASH:389A52ADE2A3CD0EC1D4345823ED3438:49DCB9A1FA027B67B2E9041AABC358E5
        public ApplicationGatewayRequestRoutingRuleImpl WithCookieBasedAffinity()
        {
            Parent.UpdateBackendHttpConfiguration(EnsureBackendHttpConfig().Name())
                .WithCookieBasedAffinity();
            return this;
        }

        
        ///GENMHASH:ABF006C723CD07B4C16642781DD352C1:80A92C790A23B4858621E149898669CA
        public ApplicationGatewayRequestRoutingRuleImpl ToBackend(string name)
        {
            var backendRef = new SubResource()
            {
                Id = Parent.FutureResourceId() + "/backendAddressPools/" + name
            };

            Inner.BackendAddressPool = backendRef;
            return this;
        }

        
        ///GENMHASH:61009120769572DC319DE0A706651D48:A9AAC19D1000F85AE80FFDF68E2B7657
        public ApplicationGatewayRequestRoutingRuleImpl FromPrivateFrontend()
        {
            associateWithPublicFrontend = false;
            return this;
        }

        
        ///GENMHASH:1D7C0E3D335976570E947F3D48437E66:21CFE894224FD9175DC687D7587C6B81
        public ApplicationGatewayRequestRoutingRuleImpl WithSslCertificate(string name)
        {
            Parent.UpdateListener(EnsureListener().Name()).WithSslCertificate(name);
            return this;
        }

        
        ///GENMHASH:C9BEFCDC31CD90EB31575FB70FEC63EF:572F23F90AA511055CD97EF80750265B
        public ApplicationGatewayRequestRoutingRuleImpl FromFrontendHttpsPort(int portNumber)
        {
            return FromFrontendPort(portNumber, ApplicationGatewayProtocol.Https, null);
        }

        
        ///GENMHASH:B3B3BBEB4388330056F367AFFE5E08E7:955135520FC3C8B79C3CC7BBD653E1D6
        public ApplicationGatewayRequestRoutingRuleImpl FromPublicFrontend()
        {
            associateWithPublicFrontend = true;
            return this;
        }

        
        ///GENMHASH:CB6B71434C2E17A82873B7892EE00D55:6699CF8695CA8CD4C78C07D022AFE500
        public ApplicationGatewayRequestRoutingRuleImpl WithoutServerNameIndication()
        {
            Parent.UpdateListener(EnsureListener().Name()).WithoutServerNameIndication();
            return this;
        }

        
        ///GENMHASH:C91CE0B00972007A115F692F7D876F49:ADEAE9F132075E8759871A4371ADDDF9
        public ApplicationGatewayRequestRoutingRuleImpl ToBackendIPAddress(string ipAddress)
        {
            Parent.UpdateBackend(EnsureBackend().Name()).WithIPAddress(ipAddress);
            return this;
        }

        
        ///GENMHASH:5ACBA6D500464D19A23A5A5A6A184B79:C49203B793C8E16B0A521362FC4A91D6
        public ApplicationGatewayRequestRoutingRuleImpl WithHostName(string hostName)
        {
            Parent.UpdateListener(EnsureListener().Name()).WithHostName(hostName);
            return this;
        }

        
        ///GENMHASH:DE88BB19D1C1507E6EAAD715D1F861E6:F2935D4C9878DFEC3D331B356A794987
        private ApplicationGatewayRequestRoutingRuleImpl FromFrontendPort(int portNumber, ApplicationGatewayProtocol protocol, string name)
        {
            // Verify no conflicting listener exists
            var listenerByPort = (ApplicationGatewayListenerImpl)this.Parent.ListenerByPortNumber(portNumber);
            IApplicationGatewayListener listenerByName = null;
            if (name != null)
            {
                Parent.Listeners().TryGetValue(name, out listenerByName);
            }

            bool? needToCreate = Parent.NeedToCreate(listenerByName, listenerByPort, name);
            if (needToCreate != null && needToCreate.Value)
            {
                // If no listener exists for the requested port number yet and the name, create one
                if (name == null)
                {
                    name = SdkContext.RandomResourceName("listener", 13);
                }

                listenerByPort = this.Parent.DefineListener(name)
                    .WithFrontendPort(portNumber);

                // Determine protocol
                if (ApplicationGatewayProtocol.Http.Equals(protocol))
                {
                    listenerByPort.WithHttp();
                }
                else if (ApplicationGatewayProtocol.Https.Equals(protocol))
                {
                    listenerByPort.WithHttps();
                }

                // Determine frontend
                if (associateWithPublicFrontend != null && associateWithPublicFrontend.Value)
                {
                    listenerByPort.WithPublicFrontend();
                    Parent.WithNewPublicIPAddress();
                }
                else if (associateWithPublicFrontend != null && !associateWithPublicFrontend.Value)
                {
                    listenerByPort.WithPrivateFrontend();
                }

                associateWithPublicFrontend = null; // Reset, indicating no frontend association need

                listenerByPort.Attach();
                return FromListener(listenerByPort.Name());
            }
            else
            {
                // If matching listener already exists then fail
                return null;
            }
        }

        
        ///GENMHASH:3E9C9108A0B9643E9C6CCF35D944BFF5:124BE7697EDA0DEA9F68AB88B3FD072D
        public ApplicationGatewayRequestRoutingRuleImpl ToBackendHttpPort(int portNumber)
        {
            string name = SdkContext.RandomResourceName("backcfg", 12);
            Parent.DefineBackendHttpConfiguration(name)
               .WithPort(portNumber)
               .Attach();
            return ToBackendHttpConfiguration(name);
        }

        
        ///GENMHASH:64EFD8E5D6EE43236B119988348C8FE5:551C88DB1BFEC84D69F63E5B891BF1C9
        public ApplicationGatewayRequestRoutingRuleImpl FromListener(string name)
        {
            var listenerRef = new SubResource()
            {
                Id = Parent.FutureResourceId() + "/HTTPListeners/" + name
            };
            Inner.HttpListener = listenerRef;
            return this;
        }

        
        ///GENMHASH:4364BC2E794A044FD930E465BFF31892:5F1B09727C6B0D98D3B91D719E4AF6B7
        public ApplicationGatewayRequestRoutingRuleImpl FromFrontendHttpPort(int portNumber)
        {
            return FromFrontendPort(portNumber, ApplicationGatewayProtocol.Http, null);
        }

        
        ///GENMHASH:AFBFDB5617AA4227641C045CF9D86F66:E59D799F1DB4F9650C71EDC18FB6BFBB
        public ApplicationGatewayRequestRoutingRuleImpl WithSslCertificateFromPfxFile(FileInfo pfxFile)
        {
            Parent.UpdateListener(EnsureListener().Name()).WithSslCertificateFromPfxFile(pfxFile);
            return this;
        }

        
        ///GENMHASH:382D2BF4EBC04F5E7DF95B5EF5A97146:A2186495BD577CBC3FCDAFE065A38100
        public ApplicationGatewayRequestRoutingRuleImpl WithSslCertificatePassword(string password)
        {
            Parent.UpdateListener(EnsureListener().Name()).WithSslCertificatePassword(password);
            return this;
        }

        
        ///GENMHASH:E5009D35A881840DCEE40214DFD5197F:C0E7624E9F0A1098FE7AC34D7DC81866
        public ApplicationGatewayRequestRoutingRuleImpl ToBackendHttpConfiguration(string name)
        {
            var httpConfigRef = new SubResource()
            {
                Id = Parent.FutureResourceId() + "/backendHttpSettingsCollection/" + name
            };
            Inner.BackendHttpSettings = httpConfigRef;
            return this;
        }

        
        ///GENMHASH:85408D425EF4341A6D39C75F68ED8A2B:D7EEEE46B8C5048ECEB42B103795D1F6
        public ApplicationGatewayRequestRoutingRuleImpl WithServerNameIndication()
        {
            Parent.UpdateListener(EnsureListener().Name()).WithServerNameIndication();
            return this;
        }

        #endregion

        #region Accessors

        ApplicationGateway.Update.IUpdate ISettable<ApplicationGateway.Update.IUpdate>.Parent()
        {
            return Parent;
        }

        
        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public override string Name()
        {
            return Inner.Name;
        }

        
        ///GENMHASH:D457B9CDACC819681A8B8A61E22717C2:DF12139705045E06926F38A1DB38047A
        public ApplicationGatewayProtocol FrontendProtocol()
        {
            var listener = Listener();
            return (listener != null) ? listener.Protocol() : null;
        }

        
        ///GENMHASH:5EF934D4E2CF202DF23C026435D9F6D6:05FE1E23D6B429BEA4CD7C9EE7596131
        public string PublicIPAddressId()
        {
            var listener = Listener();
            return (listener != null) ? listener.PublicIPAddressId() : null;
        }

        
        ///GENMHASH:A80C3FC8655E547C3392C10C546FFF39:4178B96D859F693DD4C685D2EA97E3C1
        public bool RequiresServerNameIndication()
        {
            var listener = Listener();
            return (listener != null) ? listener.RequiresServerNameIndication() : false;
        }

        
        ///GENMHASH:EB41BE025536B41812665B952EBF2040:31ACB997844CDB27FC8A75BA5FA0E687
        public int FrontendPort()
        {
            var listener = Listener();
            return (listener != null) ? listener.FrontendPortNumber() : 0;
        }

        
        ///GENMHASH:B2F4F96855247681287878DA2BF26C8E:7BE0813A1F69908779DA5794AAE2BD13
        public ApplicationGatewayBackendHttpConfigurationImpl BackendHttpConfiguration()
        {
            var configRef = Inner.BackendHttpSettings;
            if (configRef != null)
            {
                string configName = ResourceUtils.NameFromResourceId(configRef.Id);
                IApplicationGatewayBackendHttpConfiguration config = null;
                return (Parent.BackendHttpConfigurations().TryGetValue(configName, out config)) ? (ApplicationGatewayBackendHttpConfigurationImpl)config : null;
            }
            else
            {
                return null;
            }
        }

        
        ///GENMHASH:597B4CCFA9884BBB039FE1B734196FBB:9BB7A8FF5376A1E35A43987311B73DC5
        public ApplicationGatewayRequestRoutingRuleType RuleType()
        {
            return ApplicationGatewayRequestRoutingRuleType.Parse(Inner.RuleType);
        }

        
        ///GENMHASH:5AC5C38B890C28F2C14CCD5CC0A89B49:0B03E9DA7912B73A5E88BD6441153E80
        public IApplicationGatewayBackend Backend()
        {
            var backendRef = Inner.BackendAddressPool;
            if (backendRef != null)
            {
                string backendName = ResourceUtils.NameFromResourceId(backendRef.Id);
                IApplicationGatewayBackend backend = null;
                return (Parent.Backends().TryGetValue(backendName, out backend)) ? backend : null;
            }
            else
            {
                return null;
            }
        }

        
        ///GENMHASH:1AB1FD137FCAFECBC19E784B21600422:A8E447B9115965EC413B57E517B5DA3B
        public ApplicationGatewayRequestRoutingRuleImpl WithoutCookieBasedAffinity()
        {
            Parent.UpdateBackendHttpConfiguration(EnsureBackendHttpConfig().Name())
                .WithoutCookieBasedAffinity();
            return this;
        }

        
        ///GENMHASH:B7056D5E403DF443379DDF57BB0658A2:95CF36EF4D1A21EAD1633FD0A40F89C9
        public int BackendPort()
        {
            var backendConfig = BackendHttpConfiguration();
            return (backendConfig != null) ? backendConfig.Port() : 0;
        }

        
        ///GENMHASH:1207E16326E66DA6A51CBA6F0565D088:CB87CAA0875D78D6AC5C13AF9397F5C9
        public IApplicationGatewaySslCertificate SslCertificate()
        {
            var listener = Listener();
            return (listener != null) ? listener.SslCertificate() : null;
        }

        
        ///GENMHASH:88B8E503CCDD1E57245F30B2FC889572:820DF50CEF634C47EBC86C7FEFE94C25
        public IReadOnlyCollection<ApplicationGatewayBackendAddress> BackendAddresses()
        {
            var addresses = new List<ApplicationGatewayBackendAddress>();
            var backend = Backend();
            if (backend != null && backend.Addresses != null)
            {
                return backend.Addresses;
            } else
            {
                return addresses;
            }
        }

        
        ///GENMHASH:0BBB3340617BD27DD6A3E851FD10BEE1:D28477BD31DAD54051BEAF76A9FCB4C7
        public bool CookieBasedAffinity()
        {
            var backendConfig = BackendHttpConfiguration();
            return (backendConfig != null) ? backendConfig.CookieBasedAffinity() : false;
        }

        
        ///GENMHASH:F8F8F11F485174C9B1CC3FA0197799B9:649DFFCBE23D4220949D8CA7A521D053
        internal ApplicationGatewayListenerImpl Listener()
        {
            var listenerRef = Inner.HttpListener;
            if (listenerRef != null)
            {
                string listenerName = ResourceUtils.NameFromResourceId(listenerRef.Id);
                IApplicationGatewayListener listener;
                return (Parent.Listeners().TryGetValue(listenerName, out listener)) ? (ApplicationGatewayListenerImpl)listener : null;
            }
            else
            {
                return null;
            }
        }

        
        ///GENMHASH:A50A011CA652E846C1780DCE98D171DE:8DF47161E6AF3BB720FFC33F3FA597B2
        public string HostName()
        {
            var listener = Listener();
            return (listener != null) ? listener.HostName() : null;
        }

        #endregion

        #region Actions

        
        ///GENMHASH:B141413D05555CAF08A805C787576617:AA0180A4A065FA4ED289E4A294E92B4B
        private ApplicationGatewayBackendHttpConfigurationImpl EnsureBackendHttpConfig()
        {
            var config = BackendHttpConfiguration();
            if (config == null)
            {
                string name = SdkContext.RandomResourceName("bckcfg", 11);
                config = Parent.DefineBackendHttpConfiguration(name);
                config.Attach();
                ToBackendHttpConfiguration(name);
            }

            return config;
        }

        
        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:086E96DC9677CE6EDD1F65C8128BAD7A
        public ApplicationGatewayImpl Attach()
        {
            Parent.WithRequestRoutingRule(this);
            return Parent;
        }

        
        ///GENMHASH:166583FE514624A3D800151836CD57C1:C21CB040ABF97E760528E399E710404E
        public IPublicIPAddress GetPublicIPAddress()
        {
            string pipId = PublicIPAddressId();
            return (pipId != null) ? Parent.Manager.PublicIPAddresses.GetById(pipId) : null;
        }

        #endregion

        #region Helpers

        
        ///GENMHASH:8CE04F0B10328CF0D4983442F418CB39:47F20B573156490489C531E75748B797
        private ApplicationGatewayListenerImpl EnsureListener()
        {
            var listener = Listener();
            if (listener == null)
            {
                string name = SdkContext.RandomResourceName("listener", 13);
                listener = Parent.DefineListener(name);
                listener.Attach();
                FromListener(name);
            }

            return listener;
        }

        
        ///GENMHASH:DDD0EE7198E7BD6B745033E06D1924F5:D5AB941EF579322A74ACDAD720D29F7B
        private ApplicationGatewayBackendImpl EnsureBackend()
        {
            ApplicationGatewayBackendImpl backend = (ApplicationGatewayBackendImpl) Backend();
            if (backend == null)
            {
                string name = SdkContext.RandomResourceName("backend", 12);
                backend = Parent.DefineBackend(name);
                backend.Attach();
                ToBackend(name);
            }

            return backend;
        }

        #endregion
    }
}
