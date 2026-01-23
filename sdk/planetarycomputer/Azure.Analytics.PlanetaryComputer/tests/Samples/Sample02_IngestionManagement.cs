// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.Analytics.PlanetaryComputer.Tests.Samples
{
    /// <summary>
    /// Samples demonstrating how to manage ingestion operations using the Planetary Computer SDK.
    /// Includes working with managed identities, sources, ingestion definitions, and runs.
    /// </summary>
    public partial class Sample02_IngestionManagement : PlanetaryComputerTestBase
    {
        public Sample02_IngestionManagement(bool isAsync) : base(isAsync) { }
        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task ListManagedIdentities()
        {
            #region Snippet:Sample02_ListManagedIdentities
            // Create a Planetary Computer client
            #if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

            #else

            var client = GetTestClient();

            #endif
            IngestionClient ingestionClient = client.GetIngestionClient();

            // List all managed identities
            Console.WriteLine("Available Managed Identities:");
            await foreach (ManagedIdentityMetadata identity in ingestionClient.GetManagedIdentitiesAsync())
            {
                Console.WriteLine($"  Object ID: {identity.ObjectId}");
                Console.WriteLine($"  Resource ID: {identity.ResourceId}");
            }
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task ListIngestionSources()
        {
            #region Snippet:Sample02_ListIngestionSources
            // Create a Planetary Computer client
            #if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

            #else

            var client = GetTestClient();

            #endif
            IngestionClient ingestionClient = client.GetIngestionClient();

            // List all ingestion sources
            Console.WriteLine("Ingestion Sources:");
            await foreach (IngestionSourceSummary source in ingestionClient.GetSourcesAsync())
            {
                Console.WriteLine($"  Source ID: {source.Id}");
                Console.WriteLine($"  Kind: {source.Kind}");
            }
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task CreateManagedIdentityIngestionSource()
        {
            #region Snippet:Sample02_CreateManagedIdentitySource
            // Create a Planetary Computer client
            #if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

            #else

            var client = GetTestClient();

            #endif
            IngestionClient ingestionClient = client.GetIngestionClient();

            // Get a managed identity
            ManagedIdentityMetadata identity = null;
            await foreach (ManagedIdentityMetadata id in ingestionClient.GetManagedIdentitiesAsync())
            {
                identity = id;
                break;
            }

            // Create a managed identity ingestion source
            string containerUri = "https://mystorageaccount.blob.core.windows.net/mycontainer";
            var connectionInfo = new ManagedIdentityConnection(new Uri(containerUri), identity.ObjectId);
            var ingestionSource = new ManagedIdentityIngestionSource(Guid.NewGuid(), connectionInfo);

            Response<IngestionSource> response = await ingestionClient.CreateSourceAsync(ingestionSource);
            Console.WriteLine($"Created ingestion source: {response.Value.Id}");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task CreateSASTokenIngestionSource()
        {
            #region Snippet:Sample02_CreateSASTokenSource
            // Create a Planetary Computer client
            #if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

            #else

            var client = GetTestClient();

            #endif
            IngestionClient ingestionClient = client.GetIngestionClient();

            // Create a SAS token ingestion source
            string sasContainerUri = "https://mystorageaccount.blob.core.windows.net/mycontainer";
            string sasToken = "sp=rl&st=2024-01-01T00:00:00Z&se=2024-12-31T23:59:59Z&sv=2023-01-03&sr=c&sig=...";

            var sasConnectionInfo = new SharedAccessSignatureTokenConnection(new Uri(sasContainerUri))
            {
                SharedAccessSignatureToken = sasToken
            };

            var sasIngestionSource = new SharedAccessSignatureTokenIngestionSource(Guid.NewGuid(), sasConnectionInfo);
            Response<IngestionSource> response = await ingestionClient.CreateSourceAsync(sasIngestionSource);
            Console.WriteLine($"Created SAS token ingestion source: {response.Value.Id}");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task CreateIngestionDefinition()
        {
            #region Snippet:Sample02_CreateIngestionDefinition
            // Create a Planetary Computer client
            #if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

            #else

            var client = GetTestClient();

            #endif
            IngestionClient ingestionClient = client.GetIngestionClient();

            // Create an ingestion definition
            string collectionId = "my-collection";
            string sourceCatalogUrl = "https://example.com/catalog.json";

            var ingestionDefinition = new IngestionInformation("StaticCatalog")
            {
                DisplayName = "My Dataset Ingestion",
                SourceCatalogUrl = new Uri(sourceCatalogUrl),
                KeepOriginalAssets = true,
                SkipExistingItems = true
            };

            Response<IngestionInformation> response = await ingestionClient.CreateAsync(collectionId, ingestionDefinition);
            Console.WriteLine($"Created ingestion: {response.Value.Id}");
            Console.WriteLine($"Display Name: {response.Value.DisplayName}");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task UpdateIngestionDefinition()
        {
            #region Snippet:Sample02_UpdateIngestionDefinition
            // Create a Planetary Computer client
            #if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

            #else

            var client = GetTestClient();

            #endif
            IngestionClient ingestionClient = client.GetIngestionClient();

            string collectionId = "my-collection";
            Guid ingestionId = Guid.Parse("00000000-0000-0000-0000-000000000000");

            // Update the ingestion display name
            var updateData = new
            {
                ImportType = "StaticCatalog",
                DisplayName = "Updated Ingestion Name"
            };

            Response updateResponse = await ingestionClient.UpdateAsync(
                collectionId,
                ingestionId,
                RequestContent.Create(updateData));

            Console.WriteLine("Ingestion updated successfully");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task CreateAndMonitorIngestionRun()
        {
            #region Snippet:Sample02_CreateAndMonitorRun
            // Create a Planetary Computer client
            #if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

            #else

            var client = GetTestClient();

            #endif
            IngestionClient ingestionClient = client.GetIngestionClient();

            string collectionId = "my-collection";
            Guid ingestionId = Guid.Parse("00000000-0000-0000-0000-000000000000");

            // Create an ingestion run
            Response<IngestionRun> runResponse = await ingestionClient.CreateRunAsync(collectionId, ingestionId);
            Guid runId = runResponse.Value.Id;
            Console.WriteLine($"Created ingestion run: {runId}");

            // Monitor the run status
            Response<IngestionRun> statusResponse = await ingestionClient.GetRunAsync(collectionId, ingestionId, runId);
            IngestionRun run = statusResponse.Value;

            Console.WriteLine($"Run Status: {run.Operation.Status}");
            Console.WriteLine($"Total Items: {run.Operation.TotalItems}");
            Console.WriteLine($"Successful: {run.Operation.TotalSuccessfulItems}");
            Console.WriteLine($"Failed: {run.Operation.TotalFailedItems}");
            Console.WriteLine($"Pending: {run.Operation.TotalPendingItems}");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task ListIngestions()
        {
            #region Snippet:Sample02_ListIngestions
            // Create a Planetary Computer client
            #if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

            #else

            var client = GetTestClient();

            #endif
            IngestionClient ingestionClient = client.GetIngestionClient();

            string collectionId = "my-collection";

            // List all ingestions for a collection
            Console.WriteLine($"Ingestions for collection '{collectionId}':");
            await foreach (IngestionInformation ingestion in ingestionClient.GetAllAsync(collectionId))
            {
                Console.WriteLine($"  ID: {ingestion.Id}");
                Console.WriteLine($"  Display Name: {ingestion.DisplayName}");
                Console.WriteLine($"  Import Type: {ingestion.ImportType}");
            }
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetIngestionById()
        {
            #region Snippet:Sample02_GetIngestion
            // Create a Planetary Computer client
            #if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

            #else

            var client = GetTestClient();

            #endif
            IngestionClient ingestionClient = client.GetIngestionClient();

            string collectionId = "my-collection";
            Guid ingestionId = Guid.Parse("00000000-0000-0000-0000-000000000000");

            // Get a specific ingestion
            Response<IngestionInformation> response = await ingestionClient.GetAsync(collectionId, ingestionId);
            IngestionInformation ingestion = response.Value;

            Console.WriteLine($"Ingestion ID: {ingestion.Id}");
            Console.WriteLine($"Display Name: {ingestion.DisplayName}");
            Console.WriteLine($"Import Type: {ingestion.ImportType}");
            Console.WriteLine($"Source Catalog URL: {ingestion.SourceCatalogUrl}");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task ListRunsForIngestion()
        {
            #region Snippet:Sample02_ListRuns
            // Create a Planetary Computer client
            #if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

            #else

            var client = GetTestClient();

            #endif
            IngestionClient ingestionClient = client.GetIngestionClient();

            string collectionId = "my-collection";
            Guid ingestionId = Guid.Parse("00000000-0000-0000-0000-000000000000");

            // List all runs for an ingestion
            Console.WriteLine("Ingestion Runs:");
            await foreach (IngestionRun run in ingestionClient.GetRunsAsync(collectionId, ingestionId))
            {
                Console.WriteLine($"  Run ID: {run.Id}");
                Console.WriteLine($"  Status: {run.Operation.Status}");
                Console.WriteLine($"  Total Items: {run.Operation.TotalItems}");
            }
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task GetOperationById()
        {
            #region Snippet:Sample02_GetOperation
            // Create a Planetary Computer client
            #if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

            #else

            var client = GetTestClient();

            #endif
            IngestionClient ingestionClient = client.GetIngestionClient();

            Guid operationId = Guid.Parse("00000000-0000-0000-0000-000000000000");

            // Get operation details
            Response<LongRunningOperation> response = await ingestionClient.GetOperationAsync(operationId);
            LongRunningOperation operation = response.Value;

            Console.WriteLine($"Operation ID: {operation.Id}");
            Console.WriteLine($"Status: {operation.Status}");
            Console.WriteLine($"Type: {operation.Type}");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task CancelOperation()
        {
            #region Snippet:Sample02_CancelOperation
            // Create a Planetary Computer client
            #if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

            #else

            var client = GetTestClient();

            #endif
            IngestionClient ingestionClient = client.GetIngestionClient();

            Guid operationId = Guid.Parse("00000000-0000-0000-0000-000000000000");

            // Cancel a specific operation
            try
            {
                Response cancelResponse = await ingestionClient.CancelOperationAsync(operationId);
                Console.WriteLine($"Successfully requested cancellation for operation: {operationId}");
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine($"Failed to cancel operation: {ex.Message}");
            }
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task CancelAllOperations()
        {
            #region Snippet:Sample02_CancelAllOperations
            // Create a Planetary Computer client
            #if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

            #else

            var client = GetTestClient();

            #endif
            IngestionClient ingestionClient = client.GetIngestionClient();

            // Cancel all running operations
            try
            {
                Response response = await ingestionClient.CancelAllOperationsAsync();
                Console.WriteLine("Successfully requested cancellation for all operations");
            }
            catch (RequestFailedException ex)
            {
                Console.WriteLine($"Failed to cancel operations: {ex.Message}");
            }
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task ManageIngestionSource()
        {
            #region Snippet:Sample02_ManageIngestionSource
            // Create a Planetary Computer client
            #if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

            #else

            var client = GetTestClient();

            #endif
            IngestionClient ingestionClient = client.GetIngestionClient();

            // Get a managed identity
            ManagedIdentityMetadata identity = null;
            await foreach (ManagedIdentityMetadata id in ingestionClient.GetManagedIdentitiesAsync())
            {
                identity = id;
                break;
            }

            // Create a source
            string containerUri = "https://mystorageaccount.blob.core.windows.net/mycontainer";
            var connectionInfo = new ManagedIdentityConnection(new Uri(containerUri), identity.ObjectId);
            var ingestionSource = new ManagedIdentityIngestionSource(Guid.NewGuid(), connectionInfo);

            Response<IngestionSource> createResponse = await ingestionClient.CreateSourceAsync(ingestionSource);
            Guid sourceId = createResponse.Value.Id;
            Console.WriteLine($"Created source: {sourceId}");

            // Get the source
            Response<IngestionSource> getResponse = await ingestionClient.GetSourceAsync(sourceId);
            Console.WriteLine($"Retrieved source: {getResponse.Value.Id}");

            // Replace the source with updated configuration
            var updatedSource = new ManagedIdentityIngestionSource(sourceId, connectionInfo);
            Response<IngestionSource> replaceResponse = await ingestionClient.ReplaceSourceAsync(sourceId, updatedSource);
            Console.WriteLine($"Replaced source: {replaceResponse.Value.Id}");

            // Delete the source
            await ingestionClient.DeleteSourceAsync(sourceId);
            Console.WriteLine($"Deleted source: {sourceId}");
            #endregion
        }

        [Test]
        [Ignore("Only for sample compilation verification")]
        public async Task CompleteIngestionWorkflow()
        {
            #region Snippet:Sample02_CompleteWorkflow
            // Create a Planetary Computer client
            #if SNIPPET

            Uri endpoint = new Uri("https://contoso-catalog.gwhqfdeddydpareu.uksouth.geocatalog.spatio.azure.com");

            PlanetaryComputerProClient client = new PlanetaryComputerProClient(endpoint, new DefaultAzureCredential());

            #else

            var client = GetTestClient();

            #endif
            IngestionClient ingestionClient = client.GetIngestionClient();

            string collectionId = "my-collection";
            string sourceCatalogUrl = "https://example.com/catalog.json";

            // Step 1: Create an ingestion definition
            var ingestionDefinition = new IngestionInformation("StaticCatalog")
            {
                DisplayName = "My Dataset Ingestion",
                SourceCatalogUrl = new Uri(sourceCatalogUrl),
                KeepOriginalAssets = true,
                SkipExistingItems = true
            };

            Response<IngestionInformation> createResponse = await ingestionClient.CreateAsync(
                collectionId,
                ingestionDefinition);
            Guid ingestionId = createResponse.Value.Id;
            Console.WriteLine($"Created ingestion: {ingestionId}");

            // Step 2: Create and start an ingestion run
            Response<IngestionRun> runResponse = await ingestionClient.CreateRunAsync(collectionId, ingestionId);
            Guid runId = runResponse.Value.Id;
            Console.WriteLine($"Started ingestion run: {runId}");

            // Step 3: Monitor the run progress
            Response<IngestionRun> statusResponse = await ingestionClient.GetRunAsync(collectionId, ingestionId, runId);
            IngestionRun run = statusResponse.Value;

            Console.WriteLine($"Run Status: {run.Operation.Status}");
            Console.WriteLine($"Progress: {run.Operation.TotalSuccessfulItems}/{run.Operation.TotalItems} items");

            // Step 4: List all runs for this ingestion
            Console.WriteLine("\nAll runs for this ingestion:");
            await foreach (IngestionRun r in ingestionClient.GetRunsAsync(collectionId, ingestionId))
            {
                Console.WriteLine($"  Run {r.Id}: {r.Operation.Status}");
            }
            #endregion
        }
    }
}
