// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Discovery.Tests.Samples
{
    /// <summary>
    /// Samples used by the Azure.AI.Discovery README and samples markdown. The
    /// snippet regions are injected into the docs by the repository's snippet
    /// tooling, so the code here is the single source of truth for those examples.
    /// </summary>
    public partial class DiscoverySamples : SamplesBase<DiscoveryTestEnvironment>
    {
        [Test]
        public async Task GettingStarted()
        {
#if !SNIPPET
            Uri workspaceEndpoint = new Uri(TestEnvironment.WorkspaceEndpoint);
            Uri bookshelfEndpoint = new Uri(TestEnvironment.BookshelfEndpoint);
#endif

            #region Snippet:Discovery_CreateClients
#if SNIPPET
            Uri workspaceEndpoint = new Uri("<workspace-endpoint>");
#endif
            WorkspaceClient workspaceClient = new WorkspaceClient(workspaceEndpoint, new DefaultAzureCredential());

#if SNIPPET
            Uri bookshelfEndpoint = new Uri("<bookshelf-endpoint>");
#endif
            BookshelfClient bookshelfClient = new BookshelfClient(bookshelfEndpoint, new DefaultAzureCredential());
            #endregion

            #region Snippet:Discovery_CreateAndReadConversation
            DiscoveryConversationsClient conversationsClient = workspaceClient.GetDiscoveryConversationsClient();

            DiscoveryConversation created = await conversationsClient.CreateAsync(
                projectName: "my-project",
                investigationName: "/projects/my-project/investigations/my-investigation",
                displayName: "Getting started conversation");

            DiscoveryConversation conversation = await conversationsClient.GetAsync(created.Name);
            Console.WriteLine($"Conversation: {conversation.Name}");
            #endregion

            #region Snippet:Discovery_CreateAndReadKnowledgeBase
            KnowledgeBases knowledgeBases = bookshelfClient.GetKnowledgeBasesClient();

            RequestContent body = RequestContent.Create(new
            {
                description = "My knowledge base",
                storageAssetReferences = new[]
                {
                    new
                    {
                        id = "<storage-asset-resource-id>",
                        userAssignedIdentity = "<user-assigned-identity-resource-id>",
                    },
                },
            });

            Operation<BinaryData> operation = await knowledgeBases.CreateOrUpdateAsync(
                WaitUntil.Completed,
                "my-knowledge-base",
                body);

            KnowledgeBase knowledgeBase = await knowledgeBases.GetAsync("my-knowledge-base");
            Console.WriteLine($"Knowledge base: {knowledgeBase.Name}");
            #endregion

            #region Snippet:Discovery_ListKnowledgeBases
            await foreach (KnowledgeBase kb in knowledgeBases.GetAllAsync())
            {
                Console.WriteLine(kb.Name);
            }
            #endregion
        }
    }
}
