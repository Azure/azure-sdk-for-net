// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using Microsoft.Azure.Management.Batch;
using Microsoft.Azure.Management.Batch.Models;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Xunit;


namespace Batch.Tests.ScenarioTests
{
    public class AccountTests : BatchScenarioTestBase
    {
        [Fact]
        public async Task BatchAccountEndToEndAsync()
        {
            using (MockContext context = StartMockContextAndInitializeClients(GetType()))
            {
                string resourceGroupName = TestUtilities.GenerateName();
                string batchAccountName = TestUtilities.GenerateName();
                ResourceGroup group = new ResourceGroup(Location);
                await ResourceManagementClient.ResourceGroups.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, group);

                try
                {
                    // Check if the account exists
                    var checkAvailabilityResult = await BatchManagementClient.Location.CheckNameAvailabilityAsync(Location, batchAccountName);
                    Assert.True(checkAvailabilityResult.NameAvailable);

                    // Create an account
                    BatchAccountCreateParameters createParams = new BatchAccountCreateParameters(Location);
                    AuthenticationMode authMode = AuthenticationMode.SharedKey;
                    createParams.AllowedAuthenticationModes = new List<AuthenticationMode?> { authMode };
                    await BatchManagementClient.BatchAccount.CreateAsync(resourceGroupName, batchAccountName, createParams);

                    // Check if the account exists now
                    checkAvailabilityResult = await BatchManagementClient.Location.CheckNameAvailabilityAsync(Location, batchAccountName);
                    Assert.False(checkAvailabilityResult.NameAvailable);
                    Assert.NotNull(checkAvailabilityResult.Message);
                    Assert.NotNull(checkAvailabilityResult.Reason);

                    // Get the account and verify some properties
                    BatchAccount batchAccount = await BatchManagementClient.BatchAccount.GetAsync(resourceGroupName, batchAccountName);
                    Assert.Equal(batchAccountName, batchAccount.Name);
                    Assert.True(batchAccount.DedicatedCoreQuota > 0);
                    Assert.True(batchAccount.LowPriorityCoreQuota > 0);
                    Assert.True(batchAccount.AllowedAuthenticationModes.Single() == authMode);

                    // Rotate a key
                    BatchAccountKeys originalKeys = await BatchManagementClient.BatchAccount.GetKeysAsync(resourceGroupName, batchAccountName);
                    BatchAccountKeys newKeys = await BatchManagementClient.BatchAccount.RegenerateKeyAsync(resourceGroupName, batchAccountName, AccountKeyType.Primary);
                    Assert.NotEqual(originalKeys.Primary, newKeys.Primary);
                    Assert.Equal(originalKeys.Secondary, newKeys.Secondary);

                    // List accounts under the resource group
                    IPage<BatchAccount> listResponse = await BatchManagementClient.BatchAccount.ListByResourceGroupAsync(resourceGroupName);
                    List<BatchAccount> accounts = new List<BatchAccount>(listResponse);
                    string nextLink = listResponse.NextPageLink;
                    while (nextLink != null)
                    {
                        listResponse = await BatchManagementClient.BatchAccount.ListByResourceGroupNextAsync(nextLink);
                        accounts.AddRange(listResponse);
                        nextLink = listResponse.NextPageLink;
                    }

                    Assert.Single(accounts);
                    Assert.Equal(batchAccountName, accounts.First().Name);

                    IPage<OutboundEnvironmentEndpoint> endpointsResponse = await BatchManagementClient.BatchAccount.ListOutboundNetworkDependenciesEndpointsAsync(resourceGroupName, batchAccount.Name);
                    List<OutboundEnvironmentEndpoint> endpoints = new List<OutboundEnvironmentEndpoint>();

                    do
                    {
                        endpointsResponse = await BatchManagementClient.BatchAccount.ListOutboundNetworkDependenciesEndpointsAsync(resourceGroupName, batchAccount.Name);
                        endpoints.AddRange(endpointsResponse);
                        nextLink = endpointsResponse.NextPageLink;
                    }
                    while (nextLink != null);

                    Assert.NotEmpty(endpoints);
                    Assert.True(endpoints.First().Endpoints.Count() > 0);

                    // Delete the account
                    try
                    {
                        await BatchManagementClient.BatchAccount.DeleteAsync(resourceGroupName, batchAccountName);
                    }
                    catch (CloudException ex)
                    {
                        /*  Account deletion is a long running operation. This .DeleteAsync() method will submit the account deletion request and
                         *  poll for the status of the long running operation until the account is deleted. Currently, querying for the operation
                         *  status after the account is deleted will return a 404 error, so we have to add this catch statement. This behavior will
                         *  be fixed in a future service release.
                         */
                        if (ex.Response.StatusCode != HttpStatusCode.NotFound)
                        {
                            throw;
                        }
                    }
                    // Verify account was deleted. A GET operation will return a 404 error and result in an exception
                    try
                    {
                        await BatchManagementClient.BatchAccount.GetAsync(resourceGroupName, batchAccountName);
                    }
                    catch (CloudException ex)
                    {
                        Assert.Equal(HttpStatusCode.NotFound, ex.Response.StatusCode);
                    }
                }
                finally
                {
                    await ResourceManagementClient.ResourceGroups.DeleteWithHttpMessagesAsync(resourceGroupName);
                }
            }
        }

        [Fact]
        public async Task BatchAccountCanCreateWithBYOSEnabled()
        {
            using (MockContext context = StartMockContextAndInitializeClients(GetType()))
            {
                string resourceGroupName = TestUtilities.GenerateName();
                string batchAccountName = TestUtilities.GenerateName();
                string keyvaultName = TestUtilities.GenerateName();
                ResourceGroup group = new ResourceGroup(Location);
                await ResourceManagementClient.ResourceGroups.CreateOrUpdateWithHttpMessagesAsync(resourceGroupName, group);

                try
                {
                    //Register with keyvault just in case we haven't already
                    await ResourceManagementClient.Providers.RegisterWithHttpMessagesAsync("Microsoft.KeyVault");

                    var result = await ResourceManagementClient.Resources.CreateOrUpdateWithHttpMessagesAsync(
                        resourceGroupName: resourceGroupName,
                        resourceProviderNamespace: "Microsoft.KeyVault",
                        parentResourcePath: "",
                        resourceType: "vaults",
                        resourceName: keyvaultName,
                        apiVersion: "2016-10-01",
                        parameters: new GenericResource()
                        {
                            Location = Location,
                            Properties = new Dictionary<string, object>
                            {
                                {"tenantId", "72f988bf-86f1-41af-91ab-2d7cd011db47"},
                                {"sku", new Dictionary<string, object>{{"family", "A"}, {"name", "standard"}}},
                                {"accessPolicies", new []
                                    {
                                        new Dictionary<string, object>
                                        {
                                            {"objectId", "f520d84c-3fd3-4cc8-88d4-2ed25b00d27a"},
                                            {"tenantId", "72f988bf-86f1-41af-91ab-2d7cd011db47"},
                                            {"permissions", new Dictionary<string, object>
                                                {
                                                    {"secrets", new [] { "All" }},
                                                    {"keys", new [] { "All" }},
                                                }
                                            }
                                        }
                                    }
                                },
                                {"enabledForDeployment", true},
                                {"enabledForTemplateDeployment", true},
                                {"enabledForDiskEncryption", true}
                            }
                        });

                    var keyVaultReferenceId =
                        $"/subscriptions/{BatchManagementClient.SubscriptionId}/resourceGroups/{resourceGroupName}/providers/Microsoft.KeyVault/vaults/{keyvaultName}";
                    var keyVaultReferenceUrl = ((Newtonsoft.Json.Linq.JObject)result.Body.Properties)["vaultUri"].ToString();
                    // Create an account
                    BatchAccountCreateParameters createParams = new BatchAccountCreateParameters(
                        Location,
                        poolAllocationMode: PoolAllocationMode.UserSubscription,
                        keyVaultReference: new KeyVaultReference(
                            keyVaultReferenceId,
                            keyVaultReferenceUrl));

                    await BatchManagementClient.BatchAccount.CreateAsync(resourceGroupName, batchAccountName, createParams);

                    // Get the account and verify some properties
                    BatchAccount batchAccount = await BatchManagementClient.BatchAccount.GetAsync(resourceGroupName, batchAccountName);
                    Assert.Equal(batchAccountName, batchAccount.Name);
                    Assert.Null(batchAccount.DedicatedCoreQuota);
                    Assert.Null(batchAccount.DedicatedCoreQuotaPerVMFamily);
                    Assert.True(batchAccount.DedicatedCoreQuotaPerVMFamilyEnforced);
                    Assert.Null(batchAccount.LowPriorityCoreQuota);
                    Assert.Equal(PoolAllocationMode.UserSubscription, batchAccount.PoolAllocationMode);
                    Assert.Equal(keyVaultReferenceId, batchAccount.KeyVaultReference.Id);
                    Assert.Equal(keyVaultReferenceUrl, batchAccount.KeyVaultReference.Url);
                }
                finally
                {
                    await ResourceManagementClient.ResourceGroups.DeleteWithHttpMessagesAsync(resourceGroupName);
                }
            }
        }
    }
}
