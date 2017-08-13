// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using ApplicationGatewayListener.Definition;
    using ApplicationGatewayListener.UpdateDefinition;
    using Models;
    using ResourceManager.Fluent.Core;
    using System.IO;
    using ResourceManager.Fluent.Core.ChildResourceActions;
    using ResourceManager.Fluent;

    /// <summary>
    /// Implementation for ApplicationGatewayListener.
    /// </summary>
    
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uQXBwbGljYXRpb25HYXRld2F5TGlzdGVuZXJJbXBs
    internal partial class ApplicationGatewayListenerImpl :
        ChildResource<ApplicationGatewayHttpListenerInner, ApplicationGatewayImpl, IApplicationGateway>,
        IApplicationGatewayListener,
        IDefinition<ApplicationGateway.Definition.IWithCreate>,
        IUpdateDefinition<ApplicationGateway.Update.IUpdate>,
        ApplicationGatewayListener.Update.IUpdate
    {
        
        ///GENMHASH:FDD79F9F4A54F00F3D88A305BD6E4101:C0847EA0CDA78F6D91EFD239C70F0FA7
        internal ApplicationGatewayListenerImpl(ApplicationGatewayHttpListenerInner inner, ApplicationGatewayImpl parent) : base(inner, parent)
        {
        }

        #region Withers

        
        ///GENMHASH:5ACBA6D500464D19A23A5A5A6A184B79:3CAED6F38D63250A1D8283E364506FF5
        public ApplicationGatewayListenerImpl WithHostName(string hostname)
        {
            Inner.HostName = hostname;
            return this;
        }

        
        ///GENMHASH:CB6B71434C2E17A82873B7892EE00D55:5B3EF817B7C74BB136E1CA2B7400D046
        public ApplicationGatewayListenerImpl WithoutServerNameIndication()
        {
            Inner.RequireServerNameIndication = false;
            return this;
        }

        
        ///GENMHASH:7C5A670BDA8BF576E8AFC752CD10A797:588DD8355CC6B8BBA6CED27FD5C42C76
        public ApplicationGatewayListenerImpl WithPrivateFrontend()
        {
            WithFrontend(Parent.EnsureDefaultPrivateFrontend().Name());
            return this;
        }

        
        ///GENMHASH:1D7C0E3D335976570E947F3D48437E66:90F5612F9FB70607B79E07A32AEB8B8D
        public ApplicationGatewayListenerImpl WithSslCertificate(string name)
        {
            var certRef = new SubResource()
            {
                Id = Parent.FutureResourceId() + "/sslCertificates/" + name
            };

            Inner.SslCertificate = certRef;
            return this;
        }

        
        ///GENMHASH:FA888A1E446DDA9E368D1EF43B428BAC:0FE70D5AE03341449A2D980808F522FC
        public ApplicationGatewayListenerImpl WithHttps()
        {
            Inner.Protocol = ApplicationGatewayProtocol.Https.ToString();
            return this;
        }

        
        ///GENMHASH:FD5739AFD5E74CB55C9C465B3661FBF2:393821A9A3F65B68E26BFBEA4350B3DD
        public ApplicationGatewayListenerImpl WithFrontendPort(string name)
        {
            SubResource portRef = new SubResource()
            {
                Id = Parent.FutureResourceId() + "/frontendPorts/" + name
            };
            Inner.FrontendPort = portRef;
            return this;
        }

        
        ///GENMHASH:1E7046ABBFA82B3370C0EE4358FCAAB3:B63632305CE5D2C6D9FE2C2AE6DFF9D7
        public ApplicationGatewayListenerImpl WithFrontendPort(int portNumber)
        {
            // Attempt to find an existing port referencing this port number
            string portName = Parent.FrontendPortNameFromNumber(portNumber);
            if (portName == null)
            {
                // Existing frontend port with this number not found so create one
                portName = SdkContext.RandomResourceName("port", 9);
                Parent.WithFrontendPort(portNumber, portName);
            }

            return WithFrontendPort(portName);
        }

        
        ///GENMHASH:8214BDBBC03F37877598DD319CF9DA28:6A89D21D1F64E0716C2BB0607B2B985E
        public ApplicationGatewayListenerImpl WithPublicFrontend()
        {
            WithFrontend(Parent.EnsureDefaultPublicFrontend().Name());
            return this;
        }

        
        ///GENMHASH:2EC798C5560EA4F2234EFA1478E59C04:409B6655E16BAB2E8CCE5B4E431083EE
        private ApplicationGatewayListenerImpl WithFrontend(string name)
        {
            var frontendRef = new SubResource()
            {
                Id = Parent.FutureResourceId() + "/frontendIPConfigurations/" + name
            };

            Inner.FrontendIPConfiguration = frontendRef;
            return this;
        }

        
        ///GENMHASH:85408D425EF4341A6D39C75F68ED8A2B:60CB6094D3C3120ABC72B2E26313EF5A
        public ApplicationGatewayListenerImpl WithServerNameIndication()
        {
            Inner.RequireServerNameIndication = true;
            return this;
        }

        
        ///GENMHASH:604F12B361C77B3E3AD5768A73BA6DCF:ABADA5A8E77FDA08CD893ADDC4895F32
        public ApplicationGatewayListenerImpl WithHttp()
        {
            Inner.Protocol = ApplicationGatewayProtocol.Http.ToString();
            return this;
        }

        
        ///GENMHASH:AFBFDB5617AA4227641C045CF9D86F66:EB7981C52FAC33B9BCE219D5852A1E18
        public ApplicationGatewayListenerImpl WithSslCertificateFromPfxFile(FileInfo pfxFile)
        {
            return WithSslCertificateFromPfxFile(pfxFile, null);
        }

        
        ///GENMHASH:8ADE3A1B894E5D01B188A0822FC89126:8F3C216CEC2F2F3C970738DE571B9D47
        private ApplicationGatewayListenerImpl WithSslCertificateFromPfxFile(FileInfo pfxFile, string name)
        {
            if (name == null)
            {
                name = SdkContext.RandomResourceName("cert", 10);
            }
            Parent.DefineSslCertificate(name)
                .WithPfxFromFile(pfxFile)
                .Attach();
            return WithSslCertificate(name);
        }

        
        ///GENMHASH:382D2BF4EBC04F5E7DF95B5EF5A97146:C01DAB0F887720B1B1F54C7664754686
        public ApplicationGatewayListenerImpl WithSslCertificatePassword(string password)
        {
            var sslCert = (ApplicationGatewaySslCertificateImpl) SslCertificate();
            if (sslCert != null)
            {
                sslCert.WithPfxPassword(password);
            }
            return this;
        }

        #endregion

        #region Accessors

        
        ///GENMHASH:A80C3FC8655E547C3392C10C546FFF39:F5F48992AF3FBAF8C1BC9C9A59C415FF
        public bool RequiresServerNameIndication()
        {
            return (Inner.RequireServerNameIndication != null) ? Inner.RequireServerNameIndication.Value : false;
        }

        
        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public override string Name()
        {
            return Inner.Name;
        }

        
        ///GENMHASH:5EF934D4E2CF202DF23C026435D9F6D6:4A43E80905D41DF094F9B704945856D1
        public string PublicIPAddressId()
        {
            var frontend = Frontend();
            return (frontend != null) ? frontend.PublicIPAddressId : null;
        }

        
        ///GENMHASH:B206A6556439FF2D98365C5283836AD5:125C0E491D4D29CEE8322DF9019C1DE7
        public IApplicationGatewayFrontend Frontend()
        {
            var frontendInner = Inner.FrontendIPConfiguration;
            if (frontendInner == null)
            {
                return null;
            }

            string frontendName = ResourceUtils.NameFromResourceId(frontendInner.Id);
            IApplicationGatewayFrontend frontend;
            return (Parent.Frontends().TryGetValue(frontendName, out frontend)) ? frontend : null;
        }

        ApplicationGateway.Update.IUpdate ISettable<ApplicationGateway.Update.IUpdate>.Parent()
        {
            return Parent;
        }

        
        ///GENMHASH:1C444C90348D7064AB23705C542DDF18:ADFE7EEA0734BA251C7A2C00B4ED3531
        public string NetworkId()
        {
            var frontend = Frontend();
            return (frontend != null) ? frontend.NetworkId : null;
        }

        
        ///GENMHASH:C57133CD301470A479B3BA07CD283E86:251CDCA01439FEEC30E23AD50DA1453A
        public string SubnetName()
        {
            var frontend = Frontend();
            return (frontend != null) ? frontend.SubnetName : null;
        }

        
        ///GENMHASH:E40B3F1FA93E71A00314196726D4960B:B71AFF4FEE8DFD54B2E5B5F488E605CC
        public string FrontendPortName()
        {
            return (Inner.FrontendPort != null) ? ResourceUtils.NameFromResourceId(Inner.FrontendPort.Id) : null;
        }

        
        ///GENMHASH:D684E7477889A9013C81FAD82F69C54F:BD249A015EF71106387B78281489583A
        public ApplicationGatewayProtocol Protocol()
        {
            return ApplicationGatewayProtocol.Parse(Inner.Protocol);
        }

        
        ///GENMHASH:1207E16326E66DA6A51CBA6F0565D088:3F3B707B427A3370160F5D3A76951425
        public IApplicationGatewaySslCertificate SslCertificate()
        {
            var certRef = Inner.SslCertificate;
            if (certRef == null)
            {
                return null;
            }

            string name = ResourceUtils.NameFromResourceId(certRef.Id);
            IApplicationGatewaySslCertificate cert = null;
            return (Parent.SslCertificates().TryGetValue(name, out cert)) ? cert : null;
        }

        
        ///GENMHASH:A50A011CA652E846C1780DCE98D171DE:1130E1FDC5A612FAE78D6B24DD71D43E
        public string HostName()
        {
            return Inner.HostName;
        }

        
        ///GENMHASH:EB912111C9441B9619D3AD0CCFB7E471:98FC7DF998F67011FCA026433ADD5507
        public int FrontendPortNumber()
        {
            string name = FrontendPortName();
            if (name == null)
            {
                return 0;
            }
            else
            {
                int portNumber = 0;
                return (Parent.FrontendPorts().TryGetValue(name, out portNumber)) ? portNumber : 0;
            }
        }

        #endregion

        #region Actions

        
        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:0C6B6B4DD8E378E1E80FAA7AD88AD383
        public ApplicationGatewayImpl Attach()
        {
            Parent.WithHttpListener(this);
            return Parent;
        }

        
        ///GENMHASH:166583FE514624A3D800151836CD57C1:CC312A186A3A88FA6CF6445A4520AE59
        public IPublicIPAddress GetPublicIPAddress()
        {
            string pipId = PublicIPAddressId();
            return (pipId != null) ? Parent.Manager.PublicIPAddresses.GetById(pipId) : null;
        }

        #endregion

    }
}
