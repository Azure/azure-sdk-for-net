// -----------------------------------------------------------------------------------------
// <copyright file="CloudStorageAccountTests.cs" company="Microsoft">
//    Copyright 2012 Microsoft Corporation
// 
//    Licensed under the Apache License, Version 2.0 (the "License");
//    you may not use this file except in compliance with the License.
//    You may obtain a copy of the License at
//      http://www.apache.org/licenses/LICENSE-2.0
// 
//    Unless required by applicable law or agreed to in writing, software
//    distributed under the License is distributed on an "AS IS" BASIS,
//    WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//    See the License for the specific language governing permissions and
//    limitations under the License.
// </copyright>
// -----------------------------------------------------------------------------------------

using System;
using System.Globalization;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage.Queue;
using Microsoft.WindowsAzure.Storage.Table;

#if WINDOWS_DESKTOP
using Microsoft.VisualStudio.TestTools.UnitTesting;
#else
using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
#endif

namespace Microsoft.WindowsAzure.Storage.Core.Util
{
    [TestClass]
    public class CloudStorageAccountTests : TestBase
    {
        private string token = "?sp=abcde&sig=1";

        [TestMethod]
        /// [Description("Anonymous credentials")]
        [TestCategory(ComponentCategory.Auth)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void StorageCredentialsAnonymous()
        {
            StorageCredentials cred = new StorageCredentials();

            Assert.IsNull(cred.AccountName);
            Assert.IsTrue(cred.IsAnonymous);
            Assert.IsFalse(cred.IsSAS);
            Assert.IsFalse(cred.IsSharedKey);

            Uri testUri = new Uri("http://test/abc?querya=1");
            Assert.AreEqual(testUri, cred.TransformUri(testUri));

            byte[] dummyKey = { 0, 1, 2 };
            string base64EncodedDummyKey = Convert.ToBase64String(dummyKey);
            TestHelper.ExpectedException<InvalidOperationException>(
                () => cred.UpdateKey(base64EncodedDummyKey),
                "Updating shared key on an anonymous credentials instance should fail.");


        }

        [TestMethod]
        /// [Description("Shared key credentials")]
        [TestCategory(ComponentCategory.Auth)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void StorageCredentialsSharedKey()
        {
            StorageCredentials cred = new StorageCredentials(TestBase.TargetTenantConfig.AccountName, TestBase.TargetTenantConfig.AccountKey);

            Assert.AreEqual(TestBase.TargetTenantConfig.AccountName, cred.AccountName, false);
            Assert.IsFalse(cred.IsAnonymous);
            Assert.IsFalse(cred.IsSAS);
            Assert.IsTrue(cred.IsSharedKey);

            Uri testUri = new Uri("http://test/abc?querya=1");
            Assert.AreEqual(testUri, cred.TransformUri(testUri));

            Assert.AreEqual(TestBase.TargetTenantConfig.AccountKey, cred.ExportBase64EncodedKey());
            byte[] dummyKey = { 0, 1, 2 };
            string base64EncodedDummyKey = Convert.ToBase64String(dummyKey);
            cred.UpdateKey(base64EncodedDummyKey);
            Assert.AreEqual(base64EncodedDummyKey, cred.ExportBase64EncodedKey());

#if !WINDOWS_RT
            dummyKey[0] = 3;
            base64EncodedDummyKey = Convert.ToBase64String(dummyKey);
            cred.UpdateKey(dummyKey);
            Assert.AreEqual(base64EncodedDummyKey, cred.ExportBase64EncodedKey());
#endif
        }

        [TestMethod]
        /// [Description("SAS token credentials")]
        [TestCategory(ComponentCategory.Auth)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void StorageCredentialsSAS()
        {
            StorageCredentials cred = new StorageCredentials(token);

            Assert.IsNull(cred.AccountName);
            Assert.IsFalse(cred.IsAnonymous);
            Assert.IsTrue(cred.IsSAS);
            Assert.IsFalse(cred.IsSharedKey);

            Uri testUri = new Uri("http://test/abc");
            Assert.AreEqual(testUri.AbsoluteUri + token, cred.TransformUri(testUri).AbsoluteUri, true);

            testUri = new Uri("http://test/abc?query=a&query2=b");
            string expectedUri = testUri.AbsoluteUri + "&" + token.Substring(1);
            Assert.AreEqual(expectedUri, cred.TransformUri(testUri).AbsoluteUri, true);

            byte[] dummyKey = { 0, 1, 2 };
            string base64EncodedDummyKey = Convert.ToBase64String(dummyKey);
            TestHelper.ExpectedException<InvalidOperationException>(
                () => cred.UpdateKey(base64EncodedDummyKey),
                "Updating shared key on a SAS credentials instance should fail.");
        }

        [TestMethod]
        /// [Description("CloudStorageAccount object with an empty key value.")]
        [TestCategory(ComponentCategory.Auth)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void StorageCredentialsEmptyKeyValue()
        {
            string accountName = TestBase.TargetTenantConfig.AccountName;
            string keyValue = TestBase.TargetTenantConfig.AccountKey;
            string emptyKeyValueAsString = string.Empty;
            string emptyKeyConnectionString = string.Format(CultureInfo.InvariantCulture, "DefaultEndpointsProtocol=https;AccountName={0};AccountKey=", accountName);

            StorageCredentials credentials1 = new StorageCredentials(accountName, emptyKeyValueAsString);
            Assert.AreEqual(accountName, credentials1.AccountName);
            Assert.IsFalse(credentials1.IsAnonymous);
            Assert.IsFalse(credentials1.IsSAS);
            Assert.IsTrue(credentials1.IsSharedKey);
            Assert.AreEqual(emptyKeyValueAsString, Convert.ToBase64String(credentials1.ExportKey()));

            CloudStorageAccount account1 = new CloudStorageAccount(credentials1, true);
            Assert.AreEqual(emptyKeyConnectionString, account1.ToString(true));
            Assert.IsNotNull(account1.Credentials);
            Assert.AreEqual(accountName, account1.Credentials.AccountName);
            Assert.IsFalse(account1.Credentials.IsAnonymous);
            Assert.IsFalse(account1.Credentials.IsSAS);
            Assert.IsTrue(account1.Credentials.IsSharedKey);
            Assert.AreEqual(emptyKeyValueAsString, Convert.ToBase64String(account1.Credentials.ExportKey()));

            CloudStorageAccount account2 = CloudStorageAccount.Parse(emptyKeyConnectionString);
            Assert.AreEqual(emptyKeyConnectionString, account2.ToString(true));
            Assert.IsNotNull(account2.Credentials);
            Assert.AreEqual(accountName, account2.Credentials.AccountName);
            Assert.IsFalse(account2.Credentials.IsAnonymous);
            Assert.IsFalse(account2.Credentials.IsSAS);
            Assert.IsTrue(account2.Credentials.IsSharedKey);
            Assert.AreEqual(emptyKeyValueAsString, Convert.ToBase64String(account2.Credentials.ExportKey()));

            CloudStorageAccount account3;
            bool isValidAccount3 = CloudStorageAccount.TryParse(emptyKeyConnectionString, out account3);
            Assert.IsTrue(isValidAccount3);
            Assert.IsNotNull(account3);
            Assert.AreEqual(emptyKeyConnectionString, account3.ToString(true));
            Assert.IsNotNull(account3.Credentials);
            Assert.AreEqual(accountName, account3.Credentials.AccountName);
            Assert.IsFalse(account3.Credentials.IsAnonymous);
            Assert.IsFalse(account3.Credentials.IsSAS);
            Assert.IsTrue(account3.Credentials.IsSharedKey);
            Assert.AreEqual(emptyKeyValueAsString, Convert.ToBase64String(account3.Credentials.ExportKey()));

            StorageCredentials credentials2 = new StorageCredentials(accountName, keyValue);
            Assert.AreEqual(accountName, credentials2.AccountName);
            Assert.IsFalse(credentials2.IsAnonymous);
            Assert.IsFalse(credentials2.IsSAS);
            Assert.IsTrue(credentials2.IsSharedKey);
            Assert.AreEqual(keyValue, Convert.ToBase64String(credentials2.ExportKey()));

            credentials2.UpdateKey(emptyKeyValueAsString, null);
            Assert.AreEqual(emptyKeyValueAsString, Convert.ToBase64String(credentials2.ExportKey()));

#if !WINDOWS_RT
            byte[] emptyKeyValueAsByteArray = new byte[0];

            StorageCredentials credentials3 = new StorageCredentials(accountName, keyValue);
            Assert.AreEqual(accountName, credentials3.AccountName);
            Assert.IsFalse(credentials3.IsAnonymous);
            Assert.IsFalse(credentials3.IsSAS);
            Assert.IsTrue(credentials3.IsSharedKey);
            Assert.AreEqual(keyValue, Convert.ToBase64String(credentials3.ExportKey()));

            credentials3.UpdateKey(emptyKeyValueAsByteArray, null);
            Assert.AreEqual(Convert.ToBase64String(emptyKeyValueAsByteArray), Convert.ToBase64String(credentials3.ExportKey()));
#endif
        }

        [TestMethod]
        /// [Description("CloudStorageAccount object with a null key value.")]
        [TestCategory(ComponentCategory.Auth)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void StorageCredentialsNullKeyValue()
        {
            string accountName = TestBase.TargetTenantConfig.AccountName;
            string keyValue = TestBase.TargetTenantConfig.AccountKey;
            string nullKeyValueAsString = null;

            TestHelper.ExpectedException<ArgumentNullException>(() =>
            {
                StorageCredentials credentials1 = new StorageCredentials(accountName, nullKeyValueAsString);
            }, "Cannot create key with a null value.");

            StorageCredentials credentials2 = new StorageCredentials(accountName, keyValue);
            Assert.AreEqual(accountName, credentials2.AccountName);
            Assert.IsFalse(credentials2.IsAnonymous);
            Assert.IsFalse(credentials2.IsSAS);
            Assert.IsTrue(credentials2.IsSharedKey);
            Assert.AreEqual(keyValue, Convert.ToBase64String(credentials2.ExportKey()));

            TestHelper.ExpectedException<ArgumentNullException>(() =>
            {
                credentials2.UpdateKey(nullKeyValueAsString, null);
            }, "Cannot update key with a null string value.");

#if !WINDOWS_RT
            byte[] nullKeyValueAsByteArray = null;

            StorageCredentials credentials3 = new StorageCredentials(accountName, keyValue);
            Assert.AreEqual(accountName, credentials3.AccountName);
            Assert.IsFalse(credentials3.IsAnonymous);
            Assert.IsFalse(credentials3.IsSAS);
            Assert.IsTrue(credentials3.IsSharedKey);
            Assert.AreEqual(keyValue, Convert.ToBase64String(credentials3.ExportKey()));

            TestHelper.ExpectedException<ArgumentNullException>(() =>
            {
                credentials3.UpdateKey(nullKeyValueAsByteArray, null);
            }, "Cannot update key with a null byte array value.");
#endif
        }

        [TestMethod]
        /// [Description("Compare credentials for equality")]
        [TestCategory(ComponentCategory.Auth)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void StorageCredentialsEquality()
        {
            StorageCredentials credSharedKey1 = new StorageCredentials(TestBase.TargetTenantConfig.AccountName, TestBase.TargetTenantConfig.AccountKey);
            StorageCredentials credSharedKey2 = new StorageCredentials(TestBase.TargetTenantConfig.AccountName, TestBase.TargetTenantConfig.AccountKey);
            StorageCredentials credSharedKey3 = new StorageCredentials(TestBase.TargetTenantConfig.AccountName + "1", TestBase.TargetTenantConfig.AccountKey);
            StorageCredentials credSharedKey4 = new StorageCredentials(TestBase.TargetTenantConfig.AccountName, Convert.ToBase64String(new byte[] { 0, 1, 2 }));
            StorageCredentials credSAS1 = new StorageCredentials(token);
            StorageCredentials credSAS2 = new StorageCredentials(token);
            StorageCredentials credSAS3 = new StorageCredentials(token + "1");
            StorageCredentials credAnonymous1 = new StorageCredentials();
            StorageCredentials credAnonymous2 = new StorageCredentials();

            Assert.IsTrue(credSharedKey1.Equals(credSharedKey2));
            Assert.IsFalse(credSharedKey1.Equals(credSharedKey3));
            Assert.IsFalse(credSharedKey1.Equals(credSharedKey4));
            Assert.IsTrue(credSAS1.Equals(credSAS2));
            Assert.IsFalse(credSAS1.Equals(credSAS3));
            Assert.IsTrue(credAnonymous1.Equals(credAnonymous2));
            Assert.IsFalse(credSharedKey1.Equals(credSAS1));
            Assert.IsFalse(credSharedKey1.Equals(credAnonymous1));
            Assert.IsFalse(credSAS1.Equals(credAnonymous1));
        }

        private void AccountsAreEqual(CloudStorageAccount a, CloudStorageAccount b)
        {
            // endpoints are the same
            Assert.AreEqual(a.BlobEndpoint, b.BlobEndpoint);
            Assert.AreEqual(a.QueueEndpoint, b.QueueEndpoint);
            Assert.AreEqual(a.TableEndpoint, b.TableEndpoint);
            
            // seralized representatons are the same.
            string aToStringNoSecrets = a.ToString();
            string aToStringWithSecrets = a.ToString(true);
            string bToStringNoSecrets = b.ToString(false);
            string bToStringWithSecrets = b.ToString(true);
            Assert.AreEqual(aToStringNoSecrets, bToStringNoSecrets, false);
            Assert.AreEqual(aToStringWithSecrets, bToStringWithSecrets, false);
            
            // credentials are the same
            if (a.Credentials != null && b.Credentials != null)
            {
                Assert.AreEqual(a.Credentials.IsAnonymous, b.Credentials.IsAnonymous);
                Assert.AreEqual(a.Credentials.IsSAS, b.Credentials.IsSAS);
                Assert.AreEqual(a.Credentials.IsSharedKey, b.Credentials.IsSharedKey);

                // make sure 
                if (!a.Credentials.IsAnonymous &&
                    a.Credentials != CloudStorageAccount.DevelopmentStorageAccount.Credentials &&
                    b.Credentials != CloudStorageAccount.DevelopmentStorageAccount.Credentials)
                {
                    Assert.AreNotEqual(aToStringWithSecrets, bToStringNoSecrets, true);
                }
            }
            else if (a.Credentials == null && b.Credentials == null)
            {
                return;
            }
            else
            {
                Assert.Fail("credentials mismatch");
            }
        }

        [TestMethod]
        /// [Description("DevStore account")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudStorageAccountDevelopmentStorageAccount()
        {
            CloudStorageAccount devstoreAccount = CloudStorageAccount.DevelopmentStorageAccount;
            Assert.AreEqual(devstoreAccount.BlobEndpoint, new Uri("http://127.0.0.1:10000/devstoreaccount1"));
            Assert.AreEqual(devstoreAccount.QueueEndpoint, new Uri("http://127.0.0.1:10001/devstoreaccount1"));
            Assert.AreEqual(devstoreAccount.TableEndpoint, new Uri("http://127.0.0.1:10002/devstoreaccount1"));
            string devstoreAccountToStringWithSecrets = devstoreAccount.ToString(true);
            CloudStorageAccount testAccount = CloudStorageAccount.Parse(devstoreAccountToStringWithSecrets);

            // make sure it round trips
            AccountsAreEqual(testAccount, devstoreAccount);
            CloudStorageAccount acct;
            if (!CloudStorageAccount.TryParse(devstoreAccountToStringWithSecrets, out acct))
            {
                Assert.Fail("Expected TryParse success.");
            }
        }

        [TestMethod]
        /// [Description("Regular account with HTTP")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudStorageAccountDefaultStorageAccountWithHttp()
        {
            StorageCredentials cred = new StorageCredentials(TestBase.TargetTenantConfig.AccountName, TestBase.TargetTenantConfig.AccountKey);
            CloudStorageAccount cloudStorageAccount = new CloudStorageAccount(cred, false);
            Assert.AreEqual(cloudStorageAccount.BlobEndpoint,
                new Uri(String.Format("http://{0}.blob.core.windows.net", TestBase.TargetTenantConfig.AccountName)));
            Assert.AreEqual(cloudStorageAccount.QueueEndpoint,
                new Uri(String.Format("http://{0}.queue.core.windows.net", TestBase.TargetTenantConfig.AccountName)));
            Assert.AreEqual(cloudStorageAccount.TableEndpoint,
                new Uri(String.Format("http://{0}.table.core.windows.net", TestBase.TargetTenantConfig.AccountName)));
            string cloudStorageAccountToStringNoSecrets = cloudStorageAccount.ToString();
            string cloudStorageAccountToStringWithSecrets = cloudStorageAccount.ToString(true);
            CloudStorageAccount testAccount = CloudStorageAccount.Parse(cloudStorageAccountToStringWithSecrets);
            // make sure it round trips
            AccountsAreEqual(testAccount, cloudStorageAccount);
        }

        [TestMethod]
        /// [Description("Regular account with HTTPS")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudStorageAccountDefaultStorageAccountWithHttps()
        {
            StorageCredentials cred = new StorageCredentials(TestBase.TargetTenantConfig.AccountName, TestBase.TargetTenantConfig.AccountKey);
            CloudStorageAccount cloudStorageAccount = new CloudStorageAccount(cred, true);
            Assert.AreEqual(cloudStorageAccount.BlobEndpoint,
                new Uri(String.Format("https://{0}.blob.core.windows.net", TestBase.TargetTenantConfig.AccountName)));
            Assert.AreEqual(cloudStorageAccount.QueueEndpoint,
                new Uri(String.Format("https://{0}.queue.core.windows.net", TestBase.TargetTenantConfig.AccountName)));
            Assert.AreEqual(cloudStorageAccount.TableEndpoint,
                new Uri(String.Format("https://{0}.table.core.windows.net", TestBase.TargetTenantConfig.AccountName)));

            string cloudStorageAccountToStringWithSecrets = cloudStorageAccount.ToString(true);
            CloudStorageAccount testAccount = CloudStorageAccount.Parse(cloudStorageAccountToStringWithSecrets);
            // make sure it round trips
            AccountsAreEqual(testAccount, cloudStorageAccount);
        }

        [TestMethod]
        /// [Description("Regular account with HTTP")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudStorageAccountEndpointSuffix()
        {
            const string TestEndpointSuffix = "fake.endpoint.suffix";

            CloudStorageAccount testAccount =
                CloudStorageAccount.Parse(
                    string.Format(
                        "DefaultEndpointsProtocol=http;AccountName={0};AccountKey={1};EndpointSuffix={2};",
                        TestBase.TargetTenantConfig.AccountName,
                        TestBase.TargetTenantConfig.AccountKey,
                        TestEndpointSuffix));
            
            StorageCredentials cred = new StorageCredentials(TestBase.TargetTenantConfig.AccountName, TestBase.TargetTenantConfig.AccountKey);
            CloudStorageAccount cloudStorageAccount = new CloudStorageAccount(cred, TestEndpointSuffix, false);
           
            // make sure it round trips
            this.AccountsAreEqual(testAccount, cloudStorageAccount);
        }

        [TestMethod]
        /// [Description("Regular account with HTTP")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudStorageAccountEndpointSuffixWithBlob()
        {
            const string TestEndpointSuffix = "fake.endpoint.suffix";
            const string AlternateBlobEndpoint = "http://blob.other.endpoint/";

            CloudStorageAccount testAccount =
                CloudStorageAccount.Parse(
                    string.Format(
                        "DefaultEndpointsProtocol=http;AccountName={0};AccountKey={1};EndpointSuffix={2};BlobEndpoint={3}",
                        TestBase.TargetTenantConfig.AccountName,
                        TestBase.TargetTenantConfig.AccountKey,
                        TestEndpointSuffix,
                        AlternateBlobEndpoint));

            CloudStorageAccount cloudStorageAccount = CloudStorageAccount.Parse(testAccount.ToString(true));
            
            // make sure it round trips
            this.AccountsAreEqual(testAccount, cloudStorageAccount);
        }

        [TestMethod]
        /// [Description("Regular account with HTTP")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudStorageAccountConnectionStringRoundtrip()
        {
            string accountString1 =
                string.Format(
                    "DefaultEndpointsProtocol=http;AccountName={0};AccountKey={1};EndpointSuffix={2};",
                    TestBase.TargetTenantConfig.AccountName,
                    TestBase.TargetTenantConfig.AccountKey,
                    "fake.endpoint.suffix");

            string accountString2 =
                string.Format(
                    "DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1};",
                    TestBase.TargetTenantConfig.AccountName,
                    TestBase.TargetTenantConfig.AccountKey);

            string accountString3 =
                string.Format(
                    "DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1};QueueEndpoint={2}",
                    TestBase.TargetTenantConfig.AccountName,
                    TestBase.TargetTenantConfig.AccountKey,
                    "https://alternate.queue.endpoint/");

            string accountString4 =
                string.Format(
                    "DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1};EndpointSuffix={2};QueueEndpoint={3}",
                    TestBase.TargetTenantConfig.AccountName,
                    TestBase.TargetTenantConfig.AccountKey,
                    "fake.endpoint.suffix",
                    "https://alternate.queue.endpoint/");

            connectionStringRoundtripHelper(accountString1);
            connectionStringRoundtripHelper(accountString2);
            connectionStringRoundtripHelper(accountString3);
            connectionStringRoundtripHelper(accountString4);
        }

        private void connectionStringRoundtripHelper(string accountString)
        {
            CloudStorageAccount originalAccount = CloudStorageAccount.Parse(accountString);
            CloudStorageAccount copiedAccount = CloudStorageAccount.Parse(originalAccount.ToString(true));

            // make sure it round trips
            this.AccountsAreEqual(originalAccount, copiedAccount);
        }

        [TestMethod]
        /// [Description("Service client creation methods")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudStorageAccountClientMethods()
        {
            CloudStorageAccount account = CloudStorageAccount.DevelopmentStorageAccount;
            CloudBlobClient blob = account.CreateCloudBlobClient();
            CloudQueueClient queue = account.CreateCloudQueueClient();
            CloudTableClient table = account.CreateCloudTableClient();

            // check endpoints
            Assert.AreEqual(account.BlobEndpoint, blob.BaseUri, "Blob endpoint doesn't match account");
            Assert.AreEqual(account.QueueEndpoint, queue.BaseUri, "Queue endpoint doesn't match account");
            Assert.AreEqual(account.TableEndpoint, table.BaseUri, "Table endpoint doesn't match account");

            // check creds
            Assert.AreEqual(account.Credentials, blob.Credentials, "Blob creds don't match account");
            Assert.AreEqual(account.Credentials, queue.Credentials, "Queue creds don't match account");
            Assert.AreEqual(account.Credentials, table.Credentials, "Table creds don't match account");
        }

        [TestMethod]
        /// [Description("Service client creation methods")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudStorageAccountClientUriVerify()
        {
            StorageCredentials cred = new StorageCredentials(TestBase.TargetTenantConfig.AccountName, TestBase.TargetTenantConfig.AccountKey);
            CloudStorageAccount cloudStorageAccount = new CloudStorageAccount(cred, true);

            CloudBlobClient blobClient = cloudStorageAccount.CreateCloudBlobClient();
            CloudBlobContainer container = blobClient.GetContainerReference("container1");
            Assert.AreEqual(cloudStorageAccount.BlobEndpoint.ToString() + "container1", container.Uri.ToString());

            CloudQueueClient queueClient = cloudStorageAccount.CreateCloudQueueClient();
            CloudQueue queue = queueClient.GetQueueReference("queue1");
            Assert.AreEqual(cloudStorageAccount.QueueEndpoint.ToString() + "queue1", queue.Uri.ToString());

            CloudTableClient tableClient = cloudStorageAccount.CreateCloudTableClient();
            CloudTable table = tableClient.GetTableReference("table1");
            Assert.AreEqual(cloudStorageAccount.TableEndpoint.ToString() + "table1", table.Uri.ToString());
        }

        [TestMethod]
        /// [Description("TryParse should return false for invalid connection strings")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudStorageAccountTryParseNullEmpty()
        {
            CloudStorageAccount account;
            // TryParse should not throw exception when passing in null or empty string
            Assert.IsFalse(CloudStorageAccount.TryParse(null, out account));
            Assert.IsFalse(CloudStorageAccount.TryParse(string.Empty, out account));
        }

        [TestMethod]
        /// [Description("UseDevelopmentStorage=false should fail")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudStorageAccountDevStoreNonTrueFails()
        {
            CloudStorageAccount account;

            Assert.IsFalse(CloudStorageAccount.TryParse("UseDevelopmentStorage=false", out account));
        }

        [TestMethod]
        /// [Description("UseDevelopmentStorage should fail when used with an account name")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudStorageAccountDevStorePlusAccountFails()
        {
            CloudStorageAccount account;

            Assert.IsFalse(CloudStorageAccount.TryParse("UseDevelopmentStorage=false;AccountName=devstoreaccount1", out account));
        }

        [TestMethod]
        /// [Description("UseDevelopmentStorage should fail when used with a custom endpoint")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudStorageAccountDevStorePlusEndpointFails()
        {
            CloudStorageAccount account;

            Assert.IsFalse(CloudStorageAccount.TryParse("UseDevelopmentStorage=false;BlobEndpoint=http://127.0.0.1:1000/devstoreaccount1", out account));
        }

        [TestMethod]
        /// [Description("Custom endpoints")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudStorageAccountDefaultEndpointOverride()
        {
            CloudStorageAccount account;

            Assert.IsTrue(CloudStorageAccount.TryParse("DefaultEndpointsProtocol=http;BlobEndpoint=http://customdomain.com/;AccountName=asdf;AccountKey=123=", out account));
            Assert.AreEqual(new Uri("http://customdomain.com/"), account.BlobEndpoint);
        }

        [TestMethod]
        /// [Description("Use DevStore with a proxy")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudStorageAccountDevStoreProxyUri()
        {
            CloudStorageAccount account;

            Assert.IsTrue(CloudStorageAccount.TryParse("UseDevelopmentStorage=true;DevelopmentStorageProxyUri=http://ipv4.fiddler", out account));
            Assert.AreEqual(new Uri("http://ipv4.fiddler:10000/devstoreaccount1"), account.BlobEndpoint);
            Assert.AreEqual(new Uri("http://ipv4.fiddler:10001/devstoreaccount1"), account.QueueEndpoint);
            Assert.AreEqual(new Uri("http://ipv4.fiddler:10002/devstoreaccount1"), account.TableEndpoint);
        }

        [TestMethod]
        /// [Description("ToString method for DevStore account should not return endpoint info")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudStorageAccountDevStoreRoundtrip()
        {
            string accountString = "UseDevelopmentStorage=true";

            Assert.AreEqual(accountString, CloudStorageAccount.Parse(accountString).ToString(true));
        }

        [TestMethod]
        /// [Description("ToString method for DevStore account with a proxy should not return endpoint info")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudStorageAccountDevStoreProxyRoundtrip()
        {
            string accountString = "UseDevelopmentStorage=true;DevelopmentStorageProxyUri=http://ipv4.fiddler/";

            Assert.AreEqual(accountString, CloudStorageAccount.Parse(accountString).ToString(true));
        }

        [TestMethod]
        /// [Description("ToString method for regular account should return the same connection string")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudStorageAccountDefaultCloudRoundtrip()
        {
            string accountString = "DefaultEndpointsProtocol=http;AccountName=test;AccountKey=abc=";

            Assert.AreEqual(accountString, CloudStorageAccount.Parse(accountString).ToString(true));
        }

        [TestMethod]
        /// [Description("ToString method for custom endpoints should return the same connection string")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudStorageAccountExplicitCloudRoundtrip()
        {
            string accountString = "BlobEndpoint=https://blobs/;AccountName=test;AccountKey=abc=";

            Assert.AreEqual(accountString, CloudStorageAccount.Parse(accountString).ToString(true));
        }

        [TestMethod]
        /// [Description("ToString method for anonymous credentials should return the same connection string")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudStorageAccountAnonymousRoundtrip()
        {
            string accountString = "BlobEndpoint=http://blobs/";

            Assert.AreEqual(accountString, CloudStorageAccount.Parse(accountString).ToString(true));

            CloudStorageAccount account = new CloudStorageAccount(null, new Uri("http://blobs/"), null, null);

            AccountsAreEqual(account, CloudStorageAccount.Parse(account.ToString(true)));
        }

        [TestMethod]
        /// [Description("Parse method should ignore empty values")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudStorageAccountEmptyValues()
        {
            string accountString = ";BlobEndpoint=http://blobs/;;AccountName=test;;AccountKey=abc=;";
            string validAccountString = "BlobEndpoint=http://blobs/;AccountName=test;AccountKey=abc=";

            Assert.AreEqual(validAccountString, CloudStorageAccount.Parse(accountString).ToString(true));
        }

        [TestMethod]
        /// [Description("ToString method with custom blob endpoint should return the same connection string")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudStorageAccountJustBlobToString()
        {
            string accountString = "BlobEndpoint=http://blobs/;AccountName=test;AccountKey=abc=";

            Assert.AreEqual(accountString, CloudStorageAccount.Parse(accountString).ToString(true));
        }

        [TestMethod]
        /// [Description("ToString method with custom queue endpoint should return the same connection string")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudStorageAccountJustQueueToString()
        {
            string accountString = "QueueEndpoint=http://queue/;AccountName=test;AccountKey=abc=";

            Assert.AreEqual(accountString, CloudStorageAccount.Parse(accountString).ToString(true));
        }

        [TestMethod]
        /// [Description("ToString method with custom table endpoint should return the same connection string")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudStorageAccountJustTableToString()
        {
            string accountString = "TableEndpoint=http://table/;AccountName=test;AccountKey=abc=";

            Assert.AreEqual(accountString, CloudStorageAccount.Parse(accountString).ToString(true));
        }

        [TestMethod]
        /// [Description("Exporting account key should be possible both as a byte array and a Base64 encoded string")]
        [TestCategory(ComponentCategory.Core)]
        [TestCategory(TestTypeCategory.UnitTest)]
        [TestCategory(SmokeTestCategory.NonSmoke)]
        [TestCategory(TenantTypeCategory.DevStore), TestCategory(TenantTypeCategory.DevFabric), TestCategory(TenantTypeCategory.Cloud)]
        public void CloudStorageAccountExportKey()
        {
            string accountKeyString = "abc2564=";
            string accountString = "BlobEndpoint=http://blobs/;AccountName=test;AccountKey=" + accountKeyString;
            CloudStorageAccount account = CloudStorageAccount.Parse(accountString);
            StorageCredentials accountAndKey = (StorageCredentials)account.Credentials;
            string key = accountAndKey.ExportBase64EncodedKey();
            Assert.AreEqual(accountKeyString, key);

            byte[] keyBytes = accountAndKey.ExportKey();
            byte[] expectedKeyBytes = Convert.FromBase64String(accountKeyString);
            for (int i = 0; i < expectedKeyBytes.Length; i++)
            {
                Assert.AreEqual(expectedKeyBytes[i], keyBytes[i]);
            }
            Assert.AreEqual(expectedKeyBytes.Length, keyBytes.Length);
        }
    }
}
