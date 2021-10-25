#region Snippet:Hello_World_Namespaces
using System;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
#endregion
using NUnit.Framework;

namespace Azure.ResourceManager.Tests.Samples
{
    class Sample1_HelloWorld
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void GettingDefaultSubscription()
        {
            #region Snippet:Hello_World_DefaultSubscription
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = armClient.GetDefaultSubscription();
            Console.WriteLine(subscription.Id);
            #endregion Snippet:Hello_World_DefaultSubscription
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void GettingSpecificSubscription()
        {
            #region Snippet:Hello_World_SpecificSubscription
            string subscriptionId = "your-subscription-id";
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = armClient.GetSubscriptions().Get(subscriptionId);
            Console.WriteLine($"Got subscription: {subscription.Data.DisplayName}");
            #endregion Snippet:Hello_World_SpecificSubscription
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void GettingSpecifiedDefaultSubscription()
        {
            #region Snippet:Hello_World_SpecifyDefaultSubscription
            string defaultSubscriptionId = "your-subscription-id";
            ArmClient armClient = new ArmClient(defaultSubscriptionId, new DefaultAzureCredential());
            Subscription subscription = armClient.GetDefaultSubscription();
            Console.WriteLine(subscription.Id);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void RetrieveResourceGroupCollection()
        {
            ArmClient armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = armClient.GetDefaultSubscription();
            #region Snippet:Hello_World_ResourceGroupCollection
            ResourceGroupCollection rgCollection = subscription.GetResourceGroups();
            #endregion Snippet:Hello_World_ResourceGroupCollection
        }
    }
}
