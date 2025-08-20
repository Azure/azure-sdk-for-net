// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests
{
    public class Sample_Connections : SamplesBase<AIProjectsTestEnvironment>
    {
        [Test]
        [SyncOnly]
        public void ConnectionsExample()
        {
            #region Snippet:AI_Projects_ConnectionsExampleSync
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
            var specificConnection = connectionsClient.Get(connectionName, includeCredentials: false);
            Console.WriteLine(specificConnection);

            Console.WriteLine("Get the properties of a connection with credentials:");
            var specificConnectionCredentials = connectionsClient.Get(connectionName, includeCredentials: true);
            Console.WriteLine(specificConnectionCredentials);

            Console.WriteLine($"Get the properties of the default connection:");
            var defaultConnection = connectionsClient.GetDefault(includeCredentials: false);
            Console.WriteLine(defaultConnection);

            Console.WriteLine($"Get the properties of the default connection with credentials:");
            var defaultConnectionCredentials = connectionsClient.GetDefault(includeCredentials: true);
            Console.WriteLine(defaultConnectionCredentials);
            #endregion
        }

        [Test]
        [AsyncOnly]
        public async Task ConnectionsExampleAsync()
        {
            #region Snippet:AI_Projects_ConnectionsExampleAsync
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
            var specificConnection = await connectionsClient.GetAsync(connectionName, includeCredentials: false);
            Console.WriteLine(specificConnection);

            Console.WriteLine("Get the properties of a connection with credentials:");
            var specificConnectionCredentials = await connectionsClient.GetAsync(connectionName, includeCredentials: true);
            Console.WriteLine(specificConnectionCredentials);

            Console.WriteLine($"Get the properties of the default connection:");
            var defaultConnection = await connectionsClient.GetDefaultAsync(includeCredentials: false);
            Console.WriteLine(defaultConnection);

            Console.WriteLine($"Get the properties of the default connection with credentials:");
            var defaultConnectionCredentials = await connectionsClient.GetDefaultAsync(includeCredentials: true);
            Console.WriteLine(defaultConnectionCredentials);
            #endregion
        }
    }
}
