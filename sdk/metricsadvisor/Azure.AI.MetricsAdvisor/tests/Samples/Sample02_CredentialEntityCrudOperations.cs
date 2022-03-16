// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.MetricsAdvisor.Administration;
using Azure.AI.MetricsAdvisor.Models;
using Azure.AI.MetricsAdvisor.Tests;
using NUnit.Framework;

namespace Azure.AI.MetricsAdvisor.Samples
{
    public partial class MetricsAdvisorSamples : MetricsAdvisorTestEnvironment
    {
        [Test]
        public async Task CreateAndDeleteDataSourceCredentialAsync()
        {
            string endpoint = MetricsAdvisorUri;
            string subscriptionKey = MetricsAdvisorSubscriptionKey;
            string apiKey = MetricsAdvisorApiKey;
            var credential = new MetricsAdvisorKeyCredential(subscriptionKey, apiKey);

            var adminClient = new MetricsAdvisorAdministrationClient(new Uri(endpoint), credential);

            #region Snippet:CreateDataSourceCredentialAsync
#if SNIPPET
            string credentialName = "<credentialName>";
#else
            string credentialName = GetUniqueName();
#endif

            var credentialEntity = new ServicePrincipalCredentialEntity(credentialName, "<clientId>", "<clientSecret>", "<tenantId>");

            Response<DataSourceCredentialEntity> response = await adminClient.CreateDataSourceCredentialAsync(credentialEntity);

            DataSourceCredentialEntity createdCredentialEntity = response.Value;

            Console.WriteLine($"Credential entity ID: {createdCredentialEntity.Id}");
            #endregion

            // Delete the created credential to clean up the Metrics Advisor resource. Do not perform this
            // step if you intend to keep using the credential.

            await adminClient.DeleteDataSourceCredentialAsync(createdCredentialEntity.Id);
        }

        [Test]
        public async Task GetDataSourceCredentialAsync()
        {
            string endpoint = MetricsAdvisorUri;
            string subscriptionKey = MetricsAdvisorSubscriptionKey;
            string apiKey = MetricsAdvisorApiKey;
            var credential = new MetricsAdvisorKeyCredential(subscriptionKey, apiKey);

            var adminClient = new MetricsAdvisorAdministrationClient(new Uri(endpoint), credential);

            string credentialEntityId = CredentialEntityId;

            Response<DataSourceCredentialEntity> response = await adminClient.GetDataSourceCredentialAsync(credentialEntityId);

            DataSourceCredentialEntity credentialEntity = response.Value;

            Console.WriteLine($"Credential name: {credentialEntity.Name}");
            Console.WriteLine($"Credential description: {credentialEntity.Description}");

            // You can access specific properties of your credential entity depending on its kind.

            if (credentialEntity.CredentialKind == DataSourceCredentialKind.ServicePrincipal)
            {
                Console.WriteLine("Credential of kind Service Principal:");

                var servicePrincipalEntity = credentialEntity as ServicePrincipalCredentialEntity;

                Console.WriteLine($"  Client ID: {servicePrincipalEntity.ClientId}");
                Console.WriteLine($"  Tenant ID: {servicePrincipalEntity.TenantId}");
            }
            else if (credentialEntity.CredentialKind == DataSourceCredentialKind.ServicePrincipalInKeyVault)
            {
                Console.WriteLine("Credential of kind Service Principal in Key Vault:");

                var servicePrincipalEntity = credentialEntity as ServicePrincipalInKeyVaultCredentialEntity;

                Console.WriteLine($"Name of secret for client ID: {servicePrincipalEntity.SecretNameForClientId}");
                Console.WriteLine($"Name of secret for client secret: {servicePrincipalEntity.SecretNameForClientSecret}");
            }
        }
    }
}
