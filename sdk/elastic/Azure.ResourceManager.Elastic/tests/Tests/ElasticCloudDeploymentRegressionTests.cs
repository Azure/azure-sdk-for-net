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
                Assert.AreEqual("https://elasticsearch.example.com:9200/", esElement.GetString());
            }
            if (root.TryGetProperty("kibanaServiceUrl", out var kibanaElement))
            {
                Assert.AreEqual("https://kibana.example.com:5601/", kibanaElement.GetString());
            }
            if (root.TryGetProperty("kibanaSsoUrl", out var kibanaSsoElement))
            {
                Assert.AreEqual("https://kibana.example.com:5601/sso", kibanaSsoElement.GetString());
            }

            // Act - Deserialize
            var deserialized = ModelReaderWriter.Read<ElasticCloudDeployment>(wire);

            // Assert
            Assert.NotNull(deserialized);
            Assert.AreEqual(elasticsearchServiceUri, deserialized.ElasticsearchServiceUri);
            Assert.AreEqual(kibanaServiceUri, deserialized.KibanaServiceUri);
            Assert.AreEqual(kibanaSsoUri, deserialized.KibanaSsoUri);

            // Verify all URIs are absolute
            Assert.IsTrue(deserialized.ElasticsearchServiceUri.IsAbsoluteUri);
            Assert.IsTrue(deserialized.KibanaServiceUri.IsAbsoluteUri);
            Assert.IsTrue(deserialized.KibanaSsoUri.IsAbsoluteUri);
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
                Assert.AreEqual("elasticsearch", esElement.GetString());
            }
            if (root.TryGetProperty("kibanaServiceUrl", out var kibanaElement))
            {
                Assert.AreEqual("kibana", kibanaElement.GetString());
            }
            if (root.TryGetProperty("kibanaSsoUrl", out var kibanaSsoElement))
            {
                Assert.AreEqual("kibana/sso", kibanaSsoElement.GetString());
            }

            // Act - Deserialize
            var deserialized = ModelReaderWriter.Read<ElasticCloudDeployment>(wire);

            // Assert
            Assert.NotNull(deserialized);
            Assert.AreEqual(elasticsearchServiceUri, deserialized.ElasticsearchServiceUri);
            Assert.AreEqual(kibanaServiceUri, deserialized.KibanaServiceUri);
            Assert.AreEqual(kibanaSsoUri, deserialized.KibanaSsoUri);

            // Verify all URIs are relative
            Assert.IsFalse(deserialized.ElasticsearchServiceUri.IsAbsoluteUri);
            Assert.IsFalse(deserialized.KibanaServiceUri.IsAbsoluteUri);
            Assert.IsFalse(deserialized.KibanaSsoUri.IsAbsoluteUri);

            // Verify original strings are preserved
            Assert.AreEqual("elasticsearch", deserialized.ElasticsearchServiceUri.OriginalString);
            Assert.AreEqual("kibana", deserialized.KibanaServiceUri.OriginalString);
            Assert.AreEqual("kibana/sso", deserialized.KibanaSsoUri.OriginalString);
        }
    }
}
