// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.AI.AgentServer.Activity.Internal;
using NUnit.Framework;

namespace Azure.AI.AgentServer.Activity.Tests;

[TestFixture]
public class ConnectionEnvironmentTests
{
    [Test]
    public void FoundryInputConstants_HaveExpectedNames()
    {
        Assert.Multiple(() =>
        {
            Assert.That(ConnectionEnvironment.FoundryBlueprintClientId, Is.EqualTo("FOUNDRY_AGENT_BLUEPRINT_CLIENT_ID"));
            Assert.That(ConnectionEnvironment.FoundryInstanceClientId, Is.EqualTo("FOUNDRY_AGENT_INSTANCE_CLIENT_ID"));
            Assert.That(ConnectionEnvironment.FoundryTenantId, Is.EqualTo("FOUNDRY_AGENT_TENANT_ID"));
        });
    }

    [Test]
    public void M365ConnectionKeys_HaveExpectedNames()
    {
        Assert.Multiple(() =>
        {
            Assert.That(ConnectionEnvironment.AuthType, Is.EqualTo("CONNECTIONS:SERVICE_CONNECTION:SETTINGS:AUTHTYPE"));
            Assert.That(ConnectionEnvironment.ClientId, Is.EqualTo("CONNECTIONS:SERVICE_CONNECTION:SETTINGS:CLIENTID"));
            Assert.That(ConnectionEnvironment.TenantId, Is.EqualTo("CONNECTIONS:SERVICE_CONNECTION:SETTINGS:TENANTID"));
            Assert.That(ConnectionEnvironment.Scope0, Is.EqualTo("CONNECTIONS:SERVICE_CONNECTION:SETTINGS:SCOPES:0"));
            Assert.That(ConnectionEnvironment.Authority, Is.EqualTo("CONNECTIONS:SERVICE_CONNECTION:SETTINGS:AUTHORITY"));
            Assert.That(ConnectionEnvironment.ConnectionMapServiceUrl, Is.EqualTo("CONNECTIONSMAP:0:SERVICEURL"));
            Assert.That(ConnectionEnvironment.ConnectionMapConnection, Is.EqualTo("CONNECTIONSMAP:0:CONNECTION"));
        });
    }

    [Test]
    public void DefaultValues_AreExpected()
    {
        Assert.Multiple(() =>
        {
            Assert.That(ConnectionEnvironment.DefaultAuthType, Is.EqualTo("UserManagedIdentity"));
            Assert.That(ConnectionEnvironment.DefaultServiceUrl, Is.EqualTo("*"));
            Assert.That(ConnectionEnvironment.DefaultConnectionName, Is.EqualTo("SERVICE_CONNECTION"));
        });
    }

    [Test]
    public void Scopes_AreExpected()
    {
        Assert.Multiple(() =>
        {
            Assert.That(ConnectionEnvironment.BotConnectorScope, Is.EqualTo("https://api.botframework.com/.default"));
            Assert.That(ConnectionEnvironment.DigitalWorkerScope, Is.EqualTo("5a807f24-c9de-44ee-a3a7-329e88a00ffc/.default"));
            Assert.That(ConnectionEnvironment.LoginAuthorityBase, Is.EqualTo("https://login.microsoftonline.com/"));
        });
    }

    [Test]
    public void AuthorityFor_BuildsAuthorityUrl()
    {
        var result = ConnectionEnvironment.AuthorityFor("my-tenant-id");

        Assert.That(result, Is.EqualTo("https://login.microsoftonline.com/my-tenant-id"));
    }
}
