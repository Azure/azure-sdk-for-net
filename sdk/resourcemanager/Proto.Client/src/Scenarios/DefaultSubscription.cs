using Azure.Identity;
using Azure.ResourceManager.Core;
using System;

namespace Proto.Client
{
    class DefaultSubscription : Scenario
    {
        public override void Execute()
        {
            var client = new ArmClient(Context.SubscriptionId, new DefaultAzureCredential());

            var sub = client.DefaultSubscription;

            if (sub.Data.SubscriptionGuid != Context.SubscriptionId)
                throw new Exception($"Didn't get back expected subscription.  Got {sub.Data.SubscriptionGuid} expected {Context.SubscriptionId}");

            Console.WriteLine("Found correct subscription");

            // Note: check of default subscription without specifying subscription is dependent on the credentials
            // used in constructuing the client.  Removed this test as its outcome is unpredictable unless you
            // always use the same credentials.
        }
    }
}
