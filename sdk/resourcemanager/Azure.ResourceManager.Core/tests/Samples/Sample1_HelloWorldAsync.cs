#region Snippet:Hello_World_Async_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Core;
#endregion
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests.Samples
{
    class Sample1_HelloWorldAsync
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void GettingDefaultSubscription()
        {
            #region Snippet:Hello_World_Async_DefaultSubscription
            var armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = armClient.DefaultSubscription;
            Console.WriteLine(subscription.Id);
            #endregion Snippet:Hello_World_Async_DefaultSubscription
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GettingSpecificSubscriptionAsync()
        {
            #region Snippet:Hello_World_Async_SpecificSubscription
            string subscriptionId = "your-subscription-id";
            var armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = await armClient.GetSubscriptions().GetAsync(subscriptionId);
            Console.WriteLine(subscription.Id);
            #endregion Snippet:Hello_World_Async_SpecificSubscription
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
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
