// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using Azure.Core;
using Azure.ResourceManager.BotService.Models;
using Azure.ResourceManager.Models;
using Azure.ResourceManager.Resources.Models;
using NUnit.Framework;

namespace Azure.ResourceManager.BotService.Tests.Helpers
{
    public class ResourceDataHelpers
    {
        public static void AssertResource(ResourceData r1, ResourceData r2)
        {
            Assert.That(r2.Name, Is.EqualTo(r1.Name));
            Assert.That(r2.Id, Is.EqualTo(r1.Id));
            Assert.That(r2.ResourceType, Is.EqualTo(r1.ResourceType));
        }

        public static void AssertTrackedResource(TrackedResourceData r1, TrackedResourceData r2)
        {
            Assert.That(r2.Name, Is.EqualTo(r1.Name));
            Assert.That(r2.Id, Is.EqualTo(r1.Id));
            Assert.That(r2.ResourceType, Is.EqualTo(r1.ResourceType));
            Assert.That(r2.Location, Is.EqualTo(r1.Location));
            Assert.That(r2.Tags, Is.EqualTo(r1.Tags));
        }

        #region BotService
        public static BotData GetBotData(string msaAppId)
        {
            var data = new BotData(new AzureLocation("global"))
            {
                Properties = new BotProperties("TestBot", new Uri("https://mybot.coffee"), msaAppId)
                {
                    Description = "The description of the bot",
                },
                Sku = new BotServiceSku(BotServiceSkuName.F0),
                Kind = BotServiceKind.Sdk,
                Tags =
                {
                    ["tag1"] = "value1",
                    ["tag2"] = "value2",
                },
            };
            return data;
        }

        public static void AssertBotServiceData(BotData data1, BotData data2)
        {
            AssertTrackedResource(data1, data2);
            Assert.That(data2.Properties.AppPasswordHint, Is.EqualTo(data1.Properties.AppPasswordHint));
            Assert.That(data2.Properties.DisplayName, Is.EqualTo(data1.Properties.DisplayName));
            Assert.That(data2.Kind, Is.EqualTo(data1.Kind));
        }
        #endregion

        #region BotChannel
        public static BotChannelData GetEmailChannelData()
        {
            BotChannelData data = new BotChannelData(new AzureLocation("global"))
            {
                Properties = new EmailChannel()
                {
                    Properties = new EmailChannelProperties("carlostestsdk2@outlook.com", true)
                    {
                        Password = "123456"
                    }
                }
            };
            return data;
        }

        public static BotChannelData GetDirectLineSpeechChannelData()
        {
            BotChannelData data = new BotChannelData(new AzureLocation("global"))
            {
                Properties = new DirectLineSpeechChannel()
                {
                    Properties = new DirectLineSpeechChannelProperties()
                    {
                        CognitiveServiceRegion = "XcognitiveServiceRegionX",
                        CognitiveServiceSubscriptionKey = "XcognitiveServiceSubscriptionKeyX",
                        IsEnabled = true,
                    },
                }
            };
            return data;
        }

        public static BotChannelData GetLineChannelData()
        {
            BotChannelData data = new BotChannelData(AzureLocation.WestUS)
            {
                Properties = new LineChannel()
                {
                    Properties = new LineChannelProperties(new LineRegistration[]
                    {
                        new LineRegistration()
                        {
                            ChannelSecret = "channelSecret",
                            ChannelAccessToken = "channelAccessToken",
                        }
                    }),
                }
            };
            return data;
        }

        public static void AssertBotChannel(BotChannelData data1, BotChannelData data2)
        {
            AssertTrackedResource(data1, data2);
            Assert.That(data2.Sku, Is.EqualTo(data1.Sku));
            Assert.That(data2.Kind, Is.EqualTo(data1.Kind));
            Assert.That(data2.Properties.ProvisioningState, Is.EqualTo(data1.Properties.ProvisioningState));
        }
        #endregion

        #region ConnectionSetting
        public static BotConnectionSettingData GetBotConnectionSettingData(string clientId, string ClientSecret, string providerId)
        {
            BotConnectionSettingData data = new BotConnectionSettingData(new AzureLocation("global"))
            {
                Properties = new BotConnectionSettingProperties()
                {
                    ClientId = clientId,
                    ClientSecret = ClientSecret,
                    ServiceProviderId = providerId,
                    Parameters =
                    {
                        new BotConnectionSettingParameter()
                        {
                        Key = "key11",
                        Value = "value1",
                        },
                        new BotConnectionSettingParameter()
                        {
                        Key = "key2",
                        Value = "value2",
                        }
                    }
                },
                ETag = new ETag("etag1"),
                Tags =
                {
                    ["tag1"] = "value1",
                    ["tag2"] = "value2",
                }
            };
            return data;
        }

        public static void AssertBotConnectionSettingData(BotConnectionSettingData data1, BotConnectionSettingData data2)
        {
            AssertTrackedResource(data1, data2);
            Assert.That(data2.Sku, Is.EqualTo(data1.Sku));
            Assert.That(data2.Kind, Is.EqualTo(data1.Kind));
            Assert.That(data2.Properties.Parameters.Count, Is.EqualTo(data1.Properties.Parameters.Count));
        }
        #endregion
    }
}
