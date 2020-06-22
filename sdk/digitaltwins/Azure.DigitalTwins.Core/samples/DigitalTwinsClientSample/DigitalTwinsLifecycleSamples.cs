// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text.Json;
using System.Threading.Tasks;
using Azure.DigitalTwins.Core.Models;
using Azure.DigitalTwins.Core.Serialization;
using static Azure.DigitalTwins.Core.Samples.SampleLogger;

namespace Azure.DigitalTwins.Core.Samples
{
    /// <summary>
    /// This sample creates all the models in \DTDL\Models folder in the ADT service instance
    /// and creates the corresponding twins in \DTDL\DigitalTwins folder
    /// The Diagram for the Hospital model looks like this:
    ///
    ///     +------------+
    ///     |  Building  +-----isEquippedWith-----+
    ///     +------------+                        |
    ///           |                               v
    ///          has                           +-----+
    ///           |                            | HVAC|
    ///           v                            +-----+
    ///     +------------+                        |
    ///     |   Floor    +<--controlsTemperature--+
    ///     +------------+
    ///           |
    ///        contains
    ///           |
    ///           v
    ///     +------------+                 +-----------------+
    ///     |   Room     |-with component->| WifiAccessPoint |
    ///     +------------+                 +-----------------+
    /// </summary>
    internal class DigitalTwinsLifecycleSamples
    {
        // Json folders and file paths
        private static readonly string s_dtdlDirectoryPath = Path.Combine(GetWorkingDirectory(), "DTDL");

        private static readonly string s_modelsPath = Path.Combine(s_dtdlDirectoryPath, "Models");
        private static readonly string s_twinsPath = Path.Combine(s_dtdlDirectoryPath, "DigitalTwins");
        private static readonly string s_relationshipsPath = Path.Combine(s_dtdlDirectoryPath, "Relationships");

        private readonly string _eventRouteId = $"sampleEventRouteId-{Guid.NewGuid()}";

        private readonly string eventhubEndpointName;
        private readonly DigitalTwinsClient client;

        public DigitalTwinsLifecycleSamples(DigitalTwinsClient dtClient, string eventhubEndpointName)
        {
            this.eventhubEndpointName = eventhubEndpointName;
            client = dtClient;
        }

        /// <summary>
        /// Creates all Models in the Models folder
        /// Creates all DigitalTwins in the DigitalTwins folder
        /// Connects all DigitalTwins using relationships in the Relationships folder.
        /// </summary>
        public async Task RunSamplesAsync()
        {
            // Ensure existing twins with the same name are deleted first
            await DeleteTwinsAsync();

            // Delete existing models
            await DeleteAllModelsAsync();

            // Create all the models
            await AddAllModelsAsync();

            // Get all models
            await GetAllModelsAsync();

            // Create twin counterparts for all the models
            await CreateAllTwinsAsync();

            // Get all twins
            await QueryTwinsAsync();

            // Create all the relationships
            await ConnectTwinsTogetherAsync();

            // Creating event route
            await CreateEventRoute();

            // Get all event routes
            await GetEventRoutes();

            // Deleting event route
            await DeleteEventRoute();
        }

        /// <summary>
        /// Delete models created by FullLifecycleSample for the ADT service instance
        /// </summary>

        private async Task DeleteAllModelsAsync()
        {
            PrintHeader("DELETING MODELS");

            try
            {
                // This is to ensure models are deleted in an order such that no other models are referencing it
                var models = new Queue();
                models.Enqueue(SamplesConstants.RoomModelId);
                models.Enqueue(SamplesConstants.WifiModelId);
                models.Enqueue(SamplesConstants.BuildingModelId);
                models.Enqueue(SamplesConstants.FloorModelId);
                models.Enqueue(SamplesConstants.HvacModelId);

                foreach (string modelId in models)
                {
                    await client.DeleteModelAsync(modelId);
                    Console.WriteLine($"Deleted model '{modelId}'.");
                }
            }
            catch (RequestFailedException ex) when (ex.Status == (int)HttpStatusCode.NotFound)
            {
                // Model does not exist.
            }
            catch (Exception ex)
            {
                FatalError($"Failed to delete models due to:\n{ex}");
            }
        }

        /// <summary>
        /// Loads all the models found in the Models directory into memory and uses CreateModelsAsync API to create all the models in the ADT service instance
        /// </summary>
        private async Task AddAllModelsAsync()
        {
            PrintHeader("CREATING MODELS");

            List<string> modelsToCreate = FileHelper.LoadAllFilesInPath(s_modelsPath).Values.ToList();

            if (modelsToCreate == null || !modelsToCreate.Any())
            {
                throw new Exception("Could not load models from disk.");
            }

            try
            {
                await client.CreateModelsAsync(modelsToCreate);
                Console.WriteLine("Created models.");
            }
            catch (RequestFailedException ex) when (ex.Status == (int)HttpStatusCode.Conflict)
            {
                Console.WriteLine($"One or more models already exist. Continuing with the sample optimistically.");
            }
            catch (Exception ex)
            {
                FatalError($"Failed to create models due to:\n{ex}");
            }
        }

        /// <summary>
        /// Gets all the models within the ADT service instance.
        /// </summary>
        public async Task GetAllModelsAsync()
        {
            PrintHeader("LISTING MODELS");
            try
            {
                // Get all the twin types

                #region Snippet:DigitalTwinsSampleGetModels

                AsyncPageable<ModelData> allModels = client.GetModelsAsync();
                await foreach (ModelData model in allModels)
                {
                    Console.WriteLine($"Retrieved model '{model.Id}', " +
                        $"display name '{model.DisplayName["en"]}', " +
                        $"upload time '{model.UploadTime}', " +
                        $"and decommissioned '{model.Decommissioned}'");
                }

                #endregion Snippet:DigitalTwinsSampleGetModels
            }
            catch (RequestFailedException ex)
            {
                FatalError($"Failed to get all the models due to:\n{ex}");
            }
        }

        /// <summary>
        /// Delete a twin, and any relationships it might have
        /// </summary>
        public async Task DeleteTwinsAsync()
        {
            PrintHeader("DELETE DIGITAL TWINS");
            Dictionary<string, string> twins = FileHelper.LoadAllFilesInPath(s_twinsPath);

            foreach (KeyValuePair<string, string> twin in twins)
            {
                var digitalTwinId = twin.Key;

                try
                {
                    // Delete all relationships
                    AsyncPageable<string> relationships = client.GetRelationshipsAsync(digitalTwinId);
                    await foreach (var relationshipJson in relationships)
                    {
                        BasicRelationship relationship = JsonSerializer.Deserialize<BasicRelationship>(relationshipJson);
                        await client.DeleteRelationshipAsync(digitalTwinId, relationship.Id);
                        Console.WriteLine($"Found and deleted relationship '{relationship.Id}'.");
                    }

                    // Delete any incoming relationships
                    AsyncPageable<IncomingRelationship> incomingRelationships = client.GetIncomingRelationshipsAsync(digitalTwinId);

                    await foreach (IncomingRelationship incomingRelationship in incomingRelationships)
                    {
                        await client.DeleteRelationshipAsync(incomingRelationship.SourceId, incomingRelationship.RelationshipId);
                        Console.WriteLine($"Found and deleted incoming relationship '{incomingRelationship.RelationshipId}'.");
                    }

                    // Now the digital twin should be safe to delete

                    #region Snippet:DigitalTwinsSampleDeleteTwin

                    await client.DeleteDigitalTwinAsync(digitalTwinId);
                    Console.WriteLine($"Deleted digital twin '{digitalTwinId}'.");

                    #endregion Snippet:DigitalTwinsSampleDeleteTwin
                }
                catch (RequestFailedException ex) when (ex.Status == (int)HttpStatusCode.NotFound)
                {
                    // Digital twin or relationship does not exist
                }
                catch (RequestFailedException ex)
                {
                    FatalError($"Failed to delete '{digitalTwinId}' due to {ex.Message}");
                }
            }
        }

        /// <summary>
        /// Creates all twins specified in the \DTDL\DigitalTwins directory
        /// </summary>
        public async Task CreateAllTwinsAsync()
        {
            PrintHeader("CREATE DIGITAL TWINS");
            Dictionary<string, string> twins = FileHelper.LoadAllFilesInPath(s_twinsPath);

            // Call APIs to create the twins.
            foreach (KeyValuePair<string, string> twin in twins)
            {
                try
                {
                    Response<string> response = await client.CreateDigitalTwinAsync(twin.Key, twin.Value);

                    Console.WriteLine($"Created digital twin '{twin.Key}'.");
                    Console.WriteLine($"\tBody: {response?.Value}");
                }
                catch (Exception ex)
                {
                    FatalError($"Could not create digital twin '{twin.Key}' due to {ex}");
                }
            }
        }

        public async Task QueryTwinsAsync()
        {
            PrintHeader("QUERY DIGITAL TWINS");

            try
            {
                Console.WriteLine("Making a twin query and iterating over the results.");

                #region Snippet:DigitalTwinsSampleQueryTwins

                // This code snippet demonstrates the simplest way to iterate over the digital twin results, where paging
                // happens under the covers.
                AsyncPageable<string> asyncPageableResponse = client.QueryAsync("SELECT * FROM digitaltwins");

                // Iterate over the twin instances in the pageable response.
                // The "await" keyword here is required because new pages will be fetched when necessary,
                // which involves a request to the service.
                await foreach (string response in asyncPageableResponse)
                {
                    BasicDigitalTwin twin = JsonSerializer.Deserialize<BasicDigitalTwin>(response);
                    Console.WriteLine($"Found digital twin '{twin.Id}'");
                }

                #endregion Snippet:DigitalTwinsSampleQueryTwins

                Console.WriteLine("Making a twin query, with query-charge header extraction.");

                #region Snippet:DigitalTwinsSampleQueryTwinsWithQueryCharge

                // This code snippet demonstrates how you could extract the query charges incurred when calling
                // the query API. It iterates over the response pages first to access to the query-charge header,
                // and then the digital twin results within each page.

                AsyncPageable<string> asyncPageableResponseWithCharge = client.QueryAsync("SELECT * FROM digitaltwins");
                int pageNum = 0;

                // The "await" keyword here is required as a call is made when fetching a new page.
                await foreach (Page<string> page in asyncPageableResponseWithCharge.AsPages())
                {
                    Console.WriteLine($"Page {++pageNum} results:");

                    // Extract the query-charge header from the page
                    if (QueryChargeHelper.TryGetQueryCharge(page, out float queryCharge))
                    {
                        Console.WriteLine($"Query charge was: {queryCharge}");
                    }

                    // Iterate over the twin instances.
                    // The "await" keyword is not required here as the paged response is local.
                    foreach (string response in page.Values)
                    {
                        BasicDigitalTwin twin = JsonSerializer.Deserialize<BasicDigitalTwin>(response);
                        Console.WriteLine($"Found digital twin '{twin.Id}'");
                    }
                }

                #endregion Snippet:DigitalTwinsSampleQueryTwinsWithQueryCharge
            }
            catch (Exception ex)
            {
                FatalError($"Could not query digital twins due to {ex}");
            }
        }

        /// <summary>
        /// Creates all the relationships defined in the \DTDL\Relationships directory
        /// </summary>
        public async Task ConnectTwinsTogetherAsync()
        {
            PrintHeader("CONNECT DIGITAL TWINS");

            // First we load the relationships into memory
            Dictionary<string, string> allRelationships = FileHelper.LoadAllFilesInPath(s_relationshipsPath);

            foreach (KeyValuePair<string, string> relationshipSet in allRelationships)
            {
                // For each relationship array we deserialize it first
                // We deserialize as BasicRelationship to get the entire custom relationship (custom relationship properties).
                IEnumerable<BasicRelationship> relationships = JsonSerializer.Deserialize<IEnumerable<BasicRelationship>>(relationshipSet.Value);

                // From loaded relationships, get the source Id and Id from each one,
                // and create it with full relationship payload
                foreach (BasicRelationship relationship in relationships)
                {
                    try
                    {
                        string serializedRelationship = JsonSerializer.Serialize(relationship);

                        await client.CreateRelationshipAsync(
                            relationship.SourceId,
                            relationship.Id,
                            serializedRelationship);

                        Console.WriteLine($"Linked twin '{relationship.SourceId}' to twin '{relationship.TargetId}' as '{relationship.Name}'");
                    }
                    catch (RequestFailedException ex) when (ex.Status == (int)HttpStatusCode.Conflict)
                    {
                        Console.WriteLine($"Relationship '{relationship.Id}' already exists: {ex.Message}");
                    }
                }
            }
        }

        /// <summary>
        /// Gets all event routes for digital Twin
        /// </summary>
        public async Task GetEventRoutes()
        {
            PrintHeader("LISTING EVENT ROUTES");
            try
            {
                #region Snippet:DigitalTwinsSampleGetEventRoutes

                AsyncPageable<EventRoute> response = client.GetEventRoutesAsync();
                await foreach (EventRoute er in response)
                {
                    Console.WriteLine($"Event route '{er.Id}', endpoint name '{er.EndpointName}'");
                }

                #endregion Snippet:DigitalTwinsSampleGetEventRoutes
            }
            catch (Exception ex)
            {
                FatalError($"Could not get event routes due to {ex.Message}");
            }
        }

        /// <summary>
        /// Creates event route for digital Twin
        /// </summary>
        public async Task CreateEventRoute()
        {
            PrintHeader("CREATE EVENT ROUTE");
            try
            {
                #region Snippet:DigitalTwinsSampleCreateEventRoute

                string eventFilter = "$eventType = 'DigitalTwinTelemetryMessages' or $eventType = 'DigitalTwinLifecycleNotification'";
                var eventRoute = new EventRoute(eventhubEndpointName)
                {
                    Filter = eventFilter
                };

                await client.CreateEventRouteAsync(_eventRouteId, eventRoute);
                Console.WriteLine($"Created event route '{_eventRouteId}'.");

                #endregion Snippet:DigitalTwinsSampleCreateEventRoute
            }
            catch (Exception ex)
            {
                FatalError($"CreateEventRoute: Failed to create event route due to: {ex.Message}");
            }
        }

        /// <summary>
        /// Deletes event route for digital Twin
        /// </summary>
        public async Task DeleteEventRoute()
        {
            PrintHeader("DELETING EVENT ROUTE");
            try
            {
                #region Snippet:DigitalTwinsSampleDeleteEventRoute

                await client.DeleteEventRouteAsync(_eventRouteId);
                Console.WriteLine($"Deleted event route '{_eventRouteId}'.");

                #endregion Snippet:DigitalTwinsSampleDeleteEventRoute
            }
            catch (Exception ex)
            {
                FatalError($"Could not delete event routes due to: {ex.Message}");
            }
        }

        private static string GetWorkingDirectory()
        {
            string codeBase = Assembly.GetExecutingAssembly().CodeBase;
            var uri = new UriBuilder(codeBase);
            string path = Uri.UnescapeDataString(uri.Path);
            return Path.GetDirectoryName(path);
        }
    }
}
