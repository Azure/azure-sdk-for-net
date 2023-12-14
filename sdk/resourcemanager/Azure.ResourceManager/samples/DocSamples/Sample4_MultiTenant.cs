// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:MultiTenant_Namespaces
using System;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
#endregion
using NUnit.Framework;

namespace Azure.ResourceManager.Tests.Samples
{
    public class Sample4_MultiTenant
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task EnableCrossTenantAuthentication()
        {
            #region Snippet:Enable_Cross_Tenant_Authentication
            string clientId = Environment.GetEnvironmentVariable("CLIENT_ID");
            string clientSecret = Environment.GetEnvironmentVariable("CLIENT_SECRET");
            string tenantId01 = Environment.GetEnvironmentVariable("TENANT_ID_01");
            string tenantId02 = Environment.GetEnvironmentVariable("TENANT_ID_02");
            string subscriptionId01 = Environment.GetEnvironmentVariable("SUBSCRIPTION_ID_01");

            // Prepare client and policy for tenant01
            TokenCredential credForTenant01 = new ClientSecretCredential(tenantId01, clientId, clientSecret);
            TokenCredential credForTenant02 = new ClientSecretCredential(tenantId02, clientId, clientSecret);

            string token = (await credForTenant02.GetTokenAsync(new TokenRequestContext(
                    new[] { ArmEnvironment.AzurePublicCloud.DefaultScope }), CancellationToken.None)).Token;
            ArmClientOptions options = new ArmClientOptions();
            AuxiliaryPoilcy headerPolicy = new AuxiliaryPoilcy(token);
            options.AddPolicy(headerPolicy, HttpPipelinePosition.PerCall);
            ArmClient client = new ArmClient(credForTenant01, subscriptionId01, options);
            #endregion
        }
    }
}
