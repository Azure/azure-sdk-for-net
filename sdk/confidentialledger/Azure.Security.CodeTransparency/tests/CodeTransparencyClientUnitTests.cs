// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Security.CodeTransparency.Tests
{
    public class CodeTransparencyClientUnitTests: ClientTestBase
    {
        /// <summary>
        /// A canned service identity response. But with a parseable cert.
        /// </summary>
        private readonly string _serviceIdentityJson = """
        {
            "ledgerTlsCertificate": "-----BEGIN CERTIFICATE-----\nMIIBvjCCAUSgAwIBAgIRALIcCHAQ8TpbFgvuNThTIFkwCgYIKoZIzj0EAwMwFjEU\nMBIGA1UEAwwLQ0NGIE5ldHdvcmswHhcNMjQwMTAzMDg1NDM2WhcNMjQwNDAyMDg1\nNDM1WjAWMRQwEgYDVQQDDAtDQ0YgTmV0d29yazB2MBAGByqGSM49AgEGBSuBBAAi\nA2IABFK177XlxO+GvJ91xjC98icJRKJbUIOSffHYEWAKojxvEa7EV1eVUINye0tU\nZJVVI5Nw2Y7Gbi7cm89Njnvz/uYUHBp/di3Rk+R4kupHEH6XErTMN93CAR4lIBOY\ndF7JpqNWMFQwEgYDVR0TAQH/BAgwBgEB/wIBADAdBgNVHQ4EFgQU4px9yVX1Ru3W\nefhlw88K2zmyFQEwHwYDVR0jBBgwFoAU4px9yVX1Ru3Wefhlw88K2zmyFQEwCgYI\nKoZIzj0EAwMDaAAwZQIwG20Zjw5WPVoW6jsIchwSnfhniJNr0xF8hJJKUXIfyEDo\nnPewSdWnE4RubOm/ctMYAjEAlvwpdzSDFg57beLfq0bhaznxGOBpYQXl+q1uzm/S\nPup20CFNsp8G8m7w076DGJEA\n-----END CERTIFICATE-----\n",
            "ledgerId": "cts-canary"
        }
        """;

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
        public async Task CreateEntryAsync_sendsBytes_receives_json()
        {
            var mockedResponse = new MockResponse(200);
            mockedResponse.SetContent("{\"operationId\": \"foobar\"}");
            var mockTransport = new MockTransport(mockedResponse);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://foo.bar.com"
            };

            CodeTransparencyClient client = new(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);
            BinaryData content = BinaryData.FromString("Hello World!");
            Operation<GetOperationResult> response = await client.CreateEntryAsync(content);

            Assert.AreEqual("https://foo.bar.com/entries?api-version=2024-01-11-preview", mockTransport.Requests[0].Uri.ToString());
            Assert.AreEqual(false, response.HasCompleted);
            Assert.AreEqual("foobar", response.Id);
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
            Operation<GetOperationResult> response = await client.CreateEntryAsync(content);

            Assert.AreEqual("https://foo.bar.com/entries?api-version=2024-01-11-preview", mockTransport.Requests[0].Uri.ToString());
            Assert.AreEqual(false, response.HasCompleted);
            Assert.AreEqual("foobar", response.Id);
        }

        [Test]
        public async Task CreateEntryAsync_retries_unsuccessful_post()
        {
            var mockedResponse = new MockResponse(200);
            mockedResponse.SetContent("{\"operationId\": \"foobar\"}");
            var mockTransport = new MockTransport(new MockResponse(503), mockedResponse);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://foo.bar.com"
            };
            var client = new CodeTransparencyClient(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);
            BinaryData content = BinaryData.FromString("Hello World!");
            Operation<GetOperationResult> response = await client.CreateEntryAsync(content);
            Assert.AreEqual("https://foo.bar.com/entries?api-version=2024-01-11-preview", mockTransport.Requests[0].Uri.ToString());
            Assert.AreEqual("foobar", response.Id);
        }

        [Test]
        public async Task CreateEntryAsync_waits_for_operation_success()
        {
            var createResponse = new MockResponse(200);
            createResponse.SetContent("{\"operationId\": \"foobar\"}");
            var pendingResponse = new MockResponse(200);
            pendingResponse.SetContent("{\"operationId\": \"foobar\", \"status\": \"running\"}");
            var operationResponse = new MockResponse(200);
            operationResponse.SetContent("{\"operationId\": \"foobar\", \"entryId\": \"123.23\", \"status\": \"succeeded\"}");

            var mockTransport = new MockTransport(createResponse, pendingResponse, operationResponse);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://foo.bar.com"
            };
            var client = new CodeTransparencyClient(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);
            BinaryData content = BinaryData.FromString("Hello World!");
            Operation<GetOperationResult> operation = await client.CreateEntryAsync(content);
            Assert.AreEqual("https://foo.bar.com/entries?api-version=2024-01-11-preview", mockTransport.Requests[0].Uri.ToString());
            Assert.AreEqual("foobar", operation.Id);
            Response<GetOperationResult> response = await operation.WaitForCompletionAsync();
            GetOperationResult value = response.Value;
            Assert.AreEqual("123.23", value.EntryId);
            Assert.AreEqual(OperationStatus.Succeeded, value.Status);
            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);
        }

         [Test]
        public async Task CreateEntryAsync_stops_on_operation_failure()
        {
            var createResponse = new MockResponse(200);
            createResponse.SetContent("{\"operationId\": \"foobar\"}");
            var pendingResponse = new MockResponse(200);
            pendingResponse.SetContent("{\"operationId\": \"foobar\", \"status\": \"running\"}");
            var operationResponse = new MockResponse(200);
            operationResponse.SetContent("{\"operationId\": \"foobar\", \"status\": \"failed\"}");

            var mockTransport = new MockTransport(createResponse, pendingResponse, operationResponse);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://foo.bar.com"
            };
            var client = new CodeTransparencyClient(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);
            BinaryData content = BinaryData.FromString("Hello World!");
            Operation<GetOperationResult> operation = await client.CreateEntryAsync(content);
            Assert.AreEqual("https://foo.bar.com/entries?api-version=2024-01-11-preview", mockTransport.Requests[0].Uri.ToString());
            Assert.AreEqual("foobar", operation.Id);

            Assert.ThrowsAsync<RequestFailedException>(async () => await operation.WaitForCompletionAsync());
            Assert.IsTrue(operation.HasCompleted);
            Assert.IsTrue(operation.HasValue);
        }

        [Test]
        public async Task GetEntryStatusAsync_gets_entryId()
        {
            var mockedResponse = new MockResponse(200);
            mockedResponse.SetContent("{\"status\": \"succeeded\", \"entryId\": \"2.35\"}");
            var mockTransport = new MockTransport(mockedResponse);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://foo.bar.com"
            };
            var client = new CodeTransparencyClient(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);
            Response<GetOperationResult> response = await client.GetEntryStatusAsync("operationId");
            Assert.AreEqual("https://foo.bar.com/operations/operationId?api-version=2024-01-11-preview", mockTransport.Requests[0].Uri.ToString());
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(OperationStatus.Succeeded, response.Value.Status);
            Assert.AreEqual("2.35", response.Value.EntryId);
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
            Assert.AreEqual("https://foo.bar.com/entries/4.44?api-version=2024-01-11-preview", mockTransport.Requests[1].Uri.ToString());
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(new byte[] { 0x01, 0x02, 0x03 }, response.Value.ToArray());
        }

        [Test]
        public async Task GetEntryAsync_gets_entry_bytes_with_embedded_receipt()
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
            Response<BinaryData> response = await client.GetEntryAsync("4.44", true);
            Assert.AreEqual("https://foo.bar.com/entries/4.44?api-version=2024-01-11-preview&embedReceipt=true", mockTransport.Requests[0].Uri.ToString());
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(new byte[] { 0x01, 0x02, 0x03 }, response.Value.ToArray());
        }

        [Test]
        public async Task GetEntryReceiptAsync_gets_receipt_bytes_after_retry()
        {
            var mockedResponse = new MockResponse(200);
            mockedResponse.AddHeader("Content-Type", "application/cbor");
            mockedResponse.SetContent(new byte[] { 0x01, 0x02, 0x03 });
            var mockTransport = new MockTransport(new MockResponse(503), mockedResponse);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://foo.bar.com"
            };
            var client = new CodeTransparencyClient(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);
            Response<BinaryData> response = await client.GetEntryReceiptAsync("4.44");

            Assert.AreEqual("https://foo.bar.com/entries/4.44/receipt?api-version=2024-01-11-preview", mockTransport.Requests[1].Uri.ToString());
            Assert.AreEqual(200, response.GetRawResponse().Status);
            Assert.AreEqual(new byte[] { 0x01, 0x02, 0x03 }, response.Value.ToArray());
        }

        [Test]
        public async Task GetEntryIdsAsync_gets_entry_ids()
        {
            var page1 = new MockResponse(200);
            page1.SetContent("{\"transactionIds\": [ \"2.1\",\"2.2\",\"2.3\" ], \"nextLink\":\"/entries/txIds?from=3&to=6\"}");
            var page2 = new MockResponse(200);
            page2.SetContent("{\"transactionIds\": [ \"3.4\",\"3.5\",\"3.6\" ], \"nextLink\":\"/entries/txIds?from=7\"}");
            var page3 = new MockResponse(200);
            page3.SetContent("{\"transactionIds\": [ \"4.7\" ]}");
            var mockTransport = new MockTransport(page1, page2, page3);
            var options = new CodeTransparencyClientOptions
            {
                Transport = mockTransport,
                IdentityClientEndpoint = "https://foo.bar.com"
            };
            var client = new CodeTransparencyClient(new Uri("https://foo.bar.com"), new AzureKeyCredential("token"), options);
            AsyncPageable<string> response = client.GetEntryIdsAsync();
            List<string> ids = new();
            await foreach (Page<string> page in response.AsPages())
            {
                ids.AddRange(page.Values);
            }
            Assert.AreEqual("https://foo.bar.com/entries/txIds?api-version=2024-01-11-preview", mockTransport.Requests[0].Uri.ToString());
            Assert.AreEqual("https://foo.bar.com/entries/txIds?from=3&to=6", mockTransport.Requests[1].Uri.ToString());
            Assert.AreEqual("https://foo.bar.com/entries/txIds?from=7", mockTransport.Requests[2].Uri.ToString());

            Assert.That(ids, Is.EquivalentTo(new string[] { "2.1", "2.2", "2.3", "3.4", "3.5", "3.6", "4.7" }));
        }
    }
}