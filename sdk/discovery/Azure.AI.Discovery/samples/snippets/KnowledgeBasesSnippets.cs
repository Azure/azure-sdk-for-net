// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.AI.Discovery;
using Azure.Core;
using Azure.Identity;

namespace Azure.AI.Discovery.Samples.Snippets
{
    /// <summary>
    /// Snippets demonstrating how to manage knowledge bases and their versions.
    /// </summary>
    public partial class KnowledgeBasesSnippets
    {
        /// <summary>
        /// List knowledge bases, create a new version, and start an indexing operation.
        /// </summary>
        public async Task ManageKnowledgeBaseVersions()
        {
            #region Snippet:ManageKnowledgeBaseVersions
            BookshelfClient client = new BookshelfClient(
                new Uri("https://<bookshelfName>.bookshelf.discovery.azure.com"),
                new DefaultAzureCredential());

            KnowledgeBases knowledgeBases = client.GetKnowledgeBasesClient();
            KnowledgeBaseVersions versions = client.GetKnowledgeBaseVersionsClient();

            // List knowledge bases.
            await foreach (KnowledgeBase kb in knowledgeBases.GetAllAsync())
            {
                Console.WriteLine($"Knowledge base: {kb.Name}");
            }

            // Create a knowledge base version. CreateOrUpdate is currently exposed as a protocol method
            // (no typed convenience overload), so build a RequestContent from the typed model.
            string knowledgeBaseName = "my-kb";
            string versionName = "v1";

            KnowledgeBaseVersion resource = new KnowledgeBaseVersion(
                description: "Research data for compound analysis",
                copilotInstruction: "Use this to query information about compound interactions.")
            {
                StorageAssetReferences =
                {
                    new StorageAssetReference(new ResourceIdentifier("/subscriptions/.../storageAssets/my-asset"))
                    {
                        UserAssignedIdentity = new ResourceIdentifier("/subscriptions/.../userAssignedIdentities/my-id"),
                    },
                },
            };

            Response createResponse = await versions.CreateOrUpdateAsync(
                knowledgeBaseName, versionName, RequestContent.Create(resource));
            Console.WriteLine($"CreateOrUpdate status: {createResponse.Status}");

            // Start indexing as a long-running operation.
            Operation<KnowledgeBaseVersion> indexing = await versions.StartIndexingAsync(
                WaitUntil.Completed,
                knowledgeBaseName,
                versionName,
                nodePoolId: "/subscriptions/.../nodePools/my-pool");

            Console.WriteLine($"Indexed version: {indexing.Value.Version}");
            #endregion
        }
    }
}
