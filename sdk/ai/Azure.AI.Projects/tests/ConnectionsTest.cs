// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#nullable disable

using System;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.AI.Projects.Tests
{
    public class ConnectionsTest : ProjectsClientTestBase
    {
        public ConnectionsTest(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        [Ignore("Pending 2.* investigation")]
        public async Task ConnectionsBasicTest()
        {
            var connectionName = TestEnvironment.STORAGECONNECTIONNAME;
            var connectionType = TestEnvironment.STORAGECONNECTIONTYPE;

            AIProjectClient projectClient = GetTestClient();
            if (IsAsync)
            {
                await ConnectionsTestAsync(projectClient, connectionName, connectionType);
            }
            else
            {
                ConnectionsTestSync(projectClient, connectionName, connectionType);
            }
        }

        private void ConnectionsTestSync(AIProjectClient projectClient, string connectionName, string connectionType)
        {
            Console.WriteLine("List the properties of all connections:");
            bool isEmpty = true;
            foreach (AIProjectConnection connection in projectClient.Connections.GetConnections())
            {
                isEmpty = false;
                ValidateConnection(connection, false);
                Console.WriteLine(connection);
            }
            Assert.IsFalse(isEmpty, "Expected at least one connection to be returned.");

            Console.WriteLine("List the properties of all connections of a particular type (e.g., Azure OpenAI connections):");
            isEmpty = true;
            foreach (AIProjectConnection connection in projectClient.Connections.GetConnections(connectionType: connectionType))
            {
                isEmpty = false;
                ValidateConnection(connection, false, expectedConnectionType: connectionType);
            }
            Assert.IsFalse(isEmpty, "Expected at least one connection of type to be returned.");

            Console.WriteLine($"Get the properties of a connection named `{connectionName}`:");
            AIProjectConnection specificConnection = projectClient.Connections.GetConnection(connectionName, includeCredentials: false);
            ValidateConnection(specificConnection, false, expectedConnectionName: connectionName);

            Console.WriteLine("Get the properties of a connection with credentials:");
            AIProjectConnection specificConnectionCredentials = projectClient.Connections.GetConnection(connectionName, includeCredentials: true);
            ValidateConnection(specificConnectionCredentials, true, expectedConnectionName: connectionName);

            Console.WriteLine($"Get the properties of the default connection:");
            AIProjectConnection defaultConnection = projectClient.Connections.GetDefaultConnection(connectionType: connectionType, includeCredentials: false);
            ValidateConnection(defaultConnection, false);

            Console.WriteLine($"Get the properties of the default connection with credentials:");
            AIProjectConnection defaultConnectionCredentials = projectClient.Connections.GetDefaultConnection(connectionType: connectionType, includeCredentials: true);
            ValidateConnection(defaultConnectionCredentials, true);
        }

        private async Task ConnectionsTestAsync(AIProjectClient projectClient, string connectionName, string connectionType)
        {
            Console.WriteLine("List the properties of all connections:");
            bool isEmpty = true;
            await foreach (AIProjectConnection connection in projectClient.Connections.GetConnectionsAsync())
            {
                isEmpty = false;
                ValidateConnection(connection, false);
                Console.WriteLine(connection);
            }
            Assert.IsFalse(isEmpty, "Expected at least one connection to be returned.");

            Console.WriteLine("List the properties of all connections of a particular type (e.g., Azure OpenAI connections):");
            isEmpty = true;
            await foreach (AIProjectConnection connection in projectClient.Connections.GetConnectionsAsync(connectionType: connectionType))
            {
                isEmpty = false;
                ValidateConnection(connection, false, expectedConnectionType: connectionType);
            }
            Assert.IsFalse(isEmpty, "Expected at least one connection of type to be returned.");

            Console.WriteLine($"Get the properties of a connection named `{connectionName}`:");
            AIProjectConnection specificConnection = await projectClient.Connections.GetConnectionAsync(connectionName, includeCredentials: false);
            ValidateConnection(specificConnection, false, expectedConnectionName: connectionName);

            Console.WriteLine("Get the properties of a connection with credentials:");
            AIProjectConnection specificConnectionCredentials = await projectClient.Connections.GetConnectionAsync(connectionName, includeCredentials: true);
            ValidateConnection(specificConnectionCredentials, true, expectedConnectionName: connectionName);

            Console.WriteLine($"Get the properties of the default connection:");
            AIProjectConnection defaultConnection = await projectClient.Connections.GetDefaultConnectionAsync(connectionType: connectionType, includeCredentials: false);
            ValidateConnection(defaultConnection, false);

            Console.WriteLine($"Get the properties of the default connection with credentials:");
            AIProjectConnection defaultConnectionCredentials = await projectClient.Connections.GetDefaultConnectionAsync(connectionType: connectionType, includeCredentials: true);
            ValidateConnection(defaultConnectionCredentials, true);
        }
    }
}
