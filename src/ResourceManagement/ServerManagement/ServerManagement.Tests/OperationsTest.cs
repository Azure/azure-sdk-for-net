// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Management.ServerManagement;
using Microsoft.Azure.Management.ServerManagement.Models;
using Microsoft.Rest;
using Microsoft.Rest.Azure;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using Xunit.Abstractions;

namespace ServerManagement.Tests
{
    public class OperationsTest : ServerManagementTestBase
    {
        public OperationsTest(ITestOutputHelper output) : base(output)
        {
        }

        private async Task RunPowerShellCommand(ServerManagementClient client, NodeResource node,
            SessionResource session,
            PowerShellSessionResource ps)
        {
            // run a command
            var result =
                await
                    client.PowerShell.InvokeCommandAsync(ResourceGroup,
                        node.Name,
                        session.Name,
                        ps.SessionId,
                        "dir c:\\");
            Assert.NotNull(result);

            // did the command complete successfully?t
            Assert.True(result.Completed);

            // did we get some results?
            var found = false;
            foreach (var r in result.Results)
            {
                found = true;
                WriteLine(string.Format(" {0}", r.ToJson()));
            }
            Assert.True(found);
        }

        private async Task RunLongPowerShellCommand(ServerManagementClient client, NodeResource node,
            SessionResource session,
            PowerShellSessionResource ps)
        {
            // run a command
            var result = await client.PowerShell.InvokeCommandAsync(ResourceGroup,
                node.Name,
                session.Name,
                ps.SessionId,
                "dir c:\\ ; sleep 20 ; dir c:\\windows");
            Assert.NotNull(result);

            // this should return false because 20 seconds is too long...
            // did the command complete successfully?
            Assert.False(result.Completed);

            // did we get some results?
            var found = false;
            foreach (var r in result.Results)
            {
                found = true;
                WriteLine(string.Format(" {0}", r.ToJson()));
            }
            Assert.True(found);

            PowerShellCommandStatus more;
            found = false;
            // go back for some more results.
            do
            {
                more = await client.PowerShell.GetCommandStatusAsync(ResourceGroup,
                    node.Name,
                    session.Name,
                    ps.SessionId,
                    PowerShellExpandOption.Output);

                foreach (var r in more.Results)
                {
                    found = true;
                    WriteLine(string.Format(" {0}", r.ToJson()));
                }
            } while (!(more.Completed ?? false));
            Assert.True(found);
            Assert.True(more.Completed);
        }

        private async Task ListPowerShellSessions(ServerManagementClient client, NodeResource node,
            SessionResource session)
        {
            bool found;
            // list the powershell sessions open
            var sessions = await client.PowerShell.ListSessionAsync(ResourceGroup, node.Name, session.Name);
            Assert.NotNull(sessions);
            found = false;
            foreach (var s in sessions.Value)
            {
                found = true;
                WriteLine(string.Format(" {0}", s.ToJson()));
            }
            Assert.True(found);
        }

        private async Task<IPage<NodeResource>> ListNodesInSubscription(ServerManagementClient client)
        {
            // look at all the nodes in the subscription
            var nodes = await client.Node.ListAsync();
            Assert.NotNull(nodes);

            var found = false;
            foreach (var n in nodes)
            {
                found = true;
                WriteLine(string.Format("Found node in subscription: {0}", n.Name));
            }

            // make sure we got *some* back.
            Assert.True(found, "No nodes in collection");
            return nodes;
        }

        private static async Task<NodeResource> CreateNode(ServerManagementClient client, GatewayResource gateway)
        {
            var node = await client.Node.CreateAsync(
                ResourceGroup,
                NodeName,
                connectionName: NodeName,
                gatewayId: gateway.Id,
                location: Location,
                userName: NodeUserName,
                password: NodePassword
                );
            Assert.NotNull(node);
            return node;
        }

        private async Task<GatewayResource> CreateAndConfigureGateway(ServerManagementClient client, string GatewayName)
        {
            GatewayResource gateway;
            // create a gateway
            gateway = await client.Gateway.CreateAsync(
                ResourceGroup,
                GatewayName,
                autoUpgrade: AutoUpgrade.Off,
                location: Location
                );
            Assert.NotNull(gateway);

            WriteLine(string.Format("Created Gateway: {0}", gateway.Name));

            var profile = await client.Gateway.GetProfileAsync(ResourceGroup, GatewayName);

            if (TestingInteractively)
            {
                // stop the service
                StopGateway();

                // install the new profile
                WriteLine(string.Format("Profile:\r\n{0}", profile.ToJson()));
                var encrypted = ProtectedData.Protect(Encoding.UTF8.GetBytes(profile.ToJsonTight()),
                    null,
                    DataProtectionScope.LocalMachine);
                var path = Environment.ExpandEnvironmentVariables(@"%PROGRAMDATA%") + @"\ManagementGateway";
                Directory.CreateDirectory(path);
                File.WriteAllBytes(path + @"\GatewayProfile.json", encrypted);

                // start the service.
                StartGateway();

                // wait for service to initialize itself.
                Task.Delay(180 * 1000).Wait();
            }
            Assert.NotNull(gateway);

            return gateway;
        }

        private async Task GetTabCompletionResults(ServerManagementClient client, NodeResource node,
            SessionResource session,
            PowerShellSessionResource ps)
        {
            bool found;
            // try to get tab command completion
            var results = await client.PowerShell.TabCompletionAsync(ResourceGroup,
                node.Name,
                session.Name,
                ps.SessionId,
                "dir c:\\");
            Assert.NotNull(results);
            found = false;
            foreach (var s in results.Results)
            {
                found = true;
                WriteLine(string.Format(" {0}", s.ToJson()));
            }
            Assert.True(found);
        }

        [Fact]
        public async Task CreateGatewayFailTest()
        {
            // ensure known state before starting.
            await EnsurePrerequisites();

            using (var context = MockContext.Start("ServerManagement.Tests"))
            {
                var client = GetServerManagementClient(context);

                // try an empty string for name
                await Assert.ThrowsAsync<ValidationException>(() => client.Gateway.CreateAsync(ResourceGroup, ""));

                // try a non existent resource group
                await Assert.ThrowsAsync<ErrorException>(
                    () => client.Gateway.CreateAsync("mary had a little lamb", "testgateway"));

                // try a bad location
                await Assert.ThrowsAsync<ErrorException>(
                    () => client.Gateway.CreateAsync(ResourceGroup, "testgateway", "neverneverland"));
            }
        }

        [Fact]
        public async Task GatewayTest()
        {
            // ensure known state before starting.
            await EnsurePrerequisites();

            using (var context = MockContext.Start("ServerManagement.Tests"))
            {
                var client = GetServerManagementClient(context);

                try
                {
                    // create a gateway
                    var gateway = await client.Gateway.CreateAsync(
                        ResourceGroup,
                        GatewayOne,
                        autoUpgrade: AutoUpgrade.On,
                        location: Location
                        );
                    Assert.NotNull(gateway);
                    Assert.Equal(GatewayOne, gateway.Name);
                    Assert.Equal("microsoft.servermanagement/gateways", gateway.Type);
                    Assert.Equal(Location, gateway.Location);
                    Assert.Equal(AutoUpgrade.On, gateway.AutoUpgrade);
                    WriteLine(gateway.ToJson());

                    // verify that we can get the gateway again.
                    gateway = await client.Gateway.GetAsync(ResourceGroup, GatewayOne);
                    Assert.NotNull(gateway);
                    Assert.Equal(GatewayOne, gateway.Name);
                    Assert.Equal("microsoft.servermanagement/gateways", gateway.Type);
                    Assert.Equal(Location, gateway.Location);
                    Assert.Equal(AutoUpgrade.On, gateway.AutoUpgrade);
                    WriteLine(gateway.ToJson());

                    // update the gateway a bit.
                    gateway = await client.Gateway.UpdateAsync(ResourceGroup,
                        GatewayOne,
                        Location,
                        autoUpgrade: AutoUpgrade.Off);
                    Assert.Equal(AutoUpgrade.Off, gateway.AutoUpgrade);

                    // get the gateway status
                    gateway = await client.Gateway.GetAsync(ResourceGroup, GatewayOne, GatewayExpandOption.Status);
                    Assert.NotNull(gateway);

                    // check for some extended properties
                    Assert.NotNull(gateway.LatestPublishedMsiVersion);
                    Assert.NotNull(gateway.ActiveMessageCount);
                    WriteLine(gateway.ToJson());

                    // Let's see how many gatways are in the subscription
                    var gateways = await client.Gateway.ListAsync();
                    Assert.NotNull(gateways);

                    var found = false;
                    foreach (var g in gateways)
                    {
                        found = true;
                        WriteLine(string.Format("Found Gateway in subscription: {0}", g.Name));
                    }

                    Assert.True(found, "No gateways in collection?");
                }
                finally
                {
                    // remove gateway that we've created 
                    RemoveGateway(client, GatewayOne).Wait();
                }

                // make sure that the gateway is gone.
                await Assert.ThrowsAsync<ErrorException>(() => client.Gateway.GetAsync(ResourceGroup, GatewayOne));
            }
        }

        [Fact]
        public async Task NodeTest()
        {
            // ensure known state before starting.
            await EnsurePrerequisites();

            using (var context = MockContext.Start("ServerManagement.Tests"))
            {
                var client = GetServerManagementClient(context);
                GatewayResource gateway = null;

                if (!ForceResetGatewayProfile)
                {
                    try
                    {
                        gateway = await client.Gateway.GetAsync(ResourceGroup, GatewayTwo);

                        // make sure the gateway service is running.
                        StartGateway();
                    }
                    catch
                    {
                        // if it's not there, we'll create it anyway.
                    }
                }
                try
                {
                    if (gateway == null)
                    {
                        gateway = await CreateAndConfigureGateway(client, GatewayTwo);
                    }

                    WriteLine("Creating Node");
                    var node = await CreateNode(client, gateway);
                    Assert.NotNull(node);

                    // get the same node again
                    WriteLine("Getting Node");
                    node = await client.Node.GetAsync(ResourceGroup, NodeName);
                    Assert.NotNull(node);

                    Assert.Equal(NodeName, node.Name);
                    Assert.Equal(NodeName, node.ConnectionName);

                    // get all the nodes in the subscription
                    WriteLine("Listing Nodes");
                    var nodes = await ListNodesInSubscription(client);

                    // make sure this resource group just has the one node 
                    nodes = await client.Node.ListForResourceGroupAsync(ResourceGroup);
                    Assert.Equal(1, nodes.Count());

                    WriteLine("Creating Session");
                    // Create a session for this node.
                    var session = await client.Session.CreateAsync(ResourceGroup,
                        node.Name,
                        SessionId,
                        NodeUserName,
                        NodePassword);

                    Assert.NotNull(session);
                    Assert.Equal(NodeUserName, session.UserName);

                    // Get the same session again
                    WriteLine("Getting Session");
                    session = await client.Session.GetAsync(ResourceGroup, node.Name, session.Name);
                    Assert.NotNull(session);
                    WriteLine(string.Format("Session/Get response:{0}", session.ToJson()));

                    // create a powershell session inside the SMT session
                    WriteLine("Creating PowerShell Session");
                    var ps = await client.PowerShell.CreateSessionAsync(ResourceGroup,
                        node.Name,
                        session.Name,
                        "00000000-0000-0000-0000-000000000000");
                    Assert.NotNull(ps);

                    // run a powershell command on that session
                    WriteLine("Running PowerShell command");
                    await RunPowerShellCommand(client, node, session, ps);

                    // get some tab completion results
                    WriteLine("Try Tab Completion");
                    await GetTabCompletionResults(client, node, session, ps);

                    // look at all the open powershell sessions
                    WriteLine("List PowerShell Sessions");
                    await ListPowerShellSessions(client, node, session);

                    WriteLine("Try a long-running command.");
                    await RunLongPowerShellCommand(client, node, session, ps);

                    // clean up our active SMT session.
                    WriteLine("Delete Session");
                    await client.Session.DeleteAsync(ResourceGroup, node.Name, session.Name);
                }
                finally
                {
                    // remove gateway that we've created 
                    if (!TestingInteractively)
                    {
                        RemoveGateway(client, GatewayTwo).Wait();
                    }

                    // regardless, always clear the nodes out.
                    RemoveAllNodes(client).Wait();
                }
            }
        }
    }
}