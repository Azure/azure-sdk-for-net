// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Globalization;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Storage.Test
{
    [TestFixture]
    public class StorageConnectionStringTests
    {
        [Test]
        [LiveOnly]
        [Description("StorageConnectionString object with an empty key value.")]
        public void StorageCredentialsEmptyKeyValue()
        {
            var accountName = TestConfigurations.DefaultTargetTenant.AccountName;
            _ = TestConfigurations.DefaultTargetTenant.AccountKey;
            var emptyKeyValueAsString = string.Empty;
            var emptyKeyConnectionString = string.Format(CultureInfo.InvariantCulture, "DefaultEndpointsProtocol=https;AccountName={0};AccountKey=", accountName);

            var credentials1 = new StorageSharedKeyCredential(accountName, emptyKeyValueAsString);

            StorageConnectionString conn1 = TestExtensions.CreateStorageConnectionString(credentials1, true);
            Assert.AreEqual(emptyKeyConnectionString, conn1.ToString(true));
            Assert.IsNotNull(conn1.Credentials);
            Assert.IsInstanceOf(typeof(StorageSharedKeyCredential), conn1.Credentials);
            Assert.AreEqual(accountName, ((StorageSharedKeyCredential)conn1.Credentials).AccountName);
            Assert.AreEqual(emptyKeyValueAsString, ((StorageSharedKeyCredential)conn1.Credentials).ExportBase64EncodedKey());

            var account2 = StorageConnectionString.Parse(emptyKeyConnectionString);
            Assert.AreEqual(emptyKeyConnectionString, account2.ToString(true));
            Assert.IsNotNull(account2.Credentials);
            Assert.IsInstanceOf(typeof(StorageSharedKeyCredential), account2.Credentials);
            Assert.AreEqual(accountName, ((StorageSharedKeyCredential)account2.Credentials).AccountName);
            Assert.AreEqual(emptyKeyValueAsString, ((StorageSharedKeyCredential)account2.Credentials).ExportBase64EncodedKey());

            var isValidAccount3 = StorageConnectionString.TryParse(emptyKeyConnectionString, out StorageConnectionString account3);
            Assert.IsTrue(isValidAccount3);
            Assert.IsNotNull(account3);
            Assert.AreEqual(emptyKeyConnectionString, account3.ToString(true));
            Assert.IsNotNull(account3.Credentials);
            Assert.IsInstanceOf(typeof(StorageSharedKeyCredential), account3.Credentials);
            Assert.AreEqual(accountName, ((StorageSharedKeyCredential)account3.Credentials).AccountName);
            Assert.AreEqual(emptyKeyValueAsString, ((StorageSharedKeyCredential)account3.Credentials).ExportBase64EncodedKey());
        }

        private void AccountsAreEqual(StorageConnectionString a, StorageConnectionString b)
        {
            // endpoints are the same
            Assert.AreEqual(a.BlobEndpoint, b.BlobEndpoint);
            Assert.AreEqual(a.QueueEndpoint, b.QueueEndpoint);
            Assert.AreEqual(a.FileEndpoint, b.FileEndpoint);

            // storage uris are the same
            Assert.AreEqual(a.BlobStorageUri, b.BlobStorageUri);
            Assert.AreEqual(a.QueueStorageUri, b.QueueStorageUri);
            Assert.AreEqual(a.FileStorageUri, b.FileStorageUri);

            // seralized representatons are the same.
            var aToStringNoSecrets = a.ToString(false);
            var aToStringWithSecrets = a.ToString(true);
            var bToStringNoSecrets = b.ToString(false);
            var bToStringWithSecrets = b.ToString(true);
            Assert.AreEqual(aToStringNoSecrets, bToStringNoSecrets);
            Assert.AreEqual(aToStringWithSecrets, bToStringWithSecrets);

            // credentials are the same
            if (a.Credentials != null && b.Credentials != null)
            {
                Assert.AreEqual(a.GetType(), b.GetType());

                // make sure
                if (a.Credentials != StorageConnectionString.DevelopmentStorageAccount.Credentials &&
                    b.Credentials != StorageConnectionString.DevelopmentStorageAccount.Credentials)
                {
                    StringAssert.AreNotEqualIgnoringCase(aToStringWithSecrets, bToStringNoSecrets);
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

        [Test]
        [Description("DevStore account")]
        public void DevelopmentStorageAccount()
        {
            StorageConnectionString devstoreAccount = StorageConnectionString.DevelopmentStorageAccount;
            Assert.AreEqual(new Uri("http://127.0.0.1:10000/devstoreaccount1"), devstoreAccount.BlobEndpoint);
            Assert.AreEqual(new Uri("http://127.0.0.1:10001/devstoreaccount1"), devstoreAccount.QueueEndpoint);
            Assert.AreEqual(new Uri("http://127.0.0.1:10000/devstoreaccount1"), devstoreAccount.BlobStorageUri.PrimaryUri);
            Assert.AreEqual(new Uri("http://127.0.0.1:10001/devstoreaccount1"), devstoreAccount.QueueStorageUri.PrimaryUri);
            Assert.AreEqual(new Uri("http://127.0.0.1:10000/devstoreaccount1-secondary"), devstoreAccount.BlobStorageUri.SecondaryUri);
            Assert.AreEqual(new Uri("http://127.0.0.1:10001/devstoreaccount1-secondary"), devstoreAccount.QueueStorageUri.SecondaryUri);
            Assert.IsNull(devstoreAccount.FileStorageUri.PrimaryUri);
            Assert.IsNull(devstoreAccount.FileStorageUri.SecondaryUri);

            var devstoreAccountToStringWithSecrets = devstoreAccount.ToString(true);
            var testAccount = StorageConnectionString.Parse(devstoreAccountToStringWithSecrets);

            AccountsAreEqual(testAccount, devstoreAccount);
            if (!StorageConnectionString.TryParse(devstoreAccountToStringWithSecrets, out _))
            {
                Assert.Fail("Expected TryParse success.");
            }
        }

        [Test]
        [LiveOnly]
        [Description("Regular account with HTTP")]
        public void DefaultStorageAccountWithHttp()
        {
            var cred = new StorageSharedKeyCredential(TestConfigurations.DefaultTargetTenant.AccountName, TestConfigurations.DefaultTargetTenant.AccountKey);
            var conn = TestExtensions.CreateStorageConnectionString(cred, false);
            Assert.AreEqual(conn.BlobEndpoint,
                new Uri(string.Format("http://{0}.blob.core.windows.net", TestConfigurations.DefaultTargetTenant.AccountName)));
            Assert.AreEqual(conn.QueueEndpoint,
                new Uri(string.Format("http://{0}.queue.core.windows.net", TestConfigurations.DefaultTargetTenant.AccountName)));
            Assert.AreEqual(conn.FileEndpoint,
                new Uri(string.Format("http://{0}.file.core.windows.net", TestConfigurations.DefaultTargetTenant.AccountName)));
            Assert.AreEqual(conn.BlobStorageUri.SecondaryUri,
                new Uri(string.Format("http://{0}-secondary.blob.core.windows.net", TestConfigurations.DefaultTargetTenant.AccountName)));
            Assert.AreEqual(conn.QueueStorageUri.SecondaryUri,
                new Uri(string.Format("http://{0}-secondary.queue.core.windows.net", TestConfigurations.DefaultTargetTenant.AccountName)));
            Assert.AreEqual(conn.FileStorageUri.SecondaryUri,
                new Uri(string.Format("http://{0}-secondary.file.core.windows.net", TestConfigurations.DefaultTargetTenant.AccountName)));
            _ = conn.ToString();
            var storageConnectionStringToStringWithSecrets = conn.ToString(true);
            var testAccount = StorageConnectionString.Parse(storageConnectionStringToStringWithSecrets);

            AccountsAreEqual(testAccount, conn);
        }

        [Test]
        [LiveOnly]
        [Description("Regular account with HTTPS")]
        public void DefaultStorageAccountWithHttps()
        {
            var cred = new StorageSharedKeyCredential(TestConfigurations.DefaultTargetTenant.AccountName, TestConfigurations.DefaultTargetTenant.AccountKey);
            var conn = TestExtensions.CreateStorageConnectionString(cred, true);
            Assert.AreEqual(conn.BlobEndpoint,
                new Uri(string.Format("https://{0}.blob.core.windows.net", TestConfigurations.DefaultTargetTenant.AccountName)));
            Assert.AreEqual(conn.QueueEndpoint,
                new Uri(string.Format("https://{0}.queue.core.windows.net", TestConfigurations.DefaultTargetTenant.AccountName)));
            Assert.AreEqual(conn.FileEndpoint,
                new Uri(string.Format("https://{0}.file.core.windows.net", TestConfigurations.DefaultTargetTenant.AccountName)));
            Assert.AreEqual(conn.BlobStorageUri.SecondaryUri,
                new Uri(string.Format("https://{0}-secondary.blob.core.windows.net", TestConfigurations.DefaultTargetTenant.AccountName)));
            Assert.AreEqual(conn.QueueStorageUri.SecondaryUri,
                new Uri(string.Format("https://{0}-secondary.queue.core.windows.net", TestConfigurations.DefaultTargetTenant.AccountName)));
            Assert.AreEqual(conn.FileStorageUri.SecondaryUri,
                new Uri(string.Format("https://{0}-secondary.file.core.windows.net", TestConfigurations.DefaultTargetTenant.AccountName)));

            var storageConnectionStringToStringWithSecrets = conn.ToString(true);
            var testAccount = StorageConnectionString.Parse(storageConnectionStringToStringWithSecrets);

            AccountsAreEqual(testAccount, conn);
        }

        [Test]
        [LiveOnly]
        [Description("Regular account with HTTP")]
        public void EndpointSuffixWithHttp()
        {
            const string TestEndpointSuffix = "fake.endpoint.suffix";

            var conn = StorageConnectionString.Parse(
                string.Format(
                    "DefaultEndpointsProtocol=http;AccountName={0};AccountKey={1};EndpointSuffix={2};",
                    TestConfigurations.DefaultTargetTenant.AccountName,
                    TestConfigurations.DefaultTargetTenant.AccountKey,
                    TestEndpointSuffix));

            Assert.AreEqual(conn.BlobEndpoint,
                new Uri(string.Format("http://{0}.blob.{1}", TestConfigurations.DefaultTargetTenant.AccountName, TestEndpointSuffix)));
            Assert.AreEqual(conn.QueueEndpoint,
                new Uri(string.Format("http://{0}.queue.{1}", TestConfigurations.DefaultTargetTenant.AccountName, TestEndpointSuffix)));
            Assert.AreEqual(conn.FileEndpoint,
                new Uri(string.Format("http://{0}.file.{1}", TestConfigurations.DefaultTargetTenant.AccountName, TestEndpointSuffix)));
            Assert.AreEqual(conn.BlobStorageUri.SecondaryUri,
                new Uri(string.Format("http://{0}-secondary.blob.{1}", TestConfigurations.DefaultTargetTenant.AccountName, TestEndpointSuffix)));
            Assert.AreEqual(conn.QueueStorageUri.SecondaryUri,
                new Uri(string.Format("http://{0}-secondary.queue.{1}", TestConfigurations.DefaultTargetTenant.AccountName, TestEndpointSuffix)));
            Assert.AreEqual(conn.FileStorageUri.SecondaryUri,
               new Uri(string.Format("http://{0}-secondary.file.{1}", TestConfigurations.DefaultTargetTenant.AccountName, TestEndpointSuffix)));

            var storageConnectionStringToStringWithSecrets = conn.ToString(true);
            var testAccount = StorageConnectionString.Parse(storageConnectionStringToStringWithSecrets);

            AccountsAreEqual(testAccount, conn);
        }

        [Test]
        [LiveOnly]
        [Description("Regular account with HTTPS")]
        public void EndpointSuffixWithHttps()
        {
            const string TestEndpointSuffix = "fake.endpoint.suffix";

            var conn = StorageConnectionString.Parse(
                string.Format(
                    "DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1};EndpointSuffix={2};",
                    TestConfigurations.DefaultTargetTenant.AccountName,
                    TestConfigurations.DefaultTargetTenant.AccountKey,
                    TestEndpointSuffix));

            Assert.AreEqual(conn.BlobEndpoint,
                new Uri(string.Format("https://{0}.blob.{1}", TestConfigurations.DefaultTargetTenant.AccountName, TestEndpointSuffix)));
            Assert.AreEqual(conn.QueueEndpoint,
                new Uri(string.Format("https://{0}.queue.{1}", TestConfigurations.DefaultTargetTenant.AccountName, TestEndpointSuffix)));
            Assert.AreEqual(conn.FileEndpoint,
                new Uri(string.Format("https://{0}.file.{1}", TestConfigurations.DefaultTargetTenant.AccountName, TestEndpointSuffix)));
            Assert.AreEqual(conn.BlobStorageUri.SecondaryUri,
                new Uri(string.Format("https://{0}-secondary.blob.{1}", TestConfigurations.DefaultTargetTenant.AccountName, TestEndpointSuffix)));
            Assert.AreEqual(conn.QueueStorageUri.SecondaryUri,
                new Uri(string.Format("https://{0}-secondary.queue.{1}", TestConfigurations.DefaultTargetTenant.AccountName, TestEndpointSuffix)));
            Assert.AreEqual(conn.FileStorageUri.SecondaryUri,
                new Uri(string.Format("https://{0}-secondary.file.{1}", TestConfigurations.DefaultTargetTenant.AccountName, TestEndpointSuffix)));

            var storageConnectionStringToStringWithSecrets = conn.ToString(true);
            var testAccount = StorageConnectionString.Parse(storageConnectionStringToStringWithSecrets);

            AccountsAreEqual(testAccount, conn);
        }

        [Test]
        [LiveOnly]
        [Description("Regular account with HTTP")]
        public void EndpointSuffixWithBlob()
        {
            const string TestEndpointSuffix = "fake.endpoint.suffix";
            const string AlternateBlobEndpoint = "http://blob.other.endpoint/";

            var testAccount =
                StorageConnectionString.Parse(
                    string.Format(
                        "DefaultEndpointsProtocol=http;AccountName={0};AccountKey={1};EndpointSuffix={2};BlobEndpoint={3}",
                        TestConfigurations.DefaultTargetTenant.AccountName,
                        TestConfigurations.DefaultTargetTenant.AccountKey,
                        TestEndpointSuffix,
                        AlternateBlobEndpoint));

            var conn = StorageConnectionString.Parse(testAccount.ToString(true));

            // make sure it round trips
            AccountsAreEqual(testAccount, conn);
        }

        [Test]
        [LiveOnly]
        [Description("Regular account with HTTP")]
        public void ConnectionStringRoundtrip()
        {
            var accountKeyParams = new[]
                {
                    TestConfigurations.DefaultTargetTenant.AccountName,
                    TestConfigurations.DefaultTargetTenant.AccountKey,
                    "fake.endpoint.suffix",
                    "https://primary.endpoint/",
                    "https://secondary.endpoint/"
                };

            var accountSasParams = new[]
                {
                    TestConfigurations.DefaultTargetTenant.AccountName,
                    "sasTest",
                    "fake.endpoint.suffix",
                    "https://primary.endpoint/",
                    "https://secondary.endpoint/"
                };

            // account key

            var accountString1 =
                string.Format(
                    "DefaultEndpointsProtocol=http;AccountName={0};AccountKey={1};EndpointSuffix={2};",
                    accountKeyParams);

            var accountString2 =
                string.Format(
                    "DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1};",
                    accountKeyParams);

            var accountString3 =
                string.Format(
                    "DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1};QueueEndpoint={3}",
                    accountKeyParams);

            var accountString4 =
                string.Format(
                    "DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1};EndpointSuffix={2};QueueEndpoint={3}",
                    accountKeyParams);

            ValidateRoundTrip(accountString1);
            ValidateRoundTrip(accountString2);
            ValidateRoundTrip(accountString3);
            ValidateRoundTrip(accountString4);

            var accountString5 =
                string.Format(
                    "AccountName={0};AccountKey={1};EndpointSuffix={2};",
                    accountKeyParams);

            var accountString6 =
                string.Format(
                    "AccountName={0};AccountKey={1};",
                    accountKeyParams);

            var accountString7 =
                string.Format(
                    "AccountName={0};AccountKey={1};QueueEndpoint={3}",
                    accountKeyParams);

            var accountString8 =
                string.Format(
                    "AccountName={0};AccountKey={1};EndpointSuffix={2};QueueEndpoint={3}",
                    accountKeyParams);

            ValidateRoundTrip(accountString5);
            ValidateRoundTrip(accountString6);
            ValidateRoundTrip(accountString7);
            ValidateRoundTrip(accountString8);

            // shared access

            var accountString9 =
                string.Format(
                    "DefaultEndpointsProtocol=http;AccountName={0};SharedAccessSignature={1};EndpointSuffix={2};",
                    accountSasParams);

            var accountString10 =
                string.Format(
                    "DefaultEndpointsProtocol=https;AccountName={0};SharedAccessSignature={1};",
                    accountSasParams);

            var accountString11 =
                string.Format(
                    "DefaultEndpointsProtocol=https;AccountName={0};SharedAccessSignature={1};QueueEndpoint={3}",
                    accountSasParams);

            var accountString12 =
                string.Format(
                    "DefaultEndpointsProtocol=https;AccountName={0};SharedAccessSignature={1};EndpointSuffix={2};QueueEndpoint={3}",
                    accountSasParams);

            ValidateRoundTrip(accountString9);
            ValidateRoundTrip(accountString10);
            ValidateRoundTrip(accountString11);
            ValidateRoundTrip(accountString12);

            var accountString13 =
                string.Format(
                    "AccountName={0};SharedAccessSignature={1};EndpointSuffix={2};",
                    accountSasParams);

            var accountString14 =
                string.Format(
                    "AccountName={0};SharedAccessSignature={1};",
                    accountSasParams);

            var accountString15 =
                string.Format(
                    "AccountName={0};SharedAccessSignature={1};QueueEndpoint={3}",
                    accountSasParams);

            var accountString16 =
                string.Format(
                    "AccountName={0};SharedAccessSignature={1};EndpointSuffix={2};QueueEndpoint={3}",
                    accountSasParams);

            ValidateRoundTrip(accountString13);
            ValidateRoundTrip(accountString14);
            ValidateRoundTrip(accountString15);
            ValidateRoundTrip(accountString16);

            // shared access no account name

            var accountString17 =
                string.Format(
                    "SharedAccessSignature={1};QueueEndpoint={3}",
                    accountSasParams);

            ValidateRoundTrip(accountString17);
        }

        [Test]
        [LiveOnly]
        [Description("Regular account with HTTP")]
        public void ValidateExpectedExceptions()
        {
            var endpointCombinations = new[]
                {
                    new[] { "BlobEndpoint={3}", "BlobSecondaryEndpoint={4}", "BlobEndpoint={3};BlobSecondaryEndpoint={4}" },
                    new[] { "QueueEndpoint={3}", "QueueSecondaryEndpoint={4}", "QueueEndpoint={3};QueueSecondaryEndpoint={4}" },
                    new[] { "FileEndpoint={3}", "FileSecondaryEndpoint={4}", "FileEndpoint={3};FileSecondaryEndpoint={4}" }
                };

            var accountKeyParams = new[]
                {
                    TestConfigurations.DefaultTargetTenant.AccountName,
                    TestConfigurations.DefaultTargetTenant.AccountKey,
                    "fake.endpoint.suffix",
                    "https://primary.endpoint/",
                    "https://secondary.endpoint/"
                };

            var accountSasParams = new[]
                {
                    TestConfigurations.DefaultTargetTenant.AccountName,
                    "sasTest",
                    "fake.endpoint.suffix",
                    "https://primary.endpoint/",
                    "https://secondary.endpoint/"
                };

            foreach (var endpointCombination in endpointCombinations)
            {
                // account key

                var accountStringKeyPrimary =
                    string.Format(
                        "DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1};EndpointSuffix={2};" + endpointCombination[0],
                        accountKeyParams
                        );

                var accountStringKeySecondary =
                    string.Format(
                        "DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1};EndpointSuffix={2};" + endpointCombination[1],
                        accountKeyParams
                        );

                var accountStringKeyPrimarySecondary =
                    string.Format(
                        "DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1};EndpointSuffix={2};" + endpointCombination[2],
                        accountKeyParams
                        );

                var conn = StorageConnectionString.Parse(accountStringKeyPrimary); // no exception expected

                // Query params should not be set as no Sas token is included
                Assert.IsEmpty(conn.BlobEndpoint.Query);
                Assert.IsEmpty(conn.FileEndpoint.Query);
                Assert.IsEmpty(conn.QueueEndpoint.Query);

                TestHelper.AssertExpectedException(
                    () => StorageConnectionString.Parse(accountStringKeySecondary),
                    new FormatException("No valid combination of account information found.")
                    );

                StorageConnectionString.Parse(accountStringKeyPrimarySecondary); // no exception expected

                // account key, no default protocol

                var accountStringKeyNoDefaultProtocolPrimary =
                    string.Format(
                        "AccountName={0};AccountKey={1};EndpointSuffix={2};" + endpointCombination[0],
                        accountKeyParams
                        );

                var accountStringKeyNoDefaultProtocolSecondary =
                    string.Format(
                        "AccountName={0};AccountKey={1};EndpointSuffix={2};" + endpointCombination[1],
                        accountKeyParams
                        );

                var accountStringKeyNoDefaultProtocolPrimarySecondary =
                    string.Format(
                        "AccountName={0};AccountKey={1};EndpointSuffix={2};" + endpointCombination[2],
                        accountKeyParams
                        );

                StorageConnectionString.Parse(accountStringKeyNoDefaultProtocolPrimary); // no exception expected

                TestHelper.AssertExpectedException(
                    () => StorageConnectionString.Parse(accountStringKeyNoDefaultProtocolSecondary),
                    new FormatException("No valid combination of account information found.")
                    );

                StorageConnectionString.Parse(accountStringKeyNoDefaultProtocolPrimarySecondary); // no exception expected

                // SAS

                var accountStringSasPrimary =
                    string.Format(
                        "DefaultEndpointsProtocol=https;AccountName={0};SharedAccessSignature={1};EndpointSuffix={2};" + endpointCombination[0],
                        accountSasParams
                        );

                var accountStringSasSecondary =
                    string.Format(
                        "DefaultEndpointsProtocol=https;AccountName={0};SharedAccessSignature={1};EndpointSuffix={2};" + endpointCombination[1],
                        accountSasParams
                        );

                var accountStringSasPrimarySecondary =
                    string.Format(
                        "DefaultEndpointsProtocol=https;AccountName={0};SharedAccessSignature={1};EndpointSuffix={2};" + endpointCombination[2],
                        accountSasParams
                        );

                StorageConnectionString.Parse(accountStringSasPrimary); // no exception expected

                TestHelper.AssertExpectedException(
                    () => StorageConnectionString.Parse(accountStringSasSecondary),
                    new FormatException("No valid combination of account information found.")
                    );

                StorageConnectionString.Parse(accountStringSasPrimarySecondary); // no exception expected

                // SAS, no default protocol

                var accountStringSasNoDefaultProtocolPrimary =
                    string.Format(
                        "AccountName={0};SharedAccessSignature={1};EndpointSuffix={2};" + endpointCombination[0],
                        accountSasParams
                        );

                var accountStringSasNoDefaultProtocolSecondary =
                    string.Format(
                        "AccountName={0};SharedAccessSignature={1};EndpointSuffix={2};" + endpointCombination[1],
                        accountSasParams
                        );

                var accountStringSasNoDefaultProtocolPrimarySecondary =
                    string.Format(
                        "AccountName={0};SharedAccessSignature={1};EndpointSuffix={2};" + endpointCombination[2],
                        accountSasParams
                        );

                conn = StorageConnectionString.Parse(accountStringSasNoDefaultProtocolPrimary); // no exception expected

                // Sas token should be included in Query portion of Uri
                StringAssert.Contains("sasTest", conn.BlobEndpoint.Query);
                StringAssert.Contains("sasTest", conn.FileEndpoint.Query);
                StringAssert.Contains("sasTest", conn.QueueEndpoint.Query);

                TestHelper.AssertExpectedException(
                    () => StorageConnectionString.Parse(accountStringSasNoDefaultProtocolSecondary),
                    new FormatException("No valid combination of account information found.")
                    );

                StorageConnectionString.Parse(accountStringSasNoDefaultProtocolPrimarySecondary); // no exception expected

                // SAS without AccountName

                var accountStringSasNoNameNoEndpoint =
                    string.Format(
                        "SharedAccessSignature={1}",
                        accountSasParams
                        );

                var accountStringSasNoNamePrimary =
                    string.Format(
                        "SharedAccessSignature={1};" + endpointCombination[0],
                        accountSasParams
                        );

                var accountStringSasNoNameSecondary =
                    string.Format(
                        "SharedAccessSignature={1};" + endpointCombination[1],
                        accountSasParams
                        );

                var accountStringSasNoNamePrimarySecondary =
                    string.Format(
                        "SharedAccessSignature={1};" + endpointCombination[2],
                        accountSasParams
                        );

                TestHelper.AssertExpectedException(
                    () => StorageConnectionString.Parse(accountStringSasNoNameNoEndpoint),
                    new FormatException("No valid combination of account information found.")
                    );

                StorageConnectionString.Parse(accountStringSasNoNamePrimary); // no exception expected

                TestHelper.AssertExpectedException(
                    () => StorageConnectionString.Parse(accountStringSasNoNameSecondary),
                    new FormatException("No valid combination of account information found.")
                    );

                StorageConnectionString.Parse(accountStringSasNoNamePrimarySecondary); // no exception expected
            }
        }

        private void ValidateRoundTrip(string connectionString)
        {
            var parsed = StorageConnectionString.Parse(connectionString);

            var reserialized = parsed.ToString(true);

            var reparsed = StorageConnectionString.Parse(reserialized);

            // make sure it round trips
            AccountsAreEqual(parsed, reparsed);
        }

        [Test]
        [Description("TryParse should return false for invalid connection strings")]
        public void TryParseNullEmpty()
        {
            // TryParse should not throw exception when passing in null or empty string
            Assert.IsFalse(StorageConnectionString.TryParse(null, out _));
            Assert.IsFalse(StorageConnectionString.TryParse(string.Empty, out _));
        }

        [Test]
        [Description("UseDevelopmentStorage=false should fail")]
        public void DevStoreNonTrueFails() => Assert.IsFalse(StorageConnectionString.TryParse("UseDevelopmentStorage=false", out _));

        [Test]
        [Description("UseDevelopmentStorage should fail when used with an account name")]
        public void DevStorePlusAccountFails() => Assert.IsFalse(StorageConnectionString.TryParse("UseDevelopmentStorage=false;AccountName=devstoreaccount1", out _));

        [Test]
        [Description("UseDevelopmentStorage should fail when used with a custom endpoint")]
        public void DevStorePlusEndpointFails() => Assert.IsFalse(StorageConnectionString.TryParse("UseDevelopmentStorage=false;BlobEndpoint=http://127.0.0.1:1000/devstoreaccount1", out _));

        [Test]
        [Description("UseDevelopmentStorage=true should succeed")]
        public void DevStoreTrueLowerCase() => Assert.IsTrue(StorageConnectionString.TryParse("UseDevelopmentStorage=true", out _));

        [Test]
        [Description("UseDevelopmentStorage=True should succeed")]
        public void DevStoreTrueUpperCase() => Assert.IsTrue(StorageConnectionString.TryParse("UseDevelopmentStorage=True", out _));

        [Test]
        [Description("Custom endpoints")]
        public void DefaultEndpointOverride()
        {
            Assert.IsTrue(StorageConnectionString.TryParse("DefaultEndpointsProtocol=http;BlobEndpoint=http://customdomain.com/;AccountName=asdf;AccountKey=123=", out StorageConnectionString account));
            Assert.AreEqual(new Uri("http://customdomain.com/"), account.BlobEndpoint);
            Assert.IsNull(account.BlobStorageUri.SecondaryUri);
        }

        [Test]
        [Description("Use DevStore with a proxy")]
        public void DevStoreProxyUri()
        {
            Assert.IsTrue(StorageConnectionString.TryParse("UseDevelopmentStorage=true;DevelopmentStorageProxyUri=http://ipv4.fiddler", out StorageConnectionString devstoreAccount));
            Assert.AreEqual(new Uri("http://ipv4.fiddler:10000/devstoreaccount1"), devstoreAccount.BlobEndpoint);
            Assert.AreEqual(new Uri("http://ipv4.fiddler:10001/devstoreaccount1"), devstoreAccount.QueueEndpoint);
            Assert.AreEqual(new Uri("http://ipv4.fiddler:10000/devstoreaccount1"), devstoreAccount.BlobStorageUri.PrimaryUri);
            Assert.AreEqual(new Uri("http://ipv4.fiddler:10001/devstoreaccount1"), devstoreAccount.QueueStorageUri.PrimaryUri);
            Assert.AreEqual(new Uri("http://ipv4.fiddler:10000/devstoreaccount1-secondary"), devstoreAccount.BlobStorageUri.SecondaryUri);
            Assert.AreEqual(new Uri("http://ipv4.fiddler:10001/devstoreaccount1-secondary"), devstoreAccount.QueueStorageUri.SecondaryUri);
            Assert.IsNull(devstoreAccount.FileStorageUri.PrimaryUri);
            Assert.IsNull(devstoreAccount.FileStorageUri.SecondaryUri);
        }

        [Test]
        [Description("ToString method for DevStore account should not return endpoint info")]
        public void DevStoreRoundtrip()
        {
            var accountString = "UseDevelopmentStorage=true";

            Assert.AreEqual(accountString, StorageConnectionString.Parse(accountString).ToString(true));
        }

        [Test]
        [Description("ToString method for DevStore account with a proxy should not return endpoint info")]
        public void DevStoreProxyRoundtrip()
        {
            var accountString = "UseDevelopmentStorage=true;DevelopmentStorageProxyUri=http://ipv4.fiddler/";

            Assert.AreEqual(accountString, StorageConnectionString.Parse(accountString).ToString(true));
        }

        [Test]
        [Description("ToString method for regular account should return the same connection string")]
        public void DefaultCloudRoundtrip()
        {
            var accountString = "DefaultEndpointsProtocol=http;AccountName=test;AccountKey=abc=";

            Assert.AreEqual(accountString, StorageConnectionString.Parse(accountString).ToString(true));
        }

        [Test]
        [Description("ToString method for anonymous credentials should return the same connection string")]
        public void AnonymousRoundtrip()
        {
            var accountString = "BlobEndpoint=http://blobs/";

            Assert.AreEqual(accountString, StorageConnectionString.Parse(accountString).ToString(true));

            var account = new StorageConnectionString(null, (new Uri("http://blobs/"), default), (default, default), (default, default));

            AccountsAreEqual(account, StorageConnectionString.Parse(account.ToString(true)));
        }

        [Test]
        [Description("Exporting account key should be possible both as a byte array and a Base64 encoded string")]
        public void ExportKey()
        {
            var accountKeyString = "abc2564=";
            var accountString = "BlobEndpoint=http://blobs/;AccountName=test;AccountKey=" + accountKeyString;
            var account = StorageConnectionString.Parse(accountString);
            var accountAndKey = (StorageSharedKeyCredential)account.Credentials;
            var key = accountAndKey.ExportBase64EncodedKey();
            Assert.AreEqual(accountKeyString, key);

            var keyBytes = accountAndKey.GetAccountKey();
            var expectedKeyBytes = Convert.FromBase64String(accountKeyString);

            TestHelper.AssertSequenceEqual(expectedKeyBytes, keyBytes);
        }
    }
}
