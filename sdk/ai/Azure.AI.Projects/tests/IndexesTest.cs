// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.ClientModel;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using Azure.Identity;
using Azure.AI.Projects.Tests.Utils;

namespace Azure.AI.Projects.Tests
{
    public class IndexesTest : ProjectsClientTestBase
    {
        public IndexesTest(bool isAsync) : base(isAsync) //, RecordedTestMode.Record)
        {
        }

        [TestCase]
        [RecordedTest]
        public async Task SearchIndexesTest()
        {
            string indexName = TestEnvironment.INDEXNAME;
            string indexVersion = TestEnvironment.INDEXVERSION;
            string aiSearchConnectionName = TestEnvironment.AISEARCHCONNECTIONNAME;
            string aiSearchIndexName = TestEnvironment.AISEARCHINDEXNAME;

            AIProjectClient projectClient = GetTestClient();

            if (IsAsync)
            {
                await SearchIndexesTestAsync(projectClient, indexName, indexVersion, aiSearchConnectionName, aiSearchIndexName);
            }
            else
            {
                SearchIndexesTestSync(projectClient, indexName, indexVersion, aiSearchConnectionName, aiSearchIndexName);
            }
        }

        private void SearchIndexesTestSync(AIProjectClient projectClient, string indexName, string indexVersion, string aiSearchConnectionName, string aiSearchIndexName)
        {
            BinaryContent content = BinaryContent.Create(BinaryData.FromObjectAsJson(new
            {
                connectionName = aiSearchConnectionName,
                indexName = aiSearchIndexName,
                type = "AzureSearch",
                description = "Sample Index for testing",
                displayName = "Sample Index"
            }));

            Console.WriteLine($"Create an Index named `{indexName}` referencing an existing AI Search resource:");
            SearchIndex index = (SearchIndex)projectClient.Indexes.CreateOrUpdate(
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
            SearchIndex retrievedIndex = projectClient.Indexes.GetIndex(name: indexName, version: indexVersion);
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
            foreach (SearchIndex version in projectClient.Indexes.GetIndexVersions(name: indexName))
            {
                isEmpty = false;
                ValidateIndex(version);
            }
            Assert.IsFalse(isEmpty, "Expected at least one version of the Index to be returned.");

            Console.WriteLine($"Listing all Indices:");
            isEmpty = true;
            foreach (SearchIndex version in projectClient.Indexes.GetIndexes())
            {
                isEmpty = false;
                ValidateIndex(version);
                Console.WriteLine($"Index name: {version.Name}, index version: {version.Version}");
            }
            Assert.IsFalse(isEmpty, "Expected at least one Index to be returned.");

            // Remove once service supports Delete
            try
            {
                Console.WriteLine($"To delete: index name: {indexName}, index version: {indexVersion}");
                Console.WriteLine("Delete the Index version created above:");
                projectClient.Indexes.Delete(name: indexName, version: indexVersion); // TODO: delete throws 404 error

                Console.WriteLine("Attempt to delete again. It does not exist and should return 204:");
                projectClient.Indexes.Delete(name: indexName, version: indexVersion);
            }
            catch (Exception e)
            {
                Console.WriteLine($"Delete index currently throws 404 error: {e}");
                // throw;
            }
        }

        private async Task SearchIndexesTestAsync(AIProjectClient projectClient, string indexName,string indexVersion, string aiSearchConnectionName, string aiSearchIndexName)
        {
            BinaryContent content = BinaryContent.Create(BinaryData.FromObjectAsJson(new
            {
                connectionName = aiSearchConnectionName,
                indexName = aiSearchIndexName,
                type = "AzureSearch",
                description = "Sample Index for testing",
                displayName = "Sample Index"
            }));

            Console.WriteLine($"Create an Index named `{indexName}` referencing an existing AI Search resource:");
            SearchIndex index = (SearchIndex) await projectClient.Indexes.CreateOrUpdateAsync(
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
            SearchIndex retrievedIndex = await projectClient.Indexes.GetIndexAsync(name: indexName, version: indexVersion);
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
            await foreach (SearchIndex version in projectClient.Indexes.GetIndexVersionsAsync(name: indexName))
            {
                isEmpty = false;
                ValidateIndex(version);
            }
            Assert.IsFalse(isEmpty, "Expected at least one version of the Index to be returned.");

            Console.WriteLine($"Listing all Indices:");
            isEmpty = true;
            await foreach (SearchIndex version in projectClient.Indexes.GetIndexesAsync())
            {
                isEmpty = false;
                ValidateIndex(version);
                Console.WriteLine($"Index name: {version.Name}, index version: {version.Version}");
            }
            Assert.IsFalse(isEmpty, "Expected at least one Index to be returned.");

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
