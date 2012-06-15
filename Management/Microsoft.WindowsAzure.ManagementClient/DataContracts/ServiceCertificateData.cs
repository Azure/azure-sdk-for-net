//-----------------------------------------------------------------------
// <copyright file="ServiceCertificateData.cs" company="Microsoft">
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
//    Contains code for the ServiceCertificateData class.
// </summary>
//-----------------------------------------------------------------------

using System;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;

//disable warning about field never assigned to. 
//It gets assigned at deserialization time
#pragma warning disable 649

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    //this is an oddball class. It is returned from a Get function, but it only
    //contains the certificate, so we turn the cert into an 
    //X509Certificate object and return that publically, 
    //so this class is internal. See GetServiceCertificateAsync
    [DataContract(Name = "Certificate", Namespace = AzureConstants.AzureSchemaNamespace)]
    internal class ServiceCertificateData : AzureDataContractBase
    {
        private ServiceCertificateData() { }

        [DataMember(Name = "Data", IsRequired = true)]
        private string _certData;

        internal X509Certificate2 Certificate { get; private set; }

        [OnDeserialized]
        private void DeserializeCert(StreamingContext context)
        {
            byte[] certBytes = Convert.FromBase64String(_certData);

            this.Certificate = new X509Certificate2(certBytes);
        }
    }
}
