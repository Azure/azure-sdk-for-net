// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.Core.Experimental.Tests;
using Azure.Core.Experimental.Tests.Models;
using Azure.Core.Pipeline;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Core.Tests
{
    public class DataPlaneGeneratedClientTests : ClientTestBase
    {
        public DataPlaneGeneratedClientTests(bool isAsync) : base(isAsync)
        {
        }

        private readonly Uri _url = new Uri("https://example.azurepetstore.com");

        public PetStoreClient CreateClient(HttpPipelineTransport transport)
        {
            var options = new PetStoreClientOptions()
            {
                Transport = transport
            };

            return new PetStoreClient(_url, new MockCredential(), options);
        }

        [Test]
        public async Task CanGetResponseFromLlcGetMethodAsync()
        {
            var mockResponse = new MockResponse(200);

            Pet pet = new Pet("snoopy", "beagle");
            mockResponse.SetContent(SerializationHelpers.Serialize(pet, SerializePet));

            var mockTransport = new MockTransport(mockResponse);
            PetStoreClient client = CreateClient(mockTransport);

            Response response = await client.GetPetAsync("snoopy", new RequestContext());

            var doc = JsonDocument.Parse(response.Content.ToMemory());
            var name = doc.RootElement.GetProperty("name").GetString();

            Assert.AreEqual(200, response.Status);
            Assert.AreEqual("snoopy", name);
            Assert.AreEqual("beagle", doc.RootElement.GetProperty("species").GetString());
        }

        [Test]
        public async Task CanGetOutputModelOnSuccessCodeAsync()
        {
            var mockResponse = new MockResponse(200);

            Pet petResponse = new Pet("snoopy", "beagle");
            mockResponse.SetContent(SerializationHelpers.Serialize(petResponse, SerializePet));

            var mockTransport = new MockTransport(mockResponse);
            PetStoreClient client = CreateClient(mockTransport);

            Pet pet = await client.GetPetAsync("pet1");

            Assert.AreEqual("snoopy", pet.Name);
            Assert.AreEqual("beagle", pet.Species);
        }

        [Test]
        public async Task ModelCastThrowsOnErrorCodeAsync()
        {
            var mockResponse = new MockResponse(404);

            // Send the response through the pipeline so IsError is set.
            var mockTransport = new MockTransport(mockResponse);
            PetStoreClient client = CreateClient(mockTransport);

            Response response = await client.GetPetAsync("pet1", ErrorOptions.NoThrow);

            Assert.Throws<RequestFailedException>(() => { Pet pet = response; });
        }

        [Test]
        public void CannotGetOutputModelOnFailureCodeAsync()
        {
            var mockResponse = new MockResponse(404);

            var mockTransport = new MockTransport(mockResponse);
            PetStoreClient client = CreateClient(mockTransport);

            Assert.ThrowsAsync<RequestFailedException>(async () => await client.GetPetAsync("pet1"));
        }

        // Note: these two tests *currently* test different code paths:
        // 1) In the ResponseStatusOptions.Default case, we're going through code paths in
        //    ClientDiagnostics that we'll later migrate to ResponseClassifier (see https://github.com/azure/azure-sdk-for-net/issues/24031)
        //
        //    Because this one is thrown from client's `GetPetAsync()` method, where it calls
        //    _clientDiagnostics.CreateRFException() -- this happens via different constructors (Note: does it have to?  Could we refactor this?)
        //
        // 2) In the ResponseStatusOptions.NoThrow case, we're going through code paths in
        //    ResponseClassifier, which will become the only path after resolution of #24031
        //
        // Importantly, having these two tests validates our premise:
        //   ** The Grow-Up Story/(Gen 1) Convenience Client Helper approach has the same semantics

        [Test]
        public async Task GetRequestFailedException_StatusOptionDefault()
        {
            var mockResponse = new MockResponse(404);
            mockResponse.SetContent("{\"error\": { \"code\": \"MockStatusCode\" }}");
            mockResponse.AddHeader(HttpHeader.Names.ContentType, "application/json");

            var mockTransport = new MockTransport(mockResponse);
            PetStoreClient client = CreateClient(mockTransport);

            try
            {
                Pet pet = await client.GetPetAsync("pet1");
            }
            catch (RequestFailedException e)
            {
                Assert.AreEqual(404, e.Status);
                Assert.That(() => e.Message.StartsWith("Service request failed."));
                Assert.That(() => e.ErrorCode.StartsWith("MockStatusCode"));
            }
        }

        [Test]
        public async Task GetRequestFailedException_StatusOptionNoThrow()
        {
            var mockResponse = new MockResponse(404);
            mockResponse.SetContent("{\"error\": { \"code\": \"MockStatusCode\" }}");
            mockResponse.AddHeader(HttpHeader.Names.ContentType, "application/json");

            var mockTransport = new MockTransport(mockResponse);
            PetStoreClient client = CreateClient(mockTransport);

            try
            {
                // NOTE: is it weird that we're saying NoThrow here and it throws?
                // This looks confusing to me as someone reading this code.
                Pet pet = await client.GetPetAsync("pet1", ErrorOptions.NoThrow);
            }
            catch (RequestFailedException e)
            {
                Assert.AreEqual(404, e.Status);
                Assert.That(() => e.Message.StartsWith("Service request failed."));
                Assert.That(() => e.ErrorCode.StartsWith("MockStatusCode"));
            }
        }

        [Test]
        public void CanSuppressExceptions()
        {
            var mockResponse = new MockResponse(404);

            var mockTransport = new MockTransport(mockResponse);
            PetStoreClient client = CreateClient(mockTransport);

            RequestContext context = new RequestContext()
            {
                ErrorOptions = ErrorOptions.NoThrow
            };

            Response response = default;
            Assert.DoesNotThrowAsync(async () =>
            {
                response = await client.GetPetAsync("snoopy", context);
            });

            Assert.AreEqual(404, response.Status);
        }

        [Test]
        public async Task ThrowOnErrorDoesntThrowOnSuccess()
        {
            var mockResponse = new MockResponse(200);

            Pet pet = new Pet("snoopy", "beagle");
            mockResponse.SetContent(SerializationHelpers.Serialize(pet, SerializePet));

            var mockTransport = new MockTransport(mockResponse);
            PetStoreClient client = CreateClient(mockTransport);

            Response response = await client.GetPetAsync("snoopy",
                new RequestContext()
                {
                    ErrorOptions = ErrorOptions.Default
                });
            var doc = JsonDocument.Parse(response.Content.ToMemory());

            Assert.AreEqual(200, response.Status);
            Assert.AreEqual("snoopy", doc.RootElement.GetProperty("name").GetString());
            Assert.AreEqual("beagle", doc.RootElement.GetProperty("species").GetString());
        }

        [Test]
        public void ThrowOnErrorThrowsOnError()
        {
            var mockResponse = new MockResponse(404);

            var mockTransport = new MockTransport(mockResponse);
            PetStoreClient client = CreateClient(mockTransport);

            Assert.ThrowsAsync<RequestFailedException>(async () =>
            {
                await client.GetPetAsync("snoopy", new RequestContext()
                {
                    ErrorOptions = ErrorOptions.Default
                });
            });
        }

        [Test]
        public async Task Change404Category()
        {
            var mockResponse = new MockResponse(404);

            // Send the response through the pipeline so IsError is set.
            var mockTransport = new MockTransport(mockResponse);
            PetStoreClient client = CreateClient(mockTransport);

            #region Snippet:SetRequestContext
            var context = new RequestContext();
            context.AddClassifier(404, isError: false);

            Response response = await client.GetPetAsync("pet1", context);
            #endregion

            Assert.AreEqual(404, response.Status);
        }

        #region Helpers
        private void SerializePet(ref Utf8JsonWriter writer, Pet pet)
        {
            writer.WriteStartObject();

            writer.WritePropertyName("name");
            writer.WriteStringValue(pet.Name);

            writer.WritePropertyName("species");
            writer.WriteStringValue(pet.Species);

            writer.WriteEndObject();
        }
        #endregion
    }
}
