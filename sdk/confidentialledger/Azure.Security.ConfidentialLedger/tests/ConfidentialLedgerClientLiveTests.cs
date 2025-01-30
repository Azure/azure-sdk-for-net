// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// This identifies the latest API Version under test: 2024-08-22-preview
#define API_V3

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
using Azure.Data.ConfidentialLedger.Tests.Helper;
using Azure.Security.ConfidentialLedger.Certificate;
using NUnit.Framework;
using Xunit;
using static Azure.Security.ConfidentialLedger.ConfidentialLedgerClientOptions;

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
                    ledgerOptions: InstrumentClientOptions(new ConfidentialLedgerClientOptions(ServiceVersion.V2024_08_22_Preview)),
                    identityServiceCert: serviceCert.Cert));
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
        [LiveOnly]
        public async Task GetLedgerIdentity()
        {
            var ledgerId = TestEnvironment.ConfidentialLedgerUrl.Host;
            ledgerId = ledgerId.Substring(0, ledgerId.IndexOf('.'));
            var result = await IdentityClient.GetLedgerIdentityAsync(ledgerId, new()).ConfigureAwait(false);

            Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
        }

        #region LedgerTransactions
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
        #endregion

        #region LedgerGovernance
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
        #endregion

        #region LedgerUserManagment
#if API_V3
        [Fact(Skip = "Skipped for API_V3")]
#else
        [Fact]
#endif
        public async Task GetUser(string objId)
        {
            var result = await Client.GetUserAsync(objId, new());
            var stringResult = new StreamReader(result.ContentStream).ReadToEnd();

            Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
            Assert.That(stringResult, Does.Contain(objId));
        }

#if API_V3
        [Fact(Skip = "Skipped for API_V3")]
#else
        [Fact]
#endif
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

#if API_V3
        [Fact(Skip = "Skipped for API_V3")]
#else
        [Fact]
#endif
        [RecordedTest]
        public async Task GetUsers()
        {
            // Create a user, test that it shows up in the users list
            var userId = Recording.Random.NewGuid().ToString();
            Response result = await Client.CreateOrUpdateUserAsync(
                userId,
                RequestContent.Create(new { assignedRole = "Reader" }));
            var stringResult = new StreamReader(result.ContentStream).ReadToEnd();

            Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
            Assert.That(stringResult, Does.Contain(userId));

            HashSet<string> users = [];
            await foreach (BinaryData page in Client.GetUsersAsync())
            {
                JsonElement pageResult = JsonDocument.Parse(page.ToStream()).RootElement;
                if (pageResult.GetProperty("assignedRole").GetString() == "Reader")
                {
                    users.Add(pageResult.GetProperty("userId").GetString());
                }
            }

            Assert.IsTrue(users.Contains(userId), "GetUsers endpoint does not contain expected reader");
            await Client.DeleteUserAsync(userId);
        }

        [RecordedTest]
        public async Task GetLedgerUsers()
        {
            // Create a user, test that it shows up in the users list
            var userId = Recording.Random.NewGuid().ToString();
            Response result = await Client.CreateOrUpdateLedgerUserAsync(
                userId,
                RequestContent.Create(new { assignedRole = "Reader" }));
            var stringResult = new StreamReader(result.ContentStream).ReadToEnd();

            Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
            Assert.That(stringResult, Does.Contain(userId));

            HashSet<string> users = [];
            await foreach (BinaryData page in Client.GetLedgerUsersAsync())
            {
                JsonElement pageResult = JsonDocument.Parse(page.ToStream()).RootElement;
                if (pageResult.GetProperty("assignedRole").GetString() == "Reader")
                {
                    users.Add(pageResult.GetProperty("userId").GetString());
                }
            }

            Assert.IsTrue(users.Contains(userId), "GetLedgerUsers endpoint does not contain expected reader");
            await Client.DeleteLedgerUserAsync(userId);
        }
        #endregion

        #region Programmability
        [RecordedTest]
        public async Task UserDefinedEndpointsTest()
        {
            // Deploy JS App
            string programmabilityPayload = JsonSerializer.Serialize(JSBundle.Create("test", "programmability.js"));
            RequestContent programmabilityContent = RequestContent.Create(programmabilityPayload);

            Response result = await Client.CreateUserDefinedEndpointAsync(programmabilityContent);
            var stringResult = new StreamReader(result.ContentStream).ReadToEnd();

            Assert.AreEqual((int)HttpStatusCode.Created, result.Status);

            // Verify Response by Querying endpt
            ConfidentialLedgerHelperHttpClient helperHttpClient = new ConfidentialLedgerHelperHttpClient(TestEnvironment.ConfidentialLedgerUrl, Credential);
            (var statusCode, var response) = await helperHttpClient.QueryUserDefinedContentEndpointAsync("app/Content");
            Assert.AreEqual((int)HttpStatusCode.OK, statusCode);
            Assert.AreEqual("Test content", response);

            // Deploy Empty JS Bundle to remove JS App
            programmabilityPayload = JsonSerializer.Serialize(JSBundle.Create());

            result = await Client.CreateUserDefinedEndpointAsync(programmabilityContent);
            stringResult = new StreamReader(result.ContentStream).ReadToEnd();

            Assert.AreEqual((int)HttpStatusCode.Created, result.Status);
        }

        [RecordedTest]
        public async Task JSRuntimeOptionsTest()
        {
            // Get Default JS Runtime Options
            Response result = await Client.GetRuntimeOptionsAsync();
            var stringResult = new StreamReader(result.ContentStream).ReadToEnd();

            // Deserialize JSON response into a dictionary
            var runtimeOptions = JsonSerializer.Deserialize<Dictionary<string, object>>(result.Content.ToString());

            // Expected Default values
            var expectedJSRuntimeOptions = new Dictionary<string, object>
            {
                { "log_exception_details", false },
                { "max_cached_interpreters", 10 },
                { "max_execution_time_ms", 1000 },
                { "max_heap_bytes", 104857600 },
                { "max_stack_bytes", 1048576 },
                { "return_exception_details", false }
            };

            // Validate response matches expected options
            foreach (var kvp in expectedJSRuntimeOptions)
            {
                Assert.True(runtimeOptions.TryGetValue(kvp.Key, out var actualValue), $"Missing key: {kvp.Key}");
                Assert.Equals(kvp.Value, actualValue);
            }

            // Update Runtime Options
            var updateJSRuntimeOptions = new Dictionary<string, object>
            {
                { "log_exception_details", false },
                { "max_cached_interpreters", 20 },
                { "max_execution_time_ms", 5000 },
                { "max_heap_bytes", 204857600 },
                { "max_stack_bytes", 1048576 },
                { "return_exception_details", false }
            };

            string jsRuntimeOptionsPayload = JsonSerializer.Serialize(updateJSRuntimeOptions);
            RequestContent runtimeOptionsContent = RequestContent.Create(jsRuntimeOptionsPayload);

            result = await Client.UpdateRuntimeOptionsAsync(runtimeOptionsContent);

            Assert.AreEqual((int)HttpStatusCode.OK, result.Status);

            // Revert Runtime Options
            string restoreJsRuntimeOptionsPayload = JsonSerializer.Serialize(updateJSRuntimeOptions);
            runtimeOptionsContent = RequestContent.Create(restoreJsRuntimeOptionsPayload);

            result = await Client.UpdateRuntimeOptionsAsync(runtimeOptionsContent);

            Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
        }
        #endregion

        #region CustomRole
        [RecordedTest]
        public async Task CustomRoleTest()
        {
            string roleName = "TestRole";
            // Add Custom Role
            var rolesParam = new RolesParam
            {
                Roles = new List<Role>
                {
                    new Role
                    {
                        RoleName = roleName,
                        RoleActions = new List<string> { "/content/write" }
                    }
                }
            };

            Response result = await Client.CreateUserDefinedRoleAsync(RequestContent.Create(JsonSerializer.Serialize(rolesParam)));
            Assert.AreEqual((int)HttpStatusCode.OK, result.Status);

            result =  await Client.GetUserDefinedRoleAsync(roleName);
            var roleData = JsonSerializer.Deserialize<RolesParam>(result.Content.ToString());
            // Validate Fetched RoleData with Added Role Data
            Assert.Equals(rolesParam, roleData);

            result = await Client.DeleteUserDefinedRoleAsync(roleName);
            Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
        }
        #endregion

        #region LedgerTestHelpers
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
        private class Role
        {
            public string RoleName { get; set; } = string.Empty;
            public List<string> RoleActions { get; set; } = new List<string>();
        }

        private class RolesParam
        {
            public List<Role> Roles { get; set; } = new List<Role>();
        }
        #endregion
    }
}
