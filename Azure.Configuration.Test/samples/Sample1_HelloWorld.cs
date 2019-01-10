using NUnit.Framework;
using System;
using System.Threading.Tasks;
using Azure.Core;

namespace Azure.Configuration.Samples
{
    [Category("Live")]
    public partial class ConfigurationSamples
    {
        [Test]
        public async Task HelloWorld()
        {
            // Retrieve the connection string from the configuration store. 
            // You can get the string from your Azure portal.
            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");

            // Instantiate a client that will be used to call the service.
            var client = new ConfigurationClient(connectionString);

            // Create a setting to be stored by the configuration service.
            var setting = new ConfigurationSetting();
            setting.Key = "some_key"; // the key is a free form string, i.e. up to you what it is.
            setting.Value = "some_value"; // same with the value.

            // SetAsyc adds a new setting to the store or overrides an existing setting.
            // Alternativelly you can call AddAsync which only succeeds if the setting does not already exist in the store.
            // Or you can call UpdateAsync to update a setting that is already present in the store.
            Response<ConfigurationSetting> setResponse = await client.SetAsync(setting);
            if (setResponse.Status != 200)
            {
                throw new Exception("could not set configuration setting");
            }

            // Retrieve a previously stored setting by calling GetAsync.
            Response<ConfigurationSetting> getResponse = await client.GetAsync("some_key");
            if (getResponse.Status != 200)
            {
                throw new Exception("could not set configuration setting");
            }
            ConfigurationSetting retrieved = getResponse.Result;
            string retrievedValue = retrieved.Value;

            // Delete the setting when you don't need it anymore.
            Response<ConfigurationSetting> deleteResponse = await client.DeleteAsync("some_key");
        }
    }
}
