// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Security.CodeTransparency.Tests
{
    public class CodeTransparencyClientRecordedTests : CodeTransparencyRecordedTestBase
    {
        private string _fileQualifierPrefix;

        public CodeTransparencyClientRecordedTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void SetUpTestFiles()
        {
            var assembly = Assembly.GetExecutingAssembly();
            string mustExistFilename = "input_signed_claims";
            string resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith(mustExistFilename));
            _fileQualifierPrefix = resourceName.Split(new string[] { mustExistFilename }, StringSplitOptions.None)[0];
        }

        private byte[] ReadFileBytes(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using Stream stream = assembly.GetManifestResourceStream(_fileQualifierPrefix + name);
            if (stream == null)
                throw new FileNotFoundException("Resource not found: " + _fileQualifierPrefix + name);
            using MemoryStream mem = new();
            stream.CopyTo(mem);
            return mem.ToArray();
        }

        /// <summary>
        /// Creates an entry and returns the entryId.
        /// Handles both 201 (pending, parse OperationId from CBOR body) and
        /// 303 (already committed, extract entryId from Location header).
        /// </summary>
        private async Task<string> CreateEntryAndGetEntryIdAsync()
        {
            byte[] coseSignature = ReadFileBytes("input_signed_claims");
            var body = BinaryData.FromBytes(coseSignature);

            Response<BinaryData> createResponse = await Client.CreateEntryAsync(body, waitForCommit: false);
            int status = createResponse.GetRawResponse().Status;

            if (status == 303)
            {
                // Already committed — extract entryId from Location header
                // Location format: https://host/entries/{entryId}
                createResponse.GetRawResponse().Headers.TryGetValue("Location", out string location);
                Assert.IsNotNull(location, "303 response must include Location header");
                var uri = new Uri(location);
                string entryId = uri.Segments.Last();
                Assert.IsNotEmpty(entryId);
                return entryId;
            }
            else
            {
                // 201 — entry accepted, parse OperationId and poll
                Assert.AreEqual(201, status);
                string operationId = CborUtils.GetStringValueFromCborMapByKey(
                    createResponse.Value.ToArray(), "OperationId");
                Assert.IsNotEmpty(operationId);
                return operationId;
            }
        }

        [RecordedTest]
        [LiveOnly]
        public async Task GetTransparencyConfigCbor()
        {
            Response response = await Client.GetTransparencyConfigCborAsync(new RequestContext());

            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
            Assert.IsNotNull(response.Content);
            Assert.IsTrue(response.Content.ToMemory().Length > 0);
        }

        [RecordedTest]
        [LiveOnly]
        public async Task GetPublicKeys()
        {
            Response response = await Client.GetPublicKeysAsync(new RequestContext());

            Assert.AreEqual((int)HttpStatusCode.OK, response.Status);
            Assert.IsNotNull(response.Content);
        }

        [RecordedTest]
        [LiveOnly]
        public async Task CreateEntryReturnsValidResponse()
        {
            byte[] coseSignature = ReadFileBytes("input_signed_claims");
            var body = BinaryData.FromBytes(coseSignature);

            Response<BinaryData> createResponse = await Client.CreateEntryAsync(body, waitForCommit: false);
            int status = createResponse.GetRawResponse().Status;

            Assert.That(status, Is.EqualTo(201).Or.EqualTo(303));

            if (status == 303)
            {
                createResponse.GetRawResponse().Headers.TryGetValue("Location", out string location);
                Assert.IsNotNull(location, "303 must include Location header");
                Assert.That(location, Does.Contain("/entries/"));
            }
            else
            {
                Assert.IsNotNull(createResponse.Value);
                string operationId = CborUtils.GetStringValueFromCborMapByKey(
                    createResponse.Value.ToArray(), "OperationId");
                Assert.IsNotEmpty(operationId);
            }
        }

        [RecordedTest]
        [LiveOnly]
        public async Task GetOperationForEntry()
        {
            string id = await CreateEntryAndGetEntryIdAsync();

            // GetOperation accepts an operationId; for 303 the id is the entryId
            Response operationResponse = await Client.GetOperationAsync(id, new RequestContext());

            Assert.That(operationResponse.Status, Is.EqualTo(200).Or.EqualTo(202));
            Assert.IsNotNull(operationResponse.Content);
        }

        [RecordedTest]
        [LiveOnly]
        public async Task GetEntryForCommittedEntry()
        {
            string entryId = await CreateEntryAndGetEntryIdAsync();

            Response<BinaryData> entryResponse = await Client.GetEntryAsync(entryId);

            // Service may return 200 (entry ready) or 302 (redirect to receipt)
            Assert.That(entryResponse.GetRawResponse().Status,
                Is.EqualTo(200).Or.EqualTo(202).Or.EqualTo(302));
        }

        [RecordedTest]
        [LiveOnly]
        public async Task GetEntryStatementForCommittedEntry()
        {
            string entryId = await CreateEntryAndGetEntryIdAsync();

            Response<BinaryData> statementResponse = await Client.GetEntryStatementAsync(entryId);

            Assert.AreEqual((int)HttpStatusCode.OK, statementResponse.GetRawResponse().Status);
            Assert.IsNotNull(statementResponse.Value);
            Assert.IsTrue(statementResponse.Value.ToMemory().Length > 0);
        }

        [RecordedTest]
        [LiveOnly]
        public async Task GetEntryWithRequestContext()
        {
            string entryId = await CreateEntryAndGetEntryIdAsync();

            Response entryResponse = await Client.GetEntryAsync(entryId, new RequestContext());

            // Service may return 200 (entry ready) or 302 (redirect to receipt)
            Assert.That(entryResponse.Status,
                Is.EqualTo(200).Or.EqualTo(202).Or.EqualTo(302));
        }

        [RecordedTest]
        [LiveOnly]
        public async Task GetEntryStatementWithRequestContext()
        {
            string entryId = await CreateEntryAndGetEntryIdAsync();

            Response statementResponse = await Client.GetEntryStatementAsync(entryId, new RequestContext());

            Assert.AreEqual((int)HttpStatusCode.OK, statementResponse.Status);
            Assert.IsNotNull(statementResponse.Content);
            Assert.IsTrue(statementResponse.Content.ToMemory().Length > 0);
        }
    }
}
