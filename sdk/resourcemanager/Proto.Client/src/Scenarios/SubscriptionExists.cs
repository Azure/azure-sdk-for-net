using Azure.ResourceManager.Core;
using System;
using Azure.Identity;

namespace Proto.Client
{
    class SubscriptionExists : Scenario
    {
        public override void Execute()
        {
            var client = new AzureResourceManagerClient(new DefaultAzureCredential());
            if(client.GetSubscriptionContainer().DoesExist(Context.SubscriptionId))
            {
                Console.WriteLine($"Found {Context.SubscriptionId}");
            }
            else
            {
                throw new Exception($"Did not find {Context.SubscriptionId}");
            }
        }
    }
}
