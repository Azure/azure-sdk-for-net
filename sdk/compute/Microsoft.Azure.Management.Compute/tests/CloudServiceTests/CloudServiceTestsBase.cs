// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Azure.Management.Compute;
using Microsoft.Azure.Management.Compute.Models;
using Microsoft.Azure.Management.Network;
using Microsoft.Azure.Management.Network.Models;
using Microsoft.Azure.Management.ResourceManager;
using Microsoft.Azure.Management.ResourceManager.Models;
using Microsoft.Azure.Management.Storage.Models;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Xunit;
using CM = Microsoft.Azure.Management.Compute.Models;

namespace Compute.Tests
{
    public class CloudServiceTestsBase : VMTestBase, IDisposable


    {
        public string originalLocation;
        public const string MultiRole2Worker1WebRolesPackageSasUri = "TestCloudServiceMultiRole_WorkerRole1(Standard_D2_v2)(1)_WorkerRole2(Standard_D1_v2)(1)_WebRole1(Standard_A2_v2)(2).cspkg";
        public const string MultiRole1Worker1WebRolesPackageSasUri = "TestCloudServiceMultiRole_WorkerRole2(Standard_D2_v2)(1)_WebRole1(Standard_A2_v2)(1).cspkg";
        public const string WebRoleSasUri = "HelloWorldTest_WebRole_D2_V2.cspkg";
        public const string WorkerRoleWithInputEndpointSasUri = "HelloWorldWorker_Standard_D2_v2.cspkg";
        public const string RPType = "Microsoft.Compute/cloudServices";

        public CloudServiceTestsBase()
        {
            originalLocation = Environment.GetEnvironmentVariable("AZURE_VM_TEST_LOCATION");
            Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", "eastus2euap");
        }

        public void Dispose()
        {
            Environment.SetEnvironmentVariable("AZURE_VM_TEST_LOCATION", originalLocation);
        }
        public static Extension CreateExtension(string name, string publisher, string type, string version, string forceUpdateTag = null,
                                                                bool autoUpgrade = false, bool enableAutomaticUpgrade = false, string publicConfig = null, string privateConfig = null, List<string> roleAppliedTo = null)
        {
            return new Extension
            {
                Name = name,
                Properties = new CloudServiceExtensionProperties
                {
                    Publisher = publisher,
                    Type = type,
                    TypeHandlerVersion = version,
                    AutoUpgradeMinorVersion = autoUpgrade,
                    Settings = publicConfig,
                    ProtectedSettings = privateConfig,
                    RolesAppliedTo = roleAppliedTo,
                }
            };
        }

        public static Extension CreateRDPExtension(string name)
        {
            string rdpExtensionPublicConfig = "<PublicConfig>" +
                                                "<UserName>adminRdpTest</UserName>" +
                                                "<Expiration>2021-10-27T23:59:59</Expiration>" +
                                             "</PublicConfig>";
            string rdpExtensionPrivateConfig = "<PrivateConfig>" +
                                                  "<Password>VsmrdpTest!</Password>" +
                                               "</PrivateConfig>";

            return CreateExtension(name, "Microsoft.Windows.Azure.Extensions", "RDP", "1.2.1", autoUpgrade: true,
                                                                                              publicConfig: rdpExtensionPublicConfig,
                                                                                              privateConfig: rdpExtensionPrivateConfig);

        }

        protected string CreateCspkgSasUrl(string rgName, string fileName)
        {
            string storageAccountName = ComputeManagementTestUtilities.GenerateName("saforcspkg");
            string asName = ComputeManagementTestUtilities.GenerateName("asforcspkg");
            StorageAccount storageAccountOutput = CreateStorageAccount(rgName, storageAccountName); // resource group is also created in this method.
            string applicationMediaLink = @"https://saforcspkg1969.blob.core.windows.net/sascontainer/" + fileName;
            if (HttpMockServer.Mode == HttpRecorderMode.Record)
            {
                var accountKeyResult = m_SrpClient.StorageAccounts.ListKeysWithHttpMessagesAsync(rgName, storageAccountName).Result;
                CloudStorageAccount storageAccount = new CloudStorageAccount(new StorageCredentials(storageAccountName, accountKeyResult.Body.Key1), useHttps: true);

                var blobClient = storageAccount.CreateCloudBlobClient();
                CloudBlobContainer container = blobClient.GetContainerReference("sascontainer");
                container.CreateIfNotExistsAsync().Wait();

                CloudBlockBlob blockBlob = container.GetBlockBlobReference(fileName);
                blockBlob.UploadFromFileAsync(Path.Combine(Directory.GetCurrentDirectory(), "Resources", fileName)).Wait();

                SharedAccessBlobPolicy sasConstraints = new SharedAccessBlobPolicy();
                sasConstraints.SharedAccessStartTime = DateTime.UtcNow.AddDays(-1);
                sasConstraints.SharedAccessExpiryTime = DateTime.UtcNow.AddDays(2);
                sasConstraints.Permissions = SharedAccessBlobPermissions.Read | SharedAccessBlobPermissions.Write;

                //Generate the shared access signature on the blob, setting the constraints directly on the signature.
                string sasContainerToken = blockBlob.GetSharedAccessSignature(sasConstraints);

                //Return the URI string for the container, including the SAS token.
                applicationMediaLink = blockBlob.Uri + sasContainerToken;
            }
            return applicationMediaLink;
        }

        public CloudService CreateCloudService_NoAsyncTracking(
            string rgName,
            string csName,
            CloudService cloudService)
        {

            var createOrUpdateResponse = CreateCloudServiceGetOperationResponse(rgName,
                                                                                 csName,
                                                                                 cloudService);
            ValidateCloudService(cloudService, createOrUpdateResponse, rgName, csName);

            // Validate Get response
            var getResponse = m_CrpClient.CloudServices.Get(rgName, csName);
            ValidateCloudService(cloudService, getResponse, rgName, csName);

            return getResponse;

        }

        protected void UpdateCloudService(string rgName, string csName, CloudService cloudService)
        {
            var createOrUpdateResponse = m_CrpClient.CloudServices.CreateOrUpdate(rgName, csName, cloudService);
        }

        private CloudService CreateCloudServiceGetOperationResponse(
            string rgName,
            string csName,
            CloudService cloudService)
        {
            // Create the resource Group, it might have been already created during StorageAccount creation.
            var resourceGroup = m_ResourcesClient.ResourceGroups.CreateOrUpdate(
                rgName,
                new ResourceGroup
                {
                    Location = m_location
                });

            CloudService createOrUpdateResponse = m_CrpClient.CloudServices.CreateOrUpdate(rgName, csName, cloudService);

            Assert.True(createOrUpdateResponse.Name == csName);
            Assert.True(createOrUpdateResponse.Location.ToLower() == cloudService.Location.ToLower().Replace(" ", ""));

            return createOrUpdateResponse;
        }

        protected void ValidateCloudServiceInstanceView(CloudService cloudService,
            CloudServiceInstanceView cloudServiceInstanceView)
        {
            Assert.NotNull(cloudServiceInstanceView.Statuses);
            Assert.NotNull(cloudServiceInstanceView);
        }

        protected void ValidateCloudServiceNetworkProfile(CloudServiceNetworkProfile cloudService, CloudServiceNetworkProfile cloudServiceOut)
        {
            // Placeholder to validate NetworkProfile.
        }

        internal void VerifyExtensionsAreSame(IList<Extension> expectedExtensions, IList<Extension> actualExtensions, bool verifyRolesAppliedTo = false)
        {
            Assert.True(expectedExtensions.Count <= actualExtensions.Count, "Number of extensions should be match");
            Dictionary<string, Extension> expectedExtensionMap = expectedExtensions.ToDictionary(e => e.Name, e => e);
            HashSet<string> visitedExtension = new HashSet<string>();
            /*
            foreach (Extension actualExtension in actualExtensions)
            {
                Assert.True(visitedExtension.Add(actualExtension.Name), $"Found duplicate extension name {actualExtension.Name} in VSM which is not allowed");
                Assert.True(actualExtension.Properties.ProvisioningState == Microsoft.Azure.Management.Network.Models.ProvisioningState.Succeeded, "provisioningState should be match");
                Assert.True(expectedExtensionMap.ContainsKey(actualExtension.Name), $"Extension {actualExtension.Name} didn't exist in the expectedExtensionMap");
                Extension expectedExtension = expectedExtensionMap[actualExtension.Name];
                Assert.True(expectedExtension.Properties.AutoUpgradeMinorVersion == actualExtension.Properties.AutoUpgradeMinorVersion, "autoUpgradeMinorVersion setting should be same");
                Assert.True(expectedExtension.Properties.Publisher == actualExtension.Properties.Publisher, "publisher setting should be same");
                Assert.True(expectedExtension.Properties.Type == actualExtension.Properties.Type, "extension type should be same");

                if (verifyRolesAppliedTo)
                {
                    Assert.Equal(expectedExtension.Properties.RolesAppliedTo ?? new List<string>() { "*" }, actualExtension.Properties.RolesAppliedTo);
                }
            }*/
        }

        protected void ValidateCloudServiceRoleProfile(CloudServiceRoleProfile cloudServiceRoleProfile, CloudServiceRoleProfile returnedCloudServiceRoleProfile)
        {
            Assert.True(returnedCloudServiceRoleProfile.Roles.Count == cloudServiceRoleProfile.Roles.Count, "Role count must match in the Input Model and Returned Model");

            Dictionary<string, CloudServiceRoleSku> modelRolesToSkuMapping = new Dictionary<string, CloudServiceRoleSku>();
            foreach (var role in returnedCloudServiceRoleProfile.Roles)
            {
                modelRolesToSkuMapping.Add(role.Name, role.Sku);
            }

            foreach (var role in cloudServiceRoleProfile.Roles)
            {
                Assert.True(modelRolesToSkuMapping.ContainsKey(role.Name), "Returned Role should be present in Input Model Role");
                Assert.Equal(role.Sku.Name, modelRolesToSkuMapping[role.Name].Name, StringComparer.OrdinalIgnoreCase);
                Assert.Equal(role.Sku.Capacity, modelRolesToSkuMapping[role.Name].Capacity);
                modelRolesToSkuMapping.Remove(role.Name);
            }
        }

        protected void ValidateCloudService(CloudService cloudService, CloudService cloudServiceOut, string rgName, string csName)
        {
            Assert.Equal(cloudServiceOut.Type, string.Format("{0}/{1}", ApiConstants.ResourceProviderNamespace, ApiConstants.CloudServices));
            Assert.Equal(Helpers.GetCloudServiceReferenceId(m_subId, rgName, csName), cloudServiceOut.Id, StringComparer.OrdinalIgnoreCase);
            Assert.NotNull(cloudServiceOut.Properties);
            Assert.True(!string.IsNullOrEmpty(cloudServiceOut.Properties.ProvisioningState));
            Assert.Null(cloudServiceOut.Properties.PackageUrl);
            Assert.NotNull(cloudServiceOut.Properties.Configuration);
            Assert.NotNull(cloudServiceOut.Properties.UpgradeMode);

            if (cloudService.Properties.ExtensionProfile != null &&
                cloudService.Properties.ExtensionProfile.Extensions.Any())
            {
                foreach (var vmExtension in cloudService.Properties.ExtensionProfile.Extensions)
                {
                    var vmExt = cloudServiceOut.Properties.ExtensionProfile.Extensions.FirstOrDefault(s => String.Compare(s.Name, vmExtension.Name, StringComparison.OrdinalIgnoreCase) == 0);
                    Assert.NotNull(vmExt);
                }
            }

            if (cloudService.Properties.NetworkProfile != null)
            {
                ValidateCloudServiceNetworkProfile(cloudService.Properties.NetworkProfile, cloudServiceOut.Properties.NetworkProfile);
            }
            else
            {
                Assert.True((cloudServiceOut.Properties.NetworkProfile == null));
            }

            if (cloudService.Properties.RoleProfile != null)
            {
                ValidateCloudServiceRoleProfile(cloudService.Properties.RoleProfile, cloudServiceOut.Properties.RoleProfile);
            }
            else
            {
                Assert.True((cloudServiceOut.Properties.RoleProfile == null));
            }

            if (cloudService.Zones != null)
            {
                Assert.NotNull(cloudServiceOut.Zones);
                Assert.Equal(cloudServiceOut.Zones.Count, cloudServiceOut.Zones.Count);
                Assert.True(cloudService.Zones.All(cloudServiceOut.Zones.Contains));
            }
            else
            {
                Assert.Null(cloudServiceOut.Zones);
            }
        }

        protected VirtualNetwork CreateVirtualNetwork(string resourceGroupName, string vnetName, string subnetName)
        {
            try
            {
                // Create the resource Group.
                var resourceGroup = m_ResourcesClient.ResourceGroups.CreateOrUpdate(
                    resourceGroupName,
                    new ResourceGroup
                    {
                        Location = m_location,
                        Tags = new Dictionary<string, string>() { { resourceGroupName, DateTime.UtcNow.ToString("u") } }
                    });
                VirtualNetwork vnetParams = GenerateVnetModel(vnetName, subnetName);
                return m_NrpClient.VirtualNetworks.CreateOrUpdate(resourceGroupName, vnetName, vnetParams);
            }
            catch
            {
                m_ResourcesClient.ResourceGroups.Delete(resourceGroupName);
                throw;
            }

        }

        public void verifyRoleInstance(string roleInstanceName, string roleInstanceSKU, RoleInstance returnedRoleInstance)
        {
            Assert.NotNull(returnedRoleInstance);
            Assert.True(roleInstanceName == returnedRoleInstance.Name);
            Assert.True(returnedRoleInstance.Sku.Name == roleInstanceSKU);
            Assert.NotNull(returnedRoleInstance.Properties.NetworkProfile);
        }

        public void verifyRoleInstanceInstanceView(RoleInstanceInstanceView returnedRoleInstance)
        {
            Assert.NotNull(returnedRoleInstance);
            Assert.NotNull(returnedRoleInstance);
            Assert.NotNull(returnedRoleInstance.Statuses);
            Assert.NotNull(returnedRoleInstance.PlatformFaultDomain);
            Assert.NotNull(returnedRoleInstance.PlatformUpdateDomain);
        }

        protected PublicIPAddress CreatePublicIP(string publicIPAddressName, string resourceGroupName, string dnsName)
        {
            PublicIPAddress publicIPAddressParams = GeneratePublicIPAddressModel(publicIPAddressName, dnsName);
            PublicIPAddress publicIpAddress = m_NrpClient.PublicIPAddresses.CreateOrUpdate(resourceGroupName, publicIPAddressName, publicIPAddressParams);
            return publicIpAddress;
        }

        protected PublicIPAddress GeneratePublicIPAddressModel(string publicIPAddressName, string dnsName)
        {
            PublicIPAddress publicIPAddressParams = new PublicIPAddress(name: publicIPAddressName)
            {
                Location = m_location,
                PublicIPAllocationMethod = IPAllocationMethod.Dynamic,
                DnsSettings = new PublicIPAddressDnsSettings()
                {
                    DomainNameLabel = dnsName
                }
            };

            return publicIPAddressParams;
        }
        protected CloudService GenerateCloudServiceWithNetworkProfile(string resourceGroupName, string serviceName, string cspkgSasUri, string vnetName, string subnetName, string lbName, string lbFrontendName, Dictionary<string, RoleConfiguration> roleNameToPropertiesMapping, string publicIPAddressName)
        {
            CloudService cloudService = GenerateCloudService(serviceName, cspkgSasUri, vnetName, subnetName, roleNameToPropertiesMapping);
            cloudService.Properties.NetworkProfile = GenerateNrpCloudServiceNetworkProfile(publicIPAddressName, resourceGroupName, lbName, lbFrontendName);
            return cloudService;
        }

        protected CloudService GenerateCloudService(string serviceName,
            string cspkgSasUri,
            string vnetName,
            string subnetName,
            Dictionary<string, RoleConfiguration> roleNameToPropertiesMapping,
            CloudServiceVaultSecretGroup vaultGroup = null,
            List<ServiceConfigurationRoleCertificate> cscfgCerts = null,
            ServiceConfigurationRoleSecurityConfigurations securityConfigurations = null,
            List<Extension> extensions = null)
        {
            CloudService cloudService = new CloudService
            {
                Properties = new CloudServiceProperties
                {
                    RoleProfile = new CloudServiceRoleProfile()
                    {
                        Roles = GenerateRoles(roleNameToPropertiesMapping)
                    },
                    Configuration = GenerateBase64EncodedCscfgWithNetworkConfiguration(serviceName, roleNameToPropertiesMapping, vnetName, subnetName, null, cscfgCerts, securityConfigurations),
                    PackageUrl = cspkgSasUri
                },
                Location = m_location
            };
            if (vaultGroup != null)
            {
                cloudService.Properties.OsProfile =
                    new CloudServiceOsProfile
                    {
                        Secrets = new List<CloudServiceVaultSecretGroup>
                        {
                            vaultGroup
                        }
                    };
            }

            if (extensions != null)
            {
                cloudService.Properties.ExtensionProfile = new CloudServiceExtensionProfile
                {
                    Extensions = extensions
                };
            }
            return cloudService;
        }

        protected static string GenerateBase64EncodedCscfgWithNetworkConfiguration(string serviceName,
            Dictionary<string, RoleConfiguration> roleNameToPropertiesMapping,
            string vNetName,
            string subnetName,
            ServiceConfigurationNetworkConfigurationAddressAssignmentsReservedIPs reservedIPs = null,
            List<ServiceConfigurationRoleCertificate> cscfgCerts = null,
            ServiceConfigurationRoleSecurityConfigurations securityConfigurations = null,
            int osFamily = 5,
            Setting[] serviceSettings = null)
        {
            string cscfgPlainText = ServiceConfigurationHelpers.GenerateServiceConfiguration(
                serviceName: serviceName,
                osFamily: osFamily,
                osVersion: "*",
                roleNameToPropertiesMapping: roleNameToPropertiesMapping,
                schemaVersion: "2015-04.2.6",
                vNetName: vNetName,
                subnetName: subnetName,
                reservedIPs: reservedIPs,
                certificates: cscfgCerts,
                securityConfigurations: securityConfigurations,
                serviceSettings: serviceSettings
                );

            return cscfgPlainText;
        }

        protected static List<CloudServiceRoleProfileProperties> GenerateRoles(Dictionary<string, RoleConfiguration> roleNameToPropertiesMapping)
        {
            List<CloudServiceRoleProfileProperties> roles = new List<CloudServiceRoleProfileProperties>();

            foreach (string roleName in roleNameToPropertiesMapping.Keys)
            {
                roles.Add(new CloudServiceRoleProfileProperties()
                {
                    Name = roleName,
                    Sku = new CloudServiceRoleSku
                    {
                        Name = roleNameToPropertiesMapping[roleName].RoleInstanceSize,
                        Capacity = roleNameToPropertiesMapping[roleName].InstanceCount,
                        Tier = roleNameToPropertiesMapping[roleName].RoleInstanceSize.IndexOf("_", StringComparison.InvariantCulture) != -1 ? roleNameToPropertiesMapping[roleName].RoleInstanceSize.Substring(0, roleNameToPropertiesMapping[roleName].RoleInstanceSize.IndexOf("_")) : null
                    }
                });
            }

            return roles;
        }

        protected CloudServiceNetworkProfile GenerateNrpCloudServiceNetworkProfile(string publicIPAddressName, string resourceGroupName, string lbName, string lbFrontEndName)
        {
            var feipConfig = GenerateFrontEndIpConfigurationModel(publicIPAddressName, resourceGroupName, lbFrontEndName);
            CloudServiceNetworkProfile cloudServiceNetworkProfile = new CloudServiceNetworkProfile()
            {
                LoadBalancerConfigurations = new List<LoadBalancerConfiguration>()
                {
                    new LoadBalancerConfiguration()
                    {
                        Name  = lbName,
                        Properties = new LoadBalancerConfigurationProperties()
                        {
                            FrontendIpConfigurations = new List<LoadBalancerFrontendIpConfiguration>()
                            {
                                feipConfig
                            }
                        }
                    }
                }
            };

            return cloudServiceNetworkProfile;
        }

        protected LoadBalancerFrontendIpConfiguration GenerateFrontEndIpConfigurationModel(string publicIPAddressName, string resourceGroupName, string lbFrontEndName)
        {
            LoadBalancerFrontendIpConfiguration feipConfiguration =
                new LoadBalancerFrontendIpConfiguration()
                {
                    Name = lbFrontEndName,
                    Properties = new LoadBalancerFrontendIpConfigurationProperties()
                    {
                        PublicIPAddress = new CM.SubResource()
                        {
                            Id = $"/subscriptions/{m_subId}/resourceGroups/{resourceGroupName}/providers/Microsoft.Network/publicIPAddresses/{publicIPAddressName}",
                        }
                    }
                };

            return feipConfiguration;
        }

        protected VirtualNetwork GenerateVnetModel(string vnetName, string subnetName)
        {
            VirtualNetwork vnet = new VirtualNetwork(name: vnetName)
            {
                AddressSpace = new AddressSpace
                {
                    AddressPrefixes = new List<string> { "10.0.0.0/16" }
                },
                Subnets = new List<Subnet>
                {
                    new Subnet(name: subnetName)
                    {
                        AddressPrefix = "10.0.0.0/24"
                    }
                },
                Location = m_location
            };

            return vnet;
        }

        public class RoleConfiguration
        {
            public uint InstanceCount { get; set; }

            public string RoleInstanceSize { get; set; }

            public Dictionary<string, string> Settings { get; set; }
        }

        /// <summary>
        /// Returns a List of supported RoleInstance Sizes based on the environment.
        /// Note: The ordering of the List is important as all tests will have size dependency in their CSPKG.
        /// By Default most tests have dependency on ""Standard_D2_v2" for Prod regions.
        /// </summary>
        internal static List<string> GetSupportedRoleInstanceSizes()
        {
            return new List<string> { "Standard_D2_v2", "Standard_D1_v2", "Standard_A1", "Standard_A2_v2" };
        }

    }
}