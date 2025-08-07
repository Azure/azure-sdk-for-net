// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Formats.Cbor;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using Azure.Identity;
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

            var mockTransport = new MockTransport(createResponse, succeededResponse, entryResponse);
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

            #region Snippet:CodeTransparencySample1_WaitForResult
            Response<BinaryData> operationResult = await operation.WaitForCompletionAsync();

            string entryId = string.Empty;
            CborReader cborReader = new CborReader(operationResult.Value);
            cborReader.ReadStartMap();
            while (cborReader.PeekState() != CborReaderState.EndMap)
            {
                string key = cborReader.ReadTextString();
                if (key == "EntryId")
                {
                    entryId = cborReader.ReadTextString();
                }
                else
                    cborReader.SkipValue();
            }

            Console.WriteLine($"The entry id to use to get the receipt and Transparent Statement is {{{entryId}}}");
            #endregion Snippet:CodeTransparencySample1_WaitForResult

            #region Snippet:CodeTransparencySample2_GetEntryStatement
            Response<BinaryData> signatureWithReceiptResponse = await client.GetEntryStatementAsync(entryId);
            #endregion Snippet:CodeTransparencySample2_GetEntryStatement

            #region Snippet:CodeTransparencySample2_GetRawReceipt
#if SNIPPET
            Response<BinaryData> receipt = await client.GetEntryAsync(entryId);
#endif
            #endregion Snippet:CodeTransparencySample2_GetRawReceipt

            BinaryData signatureWithReceipt = signatureWithReceiptResponse.Value;
            byte[] signatureWithReceiptBytes = signatureWithReceipt.ToArray();

            #region Snippet:CodeTransparencySample2_VerifyReceiptAndInputSignedStatement
#if SNIPPET
            // Create a JsonWebKey
            JsonWebKey jsonWebKey = new JsonWebKey(<.....>);
            byte[] inputSignedStatement = readFileBytes("<input_signed_claims");

            try
            {
                CcfReceiptVerifier.VerifyTransparentStatementReceipt(jsonWebKey, signatureWithReceiptBytes, inputSignedStatement);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
#endif
            #endregion Snippet:CodeTransparencySample2_VerifyReceiptAndInputSignedStatement

            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);
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
            Response<BinaryData> transparentStatement = client.GetEntryStatement(entryId);
            byte[] transparentStatementBytes = transparentStatement.Value.ToArray();

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

            byte[] receiptBytes = readFileBytes("receipt.cose");
            byte[] inputSignedPayloadBytes = readFileBytes("input_signed_claims");

            #region Snippet:CodeTransparencyVerifyReceipt
#if SNIPPET
            Response<JwksDocument> key = client.GetPublicKeys();

            CcfReceiptVerifier.VerifyTransparentStatementReceipt(key.Value.Keys[0], receiptBytes, inputSignedPayloadBytes);
#endif
            #endregion Snippet:CodeTransparencyVerifyReceipt

#endif
        }
    }
}
