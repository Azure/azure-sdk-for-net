// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Provisioning.Tests;
using NUnit.Framework;

namespace Azure.Provisioning.BotService.Tests;

public class BasicBotServiceTests
{
    internal static Trycep CreateBotTest()
    {
        return new Trycep().Define(
            ctx =>
            {
                #region Snippet:BotServiceBasic
                Infrastructure infra = new();

                Bot bot =
                    new(nameof(bot), Bot.ResourceVersions.V2023_09_15_PREVIEW)
                    {
                        Kind = BotServiceKind.Bot,
                        Sku = new BotServiceSku
                        {
                            Name = BotServiceSkuName.F0,
                        },
                        Tags = { ["environment"] = "test" },
                        Properties = new BotProperties
                        {
                            DisplayName = "sample-bot",
                            Endpoint = new Uri("https://example.com/api/messages"),
                            MsaAppId = "00000000-0000-0000-0000-000000000000",
                        },
                    };
                infra.Add(bot);
                #endregion

                return infra;
            });
    }

    [Test]
    public async Task CreateBot()
    {
        await using Trycep test = CreateBotTest();
        test.Compare(
            """
            @description('The location for the resource(s) to be deployed.')
            param location string = resourceGroup().location

            resource bot 'Microsoft.BotService/botServices@2023-09-15-preview' = {
              name: take('bot-${uniqueString(resourceGroup().id)}', 24)
              tags: {
                environment: 'test'
              }
              location: location
              properties: {
                displayName: 'sample-bot'
                endpoint: 'https://example.com/api/messages'
                msaAppId: '00000000-0000-0000-0000-000000000000'
              }
              sku: {
                name: 'F0'
              }
              kind: 'bot'
            }
            """);
    }
}
