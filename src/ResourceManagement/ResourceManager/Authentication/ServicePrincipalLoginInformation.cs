// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace Microsoft.Azure.Management.ResourceManager.Fluent.Authentication
{
    public class ServicePrincipalLoginInformation
    {
        public string ClientId { get; set; }

        public string ClientSecret { get; set; }

        public byte[] Certificate { get; set; }

        public string CertificatePassword { get; set; }
    }
}
