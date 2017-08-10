// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.
namespace Microsoft.Azure.Management.Network.Fluent
{
    using ApplicationGatewaySslCertificate.Definition;
    using ApplicationGatewaySslCertificate.UpdateDefinition;
    using Models;
    using ResourceManager.Fluent.Core;
    using System.IO;
    using ResourceManager.Fluent.Core.ChildResourceActions;
    using System;

    /// <summary>
    /// Implementation for ApplicationGatewaySslCertificate.
    /// </summary>
    
    ///GENTHASH:Y29tLm1pY3Jvc29mdC5henVyZS5tYW5hZ2VtZW50Lm5ldHdvcmsuaW1wbGVtZW50YXRpb24uQXBwbGljYXRpb25HYXRld2F5U3NsQ2VydGlmaWNhdGVJbXBs
    internal partial class ApplicationGatewaySslCertificateImpl :
        ChildResource<Models.ApplicationGatewaySslCertificateInner, ApplicationGatewayImpl, IApplicationGateway>,
        IApplicationGatewaySslCertificate,
        IDefinition<ApplicationGateway.Definition.IWithCreate>,
        IUpdateDefinition<ApplicationGateway.Update.IUpdate>,
        ApplicationGatewaySslCertificate.Update.IUpdate
    {
        
        ///GENMHASH:10A46E6A29805F84C3DCA9670AF5A0BC:C0847EA0CDA78F6D91EFD239C70F0FA7
        internal ApplicationGatewaySslCertificateImpl(ApplicationGatewaySslCertificateInner inner, ApplicationGatewayImpl parent) : base(inner, parent)
        {
        }

        #region Withers

        
        ///GENMHASH:F2EE2F07B6724F1FF58043814706A8ED:DB3DCD6CAFDAF739E813082765CD3375
        public ApplicationGatewaySslCertificateImpl WithPfxFromBytes(params byte[] pfxData)
        {
            string encoded = null;
            if (pfxData != null)
            {
                encoded = Convert.ToBase64String(pfxData);
            }
            Inner.Data = encoded;
            return this;
        }

        
        ///GENMHASH:079EAB40DB57656F562BDBA357A86C43:8892D33C89EB45AB71456048E4189668
        public ApplicationGatewaySslCertificateImpl WithPfxPassword(string password)
        {
            Inner.Password = password;
            return this;
        }

        
        ///GENMHASH:94F90A4A28B1E983315F51729B27DB77:C1618266BE02E9D02718895EE4730BE4
        public ApplicationGatewaySslCertificateImpl WithPfxFromFile(FileInfo pfxFile)
        {
            if (pfxFile == null) {
                throw new ArgumentNullException();
            }

            byte[] content = File.ReadAllBytes(pfxFile.FullName);
            return (content != null) ? WithPfxFromBytes(content) : null;
        }

        #endregion

        #region Accessors

        
        ///GENMHASH:37B0EAF4E984261F22FBACEF515D705F:19A294AC60BE3434C95A61817A6A6A02
        public string PublicData()
        {
            return Inner.PublicCertData;
        }

        ApplicationGateway.Update.IUpdate ISettable<ApplicationGateway.Update.IUpdate>.Parent()
        {
            return Parent;
        }

        
        ///GENMHASH:3E38805ED0E7BA3CAEE31311D032A21C:61C1065B307679F3800C701AE0D87070
        public override string Name()
        {
            return Inner.Name;
        }

        #endregion

        #region Actions

        
        ///GENMHASH:077EB7776EFFBFAA141C1696E75EF7B3:EE3E7C8735613AC91F1EABEEC252AB88
        public ApplicationGatewayImpl Attach()
        {
            return Parent.WithSslCertificate(this);
        }

        #endregion
    }
}
