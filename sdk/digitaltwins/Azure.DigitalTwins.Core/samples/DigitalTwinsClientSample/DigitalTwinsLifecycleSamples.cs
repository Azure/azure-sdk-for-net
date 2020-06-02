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
using Azure.DigitalTwins.Core.Queries;
using Azure.DigitalTwins.Core.Serialization;
using static Azure.DigitalTwins.Core.Samples.SampleLogger;
using static Azure.DigitalTwins.Core.Samples.UniqueIdHelper;

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

        private readonly string _eventhubEndpointName;
        private readonly string _eventRouteId = $"sampleEventRouteId-{Guid.NewGuid()}";

        private DigitalTwinsClient DigitalTwinsClient { get; }

        public DigitalTwinsLifecycleSamples(DigitalTwinsClient dtClient, string eventhubEndpointName)
        {
            _eventhubEndpointName = eventhubEndpointName;
            DigitalTwinsClient = dtClient;
        }

        /// <summary>
        /// Creates all Models in the Models folder
        /// Creates all DigitalTwins in the DigitalTwins folder
        /// Connects all DigitalTwins using relationships in the Relationships folder.
        /// </summary>
        public async Task RunSamplesAsync()
        {
            // Ensure existing twins with the same name are deleted first
            await DeleteTwinsAsync().ConfigureAwait(false);

            // Delete existing models
            await DeleteAllModelsAsync().ConfigureAwait(false);

            // Create all the models
            await AddAllModelsAsync().ConfigureAwait(false);

            // Get all models
            await GetAllModelsAsync().ConfigureAwait(false);

            // Create twin counterparts for all the models
            await CreateAllTwinsAsync().ConfigureAwait(false);

            // Get all twins
            await QueryTwinsAsync().ConfigureAwait(false);

            // Create all the relationships
            await ConnectTwinsTogetherAsync().ConfigureAwait(false);

            // Creating event route
            await CreateEventRoute().ConfigureAwait(false);

            // Get all event routes
            await GetEventRoutes().ConfigureAwait(false);

            // Deleting event route
            await DeleteEventRoute().ConfigureAwait(false);
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
                    await DigitalTwinsClient.DeleteModelAsync(modelId).ConfigureAwait(false);
                    Console.WriteLine($"Deleted model {modelId}");
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
                Response<IReadOnlyList<ModelData>> response = await DigitalTwinsClient.CreateModelsAsync(modelsToCreate).ConfigureAwait(false);
                Console.WriteLine($"Created models status: {response.GetRawResponse().Status}");
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

                AsyncPageable<ModelData> allModels = DigitalTwinsClient.GetModelsAsync();
                await foreach (ModelData model in allModels)
                {
                    Console.WriteLine($"Model Id: {model.Id}, display name: {model.DisplayName["en"]}, upload time: {model.UploadTime}, is decommissioned: {model.Decommissioned}");
                }

                #endregion Snippet:DigitalTwinsSampleGetModels
            }
            catch (Exception ex)
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
                try
                {
                    // Delete all relationships

                    #region Snippet:DigitalTwinsSampleGetRelationships

                    AsyncPageable<string> relationships = DigitalTwinsClient.GetRelationshipsAsync(twin.Key);

                    #endregion Snippet:DigitalTwinsSampleGetRelationships

                    await foreach (var relationshipJson in relationships)
                    {
                        BasicRelationship relationship = JsonSerializer.Deserialize<BasicRelationship>(relationshipJson);
                        await DigitalTwinsClient.DeleteRelationshipAsync(twin.Key, relationship.Id).ConfigureAwait(false);
                        Console.WriteLine($"Found and deleted relationship {relationship.Id}");
                    }

                    // Delete any incoming relationships

                    #region Snippet:DigitalTwinsSampleGetIncomingRelationships

                    AsyncPageable<IncomingRelationship> incomingRelationships = DigitalTwinsClient.GetIncomingRelationshipsAsync(twin.Key);

                    #endregion Snippet:DigitalTwinsSampleGetIncomingRelationships

                    await foreach (IncomingRelationship incomingRelationship in incomingRelationships)
                    {
                        await DigitalTwinsClient.DeleteRelationshipAsync(incomingRelationship.SourceId, incomingRelationship.RelationshipId).ConfigureAwait(false);
                        Console.WriteLine($"Found and deleted incoming relationship {incomingRelationship.RelationshipId}");
                    }

                    // Now the digital twin should be safe to delete

                    #region Snippet:DigitalTwinsSampleDeleteTwin

                    await DigitalTwinsClient.DeleteDigitalTwinAsync(twin.Key).ConfigureAwait(false);

                    #endregion Snippet:DigitalTwinsSampleDeleteTwin

                    Console.WriteLine($"Deleted digital twin {twin.Key}");
                }
                catch (RequestFailedException ex) when (ex.Status == (int)HttpStatusCode.NotFound)
                {
                    // Digital twin or relationship does not exist
                }
                catch (RequestFailedException ex)
                {
                    FatalError($"Failed to delete {twin.Key} due to {ex.Message}");
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
                    #region Snippet:DigitalTwinsSampleCreateTwin

                    Response<string> response = await DigitalTwinsClient.CreateDigitalTwinAsync(twin.Key, twin.Value).ConfigureAwait(false);

                    #endregion Snippet:DigitalTwinsSampleCreateTwin

                    Console.WriteLine($"Created digital twin {twin.Key}. Create response status: {response.GetRawResponse().Status}");
                    Console.WriteLine($"Body: {response?.Value}");
                }
                catch (Exception ex)
                {
                    FatalError($"Could not create digital twin {twin.Key} due to {ex}");
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
                AsyncPageable<string> asyncPageableResponse = DigitalTwinsClient.QueryAsync("SELECT * FROM digitaltwins");

                // Iterate over the twin instances in the pageable response.
                // The "await" keyword here is required because new pages will be fetched when necessary,
                // which involves a request to the service.
                await foreach (string response in asyncPageableResponse)
                {
                    BasicDigitalTwin twin = JsonSerializer.Deserialize<BasicDigitalTwin>(response);
                    Console.WriteLine($"Found digital twin: {twin.Id}");
                }

                #endregion Snippet:DigitalTwinsSampleQueryTwins

                Console.WriteLine("Making a twin query, with query-charge header extraction.");

                #region Snippet:DigitalTwinsSampleQueryTwinsWithQueryCharge

                // This code snippet demonstrates how you could extract the query charges incurred when calling
                // the query API. It iterates over the response pages first to access to the query-charge header,
                // and then the digital twin results within each page.

                AsyncPageable<string> asyncPageableResponseWithCharge = DigitalTwinsClient.QueryAsync("SELECT * FROM digitaltwins");
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
                        Console.WriteLine($"Found digital twin: {twin.Id}");
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

                foreach (BasicRelationship relationship in relationships)
                {
                    try
                    {
                        #region Snippet:DigitalTwinsSampleCreateRelationship

                        string serializedRelationship = JsonSerializer.Serialize(relationship);

                        await DigitalTwinsClient
                            .CreateRelationshipAsync(
                                relationship.SourceId,
                                relationship.Id,
                                serializedRelationship)
                            .ConfigureAwait(false);

                        #endregion Snippet:DigitalTwinsSampleCreateRelationship

                        Console.WriteLine($"Linked {serializedRelationship}");
                    }
                    catch (RequestFailedException ex) when (ex.Status == (int)HttpStatusCode.Conflict)
                    {
                        Console.WriteLine($"Relationship {relationship.Id} already exists: {ex.Message}");
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

                AsyncPageable<EventRoute> response = DigitalTwinsClient.GetEventRoutesAsync();
                await foreach (EventRoute er in response)
                {
                    Console.WriteLine($"Event route: {er.Id}, endpoint name: {er.EndpointName}");
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
                var eventRoute = new EventRoute(_eventhubEndpointName)
                {
                    Filter = eventFilter
                };

                Response createEventRouteResponse = await DigitalTwinsClient.CreateEventRouteAsync(_eventRouteId, eventRoute).ConfigureAwait(false);

                #endregion Snippet:DigitalTwinsSampleCreateEventRoute

                Console.WriteLine($"Created event route: {_eventRouteId} Response status: {createEventRouteResponse.Status}");
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

                Response response = await DigitalTwinsClient.DeleteEventRouteAsync(_eventRouteId).ConfigureAwait(false);

                #endregion Snippet:DigitalTwinsSampleDeleteEventRoute

                Console.WriteLine($"Successfully deleted event route: {_eventRouteId}, status: {response.Status}");
            }
            catch (Exception ex)
            {
                FatalError($"Could not delete event routes due to {ex.Message}");
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
