// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Discovery.Tests
{
    /// <summary>
    /// Tests for Knowledge Bases operations.
    /// </summary>
    public class KnowledgeBasesTests : BookshelfClientTestBase
    {
        public KnowledgeBasesTests(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task ListKnowledgeBases()
        {
            // Arrange
            BookshelfClient client = CreateBookshelfClient();
            var knowledgeBasesClient = client.GetKnowledgeBasesClient();

            // Act
            var knowledgeBases = new List<KnowledgeBase>();
            await foreach (var kb in knowledgeBasesClient.GetAllAsync())
            {
                knowledgeBases.Add(kb);
            }

            // Assert
            Assert.That(knowledgeBases, Is.Not.Null);
            // List may be empty but should not throw
        }

        // DeleteKnowledgeBase test removed: KnowledgeBases no longer exposes a Delete API
    }
}
