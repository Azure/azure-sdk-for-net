// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.ClientModel.Primitives;
using System.Collections.Generic;
using Azure.Core;
using Azure.Identity;

namespace Azure.AI.Projects
{
    // Data plane generated client.
    /// <summary> The AzureAI service client. </summary>
    public partial class AIProjectClient : ConnectionProvider
    {
        private readonly ConnectionCacheManager _cacheManager;
        private readonly ConnectionsClient _connectionsClient;

        /// <summary> Initializes a new instance of AzureAIClient. </summary>
        /// <param name="connectionString">The Azure AI Foundry project connection string, in the form `endpoint;subscription_id;resource_group_name;project_name`.</param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionString"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="connectionString"/> </exception>
        public AIProjectClient(string connectionString, TokenCredential credential = null) : this(connectionString, BuildCredential(credential), new AIProjectClientOptions())
        {
            _connectionsClient = new ConnectionsClient(connectionString, _tokenCredential);
            _cacheManager = new ConnectionCacheManager(_connectionsClient, _tokenCredential);
        }

        /// <summary>
        /// Initializes a new instance of AzureAIClient.
        /// </summary>
        /// <param name="connectionString">The Azure AI Foundry project connection string, in the form `endpoint;subscription_id;resource_group_name;project_name`.</param>
        /// <param name="credential"> A credential used to authenticate to an Azure Service. </param>
        /// <param name="options"> The options for configuring the client. </param>
        /// <exception cref="ArgumentNullException"> <paramref name="connectionString"/> is null. </exception>
        /// <exception cref="ArgumentException"> <paramref name="connectionString"/> is an empty string. </exception>
        public AIProjectClient(string connectionString, TokenCredential credential, AIProjectClientOptions options)
             : this(new Uri(ClientHelper.ParseConnectionString(connectionString, "endpoint")),
                  ClientHelper.ParseConnectionString(connectionString, "subscriptionId"),
                  ClientHelper.ParseConnectionString(connectionString, "ResourceGroupName"),
                  ClientHelper.ParseConnectionString(connectionString, "ProjectName"),
                  credential,
                  options)
        {
        }

        /// <summary>
        /// Retrieves the connection options for a specified client type and instance ID.
        /// </summary>
        public override ClientConnection GetConnection(string connectionId) => _cacheManager.GetConnection(connectionId);

        /// <summary>
        /// Retrieves all connection options.
        /// </summary>
        public override IEnumerable<ClientConnection> GetAllConnections() => _cacheManager.GetAllConnections();

        private static TokenCredential BuildCredential(TokenCredential credential)
        {
            if (credential != null)
            {
                return credential;
            }

            string clientId = Environment.GetEnvironmentVariable("CLOUDMACHINE_MANAGED_IDENTITY_CLIENT_ID");

            return !string.IsNullOrEmpty(clientId)
                ? new ManagedIdentityCredential(clientId)
                : new ChainedTokenCredential(new AzureCliCredential(), new AzureDeveloperCliCredential());
        }
    }
}
