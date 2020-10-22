// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using Azure.Core.TestFramework;
using Azure.Identity;
using Azure.Learn.AppConfig.Tests;
using NUnit.Framework;

namespace Azure.Learn.AppConfig.Samples
{
    public class Sample1_HelloWorld : SamplesBase<LearnAppConfigTestEnvironment>
    {
        [Test]
        public void GetConfigurationSetting()
        {
            var client = GetClient();

            ConfigurationSetting color = client.GetConfigurationSetting("FontColor");
            ConfigurationSetting greeting = client.GetConfigurationSetting("GreetingText");

            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color.Value);
            Console.WriteLine(greeting.Value);
            Console.ResetColor();
        }

        [Test]
        public void SetConfigurationSetting()
        {
            var client = GetClient();

            var setting = new ConfigurationSetting
            {
                ContentType = "string",
                Value = "myvalue"
            };

            for (var i = 0; i < 100; i++)
            {
                Console.WriteLine($"Set setting {i}");
                setting.Value = $"myvalue{i}";
                client.SetConfigurationSetting($"mysetting{i}", $"mylabel{i}", setting);
            }
        }

        [Test]
        public void ListConfigurationSettings()
        {
            var client = GetClient();

            Console.WriteLine();
            foreach (var setting in client.GetConfigurationSettings())
            {
                Console.WriteLine($"SETTING: {setting.Key} -> {setting.Label} -> {setting.Value}");
            }
        }

        private static ConfigurationClient GetClient()
        {
            string endpoint = "https://chrissapi-learn-azconfig-net.azconfig.io";
            return new ConfigurationClient(new Uri(endpoint), new DefaultAzureCredential());
        }
    }
}
