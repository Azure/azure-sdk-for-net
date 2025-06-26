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

            Console.WriteLine("List the properties of all connections:");
            foreach (Connection connection in projectClient.Connections.GetConnections())
            {
                Console.WriteLine(connection);
                Console.Write(connection.Name);
            }

            Console.WriteLine("List the properties of all connections of a particular type (e.g., Azure OpenAI connections):");
            foreach (Connection connection in projectClient.Connections.GetConnections(connectionType: ConnectionType.AzureOpenAI))
            {
                Console.WriteLine(connection);
            }

            Console.WriteLine($"Get the properties of a connection named `{connectionName}`:");
            Connection specificConnection = projectClient.Connections.Get(connectionName, includeCredentials: false);
            Console.WriteLine(specificConnection);

            Console.WriteLine("Get the properties of a connection with credentials:");
            Connection specificConnectionCredentials = projectClient.Connections.Get(connectionName, includeCredentials: true);
            Console.WriteLine(specificConnectionCredentials);

            Console.WriteLine($"Get the properties of the default connection:");
            Connection defaultConnection = projectClient.Connections.GetDefault(includeCredentials: false);
            Console.WriteLine(defaultConnection);

            Console.WriteLine($"Get the properties of the default connection with credentials:");
            Connection defaultConnectionCredentials = projectClient.Connections.GetDefault(includeCredentials: true);
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

            Console.WriteLine("List the properties of all connections:");
            await foreach (Connection connection in projectClient.Connections.GetConnectionsAsync())
            {
                Console.WriteLine(connection);
                Console.Write(connection.Name);
            }

            Console.WriteLine("List the properties of all connections of a particular type (e.g., Azure OpenAI connections):");
            await foreach (Connection connection in projectClient.Connections.GetConnectionsAsync(connectionType: ConnectionType.AzureOpenAI))
            {
                Console.WriteLine(connection);
            }

            Console.WriteLine($"Get the properties of a connection named `{connectionName}`:");
            Connection specificConnection = await projectClient.Connections.GetAsync(connectionName, includeCredentials: false);
            Console.WriteLine(specificConnection);

            Console.WriteLine("Get the properties of a connection with credentials:");
            Connection specificConnectionCredentials = await projectClient.Connections.GetAsync(connectionName, includeCredentials: true);
            Console.WriteLine(specificConnectionCredentials);

            Console.WriteLine($"Get the properties of the default connection:");
            Connection defaultConnection = await projectClient.Connections.GetDefaultAsync(includeCredentials: false);
            Console.WriteLine(defaultConnection);

            Console.WriteLine($"Get the properties of the default connection with credentials:");
            Connection defaultConnectionCredentials = await projectClient.Connections.GetDefaultAsync(includeCredentials: true);
            Console.WriteLine(defaultConnectionCredentials);
            #endregion
        }
    }
}
