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

using BackupServices.Tests.Helpers;
using Microsoft.Azure.Management.BackupServices;
using Microsoft.Azure.Management.BackupServices.Models;
using Microsoft.Azure.Test;
using System;
using System.Configuration;
using System.Net;
using System.Security.Cryptography.X509Certificates;
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

                BackupServicesManagementClient client = GetServiceClient<BackupServicesManagementClient>();

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
                    client.Vault.UploadCertificate("IdMgmtInternalCert", vaultCredUploadCertRequest, GetCustomRequestHeaders());

                // Response Validation
                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
                Assert.NotNull(response.ResourceCertificateAndACSDetails);

                // Basic Validation                
                Assert.True(string.Equals(rawCertDataString, response.ResourceCertificateAndACSDetails.Certificate),
                            "Downloaded and uploaded cert raw data don't match");
                Assert.True(string.Equals(cert.Thumbprint, response.ResourceCertificateAndACSDetails.Thumbprint,
                                          StringComparison.OrdinalIgnoreCase),
                            "Downloaded and uploaded cert thumbprints don't match");
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
        public void UpdateStorageTypeOnLockedResourceFailsTest()
        {
            bool validationSucceeded = false;

            using (UndoContext undoContext = UndoContext.Current)
            {
                undoContext.Start();

                BackupServicesManagementClient client = GetServiceClient<BackupServicesManagementClient>();

                UpdateVaultStorageTypeRequest updateVaultStorageTypeRequest = new UpdateVaultStorageTypeRequest()
                {
                    StorageTypeProperties = new StorageTypeProperties()
                    {
                        StorageModelType = AzureBackupVaultStorageType.LocallyRedundant.ToString(),
                    },
                };

                try
                {
                    OperationResponse response = client.Vault.UpdateStorageType(updateVaultStorageTypeRequest, GetCustomRequestHeaders());
                }
                catch (Exception ex)
                {
                    if (ex.GetType() == typeof(Hyak.Common.CloudException))
                    {
                        Hyak.Common.CloudException cloudEx = ex as Hyak.Common.CloudException;
                        if (cloudEx.Error.GetType() == typeof(Hyak.Common.CloudError))
                        {
                            Hyak.Common.CloudError cloudError = cloudEx.Error as Hyak.Common.CloudError;
                            if (cloudError.Code == "StorageModelModifyError")
                            {
                                validationSucceeded = true;
                            }
                        }
                    }
                }

                Assert.True(validationSucceeded);
            }
        }
    }
}
