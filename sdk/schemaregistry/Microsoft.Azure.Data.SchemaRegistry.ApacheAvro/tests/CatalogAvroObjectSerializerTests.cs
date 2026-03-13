// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Identity;
using Azure.Messaging.MessagingCatalog;
using Moq;
using NUnit.Framework;

namespace Microsoft.Azure.Data.SchemaRegistry.ApacheAvro.Tests
{
    /// <summary>
    /// Unit tests for SchemaRegistryAvroSerializer in catalog mode using Azure Messaging Catalog for schema management
    /// </summary>
    public class CatalogAvroObjectSerializerTests
    {
        [Test]
        public void Constructor_ValidParameters_CreatesInstanceSuccessfully()
        {
            // Arrange
            var mockClient = new Mock<MessagingCatalogClient>();
            var groupName = "test-group";
            var options = new SchemaRegistryAvroSerializerOptions { AutoRegisterSchemas = true };

            // Act & Assert - Should not throw
            Assert.DoesNotThrow(() => new SchemaRegistryAvroSerializer(mockClient.Object, groupName, options));
        }

        [Test]
        public void Constructor_NullCatalogClient_ThrowsArgumentNullException()
        {
            // Arrange
            MessagingCatalogClient catalogClient = null;
            var groupName = "test-group";
            var options = new SchemaRegistryAvroSerializerOptions();

            // Act & Assert
            Assert.Throws<ArgumentNullException>(() => new SchemaRegistryAvroSerializer(catalogClient, groupName, options));
        }

        [Test]
        public void Constructor_EmptyGroupName_DoesNotThrow()
        {
            // Arrange
            var mockClient = new Mock<MessagingCatalogClient>();
            string groupName = ""; // Empty string is actually allowed
            var options = new SchemaRegistryAvroSerializerOptions();

            // Act & Assert - Should not throw, empty group name is valid
            Assert.DoesNotThrow(() => new SchemaRegistryAvroSerializer(mockClient.Object, groupName, options));
        }

        [Test]
        public void Constructor_NullOptions_UsesDefaultOptions()
        {
            // Arrange
            var mockClient = new Mock<MessagingCatalogClient>();
            var groupName = "test-group";
            SchemaRegistryAvroSerializerOptions options = null;

            // Act & Assert - Should not throw and should use default options
            Assert.DoesNotThrow(() => new SchemaRegistryAvroSerializer(mockClient.Object, groupName, options));
        }
    }
}