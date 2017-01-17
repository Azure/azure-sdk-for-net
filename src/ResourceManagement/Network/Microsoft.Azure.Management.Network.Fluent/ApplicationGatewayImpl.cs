// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using System.Threading.Tasks;
    using ApplicationGateway.Definition;
    using ApplicationGateway.Update;
    using Models;
    using Resource.Fluent.Core;
    using Resource.Fluent.Core.ResourceActions;
    using System.Collections.Generic;
    using Resource.Fluent;
    using System.Text;

    /// <summary>
    /// Implementation of the ApplicationGateway interface.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uQXBwbGljYXRpb25HYXRld2F5SW1wbA==
    internal partial class ApplicationGatewayImpl :
        GroupableParentResource<IApplicationGateway,
            ApplicationGatewayInner,
            ApplicationGatewayImpl,
            INetworkManager,
            IWithGroup,
            ApplicationGateway.Definition.IWithRequestRoutingRule,
            IWithCreate,
            IUpdate>,
        IApplicationGateway,
        IDefinition,
        IUpdate
    {
        private Dictionary<string, IApplicationGatewayIpConfiguration> ipConfigs;
        private Dictionary<string, IApplicationGatewayFrontend> frontends;
        private Dictionary<string, IApplicationGatewayBackend> backends;
        private Dictionary<string, IApplicationGatewayBackendHttpConfiguration> backendHttpConfigs;
        private Dictionary<string, IApplicationGatewayListener> listeners;
        private Dictionary<string, IApplicationGatewayRequestRoutingRule> rules;
        private Dictionary<string, IApplicationGatewaySslCertificate> sslCerts;
        private static string DEFAULT = "default";
        private IApplicationGatewaysOperations innerCollection;
        private ApplicationGatewayFrontendImpl defaultPrivateFrontend;
        private ApplicationGatewayFrontendImpl defaultPublicFrontend;
        private Dictionary<string, string> creatablePipsByFrontend;
        private ICreatable<INetwork> creatableNetwork;
        private ICreatable<IPublicIpAddress> creatablePip;

        internal ApplicationGatewayImpl(
            string name,
            ApplicationGatewayInner innerModel,
            IApplicationGatewaysOperations innerCollection,
            INetworkManager networkManager) : base(name, innerModel, networkManager)
        {
            this.innerCollection = innerCollection;
        }

        #region Accessors

        ///GENMHASH:327A257714E97E0CC9195D07369866F6:AC0B304DE3854395AFFCFBF726105B2C
        public IReadOnlyDictionary<string, IApplicationGatewayFrontend> PublicFrontends()
        {
            Dictionary<string, IApplicationGatewayFrontend> publicFrontends = new Dictionary<string, IApplicationGatewayFrontend>();
            foreach (var frontend in Frontends().Values)
            {
                if (frontend.IsPublic)
                {
                    publicFrontends.Add(frontend.Name, frontend);
                }
            }

            return publicFrontends;
        }

        ///GENMHASH:605022D847E1CBA530EBD654136D8064:B699ABF72548606674C97317B2B20760
        public IApplicationGatewayIpConfiguration DefaultIpConfiguration()
        {
            // Default means the only one
            if (ipConfigs.Count == 1)
            {
                return firstValueFromDictionary(ipConfigs);
            }
            else
            {
                return null;
            }
        }

        ///GENMHASH:2572DE01031DBF4160442C8972FF5A5E:82DF98F81461A048AF4598C642544BE3
        public string FrontendPortNameFromNumber(int portNumber)
        {
            string portName = null;
            foreach (var portEntry in FrontendPorts())
            {
                if (portNumber == portEntry.Value)
                {
                    portName = portEntry.Key;
                    break;
                }
            }

            return portName;
        }

        ///GENMHASH:F756CBB3F13EF6198269C107AED6F9A2:F819A402FF29D3234FF975971868AD05
        public ApplicationGatewayTier Tier()
        {
            if (Sku() != null && Sku().Tier != null)
            {
                return ApplicationGatewayTier.Parse(Sku().Tier);
            }
            else
            {
                return ApplicationGatewayTier.Standard;
            }
        }

        ///GENMHASH:2911D7234EA1C2B2AC65B607D78B6E4A:1BA96F7ED47F4A48A42FC00578BB3810
        public bool IsPublic()
        {
            foreach (var frontend in frontends.Values)
            {
                if (frontend.IsPublic)
                {
                    return true;
                }
            }
            return false;
        }

        ///GENMHASH:C57133CD301470A479B3BA07CD283E86:AD561DB8BFA1E730BA1B2810E86A05D2
        public string SubnetName()
        {
            var subnetRef = DefaultSubnetRef();
            return (subnetRef != null) ? ResourceUtils.NameFromResourceId(subnetRef.Id) : null;
        }

        ///GENMHASH:2B1D79EF0701484A69266710AE199343:62BC79EC46523CAA9DA5DC9A5E4C242A
        public IReadOnlyDictionary<string, IApplicationGatewayFrontend> PrivateFrontends()
        {
            Dictionary<string, IApplicationGatewayFrontend> privateFrontends = new Dictionary<string, IApplicationGatewayFrontend>();
            foreach (var frontend in frontends.Values)
            {
                if (frontend.IsPrivate)
                {
                    privateFrontends.Add(frontend.Name, frontend);
                }
            }

            return privateFrontends;
        }

        ///GENMHASH:26736A6ADD939D26955E1B3CFAB3B027:E89C02FDC5725B8AD23DCBADA1105204
        public IPAllocationMethod PrivateIpAllocationMethod()
        {
            var frontend = DefaultPrivateFrontend();
            return (frontend != null) ? frontend.PrivateIpAllocationMethod : null;
        }

        ///GENMHASH:57B5349245E8E0AED639AD6C90041662:15B0E79628926A104F3E67AB78CAA58A
        public IReadOnlyDictionary<string, IApplicationGatewayBackendHttpConfiguration> BackendHttpConfigurations()
        {
            return backendHttpConfigs;
        }

        ///GENMHASH:DF33B11AB8B490CB0B236CD72B44740F:806736DF09AB90BDDD8E032352FC75F7
        public IApplicationGatewayListener ListenerByPortNumber(int portNumber)
        {
            IApplicationGatewayListener listener = null;
            foreach (var l in listeners.Values)
            {
                if (l.FrontendPortNumber == portNumber)
                {
                    listener = l;
                    break;
                }
            }

            return listener;
        }

        ///GENMHASH:140689F6718EC0DE59ED2724FEF8B493:FFD69AF34CCA85347AFB30F010027480
        public ApplicationGatewaySslPolicy SslPolicy()
        {
            return Inner.SslPolicy;
        }

        ///GENMHASH:CD498C02D42C73AD0C1FF12493E2A9B8:CD5E24B4D8E0D679C5291E15ABECB279
        public int InstanceCount()
        {
            if (Sku() != null && Sku().Capacity != null)
            {
                return Sku().Capacity.Value;
            }
            else
            {
                return 1;
            }
        }

        ///GENMHASH:77914F0D4FB485205682C4181EFAACC8:875B0523271DDA40BF052DD20E89DCA7
        public IReadOnlyDictionary<string, IApplicationGatewayListener> Listeners()
        {
            return listeners;
        }

        ///GENMHASH:37B3BFB70B7A5569F82FB660A259D248:E92DB289B022D8EE6CEDBF8D99A476BC
        public IApplicationGatewayFrontend DefaultPublicFrontend()
        {
            // Default means the only public one or the one tracked as default, if more than one public present
            var publicFrontends = PublicFrontends();
            if (publicFrontends.Count == 1)
            {
                defaultPublicFrontend = (ApplicationGatewayFrontendImpl)firstValueFromDictionary(publicFrontends);
            }
            else if (frontends.Count == 0)
            {
                defaultPublicFrontend = null;
            }

            return defaultPublicFrontend;
        }

        ///GENMHASH:56D5F87F4F5A3E1857D2D243C076EE30:59E2C0788337FAEAF9283E6BBEF1463E
        public ApplicationGatewayOperationalState OperationalState()
        {
            return ApplicationGatewayOperationalState.Parse(Inner.OperationalState);
        }

        ///GENMHASH:A45CE73D7318CE351EAF634272B1CA21:AAFEA7A6CB469B72F235861703236767
        public IReadOnlyDictionary<string, IApplicationGatewayBackend> Backends()
        {
            return backends;
        }

        ///GENMHASH:F0126379A1F65359204BD22C7CF55E7C:BE15CAD584433DEAF8B46C62642E8728
        public IReadOnlyDictionary<string, int> FrontendPorts()
        {
            Dictionary<string, int> ports = new Dictionary<string, int>();
            if (Inner.FrontendPorts != null)
            {
                foreach (var portInner in Inner.FrontendPorts)
                {
                    if (portInner.Port != null)
                    {
                        ports.Add(portInner.Name, portInner.Port.Value);
                    }
                }
            }
            return ports;
        }

        ///GENMHASH:C19382933BDE655D0F0F95CD9474DFE7:FEE32912F8CE067CB20B5A239BD484D3
        public ApplicationGatewaySkuName Size()
        {
            if (Sku() != null && Sku().Name != null)
            {
                return ApplicationGatewaySkuName.Parse(Sku().Name);
            }
            else
            {
                return ApplicationGatewaySkuName.StandardSmall;
            }
        }

        ///GENMHASH:8AA9D9D4B919CCB8947405FAA41035E2:6566E7A57F604BD33E81174C58827CA7
        public string PrivateIpAddress()
        {
            var frontend = DefaultPrivateFrontend();
            return (frontend != null) ? frontend.PrivateIpAddress : null;
        }

        ///GENMHASH:1C444C90348D7064AB23705C542DDF18:9AE479D53BC930F7515CB230EE4EB7EF
        public string NetworkId()
        {
            var subnetRef = DefaultSubnetRef();
            return (subnetRef != null) ? ResourceUtils.ParentResourcePathFromResourceId(subnetRef.Id) : null;
        }

        ///GENMHASH:F792F6C8C594AA68FA7A0FCA92F55B55:43E446F640DC3345BDBD9A3378F2018A
        public ApplicationGatewaySku Sku()
        {
            return Inner.Sku;
        }

        ///GENMHASH:8535B0E23E6704558262509B5A55B45D:B0B422F1B1E66AA120E54D492AF6FDE5
        public IReadOnlyDictionary<string, IApplicationGatewayIpConfiguration> IpConfigurations()
        {
            return ipConfigs;
        }

        ///GENMHASH:3BF87DE2E0C9BBAA60FEF8B345571B0D:78DEDBCE9849DD9B71BA61C7FBEA3261
        public IReadOnlyDictionary<string, IApplicationGatewayFrontend> Frontends()
        {
            return frontends;
        }

        ///GENMHASH:691BBD1A543FA3E8C9A27D451AEF177E:FC8B3AE517369B64F33F8DC475426F01
        public IReadOnlyDictionary<string, IApplicationGatewayRequestRoutingRule> RequestRoutingRules()
        {
            return rules;
        }

        ///GENMHASH:E1FFDF5A7DA768AA3F4DBC943784DF12:60FA949AF41551509BEDF0FF5451A6CB
        public IReadOnlyDictionary<string, IApplicationGatewaySslCertificate> SslCertificates()
        {
            return sslCerts;
        }

        ///GENMHASH:6A7F875381DF37D9F784810F1A3E35BE:EFFE7386E0D8E0FFBD6399B90A1C3CF3
        public bool IsPrivate()
        {
            foreach (var frontend in frontends.Values)
            {
                if (frontend.IsPrivate)
                {
                    return true;
                }
            }
            return false;
        }

        #endregion

        #region Withers

        #region ApplicationGateway

        ///GENMHASH:0A25F8D30AF64565545B20B215964E6B:7FF7C66C33A802B8668BFAC46B248EE8
        public ApplicationGatewayImpl WithSize(ApplicationGatewaySkuName skuName)
        {
            int count;
            // Preserve instance count if already set
            if (Sku() != null && Sku().Capacity != null)
            {
                count = Sku().Capacity.Value;
            }
            else
            {
                count = 1; // Default instance count
            }

            var sku = new ApplicationGatewaySku()
            {
                Name = skuName.ToString(),
                Capacity = count
            };

            Inner.Sku = sku;
            return this;
        }

        ///GENMHASH:94ACA3B358939F31F4F3966CDB1B73A4:7D7FC963A56E00888DE266506161CB7C
        public ApplicationGatewayImpl WithInstanceCount(int capacity)
        {
            if (Inner.Sku == null)
            {
                WithSize(ApplicationGatewaySkuName.StandardSmall);
            }

            Inner.Sku.Capacity = capacity;
            return this;
        }

        #endregion

        #region BackendHttpConfigurations

        ///GENMHASH:43D0A80DA689D640320A61D90075ADE8:FC98A09D6ECDCD30021D0B597F97C70C
        internal ApplicationGatewayImpl WithBackendHttpConfiguration(ApplicationGatewayBackendHttpConfigurationImpl httpConfig)
        {
            if (httpConfig != null)
            {
                backendHttpConfigs[httpConfig.Name()] = httpConfig;
            }
            return this;
        }

        ///GENMHASH:6409DA3F27E7CD8F90997F2AD668CE00:41A39172A229BE80EACCBF48C5405C39
        public ApplicationGatewayBackendHttpConfigurationImpl DefineBackendHttpConfiguration(string name)
        {
            IApplicationGatewayBackendHttpConfiguration httpConfig = null;
            if (!backendHttpConfigs.TryGetValue(name, out httpConfig))
            {
                var inner = new ApplicationGatewayBackendHttpSettingsInner()
                {
                    Name = name,
                    Port = 80 // Default port
                };

                return new ApplicationGatewayBackendHttpConfigurationImpl(inner, this);
            }
            else
            {
                return (ApplicationGatewayBackendHttpConfigurationImpl)httpConfig;
            }
        }

        ///GENMHASH:18F12733B6D16771FA686008216DE902:497D5BA64B46BCAD73B9D4148D1EA0E5
        public ApplicationGatewayBackendHttpConfigurationImpl UpdateBackendHttpConfiguration(string name)
        {
            IApplicationGatewayBackendHttpConfiguration config = null;
            backendHttpConfigs.TryGetValue(name, out config);
            return (ApplicationGatewayBackendHttpConfigurationImpl)config;
        }

        #endregion

        #region Backends

        ///GENMHASH:A0A23179FBDC541925212899C1A48667:2ECFEA1CD411E1F5B44424C5D9DDACA5
        public ApplicationGatewayImpl WithoutBackendIpAddress(string ipAddress)
        {
            foreach (var backend in backends.Values)
            {
                ApplicationGatewayBackendImpl backendImpl = (ApplicationGatewayBackendImpl)backend;
                backendImpl.WithoutIpAddress(ipAddress);
            }
            return this;
        }

        ///GENMHASH:B63ECBF93DAE93F829555FDE7D92623F:42006D4B61D56FE465F7DF0F31BA69B1
        public ApplicationGatewayImpl WithoutBackend(string backendName)
        {
            backends.Remove(backendName);
            return this;
        }

        ///GENMHASH:A21060E42B1DFECB63D4D27A101A8941:5B99013747311ACBEED53F35BF26AD98
        public ApplicationGatewayBackendImpl DefineBackend(string name)
        {
            IApplicationGatewayBackend backend = null;
            if (!backends.TryGetValue(name, out backend))
            {
                var inner = new ApplicationGatewayBackendAddressPoolInner()
                {
                    Name = name
                };
                return new ApplicationGatewayBackendImpl(inner, this);
            }
            else
            {
                return (ApplicationGatewayBackendImpl)backend;
            }
        }

        ///GENMHASH:77C9DAC5FABBCE9000402FF2D27EA990:6BF21BB8CB142597A825567301634266
        public ApplicationGatewayBackendImpl UpdateBackend(string name)
        {
            IApplicationGatewayBackend backend = null;
            backends.TryGetValue(name, out backend);
            return (ApplicationGatewayBackendImpl)backend;
        }

        ///GENMHASH:C000D62B14DEB58BED734D8C97CBA337:4F027AEBFAC53ECDC5ED96364FD97831
        internal ApplicationGatewayImpl WithBackend(ApplicationGatewayBackendImpl backend)
        {
            if (backend != null)
            {
                backends[backend.Name()] = backend;
            }
            return this;
        }

        ///GENMHASH:52092E76C641F5B4C13B8CD22D11A1C5:249224B1D62137072D4A55E6C56A9A20
        public ApplicationGatewayImpl WithoutBackendFqdn(string fqdn)
        {
            foreach (var backend in backends.Values)
            {
                ((ApplicationGatewayBackendImpl)backend).WithoutFqdn(fqdn);
            }
            return this;
        }

        #endregion

        #region FrontendPorts

        ///GENMHASH:99A00736DF753F6060C6104537FAB411:D9EF6ECF075F0671DA3E7309852CB983
        public ApplicationGatewayImpl WithoutFrontendPort(string name)
        {
            if (Inner.FrontendPorts == null)
            {
                return this;
            }

            for (int i = 0; i < Inner.FrontendPorts.Count; i++)
            {
                var inner = Inner.FrontendPorts[i];
                if (inner.Name.ToLower().Equals(name.ToLower()))
                {
                    Inner.FrontendPorts.RemoveAt(i);
                    break;
                }
            }

            return this;
        }

        ///GENMHASH:668234534FB4FFFD8523AC34BA26B3DC:81C6EB67B9E5A0F963383F80948256A2
        public ApplicationGatewayImpl WithoutFrontendPort(int portNumber)
        {
            for (int i = 0; i < Inner.FrontendPorts.Count; i++)
            {
                var inner = Inner.FrontendPorts[i];
                if (inner.Port.Equals(portNumber))
                {
                    Inner.FrontendPorts.RemoveAt(i);
                    break;
                }
            }
            return this;
        }

        ///GENMHASH:1E7046ABBFA82B3370C0EE4358FCAAB3:0BE350F61261249195A1647DAD43D2AB
        public ApplicationGatewayImpl WithFrontendPort(int portNumber)
        {
            return WithFrontendPort(portNumber, null);
        }

        ///GENMHASH:328B229A953520EB99975ECA4DEB46B7:E963FDA43A79265B89CA4E5FE8DAEB76
        public ApplicationGatewayImpl WithFrontendPort(int portNumber, string name)
        {
            // Ensure inner ports list initialized
            var frontendPorts = Inner.FrontendPorts;
            if (frontendPorts == null)
            {
                frontendPorts = new List<ApplicationGatewayFrontendPortInner>();
                Inner.FrontendPorts = frontendPorts;
            }

            // Attempt to find inner port by name if provided, or port number otherwise
            ApplicationGatewayFrontendPortInner frontendPortByName = null;
            ApplicationGatewayFrontendPortInner frontendPortByNumber = null;
            foreach (var inner in Inner.FrontendPorts)
            {
                if (name != null && name.ToLower().Equals(inner.Name.ToLower()))
                {
                    frontendPortByName = inner;
                }

                if (inner.Port == portNumber)
                {
                    frontendPortByNumber = inner;
                }
            }

            bool? needToCreate = NeedToCreate(frontendPortByName, frontendPortByNumber, name);
            if (needToCreate != null && needToCreate.Value)
            {
                // If no conflict, create a new port
                if (name == null)
                {
                    // No name specified, so auto-name it
                    name = SharedSettings.RandomResourceName("port", 9);
                }

                frontendPortByName = new ApplicationGatewayFrontendPortInner()
                {
                    Name = name,
                    Port = portNumber
                };

                frontendPorts.Add(frontendPortByName);
                return this;
            }
            else if (needToCreate != null && !needToCreate.Value)
            {
                // If found matching port, then nothing needs to happen
                return this;
            }
            else
            {
                // If name conflict for the same port number, then fail
                return null;
            }
        }

        #endregion

        #region Frontends

        ///GENMHASH:9407377DFC5566D93476B1B7D2246504:B92120874A64FEDF5BAA29C6F88C6CAD
        public ApplicationGatewayFrontendImpl UpdateFrontend(string frontendName)
        {
            IApplicationGatewayFrontend frontend = null;
            frontends.TryGetValue(frontendName, out frontend);
            return (ApplicationGatewayFrontendImpl)frontend;
        }

        ///GENMHASH:7B8AA96C3162D1728416030E94CB731F:833B17009FF35743D36834ABBB879D14
        internal ApplicationGatewayImpl WithFrontend(ApplicationGatewayFrontendImpl frontend)
        {
            if (frontend != null)
            {
                frontends[frontend.Name()] = frontend;
            }
            return this;
        }

        ///GENMHASH:2CAA0883E5A09AD81DE423447D34059F:5D6EB88CFD9F858A269954D227220035
        private ApplicationGatewayFrontendImpl DefineFrontend(string name)
        {
            IApplicationGatewayFrontend frontend = null;
            if (!frontends.TryGetValue(name, out frontend))
            {
                var inner = new ApplicationGatewayFrontendIPConfigurationInner()
                {
                    Name = name
                };
                return new ApplicationGatewayFrontendImpl(inner, this);
            }
            else
            {
                return (ApplicationGatewayFrontendImpl)frontend;
            }
        }

        ///GENMHASH:65F75FDFA4544CBB0088928EC664A699:2CC325C7E7DA0C579A9F5409C52333F5
        public ApplicationGatewayImpl WithoutFrontend(string frontendName)
        {
            frontends.Remove(frontendName);
            return this;
        }

        #region Public

        ///GENMHASH:1B49C92CBA9BDBBF9FBFD26544224384:8B6E82EE2C6ECB762256E74C48B124D1
        public IUpdate WithoutPublicIpAddress()
        {
            return WithoutPublicFrontend();
        }

        ///GENMHASH:FE2FB4C2B86589D7D187246933236472:D02F16FB7F9F848339457F517542934A
        public ApplicationGatewayImpl WithNewPublicIpAddress(ICreatable<IPublicIpAddress> creatable)
        {
            string name = EnsureDefaultPublicFrontend().Name();
            creatablePipsByFrontend[name] = creatable.Key;
            AddCreatableDependency(creatable as IResourceCreator<IHasId>);
            return this;
        }

        ///GENMHASH:9865456A38EDF249959594524980AA77:4ACB26EDB3DFCE615E1000808D779EBD
        public ApplicationGatewayImpl WithNewPublicIpAddress()
        {
            EnsureDefaultPublicFrontend();
            return this;
        }

        ///GENMHASH:BAA3D51CA88C44942207E1ACEC857C51:83FF9E6570D6D323728B8D648A3FAFF9
        public ApplicationGatewayFrontendImpl DefinePublicFrontend()
        {
            return EnsureDefaultPublicFrontend();
        }

        ///GENMHASH:90B03712BB750F79C07AC1E18C347CD2:C2BD141C1F4FD24259AF9553C95455F4
        public ApplicationGatewayFrontendImpl UpdatePublicFrontend()
        {
            return (ApplicationGatewayFrontendImpl)DefaultPublicFrontend();
        }

        ///GENMHASH:6FE68F40574F5B84C669001E20CC658F:B03DC94A2FEC619005CBF1692FC52F0D
        public ApplicationGatewayImpl WithExistingPublicIpAddress(IPublicIpAddress publicIpAddress)
        {
            EnsureDefaultPublicFrontend().WithExistingPublicIpAddress(publicIpAddress);
            return this;
        }

        ///GENMHASH:DD83F863BB3E548AA6773EF2F2FDD700:ABD548EA6D6FF93E5050DE383F0864FE
        public ApplicationGatewayImpl WithExistingPublicIpAddress(string resourceId)
        {
            EnsureDefaultPublicFrontend().WithExistingPublicIpAddress(resourceId);
            return this;
        }

        ///GENMHASH:A81618A68C4004FA1972411DF3C316A8:B36F33458166A92EBED50A27DEDA9AF1
        public ApplicationGatewayImpl WithoutPublicFrontend()
        {
            // Delete all public frontends
            List<string> toDelete = new List<string>();
            foreach (var frontend in frontends.Values)
            {
                if (frontend.IsPublic)
                {
                    toDelete.Add(frontend.Name);
                }
            }

            foreach (string frontendName in toDelete)
            {
                frontends.Remove(frontendName);
            }

            defaultPublicFrontend = null;
            return this;
        }

        #endregion

        #region Private

        ///GENMHASH:854F62AEEE32605D0082690205B49C3B:68548DB0EF9B6E0869FDD4F8A24E25F9
        public ApplicationGatewayFrontendImpl DefinePrivateFrontend()
        {
            return EnsureDefaultPrivateFrontend();
        }

        ///GENMHASH:237C0D1ED9460213CBE7249D1C6CA8F9:83004C1879D69DCF59B0E3CC399F87C9
        public ApplicationGatewayImpl WithoutPrivateFrontend()
        {
            // Delete all private frontends
            List<string> toDelete = new List<string>();
            foreach (var frontend in frontends.Values)
            {
                if (frontend.IsPrivate)
                {
                    toDelete.Add(frontend.Name);
                }
            }

            foreach (string frontendName in toDelete)
            {
                frontends.Remove(frontendName);
            }

            defaultPrivateFrontend = null;
            return this;
        }

        ///GENMHASH:EA98B464B10BD645EE3B0689825B43B8:9153A57100FB410376A86235E5F5CDBD
        public ApplicationGatewayImpl WithPrivateIpAddressDynamic()
        {
            EnsureDefaultPrivateFrontend().WithPrivateIpAddressDynamic();
            return this;
        }

        ///GENMHASH:7C5A670BDA8BF576E8AFC752CD10A797:A955581589FA3AB5F9E850A8EC96F11A
        public ApplicationGatewayImpl WithPrivateFrontend()
        {
            /* NOTE: This logic is a workaround for the unusual Azure API logic:
                - although app gateway API definition allows multiple IP configs, only one is allowed by the service currently;
                - although app gateway frontend API definition allows for multiple frontends, only one is allowed by the service today;
                - and although app gateway API definition allows different subnets to be specified between the IP configs and frontends, the service
                  requires the frontend and the containing subnet to be one and the same currently.

                So the logic here attempts to figure out from the API what that containing subnet for the app gateway is so that the user wouldn't
                have to re-enter it redundantly when enabling a private frontend, since only that one subnet is supported anyway.
                * TODO: When the underlying Azure API is reworked to make more sense, or the app gateway service starts supporting the functionality
                * that the underlying API implies is supported, this model and implementation should be revisited.
             */
            EnsureDefaultPrivateFrontend();
            return this;
        }

        ///GENMHASH:6CDEF6BE4432158ED3F8917E000EAD56:DB1402301D8518CEB5A0AE73F525CC10
        public ApplicationGatewayImpl WithPrivateIpAddressStatic(string ipAddress)
        {
            EnsureDefaultPrivateFrontend().WithPrivateIpAddressStatic(ipAddress);
            return this;
        }

        #endregion

        #endregion

        #region IPConfigurations

        ///GENMHASH:5D0DD8101FDDEC22F1DD348B5DADC47F:0DDB5F3E565736FD6F95B08EE958E156
        public ApplicationGatewayIpConfigurationImpl DefineDefaultIpConfiguration()
        {
            return EnsureDefaultIpConfig();
        }

        ///GENMHASH:405FE49F57EE4AB4C0F91D84030D1DDA:F543E5F094A29330FBE6AE2B7D8F7B7A
        public ApplicationGatewayIpConfigurationImpl UpdateIpConfiguration(string ipConfigurationName)
        {
            IApplicationGatewayIpConfiguration config = null;
            ipConfigs.TryGetValue(ipConfigurationName, out config);
            return (ApplicationGatewayIpConfigurationImpl)config;
        }

        ///GENMHASH:639D88327F2B6C934F976C743B318B50:3E294A29C2E6177D4AADBC61A2C83DBC
        public ApplicationGatewayImpl WithoutBackendHttpConfiguration(string name)
        {
            backendHttpConfigs.Remove(name);
            return this;
        }

        ///GENMHASH:B68122A3AE9F806751DFE2AC77E699AF:5A184EBE0BAD48996EE3C74365B62FA5
        public ApplicationGatewayIpConfigurationImpl UpdateDefaultIpConfiguration()
        {
            return (ApplicationGatewayIpConfigurationImpl)DefaultIpConfiguration();
        }

        ///GENMHASH:EE79C3B68C4C6A99234BB004EDCAD67A:75C2DBDE4D61EDB193493A39766B60EE
        public ApplicationGatewayImpl WithExistingSubnet(ISubnet subnet)
        {
            EnsureDefaultIpConfig().WithExistingSubnet(subnet);
            return this;
        }

        ///GENMHASH:5647899224D30C7B5E1FDCD2D9AAB1DB:E44EB8F969AE406A3CE854143982FB65
        public ApplicationGatewayImpl WithExistingSubnet(INetwork network, string subnetName)
        {
            EnsureDefaultIpConfig().WithExistingSubnet(network, subnetName);
            return this;
        }

        ///GENMHASH:E8683B20FED733D23930E96CCD1EB0A2:7246BAAE40C91731DF4E96029B3FA2BA
        public ApplicationGatewayImpl WithExistingSubnet(string networkResourceId, string subnetName)
        {
            EnsureDefaultIpConfig().WithExistingSubnet(networkResourceId, subnetName);
            return this;
        }

        ///GENMHASH:E38530BE2EC4569C8D62DB8CEB4AD38F:90CC3E1EEF35BDBB9152B8B5149B04E0
        private ApplicationGatewayIpConfigurationImpl DefineIpConfiguration(string name)
        {
            IApplicationGatewayIpConfiguration config = null;
            if (!ipConfigs.TryGetValue(name, out config))
            {
                var inner = new ApplicationGatewayIPConfigurationInner()
                {
                    Name = name
                };
                return new ApplicationGatewayIpConfigurationImpl(inner, this);
            }
            else
            {
                return (ApplicationGatewayIpConfigurationImpl)config;
            }
        }

        ///GENMHASH:A3E0AFFD41A48AADA625D444BDC4B639:D755BC44A5AE232FE3D5AB7294B7260E
        public ApplicationGatewayImpl WithoutIpConfiguration(string ipConfigurationName)
        {
            ipConfigs.Remove(ipConfigurationName);
            return this;
        }

        #endregion

        #region Listeners

        ///GENMHASH:335DEBA2C3ED42B7D6D726224668713C:5F7D61C72418DAEB7F935725E2A62AFF
        public ApplicationGatewayListenerImpl DefineListener(string name)
        {
            IApplicationGatewayListener httpListener = null;
            if (!listeners.TryGetValue(name, out httpListener))
            {
                var inner = new ApplicationGatewayHttpListenerInner()
                {
                    Name = name
                };
                return new ApplicationGatewayListenerImpl(inner, this);
            }
            else
            {
                return (ApplicationGatewayListenerImpl)httpListener;
            }
        }

        ///GENMHASH:FD3BFA79E44BF0C0FD92A0CE7B31B143:0C32B144C358DA51784C501FAE5651A1
        internal ApplicationGatewayImpl WithHttpListener(ApplicationGatewayListenerImpl httpListener)
        {
            if (httpListener != null)
            {
                listeners[httpListener.Name()] = httpListener;
            }
            return this;
        }

        ///GENMHASH:6A7BE130A21D7CF301EAC3B7AFC03BC7:89DB414F8973677B8ED5DBFA5338F186
        public ApplicationGatewayListenerImpl UpdateListener(string name)
        {
            IApplicationGatewayListener listener = null;
            listeners.TryGetValue(name, out listener);
            return (ApplicationGatewayListenerImpl)listener;
        }

        ///GENMHASH:A0174786468BD0401BEEB279F03A9F28:8E183AA7B177F20F15999B009DA993FE
        public ApplicationGatewayImpl WithoutListener(string name)
        {
            listeners.Remove(name);
            return this;
        }

        #endregion

        #region RequestRoutingRules

        ///GENMHASH:9EE982E7421C1A20C7BB22556011B5DC:345F6A97C61E955CCFAB88208C749162
        internal ApplicationGatewayImpl WithRequestRoutingRule(ApplicationGatewayRequestRoutingRuleImpl rule)
        {
            if (rule != null)
            {
                rules[rule.Name()] = rule;
            }
            return this;
        }

        ///GENMHASH:3DBBB35580E0023332C1FB4E78C36EC4:8BC4FF2E70BFA1D6AB1B2664C2AB7FA1
        public ApplicationGatewayRequestRoutingRuleImpl DefineRequestRoutingRule(string name)
        {
            IApplicationGatewayRequestRoutingRule rule = null;
            if (!rules.TryGetValue(name, out rule))
            {
                var inner = new ApplicationGatewayRequestRoutingRuleInner()
                {
                    Name = name
                };
                return new ApplicationGatewayRequestRoutingRuleImpl(inner, this);
            }
            else
            {
                return (ApplicationGatewayRequestRoutingRuleImpl)rule;
            }
        }

        ///GENMHASH:3D14082AEAA37FD69BCA1BF0129B05FF:A0722D26BD371E7333E649E461013B02
        public ApplicationGatewayRequestRoutingRuleImpl UpdateRequestRoutingRule(string name)
        {
            IApplicationGatewayRequestRoutingRule rule = null;
            rules.TryGetValue(name, out rule);
            return (ApplicationGatewayRequestRoutingRuleImpl)rule;
        }

        ///GENMHASH:3AEE65B42CA330A187F9ED489D04EF17:BB6B3B198CEC808EF295F8AE72D11548
        public ApplicationGatewayImpl WithoutRequestRoutingRule(string name)
        {
            rules.Remove(name);
            return this;
        }

        #endregion

        #region SslCertificates

        ///GENMHASH:AA53287F5186B0525C5149BB8A3CC41C:F8A2D339B71D17A2BF48559C2304DA5D
        internal ApplicationGatewayImpl WithSslCertificate(ApplicationGatewaySslCertificateImpl cert)
        {
            if (cert != null)
            {
                sslCerts[cert.Name()] = cert;
            }
            return this;
        }

        ///GENMHASH:AEECF1FD9CF2F7E0FFAE9F2627E6B3FC:5EF4F345F37B15B88D7920245D112B33
        public ApplicationGatewaySslCertificateImpl DefineSslCertificate(string name)
        {
            IApplicationGatewaySslCertificate cert = null;
            if (!sslCerts.TryGetValue(name, out cert))
            {
                var inner = new ApplicationGatewaySslCertificateInner()
                {
                    Name = name
                };
                return new ApplicationGatewaySslCertificateImpl(inner, this);
            }
            else
            {
                return (ApplicationGatewaySslCertificateImpl)cert;
            }
        }

        ///GENMHASH:4DB70C23295D0F053459FB0473314A93:7A5B03571727B37E62AC3357D157E863
        public ApplicationGatewayImpl WithoutCertificate(string name)
        {
            sslCerts.Remove(name);
            return this;
        }

        #endregion

        #endregion

        #region Helpers

        ///GENMHASH:80375A07B813FDE5A15028546D4FB694:130D5B3A30C34F066046287000EF7300
        internal ApplicationGatewayImpl WithConfig(ApplicationGatewayIpConfigurationImpl config)
        {
            if (config != null)
            {
                ipConfigs[config.Name()] = config;
            }
            return this;
        }

        ///GENMHASH:6D9F740D6D73C56877B02D9F1C96F6E7:E6C99E3819DC72204CDC6B1A73151A87
        protected override void InitializeChildrenFromInner()
        {
            InitializeConfigsFromInner();
            InitializeFrontendsFromInner();
            InitializeBackendsFromInner();
            InitializeBackendHttpConfigsFromInner();
            InitializeHttpListenersFromInner();
            InitializeRequestRoutingRulesFromInner();
            InitializeSslCertificatesFromInner();
            defaultPrivateFrontend = null;
            defaultPublicFrontend = null;
            creatablePipsByFrontend = new Dictionary<string, string>();
        }

        ///GENMHASH:3EB46226E14C9B9CCFF912B0282CE5C1:05D1016177B6A6A6C2D59D08E19394C9
        private void InitializeBackendHttpConfigsFromInner()
        {
            backendHttpConfigs = new Dictionary<string, IApplicationGatewayBackendHttpConfiguration>();
            var inners = Inner.BackendHttpSettingsCollection;
            if (inners != null)
            {
                foreach (var inner in inners)
                {
                    var httpConfig = new ApplicationGatewayBackendHttpConfigurationImpl(inner, this);
                    backendHttpConfigs[inner.Name] = httpConfig;
                }
            }
        }

        ///GENMHASH:359B78C1848B4A526D723F29D8C8C558:257D937A0F04955A15D8633AF5E905F3
        override protected async Task<ApplicationGatewayInner> CreateInnerAsync()
        {
            var tasks = new List<Task>();

            // Determine if a default public frontend PIP should be created
            ApplicationGatewayFrontendImpl defaultPublicFrontend = (ApplicationGatewayFrontendImpl)DefaultPublicFrontend();
            if (defaultPublicFrontend != null && defaultPublicFrontend.PublicIpAddressId() == null)
            {
                // If default public frontend requested but no PIP specified, create one
                Task pipTask = EnsureDefaultPipDefinition().CreateAsync().ContinueWith(
                    antecedent => {
                        var publicIp = antecedent.Result;
                        // Attach the created PIP when available
                        defaultPublicFrontend.WithExistingPublicIpAddress(publicIp);
                    });
                tasks.Add(pipTask);
            }

            // Determine if default VNet should be created
            var defaultIpConfig = EnsureDefaultIpConfig();
            var defaultPrivateFrontend = (ApplicationGatewayFrontendImpl)DefaultPrivateFrontend();
            if (defaultIpConfig.SubnetName() != null)
            {
                // If default IP config already has a subnet assigned to it...
                if (defaultPrivateFrontend != null)
                {
                    // ...And a private frontend is requested, then use the same vnet for the private frontend
                    UseSubnetFromIpConfigForFrontend(defaultIpConfig, defaultPrivateFrontend);
                }

                // ...And no need to create a default VNet
            }
            else
            {
                // But if default IP config does not have a subnet specified, then create a default VNet
                Task networkTask = EnsureDefaultNetworkDefinition().CreateAsync().ContinueWith(antecedent =>
                {
                    //... and assign the created VNet to the default IP config
                    var network = antecedent.Result;
                    defaultIpConfig.WithExistingSubnet(network, DEFAULT);
                    if (defaultPrivateFrontend != null)
                    {
                        // If a private frontend is also requested, then use the same VNet for the private frontend as for the IP config
                        /* TODO: Not sure if the assumption of the same subnet for the frontend and the IP config will hold in
                         * the future, but the existing ARM template for App Gateway for some reason uses the same subnet for the
                         * IP config and the private frontend. Also, trying to use different subnets results in server error today saying they
                         * have to be the same. This may need to be revisited in the future however, as this is somewhat inconsistent
                         * with what the documentation says.
                         */
                        UseSubnetFromIpConfigForFrontend(defaultIpConfig, defaultPrivateFrontend);
                    }
                });
                tasks.Add(networkTask);
            }

            var appGatewayInnerTask = Task.WhenAll(tasks.ToArray()).ContinueWith(antecedent => {
                return innerCollection.CreateOrUpdateAsync(ResourceGroupName, Name, Inner);
            });

            return await appGatewayInnerTask.Result;
        }

        /// <summary>
        /// Determines whether the app gateway child that can be found using a name or a port number can be created,
        /// or it already exists, or there is a clash.
        /// </summary>
        /// <param name="byName">Object found by name.</param>
        /// <param name="byPort">Object found by port.</param>
        /// <param name="name">The desired name of the object.</param>
        /// <return>True if already found, false if ok to create, null if conflict.</return>
        ///GENMHASH:644A3298215000D78F5173C9BC6F440E:9BEBC7254CB4CA864A9951088E837542
        internal bool? NeedToCreate<T>(T byName, T byPort, string name)
        {
            if (byName != null && byPort != null)
            {
                // If objects with this name and/or port already exist...
                if (byName.Equals(byPort))
                {
                    // ...And it is the same object, then do nothing
                    return false;
                }
                else
                {
                    // ...But if they are inconsistent, then fail fast
                    return null;
                }
            }
            else if (byPort != null)
            {
                // If no object with the requested name, but the port number is found...
                if (name == null)
                {
                    // ...And no name is requested, then do nothing, because the object already exists
                    return false;
                }
                else
                {
                    // ...But if a clashing name is requested, then fail fast
                    return null;
                }
            }
            else
            {
                // Ok to create the object
                return true;
            }
        }

        ///GENMHASH:7C4E822443AEFDF724B915FEB1AC8939:758E11F2064BDF9569DB0F6BEDA69EF2
        private static ApplicationGatewayFrontendImpl UseSubnetFromIpConfigForFrontend(
            ApplicationGatewayIpConfigurationImpl ipConfig,
            ApplicationGatewayFrontendImpl frontend)
        {
            if (frontend != null)
            {
                frontend.WithExistingSubnet(ipConfig.NetworkId(), ipConfig.SubnetName());
                if (frontend.PrivateIpAddress() == null)
                {
                    frontend.WithPrivateIpAddressDynamic();
                }
                else if (frontend.PrivateIpAllocationMethod() == null)
                {
                    frontend.WithPrivateIpAddressDynamic();
                }
            }

            return frontend;
        }

        ///GENMHASH:AC21A10EE2E745A89E94E447800452C1:2E5EA5B659E60C29EEED049E3FE11D8B
        protected override void BeforeCreating()
        {
            // Process created PIPs
            foreach (var frontendPipPair in creatablePipsByFrontend)
            {
                var createdPip = CreatedResource(frontendPipPair.Value);
                UpdateFrontend(frontendPipPair.Key).WithExistingPublicIpAddress(createdPip.Id);
            }
            creatablePipsByFrontend.Clear();

            // Reset and update IP configs
            EnsureDefaultIpConfig();
            Inner.GatewayIPConfigurations = InnersFromWrappers<ApplicationGatewayIPConfigurationInner, IApplicationGatewayIpConfiguration>(ipConfigs.Values);

            // Reset and update frontends
            Inner.FrontendIPConfigurations = InnersFromWrappers<ApplicationGatewayFrontendIPConfigurationInner, IApplicationGatewayFrontend>(frontends.Values);

            // Reset and update backends
            Inner.BackendAddressPools = InnersFromWrappers<ApplicationGatewayBackendAddressPoolInner, IApplicationGatewayBackend>(backends.Values);

            // Reset and update backend HTTP settings configs
            Inner.BackendHttpSettingsCollection = InnersFromWrappers<ApplicationGatewayBackendHttpSettingsInner, IApplicationGatewayBackendHttpConfiguration>(backendHttpConfigs.Values);

            // Reset and update HTTP listeners
            Inner.HttpListeners = InnersFromWrappers<ApplicationGatewayHttpListenerInner, IApplicationGatewayListener>(listeners.Values);
            foreach (var listener in listeners.Values)
            {
                SubResource r;

                // Clear deleted frontend references
                r = listener.Inner.FrontendIPConfiguration;
                if (r != null && !Frontends().ContainsKey(ResourceUtils.NameFromResourceId(r.Id)))
                {
                    listener.Inner.FrontendIPConfiguration = null;
                }

                // Clear deleted frontend port references
                r = listener.Inner.FrontendPort;
                if (r != null && !FrontendPorts().ContainsKey(ResourceUtils.NameFromResourceId(r.Id)))
                {
                    listener.Inner.FrontendPort = null;
                }

                // Clear deleted SSL certificate references
                r = listener.Inner.SslCertificate;
                if (r != null && !SslCertificates().ContainsKey(ResourceUtils.NameFromResourceId(r.Id)))
                {
                    listener.Inner.SslCertificate = null;
                }
            }

            // Reset and update request routing rules
            Inner.RequestRoutingRules = InnersFromWrappers<ApplicationGatewayRequestRoutingRuleInner, IApplicationGatewayRequestRoutingRule>(rules.Values);
            foreach (var rule in rules.Values)
            {
                SubResource r;

                // Clear deleted backends
                r = rule.Inner.BackendAddressPool;
                if (r != null && !this.Backends().ContainsKey(ResourceUtils.NameFromResourceId(r.Id)))
                {
                    rule.Inner.BackendAddressPool = null;
                }

                // Clear deleted backend HTTP configs
                r = rule.Inner.BackendHttpSettings;
                if (r != null && !BackendHttpConfigurations().ContainsKey(ResourceUtils.NameFromResourceId(r.Id)))
                {
                    rule.Inner.BackendHttpSettings = null;
                }

                // Clear deleted frontend HTTP listeners
                r = rule.Inner.HttpListener;
                if (r != null && !Listeners().ContainsKey(ResourceUtils.NameFromResourceId(r.Id)))
                {
                    rule.Inner.HttpListener = null;
                }
            }

            // Reset and update SSL certs
            Inner.SslCertificates = InnersFromWrappers<ApplicationGatewaySslCertificateInner, IApplicationGatewaySslCertificate>(sslCerts.Values);
        }

        ///GENMHASH:14670FFEE8D86F167A4246AFE76F91E6:8F8A962E6738F94558583D11555C6B53
        private void InitializeRequestRoutingRulesFromInner()
        {
            rules = new Dictionary<string, IApplicationGatewayRequestRoutingRule>();
            var inners = Inner.RequestRoutingRules;
            if (inners != null)
            {
                foreach (var inner in inners)
                {
                    var rule = new ApplicationGatewayRequestRoutingRuleImpl(inner, this);
                    rules[inner.Name] = rule;
                }
            }
        }

        ///GENMHASH:38719597698E42AABAD5A9917188C155:5FA623156A2242C0CC7212EF7D654C87
        private void InitializeFrontendsFromInner()
        {
            frontends = new Dictionary<string, IApplicationGatewayFrontend>();
            var inners = Inner.FrontendIPConfigurations;
            if (inners != null)
            {
                foreach (var inner in inners)
                {
                    var frontend = new ApplicationGatewayFrontendImpl(inner, this);
                    frontends[inner.Name] = frontend;
                }
            }
        }

        ///GENMHASH:38BB8357245354CED812C58E4EC79068:D0C7FA8A585A667919422AC63F659988
        private void InitializeBackendsFromInner()
        {
            backends = new Dictionary<string, IApplicationGatewayBackend>();
            var inners = Inner.BackendAddressPools;
            if (inners != null)
            {
                foreach (var inner in inners)
                {
                    var backend = new ApplicationGatewayBackendImpl(inner, this);
                    backends[inner.Name] = backend;
                }
            }
        }

        ///GENMHASH:4AC8CF7D9CB1EC685C6E9B19CE307C6F:EA1960DD08CE81963CC51EC4948132A2
        private SubResource DefaultSubnetRef()
        {
            var ipConfig = DefaultIpConfiguration();
            return (ipConfig != null) ? ipConfig.Inner.Subnet : null;
        }

        ///GENMHASH:284892F1C09754FA6CF4266448D10168:6A6B9DA04BA6ED95CE65132FD1333E49
        public IApplicationGatewayFrontend DefaultPrivateFrontend()
        {
            // Default means the only private one or the one tracked as default, if more than one private present
            var privateFrontends = PrivateFrontends();
            if (privateFrontends.Count == 1)
            {
                defaultPrivateFrontend = (ApplicationGatewayFrontendImpl)firstValueFromDictionary(privateFrontends);
            }
            else if (frontends.Count == 0)
            {
                defaultPrivateFrontend = null;
            }
            return defaultPrivateFrontend;
        }

        private V firstValueFromDictionary<K, V>(IReadOnlyDictionary<K, V> dictionary)
        {
            if (dictionary == null || dictionary.Count == 0)
            {
                return default(V);
            }

            var enumerator = dictionary.Values.GetEnumerator();
            enumerator.MoveNext();
            return enumerator.Current;
        }

        ///GENMHASH:D232B3BB0D86D13CC0B242F4000DBF07:97DF71BC11CE54F5F4736C975A273A63
        private ICreatable<IPublicIpAddress> EnsureDefaultPipDefinition()
        {
            if (creatablePip == null)
            {
                string pipName = SharedSettings.RandomResourceName("pip", 9);
                creatablePip = Manager.PublicIpAddresses.Define(pipName)
                    .WithRegion(RegionName)
                    .WithExistingResourceGroup(ResourceGroupName);
            }

            return creatablePip;
        }

        ///GENMHASH:DA0903CF2B09DA8DCF45A148EE669133:E387DB2FECFAD1CD7B9B3A06EC339A39
        internal ApplicationGatewayFrontendImpl EnsureDefaultPublicFrontend()
        {
            var frontend = (ApplicationGatewayFrontendImpl)DefaultPublicFrontend();
            if (frontend != null)
            {
                return frontend;
            }
            else
            {
                string name = SharedSettings.RandomResourceName("frontend", 14);
                frontend = DefineFrontend(name);
                frontend.Attach();
                defaultPublicFrontend = frontend;
                return frontend;
            }
        }

        ///GENMHASH:F91F57741BB7E185BF012523964DEED0:27E486AB74A10242FF421C0798DDC450
        protected override void AfterCreating()
        {
        }

        ///GENMHASH:1F12F15BC25B4A670CBA526BA2A27CC0:CC90A63D0E46102BDCA3DC06F4351E69
        private void InitializeSslCertificatesFromInner()
        {
            sslCerts = new Dictionary<string, IApplicationGatewaySslCertificate>();
            var inners = Inner.SslCertificates;
            if (inners != null)
            {
                foreach (var inner in inners)
                {
                    var cert = new ApplicationGatewaySslCertificateImpl(inner, this);
                    sslCerts[inner.Name] = cert;
                }
            }
        }

        ///GENMHASH:B9C8411DAA4D113FE18FEEEF1BE8CDB6:EBBE4DB86B4401A7F0C2E50102BABB4B
        internal string FutureResourceId()
        {
            return new StringBuilder()
                .Append(ResourceIdBase)
                .Append("/providers/Microsoft.Network/applicationGateways/")
                .Append(Name).ToString();
        }

        ///GENMHASH:0F667C94F2289EF36EC5F8C809B0D66D:BDD4570033866F30B639E2B8A512C623
        internal ApplicationGatewayFrontendImpl EnsureDefaultPrivateFrontend()
        {
            var frontend = (ApplicationGatewayFrontendImpl)DefaultPrivateFrontend();
            if (frontend != null)
            {
                return frontend;
            }
            else
            {
                string name = SharedSettings.RandomResourceName("frontend", 14);
                frontend = DefineFrontend(name);
                frontend.Attach();
                defaultPrivateFrontend = frontend;
                return frontend;
            }
        }

        ///GENMHASH:CC9715A22AECD112176C927FAD1E7A41:878620025FD4DBD54E68E653EC6A401A
        private ApplicationGatewayIpConfigurationImpl EnsureDefaultIpConfig()
        {
            ApplicationGatewayIpConfigurationImpl ipConfig = (ApplicationGatewayIpConfigurationImpl) DefaultIpConfiguration();
            if (ipConfig == null)
            {
                string name = SharedSettings.RandomResourceName("ipcfg", 11);
                ipConfig = DefineIpConfiguration(name);
                ipConfig.Attach();
            }

            return ipConfig;
        }

        ///GENMHASH:378C5280A44231F5593B789FF6A1BF16:24E45B50AE0887B03C04922FC3F414DC
        private ICreatable<INetwork> EnsureDefaultNetworkDefinition()
        {
            if (creatableNetwork == null)
            {
                string vnetName = SharedSettings.RandomResourceName("vnet", 10);
                creatableNetwork = Manager.Networks.Define(vnetName)
                    .WithRegion(Region)
                    .WithExistingResourceGroup(ResourceGroupName)
                    .WithAddressSpace("10.0.0.0/24")
                    .WithSubnet(DEFAULT, "10.0.0.0/25")
                    .WithSubnet("apps", "10.0.0.128/25");
            }

            return creatableNetwork;
        }

        ///GENMHASH:D10DEC59828FEAE61D059EA56D310BFE:AB6C127A63CD705630463C82659E7115
        private void InitializeConfigsFromInner()
        {
            ipConfigs = new Dictionary<string, IApplicationGatewayIpConfiguration>();
            var inners = Inner.GatewayIPConfigurations;
            if (inners != null)
            {
                foreach (var inner in inners)
                {
                    var config = new ApplicationGatewayIpConfigurationImpl(inner, this);
                    ipConfigs[inner.Name] = config;
                }
            }
        }

        ///GENMHASH:709E56A3C42D339048D2196CAAA5ED3F:D1F930D6EF465080D5C775FDA7AD0C5D
        private void InitializeHttpListenersFromInner()
        {
            listeners = new Dictionary<string, IApplicationGatewayListener>();
            var inners = Inner.HttpListeners;
            if (inners != null)
            {
                foreach (var inner in inners)
                {
                    var httpListener = new ApplicationGatewayListenerImpl(inner, this);
                    listeners[inner.Name] = httpListener;
                }
            }
        }

        #endregion

        #region Actions

        ///GENMHASH:4002186478A1CB0B59732EBFB18DEB3A:96A74C51AAF39DA86E198A67D990E237
        public override IApplicationGateway Refresh()
        {
            var inner = innerCollection.Get(this.ResourceGroupName, this.Name);
            SetInner(inner);
            InitializeChildrenFromInner();
            return this;
        }

        #endregion
    }
}
