// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for license information.

namespace IntegrationTestCommon
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.IO.Compression;
    using System.Linq;
    using System.Net;
    using System.Net.Security;
    using System.Security.Cryptography.X509Certificates;
    using System.Threading.Tasks;
    using Microsoft.Azure.Batch.IntegrationTestCommon.Tests.Helpers;
    using Microsoft.Azure.Management.Batch;
    using Microsoft.Azure.Management.Batch.Models;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using System.Text;
    using BatchTestCommon;
    using Microsoft.Rest;
    using Azure.Storage.Blobs.Specialized;

    public class IntegrationTestCommon
    {
        public static BatchManagementClient OpenBatchManagementClient()
        {
            ServiceClientCredentials credentials;

            if (IsManagementUrlAValidProductionURL())
            {
                string accessToken = GetAuthenticationTokenAsync("https://management.core.windows.net/").Result;
                credentials = new TokenCredentials(accessToken);
            }
            else
            {
                credentials = GetBatchTestTenantCloudCredentials();
            }

            string managementUrl = TestCommon.Configuration.BatchManagementUrl;

            var managementClient = new BatchManagementClient(credentials)
            {
                BaseUri = new Uri(managementUrl),
                SubscriptionId = TestCommon.Configuration.BatchSubscription
            };

            //Add the extra headers as specified in the configuration
            foreach (KeyValuePair<string, string> extraHeader in TestCommon.Configuration.BatchTRPExtraHeaders)
            {
                managementClient.HttpClient.DefaultRequestHeaders.Add(extraHeader.Key, extraHeader.Value);
            }

            return managementClient;
        }

        private static bool IsManagementUrlAValidProductionURL()
        {
            return new[] { "https://management.azure.com" }.Any(x => TestCommon.Configuration.BatchManagementUrl.StartsWith(x, StringComparison.OrdinalIgnoreCase));
        }

        public static async Task<string> GetAuthenticationTokenAsync(string resource)
        {
            var authContext = new AuthenticationContext(TestCommon.Configuration.BatchAuthorityUrl);

            var authResult = await authContext.AcquireTokenAsync(resource, new ClientCredential(TestCommon.Configuration.AzureAuthenticationClientId, TestCommon.Configuration.AzureAuthenticationClientSecret));

            return authResult.AccessToken;
        }

        private static ServiceClientCredentials GetBatchTestTenantCloudCredentials()
        {
            X509Certificate2 certificate2 = null;
            X509Store store = null;

            try
            {
                store = new X509Store(StoreLocation.CurrentUser);

                store.Open(OpenFlags.ReadOnly);

                X509Certificate2Collection certificates = store.Certificates;

                certificate2 = certificates.Cast<X509Certificate2>().FirstOrDefault(
                    c => String.Equals(
                        c.Thumbprint,
                        TestCommon.Configuration.BatchTRPCertificateThumbprint(),
                        StringComparison.OrdinalIgnoreCase));

                if (certificate2 == null)
                {
                    throw new InvalidOperationException("The certificate with thumbprint '" + TestCommon.Configuration.BatchTRPCertificateThumbprint +
                        "' is not installed on your machine. Refer to the howto.txt for information about setting up your machine for client integration tests.");
                }
            }
            finally
            {
                if (store != null)
                {
                    store.Close();
                }
            }
#if FullNetFx
            return new CertificateCredentials(certificate2);
# else
            return new CertificateCredentialsNetCore(certificate2);
#endif
        }

        public static async Task EnableAutoStorageAsync()
        {
            using BatchManagementClient managementClient = OpenBatchManagementClient();
            //TODO: Why do we need this...?
            ServicePointManager.ServerCertificateValidationCallback =
                delegate (object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                {
                    if (sender is HttpWebRequest request)
                    {
                        if (request.Address.ToString().Contains(TestCommon.Configuration.BatchManagementUrl))
                        {
                            return true;
                        }
                    }
                    return sslPolicyErrors == SslPolicyErrors.None; //use the default validation for all other certificates
                    };

            //If the account doesn't already have auto storage enabled, enable it
            BatchAccount batchAccount = await managementClient.BatchAccount.GetAsync(TestCommon.Configuration.BatchAccountResourceGroup, TestCommon.Configuration.BatchAccountName);
            if (batchAccount.AutoStorage == null)
            {
                const string classicStorageAccountGroup = "Microsoft.ClassicStorage";
                const string storageAccountGroup = "Microsoft.Storage";
                string resourceFormatString = $"/subscriptions/{TestCommon.Configuration.BatchSubscription}/resourceGroups/{TestCommon.Configuration.StorageAccountResourceGroup}/providers/" + "{0}" +
                    $"/storageAccounts/{TestCommon.Configuration.StorageAccountName}";

                string classicStorageAccountFullResourceId = string.Format(resourceFormatString, classicStorageAccountGroup);
                string storageAccountFullResourceId = string.Format(resourceFormatString, storageAccountGroup);

                var updateParameters = new BatchAccountUpdateParameters()
                {
                    AutoStorage = new AutoStorageBaseProperties
                    {
                        StorageAccountId = classicStorageAccountFullResourceId
                    }
                };
                try
                {
                    await managementClient.BatchAccount.UpdateAsync(TestCommon.Configuration.BatchAccountResourceGroup, TestCommon.Configuration.BatchAccountName, updateParameters);
                }
                catch (Exception e) when (e.Message.Contains("The specified storage account could not be found"))
                {
                    //If the storage account could not be found, it might be because we looked in "Classic" -- in that case swallow
                    //the exception.
                }

                updateParameters.AutoStorage.StorageAccountId = storageAccountFullResourceId;
                await managementClient.BatchAccount.UpdateAsync(TestCommon.Configuration.BatchAccountResourceGroup, TestCommon.Configuration.BatchAccountName, updateParameters);
            }
        }

        public static async Task UploadTestApplicationAsync(string storageUrl)
        {
            const string dummyPackageContentFile = @"TestApplicationPackage.zip";

            using MemoryStream fakeApplicationPackageZip = new MemoryStream();
            using (ZipArchive zip = new ZipArchive(fakeApplicationPackageZip, ZipArchiveMode.Create, leaveOpen: true))
            {
                ZipArchiveEntry entry = zip.CreateEntry(dummyPackageContentFile);
                using var s = entry.Open();
                byte[] bytes = Encoding.UTF8.GetBytes("The quick brown fox jumps over the lazy dog.");
                s.Write(bytes, 0, bytes.Length);
            }

            fakeApplicationPackageZip.Seek(0, SeekOrigin.Begin);

            BlockBlobClient blobClient = new BlockBlobClient(new Uri(storageUrl));
            await blobClient.UploadAsync(fakeApplicationPackageZip).ConfigureAwait(false);
        }

        public static string GetTemporaryCertificateFilePath(string fileName)
        {
            string certificateFolderPath = Path.Combine(Path.GetTempPath(), @"BatchTestCertificates");

            Directory.CreateDirectory(certificateFolderPath);

            return Path.Combine(certificateFolderPath, fileName);
        }
    }
}
