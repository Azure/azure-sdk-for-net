// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.Globalization;
using System.Linq;
using Azure.Storage.Test;
using NUnit.Framework;

namespace Azure.Storage.Common.Test
{
    [TestFixture]
    public class StorageConnectionStringTests
    {
        [Test]
        [Description("StorageConnectionString object with an empty key value.")]
        public void StorageCredentialsEmptyKeyValue()
        {
            var accountName = TestConfigurations.DefaultTargetTenant.AccountName;
            _ = TestConfigurations.DefaultTargetTenant.AccountKey;
            var emptyKeyValueAsString = String.Empty;
            var emptyKeyConnectionString = String.Format(CultureInfo.InvariantCulture, "DefaultEndpointsProtocol=https;AccountName={0};AccountKey=", accountName);

            var credentials1 = new StorageSharedKeyCredential(accountName, emptyKeyValueAsString);

            var conn1 = new StorageConnectionString(credentials1, true);
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

            var isValidAccount3 = StorageConnectionString.TryParse(emptyKeyConnectionString, out var account3);
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
            Assert.AreEqual(a.TableEndpoint, b.TableEndpoint);
            Assert.AreEqual(a.FileEndpoint, b.FileEndpoint);

            // storage uris are the same
            Assert.AreEqual(a.BlobStorageUri, b.BlobStorageUri);
            Assert.AreEqual(a.QueueStorageUri, b.QueueStorageUri);
            Assert.AreEqual(a.TableStorageUri, b.TableStorageUri);
            Assert.AreEqual(a.FileStorageUri, b.FileStorageUri);

            // seralized representatons are the same.
            var aToStringNoSecrets = a.ToString();
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
            var devstoreAccount = StorageConnectionString.DevelopmentStorageAccount;
            Assert.AreEqual(new Uri("http://127.0.0.1:10000/devstoreaccount1"), devstoreAccount.BlobEndpoint);
            Assert.AreEqual(new Uri("http://127.0.0.1:10001/devstoreaccount1"), devstoreAccount.QueueEndpoint);
            Assert.AreEqual(new Uri("http://127.0.0.1:10002/devstoreaccount1"), devstoreAccount.TableEndpoint);
            Assert.AreEqual(new Uri("http://127.0.0.1:10000/devstoreaccount1"), devstoreAccount.BlobStorageUri.PrimaryUri);
            Assert.AreEqual(new Uri("http://127.0.0.1:10001/devstoreaccount1"), devstoreAccount.QueueStorageUri.PrimaryUri);
            Assert.AreEqual(new Uri("http://127.0.0.1:10002/devstoreaccount1"), devstoreAccount.TableStorageUri.PrimaryUri);
            Assert.AreEqual(new Uri("http://127.0.0.1:10000/devstoreaccount1-secondary"), devstoreAccount.BlobStorageUri.SecondaryUri);
            Assert.AreEqual(new Uri("http://127.0.0.1:10001/devstoreaccount1-secondary"), devstoreAccount.QueueStorageUri.SecondaryUri);
            Assert.AreEqual(new Uri("http://127.0.0.1:10002/devstoreaccount1-secondary"), devstoreAccount.TableStorageUri.SecondaryUri);
            Assert.IsNull(devstoreAccount.FileStorageUri.PrimaryUri);
            Assert.IsNull(devstoreAccount.FileStorageUri.SecondaryUri);

            var devstoreAccountToStringWithSecrets = devstoreAccount.ToString(true);
            var testAccount = StorageConnectionString.Parse(devstoreAccountToStringWithSecrets);

            this.AccountsAreEqual(testAccount, devstoreAccount);
            if (!StorageConnectionString.TryParse(devstoreAccountToStringWithSecrets, out _))
            {
                Assert.Fail("Expected TryParse success.");
            }
        }

        [Test]
        [Description("Regular account with HTTP")]
        public void DefaultStorageAccountWithHttp()
        {
            var cred = new StorageSharedKeyCredential(TestConfigurations.DefaultTargetTenant.AccountName, TestConfigurations.DefaultTargetTenant.AccountKey);
            var conn = new StorageConnectionString(cred, false);
            Assert.AreEqual(conn.BlobEndpoint,
                new Uri(String.Format("http://{0}.blob.core.windows.net", TestConfigurations.DefaultTargetTenant.AccountName)));
            Assert.AreEqual(conn.QueueEndpoint,
                new Uri(String.Format("http://{0}.queue.core.windows.net", TestConfigurations.DefaultTargetTenant.AccountName)));
            Assert.AreEqual(conn.TableEndpoint,
                new Uri(String.Format("http://{0}.table.core.windows.net", TestConfigurations.DefaultTargetTenant.AccountName)));
            Assert.AreEqual(conn.FileEndpoint,
                new Uri(String.Format("http://{0}.file.core.windows.net", TestConfigurations.DefaultTargetTenant.AccountName)));
            Assert.AreEqual(conn.BlobStorageUri.SecondaryUri,
                new Uri(String.Format("http://{0}-secondary.blob.core.windows.net", TestConfigurations.DefaultTargetTenant.AccountName)));
            Assert.AreEqual(conn.QueueStorageUri.SecondaryUri,
                new Uri(String.Format("http://{0}-secondary.queue.core.windows.net", TestConfigurations.DefaultTargetTenant.AccountName)));
            Assert.AreEqual(conn.TableStorageUri.SecondaryUri,
                new Uri(String.Format("http://{0}-secondary.table.core.windows.net", TestConfigurations.DefaultTargetTenant.AccountName)));
            Assert.AreEqual(conn.FileStorageUri.SecondaryUri,
                new Uri(String.Format("http://{0}-secondary.file.core.windows.net", TestConfigurations.DefaultTargetTenant.AccountName)));
            _ = conn.ToString();
            var storageConnectionStringToStringWithSecrets = conn.ToString(true);
            var testAccount = StorageConnectionString.Parse(storageConnectionStringToStringWithSecrets);

            this.AccountsAreEqual(testAccount, conn);
        }

        [Test]
        [Description("Regular account with HTTPS")]
        public void DefaultStorageAccountWithHttps()
        {
            var cred = new StorageSharedKeyCredential(TestConfigurations.DefaultTargetTenant.AccountName, TestConfigurations.DefaultTargetTenant.AccountKey);
            var conn = new StorageConnectionString(cred, true);
            Assert.AreEqual(conn.BlobEndpoint,
                new Uri(String.Format("https://{0}.blob.core.windows.net", TestConfigurations.DefaultTargetTenant.AccountName)));
            Assert.AreEqual(conn.QueueEndpoint,
                new Uri(String.Format("https://{0}.queue.core.windows.net", TestConfigurations.DefaultTargetTenant.AccountName)));
            Assert.AreEqual(conn.TableEndpoint,
                new Uri(String.Format("https://{0}.table.core.windows.net", TestConfigurations.DefaultTargetTenant.AccountName)));
            Assert.AreEqual(conn.FileEndpoint,
                new Uri(String.Format("https://{0}.file.core.windows.net", TestConfigurations.DefaultTargetTenant.AccountName)));
            Assert.AreEqual(conn.BlobStorageUri.SecondaryUri,
                new Uri(String.Format("https://{0}-secondary.blob.core.windows.net", TestConfigurations.DefaultTargetTenant.AccountName)));
            Assert.AreEqual(conn.QueueStorageUri.SecondaryUri,
                new Uri(String.Format("https://{0}-secondary.queue.core.windows.net", TestConfigurations.DefaultTargetTenant.AccountName)));
            Assert.AreEqual(conn.TableStorageUri.SecondaryUri,
                new Uri(String.Format("https://{0}-secondary.table.core.windows.net", TestConfigurations.DefaultTargetTenant.AccountName)));
            Assert.AreEqual(conn.FileStorageUri.SecondaryUri,
                new Uri(String.Format("https://{0}-secondary.file.core.windows.net", TestConfigurations.DefaultTargetTenant.AccountName)));

            var storageConnectionStringToStringWithSecrets = conn.ToString(true);
            var testAccount = StorageConnectionString.Parse(storageConnectionStringToStringWithSecrets);

            this.AccountsAreEqual(testAccount, conn);
        }

        [Test]
        [Description("Regular account with HTTP")]
        public void EndpointSuffixWithHttp()
        {
            const string TestEndpointSuffix = "fake.endpoint.suffix";

            var conn = StorageConnectionString.Parse(
                String.Format(
                    "DefaultEndpointsProtocol=http;AccountName={0};AccountKey={1};EndpointSuffix={2};",
                    TestConfigurations.DefaultTargetTenant.AccountName,
                    TestConfigurations.DefaultTargetTenant.AccountKey,
                    TestEndpointSuffix));

            Assert.AreEqual(conn.BlobEndpoint,
                new Uri(String.Format("http://{0}.blob.{1}", TestConfigurations.DefaultTargetTenant.AccountName, TestEndpointSuffix)));
            Assert.AreEqual(conn.QueueEndpoint,
                new Uri(String.Format("http://{0}.queue.{1}", TestConfigurations.DefaultTargetTenant.AccountName, TestEndpointSuffix)));
            Assert.AreEqual(conn.TableEndpoint,
                new Uri(String.Format("http://{0}.table.{1}", TestConfigurations.DefaultTargetTenant.AccountName, TestEndpointSuffix)));
            Assert.AreEqual(conn.FileEndpoint,
                new Uri(String.Format("http://{0}.file.{1}", TestConfigurations.DefaultTargetTenant.AccountName, TestEndpointSuffix)));
            Assert.AreEqual(conn.BlobStorageUri.SecondaryUri,
                new Uri(String.Format("http://{0}-secondary.blob.{1}", TestConfigurations.DefaultTargetTenant.AccountName, TestEndpointSuffix)));
            Assert.AreEqual(conn.QueueStorageUri.SecondaryUri,
                new Uri(String.Format("http://{0}-secondary.queue.{1}", TestConfigurations.DefaultTargetTenant.AccountName, TestEndpointSuffix)));
            Assert.AreEqual(conn.TableStorageUri.SecondaryUri,
                new Uri(String.Format("http://{0}-secondary.table.{1}", TestConfigurations.DefaultTargetTenant.AccountName, TestEndpointSuffix)));
            Assert.AreEqual(conn.FileStorageUri.SecondaryUri,
               new Uri(String.Format("http://{0}-secondary.file.{1}", TestConfigurations.DefaultTargetTenant.AccountName, TestEndpointSuffix)));

            var storageConnectionStringToStringWithSecrets = conn.ToString(true);
            var testAccount = StorageConnectionString.Parse(storageConnectionStringToStringWithSecrets);

            this.AccountsAreEqual(testAccount, conn);
        }

        [Test]
        [Description("Regular account with HTTPS")]
        public void EndpointSuffixWithHttps()
        {
            const string TestEndpointSuffix = "fake.endpoint.suffix";

            var conn = StorageConnectionString.Parse(
                String.Format(
                    "DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1};EndpointSuffix={2};",
                    TestConfigurations.DefaultTargetTenant.AccountName,
                    TestConfigurations.DefaultTargetTenant.AccountKey,
                    TestEndpointSuffix));

            Assert.AreEqual(conn.BlobEndpoint,
                new Uri(String.Format("https://{0}.blob.{1}", TestConfigurations.DefaultTargetTenant.AccountName, TestEndpointSuffix)));
            Assert.AreEqual(conn.QueueEndpoint,
                new Uri(String.Format("https://{0}.queue.{1}", TestConfigurations.DefaultTargetTenant.AccountName, TestEndpointSuffix)));
            Assert.AreEqual(conn.TableEndpoint,
                new Uri(String.Format("https://{0}.table.{1}", TestConfigurations.DefaultTargetTenant.AccountName, TestEndpointSuffix)));
            Assert.AreEqual(conn.FileEndpoint,
                new Uri(String.Format("https://{0}.file.{1}", TestConfigurations.DefaultTargetTenant.AccountName, TestEndpointSuffix)));
            Assert.AreEqual(conn.BlobStorageUri.SecondaryUri,
                new Uri(String.Format("https://{0}-secondary.blob.{1}", TestConfigurations.DefaultTargetTenant.AccountName, TestEndpointSuffix)));
            Assert.AreEqual(conn.QueueStorageUri.SecondaryUri,
                new Uri(String.Format("https://{0}-secondary.queue.{1}", TestConfigurations.DefaultTargetTenant.AccountName, TestEndpointSuffix)));
            Assert.AreEqual(conn.TableStorageUri.SecondaryUri,
                new Uri(String.Format("https://{0}-secondary.table.{1}", TestConfigurations.DefaultTargetTenant.AccountName, TestEndpointSuffix)));
            Assert.AreEqual(conn.FileStorageUri.SecondaryUri,
                new Uri(String.Format("https://{0}-secondary.file.{1}", TestConfigurations.DefaultTargetTenant.AccountName, TestEndpointSuffix)));

            var storageConnectionStringToStringWithSecrets = conn.ToString(true);
            var testAccount = StorageConnectionString.Parse(storageConnectionStringToStringWithSecrets);

            this.AccountsAreEqual(testAccount, conn);
        }

        [Test]
        [Description("Regular account with HTTP")]
        public void EndpointSuffixWithBlob()
        {
            const string TestEndpointSuffix = "fake.endpoint.suffix";
            const string AlternateBlobEndpoint = "http://blob.other.endpoint/";

            var testAccount =
                StorageConnectionString.Parse(
                    global::System.String.Format(
                        "DefaultEndpointsProtocol=http;AccountName={0};AccountKey={1};EndpointSuffix={2};BlobEndpoint={3}",
                        TestConfigurations.DefaultTargetTenant.AccountName,
                        TestConfigurations.DefaultTargetTenant.AccountKey,
                        TestEndpointSuffix,
                        AlternateBlobEndpoint));

            var conn = StorageConnectionString.Parse(testAccount.ToString(true));

            // make sure it round trips
            this.AccountsAreEqual(testAccount, conn);
        }

        [Test]
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
                String.Format(
                    "DefaultEndpointsProtocol=http;AccountName={0};AccountKey={1};EndpointSuffix={2};",
                    accountKeyParams);

            var accountString2 =
                String.Format(
                    "DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1};",
                    accountKeyParams);

            var accountString3 =
                String.Format(
                    "DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1};QueueEndpoint={3}",
                    accountKeyParams);

            var accountString4 =
                String.Format(
                    "DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1};EndpointSuffix={2};QueueEndpoint={3}",
                    accountKeyParams);

            this.ValidateRoundTrip(accountString1);
            this.ValidateRoundTrip(accountString2);
            this.ValidateRoundTrip(accountString3);
            this.ValidateRoundTrip(accountString4);

            var accountString5 =
                String.Format(
                    "AccountName={0};AccountKey={1};EndpointSuffix={2};",
                    accountKeyParams);

            var accountString6 =
                String.Format(
                    "AccountName={0};AccountKey={1};",
                    accountKeyParams);

            var accountString7 =
                String.Format(
                    "AccountName={0};AccountKey={1};QueueEndpoint={3}",
                    accountKeyParams);

            var accountString8 =
                String.Format(
                    "AccountName={0};AccountKey={1};EndpointSuffix={2};QueueEndpoint={3}",
                    accountKeyParams);

            this.ValidateRoundTrip(accountString5);
            this.ValidateRoundTrip(accountString6);
            this.ValidateRoundTrip(accountString7);
            this.ValidateRoundTrip(accountString8);

            // shared access

            var accountString9 =
                String.Format(
                    "DefaultEndpointsProtocol=http;AccountName={0};SharedAccessSignature={1};EndpointSuffix={2};",
                    accountSasParams);

            var accountString10 =
                String.Format(
                    "DefaultEndpointsProtocol=https;AccountName={0};SharedAccessSignature={1};",
                    accountSasParams);

            var accountString11 =
                String.Format(
                    "DefaultEndpointsProtocol=https;AccountName={0};SharedAccessSignature={1};QueueEndpoint={3}",
                    accountSasParams);

            var accountString12 =
                String.Format(
                    "DefaultEndpointsProtocol=https;AccountName={0};SharedAccessSignature={1};EndpointSuffix={2};QueueEndpoint={3}",
                    accountSasParams);

            this.ValidateRoundTrip(accountString9);
            this.ValidateRoundTrip(accountString10);
            this.ValidateRoundTrip(accountString11);
            this.ValidateRoundTrip(accountString12);

            var accountString13 =
                String.Format(
                    "AccountName={0};SharedAccessSignature={1};EndpointSuffix={2};",
                    accountSasParams);

            var accountString14 =
                String.Format(
                    "AccountName={0};SharedAccessSignature={1};",
                    accountSasParams);

            var accountString15 =
                String.Format(
                    "AccountName={0};SharedAccessSignature={1};QueueEndpoint={3}",
                    accountSasParams);

            var accountString16 =
                String.Format(
                    "AccountName={0};SharedAccessSignature={1};EndpointSuffix={2};QueueEndpoint={3}",
                    accountSasParams);

            this.ValidateRoundTrip(accountString13);
            this.ValidateRoundTrip(accountString14);
            this.ValidateRoundTrip(accountString15);
            this.ValidateRoundTrip(accountString16);

            // shared access no account name

            var accountString17 =
                String.Format(
                    "SharedAccessSignature={1};QueueEndpoint={3}",
                    accountSasParams);

            this.ValidateRoundTrip(accountString17);
        }

        [Test]
        [Description("Regular account with HTTP")]
        public void ValidateExpectedExceptions()
        {
            var endpointCombinations = new[]
                {
                    new[] { "BlobEndpoint={3}", "BlobSecondaryEndpoint={4}", "BlobEndpoint={3};BlobSecondaryEndpoint={4}" },
                    new[] { "QueueEndpoint={3}", "QueueSecondaryEndpoint={4}", "QueueEndpoint={3};QueueSecondaryEndpoint={4}" },
                    new[] { "TableEndpoint={3}", "TableSecondaryEndpoint={4}", "TableEndpoint={3};TableSecondaryEndpoint={4}" },
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
                    String.Format(
                        "DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1};EndpointSuffix={2};" + endpointCombination[0],
                        accountKeyParams
                        );

                var accountStringKeySecondary =
                    String.Format(
                        "DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1};EndpointSuffix={2};" + endpointCombination[1],
                        accountKeyParams
                        );


                var accountStringKeyPrimarySecondary =
                    String.Format(
                        "DefaultEndpointsProtocol=https;AccountName={0};AccountKey={1};EndpointSuffix={2};" + endpointCombination[2],
                        accountKeyParams
                        );


                StorageConnectionString.Parse(accountStringKeyPrimary); // no exception expected

                TestHelper.AssertExpectedException(
                    () => StorageConnectionString.Parse(accountStringKeySecondary),
                    new FormatException("No valid combination of account information found.")
                    );

                StorageConnectionString.Parse(accountStringKeyPrimarySecondary); // no exception expected

                // account key, no default protocol

                var accountStringKeyNoDefaultProtocolPrimary =
                    String.Format(
                        "AccountName={0};AccountKey={1};EndpointSuffix={2};" + endpointCombination[0],
                        accountKeyParams
                        );

                var accountStringKeyNoDefaultProtocolSecondary =
                    String.Format(
                        "AccountName={0};AccountKey={1};EndpointSuffix={2};" + endpointCombination[1],
                        accountKeyParams
                        );


                var accountStringKeyNoDefaultProtocolPrimarySecondary =
                    String.Format(
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
                    String.Format(
                        "DefaultEndpointsProtocol=https;AccountName={0};SharedAccessSignature={1};EndpointSuffix={2};" + endpointCombination[0],
                        accountSasParams
                        );

                var accountStringSasSecondary =
                    String.Format(
                        "DefaultEndpointsProtocol=https;AccountName={0};SharedAccessSignature={1};EndpointSuffix={2};" + endpointCombination[1],
                        accountSasParams
                        );

                var accountStringSasPrimarySecondary =
                    String.Format(
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
                    String.Format(
                        "AccountName={0};SharedAccessSignature={1};EndpointSuffix={2};" + endpointCombination[0],
                        accountSasParams
                        );

                var accountStringSasNoDefaultProtocolSecondary =
                    String.Format(
                        "AccountName={0};SharedAccessSignature={1};EndpointSuffix={2};" + endpointCombination[1],
                        accountSasParams
                        );

                var accountStringSasNoDefaultProtocolPrimarySecondary =
                    String.Format(
                        "AccountName={0};SharedAccessSignature={1};EndpointSuffix={2};" + endpointCombination[2],
                        accountSasParams
                        );

                StorageConnectionString.Parse(accountStringSasNoDefaultProtocolPrimary); // no exception expected

                TestHelper.AssertExpectedException(
                    () => StorageConnectionString.Parse(accountStringSasNoDefaultProtocolSecondary),
                    new FormatException("No valid combination of account information found.")
                    );

                StorageConnectionString.Parse(accountStringSasNoDefaultProtocolPrimarySecondary); // no exception expected

                // SAS without AccountName

                var accountStringSasNoNameNoEndpoint =
                    String.Format(
                        "SharedAccessSignature={1}",
                        accountSasParams
                        );

                var accountStringSasNoNamePrimary =
                    String.Format(
                        "SharedAccessSignature={1};" + endpointCombination[0],
                        accountSasParams
                        );

                var accountStringSasNoNameSecondary =
                    String.Format(
                        "SharedAccessSignature={1};" + endpointCombination[1],
                        accountSasParams
                        );

                var accountStringSasNoNamePrimarySecondary =
                    String.Format(
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
            this.AccountsAreEqual(parsed, reparsed);
        }

        [Test]
        [Description("TryParse should return false for invalid connection strings")]
        public void TryParseNullEmpty()
        {
            // TryParse should not throw exception when passing in null or empty string
            Assert.IsFalse(StorageConnectionString.TryParse(null, out _));
            Assert.IsFalse(StorageConnectionString.TryParse(String.Empty, out _));
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
        [Description("Custom endpoints")]
        public void DefaultEndpointOverride()
        {

            Assert.IsTrue(StorageConnectionString.TryParse("DefaultEndpointsProtocol=http;BlobEndpoint=http://customdomain.com/;AccountName=asdf;AccountKey=123=", out var account));
            Assert.AreEqual(new Uri("http://customdomain.com/"), account.BlobEndpoint);
            Assert.IsNull(account.BlobStorageUri.SecondaryUri);
        }

        [Test]
        [Description("Use DevStore with a proxy")]
        public void DevStoreProxyUri()
        {
            Assert.IsTrue(StorageConnectionString.TryParse("UseDevelopmentStorage=true;DevelopmentStorageProxyUri=http://ipv4.fiddler", out var devstoreAccount));
            Assert.AreEqual(new Uri("http://ipv4.fiddler:10000/devstoreaccount1"), devstoreAccount.BlobEndpoint);
            Assert.AreEqual(new Uri("http://ipv4.fiddler:10001/devstoreaccount1"), devstoreAccount.QueueEndpoint);
            Assert.AreEqual(new Uri("http://ipv4.fiddler:10002/devstoreaccount1"), devstoreAccount.TableEndpoint);
            Assert.AreEqual(new Uri("http://ipv4.fiddler:10000/devstoreaccount1"), devstoreAccount.BlobStorageUri.PrimaryUri);
            Assert.AreEqual(new Uri("http://ipv4.fiddler:10001/devstoreaccount1"), devstoreAccount.QueueStorageUri.PrimaryUri);
            Assert.AreEqual(new Uri("http://ipv4.fiddler:10002/devstoreaccount1"), devstoreAccount.TableStorageUri.PrimaryUri);
            Assert.AreEqual(new Uri("http://ipv4.fiddler:10000/devstoreaccount1-secondary"), devstoreAccount.BlobStorageUri.SecondaryUri);
            Assert.AreEqual(new Uri("http://ipv4.fiddler:10001/devstoreaccount1-secondary"), devstoreAccount.QueueStorageUri.SecondaryUri);
            Assert.AreEqual(new Uri("http://ipv4.fiddler:10002/devstoreaccount1-secondary"), devstoreAccount.TableStorageUri.SecondaryUri);
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

            var account = new StorageConnectionString(null, new Uri("http://blobs/"), null, null, null);

            this.AccountsAreEqual(account, StorageConnectionString.Parse(account.ToString(true)));
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

            var keyBytes = accountAndKey.AccountKeyValue;
            var expectedKeyBytes = Convert.FromBase64String(accountKeyString);

            TestHelper.AssertSequenceEqual(expectedKeyBytes, keyBytes);
        }
    }

}
