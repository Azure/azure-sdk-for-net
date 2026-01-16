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
            Assert.That(conn1.ToString(true), Is.EqualTo(emptyKeyConnectionString));
            Assert.That(conn1.Credentials, Is.Not.Null);
            Assert.That(conn1.Credentials, Is.InstanceOf(typeof(StorageSharedKeyCredential)));
            Assert.That(((StorageSharedKeyCredential)conn1.Credentials).AccountName, Is.EqualTo(accountName));
            Assert.That(((StorageSharedKeyCredential)conn1.Credentials).ExportBase64EncodedKey(), Is.EqualTo(emptyKeyValueAsString));

            var account2 = StorageConnectionString.Parse(emptyKeyConnectionString);
            Assert.That(account2.ToString(true), Is.EqualTo(emptyKeyConnectionString));
            Assert.That(account2.Credentials, Is.Not.Null);
            Assert.That(account2.Credentials, Is.InstanceOf(typeof(StorageSharedKeyCredential)));
            Assert.That(((StorageSharedKeyCredential)account2.Credentials).AccountName, Is.EqualTo(accountName));
            Assert.That(((StorageSharedKeyCredential)account2.Credentials).ExportBase64EncodedKey(), Is.EqualTo(emptyKeyValueAsString));

            var isValidAccount3 = StorageConnectionString.TryParse(emptyKeyConnectionString, out StorageConnectionString account3);
            Assert.That(isValidAccount3, Is.True);
            Assert.That(account3, Is.Not.Null);
            Assert.That(account3.ToString(true), Is.EqualTo(emptyKeyConnectionString));
            Assert.That(account3.Credentials, Is.Not.Null);
            Assert.That(account3.Credentials, Is.InstanceOf(typeof(StorageSharedKeyCredential)));
            Assert.That(((StorageSharedKeyCredential)account3.Credentials).AccountName, Is.EqualTo(accountName));
            Assert.That(((StorageSharedKeyCredential)account3.Credentials).ExportBase64EncodedKey(), Is.EqualTo(emptyKeyValueAsString));
        }

        private void AccountsAreEqual(StorageConnectionString a, StorageConnectionString b)
        {
            // endpoints are the same
            Assert.That(b.BlobEndpoint, Is.EqualTo(a.BlobEndpoint));
            Assert.That(b.QueueEndpoint, Is.EqualTo(a.QueueEndpoint));
            Assert.That(b.FileEndpoint, Is.EqualTo(a.FileEndpoint));

            // storage uris are the same
            Assert.That(b.BlobStorageUri, Is.EqualTo(a.BlobStorageUri));
            Assert.That(b.QueueStorageUri, Is.EqualTo(a.QueueStorageUri));
            Assert.That(b.FileStorageUri, Is.EqualTo(a.FileStorageUri));

            // seralized representatons are the same.
            var aToStringNoSecrets = a.ToString(false);
            var aToStringWithSecrets = a.ToString(true);
            var bToStringNoSecrets = b.ToString(false);
            var bToStringWithSecrets = b.ToString(true);
            Assert.That(bToStringNoSecrets, Is.EqualTo(aToStringNoSecrets));
            Assert.That(bToStringWithSecrets, Is.EqualTo(aToStringWithSecrets));

            // credentials are the same
            if (a.Credentials != null && b.Credentials != null)
            {
                Assert.That(b.GetType(), Is.EqualTo(a.GetType()));

                // make sure
                if (a.Credentials != StorageConnectionString.DevelopmentStorageAccount.Credentials &&
                    b.Credentials != StorageConnectionString.DevelopmentStorageAccount.Credentials)
                {
                    Assert.That(bToStringNoSecrets, Is.Not.EqualTo(aToStringWithSecrets).IgnoreCase);
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
            Assert.That(devstoreAccount.BlobEndpoint, Is.EqualTo(new Uri("http://127.0.0.1:10000/devstoreaccount1")));
            Assert.That(devstoreAccount.QueueEndpoint, Is.EqualTo(new Uri("http://127.0.0.1:10001/devstoreaccount1")));
            Assert.That(devstoreAccount.BlobStorageUri.PrimaryUri, Is.EqualTo(new Uri("http://127.0.0.1:10000/devstoreaccount1")));
            Assert.That(devstoreAccount.QueueStorageUri.PrimaryUri, Is.EqualTo(new Uri("http://127.0.0.1:10001/devstoreaccount1")));
            Assert.That(devstoreAccount.BlobStorageUri.SecondaryUri, Is.EqualTo(new Uri("http://127.0.0.1:10000/devstoreaccount1-secondary")));
            Assert.That(devstoreAccount.QueueStorageUri.SecondaryUri, Is.EqualTo(new Uri("http://127.0.0.1:10001/devstoreaccount1-secondary")));
            Assert.That(devstoreAccount.FileStorageUri.PrimaryUri, Is.Null);
            Assert.That(devstoreAccount.FileStorageUri.SecondaryUri, Is.Null);

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
            Assert.That(new Uri(string.Format("http://{0}.blob.core.windows.net", TestConfigurations.DefaultTargetTenant.AccountName)),
                Is.EqualTo(conn.BlobEndpoint));
            Assert.That(new Uri(string.Format("http://{0}.queue.core.windows.net", TestConfigurations.DefaultTargetTenant.AccountName)),
                Is.EqualTo(conn.QueueEndpoint));
            Assert.That(new Uri(string.Format("http://{0}.file.core.windows.net", TestConfigurations.DefaultTargetTenant.AccountName)),
                Is.EqualTo(conn.FileEndpoint));
            Assert.That(new Uri(string.Format("http://{0}-secondary.blob.core.windows.net", TestConfigurations.DefaultTargetTenant.AccountName)),
                Is.EqualTo(conn.BlobStorageUri.SecondaryUri));
            Assert.That(new Uri(string.Format("http://{0}-secondary.queue.core.windows.net", TestConfigurations.DefaultTargetTenant.AccountName)),
                Is.EqualTo(conn.QueueStorageUri.SecondaryUri));
            Assert.That(new Uri(string.Format("http://{0}-secondary.file.core.windows.net", TestConfigurations.DefaultTargetTenant.AccountName)),
                Is.EqualTo(conn.FileStorageUri.SecondaryUri));
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
            Assert.That(new Uri(string.Format("https://{0}.blob.core.windows.net", TestConfigurations.DefaultTargetTenant.AccountName)),
                Is.EqualTo(conn.BlobEndpoint));
            Assert.That(new Uri(string.Format("https://{0}.queue.core.windows.net", TestConfigurations.DefaultTargetTenant.AccountName)),
                Is.EqualTo(conn.QueueEndpoint));
            Assert.That(new Uri(string.Format("https://{0}.file.core.windows.net", TestConfigurations.DefaultTargetTenant.AccountName)),
                Is.EqualTo(conn.FileEndpoint));
            Assert.That(new Uri(string.Format("https://{0}-secondary.blob.core.windows.net", TestConfigurations.DefaultTargetTenant.AccountName)),
                Is.EqualTo(conn.BlobStorageUri.SecondaryUri));
            Assert.That(new Uri(string.Format("https://{0}-secondary.queue.core.windows.net", TestConfigurations.DefaultTargetTenant.AccountName)),
                Is.EqualTo(conn.QueueStorageUri.SecondaryUri));
            Assert.That(new Uri(string.Format("https://{0}-secondary.file.core.windows.net", TestConfigurations.DefaultTargetTenant.AccountName)),
                Is.EqualTo(conn.FileStorageUri.SecondaryUri));

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

            Assert.That(new Uri(string.Format("http://{0}.blob.{1}", TestConfigurations.DefaultTargetTenant.AccountName, TestEndpointSuffix)),
                Is.EqualTo(conn.BlobEndpoint));
            Assert.That(new Uri(string.Format("http://{0}.queue.{1}", TestConfigurations.DefaultTargetTenant.AccountName, TestEndpointSuffix)),
                Is.EqualTo(conn.QueueEndpoint));
            Assert.That(new Uri(string.Format("http://{0}.file.{1}", TestConfigurations.DefaultTargetTenant.AccountName, TestEndpointSuffix)),
                Is.EqualTo(conn.FileEndpoint));
            Assert.That(new Uri(string.Format("http://{0}-secondary.blob.{1}", TestConfigurations.DefaultTargetTenant.AccountName, TestEndpointSuffix)),
                Is.EqualTo(conn.BlobStorageUri.SecondaryUri));
            Assert.That(new Uri(string.Format("http://{0}-secondary.queue.{1}", TestConfigurations.DefaultTargetTenant.AccountName, TestEndpointSuffix)),
                Is.EqualTo(conn.QueueStorageUri.SecondaryUri));
            Assert.That(new Uri(string.Format("http://{0}-secondary.file.{1}", TestConfigurations.DefaultTargetTenant.AccountName, TestEndpointSuffix)),
               Is.EqualTo(conn.FileStorageUri.SecondaryUri));

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

            Assert.That(new Uri(string.Format("https://{0}.blob.{1}", TestConfigurations.DefaultTargetTenant.AccountName, TestEndpointSuffix)),
                Is.EqualTo(conn.BlobEndpoint));
            Assert.That(new Uri(string.Format("https://{0}.queue.{1}", TestConfigurations.DefaultTargetTenant.AccountName, TestEndpointSuffix)),
                Is.EqualTo(conn.QueueEndpoint));
            Assert.That(new Uri(string.Format("https://{0}.file.{1}", TestConfigurations.DefaultTargetTenant.AccountName, TestEndpointSuffix)),
                Is.EqualTo(conn.FileEndpoint));
            Assert.That(new Uri(string.Format("https://{0}-secondary.blob.{1}", TestConfigurations.DefaultTargetTenant.AccountName, TestEndpointSuffix)),
                Is.EqualTo(conn.BlobStorageUri.SecondaryUri));
            Assert.That(new Uri(string.Format("https://{0}-secondary.queue.{1}", TestConfigurations.DefaultTargetTenant.AccountName, TestEndpointSuffix)),
                Is.EqualTo(conn.QueueStorageUri.SecondaryUri));
            Assert.That(new Uri(string.Format("https://{0}-secondary.file.{1}", TestConfigurations.DefaultTargetTenant.AccountName, TestEndpointSuffix)),
                Is.EqualTo(conn.FileStorageUri.SecondaryUri));

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
                Assert.That(conn.BlobEndpoint.Query, Is.Empty);
                Assert.That(conn.FileEndpoint.Query, Is.Empty);
                Assert.That(conn.QueueEndpoint.Query, Is.Empty);

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
                Assert.That(conn.BlobEndpoint.Query, Does.Contain("sasTest"));
                Assert.That(conn.FileEndpoint.Query, Does.Contain("sasTest"));
                Assert.That(conn.QueueEndpoint.Query, Does.Contain("sasTest"));

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
            Assert.That(StorageConnectionString.TryParse(null, out _), Is.False);
            Assert.That(StorageConnectionString.TryParse(string.Empty, out _), Is.False);
        }

        [Test]
        [Description("UseDevelopmentStorage=false should fail")]
        public void DevStoreNonTrueFails() => Assert.That(StorageConnectionString.TryParse("UseDevelopmentStorage=false", out _), Is.False);

        [Test]
        [Description("UseDevelopmentStorage should fail when used with an account name")]
        public void DevStorePlusAccountFails() => Assert.That(StorageConnectionString.TryParse("UseDevelopmentStorage=false;AccountName=devstoreaccount1", out _), Is.False);

        [Test]
        [Description("UseDevelopmentStorage should fail when used with a custom endpoint")]
        public void DevStorePlusEndpointFails() => Assert.That(StorageConnectionString.TryParse("UseDevelopmentStorage=false;BlobEndpoint=http://127.0.0.1:1000/devstoreaccount1", out _), Is.False);

        [Test]
        [Description("UseDevelopmentStorage=true should succeed")]
        public void DevStoreTrueLowerCase() => Assert.That(StorageConnectionString.TryParse("UseDevelopmentStorage=true", out _), Is.True);

        [Test]
        [Description("UseDevelopmentStorage=True should succeed")]
        public void DevStoreTrueUpperCase() => Assert.That(StorageConnectionString.TryParse("UseDevelopmentStorage=True", out _), Is.True);

        [Test]
        [Description("Custom endpoints")]
        public void DefaultEndpointOverride()
        {
            Assert.That(StorageConnectionString.TryParse("DefaultEndpointsProtocol=http;BlobEndpoint=http://customdomain.com/;AccountName=asdf;AccountKey=123=", out StorageConnectionString account), Is.True);
            Assert.That(account.BlobEndpoint, Is.EqualTo(new Uri("http://customdomain.com/")));
            Assert.That(account.BlobStorageUri.SecondaryUri, Is.Null);
        }

        [Test]
        [Description("Use DevStore with a proxy")]
        public void DevStoreProxyUri()
        {
            Assert.That(StorageConnectionString.TryParse("UseDevelopmentStorage=true;DevelopmentStorageProxyUri=http://ipv4.fiddler", out StorageConnectionString devstoreAccount), Is.True);
            Assert.That(devstoreAccount.BlobEndpoint, Is.EqualTo(new Uri("http://ipv4.fiddler:10000/devstoreaccount1")));
            Assert.That(devstoreAccount.QueueEndpoint, Is.EqualTo(new Uri("http://ipv4.fiddler:10001/devstoreaccount1")));
            Assert.That(devstoreAccount.BlobStorageUri.PrimaryUri, Is.EqualTo(new Uri("http://ipv4.fiddler:10000/devstoreaccount1")));
            Assert.That(devstoreAccount.QueueStorageUri.PrimaryUri, Is.EqualTo(new Uri("http://ipv4.fiddler:10001/devstoreaccount1")));
            Assert.That(devstoreAccount.BlobStorageUri.SecondaryUri, Is.EqualTo(new Uri("http://ipv4.fiddler:10000/devstoreaccount1-secondary")));
            Assert.That(devstoreAccount.QueueStorageUri.SecondaryUri, Is.EqualTo(new Uri("http://ipv4.fiddler:10001/devstoreaccount1-secondary")));
            Assert.That(devstoreAccount.FileStorageUri.PrimaryUri, Is.Null);
            Assert.That(devstoreAccount.FileStorageUri.SecondaryUri, Is.Null);
        }

        [Test]
        [Description("ToString method for DevStore account should not return endpoint info")]
        public void DevStoreRoundtrip()
        {
            var accountString = "UseDevelopmentStorage=true";

            Assert.That(StorageConnectionString.Parse(accountString).ToString(true), Is.EqualTo(accountString));
        }

        [Test]
        [Description("ToString method for DevStore account with a proxy should not return endpoint info")]
        public void DevStoreProxyRoundtrip()
        {
            var accountString = "UseDevelopmentStorage=true;DevelopmentStorageProxyUri=http://ipv4.fiddler/";

            Assert.That(StorageConnectionString.Parse(accountString).ToString(true), Is.EqualTo(accountString));
        }

        [Test]
        [Description("ToString method for regular account should return the same connection string")]
        public void DefaultCloudRoundtrip()
        {
            var accountString = "DefaultEndpointsProtocol=http;AccountName=test;AccountKey=abc=";

            Assert.That(StorageConnectionString.Parse(accountString).ToString(true), Is.EqualTo(accountString));
        }

        [Test]
        [Description("ToString method for anonymous credentials should return the same connection string")]
        public void AnonymousRoundtrip()
        {
            var accountString = "BlobEndpoint=http://blobs/";

            Assert.That(StorageConnectionString.Parse(accountString).ToString(true), Is.EqualTo(accountString));

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
            Assert.That(key, Is.EqualTo(accountKeyString));

            var keyBytes = accountAndKey.GetAccountKey();
            var expectedKeyBytes = Convert.FromBase64String(accountKeyString);

            TestHelper.AssertSequenceEqual(expectedKeyBytes, keyBytes);
        }
    }
}
