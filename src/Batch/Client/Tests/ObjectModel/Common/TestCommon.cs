// Copyright (c) Microsoft and contributors.  All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//
// See the License for the specific language governing permissions and
// limitations under the License.

﻿namespace BatchTestCommon
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
    using Microsoft.Azure;
    using Microsoft.Azure.Management.Batch;
    using Microsoft.Azure.Management.Batch.Models;
    using Microsoft.IdentityModel.Clients.ActiveDirectory;
    using System.Text;
    using Microsoft.WindowsAzure.Storage.Blob;

    public static class TestCommon
    {
        public class TestConfiguration
        {
            public const string BatchSubscriptionEnivronmentSettingName = "MABOM_BatchAccountSubscriptionId";

            public const string BatchManagementUrlEnvironmentSettingName = "MABOM_BatchManagementEndpoint";

            public const string BatchAccountKeyEnvironmentSettingName = "MABOM_BatchAccountKey";

            public const string BatchAccountNameEnvironmentSettingName = "MABOM_BatchAccountName";

            public const string BatchAccountUrlEnvironmentSettingName = "MABOM_BatchAccountEndpoint";

            public const string StorageAccountKeyEnvironmentSettingName = "MABOM_StorageKey";

            public const string StorageAccountNameEnvironmentSettingName = "MABOM_StorageAccount";

            public const string StorageAccountBlobEndpointEnvironmentSettingName = "MABOM_BlobEndpoint";

            public const string BatchAccountResourceGroupEnvironmentSettingName = "MABOM_BatchAccountResourceGroupName";

            public const string StorageAccountResourceGroupEnvironmentSettingName = "MABOM_StorageAccountResourceGroupName";

            public const string BatchTRPCertificateThumbprintEnvironmentSettingName = "MABOM_BatchTRPCertificateThumbprint";

            //Should be a string like so: header1=value1;header2=value2;...
            public const string BatchTRPExtraHeadersEnvironmentSettingName = "MABOM_BatchTRPExtraHeaders";

            public readonly string BatchSubscription = GetEnvironmentVariableOrThrow(BatchSubscriptionEnivronmentSettingName);

            public readonly string BatchManagementUrl = GetEnvironmentVariableOrThrow(BatchManagementUrlEnvironmentSettingName);

            public readonly string BatchAccountKey = GetEnvironmentVariableOrThrow(BatchAccountKeyEnvironmentSettingName);

            public readonly string BatchAccountName = GetEnvironmentVariableOrThrow(BatchAccountNameEnvironmentSettingName);

            public readonly string BatchAccountUrl = GetEnvironmentVariableOrThrow(BatchAccountUrlEnvironmentSettingName);

            public readonly string StorageAccountKey = GetEnvironmentVariableOrThrow(StorageAccountKeyEnvironmentSettingName);

            public readonly string StorageAccountName = GetEnvironmentVariableOrThrow(StorageAccountNameEnvironmentSettingName);

            public readonly string StorageAccountBlobEndpoint = GetEnvironmentVariableOrThrow(StorageAccountBlobEndpointEnvironmentSettingName);

            public readonly string BatchAccountResourceGroup = GetEnvironmentVariableOrThrow(BatchAccountResourceGroupEnvironmentSettingName);

            public readonly string StorageAccountResourceGroup = GetEnvironmentVariableOrThrow(StorageAccountResourceGroupEnvironmentSettingName);

            public readonly string BatchTRPCertificateThumbprint = GetEnvironmentVariableOrThrow(BatchTRPCertificateThumbprintEnvironmentSettingName);

            public readonly IReadOnlyDictionary<string, string> BatchTRPExtraHeaders = ParseHeaderEnvironmentVariable(BatchTRPExtraHeadersEnvironmentSettingName);

            private static IReadOnlyDictionary<string, string> ParseHeaderEnvironmentVariable(string environmentSettingName)
            {
                string settingString = Environment.GetEnvironmentVariable(environmentSettingName);
                IReadOnlyDictionary<string, string> result = new Dictionary<string, string>();

                if (!string.IsNullOrEmpty(settingString))
                {
                    IEnumerable<string> pairs = settingString.Split(';');
                    result = pairs.ToDictionary(pair => pair.Split('=')[0], pair => pair.Split('=')[1]);
                }

                return result;
            }

            private static string GetEnvironmentVariableOrThrow(string environmentSettingName)
            {
                string result = Environment.GetEnvironmentVariable(environmentSettingName);
                if (string.IsNullOrEmpty(result))
                {
                    throw new ArgumentException(string.Format("Missing required environment variable {0}", environmentSettingName));
                }

                return result;
            }

        }

        private static readonly Lazy<TestConfiguration> configurationInstance = new Lazy<TestConfiguration>(() => new TestConfiguration());

        public static TestConfiguration Configuration
        {
            get { return configurationInstance.Value; }
        }

        public static BatchManagementClient OpenBatchManagementClient()
        {
            SubscriptionCloudCredentials subscriptionCloudCredentials;

            if (IsManagementUrlAValidProductionURL())
            {
                subscriptionCloudCredentials = GetBatchProductionTokenCloudCredentials();
            }
            else
            {
                subscriptionCloudCredentials = GetBatchTestTenantCloudCredentials();
            }

            string managementUrl = Configuration.BatchManagementUrl;

            var managementClient = new BatchManagementClient(subscriptionCloudCredentials, new Uri(managementUrl));

            //Add the extra headers as specified in the configuration
            foreach (KeyValuePair<string, string> extraHeader in Configuration.BatchTRPExtraHeaders)
            {
                managementClient.HttpClient.DefaultRequestHeaders.Add(extraHeader.Key, extraHeader.Value);
            }
            
            return managementClient;
        }

        private static bool IsManagementUrlAValidProductionURL()
        {
            return new[] { "https://management.azure.com" }.Any(x => Configuration.BatchManagementUrl.StartsWith(x, StringComparison.OrdinalIgnoreCase));
        }

        private static TokenCloudCredentials GetBatchProductionTokenCloudCredentials()
        {
            var authContext = new AuthenticationContext("https://login.microsoftonline.com/microsoft.onmicrosoft.com");

            var result = authContext.AcquireToken(
                "https://management.core.windows.net/", // AAD Resource
                "da91983f-249d-4c14-8a93-b9c24d6efacc", // AAD client id
                new Uri("http://localhost")); // redirect url

            return new TokenCloudCredentials(Configuration.BatchSubscription, result.AccessToken);
        }

        private static CertificateCloudCredentials GetBatchTestTenantCloudCredentials()
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
                        Configuration.BatchTRPCertificateThumbprint, 
                        StringComparison.OrdinalIgnoreCase));

                if (certificate2 == null)
                {
                    throw new InvalidOperationException("The certificate with thumbprint '" + Configuration.BatchTRPCertificateThumbprint +
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

            string subscriptionsId = Configuration.BatchSubscription;
            return new CertificateCloudCredentials(subscriptionsId, certificate2);
        }

        public static async Task EnableAutoStorageAsync()
        {
            using (BatchManagementClient managementClient = OpenBatchManagementClient())
            {
                //TODO: Why do we need this...?
                ServicePointManager.ServerCertificateValidationCallback =
                    delegate(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
                        {
                            HttpWebRequest request = sender as HttpWebRequest;
                            if (request != null)
                            {
                                if (request.Address.ToString().Contains(Configuration.BatchManagementUrl))
                                {
                                    return true;
                                }
                            }
                            return sslPolicyErrors == SslPolicyErrors.None; //use the default validation for all other certificates
                        };

                //If the account doesn't already have auto storage enabled, enable it
                BatchAccountGetResponse getAccountResponse = await managementClient.Accounts.GetAsync(Configuration.BatchAccountResourceGroup, Configuration.BatchAccountName);
                if (getAccountResponse.Resource.Properties.AutoStorage == null)
                {
                    const string classicStorageAccountGroup = "Microsoft.ClassicStorage";
                    const string storageAccountGroup = "Microsoft.Storage";
                    string resourceFormatString = $"/subscriptions/{Configuration.BatchSubscription}/resourceGroups/{Configuration.StorageAccountResourceGroup}/providers/" + "{0}" +
                        $"/storageAccounts/{Configuration.StorageAccountName}";

                    string classicStorageAccountFullResourceId = string.Format(resourceFormatString, classicStorageAccountGroup);
                    string storageAccountFullResourceId = string.Format(resourceFormatString, storageAccountGroup);

                    var updateParameters = new BatchAccountUpdateParameters()
                        {
                            Properties = new AccountBaseProperties
                                {
                                    AutoStorage = new AutoStorageBaseProperties
                                        {
                                            StorageAccountId = classicStorageAccountFullResourceId
                                        }
                                }
                        };
                    try
                    {
                        await managementClient.Accounts.UpdateAsync(Configuration.BatchAccountResourceGroup, Configuration.BatchAccountName, updateParameters);
                    }
                    catch (Exception e) when (e.Message.Contains("The specified storage account could not be found"))
                    {
                        //If the storage account could not be found, it might be because we looked in "Classic" -- in that case swallow
                        //the exception.
                    }

                    updateParameters.Properties.AutoStorage.StorageAccountId = storageAccountFullResourceId;
                    await managementClient.Accounts.UpdateAsync(Configuration.BatchAccountResourceGroup, Configuration.BatchAccountName, updateParameters);
                }
            }
        }
        
        public static async Task UploadTestApplicationAsync(string storageUrl)
        {
            CloudBlockBlob blob = new CloudBlockBlob(new Uri(storageUrl));

            const string dummyPackageContentFile = @"TestApplicationPackage.zip";

            using (MemoryStream fakeApplicationPackageZip = new MemoryStream())
            {
                using (ZipArchive zip = new ZipArchive(fakeApplicationPackageZip, ZipArchiveMode.Create, leaveOpen: true))
                {
                    ZipArchiveEntry entry = zip.CreateEntry(dummyPackageContentFile);
                    using (var s = entry.Open())
                    {
                        byte[] bytes = Encoding.UTF8.GetBytes("The quick brown fox jumps over the lazy dog.");
                        s.Write(bytes, 0, bytes.Length);
                    }
                }

                fakeApplicationPackageZip.Seek(0, SeekOrigin.Begin);

                await blob.UploadFromStreamAsync(fakeApplicationPackageZip).ConfigureAwait(false);
            }
        }

        public static string GetTemporaryCertificateFilePath(string fileName)
        {
            string certificateFolderPath = Path.Combine(Path.GetTempPath(), @"BatchTestCertificates");

            Directory.CreateDirectory(certificateFolderPath);

            return Path.Combine(certificateFolderPath, fileName);
        }
    }
}