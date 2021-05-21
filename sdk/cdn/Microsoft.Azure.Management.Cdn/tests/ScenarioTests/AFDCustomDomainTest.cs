// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System.Collections.Generic;
using System.Net;
using Cdn.Tests.Helpers;
using Microsoft.Azure.Management.Cdn;
using Microsoft.Azure.Management.Cdn.Models;
using Microsoft.Azure.Management.Resources;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;

namespace Cdn.Tests.ScenarioTests
{
    public class AFDCustomDomainTest
    {
        [Fact]
        public void AFDCustomDomainCreateTest()
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

                    // Create a standard Azure frontdoor profile customDomain
                    string customDomainName = TestUtilities.GenerateName("customDomainName");
                    var hostName = "csharpsdk.dev.cdn.azure.cn";
                    AFDDomain afdDomainCreateParameters = new AFDDomain()
                    {
                        HostName = hostName,
                        TlsSettings = new AFDDomainHttpsParameters
                        {
                            CertificateType = "CustomerCertificate",
                            MinimumTlsVersion = AfdMinimumTlsVersion.TLS12,
                            Secret = new ResourceReference(secret.Id)
                        },
                    };

                    //Need manualy add dns txt record
                    var afdDomain = cdnMgmtClient.AFDCustomDomains.Create(resourceGroupName, profileName, customDomainName, afdDomainCreateParameters);
                    Assert.NotNull(afdDomain);
                    Assert.Equal("Approved", afdDomain.DomainValidationState);
                }
                finally
                {
                    // Delete resource group
                    _ = CdnTestUtilities.DeleteResourceGroupAsync(resourcesClient, resourceGroupName);
                }
            }
        }

        [Fact]
        public void AFDCustomDomainUpdateTest()
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

                    // Create a standard Azure frontdoor profile customDomain
                    string customDomainName = TestUtilities.GenerateName("customDomainName");
                    var hostName = "csharpsdk.dev.cdn.azure.cn";
                    AFDDomain afdDomainCreateParameters = new AFDDomain()
                    {
                        HostName = hostName,
                        TlsSettings = new AFDDomainHttpsParameters
                        {
                            CertificateType = "CustomerCertificate",
                            MinimumTlsVersion = AfdMinimumTlsVersion.TLS12,
                            Secret = new ResourceReference(secret.Id)
                        },
                    };

                    //Need manualy add dns txt record
                    var afdDomain = cdnMgmtClient.AFDCustomDomains.Create(resourceGroupName, profileName, customDomainName, afdDomainCreateParameters);
                    Assert.NotNull(afdDomain);
                    Assert.Equal("Approved", afdDomain.DomainValidationState);

                    var updateTlsSettingsParams = new AFDDomainHttpsParameters
                    {
                        CertificateType = "CustomerCertificate",
                        MinimumTlsVersion = AfdMinimumTlsVersion.TLS10,
                        Secret = new ResourceReference(secret.Id)
                    };
                    var updatedAfdDomain = cdnMgmtClient.AFDCustomDomains.Update(resourceGroupName, profileName, customDomainName, updateTlsSettingsParams);
                    Assert.NotNull(updateTlsSettingsParams);
                    Assert.Equal("Approved", updatedAfdDomain.DomainValidationState);
                    Assert.Equal(updateTlsSettingsParams.MinimumTlsVersion, updatedAfdDomain.TlsSettings.MinimumTlsVersion);
                }
                finally
                {
                    // Delete resource group
                    _ = CdnTestUtilities.DeleteResourceGroupAsync(resourcesClient, resourceGroupName);
                }
            }
        }

        [Fact]
        public void AFDCustomDomainDeleteTest()
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

                    // Create a standard Azure frontdoor profile customDomain
                    string customDomainName = TestUtilities.GenerateName("customDomainName");
                    var hostName = "csharpsdk.dev.cdn.azure.cn";
                    AFDDomain afdDomainCreateParameters = new AFDDomain()
                    {
                        HostName = hostName,
                        TlsSettings = new AFDDomainHttpsParameters
                        {
                            CertificateType = "CustomerCertificate",
                            MinimumTlsVersion = AfdMinimumTlsVersion.TLS12,
                            Secret = new ResourceReference(secret.Id)
                        },
                    };

                    //Need manualy add dns txt record
                    var afdDomain = cdnMgmtClient.AFDCustomDomains.Create(resourceGroupName, profileName, customDomainName, afdDomainCreateParameters);
                    cdnMgmtClient.AFDCustomDomains.Delete(resourceGroupName, profileName, customDomainName);
                }
                finally
                {
                    // Delete resource group
                    _ = CdnTestUtilities.DeleteResourceGroupAsync(resourcesClient, resourceGroupName);
                }
            }
        }

        [Fact]
        public void AFDCustomDomainGetListTest()
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

                    // Create a standard Azure frontdoor profile customDomain
                    string customDomainName = TestUtilities.GenerateName("customDomainName");
                    var hostName = "csharpsdk.dev.cdn.azure.cn";
                    AFDDomain afdDomainCreateParameters = new AFDDomain()
                    {
                        HostName = hostName,
                        TlsSettings = new AFDDomainHttpsParameters
                        {
                            CertificateType = "CustomerCertificate",
                            MinimumTlsVersion = AfdMinimumTlsVersion.TLS12,
                            Secret = new ResourceReference(secret.Id)
                        },
                    };

                    //Need manualy add dns txt record
                    var afdDomain = cdnMgmtClient.AFDCustomDomains.Create(resourceGroupName, profileName, customDomainName, afdDomainCreateParameters);

                    var getAfdDomain = cdnMgmtClient.AFDCustomDomains.Get(resourceGroupName, profileName, customDomainName);
                    Assert.NotNull(getAfdDomain);
                    Assert.Equal("Approved", getAfdDomain.DomainValidationState);

                    var listAfdDomains = cdnMgmtClient.AFDCustomDomains.ListByProfile(resourceGroupName, profileName);
                    Assert.Single(listAfdDomains);

                    cdnMgmtClient.AFDCustomDomains.Delete(resourceGroupName, profileName, customDomainName);
                    listAfdDomains = cdnMgmtClient.AFDCustomDomains.ListByProfile(resourceGroupName, profileName);
                    Assert.Empty(listAfdDomains);
                }
                finally
                {
                    // Delete resource group
                    _ = CdnTestUtilities.DeleteResourceGroupAsync(resourcesClient, resourceGroupName);
                }
            }
        }

        [Fact]
        public void AFDCustomDomainRefreshValidationTokenTest()
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

                    // Create a standard Azure frontdoor profile customDomain
                    string customDomainName = TestUtilities.GenerateName("customDomainName");
                    var hostName = "csharpsdk.dev.cdn.azure.cn";
                    AFDDomain afdDomainCreateParameters = new AFDDomain()
                    {
                        HostName = hostName,
                        TlsSettings = new AFDDomainHttpsParameters
                        {
                            CertificateType = "CustomerCertificate",
                            MinimumTlsVersion = AfdMinimumTlsVersion.TLS12,
                            Secret = new ResourceReference(secret.Id)
                        },
                    };

                    //Need manualy add dns txt record
                    var afdDomain = cdnMgmtClient.AFDCustomDomains.Create(resourceGroupName, profileName, customDomainName, afdDomainCreateParameters);

                    Assert.ThrowsAny<AfdErrorResponseException>(() =>
                    {
                        // Current DNS Txt RecordValidation has not expired yet
                        var validationTokenResult = cdnMgmtClient.AFDCustomDomains.RefreshValidationToken(resourceGroupName, profileName, customDomainName);
                    });
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
