// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Linq;
using System.Net;
using Cdn.Tests.Helpers;
using Microsoft.Azure.Management.Cdn;
using Microsoft.Azure.Management.Cdn.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Cdn.Tests.ScenarioTests
{
    public class AFDSecretTest
    {
        [Fact]
        public void AFDSecretCreateTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create clients
                var cdnMgmtClient = CdnTestUtilities.GetCdnManagementClient(context, handler1);
                var resourcesClient = CdnTestUtilities.GetResourceManagementClient(context, handler2);

                // Create resource group
                var resourceGroupName = CdnTestUtilities.CreateResourceGroup(resourcesClient);

                try
                {
                    // Create a standard Azure frontdoor profile
                    string profileName = TestUtilities.GenerateName("profile");
                    Profile createParameters = new Profile
                    {
                        Location = "WestUs",
                        Sku = new Sku { Name = SkuName.StandardAzureFrontDoor },
                        Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                    };
                    var profile = cdnMgmtClient.Profiles.Create(resourceGroupName, profileName, createParameters);

                    // Create a standard Azure frontdoor profile secret
                    string secretName = TestUtilities.GenerateName("secretName");
                    var secretSource = new ResourceReference("/subscriptions/d7cfdb98-c118-458d-8bdf-246be66b1f5e/resourceGroups/cdn-powershell-test/providers/Microsoft.KeyVault/vaults/cdn-powershell-test-kv/certificates/cdn-powershell-test-cer");
                    CustomerCertificateParameters parameters = new CustomerCertificateParameters(secretSource)
                    {
                        UseLatestVersion = true,
                        SubjectAlternativeNames = new List<string>(),
                    };

                    var secret = cdnMgmtClient.Secrets.Create(resourceGroupName, profileName, secretName, parameters);
                    Assert.NotNull(secret);
                    Assert.Equal(secretName, secret.Name);
                }
                finally
                {
                    // Delete resource group
                    _ = CdnTestUtilities.DeleteResourceGroupAsync(resourcesClient, resourceGroupName);
                }
            }
        }

     
        [Fact(Skip = "Not supported patch now 01/20/2020")]
        public void AFDSecretUpdateTest()
        {
            
        }
        

        [Fact]
        public void AFDSecretDeleteTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create clients
                var cdnMgmtClient = CdnTestUtilities.GetCdnManagementClient(context, handler1);
                var resourcesClient = CdnTestUtilities.GetResourceManagementClient(context, handler2);

                // Create resource group
                var resourceGroupName = CdnTestUtilities.CreateResourceGroup(resourcesClient);

                try
                {
                    // Create a standard Azure frontdoor profile
                    string profileName = TestUtilities.GenerateName("profile");
                    Profile createParameters = new Profile
                    {
                        Location = "WestUs",
                        Sku = new Sku { Name = SkuName.StandardAzureFrontDoor },
                        Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                    };
                    var profile = cdnMgmtClient.Profiles.Create(resourceGroupName, profileName, createParameters);

                    // Create a standard Azure frontdoor profile
                    string secretName = TestUtilities.GenerateName("secretName");
                    var secretSource = new ResourceReference("/subscriptions/d7cfdb98-c118-458d-8bdf-246be66b1f5e/resourceGroups/cdn-powershell-test/providers/Microsoft.KeyVault/vaults/cdn-powershell-test-kv/certificates/cdn-powershell-test-cer");
                    CustomerCertificateParameters parameters = new CustomerCertificateParameters(secretSource)
                    {
                        UseLatestVersion = true,
                        SubjectAlternativeNames = new List<string>(),
                    };


                    var secret = cdnMgmtClient.Secrets.Create(resourceGroupName, profileName, secretName, parameters);
                    cdnMgmtClient.Secrets.Delete(resourceGroupName, profileName, secretName);
                }
                finally
                {
                    // Delete resource group
                    _ = CdnTestUtilities.DeleteResourceGroupAsync(resourcesClient, resourceGroupName);
                }
            }
        }

        [Fact]
        public void AFDSecretGetListTest()
        {
            var handler1 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            var handler2 = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType()))
            {
                // Create clients
                var cdnMgmtClient = CdnTestUtilities.GetCdnManagementClient(context, handler1);
                var resourcesClient = CdnTestUtilities.GetResourceManagementClient(context, handler2);

                // Create resource group
                var resourceGroupName = CdnTestUtilities.CreateResourceGroup(resourcesClient);

                try
                {
                    // Create a standard Azure frontdoor profile
                    string profileName = TestUtilities.GenerateName("profile");
                    Profile createParameters = new Profile
                    {
                        Location = "WestUs",
                        Sku = new Sku { Name = SkuName.StandardAzureFrontDoor },
                        Tags = new Dictionary<string, string>
                        {
                            {"key1","value1"},
                            {"key2","value2"}
                        }
                    };
                    var profile = cdnMgmtClient.Profiles.Create(resourceGroupName, profileName, createParameters);

                    // Create a standard Azure frontdoor profile
                    string secretName = TestUtilities.GenerateName("secretName");
                    var secretSource = new ResourceReference("/subscriptions/d7cfdb98-c118-458d-8bdf-246be66b1f5e/resourceGroups/cdn-powershell-test/providers/Microsoft.KeyVault/vaults/cdn-powershell-test-kv/certificates/cdn-powershell-test-cer");
                    CustomerCertificateParameters parameters = new CustomerCertificateParameters(secretSource)
                    {
                        UseLatestVersion = true,
                        SubjectAlternativeNames = new List<string>(),
                    };

                    var secret = cdnMgmtClient.Secrets.Create(resourceGroupName, profileName, secretName, parameters);
                    Assert.NotNull(secret);
                    Assert.Equal(secretName, secret.Name);

                    var getSecret = cdnMgmtClient.Secrets.Get(resourceGroupName, profileName, secretName);
                    Assert.NotNull(getSecret);
                    Assert.Equal(secretName, getSecret.Name);

                    var listSecrets = cdnMgmtClient.Secrets.ListByProfile(resourceGroupName, profileName);
                    Assert.NotNull(listSecrets);
                    Assert.Single(listSecrets);

                    string secretName2 = TestUtilities.GenerateName("secretName");
                    var secrets = cdnMgmtClient.Secrets.Create(resourceGroupName, profileName, secretName2, parameters);

                    listSecrets = cdnMgmtClient.Secrets.ListByProfile(resourceGroupName, profileName);
                    Assert.NotNull(listSecrets);
                    Assert.Equal(2, listSecrets.Count());
                }
                finally
                {
                    // Delete resource group
                    _ = CdnTestUtilities.DeleteResourceGroupAsync(resourcesClient, resourceGroupName);
                }
            }
        }
    }
}
