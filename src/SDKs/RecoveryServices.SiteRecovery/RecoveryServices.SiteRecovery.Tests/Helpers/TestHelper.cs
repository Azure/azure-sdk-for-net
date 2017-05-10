// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using Microsoft.Azure.Management.RecoveryServices;
using Microsoft.Azure.Management.RecoveryServices.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Resources.Models;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery;
using Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Microsoft.Azure.Management.RecoveryServices.SiteRecovery.Tests
{
    public class TestHelper: IDisposable
    {
        private const string resourceNamespace = "Microsoft.RecoveryServices";
        private const string resourceGroupName = "resourceGroupPS1";
        private const string vaultName = "vault1";
        private const string location = "southeastasia";
        private const string fabricName = "Azure";

        public RecoveryServicesClient VaultClient { get; private set; }

        public SiteRecoveryManagementClient SiteRecoveryClient { get; private set; }

        public void Initialize(MockContext context)
        {
            VaultClient = this.GetVaultClient(context);

            this.SiteRecoveryClient = this.GetSiteRecoveryClient(context);
            this.SiteRecoveryClient.ResourceGroupName = resourceGroupName;
            this.SiteRecoveryClient.ResourceName = vaultName;
        }

        public void CreateResourceGroup(MockContext context)
        {
            ResourceManagementClient resourcesClient = this.GetResourcesClient(context);

            try
            {
                resourcesClient.ResourceGroups.CreateOrUpdate(resourceGroupName,
                new ResourceGroup
                {
                    Location = location
                });

                var response = resourcesClient.ResourceGroups.Get(resourceGroupName);
                Assert.True(response.Name == resourceGroupName, "Resource groups cannot be different");
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode != System.Net.HttpStatusCode.Conflict) throw;
            }
        }

        public void CreateVault(MockContext context)
        {
            Vault vault = new Vault()
            {
                Location = location,
                Sku = new Sku()
                {
                    Name = SkuName.Standard
                },
                Properties = new VaultProperties()
            };

            try
            {
                VaultClient.Vaults.CreateOrUpdate(resourceGroupName, vaultName, vault);
            }
            catch (CloudException ex)
            {
                if (ex.Response.StatusCode != System.Net.HttpStatusCode.Conflict) throw;
            }
        }

        public void DisposeVaults()
        {
            var vaults = VaultClient.Vaults.ListByResourceGroup(resourceGroupName);
            foreach (var vault in vaults)
            {
                VaultClient.Vaults.Delete(resourceGroupName, vault.Name);
            }
        }

        public void WaitForJobCompletion(string jobId)
        {
            string jobStatus = string.Empty;

            RetryActionWithTimeout(
                () => jobStatus = GetJobStatus(jobId),
                () => !IsJobInProgress(jobStatus),
                TimeSpan.FromHours(3),
                statusCode =>
                {
                    TestUtilities.Wait(5000);
                    return true;
                });
        }

        public string GetJobStatus(string jobId)
        {
            return "Completed";
        }

        public bool IsJobInProgress(string jobStatus)
        {
            return jobStatus.CompareTo("InProgress") == 0 || jobStatus.CompareTo("Cancelling") == 0;
        }

        public void RetryActionWithTimeout(Action action, Func<bool> validator, TimeSpan timeout, Func<System.Net.HttpStatusCode, bool> shouldRetry)
        {
            DateTime timedOut = DateTime.Now + timeout;
            do
            {
                try
                {
                    action();
                }
                catch (CloudException exception)
                {
                    if (!shouldRetry(exception.Response.StatusCode))
                    {
                        throw;
                    }
                }
            }

            while (DateTime.Now < timedOut && !validator());
        }

        private void ValidateOperationResponse(AzureOperationResponse response)
        {
            Assert.NotNull(response);
            Assert.Equal(System.Net.HttpStatusCode.Accepted, response.Response.StatusCode);
            Assert.True(response.Response.Headers.Contains("Location"));
            Assert.True(response.Response.Headers.Contains("Azure-AsyncOperation"));
            Assert.True(response.Response.Headers.Contains("Retry-After"));
        }

        public void Dispose()
        {
            SiteRecoveryClient.Dispose();
            VaultClient.Dispose();
        }
    }
}