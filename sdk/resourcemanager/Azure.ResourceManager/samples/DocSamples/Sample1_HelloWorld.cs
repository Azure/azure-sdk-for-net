// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Hello_World_Namespaces
using System;
using Azure.Identity;
using Azure.ResourceManager;
using Azure.ResourceManager.Resources;
#endregion
using NUnit.Framework;

namespace Azure.ResourceManager.Tests.Samples
{
    public class Sample1_HelloWorld
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void GettingDefaultSubscription()
        {
            #region Snippet:Hello_World_DefaultSubscription
            ArmClient client = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = client.GetDefaultSubscription();
            Console.WriteLine(subscription.Id);
            #endregion Snippet:Hello_World_DefaultSubscription
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void GettingSpecificSubscription()
        {
            #region Snippet:Hello_World_SpecificSubscription
            string subscriptionId = "your-subscription-id";
            ArmClient client = new ArmClient(new DefaultAzureCredential());
            SubscriptionCollection subscriptions = client.GetSubscriptions();
            SubscriptionResource subscription = subscriptions.Get(subscriptionId);
            Console.WriteLine($"Got subscription: {subscription.Data.DisplayName}");
            #endregion Snippet:Hello_World_SpecificSubscription
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void GettingSpecifiedDefaultSubscription()
        {
            #region Snippet:Hello_World_SpecifyDefaultSubscription
            string defaultSubscriptionId = "your-subscription-id";
            ArmClient client = new ArmClient(new DefaultAzureCredential(), defaultSubscriptionId);
            SubscriptionResource subscription = client.GetDefaultSubscription();
            Console.WriteLine(subscription.Id);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void RetrieveResourceGroupCollection()
        {
            ArmClient client = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = client.GetDefaultSubscription();
            #region Snippet:Hello_World_ResourceGroupCollection
            ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();
            #endregion Snippet:Hello_World_ResourceGroupCollection
        }
    }
}
