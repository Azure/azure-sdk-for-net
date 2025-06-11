// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Linq;
using Azure;
using Azure.Core;
using Azure.AI.Projects;
using System.Threading.Tasks;

namespace Azure.AI.Projects
{
    public partial class AIProjectClient
    {
        private Telemetry _telemetry;
        public Telemetry Telemetry => _telemetry ??= new Telemetry(this);
    }
    /// <summary>
    /// Provides telemetry-related operations for the project.
    /// </summary>
    public partial class Telemetry
    {
        private readonly AIProjectClient _outerInstance;
        private string _connectionString;

        /// <summary>
        /// Initializes a new instance of the <see cref="Telemetry"/> class.
        /// </summary>
        /// <param name="outerInstance">The parent AIProjectClient instance.</param>
        public Telemetry(AIProjectClient outerInstance)
        {
            _outerInstance = outerInstance;
        }

        /// <summary>
        /// Gets the Application Insights connection string associated with the Project's Application Insights resource.
        /// </summary>
        /// <returns>The Application Insights connection string if the resource was enabled for the Project.</returns>
        /// <exception cref="RequestFailedException">Thrown if an Application Insights connection does not exist for this project.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the connection does not use API Key credentials or the API key is missing.</exception>
        public string GetConnectionString()
        {
            if (_connectionString == null)
            {
                Connections connectionsClient = _outerInstance.GetConnectionsClient();
                Connection connection = connectionsClient.GetDefault(ConnectionType.ApplicationInsights, includeCredentials: true);
                if (connection == null)
                {
                    throw new RequestFailedException("No Application Insights connection found.");
                }
                if (connection.Credentials is ApiKeyCredentials apiKeyCreds)
                {
                    if (string.IsNullOrEmpty(apiKeyCreds.ApiKey))
                    {
                        throw new InvalidOperationException("Application Insights connection does not have a connection string.");
                    }
                    _connectionString = apiKeyCreds.ApiKey;
                }
                else
                {
                    throw new InvalidOperationException("Application Insights connection does not use API Key credentials.");
                }
            }
            return _connectionString;
        }

        /// <summary>
        /// Gets the Application Insights connection string associated with the Project's Application Insights resource.
        /// </summary>
        /// <returns>The Application Insights connection string if the resource was enabled for the Project.</returns>
        /// <exception cref="RequestFailedException">Thrown if an Application Insights connection does not exist for this project.</exception>
        /// <exception cref="InvalidOperationException">Thrown if the connection does not use API Key credentials or the API key is missing.</exception>
        public async Task<string> GetConnectionStringAsync()
        {
            if (_connectionString == null)
            {
                Connections connectionsClient = _outerInstance.GetConnectionsClient();
                Connection connection = await connectionsClient.GetDefaultAsync(ConnectionType.ApplicationInsights, includeCredentials: true).ConfigureAwait(false);
                if (connection == null)
                {
                    throw new RequestFailedException("No Application Insights connection found.");
                }
                if (connection.Credentials is ApiKeyCredentials apiKeyCreds)
                {
                    if (string.IsNullOrEmpty(apiKeyCreds.ApiKey))
                    {
                        throw new InvalidOperationException("Application Insights connection does not have a connection string.");
                    }
                    _connectionString = apiKeyCreds.ApiKey;
                }
                else
                {
                    throw new InvalidOperationException("Application Insights connection does not use API Key credentials.");
                }
            }
            return _connectionString;
        }
    }
}
