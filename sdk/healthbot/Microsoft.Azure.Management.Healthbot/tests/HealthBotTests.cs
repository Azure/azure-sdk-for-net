
using System;
using System.Net;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using System.Collections.Generic;
using Microsoft.Azure.Management.Resources;
using Microsoft.Azure.Management.Healthbot;
using Microsoft.Azure.Management.Healthbot.Models;
using Xunit;

namespace Healthbot.Tests
{

    public class HealthbotTests : TestBase
    {

        /** Static Data **/
        static string testLocation = "eastus";
        static string testHealthBotName = "dotnet-test-bot";


        /** Tests **/

        /// <summary>
        /// Test create and list Azure Health Bot.
        /// </summary>
        [Fact]
        public void HealthbotCreateAndListTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                ResourceManagementClient resourceClient = HealthbotTestUtilities.GetResourceManagementClient(context, handler);
                healthbotClient healthbotClient = HealthbotTestUtilities.GetHealthbotManagementClient(context, handler);

                // Create resource group
                var resourceGroup = HealthbotTestUtilities.CreateResourceGroup(resourceClient);

                // Verify that there are no results when querying an empty resource group
                var bots = healthbotClient.Bots.ListByResourceGroup(resourceGroup.Name);
                Assert.Empty(bots);

                // Create Azure Health Bot
                healthbotClient.Bots.Create(resourceGroup.Name, testHealthBotName, new HealthBot(testLocation, new Sku(SkuName.F0)));

                // List Azure Health Bot in RG and check that only 1 exists
                bots = healthbotClient.Bots.ListByResourceGroup(resourceGroup.Name);
                Assert.Single(bots);
            }
        }

        /// <summary>
        /// Test create and update Azure Health Bot.
        /// </summary>
        [Fact]
        public void HealthbotCreateAndUpdateTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                ResourceManagementClient resourceClient = HealthbotTestUtilities.GetResourceManagementClient(context, handler);
                healthbotClient healthbotClient = HealthbotTestUtilities.GetHealthbotManagementClient(context, handler);

                // Create resource group
                var resourceGroup = HealthbotTestUtilities.CreateResourceGroup(resourceClient);

                // Create Azure Health Bot
                var bot = healthbotClient.Bots.Create(resourceGroup.Name, testHealthBotName, new HealthBot(testLocation, new Sku(SkuName.F0)));

                // Verify that we can get the Azure Health Bot
                var returnedBot = healthbotClient.Bots.Get(resourceGroup.Name, bot.Name);

                // Assertions
                HealthbotTestUtilities.VerifyHealthbotProperties(bot, returnedBot);

                // Update
                bot = healthbotClient.Bots.Update(resourceGroup.Name, testHealthBotName, new HealthBotUpdateParameters(sku: new Sku(SkuName.S1)));

                // Get the updated Azure Health Bot
                returnedBot = healthbotClient.Bots.Get(resourceGroup.Name, bot.Name);

                // Assertions - SKU changed
                HealthbotTestUtilities.VerifyHealthbotProperties(bot, returnedBot);
            }
        }

        /// <summary>
        /// Test create and delete Azure Health Bot.
        /// </summary>
        [Fact]
        public void HealthbotCreateAndDeleteTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };
            using (MockContext context = MockContext.Start(this.GetType()))
            {
                ResourceManagementClient resourceClient = HealthbotTestUtilities.GetResourceManagementClient(context, handler);
                healthbotClient healthbotClient = HealthbotTestUtilities.GetHealthbotManagementClient(context, handler);

                // Create resource group
                var resourceGroup = HealthbotTestUtilities.CreateResourceGroup(resourceClient);

                // Create Azure Health Bot
                var bot = healthbotClient.Bots.Create(resourceGroup.Name, testHealthBotName, new HealthBot(testLocation, new Sku(SkuName.F0)));

                // Verify that we can get the Azure Health Bot
                var returnedBot = healthbotClient.Bots.Get(resourceGroup.Name, bot.Name);

                // Delete the Azure Health Bot
                healthbotClient.Bots.Delete(resourceGroup.Name, testHealthBotName);
                
                // Verify that RG is empty after deletion
                var bots = healthbotClient.Bots.ListByResourceGroup(resourceGroup.Name);
                Assert.Empty(bots);
            }
        }

    }
}

