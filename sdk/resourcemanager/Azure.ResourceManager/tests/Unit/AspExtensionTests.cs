// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Microsoft.Extensions.Azure;
using System.Collections.Generic;
using System;
using System.Reflection;
using Azure.ResourceManager.Resources;

namespace Azure.ResourceManager.Tests
{
    public class AspExtensionTests
    {
        [Test]
        public void SimpleDefaultSubscription()
        {
            string defaultSubscription = Guid.NewGuid().ToString();

            var services = new ServiceCollection();
            services.AddAzureClients(builder =>
            {
                builder.AddArmClient(defaultSubscription);
            });

            ArmClient client = GetClient(services);

            AssertDefaultSubscription(defaultSubscription, client);
        }

        [Test]
        public void DefaultSubscriptionFromConfiguration()
        {
            string defaultSubscription = Guid.NewGuid().ToString();

            IConfiguration configuration = new ConfigurationBuilder()
                .AddInMemoryCollection(new[]
                {
                    new KeyValuePair<string, string>("defaultSubscriptionId", defaultSubscription)
                })
                .Build();
            var services = new ServiceCollection();
            services.AddAzureClients(builder =>
            {
                builder.AddArmClient(configuration);
            });

            ArmClient client = GetClient(services);

            AssertDefaultSubscription(defaultSubscription, client);
        }

        private static void AssertDefaultSubscription(string defaultSubscription, ArmClient client)
        {
            SubscriptionResource subscription = client.GetType().GetField("_defaultSubscription", BindingFlags.NonPublic | BindingFlags.Instance).GetValue(client) as SubscriptionResource;
            Assert.AreEqual(subscription.Id, SubscriptionResource.CreateResourceIdentifier(defaultSubscription));
        }

        private static ArmClient GetClient(ServiceCollection services)
        {
            ArmClient result = null;
            ServiceProvider sp = null;

            try
            {
                Assert.DoesNotThrow(() =>
                {
                    sp = services.BuildServiceProvider();
                    result = sp
                        .GetRequiredService<ArmClient>();
                });
            }
            finally
            {
                sp?.Dispose();
            }

            return result;
        }

        [Test]
        public void ModifyApiVersion()
        {
            string defaultSubscription = Guid.NewGuid().ToString();
            string apiVersion = "1010-10-10";

            var services = new ServiceCollection();
            services.AddAzureClients(builder =>
            {
                builder.AddArmClient(defaultSubscription);
                builder.ConfigureDefaults(options =>
                {
                    if (options is not ArmClientOptions armClientOptions)
                        return;

                    armClientOptions.SetApiVersion(ResourceGroupResource.ResourceType, apiVersion);
                });
            });

            ArmClient client = GetClient(services);

            AssertDefaultSubscription(defaultSubscription, client);

            Assert.IsTrue(client.ApiVersionOverrides.ContainsKey(ResourceGroupResource.ResourceType));
            Assert.AreEqual(client.ApiVersionOverrides[ResourceGroupResource.ResourceType], apiVersion);
        }
    }
}
