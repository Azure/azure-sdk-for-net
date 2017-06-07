//-----------------------------------------------------------------------
// <copyright file="ManagementCertificateInfo.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
//
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
//
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// <summary>
//    Contains code for the ManagementCertificateCollection 
//    and ManagementCertificateInfo classes.
// </summary>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    /// <summary>
    /// Represents a collection of 
    /// <see cref="ManagementCertificateInfo"/> objects.
    /// </summary>
    [CollectionDataContract(Name = "SubscriptionCertificates", Namespace = AzureConstants.AzureSchemaNamespace)]
    public class ManagementCertificateCollection : List<ManagementCertificateInfo>
    {
        private ManagementCertificateCollection() { }

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

    //This same class can be used for GET and POST so no need to duplicate,
    //the static Create is only used for POST so, internal
    /// <summary>
    /// Represents information about a management certificate.
    /// </summary>
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
                _publicKey = Convert.ToBase64String(keyBytes),
                Thumbprint = certificate.Thumbprint,
                _certData = Convert.ToBase64String(cerBytes),
                Certificate = new X509Certificate2(cerBytes)
            };
        }

        /// <summary>
        /// Gets the public key of the certificate.
        /// </summary>
        public byte[] PublicKey { get { return Convert.FromBase64String(_publicKey); } }

        [DataMember(Name = "SubscriptionCertificatePublicKey", Order = 0, IsRequired = true)]
        private string _publicKey;

        /// <summary>
        /// Gets the thumbprint of the certificate.
        /// </summary>
        [DataMember(Name = "SubscriptionCertificateThumbprint", Order = 1, IsRequired = true)]
        public string Thumbprint { get; private set; }

        /// <summary>
        /// Gets the certificate.
        /// </summary>
        public X509Certificate2 Certificate { get; private set; }

        [DataMember(Name = "SubscriptionCertificateData", Order = 2, IsRequired = true)]
        private string _certData;

        /// <summary>
        /// Gets the date and time the certificate was created.
        /// </summary>
        [DataMember(Order = 3, IsRequired = false, EmitDefaultValue = false)]
        public DateTime Created { get; private set; }

        [OnDeserialized]
        private void DeserializeCert(StreamingContext context)
        {
            byte[] certBytes = Convert.FromBase64String(_certData);

            this.Certificate = new X509Certificate2(certBytes);
        }
    }
}
