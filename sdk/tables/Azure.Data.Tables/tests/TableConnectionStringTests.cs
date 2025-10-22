// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace Azure.Data.Tables.Tests
{
    public class TableConnectionStringTests
    {
        private const string AccountName = "accountname";
        private const string TableName = "mytable";
        private const string SasToken = "sv=2019-12-12&ss=t&srt=s&sp=rwdlacu&se=2020-08-28T23:45:30Z&st=2020-08-26T15:45:30Z&spr=https&sig=mySig&tn=mytable";
        private const string TableSasToken = "sp=raud&st=2021-04-20T14:45:20Z&se=2021-04-21T14:45:20Z&sv=2020-02-10&sig=mySig&tn=mytable";
        private const string Secret = "Kg==";
        private readonly TableSharedKeyCredential _expectedCred = new TableSharedKeyCredential(AccountName, Secret);
        private readonly TableSharedKeyCredential _expectedDevStoraageCred = new TableSharedKeyCredential(TableConstants.ConnectionStrings.DevStoreAccountName, TableConstants.ConnectionStrings.DevStoreAccountKey);
        private const string cosmosPubDomain = "table.cosmos.azure.com";
        private const string cosmosUsSecDomain = "table.cosmos.azure.microsoft.scloud";

        /// <summary>
        /// Validates the functionality of the TableConnectionString.
        /// </summary>
        [Test]
        public void ParsesDevStorage()
        {
            var connString = $"UseDevelopmentStorage=true";

            Assert.That(TableConnectionString.TryParse(connString, out TableConnectionString tcs), "Parsing should have been successful");
            Assert.That(tcs.Credentials, Is.Not.Null);
            Assert.That(TableConnectionStringTests.GetCredString(tcs.Credentials), Is.EqualTo(TableConnectionStringTests.GetExpectedHash(_expectedDevStoraageCred)), "The Credentials should have matched.");
            Assert.That(tcs.TableStorageUri.PrimaryUri, Is.EqualTo(new Uri($"http://{TableConstants.ConnectionStrings.Localhost}:{TableConstants.ConnectionStrings.TableEndpointPortNumber}/{TableConstants.ConnectionStrings.DevStoreAccountName}")), "The PrimaryUri should have matched.");
        }

        public static IEnumerable<object[]> ValidStorageConnStrings()
        {
            yield return new object[] { $"DefaultEndpointsProtocol=https;AccountName={AccountName};AccountKey={Secret};EndpointSuffix=core.windows.net" };
            yield return new object[] { $"AccountName={AccountName};AccountKey={Secret};EndpointSuffix=core.windows.net" };
            yield return new object[] { $"DefaultEndpointsProtocol=https;AccountName={AccountName};AccountKey={Secret}" };
            yield return new object[] { $"AccountName={AccountName};AccountKey={Secret}" };
        }

        public static IEnumerable<object[]> InvalidStorageConnStrings()
        {
            yield return new object[] { $"DefaultEndpointsProtocol=https;AccountName=;AccountKey={Secret};EndpointSuffix=core.windows.net" };
            yield return new object[] { $"DefaultEndpointsProtocol=https;AccountName={AccountName};AccountKey=;EndpointSuffix=core.windows.net" };
            yield return new object[] { $"DefaultEndpointsProtocol=https;AccountName={AccountName};AccountKey={Secret};EndpointSuffix=" };
            yield return new object[] { $"AccountName={AccountName};;AccountKey={Secret};EndpointSuffix=core.windows.net" };
        }

        /// <summary>
        /// Validates the functionality of the TableConnectionString.
        /// </summary>
        [Test]
        [TestCaseSource(nameof(ValidStorageConnStrings))]
        public void TryParsesStorage(string connString)
        {
            Assert.That(TableConnectionString.TryParse(connString, out TableConnectionString tcs), "Parsing should have been successful");
            Assert.That(tcs.Credentials, Is.Not.Null);
            Assert.That(TableConnectionStringTests.GetCredString(tcs.Credentials), Is.EqualTo(TableConnectionStringTests.GetExpectedHash(_expectedCred)), "The Credentials should have matched.");
            Assert.That(tcs.TableStorageUri.PrimaryUri, Is.EqualTo(new Uri($"https://{AccountName}.table.core.windows.net/")), "The PrimaryUri should have matched.");
            Assert.That(tcs.TableStorageUri.SecondaryUri, Is.EqualTo(new Uri($"https://{AccountName}{TableConstants.ConnectionStrings.SecondaryLocationAccountSuffix}.table.core.windows.net/")), "The SecondaryUri should have matched.");
        }

        /// <summary>
        /// Validates the functionality of the TableConnectionString.
        /// </summary>
        [Test]
        [TestCaseSource(nameof(InvalidStorageConnStrings))]
        public void TryParsesInvalid(string connString)
        {
            Assert.That(!TableConnectionString.TryParse(connString, out TableConnectionString tcs), "Parsing should not have been successful");
        }

        /// <summary>
        /// Validates the functionality of the TableConnectionString.
        /// </summary>
        [Test]
        [TestCaseSource(nameof(InvalidStorageConnStrings))]
        public void ParsesInvalid(string connString)
        {
            Assert.Throws<InvalidOperationException>(() => TableConnectionString.Parse(connString), "Parsing should not have been successful");
        }
        /// <summary>
        /// Validates the functionality of the TableConnectionString.
        /// </summary>
        [Test]
        [TestCaseSource(nameof(ValidStorageConnStrings))]
        public void ParsesStorage(string connString)
        {
            var tcs = TableConnectionString.Parse(connString);

            Assert.That(tcs.Credentials, Is.Not.Null);
            Assert.That(TableConnectionStringTests.GetCredString(tcs.Credentials), Is.EqualTo(TableConnectionStringTests.GetExpectedHash(_expectedCred)), "The Credentials should have matched.");
            Assert.That(tcs.TableStorageUri.PrimaryUri, Is.EqualTo(new Uri($"https://{AccountName}.table.core.windows.net/")), "The PrimaryUri should have matched.");
            Assert.That(tcs.TableStorageUri.SecondaryUri, Is.EqualTo(new Uri($"https://{AccountName}{TableConstants.ConnectionStrings.SecondaryLocationAccountSuffix}.table.core.windows.net/")), "The SecondaryUri should have matched.");
        }

        public static IEnumerable<object[]> ValidCosmosConnStrings()
        {
            yield return new object[] { $"DefaultEndpointsProtocol=https;AccountName={AccountName};AccountKey={Secret};TableEndpoint=https://{AccountName}.{cosmosPubDomain}:443/;", cosmosPubDomain };
            yield return new object[] { $"AccountName={AccountName};AccountKey={Secret};TableEndpoint=https://{AccountName}.{cosmosPubDomain}:443/;", cosmosPubDomain };
            yield return new object[] { $"AccountName={AccountName};AccountKey={Secret};TableEndpoint=https://{AccountName}.{cosmosPubDomain}:443/;", cosmosPubDomain };
            yield return new object[] { $"DefaultEndpointsProtocol=https;AccountName={AccountName};AccountKey={Secret};TableEndpoint=https://{AccountName}.{cosmosUsSecDomain}:443/;", cosmosUsSecDomain };
            yield return new object[] { $"AccountName={AccountName};AccountKey={Secret};TableEndpoint=https://{AccountName}.{cosmosUsSecDomain}:443/;", cosmosUsSecDomain };
            yield return new object[] { $"AccountName={AccountName};AccountKey={Secret};TableEndpoint=https://{AccountName}.{cosmosUsSecDomain}:443/;", cosmosUsSecDomain };
        }

        /// <summary>
        /// Validates the functionality of the TableConnectionString.
        /// </summary>
        [Test]
        [TestCaseSource(nameof(ValidCosmosConnStrings))]
        public void ParsesCosmos(string connString, string domain)
        {
            Assert.That(TableConnectionString.TryParse(connString, out TableConnectionString tcs), "Parsing should have been successful");
            Assert.That(tcs.Credentials, Is.Not.Null);
            Assert.That(TableConnectionStringTests.GetCredString(tcs.Credentials), Is.EqualTo(TableConnectionStringTests.GetExpectedHash(_expectedCred)), "The Credentials should have matched.");
            Assert.That(tcs.TableStorageUri.PrimaryUri, Is.EqualTo(new Uri($"https://{AccountName}.{domain}:443/")), "The PrimaryUri should have matched.");
            Assert.That(tcs.TableStorageUri.SecondaryUri, Is.EqualTo(new Uri($"https://{AccountName}{TableConstants.ConnectionStrings.SecondaryLocationAccountSuffix}.{domain}:443/")), "The SecondaryUri should have matched.");
        }

        public static IEnumerable<object[]> ValidSasStorageConnStrings()
        {
            yield return new object[] { $"DefaultEndpointsProtocol=https;AccountName={AccountName};SharedAccessSignature={SasToken};EndpointSuffix=core.windows.net" };
            yield return new object[] { $"AccountName={AccountName};SharedAccessSignature={SasToken};EndpointSuffix=core.windows.net" };
            yield return new object[] { $"DefaultEndpointsProtocol=https;SharedAccessSignature={SasToken};AccountName={AccountName}" };
            yield return new object[] { $"AccountName={AccountName};SharedAccessSignature={SasToken}" };
            yield return new object[] { $"BlobEndpoint=https://{AccountName}.blob.core.windows.net/;QueueEndpoint=https://{AccountName}.queue.core.windows.net/;FileEndpoint=https://{AccountName}.file.core.windows.net/;TableEndpoint=https://{AccountName}.table.core.windows.net/;SharedAccessSignature={SasToken}" };
        }

        /// <summary>
        /// Validates the functionality of the TableConnectionString.
        /// </summary>
        [Test]
        [TestCaseSource(nameof(ValidSasStorageConnStrings))]
        public void ParsesSasStorage(string connString)
        {
            Assert.That(TableConnectionString.TryParse(connString, out TableConnectionString tcs), "Parsing should have been successful");
            Assert.That(tcs.Credentials, Is.Not.Null);
            Assert.That(TableConnectionStringTests.GetCredString(tcs.Credentials), Is.EqualTo(SasToken), "The Credentials should have matched.");
            Assert.That(tcs.TableStorageUri.PrimaryUri, Is.EqualTo(new Uri($"https://{AccountName}.table.core.windows.net/?{SasToken}")), "The PrimaryUri should have matched.");
            Assert.That(tcs.TableStorageUri.SecondaryUri, Is.EqualTo(new Uri($"https://{AccountName}{TableConstants.ConnectionStrings.SecondaryLocationAccountSuffix}.table.core.windows.net/?{SasToken}")), "The SecondaryUri should have matched.");
        }

        public static IEnumerable<object[]> ValidSaSCosmosConnStrings()
        {
            yield return new object[] { $"DefaultEndpointsProtocol=https;AccountName={AccountName};SharedAccessSignature={SasToken};TableEndpoint=https://{AccountName}.table.cosmos.azure.com:443/;" };
            yield return new object[] { $"AccountName={AccountName};SharedAccessSignature={SasToken};TableEndpoint=https://{AccountName}.table.cosmos.azure.com:443/;" };
        }

        /// <summary>
        /// Validates the functionality of the TableConnectionString.
        /// </summary>
        [Test]
        [TestCaseSource(nameof(ValidSaSCosmosConnStrings))]
        public void ParsesSaSCosmos(string connString)
        {
            Assert.That(TableConnectionString.TryParse(connString, out TableConnectionString tcs), "Parsing should have been successful");
            Assert.That(tcs.Credentials, Is.Not.Null);
            Assert.That(TableConnectionStringTests.GetCredString(tcs.Credentials), Is.EqualTo(SasToken), "The Credentials should have matched.");
            Assert.That(tcs.TableStorageUri.PrimaryUri, Is.EqualTo(new Uri($"https://{AccountName}.table.cosmos.azure.com/?{SasToken}")), "The PrimaryUri should have matched.");
            Assert.That(tcs.TableStorageUri.SecondaryUri, Is.EqualTo(new Uri($"https://{AccountName}{TableConstants.ConnectionStrings.SecondaryLocationAccountSuffix}.table.cosmos.azure.com/?{SasToken}")), "The SecondaryUri should have matched.");
            Assert.AreEqual(AccountName,tcs._accountName);
        }
        public static IEnumerable<object[]> InvalidConnStrings()
        {
            yield return new object[] { "UseDevelopmentStorage=false" };
            yield return new object[] { $"BlobEndpoint=https://{AccountName}.blob.core.windows.net/;QueueEndpoint=https://{AccountName}.queue.core.windows.net/;FileEndpoint=https://{AccountName}.file.core.windows.net/;TableEndpoint=https://{AccountName}.table.core.windows.net/" };
            yield return new object[] { $"DefaultEndpointsProtocol=https;AccountName={AccountName};EndpointSuffix=core.windows.net" };
            yield return new object[] { $"DefaultEndpointsProtocol=https;AccountKey={Secret};EndpointSuffix=core.windows.net" };
        }

        /// <summary>
        /// Validates the functionality of the TableConnectionString.
        /// </summary>
        [Test]
        [TestCaseSource(nameof(InvalidConnStrings))]
        public void ParseFailsWithInvalidConnString(string connString)
        {
            Assert.That(TableConnectionString.TryParse(connString, out TableConnectionString tcs), Is.False, "Parsing should not have been successful");
        }

        [Test]
        public void GetSecondaryUriFromPrimaryCosmos()
        {
            Uri secondaryEndpoint = TableConnectionString.GetSecondaryUriFromPrimary(new Uri($"https://{AccountName}.table.cosmos.azure.com:443/"));

            Assert.That(secondaryEndpoint, Is.Not.Null.Or.Empty, "Secondary endpoint should not be null or empty");
            Assert.That(secondaryEndpoint.AbsoluteUri, Is.EqualTo(new Uri($"https://{AccountName}{TableConstants.ConnectionStrings.SecondaryLocationAccountSuffix}.table.cosmos.azure.com:443/").AbsoluteUri));
        }

        [Test]
        public void GetSecondaryUriFromPrimaryStorage()
        {
            Uri secondaryEndpoint = TableConnectionString.GetSecondaryUriFromPrimary(new Uri($"https://{AccountName}.table.core.windows.net/"), AccountName);

            Assert.That(secondaryEndpoint, Is.Not.Null.Or.Empty, "Secondary endpoint should not be null or empty");
            Assert.That(secondaryEndpoint.AbsoluteUri, Is.EqualTo(new Uri($"https://{AccountName}{TableConstants.ConnectionStrings.SecondaryLocationAccountSuffix}.table.core.windows.net/")));
        }

        [Test]
        public void GetSecondaryUriFromPrimaryAzurite()
        {
            Uri secondaryEndpoint = TableConnectionString.GetSecondaryUriFromPrimary(new Uri($"https://127.0.0.1:10002/{AccountName}/"), AccountName);

            Assert.That(secondaryEndpoint, Is.Not.Null.Or.Empty, "Secondary endpoint should not be null or empty");
            Assert.That(secondaryEndpoint.AbsoluteUri, Is.EqualTo(new Uri($"https://127.0.0.1:10002/{AccountName}{TableConstants.ConnectionStrings.SecondaryLocationAccountSuffix}/")));
        }

        [Test]
        public void ParseAzuriteConnString()
        {
            var uri = "DefaultEndpointsProtocol=http;AccountName=devstoreaccount1;AccountKey=Eby8vdM02xNOcqFlqUwJPLlmEtlCDXJ1OUzFT50uSRZ6IFsuFq2UVErCz4I6tq/K1SZFPTOtr/KBHBeksoGMGw==;TableEndpoint=http://127.0.0.1:10002/devstoreaccount1;";

            var result = TableConnectionString.Parse(uri);
            Assert.AreEqual("devstoreaccount1", result._accountName);
        }

        [Test]
        public void ParseCosmosEmulatorConnString()
        {
            var uri = "DefaultEndpointsProtocol=http;AccountName=localhost;AccountKey=C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==;TableEndpoint=http://localhost:8902/;";

            var result = TableConnectionString.Parse(uri);
            Assert.AreEqual("localhost", result._accountName);
        }

        public static IEnumerable<object[]> UriInputs()
        {
            yield return new object[] { new Uri($"https://{AccountName}.table.cosmos.azure.com:443/{TableName}"), AccountName, TableName };
            yield return new object[] { new Uri($"https://{AccountName}.table.cosmos.azure.com:443/{TableName}/"), AccountName, TableName };
            yield return new object[] { new Uri($"https://{AccountName}.table.cosmos.azure.com:443/Tables('{TableName}')/"), AccountName, TableName };
            yield return new object[] { new Uri($"https://{AccountName}.table.core.windows.net/{TableName}"), AccountName, TableName };
            yield return new object[] { new Uri($"https://{AccountName}.table.core.windows.net/{TableName}/"), AccountName, TableName };
            yield return new object[] { new Uri($"https://{AccountName}.table.core.windows.net/Tables('{TableName}')/"), AccountName, TableName };
            yield return new object[] { new Uri($"https://127.0.0.1:10002/{AccountName}/{AccountName}"), AccountName, AccountName };
            yield return new object[] { new Uri($"https://127.0.0.1:10002/{AccountName}/{AccountName}/"), AccountName, AccountName };
            yield return new object[] { new Uri($"https://127.0.0.1:10002/{AccountName}/{TableName}"), AccountName, TableName };
            yield return new object[] { new Uri($"https://127.0.0.1:10002/{AccountName}/{TableName}/"), AccountName, TableName };
            yield return new object[] { new Uri($"https://127.0.0.1:10002/{AccountName}/Tables('{TableName}')/"), AccountName, TableName };
            yield return new object[] { new Uri($"https://10.0.0.1:10002/{AccountName}/{TableName}"), AccountName, TableName };
            yield return new object[] { new Uri($"https://10.0.0.1:10002/{AccountName}/{TableName}/"), AccountName, TableName };
            yield return new object[] { new Uri($"https://10.0.0.1:10002/{AccountName}/Tables('{TableName}')/"), AccountName, TableName };
            yield return new object[] { new Uri($"https://localhost:10002/{AccountName}/{AccountName}"), AccountName, AccountName };
            yield return new object[] { new Uri($"https://localhost:10002/{AccountName}/{AccountName}/"), AccountName, AccountName };
            yield return new object[] { new Uri($"https://localhost:10002/{AccountName}/{TableName}"), AccountName, TableName };
            yield return new object[] { new Uri($"https://localhost:10002/{AccountName}/{TableName}/"), AccountName, TableName };
            yield return new object[] { new Uri($"https://localhost:10002/{AccountName}/Tables('{TableName}')/"), AccountName, TableName };
        }

        [Test]
        [TestCaseSource(nameof(UriInputs))]
        public void GetAccountNameFromUri(Uri uri, string expectedAccountName, string expectedTableName)
        {
            string actualAccountName = TableConnectionString.GetAccountNameFromUri(uri);

            Assert.That(actualAccountName, Is.EqualTo(expectedAccountName));
        }

        [Test]
        [TestCaseSource(nameof(UriInputs))]
        public void GetTableNameFromUri(Uri uri, string expectedAccountName, string expectedTableName)
        {
            string actualTableName = TableConnectionString.GetTableNameFromUri(uri);

            Assert.That(actualTableName, Is.EqualTo(expectedTableName));
        }

        private static string GetExpectedHash(TableSharedKeyCredential cred) => cred.ComputeHMACSHA256("message");

        private static string GetCredString(object credential) => credential switch
        {
            TableSharedKeyCredential cred => TableConnectionStringTests.GetExpectedHash(cred),
            string sas => sas,
            _ => null
        };
    }
}
