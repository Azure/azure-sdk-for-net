using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
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
        private const string OmitMsaAppIdCreationEnvironmentVariableName = "BOT_SERVICE_OMIT_MSA_APPID";

        public BotServiceTests()
        {
            Environment.SetEnvironmentVariable(OmitMsaAppIdCreationEnvironmentVariableName, "1");
        }

        [Fact]
        public void BotCreateEmailChannel()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = BotServiceManagementTestUtilities.GetResourceManagementClient(context, handler);
                var botServiceMgmtClient = BotServiceManagementTestUtilities.GetBotServiceManagementClient(context, handler);

                // Create resource group
                var rgname = BotServiceManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Verify that there are no results when querying an empty resource group
                var bots = botServiceMgmtClient.Bots.ListByResourceGroup(rgname);
                Assert.Empty(bots);

                // Create bot services
                Bot bot1 = BotServiceManagementTestUtilities.CreateAndValidateBot(botServiceMgmtClient, rgname);

                // Enable email channel for the demo bot
                var emailChannel = botServiceMgmtClient.Channels.Create(rgname, bot1.Name, ChannelName.EmailChannel,
                    new BotChannel(location: "global", properties:
                        new EmailChannel()
                        {
                            Properties = new EmailChannelProperties("carlostestsdk2@outlook.com", "Carlos.Test1", true),
                        }));
            }
        }

        [Fact(Skip = "This is a great test but involves other systems so doesn't work in playback mode, only for local testing")]
        public void BotCreateWebAppBot()
        {
            var handler = new RecordedDelegatingHandler { StatusCodeToReturn = HttpStatusCode.OK };

            using (MockContext context = MockContext.Start(this.GetType().FullName))
            {
                var resourcesClient = BotServiceManagementTestUtilities.GetResourceManagementClient(context, handler);
                var botServiceMgmtClient = BotServiceManagementTestUtilities.GetBotServiceManagementClient(context, handler);

                // Create resource group
                var rgname = BotServiceManagementTestUtilities.CreateResourceGroup(resourcesClient);

                // Verify that there are no results when querying an empty resource group
                var bots = botServiceMgmtClient.Bots.ListByResourceGroup(rgname);
                Assert.Empty(bots);

                // Create bot services
                Bot bot1 = BotServiceManagementTestUtilities.CreateAndValidateWebBot(botServiceMgmtClient, rgname, Kind.Bot);
                Bot bot2 = BotServiceManagementTestUtilities.CreateAndValidateWebBot(botServiceMgmtClient, rgname, Kind.Function);

                // Verify that there are no results when querying an empty resource group
                bots = botServiceMgmtClient.Bots.ListByResourceGroup(rgname);
                Assert.Equal(2, bots.Count());

                Assert.Contains(bots, b => b.Name == bot1.Name);
                Assert.Contains(bots, b => b.Name == bot2.Name);
            }
        }

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
                var bots = botServiceMgmtClient.Bots.ListByResourceGroup(rgname);
                Assert.Empty(bots);

                // Create bot services
                Bot bot1 = BotServiceManagementTestUtilities.CreateAndValidateBot(botServiceMgmtClient, rgname);
                Bot bot2 = BotServiceManagementTestUtilities.CreateAndValidateBot(botServiceMgmtClient, rgname);

                // Verify that there are no results when querying an empty resource group
                bots = botServiceMgmtClient.Bots.ListByResourceGroup(rgname);
                Assert.Equal(2, bots.Count());

                Assert.Contains(bots, b => b.Name == bot1.Name);
                Assert.Contains(bots, b => b.Name == bot2.Name);
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
                Bot bot = BotServiceManagementTestUtilities.CreateAndValidateBot(botServiceMgmtClient, rgname);

                // Verify that we can get the bot
                var createdBot = botServiceMgmtClient.Bots.Get(rgname, bot.Name);

                Assert.NotNull(createdBot);
                Assert.Equal(bot.Name, createdBot.Name);
                Assert.Equal(bot.Properties.Endpoint, bot.Properties.Endpoint);

                // Update the bot endpoint
                var newEndpoint = "https://new.bot.endpoint";
                var properties = createdBot.Properties;
                properties.Endpoint = newEndpoint;

                var updatedBot = botServiceMgmtClient.Bots.Update(rgname, bot.Name,
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
                var updatedAndRetrievedBot = botServiceMgmtClient.Bots.Get(rgname, bot.Name);

                Assert.NotNull(updatedAndRetrievedBot);
                Assert.Equal(updatedAndRetrievedBot.Name, updatedBot.Name);
                Assert.Equal(newEndpoint, updatedBot.Properties.Endpoint);

                // Delete the updated bot
                botServiceMgmtClient.Bots.Delete(rgname, bot.Name);

                try
                {
                    // Get the deleted bot to verify it does not exist
                    // Verify that we can get the bot
                    var deletedBot = botServiceMgmtClient.Bots.Get(rgname, bot.Name);
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
                Bot bot = BotServiceManagementTestUtilities.CreateAndValidateBot(botServiceMgmtClient, rgname);

                // Verify that we can get the bot
                var createdBot = botServiceMgmtClient.Bots.Get(rgname, bot.Name);

                Assert.NotNull(createdBot);
                Assert.Equal(bot.Name, createdBot.Name);
                Assert.Equal(bot.Properties.Endpoint, bot.Properties.Endpoint);

                // Update the bot endpoint
                var properties = createdBot.Properties;

                var updatedBot = botServiceMgmtClient.Bots.Update(rgname, bot.Name,
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
                    Bot bot = BotServiceManagementTestUtilities.CreateAndValidateBot(botServiceMgmtClient, nonExistentResourceGroup);
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
