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
using Azure.Identity;
using NUnit.Framework.Internal;
using Azure.AI.Projects.Tests.Utils;

namespace Azure.AI.Projects.Tests
{
    public class ConnectionsTest : ProjectsClientTestBase
    {
        public ConnectionsTest(bool isAsync) : base(isAsync)
        {
        }

        [RecordedTest]
        public async Task ConnectionsBasicTest()
        {
            var connectionName = TestEnvironment.CONNECTIONNAME;
            var connectionType = TestEnvironment.CONNECTIONTYPE;

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
            foreach (ConnectionProperties connection in projectClient.Connections.GetConnections())
            {
                isEmpty = false;
                ValidateConnection(connection, false);
                Console.WriteLine(connection);
            }
            Assert.IsFalse(isEmpty, "Expected at least one connection to be returned.");

            Console.WriteLine("List the properties of all connections of a particular type (e.g., Azure OpenAI connections):");
            isEmpty = true;
            foreach (ConnectionProperties connection in projectClient.Connections.GetConnections(connectionType: connectionType))
            {
                isEmpty = false;
                ValidateConnection(connection, false, expectedConnectionType: connectionType);
            }
            Assert.IsFalse(isEmpty, "Expected at least one connection of type to be returned.");

            Console.WriteLine($"Get the properties of a connection named `{connectionName}`:");
            ConnectionProperties specificConnection = projectClient.Connections.GetConnection(connectionName, includeCredentials: false);
            ValidateConnection(specificConnection, false, expectedConnectionName: connectionName);

            Console.WriteLine("Get the properties of a connection with credentials:");
            ConnectionProperties specificConnectionCredentials = projectClient.Connections.GetConnection(connectionName, includeCredentials: true);
            ValidateConnection(specificConnectionCredentials, true, expectedConnectionName: connectionName);

            Console.WriteLine($"Get the properties of the default connection:");
            ConnectionProperties defaultConnection = projectClient.Connections.GetDefaultConnection(connectionType: connectionType, includeCredentials: false);
            ValidateConnection(defaultConnection, false);

            Console.WriteLine($"Get the properties of the default connection with credentials:");
            ConnectionProperties defaultConnectionCredentials = projectClient.Connections.GetDefaultConnection(connectionType: connectionType, includeCredentials: true);
            ValidateConnection(defaultConnectionCredentials, true);
        }

        private async Task ConnectionsTestAsync(AIProjectClient projectClient, string connectionName, string connectionType)
        {
            Console.WriteLine("List the properties of all connections:");
            bool isEmpty = true;
            await foreach (ConnectionProperties connection in projectClient.Connections.GetConnectionsAsync())
            {
                isEmpty = false;
                ValidateConnection(connection, false);
                Console.WriteLine(connection);
            }
            Assert.IsFalse(isEmpty, "Expected at least one connection to be returned.");

            Console.WriteLine("List the properties of all connections of a particular type (e.g., Azure OpenAI connections):");
            isEmpty = true;
            await foreach (ConnectionProperties connection in projectClient.Connections.GetConnectionsAsync(connectionType: connectionType))
            {
                isEmpty = false;
                ValidateConnection(connection, false, expectedConnectionType: connectionType);
            }
            Assert.IsFalse(isEmpty, "Expected at least one connection of type to be returned.");

            Console.WriteLine($"Get the properties of a connection named `{connectionName}`:");
            ConnectionProperties specificConnection = await projectClient.Connections.GetConnectionAsync(connectionName, includeCredentials: false);
            ValidateConnection(specificConnection, false, expectedConnectionName: connectionName);

            Console.WriteLine("Get the properties of a connection with credentials:");
            ConnectionProperties specificConnectionCredentials = await projectClient.Connections.GetConnectionAsync(connectionName, includeCredentials: true);
            ValidateConnection(specificConnectionCredentials, true, expectedConnectionName: connectionName);

            Console.WriteLine($"Get the properties of the default connection:");
            ConnectionProperties defaultConnection = await projectClient.Connections.GetDefaultConnectionAsync(connectionType: connectionType, includeCredentials: false);
            ValidateConnection(defaultConnection, false);

            Console.WriteLine($"Get the properties of the default connection with credentials:");
            ConnectionProperties defaultConnectionCredentials = await projectClient.Connections.GetDefaultConnectionAsync(connectionType: connectionType, includeCredentials: true);
            ValidateConnection(defaultConnectionCredentials, true);
        }
    }
}
