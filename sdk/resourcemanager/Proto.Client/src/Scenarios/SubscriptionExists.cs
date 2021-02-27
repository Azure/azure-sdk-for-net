using Azure.ResourceManager.Core;
using System;

namespace Proto.Client
{
    class SubscriptionExists : Scenario
    {
        public override void Execute()
        {
            var client = new AzureResourceManagerClient();
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
