// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Security.ConfidentialLedger.Tests
{
    public class ConfidentialLedgerClientLiveTests : RecordedTestBase<ConfidentialLedgerEnvironment>
    {
        private TokenCredential Credential;
        private ConfidentialLedgerClientOptions Options;
        private ConfidentialLedgerClient Client;
        private ConfidentialLedgerIdentityServiceClient IdentityClient;

        public ConfidentialLedgerClientLiveTests(bool isAsync) : base(isAsync)
        {
            // https://github.com/Azure/autorest.csharp/issues/1214
            TestDiagnostics = false;
        }

        [SetUp]
        public void Setup()
        {
            Credential = TestEnvironment.Credential;
            var httpHandler = new HttpClientHandler();
            httpHandler.ServerCertificateCustomValidationCallback = (_, _, _, _) =>
            {
                return true;
            };
            Options = new ConfidentialLedgerClientOptions { Transport = new HttpClientTransport(httpHandler) };
            Client = InstrumentClient(
                new ConfidentialLedgerClient(
                    TestEnvironment.ConfidentialLedgerUrl,
                    Credential,
                    InstrumentClientOptions(Options)));

            IdentityClient = InstrumentClient(
                new ConfidentialLedgerIdentityServiceClient(
                    TestEnvironment.ConfidentialLedgerIdentityUrl,
                    InstrumentClientOptions(Options)));
        }

        public async Task GetUser(string objId)
        {
            var result = await Client.GetUserAsync(objId, new());
            var stringResult = new StreamReader(result.ContentStream).ReadToEnd();

            Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
            Assert.That(stringResult, Does.Contain(objId));
        }

        //[RecordedTest]
        //public async Task GetLedgerEntries()
        //{
        //    await PostLedgerEntry();

        //    var result = await Client.GetLedgerEntriesAsync();

        //    var nextLinkDetails = GetNextLinkDetails(result);
        //    while (nextLinkDetails != null)
        //    {
        //        var fromId = nextLinkDetails["fromTransactionId"];
        //        var subId = nextLinkDetails["subLedgerId"];
        //        result = await Client.GetLedgerEntriesAsync(subId, fromId).ConfigureAwait(false);
        //        Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
        //        nextLinkDetails = GetNextLinkDetails(result);
        //    }
        //}

        //[RecordedTest]
        //public async Task GetLedgerEntry()
        //{
        //    await PostLedgerEntry();

        //    var result = await Client.GetLedgerEntriesAsync();
        //    var stringResult = new StreamReader(result.ContentStream).ReadToEnd();

        //    while (stringResult.Contains("Loading"))
        //    {
        //        result = await Client.GetLedgerEntriesAsync().ConfigureAwait(false);
        //        stringResult = new StreamReader(result.ContentStream).ReadToEnd();
        //    }
        //    var transactionId = GetFirstTransactionId(result);
        //    result = await Client.GetLedgerEntryAsync(transactionId).ConfigureAwait(false);

        //    Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
        //    Assert.That(stringResult, Does.Contain(transactionId));
        //}

        //[RecordedTest]
        //public async Task GetReceipt()
        //{
        //    await PostLedgerEntry();

        //    var result = await Client.GetLedgerEntriesAsync();
        //    var stringResult = new StreamReader(result.ContentStream).ReadToEnd();

        //    while (stringResult.Contains("Loading"))
        //    {
        //        result = await Client.GetLedgerEntriesAsync().ConfigureAwait(false);
        //        stringResult = new StreamReader(result.ContentStream).ReadToEnd();
        //    }
        //    var transactionId = GetFirstTransactionId(result);
        //    result = await Client.GetReceiptAsync(transactionId).ConfigureAwait(false);

        //    Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
        //    Assert.That(stringResult, Does.Contain(transactionId));
        //}

        //[RecordedTest]
        //public async Task GetTransactionStatus()
        //{
        //    await PostLedgerEntry();

        //    var result = await Client.GetLedgerEntriesAsync();
        //    var stringResult = new StreamReader(result.ContentStream).ReadToEnd();

        //    while (stringResult.Contains("Loading"))
        //    {
        //        result = await Client.GetLedgerEntriesAsync().ConfigureAwait(false);
        //        stringResult = new StreamReader(result.ContentStream).ReadToEnd();
        //    }
        //    var transactionId = GetFirstTransactionId(result);
        //    result = await Client.GetTransactionStatusAsync(transactionId).ConfigureAwait(false);

        //    Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
        //    Assert.That(stringResult, Does.Contain(transactionId));
        //}

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
            var result = await Client.GetConsortiumMembersAsync(new());
            var stringResult = new StreamReader(result.ContentStream).ReadToEnd();

            Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
            Assert.That(stringResult, Does.Contain("BEGIN CERTIFICATE"));
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
            var result = await Client.PostLedgerEntryAsync(
                RequestContent.Create(
                    new { contents = Recording.GenerateAssetName("test") }));
            var stringResult = new StreamReader(result.ContentStream).ReadToEnd();

            Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
            Assert.That(stringResult, Does.Contain("subLedgerId"));
        }

        [RecordedTest]
        public async Task GetCurrentLedgerEntry()
        {
            await PostLedgerEntry();

            var result = await Client.GetCurrentLedgerEntryAsync(new());
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

        private string GetFirstTransactionId(Response response)
        {
            response.ContentStream.Position = 0;
            var stringResult = new StreamReader(response.ContentStream).ReadToEnd();
            var doc = JsonDocument.Parse(stringResult);
            if (doc.RootElement.TryGetProperty("entries", out var prop))
            {
                foreach (JsonElement entry in prop.EnumerateArray())
                {
                    if (entry.TryGetProperty("transactionId", out var tid))
                    {
                        return tid.GetString();
                    }
                }
            }
            return default;
        }

        private Dictionary<string, string> GetNextLinkDetails(Response response)
        {
            var stringResult = new StreamReader(response.ContentStream).ReadToEnd();
            var doc = JsonDocument.Parse(stringResult);
            if (doc.RootElement.TryGetProperty("@nextLink", out var prop))
            {
                return GetQueryStringKvps(prop.GetString());
            }
            return default;
        }
    }
}
