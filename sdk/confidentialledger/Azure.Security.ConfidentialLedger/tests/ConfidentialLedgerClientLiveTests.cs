// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

// This identifies the latest API Version under test: 2024-08-22-preview
#define API_V3

using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Linq;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Core.TestFramework.Models;
using Azure.Data.ConfidentialLedger.Tests.Helper;
using Azure.Security.ConfidentialLedger.Certificate;
using NUnit.Framework;
using static Azure.Security.ConfidentialLedger.ConfidentialLedgerClientOptions;
using static Azure.Security.ConfidentialLedger.Tests.ConfidentialLedgerClientLiveTests;

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
            // Add BodyRegexSanitizer to handle newline characters
            BodyRegexSanitizers.Add(
                new BodyRegexSanitizer(
                    "[^\\r](?<break>\\n)")
                {
                    GroupForReplace = "break",
                    Value = "\r\n"
                });
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
                    ledgerOptions: InstrumentClientOptions(new ConfidentialLedgerClientOptions(ServiceVersion.V2024_12_09_Preview)),
                    identityServiceCert: serviceCert.Cert));
        }

#if NET6_0_OR_GREATER
        [LiveOnly]
        [RecordedTest]
        public async Task AuthWithClientCert()
        {
            await SetProxyOptionsAsync(new ProxyOptions { Transport = new ProxyOptionsTransport { TLSValidationCert = serviceCert.PEM, Certificates = { new ProxyOptionsTransportCertificatesItem { PemValue = TestEnvironment.ClientPEM, PemKey = TestEnvironment.ClientPEMPk } } } });
            var _cert = X509Certificate2.CreateFromPem(TestEnvironment.ClientPEM, TestEnvironment.ClientPEMPk);
#if NET9_0_OR_GREATER
            _cert = X509CertificateLoader.LoadPkcs12(_cert.Export(X509ContentType.Pfx), null);
#else
            _cert = new X509Certificate2(_cert.Export(X509ContentType.Pfx));
#endif
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
        [Ignore("Test is skipped for API_V3 because ledgerUsers Endpt should be used")]
#endif
        public async Task GetUser(string objId)
        {
            var result = await Client.GetUserAsync(objId, new());
            var stringResult = new StreamReader(result.ContentStream).ReadToEnd();

            Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
            Assert.That(stringResult, Does.Contain(objId));
        }

#if API_V3
        [Test]
        [Ignore("Test is skipped for API_V3 because ledgerUsers Endpt should be used")]
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
        [Test]
        [Ignore("Test is skipped for API_V3 because ledgerUsers Endpt should be used")]
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
                RequestContent.Create(new { assignedRoles = new List<string> { "Reader" } }));
            var stringResult = new StreamReader(result.ContentStream).ReadToEnd();

            Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
            Assert.That(stringResult, Does.Contain(userId));

            HashSet<string> users = [];
            await foreach (BinaryData page in Client.GetLedgerUsersAsync())
            {
                JsonElement pageResult = JsonDocument.Parse(page.ToStream()).RootElement;

                if (pageResult.GetProperty("assignedRoles")[0].ToString() == "Reader")
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
            await foreach (BinaryData functions in Client.GetUserDefinedFunctionsAsync())
            {
                JsonElement functiondata = JsonDocument.Parse(functions.ToStream()).RootElement;
                string functionId = functiondata.GetProperty("id").ToString();
                Response deleteResult = await Client.DeleteUserDefinedFunctionAsync(functionId);
                Assert.AreEqual((int)HttpStatusCode.NoContent, deleteResult.Status);
            }

            // Deploy JS App
            string programmabilityPayload = "{\"metadata\":{\"endpoints\":{\"content\":{\"get\":{\"js_module\":\"test.js\",\"js_function\":\"content\",\"forwarding_required\":\"never\",\"redirection_strategy\":\"none\",\"authn_policies\":[\"no_auth\"],\"mode\":\"readonly\",\"openapi\":{}}}}},\"modules\":[{\"name\":\"test.js\",\"module\":\"import { foo } from \\\"./bar/baz.js\\\"; export function content(request) { return { statusCode: 200, body: { payload: foo(), }, }; } \"},{\"name\":\"bar/baz.js\",\"module\":\"export function foo() { return \\\"Test content\\\"; } \"}]}";
            RequestContent programmabilityContent = RequestContent.Create(programmabilityPayload);

            Response result = await Client.CreateUserDefinedEndpointAsync(programmabilityContent);

            Assert.AreEqual((int)HttpStatusCode.Created, result.Status);

            var resp = await Client.GetUserDefinedEndpointsModuleAsync("test.js");
            Assert.AreEqual((int)HttpStatusCode.OK, resp.Status);

            // Verify Response by Querying endpt
            /// TODO: Investigate InternalServerError
            //ConfidentialLedgerHelperHttpClient helperHttpClient = new ConfidentialLedgerHelperHttpClient(TestEnvironment.ConfidentialLedgerUrl, Credential);
            //(var statusCode, var response) = await helperHttpClient.QueryUserDefinedContentEndpointAsync("/app/content");
            //Assert.AreEqual((int)HttpStatusCode.OK, statusCode);
            //Assert.AreEqual("Test content", response);
        }

        [RecordedTest]
        public async Task JSRuntimeOptionsTest()
        {
            // Get Default JS Runtime Options
            Response result = await Client.GetRuntimeOptionsAsync();
            var stringResult = new StreamReader(result.ContentStream).ReadToEnd();

            // Deserialize JSON response into a dictionary
            var runtimeOptions = JsonSerializer.Deserialize<RuntimeOptions>(result.Content.ToString());

            var expectedRuntimeOptions = new RuntimeOptions
            {
                LogExceptionDetails = false,
                MaxCachedInterpreters = 10,
                MaxExecutionTimeMs = 1000,
                MaxHeapBytes = 104857600,
                MaxStackBytes = 1048576,
                ReturnExceptionDetails = false
            };

            Assert.AreEqual(expectedRuntimeOptions.LogExceptionDetails, runtimeOptions.LogExceptionDetails);
            Assert.AreEqual(expectedRuntimeOptions.MaxCachedInterpreters, runtimeOptions.MaxCachedInterpreters);
            Assert.AreEqual(expectedRuntimeOptions.MaxExecutionTimeMs, runtimeOptions.MaxExecutionTimeMs);
            Assert.AreEqual(expectedRuntimeOptions.MaxHeapBytes, runtimeOptions.MaxHeapBytes);
            Assert.AreEqual(expectedRuntimeOptions.MaxStackBytes, runtimeOptions.MaxStackBytes);
            Assert.AreEqual(expectedRuntimeOptions.ReturnExceptionDetails, runtimeOptions.ReturnExceptionDetails);

            var updateJSRuntimeOptions = new RuntimeOptions
            {
                LogExceptionDetails = false,
                MaxCachedInterpreters = 20,
                MaxExecutionTimeMs = 5000,
                MaxHeapBytes = 204857600,
                MaxStackBytes = 1048576,
                ReturnExceptionDetails = false
            };

            string jsRuntimeOptionsPayload = JsonSerializer.Serialize(updateJSRuntimeOptions);
            RequestContent runtimeOptionsContent = RequestContent.Create(jsRuntimeOptionsPayload);

            result = await Client.UpdateRuntimeOptionsAsync(runtimeOptionsContent);
            Assert.AreEqual((int)HttpStatusCode.OK, result.Status);

            runtimeOptions = JsonSerializer.Deserialize<RuntimeOptions>(result.Content.ToString());
            Assert.AreEqual(updateJSRuntimeOptions.LogExceptionDetails, runtimeOptions.LogExceptionDetails);
            Assert.AreEqual(updateJSRuntimeOptions.MaxCachedInterpreters, runtimeOptions.MaxCachedInterpreters);
            Assert.AreEqual(updateJSRuntimeOptions.MaxExecutionTimeMs, runtimeOptions.MaxExecutionTimeMs);
            Assert.AreEqual(updateJSRuntimeOptions.MaxHeapBytes, runtimeOptions.MaxHeapBytes);
            Assert.AreEqual(updateJSRuntimeOptions.MaxStackBytes, runtimeOptions.MaxStackBytes);
            Assert.AreEqual(updateJSRuntimeOptions.ReturnExceptionDetails, runtimeOptions.ReturnExceptionDetails);

            // Revert Runtime Options
            string restoreJsRuntimeOptionsPayload = JsonSerializer.Serialize(expectedRuntimeOptions);
            runtimeOptionsContent = RequestContent.Create(restoreJsRuntimeOptionsPayload);

            result = await Client.UpdateRuntimeOptionsAsync(runtimeOptionsContent);
            Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
        }
        #endregion

        #region CustomRole
        [RecordedTest]
        public async Task CustomRoleTest()
        {
            string roleName = "userDefinedTestRole";

            // Add Custom Role
            var rolesParam = new RolesParam
            {
                Roles = [
                    new Role
                    {
                        RoleName = roleName,
                        RoleActions = new List<string> { "/content/write" }
                    }
                ]
            };

            try
            {
                Response result = await Client.CreateUserDefinedRoleAsync(RequestContent.Create(JsonSerializer.Serialize(rolesParam)));
                Assert.AreEqual((int)HttpStatusCode.OK, result.Status);

                result = await Client.GetUserDefinedRoleAsync(roleName);

                RolesParam roleData = JsonSerializer.Deserialize<RolesParam>(result.Content.ToString());
                // Validate Fetched RoleData with Added Role Data
                Assert.AreEqual(rolesParam.Roles[0].RoleName, roleData.Roles[0].RoleName);
                Assert.AreEqual(rolesParam.Roles[0].RoleActions[0], roleData.Roles[0].RoleActions[0]);
            }
            finally
            {
                Response result = await Client.DeleteUserDefinedRoleAsync(roleName);
                Assert.AreEqual((int)HttpStatusCode.OK, result.Status);
            }
        }
        #endregion

        #region CreateLedgerEntryWithTags
        [RecordedTest]
        public async Task CreateLedgerEntryWithTagsTest()
        {
            RequestContent content = RequestContent.Create(new { contents = Recording.GenerateAssetName("test") });
            string collectionId = "collection1";
            string tags = "tags1,tags2";

            Response result = await Client.CreateLedgerEntryAsync(content, collectionId, tags);
            Assert.AreEqual((int)HttpStatusCode.OK, result.Status);

            await PostLedgerEntry();
            var tuple = await GetFirstTransactionIdFromGetEntries();
            string transactionId = tuple.TransactionId;
            string stringResult = tuple.StringResult;
            Response response = await Client.GetLedgerEntryAsync(transactionId);

            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
            Assert.That(stringResult, Does.Contain(transactionId));
        }
        #endregion

        #region UserDefinedFunction
        [RecordedTest]
        public async Task UserDefinedFunctionTest()
        {
            string functionId = "myFunction";
            Response userFunctionResult = null;
            var functionParam = new UserFunctionParam
            {
                Code = "export function main() { return true }",
                Id = "myFunction"
            };
            Response response = await Client.GetUserDefinedEndpointAsync();
            if (response.Content.ToString() == null)
            {
                // Create UDF
                try
                {
                    userFunctionResult = await Client.CreateUserDefinedFunctionAsync(functionId, RequestContent.Create(JsonSerializer.Serialize(functionParam)));
                    Assert.AreEqual((int)HttpStatusCode.Created, userFunctionResult.Status);
                    userFunctionResult = await Client.GetUserDefinedFunctionAsync(functionId);

                    var functionData = JsonSerializer.Deserialize<UserFunctionParam>(userFunctionResult.Content.ToString());
                    // Validate Fetched user function with Added function Id
                    Assert.AreEqual(functionId, functionData.Id);
                }
                finally
                {
                    Response deleteResult = await Client.DeleteUserDefinedFunctionAsync(functionId);
                    Assert.AreEqual((int)HttpStatusCode.NoContent, deleteResult.Status);
                }
            }
            else
            {
                try
                {
                    userFunctionResult = await Client.CreateUserDefinedFunctionAsync(functionId, RequestContent.Create(JsonSerializer.Serialize(functionParam)));
                    Assert.AreEqual(HttpStatusCode.BadRequest, userFunctionResult.Status);
                }
                catch (RequestFailedException ex)
                {
                    Assert.AreEqual((int)HttpStatusCode.BadRequest, ex.Status);
                    Assert.That(ex.Message, Does.Contain("User defined functions cannot be created when user defined endpoints are defined. Please apply an empty application bundle for user defined endpoints and retry"));
                }
            }
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
            [JsonPropertyName("role_name")]
            public string RoleName { get; set; } = string.Empty;
            [JsonPropertyName("role_actions")]
            public List<string> RoleActions { get; set; } = new List<string>();
        }

        private class RolesParam
        {
            [JsonPropertyName("roles")]
            public List<Role> Roles { get; set; } = new List<Role>();
        }

        private class UserFunctionParam
        {
            [JsonPropertyName("code")]
            public string Code { get; set; }

            [JsonPropertyName("id")]
            public string Id { get; set; }
        }

        private class RuntimeOptions
        {
            [JsonPropertyName("log_exception_details")]
            public bool LogExceptionDetails { get; set; }
            [JsonPropertyName("max_cached_interpreters")]
            public int MaxCachedInterpreters { get; set; }
            [JsonPropertyName("max_execution_time_ms")]
            public int MaxExecutionTimeMs { get; set; }
            [JsonPropertyName("max_heap_bytes")]
            public int MaxHeapBytes { get; set; }
            [JsonPropertyName("max_stack_bytes")]
            public int MaxStackBytes { get; set; }
            [JsonPropertyName("return_exception_details")]
            public bool ReturnExceptionDetails { get; set; }
        }

        internal const string _userDefinedEndpoint = "/content";

        internal class Endpoint
        {
            [JsonPropertyName("js_module")]
            public string JsModule { get; set; }

            [JsonPropertyName("js_function")]
            public string JsFunction { get; set; }

            [JsonPropertyName("forwarding_required")]
            public string ForwardingRequired { get; set; }

            [JsonPropertyName("redirection_strategy")]
            public string RedirectionStrategy { get; set; }

            [JsonPropertyName("authn_policies")]
            public List<string> AuthnPolicies { get; set; }

            [JsonPropertyName("mode")]
            public string Mode { get; set; }

            [JsonPropertyName("openapi")]
            public Dictionary<string, object> OpenApi { get; set; }
        }

        internal class Metadata
        {
            [JsonPropertyName("endpoints")]
            public Dictionary<string, Dictionary<string, Endpoint>> Endpoints { get; set; }
        }

        internal class Module
        {
            [JsonPropertyName("name")]
            public string Name { get; set; }

            [JsonPropertyName("module")]
            public string ModuleContent { get; set; }
        }

        internal class Bundle
        {
            [JsonPropertyName("metadata")]
            public Metadata Metadata { get; set; }

            [JsonPropertyName("modules")]
            public List<Module> Modules { get; set; }
        }
        #endregion
    }
}
