// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Formats.Cbor;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Security.CodeTransparency.Tests
{
    public class CodeTransparencyClientUnitTests : ClientTestBase
    {
        private string _fileQualifierPrefix;

        /// <summary>
        /// A canned service identity response. But with a parseable cert.
        /// </summary>
        private readonly string _serviceIdentityJson = """
        {
            "ledgerTlsCertificate": "-----BEGIN CERTIFICATE-----\nMIIBvjCCAUSgAwIBAgIRALIcCHAQ8TpbFgvuNThTIFkwCgYIKoZIzj0EAwMwFjEU\nMBIGA1UEAwwLQ0NGIE5ldHdvcmswHhcNMjQwMTAzMDg1NDM2WhcNMjQwNDAyMDg1\nNDM1WjAWMRQwEgYDVQQDDAtDQ0YgTmV0d29yazB2MBAGByqGSM49AgEGBSuBBAAi\nA2IABFK177XlxO+GvJ91xjC98icJRKJbUIOSffHYEWAKojxvEa7EV1eVUINye0tU\nZJVVI5Nw2Y7Gbi7cm89Njnvz/uYUHBp/di3Rk+R4kupHEH6XErTMN93CAR4lIBOY\ndF7JpqNWMFQwEgYDVR0TAQH/BAgwBgEB/wIBADAdBgNVHQ4EFgQU4px9yVX1Ru3W\nefhlw88K2zmyFQEwHwYDVR0jBBgwFoAU4px9yVX1Ru3Wefhlw88K2zmyFQEwCgYI\nKoZIzj0EAwMDaAAwZQIwG20Zjw5WPVoW6jsIchwSnfhniJNr0xF8hJJKUXIfyEDo\nnPewSdWnE4RubOm/ctMYAjEAlvwpdzSDFg57beLfq0bhaznxGOBpYQXl+q1uzm/S\nPup20CFNsp8G8m7w076DGJEA\n-----END CERTIFICATE-----\n",
            "ledgerId": "cts-canary"
        }
        """;

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

        [SetUp]
        public void BaseSetUp()
        {
            var assembly = Assembly.GetExecutingAssembly();
            string mustExistFilename = "transparent_statement.cose";
            string resourceName = assembly.GetManifestResourceNames().Single(str => str.EndsWith(mustExistFilename));
            Assert.IsNotNull(resourceName);
            _fileQualifierPrefix = resourceName.Split(new String[] { mustExistFilename }, StringSplitOptions.None)[0];
        }

        private MockResponse createValidIdentityResponse()
        {
            var mockedResponse = new MockResponse(200);
            mockedResponse.SetContent(_serviceIdentityJson);
            return mockedResponse;
        }

        public CodeTransparencyClientUnitTests(bool isAsync) : base(isAsync)
        {
        }

        [Test]
        public void CodeTransparencyClient_constructor_does_not_request_to_get_cert()
        {
            var mockTransport = new MockTransport(createValidIdentityResponse());
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://foo.bar.com"
            };
            var _ = new CodeTransparencyClient(new Uri("https://foo.bar.com"), null, options);
            Assert.AreEqual(0, mockTransport.Requests.Count);
        }

        [Test]
        public void CodeTransparencyClient_constructor_throws_if_invalid_file()
        {
            byte[] transparentStatementCoseSign1Bytes = new byte[] { 0x01, 0x02, 0x03 /* invalid bytes */ };

            Assert.Throws<CryptographicException>(() => new CodeTransparencyClient(transparentStatementCoseSign1Bytes));
        }

        [Test]
        public void CodeTransparencyClient_constructor_uses_valid_cose_file()
        {
            byte[] transparentStatementBytes = readFileBytes("transparent_statement.cose");

            Assert.DoesNotThrow(() => new CodeTransparencyClient(transparentStatementBytes));
        }

        [Test]
        public async Task CreateEntryAsync_sendsBytes_receives_bytes()
        {
            // Create a CBOR writer
            var writer = new CborWriter();

            // Write a CBOR map with sample content
            writer.WriteStartMap(2);
            writer.WriteTextString("OperationId");
            writer.WriteTextString("12.345");
            writer.WriteTextString("Status");
            writer.WriteTextString("Succeeded");
            writer.WriteEndMap();

            // Get the CBOR encoded bytes
            byte[] cborBytes = writer.Encode();

            var mockedResponse = new MockResponse(201);
            mockedResponse.AddHeader("Content-Type", "application/cose");
            mockedResponse.SetContent(cborBytes);
            var mockTransport = new MockTransport(mockedResponse);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://foo.bar.com"
            };

            CodeTransparencyClient client = new(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);
            BinaryData content = BinaryData.FromString("Hello World!");
            Operation<BinaryData> response = await client.CreateEntryAsync(WaitUntil.Started, content);

            Assert.AreEqual("https://foo.bar.com/entries?api-version=2025-01-31-preview", mockTransport.Requests[0].Uri.ToString());
            Assert.AreEqual(false, response.HasCompleted);
            Assert.AreEqual("12.345", response.Id);
        }

        [Test]
        public async Task CreateEntryAsync_request_accepted()
        {
            // Create a CBOR writer
            var writer = new CborWriter();

            // Write a CBOR map with sample content
            writer.WriteStartMap(2);
            writer.WriteTextString("OperationId");
            writer.WriteTextString("12.345");
            writer.WriteTextString("Status");
            writer.WriteTextString("Succeeded");
            writer.WriteEndMap();

            // Get the CBOR encoded bytes
            byte[] cborBytes = writer.Encode();

            var mockedResponse = new MockResponse(202);
            mockedResponse.SetContent(cborBytes);
            var mockTransport = new MockTransport(mockedResponse);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://foo.bar.com"
            };

            CodeTransparencyClient client = new(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);
            BinaryData content = BinaryData.FromString("Hello World!");
            Operation<BinaryData> response = await client.CreateEntryAsync(WaitUntil.Started, content);

            Assert.AreEqual("https://foo.bar.com/entries?api-version=2025-01-31-preview", mockTransport.Requests[0].Uri.ToString());
            Assert.AreEqual(1, mockTransport.Requests.Count);
            Assert.AreEqual(false, response.HasCompleted);
            Assert.AreEqual("12.345", response.Id);
        }

        [Test]
        public async Task CreateEntryAsync_unsuccessful_post_success_after_retry()
        {
            // Create a CBOR writer
            var writer = new CborWriter();

            // Write a CBOR map with sample content
            writer.WriteStartMap(2);
            writer.WriteTextString("OperationId");
            writer.WriteTextString("12.345");
            writer.WriteTextString("Status");
            writer.WriteTextString("Running");
            writer.WriteEndMap();

            var mockedResponse = new MockResponse(201);
            mockedResponse.SetContent(writer.Encode());

            var mockTransport = new MockTransport(new MockResponse(503), mockedResponse);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://foo.bar.com"
            };
            var client = new CodeTransparencyClient(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);
            BinaryData content = BinaryData.FromString("Hello World!");
            Operation<BinaryData> response = await client.CreateEntryAsync(WaitUntil.Started, content);

            Assert.AreEqual(2, mockTransport.Requests.Count);
            Assert.AreEqual("https://foo.bar.com/entries?api-version=2025-01-31-preview", mockTransport.Requests[1].Uri.ToString());
            Assert.AreEqual("12.345", response.Id);
        }

        [Test]
        public async Task CreateEntryAsync_waits_for_operation_success()
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

            // Create a CBOR writer
            var cborWriter = new CborWriter();

            // Write a CBOR map with sample content
            cborWriter.WriteStartMap(2);
            cborWriter.WriteTextString("OperationId");
            cborWriter.WriteTextString("1.345");
            cborWriter.WriteTextString("Status");
            cborWriter.WriteTextString("Running");
            cborWriter.WriteEndMap();

            var pendingResponse = new MockResponse(202);
            pendingResponse.SetContent(cborWriter.Encode());

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

            var mockTransport = new MockTransport(createResponse, pendingResponse, succeededResponse);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://foo.bar.com"
            };
            CodeTransparencyClient client = new CodeTransparencyClient(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);

            Operation<BinaryData> result = await client.CreateEntryAsync(WaitUntil.Started, BinaryData.FromString("Hello World!"));

            Assert.NotNull(result);

            Response<BinaryData> response = await result.WaitForCompletionAsync();
            BinaryData value = response.Value;

            CborReader cborReader = new CborReader(value);
            cborReader.ReadStartMap();
            while (cborReader.PeekState() != CborReaderState.EndMap)
            {
                string key = cborReader.ReadTextString();
                if (key == "Status")
                {
                    Assert.AreEqual(expected: "Succeeded", cborReader.ReadTextString());
                }
                else if (key == "OperationId")
                {
                    Assert.AreEqual(expected: "1.345", cborReader.ReadTextString());
                }
                else if (key == "EntryId")
                {
                    Assert.AreEqual(expected: "123.23", cborReader.ReadTextString());
                }
            }
            cborReader.ReadEndMap();

            Assert.AreEqual(3, mockTransport.Requests.Count);
            Assert.IsTrue(result.HasCompleted);
            Assert.IsTrue(result.HasValue);
        }

        [Test]
        public void CreateEntry_ShouldReturnResponse()
        {
            // Create a CBOR writer
            var writer = new CborWriter();

            // Write a CBOR map with sample content
            writer.WriteStartMap(2);
            writer.WriteTextString("OperationId");
            writer.WriteTextString("12.345");
            writer.WriteTextString("Status");
            writer.WriteTextString("Running");
            writer.WriteEndMap();

            var mockedResponse = new MockResponse(201);
            mockedResponse.SetContent(writer.Encode());

            var mockTransport = new MockTransport(mockedResponse);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://foo.bar.com"
            };
            CodeTransparencyClient client = new CodeTransparencyClient(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);

            Operation<BinaryData> result = client.CreateEntry(WaitUntil.Started, BinaryData.FromString("test-body"));

            Assert.AreEqual(1, mockTransport.Requests.Count);
            Assert.IsFalse(result.HasCompleted);
        }

        [Test]
        public async Task GetEntryAsync_gets_entry_bytes_after_retry()
        {
            var mockedResponse = new MockResponse(200);
            mockedResponse.AddHeader("Content-Type", "application/cose");
            mockedResponse.SetContent(new byte[] { 0x01, 0x02, 0x03 });
            var mockTransport = new MockTransport(new MockResponse(503), mockedResponse);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://foo.bar.com"
            };
            var client = new CodeTransparencyClient(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);
            Response<BinaryData> response = await client.GetEntryAsync("4.44");

            Assert.AreEqual("https://foo.bar.com/entries/4.44?api-version=2025-01-31-preview", mockTransport.Requests[1].Uri.ToString());
            Assert.AreEqual(expected: 200, response.GetRawResponse().Status);
        }

        [Test]
        public async Task GetEntryAsync_gets_entry_bytes()
        {
            var mockedResponse = new MockResponse(200);
            mockedResponse.AddHeader("Content-Type", "application/cose");
            mockedResponse.SetContent(new byte[] { 0x01, 0x02, 0x03 });
            var mockTransport = new MockTransport(mockedResponse);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://foo.bar.com"
            };
            var client = new CodeTransparencyClient(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);
            Response<BinaryData> response = await client.GetEntryAsync("4.44");
            Assert.AreEqual("https://foo.bar.com/entries/4.44?api-version=2025-01-31-preview", mockTransport.Requests[0].Uri.ToString());
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(new byte[] { 0x01, 0x02, 0x03 }, response.Value.ToArray());
        }

        [Test]
        public async Task GetTransparencyConfigCborAsync_ShouldReturnResponse()
        {
            var responseMock = new MockResponse(200);
            responseMock.SetContent(BinaryData.FromString("test-content").ToArray());
            var mockTransport = new MockTransport(responseMock);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://foo.bar.com"
            };
            var client = new CodeTransparencyClient(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);

            var result = await client.GetTransparencyConfigCborAsync();

            Assert.NotNull(result);
            Assert.AreEqual("test-content", result.Value.ToString());
            Assert.AreEqual("https://foo.bar.com/.well-known/transparency-configuration?api-version=2025-01-31-preview", mockTransport.Requests[0].Uri.ToString());
        }

        [Test]
        public void GetPublicKeys_Success_After_retry()
        {
            var content = new MockResponse(200);
            content.SetContent("{\"keys\":" +
                "[{\"crv\": \"P-384\"," +
                "\"kid\":\"1dd54f9b6272971320c95850f74a9459c283b375531173c3d5d9bfd5822163cb\"," +
                "\"kty\":\"EC\"," +
                "\"x\": \"WAHDpC-ECgc7LvCxlaOPsY-xVYF9iStcEPU3XGF8dlhtb6dMHZSYVPMs2gliK-gc\"," +
                "\"y\": \"xJ7fI2kA8gs11XDc9h2zodU-fZYRrE0UJHpzPfDVJrOpTvPcDoC5EWOBx9Fks0bZ\"" +
                "}]}");

            var mockTransport = new MockTransport(new MockResponse(503), content);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://foo.bar.com"
            };
            var client = new CodeTransparencyClient(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);

            Response<JwksDocument> result = client.GetPublicKeys();

            Assert.NotNull(result);
            Assert.AreEqual(2, mockTransport.Requests.Count);
            Assert.AreEqual("https://foo.bar.com/jwks?api-version=2025-01-31-preview", mockTransport.Requests[1].Uri.ToString());
        }

        [Test]
        public void RunTransparentStatementVerification_InvalidParameters_ShouldThrowCryptographicException()
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

            byte[] transparentStatementCoseSign1Bytes = new byte[] { 0x01, 0x02, 0x03 /* invalid bytes */ };

            Assert.Throws<CryptographicException>(() => client.RunTransparentStatementVerification(transparentStatementCoseSign1Bytes));
#endif
        }

        [Test]
        public void RunTransparentStatementVerification_success()
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

            byte[] transparentStatementBytes = readFileBytes(name: "transparent_statement.cose");

            client.RunTransparentStatementVerification(transparentStatementBytes);
#endif
        }

        [Test]
        public void RunTransparentStatementVerification_FileBasedConstructor_success()
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
            byte[] transparentStatementBytes = readFileBytes(name: "transparent_statement.cose");
            var client = new CodeTransparencyClient(transparentStatementBytes, options);
            client.RunTransparentStatementVerification(transparentStatementBytes);
#endif
        }

        [Test]
        public void RunTransparentStatementVerification_InvalidCurve_InvalidOperationException()
        {
#if NET462
            Assert.Ignore("JsonWebKey to ECDsa is not supported on net462.");
#else
            var content = new MockResponse(200);
            content.SetContent("{\"keys\":" +
                "[{\"crv\": \"P-512\"," +
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

            byte[] transparentStatementBytes = readFileBytes("transparent_statement.cose");

            var exception = Assert.Throws<AggregateException>(() => client.RunTransparentStatementVerification(transparentStatementBytes));
            Assert.AreEqual("The ECDsa key uses the wrong algorithm. Expected -39 Found -35", exception.InnerExceptions[0].Message);
#endif
        }

        [Test]
        public void RunTransparentStatementVerification_Invalidkid_InvalidOperationException()
        {
#if NET462
            Assert.Ignore("JsonWebKey to ECDsa is not supported on net462.");
#else
            var content = new MockResponse(200);
            content.SetContent("{\"keys\":" +
                "[{\"crv\": \"P-384\"," +
                "\"kid\":\"99954f9b6272971320c95850f74a9459c283b375531173c3d5d9bfd5822163cb\"," +
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

            byte[] transparentStatementBytes = readFileBytes("transparent_statement.cose");

            Assert.Throws<AggregateException>(() => client.RunTransparentStatementVerification(transparentStatementBytes));
#endif
        }
    }
}
