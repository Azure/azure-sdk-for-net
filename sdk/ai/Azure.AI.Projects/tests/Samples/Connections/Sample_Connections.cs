// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;
using System.ClientModel.Primitives;
using System.Diagnostics;
using System.Collections.Generic;

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
            foreach (ConnectionProperties connection in projectClient.Connections.GetConnections())
            {
                Console.WriteLine(connection);
                Console.WriteLine(connection.Name);
            }

            Console.WriteLine("List the properties of all connections of a particular type (e.g., Azure OpenAI connections):");
            foreach (ConnectionProperties connection in projectClient.Connections.GetConnections(connectionType: ConnectionType.AzureOpenAI))
            {
                Console.WriteLine(connection);
            }

            Console.WriteLine($"Get the properties of a connection named `{connectionName}`:");
            ConnectionProperties specificConnection = projectClient.Connections.GetConnection(connectionName, includeCredentials: false);
            Console.WriteLine(specificConnection);

            Console.WriteLine("Get the properties of a connection with credentials:");
            ConnectionProperties specificConnectionCredentials = projectClient.Connections.GetConnection(connectionName, includeCredentials: true);
            Console.WriteLine(specificConnectionCredentials);

            Console.WriteLine($"Get the properties of the default connection:");
            ConnectionProperties defaultConnection = projectClient.Connections.GetDefaultConnection(includeCredentials: false);
            Console.WriteLine(defaultConnection);

            Console.WriteLine($"Get the properties of the default connection with credentials:");
            ConnectionProperties defaultConnectionCredentials = projectClient.Connections.GetDefaultConnection(includeCredentials: true);
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
            await foreach (ConnectionProperties connection in projectClient.Connections.GetConnectionsAsync())
            {
                Console.WriteLine(connection);
                Console.Write(connection.Name);
            }

            Console.WriteLine("List the properties of all connections of a particular type (e.g., Azure OpenAI connections):");
            await foreach (ConnectionProperties connection in projectClient.Connections.GetConnectionsAsync(connectionType: ConnectionType.AzureOpenAI))
            {
                Console.WriteLine(connection);
            }

            Console.WriteLine($"Get the properties of a connection named `{connectionName}`:");
            ConnectionProperties specificConnection = await projectClient.Connections.GetConnectionAsync(connectionName, includeCredentials: false);
            Console.WriteLine(specificConnection);

            Console.WriteLine("Get the properties of a connection with credentials:");
            ConnectionProperties specificConnectionCredentials = await projectClient.Connections.GetConnectionAsync(connectionName, includeCredentials: true);
            Console.WriteLine(specificConnectionCredentials);

            Console.WriteLine($"Get the properties of the default connection:");
            ConnectionProperties defaultConnection = await projectClient.Connections.GetDefaultConnectionAsync(includeCredentials: false);
            Console.WriteLine(defaultConnection);

            Console.WriteLine($"Get the properties of the default connection with credentials:");
            ConnectionProperties defaultConnectionCredentials = await projectClient.Connections.GetDefaultConnectionAsync(includeCredentials: true);
            Console.WriteLine(defaultConnectionCredentials);
            #endregion
        }
    }
}
