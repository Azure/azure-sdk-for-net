// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.Cose;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Security.CodeTransparency.Receipt;
using NUnit.Framework;

namespace Azure.Security.CodeTransparency.Tests
{
    public class SamplesUnitTests: ClientTestBase
    {
        private string _fileQualifierPrefix;

        private byte[] readFileBytes(string name) {
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(_fileQualifierPrefix+name))
            using (MemoryStream mem = new())
            {
                if (stream == null)
                    throw new FileNotFoundException("Resource not found: " + _fileQualifierPrefix+name);
                stream.CopyTo(mem);
                return mem.ToArray();
            }
        }

        public SamplesUnitTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void BaseSetUp() {
            var assembly = Assembly.GetExecutingAssembly();
            string mustExistFilename = "sbom.json";
            string resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith(mustExistFilename));
            Assert.IsNotNull(resourceName);
            _fileQualifierPrefix = resourceName.Split(new String[]{mustExistFilename}, StringSplitOptions.None)[0];
        }

        [Test]
        public async Task Snippet_Readme_CodeTransparencySubmission_Test()
        {
            var createResponse = new MockResponse(200);
            createResponse.SetContent("{\"operationId\": \"foobar\"}");
            var pendingResponse = new MockResponse(200);
            pendingResponse.SetContent("{\"operationId\": \"foobar\", \"status\": \"running\"}");
            var operationResponse = new MockResponse(200);
            operationResponse.SetContent("{\"operationId\": \"foobar\", \"entryId\": \"123.23\", \"status\": \"succeeded\"}");
            var entryResponse = new MockResponse(200);
            entryResponse.AddHeader("Content-Type", "application/cose");
            entryResponse.SetContent(new byte[] { 0x01, 0x02, 0x03 });
            var mockTransport = new MockTransport(createResponse, pendingResponse, operationResponse, entryResponse);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://foo.bar.com"
            };

            #region Snippet:CodeTransparencySubmission
#if !SNIPPET
            CodeTransparencyClient client = new(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);
#endif
#if SNIPPET
            CodeTransparencyClient client = new(new Uri("https://<< service name >>.confidential-ledger.azure.com"), null);
#endif
#if !SNIPPET
            BinaryData content = BinaryData.FromString("Hello World!");
#endif
#if SNIPPET
            FileStream fileStream = File.OpenRead("signature.cose");
            BinaryData content = BinaryData.FromStream(fileStream);
#endif
            Operation<GetOperationResult> operation = await client.CreateEntryAsync(content);
            Response<GetOperationResult> operationResult = await operation.WaitForCompletionAsync();
            Console.WriteLine($"The entry id to use to get the entry and receipt is {{{operationResult.Value.EntryId}}}");
            Response<BinaryData> signatureWithReceiptResponse = await client.GetEntryAsync(operationResult.Value.EntryId, true);
            BinaryData signatureWithReceipt = signatureWithReceiptResponse.Value;
            byte[] signatureWithReceiptBytes = signatureWithReceipt.ToArray();
            #endregion

            Assert.AreEqual("123.23", operationResult.Value.EntryId);
            Assert.AreEqual(new byte[] { 0x01, 0x02, 0x03 }, signatureWithReceiptBytes);
        }

        [Test]
        public void Snippet_Readme_CodeTransparencyVerification_Test()
        {
            byte[] signatureWithReceiptBytes = readFileBytes("sbom.descriptor.2022-12-10.embedded.did.2023-02-13.cose");
            var didDocBytes = readFileBytes("service.2023-03.did.json");
            var didDoc = DidDocument.DeserializeDidDocument(JsonDocument.Parse(didDocBytes).RootElement);
            #region Snippet:CodeTransparencyVerification
#if !SNIPPET
            CcfReceiptVerifier.RunVerification(signatureWithReceiptBytes, null, didRef => {
                Assert.AreEqual("https://preview-test.scitt.azure.net/.well-known/did.json", didRef.DidDocUrl.ToString());
                return didDoc;
            });
#endif
#if SNIPPET
            CcfReceiptVerifier.RunVerification(signatureWithReceiptBytes);
#endif
            #endregion
        }

        [Test]
        public async Task Snippet_Sample1_Test()
        {
           var createResponse = new MockResponse(200);
            createResponse.SetContent("{\"operationId\": \"foobar\"}");
            var pendingResponse = new MockResponse(200);
            pendingResponse.SetContent("{\"operationId\": \"foobar\", \"status\": \"running\"}");
            var operationResponse = new MockResponse(200);
            operationResponse.SetContent("{\"operationId\": \"foobar\", \"entryId\": \"123.23\", \"status\": \"succeeded\"}");
            var entryResponse = new MockResponse(200);
            entryResponse.AddHeader("Content-Type", "application/cose");
            entryResponse.SetContent(new byte[] { 0x01, 0x02, 0x03 });
            var mockTransport = new MockTransport(createResponse, pendingResponse, operationResponse, entryResponse);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://foo.bar.com"
            };
            #region Snippet:CodeTransparencySample1_CreateClient
#if !SNIPPET
            CodeTransparencyClient client = new(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);
#endif
#if SNIPPET
            CodeTransparencyClient client = new(new Uri("https://<< service name >>.confidential-ledger.azure.com"), null);
#endif
            #endregion

            #region Snippet:CodeTransparencySample1_SendSignature
#if !SNIPPET
            BinaryData content = BinaryData.FromString("Hello World!");
#endif
#if SNIPPET
            FileStream fileStream = File.OpenRead("signature.cose");
            BinaryData content = BinaryData.FromStream(fileStream);
#endif
            Operation<GetOperationResult> operation = await client.CreateEntryAsync(content);
            #endregion

            #region Snippet:CodeTransparencySample1_WaitForResult
            Response<GetOperationResult> response = await operation.WaitForCompletionAsync();
            GetOperationResult value = response.Value;
            Console.WriteLine($"The entry id to use to get the entry and receipt is {{{value.EntryId}}}");
            #endregion

            Assert.AreEqual("https://foo.bar.com/entries?api-version=2024-01-11-preview", mockTransport.Requests[0].Uri.ToString());
            Assert.AreEqual("foobar", operation.Id);
            Assert.AreEqual("123.23", value.EntryId);
        }

        [Test]
        public async Task Snippet_Sample2_Test()
        {
            byte[] signatureWithReceiptBytes = readFileBytes("sbom.descriptor.2022-12-10.embedded.did.2023-02-13.cose");
            var signatureWithReceiptDidDocBytes = readFileBytes("service.2023-03.did.json");
            var signatureWithReceiptDidDoc = DidDocument.DeserializeDidDocument(JsonDocument.Parse(signatureWithReceiptDidDocBytes).RootElement);
            byte[] receiptBytes = readFileBytes("artifact.2023-03-03.receipt.did.2023-03-03.cbor");
            byte[] signatureBytes = readFileBytes("artifact.2023-03-03.cose");
            var receiptDidDocBytes = readFileBytes("service.2023-02.did.json");
            var receiptDidDoc = DidDocument.DeserializeDidDocument(JsonDocument.Parse(receiptDidDocBytes).RootElement);

            var signatureWithReceiptResp = new MockResponse(200);
            signatureWithReceiptResp.AddHeader("Content-Type", "application/cose");
            signatureWithReceiptResp.SetContent(signatureWithReceiptBytes);
            var receiptResp = new MockResponse(200);
            receiptResp.AddHeader("Content-Type", "application/cbor");
            receiptResp.SetContent(receiptBytes);
            var mockTransport = new MockTransport(signatureWithReceiptResp, receiptResp);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://foo.bar.com"
            };

            #region Snippet:CodeTransparencySample2_CreateClient
#if !SNIPPET
            CodeTransparencyClient client = new(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);
#endif
#if SNIPPET
            CodeTransparencyClient client = new(new Uri("https://<< service name >>.confidential-ledger.azure.com"), null);
#endif
            #endregion
            #region Snippet:CodeTransparencySample2_GetEntryWithEmbeddedReceipt
            Response<BinaryData> signatureWithReceipt = await client.GetEntryAsync("2.34", true);
            #endregion
            #region Snippet:CodeTransparencySample2_GetRawReceipt
            Response<BinaryData> receipt = await client.GetEntryReceiptAsync("2.34");
            #endregion
            #region Snippet:CodeTransparencySample2_VerifyEntryWithEmbeddedReceipt
#if !SNIPPET
            CcfReceiptVerifier.RunVerification(signatureWithReceipt.Value.ToArray(), null, didRef => {
                return signatureWithReceiptDidDoc;
            });
#endif
#if SNIPPET
            CcfReceiptVerifier.RunVerification(signatureWithReceipt.Value.ToArray());
#endif
            #endregion

            #region Snippet:CodeTransparencySample2_VerifyEntryAndReceipt
#if !SNIPPET
            CcfReceiptVerifier.RunVerification(receipt.Value.ToArray(), signatureBytes, didRef => {
                return receiptDidDoc;
            });
#endif
#if SNIPPET
            CcfReceiptVerifier.RunVerification(receipt.Value.ToArray(), signatureBytes);
#endif
            #endregion
        }

        [Test]
        public void Snippet_Sample3_Test()
        {
            #region Snippet:CodeTransparencySample3_CreateClientWithCredentials
            TokenCredential credential = new DefaultAzureCredential();
            string[] scopes = { "https://your.service.scope/.default" };
#if !SNIPPET
            AccessToken accessToken = new("token", DateTimeOffset.Now.AddHours(1));
            CodeTransparencyClient client = new(new Uri("https://foo.bar.com"), new AzureKeyCredential(accessToken.Token));
#endif
#if SNIPPET
            AccessToken accessToken = credential.GetToken(new TokenRequestContext(scopes), CancellationToken.None);
            CodeTransparencyClient client = new(new Uri("https://<< service name >>.confidential-ledger.azure.com"), new AzureKeyCredential(accessToken.Token));
#endif
            #endregion
        }

        [Test]
        public async Task Snippet_Sample4_Test()
        {
            byte[] notMatchingSigBytes = readFileBytes("sbom.descriptor.2022-12-10.cose");
            byte[] matchingSigBytes = readFileBytes("artifact.2023-03-03.cose");
            var page1 = new MockResponse(200);
            page1.SetContent("{\"transactionIds\": [ \"2.1\",\"2.2\",\"2.3\" ], \"nextLink\":\"/entries/txIds?from=3&to=6\"}");
            var page2 = new MockResponse(200);
            page2.SetContent("{\"transactionIds\": [ \"3.4\",\"3.5\",\"3.6\" ], \"nextLink\":\"/entries/txIds?from=7\"}");
            var page3 = new MockResponse(200);
            page3.SetContent("{\"transactionIds\": [ \"4.7\" ]}");

            var notMatchingEntryResp = new MockResponse(200);
            notMatchingEntryResp.AddHeader("Content-Type", "application/cose");
            notMatchingEntryResp.SetContent(notMatchingSigBytes);

            var matchingEntryResp = new MockResponse(200);
            matchingEntryResp.AddHeader("Content-Type", "application/cose");
            matchingEntryResp.SetContent(matchingSigBytes);

            // the last entry matches the search criteria
            var mockTransport = new MockTransport(page1, notMatchingEntryResp, notMatchingEntryResp, notMatchingEntryResp, page2, notMatchingEntryResp, notMatchingEntryResp, notMatchingEntryResp, page3, matchingEntryResp);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://foo.bar.com"
            };

            #region Snippet:CodeTransparencySample4_CreateClient
#if !SNIPPET
            CodeTransparencyClient client = new(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);
#endif
#if SNIPPET
            CodeTransparencyClient client = new(new Uri("https://<< service name >>.confidential-ledger.azure.com"), null);
#endif
            #endregion
            #region Snippet:CodeTransparencySample4_IterateOverEntries
            byte[] signature = null;
            AsyncPageable<string> response = client.GetEntryIdsAsync();
            await foreach (Page<string> page in response.AsPages())
            {
                // Process ids in the page response
                foreach (string entryId in page.Values)
                {
                    // Download the signature and check if it contains the value you are looking for
                    BinaryData entry = client.GetEntry(entryId, false);
                    byte[] entryBytes = entry.ToArray();
                    CoseSign1Message coseSign1Message = CoseMessage.DecodeSign1(entryBytes);
                    // Check if the payload embedded in the signature contains a value
                    if (Encoding.ASCII.GetString(coseSign1Message.Content.Value.ToArray()).Contains("\"foo\""))
                    {
                        signature = entryBytes;
                        break;
                    }
                }
                if (signature != null)
                {
                    // do not fetch any further pages
                    break;
                }
            }
            #endregion

            Assert.AreEqual(10, mockTransport.Requests.Count, "There should be 3 pages of entries and 7 requests to fetch them");
            Assert.NotNull(signature, "Signature should have been found");
        }
    }
}
