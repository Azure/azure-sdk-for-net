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
    public class LowLevelClientTests : ClientTestBase
    {
        public LowLevelClientTests(bool isAsync) : base(isAsync)
        {
        }

        private PetStoreClient client { get; set; }
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

            Response response = await client.GetPetAsync("snoopy", new RequestOptions());
            var doc = JsonDocument.Parse(response.Content.ToMemory());

            Assert.AreEqual(200, response.Status);
            Assert.AreEqual("snoopy", doc.RootElement.GetProperty("name").GetString());
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
        public void CannotGetOutputModelOnFailureCodeAsync()
        {
            var mockResponse = new MockResponse(404);

            var mockTransport = new MockTransport(mockResponse);
            PetStoreClient client = CreateClient(mockTransport);

            Assert.ThrowsAsync<RequestFailedException>(async () => await client.GetPetAsync("pet1"));
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
