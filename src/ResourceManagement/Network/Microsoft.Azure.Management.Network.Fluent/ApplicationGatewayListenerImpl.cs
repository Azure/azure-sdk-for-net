// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using ApplicationGateway.Definition;
    using ApplicationGateway.Update;
    using ApplicationGatewayListener.Definition;
    using ApplicationGatewayListener.Update;
    using ApplicationGatewayListener.UpdateDefinition;
    using Models;
    using HasHostName.Definition;
    using HasHostName.UpdateDefinition;
    using HasHostName.Update;
    using HasServerNameIndication.Definition;
    using HasServerNameIndication.UpdateDefinition;
    using HasServerNameIndication.Update;
    using HasSslCertificate.Definition;
    using HasSslCertificate.UpdateDefinition;
    using HasSslCertificate.Update;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;
    using System.IO;
    using Resource.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// Implementation for ApplicationGatewayListener.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uQXBwbGljYXRpb25HYXRld2F5TGlzdGVuZXJJbXBs
    internal partial class ApplicationGatewayListenerImpl :
        ChildResource<Models.ApplicationGatewayHttpListenerInner, Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayImpl, Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        IApplicationGatewayListener,
        IDefinition<ApplicationGateway.Definition.IWithCreate>,
        IUpdateDefinition<ApplicationGateway.Update.IUpdate>,
        ApplicationGatewayListener.Update.IUpdate
    {
        private ApplicationGatewaySslCertificateImpl sslCert;
        ///GENMHASH:AFBFDB5617AA4227641C045CF9D86F66:51AAC8329531E69BAAFAC03299414449
        public ApplicationGatewayListenerImpl WithSslCertificateFromPfxFile(FileInfo pfxFile)
        {
            //$ String name = ResourceNamer.RandomResourceName("cert", 10);
            //$ return withSslCertificateFromPfxFile(pfxFile, name);

            return this;
        }

        ///GENMHASH:8ADE3A1B894E5D01B188A0822FC89126:C9DB02E58BCE0380CFA35181A84B25CD
        private ApplicationGatewayListenerImpl WithSslCertificateFromPfxFile(FileInfo pfxFile, string name)
        {
            //$ this.sslCert = this.Parent().DefineSslCertificate(name)
            //$ .WithPfxFromFile(pfxFile);
            //$ return this;
            //$ }

            return this;
        }

        ///GENMHASH:382D2BF4EBC04F5E7DF95B5EF5A97146:66502B9267EB235997FE645B0C0A6527
        public ApplicationGatewayListenerImpl WithSslCertificatePassword(string password)
        {
            //$ if (this.sslCert != null) {
            //$ this.sslCert.WithPfxPassword(password).Attach();
            //$ this.WithSslCertificate(sslCert.Name());
            //$ this.sslCert = null;
            //$ return this;
            //$ } else {
            //$ return null; // Fail fast as this should never happen if the internal logic is correct
            //$ }

            return this;
        }

        ///GENMHASH:A50A011CA652E846C1780DCE98D171DE:1130E1FDC5A612FAE78D6B24DD71D43E
        public string HostName()
        {
            //$ return this.Inner.HostName();

            return null;
        }

        ///GENMHASH:EB912111C9441B9619D3AD0CCFB7E471:B232091121F1BD47EF36242FE879E57E
        public int FrontendPortNumber()
        {
            //$ String name = this.FrontendPortName();
            //$ if (name == null) {
            //$ return 0;
            //$ } else {
            //$ return this.Parent().FrontendPorts().Get(name);
            //$ }

            return 0;
        }

        ///GENMHASH:8214BDBBC03F37877598DD319CF9DA28:6A89D21D1F64E0716C2BB0607B2B985E
        public ApplicationGatewayListenerImpl WithPublicFrontend()
        {
            //$ this.WithFrontend(this.Parent().EnsureDefaultPublicFrontend().Name());
            //$ return this;

            return this;
        }

        ///GENMHASH:2EC798C5560EA4F2234EFA1478E59C04:409B6655E16BAB2E8CCE5B4E431083EE
        private ApplicationGatewayListenerImpl WithFrontend(string name)
        {
            //$ SubResource frontendRef = new SubResource()
            //$ .WithId(this.Parent().FutureResourceId() + "/frontendIPConfigurations/" + name);
            //$ this.Inner.WithFrontendIPConfiguration(frontendRef);
            //$ return this;
            //$ }

            return this;
        }

        ///GENMHASH:85408D425EF4341A6D39C75F68ED8A2B:60CB6094D3C3120ABC72B2E26313EF5A
        public ApplicationGatewayListenerImpl WithServerNameIndication()
        {
            //$ this.Inner.WithRequireServerNameIndication(true);
            //$ return this;

            return this;
        }

        ///GENMHASH:604F12B361C77B3E3AD5768A73BA6DCF:ABADA5A8E77FDA08CD893ADDC4895F32
        public ApplicationGatewayListenerImpl WithHttp()
        {
            //$ this.Inner.WithProtocol(ApplicationGatewayProtocol.HTTP);
            //$ return this;

            return this;
        }

        ///GENMHASH:377296039E5241FB1B02988EFB811F77:EB7E862083A458D624358925C66523A7
        public IPublicIpAddress GetPublicIpAddress()
        {
            //$ String pipId = this.PublicIpAddressId();
            //$ if (pipId == null) {
            //$ return null;
            //$ } else {
            //$ return this.Parent().Manager().PublicIpAddresses().GetById(pipId);
            //$ }

            return null;
        }

        ///GENMHASH:C57133CD301470A479B3BA07CD283E86:251CDCA01439FEEC30E23AD50DA1453A
        public string SubnetName()
        {
            //$ ApplicationGatewayFrontend frontend = this.Frontend();
            //$ if (frontend != null) {
            //$ return frontend.SubnetName();
            //$ } else {
            //$ return null;
            //$ }

            return null;
        }

        ///GENMHASH:E40B3F1FA93E71A00314196726D4960B:B71AFF4FEE8DFD54B2E5B5F488E605CC
        public string FrontendPortName()
        {
            //$ if (this.Inner.FrontendPort() != null) {
            //$ return ResourceUtils.NameFromResourceId(this.Inner.FrontendPort().Id());
            //$ } else {
            //$ return null;
            //$ }

            return null;
        }

        ///GENMHASH:D684E7477889A9013C81FAD82F69C54F:BD249A015EF71106387B78281489583A
        public ApplicationGatewayProtocol Protocol()
        {
            //$ return this.Inner.Protocol();

            return null;
        }

        ///GENMHASH:1207E16326E66DA6A51CBA6F0565D088:3F3B707B427A3370160F5D3A76951425
        public IApplicationGatewaySslCertificate SslCertificate()
        {
            //$ SubResource certRef = this.Inner.SslCertificate();
            //$ if (certRef == null) {
            //$ return null;
            //$ }
            //$ 
            //$ String name = ResourceUtils.NameFromResourceId(certRef.Id());
            //$ return this.Parent().SslCertificates().Get(name);

            return null;
        }

        ///GENMHASH:FDD79F9F4A54F00F3D88A305BD6E4101:C0847EA0CDA78F6D91EFD239C70F0FA7
        internal ApplicationGatewayListenerImpl(ApplicationGatewayHttpListenerInner inner, ApplicationGatewayImpl parent) : base(inner, parent)
        {
            //$ super(inner, parent);
            //$ }

        }

        ///GENMHASH:1C444C90348D7064AB23705C542DDF18:ADFE7EEA0734BA251C7A2C00B4ED3531
        public string NetworkId()
        {
            //$ ApplicationGatewayFrontend frontend = this.Frontend();
            //$ if (frontend != null) {
            //$ return frontend.NetworkId();
            //$ } else {
            //$ return null;
            //$ }

            return null;
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:0C6B6B4DD8E378E1E80FAA7AD88AD383
        public ApplicationGatewayImpl Attach()
        {
            //$ this.Parent().WithHttpListener(this);
            //$ return this.Parent();

            return null;
        }

        ///GENMHASH:5ACBA6D500464D19A23A5A5A6A184B79:3CAED6F38D63250A1D8283E364506FF5
        public ApplicationGatewayListenerImpl WithHostName(string hostname)
        {
            //$ this.Inner.WithHostName(hostname);
            //$ return this;

            return this;
        }

        ///GENMHASH:CB6B71434C2E17A82873B7892EE00D55:5B3EF817B7C74BB136E1CA2B7400D046
        public ApplicationGatewayListenerImpl WithoutServerNameIndication()
        {
            //$ this.Inner.WithRequireServerNameIndication(false);
            //$ return this;

            return this;
        }

        ///GENMHASH:7C5A670BDA8BF576E8AFC752CD10A797:588DD8355CC6B8BBA6CED27FD5C42C76
        public ApplicationGatewayListenerImpl WithPrivateFrontend()
        {
            //$ this.WithFrontend(this.Parent().EnsureDefaultPrivateFrontend().Name());
            //$ return this;

            return this;
        }

        ///GENMHASH:1D7C0E3D335976570E947F3D48437E66:90F5612F9FB70607B79E07A32AEB8B8D
        public ApplicationGatewayListenerImpl WithSslCertificate(string name)
        {
            //$ SubResource certRef = new SubResource()
            //$ .WithId(this.Parent().FutureResourceId() + "/sslCertificates/" + name);
            //$ this.Inner.WithSslCertificate(certRef);
            //$ return this;

            return this;
        }

        ///GENMHASH:FA888A1E446DDA9E368D1EF43B428BAC:0FE70D5AE03341449A2D980808F522FC
        public ApplicationGatewayListenerImpl WithHttps()
        {
            //$ this.Inner.WithProtocol(ApplicationGatewayProtocol.HTTPS);
            //$ return this;

            return this;
        }

        ///GENMHASH:FD5739AFD5E74CB55C9C465B3661FBF2:393821A9A3F65B68E26BFBEA4350B3DD
        public ApplicationGatewayListenerImpl WithFrontendPort(string name)
        {
            //$ SubResource portRef = new SubResource()
            //$ .WithId(this.Parent().FutureResourceId() + "/frontendPorts/" + name);
            //$ this.Inner.WithFrontendPort(portRef);
            //$ return this;

            return this;
        }

        ///GENMHASH:1E7046ABBFA82B3370C0EE4358FCAAB3:689FD1A4EAEB4800D166067F7761BB3D
        public ApplicationGatewayListenerImpl WithFrontendPort(int portNumber)
        {
            //$ // Attempt to find an existing port referencing this port number
            //$ String portName = this.Parent().FrontendPortNameFromNumber(portNumber);
            //$ if (portName == null) {
            //$ // Existing frontend port with this number not found so create one
            //$ portName = ResourceNamer.RandomResourceName("port", 9);
            //$ this.Parent().WithFrontendPort(portNumber, portName);
            //$ }
            //$ 
            //$ return this.WithFrontendPort(portName);

            return this;
        }

        ///GENMHASH:A80C3FC8655E547C3392C10C546FFF39:F5F48992AF3FBAF8C1BC9C9A59C415FF
        public bool RequiresServerNameIndication()
        {
            //$ if (this.Inner.RequireServerNameIndication() != null) {
            //$ return this.Inner.RequireServerNameIndication();
            //$ } else {
            //$ return false;
            //$ }

            return false;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public override string Name()
        {
            //$ return this.Inner.Name();

            return null;
        }

        ///GENMHASH:8E78B2392D3D6F9CD12A41F263DE68A1:B1EFB1649097FFA979E13C945E517EDB
        public string PublicIpAddressId()
        {
            //$ ApplicationGatewayFrontendImpl frontend = (ApplicationGatewayFrontendImpl) this.Frontend();
            //$ if (frontend == null) {
            //$ return null;
            //$ } else {
            //$ return frontend.PublicIpAddressId();
            //$ }

            return null;
        }

        ///GENMHASH:B206A6556439FF2D98365C5283836AD5:125C0E491D4D29CEE8322DF9019C1DE7
        public IApplicationGatewayFrontend Frontend()
        {
            //$ SubResource frontendInner = this.Inner.FrontendIPConfiguration();
            //$ if (frontendInner == null) {
            //$ return null;
            //$ } else {
            //$ String frontendName = ResourceUtils.NameFromResourceId(frontendInner.Id());
            //$ return this.Parent().Frontends().Get(frontendName);
            //$ }

            return null;
        }

        ApplicationGateway.Update.IUpdate ISettable<ApplicationGateway.Update.IUpdate>.Parent()
        {
            return Parent;
        }
    }
}