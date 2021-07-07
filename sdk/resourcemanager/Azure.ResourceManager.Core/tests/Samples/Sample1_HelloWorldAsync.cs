using System;
using System.Threading.Tasks;
using Azure.Identity;
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests.Samples
{
    class Sample1_HelloWorldAsync
    {
        public Sample1_HelloWorldAsync()
        {
        }

        [Test]
        public void GettingDefaultSubscription()
        {
            #region Snippet:Hello_World_Async_DefaultSubscription
            var armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = armClient.DefaultSubscription;
            Console.WriteLine(subscription.Id);
            #endregion Snippet:Hello_World_Async_DefaultSubscription
        }

        [Test]
        public async Task GettingSpecificSubscriptionAsync()
        {
            #region Snippet:Hello_World_Async_SpecificSubscription
            string subscriptionId = "db1ab6f0-4769-4b27-930e-01e2ef9c123c";
            var armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = await armClient.GetSubscriptions().GetAsync(subscriptionId);
            Console.WriteLine(subscription.Id);
            #endregion Snippet:Hello_World_Async_SpecificSubscription
        }

        [Test]
        public void RetrieveResourceGroupContainer()
        {
            var armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = armClient.DefaultSubscription;
            #region Snippet:Hello_World_Async_ResourceGroupContainer
            ResourceGroupContainer rgContainer = subscription.GetResourceGroups();
            #endregion Snippet:Hello_World_Async_ResourceGroupContainer
        }
    }
}
