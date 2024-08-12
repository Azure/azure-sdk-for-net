// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

#region Snippet:Hello_World_Async_Namespaces
using System;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.ResourceManager.Resources;
#endregion
using NUnit.Framework;

namespace Azure.ResourceManager.Tests.Samples
{
    public class Sample1_HelloWorldAsync
    {
        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GettingDefaultSubscription()
        {
            #region Snippet:Hello_World_Async_DefaultSubscription
            ArmClient client = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
            Console.WriteLine(subscription.Id);
            #endregion Snippet:Hello_World_Async_DefaultSubscription
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GettingSpecificSubscriptionAsync()
        {
            #region Snippet:Hello_World_Async_SpecificSubscription
            string subscriptionId = "your-subscription-id";
            ArmClient client = new ArmClient(new DefaultAzureCredential());
            SubscriptionCollection subscriptions = client.GetSubscriptions();
            SubscriptionResource subscription = await subscriptions.GetAsync(subscriptionId);
            Console.WriteLine(subscription.Id);
            #endregion Snippet:Hello_World_Async_SpecificSubscription
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public async Task GettingSpecifiedDefaultSubscriptionAsync()
        {
            #region Snippet:Hello_World_Async_SpecifyDefaultSubscription
            string defaultSubscriptionId = "your-subscription-id";
            ArmClient client = new ArmClient(new DefaultAzureCredential(), defaultSubscriptionId);
            SubscriptionResource subscription = await client.GetDefaultSubscriptionAsync();
            Console.WriteLine(subscription.Id);
            #endregion
        }

        [Test]
        [Ignore("Only verifying that the sample builds")]
        public void RetrieveResourceGroupCollection()
        {
            ArmClient client = new ArmClient(new DefaultAzureCredential());
            SubscriptionResource subscription = client.GetDefaultSubscription();
            #region Snippet:Hello_World_Async_ResourceGroupCollection
            ResourceGroupCollection resourceGroups = subscription.GetResourceGroups();
            #endregion Snippet:Hello_World_Async_ResourceGroupCollection
        }
    }
}
