using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.ServiceProcess;
using System.Threading.Tasks;
using Microsoft.Azure.Management.ServerManagement;
using Microsoft.Azure.Test.HttpRecorder;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using Xunit.Abstractions;


namespace ServerManagement.Tests
{
    public class ServerManagementTestBase : TestBase
    {
        protected static string ResourceGroup = "sdktest";
        private static bool _once;

        private readonly ITestOutputHelper _output;

        protected static bool Recording
        {
            get { return HttpMockServer.Mode == HttpRecorderMode.Record; }
        }

        protected static bool ReuseExistingGateway
        {
            get
            {
                return Recording &&
                       "true".Equals(Environment.GetEnvironmentVariable("REUSE_EXISTING_GATEWAY"),
                           StringComparison.OrdinalIgnoreCase);
            }
        }

        protected static string NodeName
        {
            get { return Environment.GetEnvironmentVariable("NODE_NAME"); }
        }

        protected static string NodeUserName
        {
            get { return Environment.GetEnvironmentVariable("NODE_USERNAME"); }
        }

        protected static string NodePassword
        {
            get { return Environment.GetEnvironmentVariable("NODE_PASSWORD"); }
        }


        protected static bool IsAdmin
        {
            get
            {
                return Extensions.Safe(
                        () =>
                            new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator));
            }
        }

        public ServerManagementTestBase(ITestOutputHelper output)
        {
            // add environment variables so that we can just run from VS to record.
            Extensions.Default("TEST_HTTPMOCK_OUTPUT",
                String.Format("{0}\\SessionRecords", Directory.GetParent(this.GetType().Assembly.Location).FullName));
            Extensions.Default("TEST_CSM_ORGID_AUTHENTICATION", "SubscriptionId=3e82a90d-d19e-42f9-bb43-9112945846ef;BaseUri=https://management.azure.com/;AADAuthEndpoint=https://login.windows.net/");

            Extensions.Default("AZURE_TEST_MODE", "Playback");
            HttpMockServer.Mode = "record".Equals(Environment.GetEnvironmentVariable("AZURE_TEST_MODE"), StringComparison.OrdinalIgnoreCase) ? HttpRecorderMode.Record : HttpRecorderMode.Playback;

            // node settings
            Extensions.Default("NODE_NAME", "saddlebags");
            Extensions.Default("NODE_USERNAME", "gsAdmin");
            Extensions.Default("NODE_PASSWORD", "NEED_PASSWORD");

            // only used for some interactive testing. 
            Extensions.Default("REUSE_EXISTING_GATEWAY", "false");

            Console.WriteLine(String.Format("Recording: {0}", Recording));

            if (!ReuseExistingGateway)
            {
                StopGateway();
            }

            _output = output;
        }

        internal void StopGateway()
        {
            if (Recording)
            {
                ServiceController sc = new ServiceController("ServerManagementToolsGateway");
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
                        WriteLine(String.Format("Gateway Service is {0} --stopping", sc.Status));
                        sc.Stop();
                        break;
                }
                // wait a few seconds.
                Task.Delay(10 * 1000).Wait();
            }
        }

        internal void StartGateway()
        {
            if (Recording)
            {
                ServiceController sc = new ServiceController("ServerManagementToolsGateway");
                while (sc.Status == ServiceControllerStatus.StartPending || sc.Status == ServiceControllerStatus.StopPending)
                {
                    Task.Delay(100).Wait();
                }


                switch (sc.Status)
                {
                    case ServiceControllerStatus.Running:
                        WriteLine("Gateway Service already Running.");
                        break;

                    default:
                        WriteLine(String.Format("Gateway Service is {0} -- starting.", sc.Status));
                        sc.Start();
                        break;
                }

                while (sc.Status == ServiceControllerStatus.StartPending || sc.Status == ServiceControllerStatus.StopPending)
                {
                    Task.Delay(100).Wait();
                }

                // wait for service to initialize itself.
                Task.Delay(180 * 1000).Wait();
            }
        }

        public void WriteLine(string format, params object[] args)
        {
            if (_output == null)
            {
                Console.WriteLine(format,args);
            }
            else
            {
                _output.WriteLine(format, args);
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
                WriteLine(String.Format("Removing Node {0}/{1}", ResourceGroup, nodeName));
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
                WriteLine(String.Format("Removing Gateway {0}/{1}", ResourceGroup, gatewayName));

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
            await client.Node.ListForResourceGroup(ResourceGroup)?
                .WhereNotNull()
                .Select(each => RemoveNode(client, each.Name));
        }

        protected async Task RemoveAllGateways(ServerManagementClient client)
        {
            await client.Gateway.ListForResourceGroup(ResourceGroup)?
                .WhereNotNull()
                .Select(each => RemoveGateway(client, each.Name));
        }

        
        protected async Task OneTimeInitialization()
        {
            if (Recording && !IsAdmin)
            {
                // check for admin access, you're going to need it to record.
                throw new Exception("Recording requires this process to be elevated.");
            }

            if (Recording)
            {
                // check if the service is installed on this machine.
                try
                {
                    var sc = new ServiceController("ServerManagementToolsGateway");
                } catch
                {
                    throw new Exception("Recording requires the gateway service to be installed on this computer");
                }
            }

            if (!ReuseExistingGateway)
            {
                if (!_once && Recording)
                {
                    _once = true;
                    using (MockContext context = MockContext.Start("ServerManagement.Tests.Ignore"))
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
