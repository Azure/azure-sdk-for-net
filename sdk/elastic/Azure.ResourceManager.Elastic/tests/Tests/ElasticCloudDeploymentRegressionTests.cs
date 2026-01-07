// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Text.Json;
using Azure.ResourceManager.Elastic.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.Elastic.Tests
{
    /// <summary>
    /// Regression tests for ElasticCloudDeployment custom serialization fixes for issue #50974
    /// </summary>
    public class ElasticCloudDeploymentRegressionTests
    {
        [Test]
        public void SerializeAndDeserialize_AllUriProperties_WithAbsoluteUris()
        {
            // Arrange
            var elasticsearchServiceUri = new Uri("https://elasticsearch.example.com:9200");
            var kibanaServiceUri = new Uri("https://kibana.example.com:5601");
            var kibanaSsoUri = new Uri("https://kibana.example.com:5601/sso");

            var deployment = new ElasticCloudDeployment(
                name: "test-deployment",
                deploymentId: "dep-123",
                azureSubscriptionId: "sub-456",
                elasticsearchRegion: "eastus",
                elasticsearchServiceUri: elasticsearchServiceUri,
                kibanaServiceUri: kibanaServiceUri,
                kibanaSsoUri: kibanaSsoUri,
                serializedAdditionalRawData: new Dictionary<string, BinaryData>()
            );

            // Act - Serialize
            var model = deployment as IPersistableModel<ElasticCloudDeployment>;
            var wire = ModelReaderWriter.Write(model);
            var jsonString = wire.ToString();

            // Verify serialized JSON contains absolute URIs
            var jsonDoc = JsonDocument.Parse(jsonString);
            var root = jsonDoc.RootElement;

            if (root.TryGetProperty("elasticsearchServiceUrl", out var esElement))
            {
                Assert.That(esElement.GetString(), Is.EqualTo("https://elasticsearch.example.com:9200/"));
            }
            if (root.TryGetProperty("kibanaServiceUrl", out var kibanaElement))
            {
                Assert.That(kibanaElement.GetString(), Is.EqualTo("https://kibana.example.com:5601/"));
            }
            if (root.TryGetProperty("kibanaSsoUrl", out var kibanaSsoElement))
            {
                Assert.That(kibanaSsoElement.GetString(), Is.EqualTo("https://kibana.example.com:5601/sso"));
            }

            // Act - Deserialize
            var deserialized = ModelReaderWriter.Read<ElasticCloudDeployment>(wire);

            // Assert
            Assert.That(deserialized, Is.Not.Null);
            Assert.That(deserialized.ElasticsearchServiceUri, Is.EqualTo(elasticsearchServiceUri));
            Assert.That(deserialized.KibanaServiceUri, Is.EqualTo(kibanaServiceUri));
            Assert.That(deserialized.KibanaSsoUri, Is.EqualTo(kibanaSsoUri));

            // Verify all URIs are absolute
            Assert.That(deserialized.ElasticsearchServiceUri.IsAbsoluteUri, Is.True);
            Assert.That(deserialized.KibanaServiceUri.IsAbsoluteUri, Is.True);
            Assert.That(deserialized.KibanaSsoUri.IsAbsoluteUri, Is.True);
        }

        [Test]
        public void SerializeAndDeserialize_AllUriProperties_WithRelativeUris()
        {
            // Arrange - Use relative paths that don't start with "/" to avoid platform-specific interpretation
            var elasticsearchServiceUri = new Uri("elasticsearch", UriKind.Relative);
            var kibanaServiceUri = new Uri("kibana", UriKind.Relative);
            var kibanaSsoUri = new Uri("kibana/sso", UriKind.Relative);

            var deployment = new ElasticCloudDeployment(
                name: "test-deployment",
                deploymentId: "dep-123",
                azureSubscriptionId: "sub-456",
                elasticsearchRegion: "eastus",
                elasticsearchServiceUri: elasticsearchServiceUri,
                kibanaServiceUri: kibanaServiceUri,
                kibanaSsoUri: kibanaSsoUri,
                serializedAdditionalRawData: new Dictionary<string, BinaryData>()
            );

            // Act - Serialize
            var model = deployment as IPersistableModel<ElasticCloudDeployment>;
            var wire = ModelReaderWriter.Write(model);
            var jsonString = wire.ToString();

            // Verify serialized JSON contains relative URIs as original strings
            var jsonDoc = JsonDocument.Parse(jsonString);
            var root = jsonDoc.RootElement;

            if (root.TryGetProperty("elasticsearchServiceUrl", out var esElement))
            {
                Assert.That(esElement.GetString(), Is.EqualTo("elasticsearch"));
            }
            if (root.TryGetProperty("kibanaServiceUrl", out var kibanaElement))
            {
                Assert.That(kibanaElement.GetString(), Is.EqualTo("kibana"));
            }
            if (root.TryGetProperty("kibanaSsoUrl", out var kibanaSsoElement))
            {
                Assert.That(kibanaSsoElement.GetString(), Is.EqualTo("kibana/sso"));
            }

            // Act - Deserialize
            var deserialized = ModelReaderWriter.Read<ElasticCloudDeployment>(wire);

            // Assert
            Assert.That(deserialized, Is.Not.Null);
            Assert.That(deserialized.ElasticsearchServiceUri, Is.EqualTo(elasticsearchServiceUri));
            Assert.That(deserialized.KibanaServiceUri, Is.EqualTo(kibanaServiceUri));
            Assert.That(deserialized.KibanaSsoUri, Is.EqualTo(kibanaSsoUri));

            // Verify all URIs are relative
            Assert.That(deserialized.ElasticsearchServiceUri.IsAbsoluteUri, Is.False);
            Assert.That(deserialized.KibanaServiceUri.IsAbsoluteUri, Is.False);
            Assert.That(deserialized.KibanaSsoUri.IsAbsoluteUri, Is.False);

            // Verify original strings are preserved
            Assert.That(deserialized.ElasticsearchServiceUri.OriginalString, Is.EqualTo("elasticsearch"));
            Assert.That(deserialized.KibanaServiceUri.OriginalString, Is.EqualTo("kibana"));
            Assert.That(deserialized.KibanaSsoUri.OriginalString, Is.EqualTo("kibana/sso"));
        }
    }
}
