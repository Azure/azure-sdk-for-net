using Azure.ResourceManager.Core;
using System;
using Azure.Core;
using Azure.Core.Pipeline;
using System.Threading;
using System.Diagnostics;
using Azure.Identity;

namespace Proto.Client
{
    class ClientOptionsOverride : Scenario
    {
        public override void Execute()
        {

            AzureResourceManagerClientOptions options1 = new AzureResourceManagerClientOptions();
            AzureResourceManagerClientOptions options2 = new AzureResourceManagerClientOptions();
            var dummyPolicy1 = new dummyPolicy();
            var dummyPolicy2 = new dummyPolicy2();
            options1.AddPolicy(dummyPolicy1, HttpPipelinePosition.PerCall);
            options2.AddPolicy(dummyPolicy2, HttpPipelinePosition.PerCall);
            var client1 = new AzureResourceManagerClient(new DefaultAzureCredential(), options1);
            var client2 = new AzureResourceManagerClient(new DefaultAzureCredential(), options2);

            Console.WriteLine("-----Client 1-----");
            foreach (var sub in client1.GetSubscriptionContainer().List())
            {
                Console.WriteLine($"Found {sub.Data.DisplayName}");
            }

            Console.WriteLine("-----Client 2-----");
           foreach (var sub in client2.GetSubscriptionContainer().List())
            {
                Console.WriteLine($"Found {sub.Data.DisplayName}");
            }

            Debug.Assert(dummyPolicy1.numMsgGot * 2 == dummyPolicy2.numMsgGot);
            Console.WriteLine("\nPASSED\n");
            
        }

        private class dummyPolicy : HttpPipelineSynchronousPolicy
        {
            public int numMsgGot = 0;

            public override void OnReceivedResponse(HttpMessage message)
            {
                Interlocked.Increment(ref numMsgGot);
            }
        }

        private class dummyPolicy2 : HttpPipelineSynchronousPolicy
        {
            public int numMsgGot = 0;

            public override void OnReceivedResponse(HttpMessage message)
            {
                Interlocked.Add(ref numMsgGot, 2);
            }
        }

    }
}
