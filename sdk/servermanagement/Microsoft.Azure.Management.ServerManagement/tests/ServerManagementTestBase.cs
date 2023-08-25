// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using System;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.ServiceProcess;
using System.Threading.Tasks;
using Microsoft.Azure.Management.ServerManagement;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit;
using Xunit.Abstractions;

namespace ServerManagement.Tests
{
    public class ServerManagementTestBase : TestBase
    {
        protected static string ResourceGroup = "sdktest";
        private static bool _once;
        private static string _nodename;
        private static string _nodeusername;
        private static string _location;
        private static string _gatewayone;
        private static string _gatewaytwo;
        private static string _sessionId;
        private static string _sessionIdTwo;
        private readonly ITestOutputHelper _output;


        public ServerManagementTestBase(ITestOutputHelper output)
        {
#if WHEN_RUNNING_IN_VS
            // add environment variables so that we can just use the visual studio test runner for doing interactive testing.
            // these get ignored when they are already set.
            Extensions.SetEnvironmentVariableIfNotAlreadySet("TEST_HTTPMOCK_OUTPUT",
                string.Format("{0}\\SessionRecords", Directory.GetParent(GetType().Assembly.Location).FullName));
            Extensions.SetEnvironmentVariableIfNotAlreadySet("TEST_CSM_ORGID_AUTHENTICATION",
                "SubscriptionId=3e82a90d-d19e-42f9-bb43-9112945846ef;BaseUri=https://management.azure.com/;AADAuthEndpoint=https://login.windows.net/");
            Extensions.SetEnvironmentVariableIfNotAlreadySet("AZURE_TEST_MODE", "Record");
#endif
            // since HttpMockServer.Mode doesn't get set until after I'd like to know what state we're in
            // we'll preemptively set it to what it will get set to later anyway.
            HttpMockServer.Mode = "record".Equals(Environment.GetEnvironmentVariable("AZURE_TEST_MODE"),
                StringComparison.OrdinalIgnoreCase)
                ? HttpRecorderMode.Record
                : HttpRecorderMode.Playback;


            if (TestingInteractively)
            {
                StopGateway();
            }

            _output = output;
        }

        protected static bool Recording
        {
            get { return HttpMockServer.Mode == HttpRecorderMode.Record; }
        }

        internal static bool ForceResetGatewayProfile
        {
            get
            {
                return "true".Equals(Environment.GetEnvironmentVariable("SMT_FORCE_GATEWAY_RESET"),
                    StringComparison.OrdinalIgnoreCase);
            }
        }

        protected static bool TestingInteractively
        {
            get
            {
                return Recording && !ForceResetGatewayProfile;
            }
        }

        /// <summary>
        ///  the name of the SMT node to create
        /// </summary>
        protected static string NodeName
        {
            get
            {
                return _nodename ??
                       (_nodename =
                           HttpMockServer.GetVariable("SMT_NODE_NAME",
                               Environment.GetEnvironmentVariable("SMT_NODE_NAME") ?? "saddlebags").ToLower());
            }
        }

        /// <summary>
        /// the username to use when creating the SMT NODE and Session for that node
        /// </summary>
        protected static string NodeUserName
        {
            get
            {
                return _nodeusername ??
                       (_nodeusername =
                           HttpMockServer.GetVariable("SMT_NODE_USERNAME",
                               Environment.GetEnvironmentVariable("SMT_NODE_USERNAME") ?? "gsAdmin"));
            }
        }

        /// <summary>
        ///  The location to use when creating resources.
        /// </summary>
        protected static string Location
        {
            get
            {
                return _location ??
                       (_location =
                           HttpMockServer.GetVariable("SMT_TEST_LOCATION",
                               Environment.GetEnvironmentVariable("SMT_TEST_LOCATION") ?? "centralus"));
            }
        }

        /// <summary>
        ///  the gateway name to use when creating the gateway
        /// </summary>
        protected static string GatewayOne
        {
            get
            {
                return _gatewayone ??
                       (_gatewayone =
                           HttpMockServer.GetVariable("SMT_GATEWAY_1",
                               Environment.GetEnvironmentVariable("SMT_GATEWAY_1") ??
                               "test_gateway_" + new Random().Next(0, int.MaxValue)).ToLower());
            }
        }


        /// <summary>
        /// The gateway name to use when testing the node/session/pssession
        /// </summary>
        protected static string GatewayTwo
        {
            get
            {
                // if the SMT_GATEWAY_2 isn't set, we default to 'mygateway' ...
                // makes it easier to not regenerate the gateway profile every time
                return _gatewaytwo ??
                       (_gatewaytwo =
                           HttpMockServer.GetVariable("SMT_GATEWAY_2",
                               Environment.GetEnvironmentVariable("SMT_GATEWAY_2") ??
                               "mygateway").ToLower());
            }
        }

        /// <summary>
        ///  the session id to use when creating a session
        /// </summary>
        protected static string SessionId
        {
            get
            {
                return _sessionId ??
                       (_sessionId = HttpMockServer.GetVariable("SMT_SESSION_ID", Guid.NewGuid().ToString()).ToLower());
            }
        }

        /// <summary>
        /// the session id to use when creating an encrypted session
        /// </summary>
        protected static string SessionIdTwo
        {
            get
            {
                return _sessionIdTwo ??
                       (_sessionIdTwo = HttpMockServer.GetVariable("SMT_SESSION_ID_2", Guid.NewGuid().ToString()).ToLower());
            }
        }

        /// <summary>
        ///  the password to use when connecting to the node
        /// </summary>
        protected static string NodePassword
        {
            // does not store actual password; on playback we don't need the real password anyway, we can just use a dummy password
            get { return Environment.GetEnvironmentVariable("SMT_NODE_PASSWORD") ?? "S0meP@sswerd!"; }
        }

        /// <summary>
        /// checks for admin access
        /// </summary>
        protected static bool IsAdmin
        {
            get
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    try
                    {
                        return new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator);
                    }
                    catch
                    {
                    }
                }

                return false;
            }
        }

        internal void StopGateway()
        {
            if (Recording)
            {
                var sc = new ServiceController("ServerManagementToolsGateway");
                while (sc.Status == ServiceControllerStatus.StopPending)
                {
                    Task.Delay(100).Wait();
                }

                switch (sc.Status)
                {
                    case ServiceControllerStatus.Stopped:
                        WriteLine("Gateway Service already stopped.");
                        break;

                    default:
                        WriteLine(string.Format("Gateway Service is {0} --stopping", sc.Status));
                        sc.Stop();
                        break;
                }
                // wait a few seconds.
                Task.Delay(10*1000).Wait();
            }
        }

        internal void StartGateway()
        {
            if (Recording)
            {
                var sc = new ServiceController("ServerManagementToolsGateway");
                while (sc.Status == ServiceControllerStatus.StartPending ||
                       sc.Status == ServiceControllerStatus.StopPending)
                {
                    Task.Delay(100).Wait();
                }

                if (sc.Status == ServiceControllerStatus.Running)
                {
                    WriteLine("Gateway Service already Running.");
                    return;
                }

                WriteLine(string.Format("Gateway Service is {0} -- starting.", sc.Status));
                sc.Start();

                while (sc.Status == ServiceControllerStatus.StartPending ||
                       sc.Status == ServiceControllerStatus.StopPending)
                {
                    Task.Delay(100).Wait();
                }

            }
        }

        public void WriteLine(string format)
        {
            if (_output == null)
            {
                Console.WriteLine(format);
            }
            else
            {
                _output.WriteLine(format);
            }
        }

        protected static ServerManagementClient GetServerManagementClient(MockContext context)
        {
            return context.GetServiceClient<ServerManagementClient>();
        }

        protected Task RemoveNode(ServerManagementClient client, string nodeName)
        {
            try
            {
                WriteLine(string.Format("Removing Node {0}/{1}", ResourceGroup, nodeName));
                return client.Node.DeleteAsync(ResourceGroup, nodeName);
            }
            catch
            {
            }
            return Task.FromResult(false);
        }

        protected async Task RemoveGateway(ServerManagementClient client, string gatewayName)
        {
            try
            {
                WriteLine(string.Format("Removing Gateway {0}/{1}", ResourceGroup, gatewayName));

                await client.Node.ListForResourceGroup(ResourceGroup)
                    .WhereNotNull()
                    .Where(node => node.GatewayId.MatchesName(gatewayName))
                    .Select(node => RemoveNode(client, node.Name));

                await client.Gateway.DeleteAsync(ResourceGroup, gatewayName);
            }
            catch
            {
            }
        }

        protected async Task RemoveAllNodes(ServerManagementClient client)
        {
            var nodes = client.Node.ListForResourceGroup(ResourceGroup).WhereNotNull();
            if (nodes != null)
            {
                foreach (var each in nodes)
                {
                    await RemoveNode(client, each.Name);
                }
            }
        }

        protected async Task RemoveAllGateways(ServerManagementClient client)
        {
            var gateways = client.Gateway.ListForResourceGroup(ResourceGroup).WhereNotNull();
            if (gateways != null)
            {
                foreach (var each in gateways)
                {
                    if (each.Name != GatewayTwo)
                    {
                        await RemoveGateway(client, each.Name);
                    }
                }
            }
        }

        protected async Task EnsurePrerequisites()
        {
            if (Recording)
            {
                // check for admin access, you're going to need it to record.
                Assert.True(IsAdmin, "Recording requires this process to be elevated.");

                try
                {
                    // check if the service is installed on this machine.
                    using (var sc = new ServiceController("ServerManagementToolsGateway"))
                    {
                    }
                }
                catch
                {
                    throw new Exception("Recording requires the gateway service to be installed on this computer");
                }

                if (TestingInteractively && !_once)
                {
                    _once = true;
                    using (var context = MockContext.Start("Ignore"))
                    {
                        var client = GetServerManagementClient(context);
                        await RemoveAllNodes(client);
                        await RemoveAllGateways(client);
                    }
                }
            }
        }
    }
}
