// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
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
        public async Task CreateEntryAsync_sendsBytes_receives_bytes()
        {
            var mockedResponse = new MockResponse(201);
            mockedResponse.AddHeader("Content-Type", "application/cose");
            mockedResponse.SetContent(BinaryData.FromString("{\"operationId\": \"foobar\"}").ToArray());
            var mockTransport = new MockTransport(mockedResponse);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://foo.bar.com"
            };

            CodeTransparencyClient client = new(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);
            BinaryData content = BinaryData.FromString("Hello World!");
            Response<BinaryData> response = await client.CreateEntryAsync(content);

            Assert.AreEqual("https://foo.bar.com/entries?api-version=2025-01-31-preview", mockTransport.Requests[0].Uri.ToString());
            Assert.AreEqual("{\"operationId\": \"foobar\"}", response.Value.ToString());
        }

        [Test]
        public async Task CreateEntryAsync_request_accepted()
        {
            var mockedResponse = new MockResponse(202);
            mockedResponse.SetContent("{\"operationId\": \"foobar\"}");
            var mockTransport = new MockTransport(mockedResponse);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://foo.bar.com"
            };

            CodeTransparencyClient client = new(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);
            BinaryData content = BinaryData.FromString("Hello World!");
            Response<BinaryData> response = await client.CreateEntryAsync(content);

            Assert.AreEqual("https://foo.bar.com/entries?api-version=2025-01-31-preview", mockTransport.Requests[0].Uri.ToString());
            Assert.AreEqual(1, mockTransport.Requests.Count);
            Assert.AreEqual("{\"operationId\": \"foobar\"}", response.Value.ToString());
        }

        [Test]
        public async Task CreateEntryAsync_unsuccessful_post()
        {
            var mockedResponse = new MockResponse(200);
            mockedResponse.SetContent(BinaryData.FromString("{\"operationId\": \"foobar\"}").ToArray());
            var mockTransport = new MockTransport(new MockResponse(503), mockedResponse);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://foo.bar.com"
            };
            var client = new CodeTransparencyClient(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);
            BinaryData content = BinaryData.FromString("Hello World!");
            Response<BinaryData> response = await client.CreateEntryAsync(content);

            Assert.AreEqual("https://foo.bar.com/entries?api-version=2025-01-31-preview", mockTransport.Requests[0].Uri.ToString());
            Assert.AreEqual(503, response.GetRawResponse().Status);
        }

        [Test]
        public async Task GetEntryAsync_unsuccessful_get()
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

            Assert.AreEqual("https://foo.bar.com/entries/4.44?api-version=2025-01-31-preview", mockTransport.Requests[0].Uri.ToString());
            Assert.AreEqual(503, response.GetRawResponse().Status);
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
        public async Task CreateEntryAsync_ShouldReturnResponse()
        {
            var responseMock = new MockResponse(201);
            responseMock.SetContent(BinaryData.FromString("test-content").ToArray());
            var mockTransport = new MockTransport(responseMock);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://foo.bar.com"
            };
            var client = new CodeTransparencyClient(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);

            var result = await client.CreateEntryAsync(BinaryData.FromString("test-body"));

            Assert.NotNull(result);
            Assert.AreEqual("test-content", result.Value.ToString());
            Assert.AreEqual("https://foo.bar.com/entries?api-version=2025-01-31-preview", mockTransport.Requests[0].Uri.ToString());
        }

        [Test]
        public void CreateEntry_ShouldReturnResponse()
        {
            var responseMock = new MockResponse(201);
            responseMock.SetContent(BinaryData.FromString("test-content").ToArray());
            var mockTransport = new MockTransport(responseMock);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://foo.bar.com"
            };
            var client = new CodeTransparencyClient(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);

            var result = client.CreateEntry(BinaryData.FromString("test-body"));

            Assert.NotNull(result);
            Assert.AreEqual("test-content", result.Value.ToString());
            Assert.AreEqual("https://foo.bar.com/entries?api-version=2025-01-31-preview", mockTransport.Requests[0].Uri.ToString());
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
                "\"y\": \"EaDFUcuR-aQrWctpV4Kp_x16w3ZcG8957U3sLTRdeihO0vjfHBtW11xaIfAU0qAX\"" +
                "}]}");

            var mockTransport = new MockTransport(content);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://foo.bar.com"
            };
            var client = new CodeTransparencyClient(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);

            byte[] transparentStatementCoseSign1Bytes = new byte[] { 0x01, 0x02, 0x03 /* invalid bytes */ };
            byte[] signedStatement = readFileBytes("input_signed_claims");

            Assert.Throws<CryptographicException>(() => client.RunTransparentStatementVerification(transparentStatementCoseSign1Bytes, signedStatement));
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
                "\"kid\":\"1dd54f9b6272971320c95850f74a9459c283b375531173c3d5d9bfd5822163cb\"," +
                "\"kty\":\"EC\"," +
                "\"x\": \"WAHDpC-ECgc7LvCxlaOPsY-xVYF9iStcEPU3XGF8dlhtb6dMHZSYVPMs2gliK-gc\"," +
                "\"y\": \"EaDFUcuR-aQrWctpV4Kp_x16w3ZcG8957U3sLTRdeihO0vjfHBtW11xaIfAU0qAX\"" +
                "}]}");

            var mockTransport = new MockTransport(content);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://foo.bar.com"
            };
            var client = new CodeTransparencyClient(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);

            byte[] inputSignedStatement = readFileBytes("input_signed_claims");
            byte[] transparentStatementBytes = readFileBytes("transparent_statement.cose");

            client.RunTransparentStatementVerification(transparentStatementBytes, inputSignedStatement);
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
                "\"kid\":\"1dd54f9b6272971320c95850f74a9459c283b375531173c3d5d9bfd5822163cb\"," +
                "\"kty\":\"EC\"," +
                "\"x\": \"WAHDpC-ECgc7LvCxlaOPsY-xVYF9iStcEPU3XGF8dlhtb6dMHZSYVPMs2gliK-gc\"," +
                "\"y\": \"EaDFUcuR-aQrWctpV4Kp_x16w3ZcG8957U3sLTRdeihO0vjfHBtW11xaIfAU0qAX\"" +
                "}]}");

            var mockTransport = new MockTransport(content);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://foo.bar.com"
            };
            var client = new CodeTransparencyClient(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);

            byte[] inputSignedStatement = readFileBytes("input_signed_claims");
            byte[] transparentStatementBytes = readFileBytes("transparent_statement.cose");

            var exception = Assert.Throws<AggregateException>(() => client.RunTransparentStatementVerification(transparentStatementBytes, inputSignedStatement));
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
                "\"x\": \"WAHDpC-ECgc7LvCxlaOPsY-xVYF9iStcEPU3XGF8dlhtb6dMHZSYVPMs2gliK-gc\"," +
                "\"y\": \"EaDFUcuR-aQrWctpV4Kp_x16w3ZcG8957U3sLTRdeihO0vjfHBtW11xaIfAU0qAX\"" +
                "}]}");

            var mockTransport = new MockTransport(content);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://foo.bar.com"
            };
            var client = new CodeTransparencyClient(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);

            byte[] inputSignedStatement = readFileBytes("input_signed_claims");
            byte[] transparentStatementBytes = readFileBytes("transparent_statement.cose");

            Assert.Throws<AggregateException>(() => client.RunTransparentStatementVerification(transparentStatementBytes, inputSignedStatement));
#endif
        }
    }
}
