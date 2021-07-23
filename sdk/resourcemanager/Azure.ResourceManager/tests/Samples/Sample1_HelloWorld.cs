#region Snippet:Hello_World_Namespaces
using System;
using Azure.Identity;
using Azure.ResourceManager.Core;
#endregion
using NUnit.Framework;

namespace Azure.ResourceManager.Core.Tests.Samples
{
    class Sample1_HelloWorld
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void GettingDefaultSubscription()
        {
            #region Snippet:Hello_World_DefaultSubscription
            var armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = armClient.DefaultSubscription;
            Console.WriteLine(subscription.Id);
            #endregion Snippet:Hello_World_DefaultSubscription
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void GettingSpecificSubscription()
        {
            #region Snippet:Hello_World_SpecificSubscription
            string subscriptionId = "your-subscription-id";
            var armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = armClient.GetSubscriptions().Get(subscriptionId);
            Console.WriteLine("Got subscription: " + subscription.Data.DisplayName);
            #endregion Snippet:Hello_World_SpecificSubscription
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void RetrieveResourceGroupContainer()
        {
            var armClient = new ArmClient(new DefaultAzureCredential());
            Subscription subscription = armClient.DefaultSubscription;
            #region Snippet:Hello_World_ResourceGroupContainer
            ResourceGroupContainer rgContainer = subscription.GetResourceGroups();
            #endregion Snippet:Hello_World_ResourceGroupContainer
        }
    }
}
