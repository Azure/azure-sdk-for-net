using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.Serialization;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    [DataContract(Name = "StoredCertificateSettings", Namespace = AzureConstants.AzureSchemaNamespace)]
    public class CertificateSettingCollection : List<CertificateSetting>
    {
        //default constructor is left public here so users can create this and add to it...

        /// <summary>
        /// Overrides the base ToString method to return the XML serialization
        /// of the data contract represented by the class.
        /// </summary>
        /// <returns>
        /// XML serialized representation of this class as a string.
        /// </returns>
        public override string ToString()
        {
            return AzureDataContractBase.ToStringWorker(this);
        }
    }

    [DataContract(Name = "CertificateSetting", Namespace = AzureConstants.AzureSchemaNamespace)]
    public class CertificateSetting
    {
        private CertificateSetting() { }

        public CertificateSetting(StoreLocation storeLocation, StoreName storeName, string thumbprint)
        {
            this.StoreLocation = storeLocation;
            this.StoreName = storeName;
            this.Thumbprint = thumbprint;
        }

        public CertificateSetting(StoreLocation storeLocation, StoreName storeName, X509Certificate2 cert)
        {
            this.StoreLocation = storeLocation;
            this.StoreName = storeName;
            this.Thumbprint = cert.Thumbprint;
        }

        public StoreLocation StoreLocation { get; private set; }

        public StoreName StoreName { get; private set; }

        public string Thumbprint { get; private set; }
    }
}
