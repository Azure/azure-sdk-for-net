#region Snippet:Hello_World_Async_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Resources;
#endregion
using NUnit.Framework;

namespace Azure.ResourceManager.Tests.Samples
{
    class Sample1_HelloWorldAsync
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GettingDefaultSubscription()
        {
            #region Snippet:Hello_World_Async_DefaultSubscription
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
            Console.WriteLine(subscription.Id);
            #endregion Snippet:Hello_World_Async_DefaultSubscription
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GettingSpecificSubscriptionAsync()
        {
            #region Snippet:Hello_World_Async_SpecificSubscription
            string subscriptionId = "your-subscription-id";
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = await armClient.GetSubscriptions().GetAsync(subscriptionId);
            Console.WriteLine(subscription.Id);
            #endregion Snippet:Hello_World_Async_SpecificSubscription
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GettingSpecifiedDefaultSubscriptionAsync()
        {
            #region Snippet:Hello_World_Async_SpecifyDefaultSubscription
            string defaultSubscriptionId = "your-subscription-id";
            ArmClient armClient = new ArmClient(defaultSubscriptionId, new DefaultAzureCredential());
            Subscription subscription = await armClient.GetDefaultSubscriptionAsync();
            Console.WriteLine(subscription.Id);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void RetrieveResourceGroupCollection()
        {
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = armClient.GetDefaultSubscription();
            #region Snippet:Hello_World_Async_ResourceGroupCollection
            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
            #endregion Snippet:Hello_World_Async_ResourceGroupCollection
        }
    }
}
