// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using NUnit.Framework;

namespace Azure.AI.Discovery.Tests
{
    /// <summary>
    /// Unit tests for Azure.AI.Discovery Bookshelf models.
    /// These tests verify model initialization without making HTTP calls.
    /// </summary>
    public class BookshelfModelsUnitTests
    {
        [Test]
        public void StorageAssetReference_CanBeInitialized()
        {
            // Arrange & Act
            var resourceId = new ResourceIdentifier(
                "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Storage/storageAccounts/sa/blobServices/default/containers/container");
            var storageRef = new StorageAssetReference(resourceId);

            // Assert
            Assert.That(storageRef, Is.Not.Null);
            Assert.That(storageRef.Id, Is.Not.Null);
        }

        [Test]
        public void StorageAssetReference_WithUserAssignedIdentity()
        {
            // Arrange & Act
            var resourceId = new ResourceIdentifier(
                "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.Storage/storageAccounts/sa/blobServices/default/containers/container");
            var identityId = new ResourceIdentifier(
                "/subscriptions/00000000-0000-0000-0000-000000000000/resourceGroups/rg/providers/Microsoft.ManagedIdentity/userAssignedIdentities/mi");
            var storageRef = new StorageAssetReference(resourceId)
            {
                UserAssignedIdentity = identityId
            };

            // Assert
            Assert.That(storageRef, Is.Not.Null);
            Assert.That(storageRef.UserAssignedIdentity, Is.Not.Null);
        }

        [Test]
        public void DiscoveryTag_CanBeInitialized_Bookshelf()
        {
            // Arrange & Act
            var tag = new DiscoveryTag
            {
                Key = "environment",
                Value = "production"
            };

            // Assert
            Assert.That(tag, Is.Not.Null);
            Assert.That(tag.Key, Is.EqualTo("environment"));
            Assert.That(tag.Value, Is.EqualTo("production"));
        }

        // StartIndexingRequest and CancelIndexingRequest are internal in the unified package
        // (direct parameters are used in the public API instead of request objects)

        [Test]
        public void IndexingStatus_EnumValuesExist()
        {
            // Assert - verify enum values can be accessed
            Assert.That(IndexingStatus.NotStarted.ToString(), Is.EqualTo("NotStarted"));
            Assert.That(IndexingStatus.Running.ToString(), Is.EqualTo("Running"));
            Assert.That(IndexingStatus.Succeeded.ToString(), Is.EqualTo("Succeeded"));
            Assert.That(IndexingStatus.Canceled.ToString(), Is.EqualTo("Canceled"));
            Assert.That(IndexingStatus.Failed.ToString(), Is.EqualTo("Failed"));
        }

        [Test]
        public void DiscoveryProvisioningState_EnumValuesExist()
        {
            // Assert - verify enum values can be accessed
            Assert.That(DiscoveryProvisioningState.Succeeded.ToString(), Is.EqualTo("Succeeded"));
            Assert.That(DiscoveryProvisioningState.Failed.ToString(), Is.EqualTo("Failed"));
            Assert.That(DiscoveryProvisioningState.Canceled.ToString(), Is.EqualTo("Canceled"));
        }

        [Test]
        public void OperationState_EnumValuesExist()
        {
            // Assert - verify enum values can be accessed
            Assert.That(OperationState.NotStarted.ToString(), Is.EqualTo("NotStarted"));
            Assert.That(OperationState.Running.ToString(), Is.EqualTo("Running"));
            Assert.That(OperationState.Succeeded.ToString(), Is.EqualTo("Succeeded"));
            Assert.That(OperationState.Failed.ToString(), Is.EqualTo("Failed"));
            Assert.That(OperationState.Canceled.ToString(), Is.EqualTo("Canceled"));
        }

        [Test]
        public void DiscoveryModelFactory_CanCreateKnowledgeBase()
        {
            // Arrange & Act
            var knowledgeBase = DiscoveryModelFactory.KnowledgeBase(
                name: "test-kb",
                description: "Test knowledge base");

            // Assert
            Assert.That(knowledgeBase, Is.Not.Null);
            Assert.That(knowledgeBase.Name, Is.EqualTo("test-kb"));
            Assert.That(knowledgeBase.Description, Is.EqualTo("Test knowledge base"));
        }

        [Test]
        public void DiscoveryModelFactory_CanCreateKnowledgeBaseVersion()
        {
            // Arrange & Act
            var version = DiscoveryModelFactory.KnowledgeBaseVersion(
                version: "1.0.0");

            // Assert
            Assert.That(version, Is.Not.Null);
            Assert.That(version.Version, Is.EqualTo("1.0.0"));
        }

        [Test]
        public void BookshelfClient_CanGetSubClients()
        {
            // This test verifies the client factory methods exist
            // Actual client creation requires credentials and endpoint

            // Assert - verify the method signatures exist by checking the type
            var clientType = typeof(BookshelfClient);
            var knowledgeBasesMethod = clientType.GetMethod("GetKnowledgeBasesClient");
            var knowledgeBaseVersionsMethod = clientType.GetMethod("GetKnowledgeBaseVersionsClient");

            Assert.That(knowledgeBasesMethod, Is.Not.Null, "GetKnowledgeBasesClient method should exist");
            Assert.That(knowledgeBaseVersionsMethod, Is.Not.Null, "GetKnowledgeBaseVersionsClient method should exist");
        }
    }
}
