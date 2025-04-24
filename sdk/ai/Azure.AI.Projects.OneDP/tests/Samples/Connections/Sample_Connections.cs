// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.AI.Projects;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.OneDP.Tests
{
    public class Sample_Connections : SamplesBase<AIProjectsTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void ConnectionsExample()
        {
            #region Snippet:ConnectionsExampleSync
#if SNIPPET
            var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
            var connectionName = Environment.GetEnvironmentVariable("CONNECTION_NAME");
#else
            var endpoint = TestEnvironment.PROJECTENDPOINT;
            var connectionName = TestEnvironment.CONNECTIONNAME;
#endif
            AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
            Connections connectionsClient = projectClient.GetConnectionsClient();

            Console.WriteLine("List the properties of all connections:");
            foreach (var connection in connectionsClient.GetConnections())
            {
                Console.WriteLine(connection);
                Console.Write(connection.Name);
            }

            Console.WriteLine("List the properties of all connections of a particular type (e.g., Azure OpenAI connections):");
            foreach (var connection in connectionsClient.GetConnections(connectionType: ConnectionType.AzureOpenAI))
            {
                Console.WriteLine(connection);
            }

            Console.WriteLine($"Get the properties of a connection named `{connectionName}`:");
            var specificConnection = connectionsClient.GetConnection(connectionName);
            Console.WriteLine(specificConnection);

            Console.WriteLine("Get the properties of a connection with credentials:");
            var specificConnectionCredentials = connectionsClient.GetWithCredentials(connectionName);
            Console.WriteLine(specificConnectionCredentials);

            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task ConnectionsExampleAsync()
        {
            #region Snippet:ConnectionsExampleAsync
#if SNIPPET
            var endpoint = Environment.GetEnvironmentVariable("PROJECT_ENDPOINT");
            var connectionName = Environment.GetEnvironmentVariable("CONNECTION_NAME");
#else
            var endpoint = TestEnvironment.PROJECTENDPOINT;
            var connectionName = TestEnvironment.CONNECTIONNAME;
#endif
            AIProjectClient projectClient = new(new Uri(endpoint), new DefaultAzureCredential());
            Connections connectionsClient = projectClient.GetConnectionsClient();

            Console.WriteLine("List the properties of all connections:");
            await foreach (var connection in connectionsClient.GetConnectionsAsync())
            {
                Console.WriteLine(connection);
                Console.Write(connection.Name);
            }

            Console.WriteLine("List the properties of all connections of a particular type (e.g., Azure OpenAI connections):");
            await foreach (var connection in connectionsClient.GetConnectionsAsync(connectionType: ConnectionType.AzureOpenAI))
            {
                Console.WriteLine(connection);
            }

            Console.WriteLine($"Get the properties of a connection named `{connectionName}`:");
            var specificConnection = await connectionsClient.GetConnectionAsync(connectionName);
            Console.WriteLine(specificConnection);

            Console.WriteLine("Get the properties of a connection with credentials:");
            var specificConnectionCredentials = await connectionsClient.GetWithCredentialsAsync(connectionName);
            Console.WriteLine(specificConnectionCredentials);

            #endregion
        }
    }
}
