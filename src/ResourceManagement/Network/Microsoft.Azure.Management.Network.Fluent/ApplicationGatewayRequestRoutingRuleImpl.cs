// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using ApplicationGateway.Definition;
    using ApplicationGateway.Update;
    using Models;
    using ApplicationGatewayRequestRoutingRule.Definition;
    using ApplicationGatewayRequestRoutingRule.Update;
    using ApplicationGatewayRequestRoutingRule.UpdateDefinition;
    using HasCookieBasedAffinity.Definition;
    using HasCookieBasedAffinity.UpdateDefinition;
    using HasHostName.Definition;
    using HasHostName.UpdateDefinition;
    using HasServerNameIndication.Definition;
    using HasServerNameIndication.UpdateDefinition;
    using HasSslCertificate.Definition;
    using HasSslCertificate.UpdateDefinition;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;
    using System.Collections.Generic;
    using System.IO;
    using Resource.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// Implementation for ApplicationGatewayRequestRoutingRule.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uQXBwbGljYXRpb25HYXRld2F5UmVxdWVzdFJvdXRpbmdSdWxlSW1wbA==
    internal partial class ApplicationGatewayRequestRoutingRuleImpl :
        ChildResource<Models.ApplicationGatewayRequestRoutingRuleInner, Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayImpl, Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        IApplicationGatewayRequestRoutingRule,
        IDefinition<ApplicationGateway.Definition.IWithRequestRoutingRuleOrCreate>,
        IUpdateDefinition<ApplicationGateway.Update.IUpdate>,
        ApplicationGatewayRequestRoutingRule.Update.IUpdate
    {
        private bool associateWithPublicFrontend;
        ///GENMHASH:AFBFDB5617AA4227641C045CF9D86F66:E59D799F1DB4F9650C71EDC18FB6BFBB
        public ApplicationGatewayRequestRoutingRuleImpl WithSslCertificateFromPfxFile(FileInfo pfxFile)
        {
            //$ this.Parent().UpdateListener(ensureListener().Name()).WithSslCertificateFromPfxFile(pfxFile);
            //$ return this;

            return this;
        }

        ///GENMHASH:382D2BF4EBC04F5E7DF95B5EF5A97146:A2186495BD577CBC3FCDAFE065A38100
        public ApplicationGatewayRequestRoutingRuleImpl WithSslCertificatePassword(string password)
        {
            //$ this.Parent().UpdateListener(ensureListener().Name()).WithSslCertificatePassword(password);
            //$ return this;

            return this;
        }

        ///GENMHASH:A50A011CA652E846C1780DCE98D171DE:264DF620709DF8F8037CB6E71CCB5375
        public string HostName()
        {
            //$ ApplicationGatewayListener listener = this.Listener();
            //$ if (listener == null) {
            //$ return null;
            //$ } else {
            //$ return listener.HostName();
            //$ }

            return null;
        }

        ///GENMHASH:E5009D35A881840DCEE40214DFD5197F:C0E7624E9F0A1098FE7AC34D7DC81866
        public ApplicationGatewayRequestRoutingRuleImpl ToBackendHttpConfiguration(string name)
        {
            //$ SubResource httpConfigRef = new SubResource()
            //$ .WithId(this.Parent().FutureResourceId() + "/backendHttpSettingsCollection/" + name);
            //$ this.Inner.WithBackendHttpSettings(httpConfigRef);
            //$ return this;

            return this;
        }

        ///GENMHASH:85408D425EF4341A6D39C75F68ED8A2B:D7EEEE46B8C5048ECEB42B103795D1F6
        public ApplicationGatewayRequestRoutingRuleImpl WithServerNameIndication()
        {
            //$ this.Parent().UpdateListener(ensureListener().Name()).WithServerNameIndication();
            //$ return this;

            return this;
        }

        ///GENMHASH:F8F8F11F485174C9B1CC3FA0197799B9:649DFFCBE23D4220949D8CA7A521D053
        public ApplicationGatewayListenerImpl Listener()
        {
            //$ SubResource listenerRef = this.Inner.HttpListener();
            //$ if (listenerRef != null) {
            //$ String listenerName = ResourceUtils.NameFromResourceId(listenerRef.Id());
            //$ return (ApplicationGatewayListenerImpl) this.Parent().Listeners().Get(listenerName);
            //$ } else {
            //$ return null;
            //$ }

            return null;
        }

        ///GENMHASH:4364BC2E794A044FD930E465BFF31892:5F1B09727C6B0D98D3B91D719E4AF6B7
        public ApplicationGatewayRequestRoutingRuleImpl FromFrontendHttpPort(int portNumber)
        {
            //$ return this.FromFrontendPort(portNumber, ApplicationGatewayProtocol.HTTP, null);

            return this;
        }

        ///GENMHASH:0BBB3340617BD27DD6A3E851FD10BEE1:4BADA88C5FE9D21589BBD33AED331911
        public bool CookieBasedAffinity()
        {
            //$ ApplicationGatewayBackendHttpConfiguration backendConfig = this.BackendHttpConfiguration();
            //$ if (backendConfig == null) {
            //$ return false;
            //$ } else {
            //$ return backendConfig.CookieBasedAffinity();
            //$ }

            return false;
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

        ///GENMHASH:88B8E503CCDD1E57245F30B2FC889572:31A6A2A69894AFD68DBAC0B8E83EF284
        public IList<Models.ApplicationGatewayBackendAddress> BackendAddresses()
        {
            //$ List<ApplicationGatewayBackendAddress> addresses;
            //$ ApplicationGatewayBackend backend = this.Backend();
            //$ if (backend == null) {
            //$ addresses = new ArrayList<>();
            //$ } else if (backend.Addresses() == null) {
            //$ addresses = new ArrayList<>();
            //$ } else {
            //$ addresses = backend.Addresses();
            //$ }
            //$ return Collections.UnmodifiableList(addresses);

            return null;
        }

        ///GENMHASH:3E9C9108A0B9643E9C6CCF35D944BFF5:1284C4FFCBC626062213718CF44C586A
        public ApplicationGatewayRequestRoutingRuleImpl ToBackendHttpPort(int portNumber)
        {
            //$ String name = ResourceNamer.RandomResourceName("backcfg", 12);
            //$ this.Parent().DefineBackendHttpConfiguration(name)
            //$ .WithPort(portNumber)
            //$ .Attach();
            //$ return this.ToBackendHttpConfiguration(name);

            return this;
        }

        ///GENMHASH:64EFD8E5D6EE43236B119988348C8FE5:551C88DB1BFEC84D69F63E5B891BF1C9
        public ApplicationGatewayRequestRoutingRuleImpl FromListener(string name)
        {
            //$ SubResource listenerRef = new SubResource()
            //$ .WithId(this.Parent().FutureResourceId() + "/HTTPListeners/" + name);
            //$ this.Inner.WithHttpListener(listenerRef);
            //$ return this;

            return this;
        }

        ///GENMHASH:DE88BB19D1C1507E6EAAD715D1F861E6:4472B7545CB9071BC46FFAFFB6BEFD43
        private ApplicationGatewayRequestRoutingRuleImpl FromFrontendPort(int portNumber, ApplicationGatewayProtocol protocol, string name)
        {
            //$ // Verify no conflicting listener exists
            //$ ApplicationGatewayListenerImpl listenerByPort =
            //$ (ApplicationGatewayListenerImpl) this.Parent().ListenerByPortNumber(portNumber);
            //$ ApplicationGatewayListenerImpl listenerByName = null;
            //$ if (name != null) {
            //$ listenerByName = (ApplicationGatewayListenerImpl) this.Parent().Listeners().Get(name);
            //$ }
            //$ 
            //$ Boolean needToCreate = this.Parent().NeedToCreate(listenerByName, listenerByPort, name);
            //$ if (Boolean.TRUE.Equals(needToCreate)) {
            //$ // If no listener exists for the requested port number yet and the name, create one
            //$ if (name == null) {
            //$ name = ResourceNamer.RandomResourceName("listener", 13);
            //$ }
            //$ 
            //$ listenerByPort = this.Parent().DefineListener(name)
            //$ .WithFrontendPort(portNumber);
            //$ 
            //$ // Determine protocol
            //$ if (ApplicationGatewayProtocol.HTTP.Equals(protocol)) {
            //$ listenerByPort.WithHttp();
            //$ } else if (ApplicationGatewayProtocol.HTTPS.Equals(protocol)) {
            //$ listenerByPort.WithHttps();
            //$ }
            //$ 
            //$ // Determine frontend
            //$ if (Boolean.TRUE.Equals(this.associateWithPublicFrontend)) {
            //$ listenerByPort.WithPublicFrontend();
            //$ this.Parent().WithNewPublicIpAddress();
            //$ } else if (Boolean.FALSE.Equals(this.associateWithPublicFrontend)) {
            //$ listenerByPort.WithPrivateFrontend();
            //$ }
            //$ this.associateWithPublicFrontend = null;
            //$ 
            //$ listenerByPort.Attach();
            //$ return this.FromListener(listenerByPort.Name());
            //$ } else {
            //$ // If matching listener already exists then fail
            //$ return null;
            //$ }
            //$ }

            return this;
        }

        ///GENMHASH:B7056D5E403DF443379DDF57BB0658A2:D8B908F745288E8BB24BBEA2614AD276
        public int BackendPort()
        {
            //$ ApplicationGatewayBackendHttpConfiguration backendConfig = this.BackendHttpConfiguration();
            //$ if (backendConfig == null) {
            //$ return 0;
            //$ } else {
            //$ return backendConfig.Port();
            //$ }

            return 0;
        }

        ///GENMHASH:1207E16326E66DA6A51CBA6F0565D088:CDD93AFCE1E2F4AD482190B38A2C9823
        public IApplicationGatewaySslCertificate SslCertificate()
        {
            //$ if (this.Listener() == null) {
            //$ return null;
            //$ } else {
            //$ return this.Listener().SslCertificate();
            //$ }

            return null;
        }

        ///GENMHASH:1AB1FD137FCAFECBC19E784B21600422:A8E447B9115965EC413B57E517B5DA3B
        public ApplicationGatewayRequestRoutingRuleImpl WithoutCookieBasedAffinity()
        {
            //$ this.Parent().UpdateBackendHttpConfiguration(ensureBackendHttpConfig().Name())
            //$ .WithoutCookieBasedAffinity();
            //$ return this;

            return this;
        }

        ///GENMHASH:597B4CCFA9884BBB039FE1B734196FBB:9BB7A8FF5376A1E35A43987311B73DC5
        public ApplicationGatewayRequestRoutingRuleType RuleType()
        {
            //$ return this.Inner.RuleType();

            return null;
        }

        ///GENMHASH:5AC5C38B890C28F2C14CCD5CC0A89B49:0B03E9DA7912B73A5E88BD6441153E80
        public IApplicationGatewayBackend Backend()
        {
            //$ SubResource backendRef = this.Inner.BackendAddressPool();
            //$ if (backendRef != null) {
            //$ String backendName = ResourceUtils.NameFromResourceId(backendRef.Id());
            //$ return this.Parent().Backends().Get(backendName);
            //$ } else {
            //$ return null;
            //$ }

            return null;
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:BA43F9EDEEC35BE6198E496FFC893CBD
        public ApplicationGatewayImpl Attach()
        {
            //$ this.Parent().WithRequestRoutingRule(this);
            //$ return this.Parent();

            return null;
        }

        ///GENMHASH:5ACBA6D500464D19A23A5A5A6A184B79:C49203B793C8E16B0A521362FC4A91D6
        public ApplicationGatewayRequestRoutingRuleImpl WithHostName(string hostName)
        {
            //$ this.Parent().UpdateListener(ensureListener().Name()).WithHostName(hostName);
            //$ return this;

            return this;
        }

        ///GENMHASH:DDD0EE7198E7BD6B745033E06D1924F5:C0A442280B171D31392F57AC5F9A09F8
        private ApplicationGatewayBackendImpl EnsureBackend()
        {
            //$ ApplicationGatewayBackendImpl backend = (ApplicationGatewayBackendImpl) this.Backend();
            //$ if (backend == null) {
            //$ String name = ResourceNamer.RandomResourceName("backend", 12);
            //$ backend = this.Parent().DefineBackend(name);
            //$ backend.Attach();
            //$ this.ToBackend(name);
            //$ }
            //$ 
            //$ return backend;
            //$ }

            return null;
        }

        ///GENMHASH:B3B3BBEB4388330056F367AFFE5E08E7:955135520FC3C8B79C3CC7BBD653E1D6
        public ApplicationGatewayRequestRoutingRuleImpl FromPublicFrontend()
        {
            //$ this.associateWithPublicFrontend = true;
            //$ return this;

            return this;
        }

        ///GENMHASH:CB6B71434C2E17A82873B7892EE00D55:6699CF8695CA8CD4C78C07D022AFE500
        public ApplicationGatewayRequestRoutingRuleImpl WithoutServerNameIndication()
        {
            //$ this.Parent().UpdateListener(ensureListener().Name()).WithoutServerNameIndication();
            //$ return this;

            return this;
        }

        ///GENMHASH:A76BF54E2AEEF72945445A32066CB6F8:3FFB9E2FDF9813C8FCE41F3D46BEF1C9
        public ApplicationGatewayRequestRoutingRuleImpl ToBackendIpAddress(string ipAddress)
        {
            //$ this.Parent().UpdateBackend(ensureBackend().Name()).WithIpAddress(ipAddress);
            //$ return this;

            return this;
        }

        ///GENMHASH:B2F4F96855247681287878DA2BF26C8E:7BE0813A1F69908779DA5794AAE2BD13
        public ApplicationGatewayBackendHttpConfigurationImpl BackendHttpConfiguration()
        {
            //$ SubResource configRef = this.Inner.BackendHttpSettings();
            //$ if (configRef != null) {
            //$ String configName = ResourceUtils.NameFromResourceId(configRef.Id());
            //$ return (ApplicationGatewayBackendHttpConfigurationImpl) this.Parent().BackendHttpConfigurations().Get(configName);
            //$ } else {
            //$ return null;
            //$ }

            return null;
        }

        ///GENMHASH:C9BEFCDC31CD90EB31575FB70FEC63EF:572F23F90AA511055CD97EF80750265B
        public ApplicationGatewayRequestRoutingRuleImpl FromFrontendHttpsPort(int portNumber)
        {
            //$ return this.FromFrontendPort(portNumber, ApplicationGatewayProtocol.HTTPS, null);

            return this;
        }

        ///GENMHASH:BF497059E01321BD53A7DF19D85F4D8E:C0847EA0CDA78F6D91EFD239C70F0FA7
        internal ApplicationGatewayRequestRoutingRuleImpl(ApplicationGatewayRequestRoutingRuleInner inner, ApplicationGatewayImpl parent) : base(inner, parent)
        {
            //$ super(inner, parent);
            //$ }

        }

        ///GENMHASH:1D7C0E3D335976570E947F3D48437E66:21CFE894224FD9175DC687D7587C6B81
        public ApplicationGatewayRequestRoutingRuleImpl WithSslCertificate(string name)
        {
            //$ this.Parent().UpdateListener(ensureListener().Name()).WithSslCertificate(name);
            //$ return this;

            return this;
        }

        ///GENMHASH:EB41BE025536B41812665B952EBF2040:6AC3BC741A0D215AAE36D09DD6C6901C
        public int FrontendPort()
        {
            //$ ApplicationGatewayListener listener = this.Listener();
            //$ if (listener == null) {
            //$ return 0;
            //$ } else {
            //$ return listener.FrontendPortNumber();
            //$ }

            return 0;
        }

        ///GENMHASH:61009120769572DC319DE0A706651D48:A9AAC19D1000F85AE80FFDF68E2B7657
        public ApplicationGatewayRequestRoutingRuleImpl FromPrivateFrontend()
        {
            //$ this.associateWithPublicFrontend = false;
            //$ return this;

            return this;
        }

        ///GENMHASH:B141413D05555CAF08A805C787576617:9029EC63E1772B76B45975AFCC9C63DE
        private ApplicationGatewayBackendHttpConfigurationImpl EnsureBackendHttpConfig()
        {
            //$ ApplicationGatewayBackendHttpConfigurationImpl config = this.BackendHttpConfiguration();
            //$ if (config == null) {
            //$ String name = ResourceNamer.RandomResourceName("bckcfg", 11);
            //$ config = this.Parent().DefineBackendHttpConfiguration(name);
            //$ config.Attach();
            //$ this.ToBackendHttpConfiguration(name);
            //$ }
            //$ return config;
            //$ }

            return null;
        }

        ///GENMHASH:ABF006C723CD07B4C16642781DD352C1:80A92C790A23B4858621E149898669CA
        public ApplicationGatewayRequestRoutingRuleImpl ToBackend(string name)
        {
            //$ SubResource backendRef = new SubResource()
            //$ .WithId(this.Parent().FutureResourceId() + "/backendAddressPools/" + name);
            //$ this.Inner.WithBackendAddressPool(backendRef);
            //$ return this;

            return this;
        }

        ///GENMHASH:A80C3FC8655E547C3392C10C546FFF39:B19300B91009A92D52181B37B30FCC7B
        public bool RequiresServerNameIndication()
        {
            //$ ApplicationGatewayListener listener = this.Listener();
            //$ if (listener == null) {
            //$ return false;
            //$ } else {
            //$ return listener.RequiresServerNameIndication();
            //$ }

            return false;
        }

        ///GENMHASH:389A52ADE2A3CD0EC1D4345823ED3438:49DCB9A1FA027B67B2E9041AABC358E5
        public ApplicationGatewayRequestRoutingRuleImpl WithCookieBasedAffinity()
        {
            //$ this.Parent().UpdateBackendHttpConfiguration(ensureBackendHttpConfig().Name())
            //$ .WithCookieBasedAffinity();
            //$ return this;

            return this;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public override string Name()
        {
            //$ return this.Inner.Name();

            return null;
        }

        ///GENMHASH:D457B9CDACC819681A8B8A61E22717C2:E6EC55665567C1657FE0624801BD0B87
        public ApplicationGatewayProtocol FrontendProtocol()
        {
            //$ if (this.Listener() == null) {
            //$ return null;
            //$ } else {
            //$ return this.Listener().Protocol();
            //$ }

            return null;
        }

        ///GENMHASH:8E78B2392D3D6F9CD12A41F263DE68A1:E87CBDEF5F17393A6105622D05DEB191
        public string PublicIpAddressId()
        {
            //$ ApplicationGatewayListener listener = this.Listener();
            //$ if (listener == null) {
            //$ return null;
            //$ } else {
            //$ return listener.PublicIpAddressId();
            //$ }

            return null;
        }

        ///GENMHASH:8CE04F0B10328CF0D4983442F418CB39:61F8F2DB8DB29EF4DCCFE2F01DC9D3F0
        private ApplicationGatewayListenerImpl EnsureListener()
        {
            //$ ApplicationGatewayListenerImpl listener = this.Listener();
            //$ if (listener == null) {
            //$ String name = ResourceNamer.RandomResourceName("listener", 13);
            //$ listener = this.Parent().DefineListener(name);
            //$ listener.Attach();
            //$ this.FromListener(name);
            //$ }
            //$ return listener;
            //$ }

            return null;
        }

        ///GENMHASH:75998168C8403D37D5B62BD1214010ED:C1A031BED4FEE36EA5917030CC573179
        public ApplicationGatewayRequestRoutingRuleImpl ToBackendFqdn(string fqdn)
        {
            //$ this.Parent().UpdateBackend(ensureBackend().Name()).WithFqdn(fqdn);
            //$ return this;

            return this;
        }

        ApplicationGateway.Update.IUpdate ISettable<ApplicationGateway.Update.IUpdate>.Parent()
        {
            return Parent;
        }
    }
}