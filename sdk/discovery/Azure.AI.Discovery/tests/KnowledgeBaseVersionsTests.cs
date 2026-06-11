// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Discovery.Tests
{
    /// <summary>
    /// Tests for Knowledge Base Versions operations.
    /// Covers: Get, GetLatestVersion, CreateOrUpdate, GetAll (Paged), GetOperationStatus,
    /// StartIndexing (LRO), CancelIndexing (LRO), Delete, DeleteLatestVersion.
    ///
    /// Tests that create or delete KB versions use distinct, disposable KB names
    /// so the primary fixture (KNOWLEDGE_BASE_NAME / KNOWLEDGE_BASE_VERSION) is
    /// never touched by destructive operations.
    /// </summary>
    public class KnowledgeBaseVersionsTests : BookshelfClientTestBase
    {
        public KnowledgeBaseVersionsTests(bool isAsync) : base(isAsync)
        {
        }

        /// <summary>
        /// Helper: create a KB version on a disposable KB name via protocol method.
        /// Returns the HTTP status code.
        /// </summary>
        private async Task<int> CreateDisposableKBVersionAsync(
            KnowledgeBaseVersions versionsClient,
            string knowledgeBaseName,
            string versionName,
            string description = "Disposable KB version for test")
        {
            var content = RequestContent.Create(new
            {
                description,
                copilotInstruction = TestConstants.KBVersionCopilotInstruction,
                storageAssetReferences = new[]
                {
                    new
                    {
                        id = TestEnvironment.StorageAssetId,
                        userAssignedIdentity = TestEnvironment.UserAssignedIdentity
                    }
                },
            });
            var response = await versionsClient.CreateOrUpdateAsync(
                knowledgeBaseName, versionName, content);
            return response.Status;
        }

        [RecordedTest]
        public async Task ListKnowledgeBaseVersions()
        {
            // Arrange
            BookshelfClient client = CreateBookshelfClient();
            var versionsClient = client.GetKnowledgeBaseVersionsClient();
            string knowledgeBaseName = TestEnvironment.KnowledgeBaseName;

            // Act
            var versions = new List<KnowledgeBaseVersion>();
            await foreach (var version in versionsClient.GetAllAsync(knowledgeBaseName))
            {
                versions.Add(version);
            }

            // Assert
            Assert.That(versions, Is.Not.Null);
        }

        [RecordedTest]
        public async Task GetKnowledgeBaseVersion()
        {
            // Arrange
            BookshelfClient client = CreateBookshelfClient();
            var versionsClient = client.GetKnowledgeBaseVersionsClient();
            string knowledgeBaseName = TestEnvironment.KnowledgeBaseName;
            string versionName = TestEnvironment.KnowledgeBaseVersion;

            // Act
            var version = await versionsClient.GetAsync(knowledgeBaseName, versionName);

            // Assert
            ValidateResponse(version.Value, "KnowledgeBaseVersion");
            Assert.That(version.Value.Version, Is.EqualTo(versionName));
        }

        [RecordedTest]
        public async Task GetLatestVersion()
        {
            // Arrange
            BookshelfClient client = CreateBookshelfClient();
            var versionsClient = client.GetKnowledgeBaseVersionsClient();
            string knowledgeBaseName = TestEnvironment.KnowledgeBaseName;

            // Act
            var latest = await versionsClient.GetLatestVersionAsync(knowledgeBaseName);

            // Assert
            ValidateResponse(latest.Value, "KnowledgeBaseVersion");
            Assert.That(latest.Value, Is.Not.Null);
        }

        [RecordedTest]
        public async Task CreateOrUpdateKnowledgeBaseVersion()
        {
            // Arrange — use a disposable KB name so we don't collide with the
            // primary fixture's existing version (service enforces one version
            // per KB name).
            BookshelfClient client = CreateBookshelfClient();
            var versionsClient = client.GetKnowledgeBaseVersionsClient();
            string disposableKBName = Recording.GenerateAlphaNumericId("kbcrt", useOnlyLowercase: true);

            // Act
            int status = await CreateDisposableKBVersionAsync(
                versionsClient, disposableKBName, "v1",
                description: TestConstants.KBVersionDescription);

            // Assert
            Assert.That(status, Is.EqualTo(200).Or.EqualTo(201));
        }

        [RecordedTest]
        public async Task GetOperationStatus()
        {
            BookshelfClient client = CreateBookshelfClient();
            var versionsClient = client.GetKnowledgeBaseVersionsClient();
            string nodePoolId = TestEnvironment.NodePoolId;
            string projectId = TestEnvironment.ProjectArmId;

            // Use a unique disposable KB name per run (sync vs async get different
            // values from Recording.GenerateAlphaNumericId, but each is stable
            // between record and playback).
            string disposableKBName = Recording.GenerateAlphaNumericId("kbops", useOnlyLowercase: true);

            int createStatus = await CreateDisposableKBVersionAsync(
                versionsClient, disposableKBName, "v1",
                description: "KB version for GetOperationStatus test");
            Assert.That(createStatus, Is.EqualTo(200).Or.EqualTo(201));

            // Start indexing to get a real operation ID
            var startContent = RequestContent.Create(new { nodePoolId, projectId });
            var startOp = await versionsClient.StartIndexingAsync(
                WaitUntil.Started, disposableKBName, "v1",
                startContent, new RequestContext());

            // Extract operation ID
            var response = startOp.GetRawResponse();
            Assert.That(
                response.Headers.TryGetValue("operation-location", out string opLocation),
                Is.True, "Response must contain operation-location header");
            string operationId = opLocation.Split(new[] { "/operations/" }, StringSplitOptions.None).Last().Split('?').First();
            Assert.That(operationId, Is.Not.Null.And.Not.Empty);

            // Act
            var status = await versionsClient.GetOperationStatusAsync(
                disposableKBName, "v1", operationId);

            // Assert
            ValidateResponse(status.Value, "KnowledgeBaseOperationStatus");
            Assert.That(status.Value.Status, Is.Not.Null);

            // Cleanup — cancel indexing
            var cancelContent = RequestContent.Create(new { nodePoolId });
            await versionsClient.CancelIndexingAsync(
                WaitUntil.Started, disposableKBName, "v1",
                cancelContent, new RequestContext());
        }

        [RecordedTest]
        public async Task StartIndexing()
        {
            // Arrange
            BookshelfClient client = CreateBookshelfClient();
            var versionsClient = client.GetKnowledgeBaseVersionsClient();
            string knowledgeBaseName = TestEnvironment.KnowledgeBaseName;
            string versionName = TestEnvironment.KnowledgeBaseVersion;
            string nodePoolId = TestEnvironment.NodePoolId;
            string projectId = TestEnvironment.ProjectArmId;

            // Act
            var operation = await versionsClient.StartIndexingAsync(
                WaitUntil.Started,
                knowledgeBaseName,
                versionName,
                nodePoolId,
                projectId);

            // Assert
            Assert.That(operation.HasValue, Is.False, "Operation should still be in progress");
        }

        [RecordedTest]
        public async Task CancelIndexing()
        {
            // Arrange — start indexing first, then cancel immediately.
            BookshelfClient client = CreateBookshelfClient();
            var versionsClient = client.GetKnowledgeBaseVersionsClient();
            string knowledgeBaseName = TestEnvironment.KnowledgeBaseName;
            string versionName = TestEnvironment.KnowledgeBaseVersion;
            string nodePoolId = TestEnvironment.NodePoolId;
            string projectId = TestEnvironment.ProjectArmId;

            await versionsClient.StartIndexingAsync(
                WaitUntil.Started,
                knowledgeBaseName,
                versionName,
                nodePoolId,
                projectId);

            // Act
            var operation = await versionsClient.CancelIndexingAsync(
                WaitUntil.Started,
                knowledgeBaseName,
                versionName,
                nodePoolId);

            // Assert
            Assert.That(operation.HasValue, Is.False, "Cancel operation should still be in progress");
        }

        [RecordedTest]
        public async Task DeleteKnowledgeBaseVersion()
        {
            BookshelfClient client = CreateBookshelfClient();
            var versionsClient = client.GetKnowledgeBaseVersionsClient();

            string disposableKBName = Recording.GenerateAlphaNumericId("kbdel", useOnlyLowercase: true);

            int createStatus = await CreateDisposableKBVersionAsync(
                versionsClient, disposableKBName, "v1",
                description: "Sacrificial KB version for delete test");
            Assert.That(createStatus, Is.EqualTo(200).Or.EqualTo(201));

            // Use WaitUntil.Started to avoid LRO polling count mismatch during playback
            var operation = await versionsClient.DeleteAsync(
                WaitUntil.Started, disposableKBName, "v1");

            Assert.That(operation.HasValue, Is.False, "Delete operation should still be in progress");
        }

        [RecordedTest]
        public async Task DeleteLatestVersion()
        {
            // Arrange — create a sacrificial version on a disposable KB name
            BookshelfClient client = CreateBookshelfClient();
            var versionsClient = client.GetKnowledgeBaseVersionsClient();

            string disposableKBName = Recording.GenerateAlphaNumericId("kbdlt", useOnlyLowercase: true);

            int createStatus = await CreateDisposableKBVersionAsync(
                versionsClient, disposableKBName, "v1",
                description: "Sacrificial KB version for delete-latest test");
            Assert.That(createStatus, Is.EqualTo(200).Or.EqualTo(201));

            // Act
            var operation = await versionsClient.DeleteLatestVersionAsync(
                WaitUntil.Started, disposableKBName);

            // Assert
            Assert.That(operation.HasValue, Is.False, "Delete operation should still be in progress");
        }
    }
}