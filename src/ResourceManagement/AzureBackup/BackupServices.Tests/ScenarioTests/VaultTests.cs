using BackupServices.Tests.Helpers;
using Microsoft.Azure.Management.BackupServices;
using Microsoft.Azure.Management.BackupServices.Models;
using Microsoft.Azure.Test;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
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
        public void UpdateStorageTypeReturnsOK()
        {
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

                OperationResponse response = client.Vault.UpdateStorageType(updateVaultStorageTypeRequest, GetCustomRequestHeaders());

                // Response Validation
                Assert.NotNull(response);
                Assert.Equal(HttpStatusCode.OK, response.StatusCode);
            }
        }
    }
}
