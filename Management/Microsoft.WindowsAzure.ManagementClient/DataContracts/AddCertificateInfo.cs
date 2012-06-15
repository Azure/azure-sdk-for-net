//-----------------------------------------------------------------------
// <copyright file="AddServiceCertificateInfo.cs" company="Microsoft">
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
//    Contains code for the AddServiceCertificateInfo class.
// </summary>
//-----------------------------------------------------------------------

using System;
using System.Runtime.Serialization;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.WindowsAzure.ManagementClient.v1_7
{
    [DataContract(Name = "CertificateFile", Namespace = AzureConstants.AzureSchemaNamespace)]
    internal class AddServiceCertificateInfo : AzureDataContractBase
    {
        private const string certFormat = "pfx"; //only accepted value
        private AddServiceCertificateInfo() { }

        //TODO: Password is SecureString?
        internal static AddServiceCertificateInfo Create(X509Certificate2 certificate, string password)
        {
            Validation.NotNull(certificate, "certificate");
            //password might be null...

            if (certificate.HasPrivateKey == false) throw new ArgumentException(Resources.CertificateNoPrivateKey);

            byte[] certData = certificate.Export(X509ContentType.Pfx, password);

            string data = Convert.ToBase64String(certData);

            return new AddServiceCertificateInfo
            {
                Data = data,
                CertificateFormat = certFormat,
                Password = password
            };
        }

        [DataMember(Order = 0, IsRequired = true)]
        internal string Data { get; private set; }

        [DataMember(Order = 1, IsRequired = true)]
        internal string CertificateFormat { get; private set; }

        [DataMember(Order = 2, IsRequired = false, EmitDefaultValue = true)]
        internal string Password { get; private set; }
    }
}
