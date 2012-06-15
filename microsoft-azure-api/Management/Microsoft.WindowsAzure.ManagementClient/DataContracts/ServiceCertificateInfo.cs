//-----------------------------------------------------------------------
// <copyright file="ServiceCertificateInfo.cs" company="Microsoft">
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
//    Contains code for the ServiceCertificateCollection 
//    and ServiceCertificateInfo class.
// </summary>
//-----------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;

//disable warning about field never assigned to. 
//It gets assigned at deserialization time
#pragma warning disable 649

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    /// <summary>
    /// Represents a collection of <see cref="ServiceCertificateInfo"/> objects.
    /// </summary>
    [CollectionDataContract(Name = "Certificates", Namespace = AzureConstants.AzureSchemaNamespace)]
    public class ServiceCertificateCollection : List<ServiceCertificateInfo>
    {
        private ServiceCertificateCollection() { }

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

    /// <summary>
    /// Represents information about a cloud service certificate.
    /// </summary>
    [DataContract(Name = "Certificate", Namespace = AzureConstants.AzureSchemaNamespace)]
    public class ServiceCertificateInfo : AzureDataContractBase
    {
        private ServiceCertificateInfo() { }

        /// <summary>
        /// Gets the Url of the certificate in Windows Azure.
        /// </summary>
        [DataMember(Name = "CertificateUrl", Order = 0, IsRequired = true)]
        public Uri Url { get; private set; }

        /// <summary>
        /// Gets the thumbprint of the certificate.
        /// </summary>
        [DataMember(Order = 1, IsRequired = true)]
        public string Thumbprint { get; private set; }

        /// <summary>
        /// Gets the thumbprint algorithm of the certificate. 
        /// Currently the only valid value is "sha1".
        /// </summary>
        [DataMember(Order = 2, IsRequired = true)]
        public string ThumbprintAlgorithm { get; private set; }

        /// <summary>
        /// Gets the certificate.
        /// </summary>
        public X509Certificate2 Certificate { get; private set; }

        [DataMember(Name = "Data", Order = 3, IsRequired = true)]
        private string _certData;

        [OnDeserialized]
        private void DeserializeCert(StreamingContext context)
        {
            byte[] certBytes = Convert.FromBase64String(_certData);

            this.Certificate = new X509Certificate2(certBytes);
        }
    }
}
