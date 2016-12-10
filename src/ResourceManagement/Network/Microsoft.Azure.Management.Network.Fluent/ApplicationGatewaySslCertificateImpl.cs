// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using ApplicationGateway.Definition;
    using ApplicationGateway.Update;
    using ApplicationGatewaySslCertificate.Definition;
    using ApplicationGatewaySslCertificate.Update;
    using ApplicationGatewaySslCertificate.UpdateDefinition;
    using Models;
    using Microsoft.Azure.Management.Resource.Fluent.Core;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Definition;
    using Microsoft.Azure.Management.Resource.Fluent.Core.ChildResource.Update;
    using System.IO;
    using Resource.Fluent.Core.ChildResourceActions;

    /// <summary>
    /// Implementation for ApplicationGatewaySslCertificate.
    /// </summary>
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uQXBwbGljYXRpb25HYXRld2F5U3NsQ2VydGlmaWNhdGVJbXBs
    internal partial class ApplicationGatewaySslCertificateImpl :
        ChildResource<Models.ApplicationGatewaySslCertificateInner, Microsoft.Azure.Management.Network.Fluent.ApplicationGatewayImpl, Microsoft.Azure.Management.Network.Fluent.IApplicationGateway>,
        IApplicationGatewaySslCertificate,
        IDefinition<ApplicationGateway.Definition.IWithCreate>,
        IUpdateDefinition<ApplicationGateway.Update.IUpdate>,
        ApplicationGatewaySslCertificate.Update.IUpdate
    {
        ///GENMHASH:94F90A4A28B1E983315F51729B27DB77:71EBC245EFF014FF21D0CBEC5F53A54C
        public ApplicationGatewaySslCertificateImpl WithPfxFromFile(FileInfo pfxFile)
        {
            //$ if (pfxFile == null) {
            //$ return null;
            //$ }
            //$ 
            //$ byte[] content;
            //$ try {
            //$ content = Files.ReadAllBytes(pfxFile.ToPath());
            //$ return withPfxFromBytes(content);
            //$ } catch (IOException e) {
            //$ e.PrintStackTrace();
            //$ return null;
            //$ }

            return this;
        }

        ///GENMHASH:10A46E6A29805F84C3DCA9670AF5A0BC:C0847EA0CDA78F6D91EFD239C70F0FA7
        internal ApplicationGatewaySslCertificateImpl(ApplicationGatewaySslCertificateInner inner, ApplicationGatewayImpl parent) : base(inner, parent)
        {
            //$ super(inner, parent);
            //$ }

        }

        ///GENMHASH:F2EE2F07B6724F1FF58043814706A8ED:DB3DCD6CAFDAF739E813082765CD3375
        public ApplicationGatewaySslCertificateImpl WithPfxFromBytes(params byte[] pfxData)
        {
            //$ String encoded = new String(BaseEncoding.Base64().Encode(pfxData));
            //$ this.Inner.WithData(encoded);
            //$ return this;

            return this;
        }

        ///GENMHASH:079EAB40DB57656F562BDBA357A86C43:8892D33C89EB45AB71456048E4189668
        public ApplicationGatewaySslCertificateImpl WithPfxPassword(string password)
        {
            //$ this.Inner.WithPassword(password);
            //$ return this;

            return this;
        }

        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public override string Name()
        {
            //$ return this.Inner.Name();

            return null;
        }

        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:C900710B9B91094E9DE2F1F22E9BCEA4
        public ApplicationGatewayImpl Attach()
        {
            //$ this.Parent().WithSslCertificate(this);
            //$ return this.Parent();

            return null;
        }

        ///GENMHASH:37B0EAF4E984261F22FBACEF515D705F:19A294AC60BE3434C95A61817A6A6A02
        public string PublicData()
        {
            //$ return this.Inner.PublicCertData();

            return null;
        }

        ApplicationGateway.Update.IUpdate ISettable<ApplicationGateway.Update.IUpdate>.Parent()
        {
            return Parent;
        }
    }
}