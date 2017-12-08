using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net;
using System.Text;
using BotService.Tests.Helpers;
using Microsoft.Rest.ClientRuntime.Azure.TestFramework;
using ResourceGroups.Tests;
using Xunit;
using Microsoft.Azure.Management.BotService;
using Microsoft.Azure.Management.BotService.Models;
using Microsoft.Azure.Management.ResourceManager.Fluent;
using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Microsoft.Rest;
using Microsoft.Rest.Azure.Authentication;

namespace BotService.Tests
{
    public class BotServiceTests
    {
        private const string resourceNamespace = "Microsoft.BotService";
        private const string resourceType = "botService";

        [Fact]
        public void BotCreateAndListByResourceGroupTest()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = BotServiceManagementTestUtilities.GetResourceManagementClient(context, handler);
                var botServiceMgmtClient = BotServiceManagementTestUtilities.GetBotServiceManagementClient(context, handler);

                // Create resource group
                var rgname = BotServiceManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Verify that there are no results when querying an empty resource group
                var bots = botServiceMgmtClient.BotServices.ListByResourceGroup(rgname);
                Assert.Empty(bots);

                // Create bot services
                BotResource bot1 = BotServiceManagementTestUtilities.CreateAndValidateBot(botServiceMgmtClient, rgname);
                BotResource bot2 = BotServiceManagementTestUtilities.CreateAndValidateBot(botServiceMgmtClient, rgname);

                // Verify that there are no results when querying an empty resource group
                bots = botServiceMgmtClient.BotServices.ListByResourceGroup(rgname);
                Assert.Equal(2, bots.Count());

                Assert.True(bots.Any(b => b.Name == bot1.Name));
                Assert.True(bots.Any(b => b.Name == bot2.Name));
            }
        }

        [Fact]
        public void BotCreateGetUpdateGetDeleteGet()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = BotServiceManagementTestUtilities.GetResourceManagementClient(context, handler);
                var botServiceMgmtClient = BotServiceManagementTestUtilities.GetBotServiceManagementClient(context, handler);

                // Create resource group
                var rgname = BotServiceManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create bot resource
                BotResource bot = BotServiceManagementTestUtilities.CreateAndValidateBot(botServiceMgmtClient, rgname);

                // Verify that we can get the bot
                var createdBot = botServiceMgmtClient.BotServices.Get(rgname, bot.Name);

                Assert.NotNull(createdBot);
                Assert.Equal(bot.Name, createdBot.Name);
                Assert.Equal(bot.Properties.Endpoint, bot.Properties.Endpoint);

                // Update the bot endpoint
                var newEndpoint = "https://new.bot.endpoint";
                var properties = createdBot.Properties;
                properties.Endpoint = newEndpoint;

                var updatedBot = botServiceMgmtClient.BotServices.Update(rgname, bot.Name, 
                    properties: properties,
                    location: bot.Location,
                    sku: bot.Sku,
                    tags: bot.Tags,
                    kind: bot.Kind,
                    etag: bot.Etag);

                Assert.NotNull(updatedBot);
                Assert.Equal(bot.Name, updatedBot.Name);

                // Get the updated bot to verify
                // Verify that we can get the bot
                var updatedAndRetrievedBot = botServiceMgmtClient.BotServices.Get(rgname, bot.Name);

                Assert.NotNull(updatedAndRetrievedBot);
                Assert.Equal(updatedAndRetrievedBot.Name, updatedBot.Name);
                Assert.Equal(newEndpoint, updatedBot.Properties.Endpoint);

                // Delete the updated bot
                botServiceMgmtClient.BotServices.Delete(rgname, bot.Name);

                try
                {
                    // Get the deleted bot to verify it does not exist
                    // Verify that we can get the bot
                    var deletedBot = botServiceMgmtClient.BotServices.Get(rgname, bot.Name);
                }
                catch (ErrorException e)
                {
                    Assert.True(e.Response.StatusCode == HttpStatusCode.NotFound);
                }
            }
        }

        [Fact]
        public void BotUpdateSku()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = BotServiceManagementTestUtilities.GetResourceManagementClient(context, handler);
                var botServiceMgmtClient = BotServiceManagementTestUtilities.GetBotServiceManagementClient(context, handler);

                // Create resource group
                var rgname = BotServiceManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Create bot resource
                BotResource bot = BotServiceManagementTestUtilities.CreateAndValidateBot(botServiceMgmtClient, rgname);

                // Verify that we can get the bot
                var createdBot = botServiceMgmtClient.BotServices.Get(rgname, bot.Name);

                Assert.NotNull(createdBot);
                Assert.Equal(bot.Name, createdBot.Name);
                Assert.Equal(bot.Properties.Endpoint, bot.Properties.Endpoint);

                // Update the bot endpoint
                var properties = createdBot.Properties;

                var updatedBot = botServiceMgmtClient.BotServices.Update(rgname, bot.Name,
                    properties: properties,
                    location: bot.Location,
                    sku: new Sku("F0"),
                    tags: bot.Tags,
                    kind: bot.Kind,
                    etag: bot.Etag);

                Assert.NotNull(updatedBot);
                Assert.Equal(bot.Name, updatedBot.Name);
                Assert.Equal("F0", updatedBot.Sku.Name);
            }
        }

        [Fact]
        public void BotCreateWithoutResourceGroupShouldFail()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = BotServiceManagementTestUtilities.GetResourceManagementClient(context, handler);
                var botServiceMgmtClient = BotServiceManagementTestUtilities.GetBotServiceManagementClient(context, handler);

                var nonExistentResourceGroup = "na";

                try
                {
                    // Create bot resource
                    BotResource bot = BotServiceManagementTestUtilities.CreateAndValidateBot(botServiceMgmtClient, nonExistentResourceGroup);
                }
                catch (ErrorException e)
                {
                    Assert.Equal(HttpStatusCode.NotFound, e.Response.StatusCode);
                    Assert.Equal("ResourceGroupNotFound", e.Body.ErrorProperty.Code);
                }
            }
        }
    }
}
