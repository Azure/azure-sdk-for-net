// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Identity;
using System.Text.Json;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.ConstrainedExecution;
using System.Net.Sockets;
using Microsoft.Azure.Management.ResourceManager.Fluent;

namespace Azure.ResourceManager.EdgeOrder.Customizations.Models
{
    internal static partial class SiteKeyContent
    {

        internal static TokenCredential GenerateTokenCredential(this SiteKey siteKey)
        {
            var options = new TokenCredentialOptions
            {
                AuthorityHost = new Uri(siteKey.AadEndpoint),
            };
            return new ClientCertificateCredential(tenantId: siteKey.TenantId,
                clientId: siteKey.ClientId,
                clientCertificate: new X509Certificate2(Convert.FromBase64String(siteKey.ClientSecret)),
                options: options);
        }

        internal static ArmClient CreateArmClient(this SiteKey siteKey, ArmClientOptions armClientOptions)
        {
            if (armClientOptions == null)
            {
                armClientOptions = new ArmClientOptions();
            }

            armClientOptions.Environment = new ArmEnvironment(new Uri(siteKey.ArmEndPoint), siteKey.AadEndpoint);

            return new ArmClient(credential: siteKey.GenerateTokenCredential(),
                                defaultSubscriptionId: default,
                                options: armClientOptions);
        }
    }
}
