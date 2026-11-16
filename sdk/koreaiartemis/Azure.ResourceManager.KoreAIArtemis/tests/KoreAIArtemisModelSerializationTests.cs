// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Text.Json;
using Azure.Core;
using Azure.ResourceManager.KoreAIArtemis.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.KoreAIArtemis.Tests
{
    public class KoreAIArtemisModelSerializationTests
    {
        [Test]
        public void SingleSignOnUriRoundTrips()
        {
            const string url = "https://sso.example.com/login?tenant=example";
            var model = ModelReaderWriter.Read<KoreAIArtemisSingleSignOnProperties>(
                BinaryData.FromString($"{{\"type\":\"Saml\",\"url\":\"{url}\"}}"));

            Uri uri = model.Uri;
            Assert.That(uri.AbsoluteUri, Is.EqualTo(url));
            using var document = JsonDocument.Parse(ModelReaderWriter.Write(model, new ModelReaderWriterOptions("W")));
            Assert.That(document.RootElement.GetProperty("url").GetString(), Is.EqualTo(url));
        }

        [Test]
        public void SaasResourceIdRoundTrips()
        {
            var resourceId = new ResourceIdentifier("/subscriptions/00000000-0000-0000-0000-000000000001/resourceGroups/test/providers/Microsoft.SaaS/resources/kore");
            var model = new KoreAIArtemisMarketplaceDetails(new KoreAIArtemisOfferDetails("publisher", "offer"))
            {
                SaasResourceId = resourceId
            };

            BinaryData data = ModelReaderWriter.Write(model, new ModelReaderWriterOptions("W"));
            using var document = JsonDocument.Parse(data);
            Assert.That(document.RootElement.GetProperty("saasResourceId").GetString(), Is.EqualTo(resourceId.ToString()));
            ResourceIdentifier actual = ModelReaderWriter.Read<KoreAIArtemisMarketplaceDetails>(data).SaasResourceId;
            Assert.That(actual, Is.EqualTo(resourceId));
        }

        [Test]
        public void OptionalUriAndResourceIdCanBeNull()
        {
            var singleSignOn = ModelReaderWriter.Read<KoreAIArtemisSingleSignOnProperties>(
                BinaryData.FromString("{\"type\":\"Saml\",\"url\":null}"));
            var marketplace = ModelReaderWriter.Read<KoreAIArtemisMarketplaceDetails>(
                BinaryData.FromString("{\"offerDetails\":{\"publisherId\":\"publisher\",\"offerId\":\"offer\"},\"saasResourceId\":null}"));

            Assert.That(singleSignOn.Uri, Is.Null);
            Assert.That(marketplace.SaasResourceId, Is.Null);
        }
    }
}
