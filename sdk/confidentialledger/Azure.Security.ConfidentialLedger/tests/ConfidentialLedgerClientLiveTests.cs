// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.Security.ConfidentialLedger.Certificate;
using NUnit.Framework;

namespace Azure.Security.ConfidentialLedger.Tests
{
    public class ConfidentialLedgerClientLiveTests : RecordedTestBase<ConfidentialLedgerEnvironment>
    {
        private TokenCredential Credential;
        private ConfidentialLedgerClient Client;
        private ConfidentialLedgerCertificateClient IdentityClient;
        private HashSet<string> TestsNotRequiringLedgerEntry = new() { "GetEnclaveQuotes", "GetConsortiumMembers", "GetConstitution" };
        private (X509Certificate2 Cert, string PEM) serviceCert;

        public ConfidentialLedgerClientLiveTests(bool isAsync) : base(isAsync)
        {
            // https://github.com/Azure/autorest.csharp/issues/1214
            TestDiagnostics = false;
        }

        [SetUp]
        public async Task Setup()
        {
            Credential = TestEnvironment.Credential;
            IdentityClient = new ConfidentialLedgerCertificateClient(
                    TestEnvironment.ConfidentialLedgerIdentityUrl,
                   InstrumentClientOptions(new ConfidentialLedgerCertificateClientOptions()));

            serviceCert = ConfidentialLedgerClient.GetIdentityServerTlsCert(TestEnvironment.ConfidentialLedgerUrl, new(), IdentityClient);

            if (Mode != RecordedTestMode.Playback)
                await SetProxyOptionsAsync(new ProxyOptions { Transport = new ProxyOptionsTransport { TLSValidationCert = serviceCert.PEM, AllowAutoRedirect = true } });

            Client = InstrumentClient(
                new ConfidentialLedgerClient(
                    TestEnvironment.ConfidentialLedgerUrl,
                    credential: Credential,
                    clientCertificate: null,
                    ledgerOptions: InstrumentClientOptions(new ConfidentialLedgerClientOptions()),
                    identityServiceCert: serviceCert.Cert));
        }

        public async Task GetUser(string objId)
        {
            var result = await Client.GetUserAsync(objId, new());
            var stringResult = new StreamReader(result.ContentStream).ReadToEnd();

            Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
            Assert.That(stringResult, Does.Contain(objId));
        }
#if NET6_0_OR_GREATER
        [LiveOnly]
        [RecordedTest]
        public async Task AuthWithClientCert()
        {
            await SetProxyOptionsAsync(new ProxyOptions { Transport = new ProxyOptionsTransport { TLSValidationCert = serviceCert.PEM, Certificates = { new ProxyOptionsTransportCertificatesItem { PemValue = TestEnvironment.ClientPEM, PemKey = TestEnvironment.ClientPEMPk } } } });
            var _cert = X509Certificate2.CreateFromPem(TestEnvironment.ClientPEM, TestEnvironment.ClientPEMPk);
            _cert = new X509Certificate2(_cert.Export(X509ContentType.Pfx));
            var certClient = InstrumentClient(new ConfidentialLedgerClient(
                TestEnvironment.ConfidentialLedgerUrl,
                credential: null,
                clientCertificate: _cert,
                ledgerOptions: InstrumentClientOptions(new ConfidentialLedgerClientOptions())));
            var result = await certClient.GetConstitutionAsync(new());
            var stringResult = new StreamReader(result.ContentStream).ReadToEnd();

            Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
            Assert.That(stringResult, Does.Contain("digest"));
        }
#endif
        [RecordedTest]
        public async Task GetLedgerEntries()
        {
            await PostLedgerEntry();

            await foreach (var entry in Client.GetLedgerEntriesAsync())
            {
                Assert.NotNull(entry);
            }
        }

        [RecordedTest]
        public async Task GetLedgerEntry()
        {
            await PostLedgerEntry();
            var tuple = await GetFirstTransactionIdFromGetEntries();
            string transactionId = tuple.TransactionId;
            string stringResult = tuple.StringResult;
            Response response = await Client.GetLedgerEntryAsync(transactionId);

            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
            Assert.That(stringResult, Does.Contain(transactionId));
        }

        [RecordedTest]
        public async Task GetReceipt()
        {
            await PostLedgerEntry();

            var tuple = await GetFirstTransactionIdFromGetEntries();
            string transactionId = tuple.TransactionId;
            string stringResult = tuple.StringResult;

            var result = await Client.GetReceiptAsync(transactionId, new RequestContext()).ConfigureAwait(false);

            Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
            Assert.That(stringResult, Does.Contain(transactionId));
        }

        [RecordedTest]
        public async Task GetTransactionStatus()
        {
            await PostLedgerEntry();

            var tuple = await GetFirstTransactionIdFromGetEntries();
            string transactionId = tuple.TransactionId;
            string stringResult = tuple.StringResult;

            var result = await Client.GetTransactionStatusAsync(transactionId, new RequestContext()).ConfigureAwait(false);

            Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
            Assert.That(stringResult, Does.Contain(transactionId));
        }

        [RecordedTest]
        public async Task GetConstitution()
        {
            var result = await Client.GetConstitutionAsync(new());
            var stringResult = new StreamReader(result.ContentStream).ReadToEnd();

            Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
            Assert.That(stringResult, Does.Contain("digest"));
        }

        [RecordedTest]
        public async Task GetConsortiumMembers()
        {
            await foreach (var page in Client.GetConsortiumMembersAsync(new()))
            {
                var stringResult = page.ToString();

                Assert.That(stringResult, Does.Contain("BEGIN CERTIFICATE"));
            }
        }

        [RecordedTest]
        public async Task GetEnclaveQuotes()
        {
            var result = await Client.GetEnclaveQuotesAsync(new());
            var stringResult = new StreamReader(result.ContentStream).ReadToEnd();

            Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
            Assert.That(stringResult, Does.Contain("enclaveQuotes"));
        }

        [RecordedTest]
        public async Task PostLedgerEntry()
        {
            var operation = await Client.PostLedgerEntryAsync(
                waitUntil: WaitUntil.Completed,
                RequestContent.Create(new { contents = Recording.GenerateAssetName("test") }));
            var result = operation.GetRawResponse();
            var stringResult = new StreamReader(result.ContentStream).ReadToEnd();

            Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
            Assert.NotNull(operation.Id);
            Assert.That(stringResult, Does.Contain("Committed"));
            Assert.That(stringResult, Does.Contain(operation.Id));
        }

        [RecordedTest]
        public async Task GetCurrentLedgerEntry()
        {
            await Client.PostLedgerEntryAsync(
               waitUntil: WaitUntil.Completed,
               RequestContent.Create(new { contents = Recording.GenerateAssetName("test") }));

            var result = await Client.GetCurrentLedgerEntryAsync();
            var stringResult = new StreamReader(result.ContentStream).ReadToEnd();

            Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
            Assert.That(stringResult, Does.Contain("contents"));
        }

        [RecordedTest]
        public async Task CreateAndGetAndDeleteUser()
        {
            var userId = Recording.Random.NewGuid().ToString();
            var result = await Client.CreateOrUpdateUserAsync(
                userId,
                RequestContent.Create(new { assignedRole = "Reader" }));
            var stringResult = new StreamReader(result.ContentStream).ReadToEnd();

            Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
            Assert.That(stringResult, Does.Contain(userId));

            await GetUser(userId);

            await Client.DeleteUserAsync(userId);

            Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
        }

        [RecordedTest]
        [LiveOnly]
        public async Task GetLedgerIdentity()
        {
            var ledgerId = TestEnvironment.ConfidentialLedgerUrl.Host;
            ledgerId = ledgerId.Substring(0, ledgerId.IndexOf('.'));
            var result = await IdentityClient.GetLedgerIdentityAsync(ledgerId, new()).ConfigureAwait(false);

            Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
        }

        private Dictionary<string, string> GetQueryStringKvps(string s)
        {
            var parts = s.Substring(s.IndexOf('?') + 1).Split('&');
            var result = new Dictionary<string, string>();
            foreach (var part in parts)
            {
                var kvp = part.Split('=');
                result[kvp[0]] = kvp[1];
            }
            return result;
        }

        private async Task<(string TransactionId, string StringResult)> GetFirstTransactionIdFromGetEntries()
        {
            string stringResult = "Loading";
            var result = Client.GetLedgerEntriesAsync();
            bool first = true;
            Response response = null;

            await foreach (var page in result.AsPages())
            {
                if (first)
                {
                    response = page.GetRawResponse();
                }
                foreach (var entry in page.Values)
                {
                    stringResult = new StreamReader(entry.ToStream()).ReadToEnd();
                    break;
                }
                first = false;
            }

            while (stringResult.Contains("Loading"))
            {
                first = true;
                result = Client.GetLedgerEntriesAsync();
                await foreach (var page in result.AsPages())
                {
                    if (first)
                    {
                        response = page.GetRawResponse();
                    }
                    foreach (var entry in page.Values)
                    {
                        stringResult = new StreamReader(entry.ToStream()).ReadToEnd();
                        break;
                    }
                    first = false;
                }
            }
            return (GetFirstTransactionId(stringResult), stringResult);
        }

        private string GetFirstTransactionId(string stringResult)
        {
            var doc = JsonDocument.Parse(stringResult);
            if (doc.RootElement.TryGetProperty("transactionId", out var tid))
            {
                return tid.GetString();
            }
            throw new Exception($"Could not parse transationId from response:\n{stringResult}");
        }
    }
}
