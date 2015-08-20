//
// Copyright (c) Microsoft.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
//

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using BackupServices.Tests.Helpers;
using Microsoft.Azure.Management.BackupServices;
using Microsoft.Azure.Management.BackupServices.Models;
using Microsoft.Azure.Test;
using Xunit;

namespace BackupServices.Tests
{
    public class VaultTests : BackupServicesTestsBase
    {
        [Fact]
        public void UploadCertReturnsValidResponseTest()
        {
            using (UndoContext undoContext = UndoContext.Current)
            {
                undoContext.Start();

                BackupVaultServicesManagementClient client = GetServiceClient<BackupVaultServicesManagementClient>();

                string subscriptionId = ConfigurationManager.AppSettings["SubscriptionId"];
                string resourceName = ConfigurationManager.AppSettings["ResourceName"];
                string resourceId = ConfigurationManager.AppSettings["ResourceId"];

                string certFriendlyName = VaultTestHelper.GenerateCertFriendlyName(subscriptionId, resourceName);

                X509Certificate2 cert =
                    VaultTestHelper.CreateSelfSignedCert(VaultTestHelper.DefaultIssuer,
                                                         certFriendlyName,
                                                         VaultTestHelper.DefaultPassword,
                                                         DateTime.UtcNow.AddMinutes(-10),
                                                         DateTime.UtcNow.AddHours(VaultTestHelper.GetCertificateExpiryInHours()));

                string rawCertDataString = Convert.ToBase64String(cert.RawData);
                VaultCredUploadCertRequest vaultCredUploadCertRequest = new VaultCredUploadCertRequest()
                {
                    RawCertificateData = new RawCertificateData()
                    {
                        Certificate = rawCertDataString,
                    },
                };

                VaultCredUploadCertResponse response =
                    client.Vault.UploadCertificate(BackupServicesTestsBase.ResourceGroupName, BackupServicesTestsBase.ResourceName, "IdMgmtInternalCert", vaultCredUploadCertRequest, GetCustomRequestHeaders());

                // Response Validation
                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                Assert.NotNull(response.ResourceCertificateAndACSDetails);

                // Basic Validation                
                Assert.False(string.IsNullOrEmpty(response.ResourceCertificateAndACSDetails.GlobalAcsHostName),
                             "Returned Global ACS Host Name shouldn't be null or empty");
                Assert.False(string.IsNullOrEmpty(response.ResourceCertificateAndACSDetails.GlobalAcsNamespace),
                             "Returned Global ACS Namespace shouldn't be null or empty");
                Assert.False(string.IsNullOrEmpty(response.ResourceCertificateAndACSDetails.GlobalAcsRPRealm),
                             "Returned Global ACS RP Realm shouldn't be null or empty");

                // Extra Validation
                Assert.True(string.Equals(VaultTestHelper.DefaultIssuer, response.ResourceCertificateAndACSDetails.Issuer),
                            "Downloaded and uploaded cert Issuers don't match");
                Assert.True(string.Equals(resourceId, response.ResourceCertificateAndACSDetails.ResourceId.ToString()),
                            "Downloaded and uploaded resource IDs don't match");
            }
        }

        [Fact]
        public void UpdateStorageTypeReturnsValidCodeTest()
        {
            using (UndoContext undoContext = UndoContext.Current)
            {
                undoContext.Start();

                BackupVaultServicesManagementClient client = GetServiceClient<BackupVaultServicesManagementClient>();

                UpdateVaultStorageTypeRequest updateVaultStorageTypeRequest = new UpdateVaultStorageTypeRequest()
                {
                    StorageTypeProperties = new StorageTypeProperties()
                    {
                        StorageModelType = AzureBackupVaultStorageType.LocallyRedundant.ToString(),
                    },
                };

                OperationResponse response = client.Vault.UpdateStorageType(BackupServicesTestsBase.ResourceGroupName, BackupServicesTestsBase.ResourceName, updateVaultStorageTypeRequest, GetCustomRequestHeaders());

                // Response Validation
                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.NoContent, response.StatusCode);
            }
        }

        [Fact]
        public void CreateOrUpdateVaultReturnsValidCodeTest()
        {
            using (UndoContext undoContext = UndoContext.Current)
            {
                undoContext.Start();

                BackupVaultServicesManagementClient client = GetServiceClient<BackupVaultServicesManagementClient>();

                string location = ConfigurationManager.AppSettings["Location"];
                string resourceGroupName = ConfigurationManager.AppSettings["resourceGroupName"];
                string resourceName = ConfigurationManager.AppSettings["ResourceName"];
                string armResourceId = ConfigurationManager.AppSettings["ARMResourceId"];
                string resourceType = ConfigurationManager.AppSettings["ResourceType"];
                string defaultSku = "standard";

                AzureBackupVaultCreateOrUpdateParameters parameters = new AzureBackupVaultCreateOrUpdateParameters()
                {
                    Location = location,
                    Properties = new AzureBackupVaultProperties()
                    {
                        Sku = new SkuProperties()
                        {
                            Name = defaultSku,
                        },
                    },
                };

                AzureBackupVaultGetResponse response = client.Vault.CreateOrUpdate(resourceGroupName, resourceName, parameters, GetCustomRequestHeaders());

                // Response Validation
                Assert.NotNull(response);
                Assert.True(response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created,
                            "Status Code should either be OK or Created");
                Assert.NotNull(response.Vault);

                // Basic Validation
                //Assert.True(string.Equals(response.Vault.Id, armResourceId, StringComparison.OrdinalIgnoreCase),
                //            "Obtained vault ID doesn't match the input ARM resource ID");
                //Assert.True(string.Equals(response.Vault.Location, location),
                //            "Obtained vault location doesn't match the input resource location");
                //Assert.True(string.Equals(response.Vault.Name, resourceName),
                //            "Obtained vault name doesn't match the input resource name");
                //Assert.True(string.Equals(response.Vault.Type, resourceType),
                //            "Obtained vault type doesn't match the input resource type");
                //Assert.NotNull(response.Vault.Properties);
                //Assert.NotNull(response.Vault.Properties.Sku);
                //Assert.True(string.Equals(response.Vault.Properties.Sku.Name, defaultSku, StringComparison.OrdinalIgnoreCase),
                //            "Obtained vault SKU doesn't match the input resource SKU");
            }
        }

        [Fact]
        public void DeleteVaultRemovesVaultTest()
        {
            using (UndoContext undoContext = UndoContext.Current)
            {
                undoContext.Start();

                BackupVaultServicesManagementClient client = GetServiceClient<BackupVaultServicesManagementClient>();

                string resourceGroupName = ConfigurationManager.AppSettings["resourceGroupName"];
                string location = ConfigurationManager.AppSettings["Location"];
                string resourceName = "delTestRes";
                string defaultSku = "standard";

                AzureBackupVaultCreateOrUpdateParameters parameters = new AzureBackupVaultCreateOrUpdateParameters()
                {
                    Location = location,
                    Properties = new AzureBackupVaultProperties()
                    {
                        Sku = new SkuProperties()
                        {
                            Name = defaultSku,
                        },
                    },
                };

                AzureBackupVaultGetResponse createResponse = client.Vault.CreateOrUpdate(resourceGroupName, resourceName, parameters, GetCustomRequestHeaders());
                Assert.True(createResponse.StatusCode == HttpStatusCode.OK || createResponse.StatusCode == HttpStatusCode.Created,
                            "Unable to create test resource");

                AzureBackupVaultGetResponse deleteResponse = client.Vault.Delete(resourceGroupName, resourceName, GetCustomRequestHeaders());
                Assert.NotNull(deleteResponse);
                Assert.Equal(deleteResponse.StatusCode, HttpStatusCode.OK);

                bool resourceDeleted = false;
                try
                {
                    AzureBackupVaultGetResponse getResponse = client.Vault.Get(resourceGroupName, resourceName, GetCustomRequestHeaders());
                }
                catch (Exception ex)
                {
                    if (ex.GetType() == typeof(Hyak.Common.CloudException))
                    {
                        Hyak.Common.CloudException cloudEx = ex as Hyak.Common.CloudException;
                        if (cloudEx != null &&
                            cloudEx.Error != null &&
                            !string.IsNullOrEmpty(cloudEx.Error.Code) &&
                            cloudEx.Error.Code == "ResourceNotFound")
                        {
                            resourceDeleted = true;
                        }
                    }
                }

                Assert.True(resourceDeleted, "Resource still exists after deletion");
            }
        }

        [Fact]
        public void GetVaultReturnsSameVaultTest()
        {
            using (UndoContext undoContext = UndoContext.Current)
            {
                undoContext.Start();

                BackupVaultServicesManagementClient client = GetServiceClient<BackupVaultServicesManagementClient>();

                string resourceGroupName = ConfigurationManager.AppSettings["resourceGroupName"];
                string resourceName = ConfigurationManager.AppSettings["ResourceName"];
                string location = ConfigurationManager.AppSettings["Location"];
                string armResourceId = ConfigurationManager.AppSettings["ARMResourceId"];
                string resourceType = ConfigurationManager.AppSettings["ResourceType"];
                //string defaultSku = "standard";

                AzureBackupVaultGetResponse response = client.Vault.Get(resourceGroupName, resourceName, GetCustomRequestHeaders());
                // Response Validation
                Assert.NotNull(response);
                Assert.True(response.StatusCode == HttpStatusCode.OK || response.StatusCode == HttpStatusCode.Created,
                            "Status code should either be OK or Created");
                Assert.NotNull(response.Vault);

                // Basic Validation
                //Assert.True(string.Equals(response.Vault.Id, armResourceId, StringComparison.OrdinalIgnoreCase),
                //            "Obtained vault ID doesn't match the input ARM resource ID");
                //Assert.True(string.Equals(response.Vault.Location, location),
                //            "Obtained vault location doesn't match the input resource location");
                //Assert.True(string.Equals(response.Vault.Name, resourceName),
                //            "Obtained vault name doesn't match the input resource name");
                //Assert.True(string.Equals(response.Vault.Type, resourceType),
                //            "Obtained vault type doesn't match the input resource type");
                //Assert.NotNull(response.Vault.Properties);
                //Assert.NotNull(response.Vault.Properties.Sku);
                //Assert.True(string.Equals(response.Vault.Properties.Sku.Name, defaultSku, StringComparison.OrdinalIgnoreCase),
                //            "Obtained vault SKU doesn't match the input resource SKU");
            }
        }

        [Fact]
        public void GetResourceStorageConfigReturnsStorageTypeTest()
        {
            using (UndoContext undoContext = UndoContext.Current)
            {
                undoContext.Start();

                BackupVaultServicesManagementClient client = GetServiceClient<BackupVaultServicesManagementClient>();

                string resourceGroupName = ConfigurationManager.AppSettings["resourceGroupName"];
                string resourceName = ConfigurationManager.AppSettings["ResourceName"];

                GetResourceStorageConfigResponse response = client.Vault.GetResourceStorageConfig(resourceGroupName, resourceName, GetCustomRequestHeaders());
                // Response Validation
                Assert.NotNull(response);
                Assert.True(response.StatusCode == HttpStatusCode.OK, "Status code should be OK");
                Assert.NotNull(response.StorageDetails);

                // Basic Validation
                var validStorageTypes = Enum.GetNames(typeof(AzureBackupVaultStorageType));
                Assert.True(validStorageTypes.Any(validStorageType => validStorageType == response.StorageDetails.StorageType),
                            "Obtained storage type of vault is invalid");
                var validStorageTypeStates = Enum.GetNames(typeof(AzureBackupVaultStorageTypeState));
                Assert.True(validStorageTypeStates.Any(validStorageTypeState => validStorageTypeState == response.StorageDetails.StorageTypeState),
                            "Obtained storage type state of vault is invalid");
            }
        }

        [Fact]
        public void ListVaultsReturnsVaultsInSubscriptionTest()
        {
            using (UndoContext undoContext = UndoContext.Current)
            {
                undoContext.Start();

                BackupVaultServicesManagementClient client = GetServiceClient<BackupVaultServicesManagementClient>();

                string armResourceId = ConfigurationManager.AppSettings["ARMResourceId"];
                string location = ConfigurationManager.AppSettings["Location"];
                string resourceName = ConfigurationManager.AppSettings["ResourceName"];
                string resourceType = ConfigurationManager.AppSettings["ResourceType"];
                string locationShort = ConfigurationManager.AppSettings["LocationShort"];

                int top = 100;

                AzureBackupVaultListResponse response = client.Vault.List(top, GetCustomRequestHeaders());
                // Response Validation
                Assert.NotNull(response);
                Assert.True(response.StatusCode == HttpStatusCode.OK, "Status code should be OK");
                Assert.NotNull(response.Vaults);

                // Basic Validation
                Assert.True(response.Vaults.Any(vault =>
                {
                    return vault.Id == armResourceId &&
                           (vault.Location == location || vault.Location == locationShort) &&
                           vault.Name == resourceName &&
                           vault.Type == resourceType;
                }), "Obtained vault list doesn't container the input resource");
            }
        }

        [Fact]
        public void ListVaultsByResourceGroupReturnsVaultsinResourceGroup()
        {
            using (UndoContext undoContext = UndoContext.Current)
            {
                undoContext.Start();

                BackupVaultServicesManagementClient client = GetServiceClient<BackupVaultServicesManagementClient>();

                string resourceGroupName = ConfigurationManager.AppSettings["resourceGroupName"];
                string armResourceId = ConfigurationManager.AppSettings["ARMResourceId"];
                string location = ConfigurationManager.AppSettings["Location"];
                string resourceName = ConfigurationManager.AppSettings["ResourceName"];
                string resourceType = ConfigurationManager.AppSettings["ResourceType"];
                string locationShort = ConfigurationManager.AppSettings["LocationShort"];

                int top = 100;

                AzureBackupVaultListResponse response = client.Vault.ListByResourceGroup(resourceGroupName, top, GetCustomRequestHeaders());
                // Response Validation
                Assert.NotNull(response);
                Assert.True(response.StatusCode == HttpStatusCode.OK, "Status code should be OK");
                Assert.NotNull(response.Vaults);

                // Basic Validation
                Assert.True(response.Vaults.Any(vault =>
                {
                    return vault.Id == armResourceId &&
                           (vault.Location == location || vault.Location == locationShort) &&
                           vault.Name == resourceName &&
                           vault.Type == resourceType;
                }), "Obtained vault list doesn't container the input resource");
            }
        }
    }
}
