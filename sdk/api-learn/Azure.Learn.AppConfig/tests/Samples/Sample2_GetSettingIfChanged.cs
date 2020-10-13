// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Learn.AppConfig.Tests;
using NUnit.Framework;

namespace Azure.Learn.AppConfig.Samples
{
    public class Sample2_GetSettingIfChanged : SamplesBase<LearnAppConfigTestEnvironment>
    {
        [Test]
        public async Task GetConfigurationSettingIfChanged()
        {
            string endpoint = Environment.GetEnvironmentVariable("API-LEARN_ENDPOINT");

            ConfigurationClient client = new ConfigurationClient(new Uri(endpoint), new DefaultAzureCredential());

            Dictionary<string, ConfigurationSetting> settingCache = new Dictionary<string, ConfigurationSetting>();
            await InitializeCacheAsync(client, settingCache);
            PrintGreeting(settingCache);

            for (int i = 0; i < 4; i++)
            {
                await UpdateCacheAsync(client, settingCache);
                PrintGreeting(settingCache);

                await Task.Delay(2000);
            }
        }

        private async Task InitializeCacheAsync(ConfigurationClient client, Dictionary<string, ConfigurationSetting> cache)
        {
            cache["FontColor"] = await client.GetConfigurationSettingAsync("FontColor");
            cache["GreetingText"] = await client.GetConfigurationSettingAsync("GreetingText");
        }

        public async Task UpdateCacheAsync(ConfigurationClient client, Dictionary<string, ConfigurationSetting> cache)
        {
            Response<ConfigurationSetting> response = await client.GetConfigurationSettingAsync(cache["FontColor"], onlyIfChanged: true);
            if (response.GetRawResponse().Status == (int)HttpStatusCode.NotModified)
            {
                Console.WriteLine("ConfigurationSetting 'FontColor' has not changed since it was cached.");
            }
            else
            {
                cache["FontColor"] = response.Value;
            }
            response = await client.GetConfigurationSettingAsync(cache["GreetingText"], onlyIfChanged: true);
            if (response.GetRawResponse().Status == (int)HttpStatusCode.NotModified)
            {
                Console.WriteLine("ConfigurationSetting 'GreetingText' has not changed since it was cached.");
            }
            else
            {
                cache["GreetingText"] = response.Value;
            }
        }

        public void PrintGreeting(Dictionary<string, ConfigurationSetting> cache)
        {
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), cache["FontColor"].Value);
            Console.WriteLine(cache["GreetingText"].Value);
            Console.ResetColor();
        }
    }
}
