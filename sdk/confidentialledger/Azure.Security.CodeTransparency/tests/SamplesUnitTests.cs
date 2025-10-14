// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic; // Added for List<T>
using System.Formats.Cbor;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.Cose;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Security.CodeTransparency.Receipt;
using NUnit.Framework;

namespace Azure.Security.CodeTransparency.Tests
{
    public class SamplesUnitTests : ClientTestBase
    {
        private string _fileQualifierPrefix;

        private byte[] readFileBytes(string name)
        {
            var assembly = Assembly.GetExecutingAssembly();
            using (Stream stream = assembly.GetManifestResourceStream(_fileQualifierPrefix + name))
            using (MemoryStream mem = new())
            {
                if (stream == null)
                    throw new FileNotFoundException("Resource not found: " + _fileQualifierPrefix + name);
                stream.CopyTo(mem);
                return mem.ToArray();
            }
        }

        public SamplesUnitTests(bool isAsync) : base(isAsync)
        {
        }

        [SetUp]
        public void BaseSetUp()
        {
            var assembly = Assembly.GetExecutingAssembly();
            string mustExistFilename = "transparent_statement.cose";
            string resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith(mustExistFilename));
            Assert.IsNotNull(resourceName);
            _fileQualifierPrefix = resourceName.Split(new String[] { mustExistFilename }, StringSplitOptions.None)[0];
        }

        [Test]
        public async Task Snippet_Readme_CodeTransparencySubmission_Test()
        {
            // Create a CBOR writer
            var createCborWriter = new CborWriter();

            // Write a CBOR map with sample content
            createCborWriter.WriteStartMap(1);
            createCborWriter.WriteTextString("OperationId");
            createCborWriter.WriteTextString("123.45");
            createCborWriter.WriteEndMap();

            var createResponse = new MockResponse(201);
            createResponse.SetContent(createCborWriter.Encode());

            var succeededCborWriter = new CborWriter();

            // Write a CBOR map with sample content
            succeededCborWriter.WriteStartMap(3);
            succeededCborWriter.WriteTextString("OperationId");
            succeededCborWriter.WriteTextString("1.345");
            succeededCborWriter.WriteTextString("EntryId");
            succeededCborWriter.WriteTextString("123.23");
            succeededCborWriter.WriteTextString("Status");
            succeededCborWriter.WriteTextString("Succeeded");
            succeededCborWriter.WriteEndMap();

            var succeededResponse = new MockResponse(202);
            succeededResponse.SetContent(succeededCborWriter.Encode());

            var entryResponse = new MockResponse(200);
            entryResponse.AddHeader("Content-Type", "application/cose");
            entryResponse.SetContent(new byte[] { 0x01, 0x02, 0x03 });

            var mockTransport = new MockTransport(createResponse, succeededResponse, entryResponse, entryResponse);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://foo.bar.com"
            };

            #region Snippet:CodeTransparencySubmission
            #region Snippet:CodeTransparencySample_CreateClient
#if !SNIPPET
            CodeTransparencyClient client = new(new Uri("https://foo.bar.com"), options);
#endif
#if SNIPPET
            CodeTransparencyClient client = new(new Uri("https://<< service name >>.confidential-ledger.azure.com"));
#endif
            #endregion Snippet:CodeTransparencySample_CreateClient
#if !SNIPPET
            BinaryData content = BinaryData.FromString("Hello World!");
#endif
#if SNIPPET
            FileStream fileStream = File.OpenRead("signature.cose");
            BinaryData content = BinaryData.FromStream(fileStream);
#endif
            Operation<BinaryData> operation = await client.CreateEntryAsync(WaitUntil.Started, content);
            #endregion Snippet:CodeTransparencySubmission

            #region Snippet:CodeTransparencyDownloadTransparentStatement
            #region Snippet:CodeTransparencySample1_WaitForResult
            Response<BinaryData> operationResult = await operation.WaitForCompletionAsync();
            string entryId = CborUtils.GetStringValueFromCborMapByKey(operationResult.Value.ToArray(), "EntryId");
            Console.WriteLine($"The entry ID to use to retrieve the receipt and transparent statement is {{{entryId}}}");
            #endregion Snippet:CodeTransparencySample1_WaitForResult
            #region Snippet:CodeTransparencySample2_GetEntryStatement
            Response<BinaryData> transparentStatementResponse = await client.GetEntryStatementAsync(entryId);
            #endregion Snippet:CodeTransparencySample2_GetEntryStatement
            #endregion Snippet:CodeTransparencyDownloadTransparentStatement

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);

            #region Snippet:CodeTransparencySample2_GetRawReceipt
#if SNIPPET
            Response<BinaryData> receipt = await client.GetEntryAsync(entryId);
#endif
            #endregion Snippet:CodeTransparencySample2_GetRawReceipt

            BinaryData transparentStatement = transparentStatementResponse.Value;
            byte[] transparentStatementBytes = transparentStatement.ToArray();
            #region Snippet:CodeTransparencySample1_DownloadStatement
#if SNIPPET
            Response<BinaryData> transparentStatementResponse = client.GetEntryStatement(entryId);
#endif
            #endregion Snippet:CodeTransparencySample1_DownloadStatement
            #region Snippet:CodeTransparencyVerificationUsingTransparentStatementFile
#if SNIPPET
            byte[] transparentStatementBytes = File.ReadAllBytes("transparent_statement.cose");
            try
            {
                CodeTransparencyClient client = new(transparentStatementBytes);
                client.RunTransparentStatementVerification(transparentStatementBytes);
                Console.WriteLine("Verification succeeded: The statement was registered in the immutable ledger.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Verification failed: {e.Message}");
            }
#endif
            #endregion Snippet:CodeTransparencyVerificationUsingTransparentStatementFile
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
            #endregion Snippet:CodeTransparencySample3_CreateClientWithCredentials
        }

        [Test]
        public void Snippet_Readme_CodeTransparencyVerification_Test()
        {
#if NET462
            Assert.Ignore("JsonWebKey to ECDsa is not supported on net462.");
#else
            var content = new MockResponse(200);
            content.SetContent("{\"keys\":" +
                "[{\"crv\": \"P-384\"," +
                "\"kid\":\"1dd54f9b6272971320c95850f74a9459c283b375531173c3d5d9bfd5822163cb\"," +
                "\"kty\":\"EC\"," +
                "\"x\": \"WAHDpC-ECgc7LvCxlaOPsY-xVYF9iStcEPU3XGF8dlhtb6dMHZSYVPMs2gliK-gc\"," +
                "\"y\": \"xJ7fI2kA8gs11XDc9h2zodU-fZYRrE0UJHpzPfDVJrOpTvPcDoC5EWOBx9Fks0bZ\"" +
                "}]}");

            var mockTransport = new MockTransport(content);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://foo.bar.com"
            };
            var client = new CodeTransparencyClient(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);

            byte[] transparentStatementBytes = readFileBytes("transparent_statement.cose");
            #region Snippet:CodeTransparencyVerification
#if SNIPPET
            Response<BinaryData> transparentStatementResponse = client.GetEntryStatement(entryId);
            byte[] transparentStatementBytes = transparentStatementResponse.Value.ToArray();
            try
            {
                client.RunTransparentStatementVerification(transparentStatementBytes);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
#endif
            #endregion
#endif
        }

        [Test]
        public void Snippet_Readme_CodeTransparencyCcfReceiptVerifier_Test()
        {
#if NET462
            Assert.Ignore("JsonWebKey to ECDsa is not supported on net462.");
#else
            var content = new MockResponse(200);
            content.SetContent("{\"keys\":" +
                "[{\"crv\": \"P-384\"," +
                "\"kid\":\"fb29ce6d6b37e7a0b03a5fc94205490e1c37de1f41f68b92e3620021e9981d01\"," +
                "\"kty\":\"EC\"," +
                "\"x\": \"Tv_tP9eJIb5oJY9YB6iAzMfds4v3N84f8pgcPYLaxd_Nj3Nb_dBm6Fc8ViDZQhGR\"," +
                "\"y\": \"xJ7fI2kA8gs11XDc9h2zodU-fZYRrE0UJHpzPfDVJrOpTvPcDoC5EWOBx9Fks0bZ\"" +
                "}]}");

            var mockTransport = new MockTransport(content);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://foo.bar.com"
            };
            var client = new CodeTransparencyClient(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);
            Response<JwksDocument> jwksDoc = client.GetPublicKeys();
            JsonWebKey jsonWebKey = jwksDoc.Value.Keys[0];
            byte[] inputReceipt = readFileBytes("receipt.cose");
            byte[] inputSignedStatement = readFileBytes("input_signed_claims");

            #region Snippet:CodeTransparencyVerification_VerifyReceiptAndInputSignedStatement
#if SNIPPET
            JsonWebKey jsonWebKey = new JsonWebKey(<.....>);
            byte[] inputSignedStatement = readFileBytes("<input_signed_claims>");
            byte[] inputReceipt = readFileBytes("<input_receipt>");
#endif
            try
            {
                CcfReceiptVerifier.VerifyTransparentStatementReceipt(jsonWebKey, inputReceipt, inputSignedStatement);
                Console.WriteLine("Verification succeeded: The statement was registered in the immutable ledger.");
            }
            catch (Exception e)
            {
                Console.WriteLine($"Verification failed: {e.Message}");
            }
            #endregion Snippet:CodeTransparencyVerification_VerifyReceiptAndInputSignedStatement

#endif
        }

        [Test]
        public void Snippet_Readme_DeserializeTransparentStatement_Test()
        {
#if NET462
            Assert.Ignore("JsonWebKey to ECDsa is not supported on net462.");
#else
            #region Snippet:DeserializeTransparentStatement_Sample1
            // Read the transparent statement bytes from disk.
#if !SNIPPET
            byte[] transparentStatement = readFileBytes("transparent_statement.cose");
#endif
#if SNIPPET
            byte[] transparentStatement = File.ReadAllBytes("<input_file>");
#endif

            CoseSign1Message inputSignedStatement;
            try
            {
                inputSignedStatement = CoseMessage.DecodeSign1(transparentStatement);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to decode transparent statement: {ex.Message}");
                return; // Stop if decoding fails.
            }

            // Access the signed payload.
            ReadOnlyMemory<byte> payload = inputSignedStatement.Content ?? ReadOnlyMemory<byte>.Empty;
            // Use payload as needed.

            // Access the embedded receipts in unprotected headers.
            if (!inputSignedStatement.UnprotectedHeaders.TryGetValue(
                    new CoseHeaderLabel(CcfReceipt.CoseHeaderEmbeddedReceipts),
                    out CoseHeaderValue embeddedReceipts))
            {
                Console.WriteLine("Receipts are not present.");
                return;
            }

            // Parse CBOR array of receipt COSE_Sign1 messages.
            var reader = new CborReader(embeddedReceipts.EncodedValue);
            if (reader.PeekState() != CborReaderState.StartArray)
            {
                Console.WriteLine("Embedded receipts value is not a CBOR array.");
                return;
            }

            reader.ReadStartArray();
            var receiptBytesList = new List<byte[]>();
            while (reader.PeekState() != CborReaderState.EndArray)
            {
                receiptBytesList.Add(reader.ReadByteString());
            }
            reader.ReadEndArray();

            for (int i = 0; i < receiptBytesList.Count; i++)
            {
                try
                {
                    CoseSign1Message receipt = CoseMessage.DecodeSign1(receiptBytesList[i]);
                    // Inspect receipt (headers/signature) as needed.
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Failed to decode receipt #{i}: {ex.Message}");
                }
            }
            #endregion Snippet:DeserializeTransparentStatement_Sample1
#endif
        }
    }
}
