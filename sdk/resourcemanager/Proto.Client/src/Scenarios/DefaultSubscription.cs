using Azure.Identity;
using Azure.ResourceManager.Core;
using System;

namespace Proto.Client
{
    class DefaultSubscription : Scenario
    {
        public override void Execute()
        {
            var client = new AzureResourceManagerClient(Context.SubscriptionId, new DefaultAzureCredential());

            var sub = client.DefaultSubscription;

            if (sub.Data.SubscriptionGuid != Context.SubscriptionId)
                throw new Exception($"Didn't get back expected subscription.  Got {sub.Data.SubscriptionGuid} expected {Context.SubscriptionId}");

            Console.WriteLine("Found correct subscription");

            client = new AzureResourceManagerClient(new DefaultAzureCredential());

            sub = client.DefaultSubscription;

            if (sub.Data.SubscriptionGuid != Context.SubscriptionId)
                throw new Exception($"Didn't get back expected subscription.  Got {sub.Data.SubscriptionGuid} expected {Context.SubscriptionId}");

            Console.WriteLine("Found correct subscription");
        }
    }
}
