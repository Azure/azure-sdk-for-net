// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.HealthBot.Tests;

public class BasicHealthBotTests
{
    internal static Trycep CreateHealthBotTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:HealthBotBasic
                Infrastructure infra = new();

                HealthBot bot =
                    new(nameof(bot), HealthBot.ResourceVersions.V2025_11_01)
                    {
                        SkuName = HealthBotSkuName.F0,
                        Tags = { ["environment"] = "test" },
                    };
                infra.Add(bot);

                infra.Add(new ProvisioningOutput("botName", typeof(string)) { Value = bot.Name });
                infra.Add(new ProvisioningOutput("resourceId", typeof(string)) { Value = bot.Id });
                #endregion

                return infra;
            });
    }

    [Test]
    [Description("https://learn.microsoft.com/en-us/azure/templates/microsoft.healthbot/2025-11-01/healthbots")]
    public async Task CreateHealthBot()
    {
        await using Trycep test = CreateHealthBotTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource bot 'Microsoft.HealthBot/healthBots@2025-11-01' = {
              name: take('bot-${uniqueString(resourceGroup().id)}', 64)
              location: location
              sku: {
                name: 'F0'
              }
              tags: {
                environment: 'test'
              }
            }

            output botName string = bot.name

            output resourceId string = bot.id
            """);
    }
}
