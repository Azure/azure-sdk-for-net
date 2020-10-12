using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Azure.Identity;
using Azure.Learn.AppConfig;

namespace Azure.Learn.AppConfig.Samples
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            var p = new Program();
            p.GetConfigurationSetting();
            await p.GetConfigurationSettingIfChanged();
        }

        public void GetConfigurationSetting()
        {
            string endpoint = Environment.GetEnvironmentVariable("API-LEARN_ENDPOINT");
            ConfigurationClient client = new ConfigurationClient(new Uri(endpoint), new DefaultAzureCredential());

            ConfigurationSetting color = client.GetConfigurationSetting("FontColor");
            ConfigurationSetting greeting = client.GetConfigurationSetting("GreetingText");

            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), color.Value);
            Console.WriteLine(greeting.Value);
            Console.ResetColor();
        }

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
            cache["FontColor"] = await client.GetConfigurationSettingAsync(cache["FontColor"], onlyIfChanged: true);
            cache["GreetingText"] = await client.GetConfigurationSettingAsync(cache["GreetingText"], onlyIfChanged: true);
        }

        public void PrintGreeting(Dictionary<string, ConfigurationSetting> cache)
        {
            Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), cache["FontColor"].Value);
            Console.WriteLine(cache["GreetingText"].Value);
            Console.ResetColor();
        }
    }
}
