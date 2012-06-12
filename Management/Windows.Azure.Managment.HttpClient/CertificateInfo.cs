using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;

namespace Windows.Azure.Management.v1_7
{
    #region Service Certificates
    [CollectionDataContract(Name = "Certificates", Namespace = AzureConstants.AzureSchemaNamespace)]
    public class ServiceCertificateCollection : List<ServiceCertificateInfo>
    {
        private ServiceCertificateCollection() { }

        public override string ToString()
        {
            return AzureDataContractBase.ToStringWorker(this);
        }
    }

    [DataContract(Name = "Certificate", Namespace = AzureConstants.AzureSchemaNamespace)]
    public class ServiceCertificateInfo : AzureDataContractBase
    {
        private ServiceCertificateInfo() { }

        [DataMember(Name = "CertificateUrl", Order = 0, IsRequired = true)]
        public Uri Url { get; private set; }

        [DataMember(Order = 1, IsRequired = true)]
        public String Thumbprint { get; private set; }

        [DataMember(Order = 2, IsRequired = true)]
        public String ThumbprintAlgorithm { get; private set; }

        public X509Certificate2 Certificate { get; private set; }

        [DataMember(Name = "Data", Order = 3, IsRequired = true)]
        private String _certData;

        [OnDeserialized]
        private void DeserializeCert(StreamingContext context)
        {
            byte[] certBytes = Convert.FromBase64String(this._certData);

            this.Certificate = new X509Certificate2(certBytes);
        }
    }

    [DataContract(Name = "CertificateFile", Namespace = AzureConstants.AzureSchemaNamespace)]
    internal class AddServiceCertificateInfo : AzureDataContractBase
    {
        private const string certFormat = "pfx"; //only accepted value
        private AddServiceCertificateInfo() { }

        //TODO: Password is SecureString?
        internal static AddServiceCertificateInfo Create(X509Certificate2 certificate, String password)
        {
            Validation.NotNull(certificate, "certificate");
            //password might be null...

            if (certificate.HasPrivateKey == false) throw new ArgumentException(Resources.CertificateNoPrivateKey);

            byte[] certData = certificate.Export(X509ContentType.Pfx, password);

            String data = Convert.ToBase64String(certData);

            return new AddServiceCertificateInfo
            {
                Data = data,
                CertificateFormat = certFormat,
                Password = password
            };
        }

        [DataMember(Order = 0, IsRequired = true)]
        internal String Data { get; private set; }

        [DataMember(Order = 1, IsRequired = true)]
        internal String CertificateFormat { get; private set; }

        [DataMember(Order = 2, IsRequired = false, EmitDefaultValue = true)]
        internal String Password { get; private set; }
    }

    //this is an oddball class. It is returned from a Get function, but it only
    //contains the certificate, so we turn the cert into an X509Certificate object and
    //return that publically, so this class is internal. See GetServiceCertificateAsync
    [DataContract(Name = "Certificate", Namespace = AzureConstants.AzureSchemaNamespace)]
    internal class ServiceCertificateData : AzureDataContractBase
    {
        private ServiceCertificateData() { }

        [DataMember(Name="Data", IsRequired=true)]
        private String _certData;

        internal X509Certificate2 Certificate { get; private set; }

        [OnDeserialized]
        private void DeserializeCert(StreamingContext context)
        {
            byte[] certBytes = Convert.FromBase64String(this._certData);

            this.Certificate = new X509Certificate2(certBytes);
        }
    }
    #endregion

    #region Management Certificates
    [CollectionDataContract(Name = "SubscriptionCertificates", Namespace = AzureConstants.AzureSchemaNamespace)]
    public class ManagementCertificateCollection : List<ManagementCertificateInfo>
    {
        private ManagementCertificateCollection() { }

        public override string ToString()
        {
            return AzureDataContractBase.ToStringWorker(this);
        }
    }

    //This same class can be used for GET and POST so no need to duplicate,
    //the static Create is only used for POST so, internal
    [DataContract(Name = "SubscriptionCertificate", Namespace = AzureConstants.AzureSchemaNamespace)]
    public class ManagementCertificateInfo : AzureDataContractBase
    {
        private ManagementCertificateInfo() { }

        internal static ManagementCertificateInfo Create(X509Certificate2 certificate)
        {
            Validation.NotNull(certificate, "certificate");

            //can just pull everything out of the cert...
            byte[] keyBytes = certificate.PublicKey.EncodedKeyValue.RawData;
            byte[] cerBytes = certificate.RawData;

            return new ManagementCertificateInfo
            {
                PublicKey = Convert.ToBase64String(keyBytes),
                Thumbprint = certificate.Thumbprint,
                RawData = Convert.ToBase64String(cerBytes)
            };
        }

        [DataMember(Name="SubscriptionCertificatePublicKey", Order=0, IsRequired=true)]
        public String PublicKey { get; private set; }

        [DataMember(Name="SubscriptionCertificateThumbprint", Order=1, IsRequired=true)]
        public String Thumbprint { get; private set; }

        [DataMember(Name="SubscriptionCertificateData", Order=2, IsRequired=true)]
        public String RawData { get; private set; }

        [DataMember(Order=3, IsRequired=false, EmitDefaultValue=false)]
        public DateTime Created { get; private set; }
    }
    #endregion

}
