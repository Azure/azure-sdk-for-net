// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
            string endpoint = "http://example.azconfig.io";
            ConfigurationClient client = new ConfigurationClient(new Uri(endpoint), new DefaultAzureCredential());

            ConfigurationSetting color = client.GetConfigurationSetting("FontColor");
            ConfigurationSetting greeting = client.GetConfigurationSetting("GreetingText");

            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color.Value);
            Console.WriteLine(greeting.Value);
            Console.ResetColor();
        }
    }
}
