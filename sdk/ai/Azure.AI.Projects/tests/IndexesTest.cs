// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using System.Threading.Tasks;
using Microsoft.ClientModel.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests
{
    public class IndexesTest : ProjectsClientTestBase
    {
        public IndexesTest(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task SearchIndexesTest()
        {
            string indexName = TestEnvironment.INDEX_NAME;
            string indexVersion = TestEnvironment.INDEX_VERSION;
            string aiSearchConnectionName = TestEnvironment.AI_SEARCH_CONNECTION_NAME;
            string aiSearchIndexName = TestEnvironment.AI_SEARCH_INDEX_NAME;

            AIProjectClient projectClient = GetTestProjectClient();

            BinaryContent content = BinaryContent.Create(BinaryData.FromObjectAsJson(new
            {
                connectionName = aiSearchConnectionName,
                indexName = aiSearchIndexName,
                type = "AzureSearch",
                description = "Sample Index for testing",
                displayName = "Sample Index"
            }));

            Console.WriteLine($"Create an Index named `{indexName}` referencing an existing AI Search resource:");
            AIProjectIndex index = (AIProjectIndex)await projectClient.Indexes.CreateOrUpdateAsync(
                name: indexName,
                version: indexVersion,
                content: content
            );
            ValidateIndex(
                index,
                expectedIndexType: "AzureSearch",
                expectedIndexName: indexName,
                expectedIndexVersion: indexVersion,
                expectedAiSearchConnectionName: aiSearchConnectionName,
                expectedAiSearchIndexName: aiSearchIndexName
            );

            Console.WriteLine($"Get an existing Index named `{indexName}`, version `{indexVersion}`:");
            AIProjectIndex retrievedIndex = await projectClient.Indexes.GetIndexAsync(name: indexName, version: indexVersion);
            ValidateIndex(
                retrievedIndex,
                expectedIndexType: "AzureSearch",
                expectedIndexName: indexName,
                expectedIndexVersion: indexVersion,
                expectedAiSearchConnectionName: aiSearchConnectionName,
                expectedAiSearchIndexName: aiSearchIndexName
            );

            Console.WriteLine($"Listing all versions of the Index named `{indexName}`:");
            bool isEmpty = true;
            await foreach (AIProjectIndex version in projectClient.Indexes.GetIndexVersionsAsync(name: indexName))
            {
                isEmpty = false;
                ValidateIndex(version);
            }
            Assert.That(isEmpty, Is.False, "Expected at least one version of the Index to be returned.");

            Console.WriteLine($"Listing all Indices:");
            isEmpty = true;
            await foreach (AIProjectIndex version in projectClient.Indexes.GetIndexesAsync())
            {
                isEmpty = false;
                ValidateIndex(version);
                Console.WriteLine($"Index name: {version.Name}, index version: {version.Version}");
            }
            Assert.That(isEmpty, Is.False, "Expected at least one Index to be returned.");

            // Remove once service supports Delete
            try
            {
                Console.WriteLine($"To delete: index name: {indexName}, index version: {indexVersion}");
                Console.WriteLine("Delete the Index version created above:");
                await projectClient.Indexes.DeleteAsync(name: indexName, version: indexVersion); // TODO: delete throws 404 error

                Console.WriteLine("Attempt to delete again. It does not exist and should return 204:");
                await projectClient.Indexes.DeleteAsync(name: indexName, version: indexVersion);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Delete index currently throws 404 error: {e}");
                // throw;
            }
        }
    }
}
