// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core;
using Azure.Identity;
using System.Security.Cryptography.X509Certificates;

namespace Azure.ResourceManager.EdgeOrder.Customizations.Models
{
    internal static partial class SiteKeyContent
    {
        internal static TokenCredential GenerateTokenCredential(this SiteKey siteKey)
        {
            var options = new ClientCertificateCredentialOptions
            {
                AuthorityHost = new Uri(siteKey.AadEndpoint),
                SendCertificateChain = true,
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

            armClientOptions.Environment = new ArmEnvironment(new Uri(siteKey.ArmEndPoint), siteKey.ArmEndPoint);

            return new ArmClient(credential: siteKey.GenerateTokenCredential(),
                                defaultSubscriptionId: new ResourceIdentifier(siteKey.ResourceId).SubscriptionId,
                                options: armClientOptions);
        }
    }
}
