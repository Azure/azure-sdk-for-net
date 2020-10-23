// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.Core.TestFramework;
using NUnit.Framework;

namespace Azure.Learn.AppConfig.Tests
{
    public class ConfigurationClientLiveTests : RecordedTestBase<LearnAppConfigTestEnvironment>
    {
        public ConfigurationClientLiveTests(bool isAsync) : base(isAsync, RecordedTestMode.Record)
        {
            //...
        }

        [RecordedTest]
        public async Task GetSetting()
        {
            // arrange
            ConfigurationClient service = GetClient();
            string settingKey = TestEnvironment.SettingKey;
            string settingValue = TestEnvironment.SettingValue;


            // act
            ConfigurationSetting setting = await service.GetConfigurationSettingAsync(settingKey);

            // assert
            Assert.AreEqual(settingKey, setting.Key);
            Assert.AreEqual(settingValue, setting.Value);
        }

        private ConfigurationClient GetClient()
        {
            string endpoint = TestEnvironment.Endpoint;

            // The TestEnvironment.Credential represents a credential that
            // support Azure Active Directory. It is created from the TENANT_ID,
            // CLIENT_ID, and CLIENT_SECRET environment variables.
            TokenCredential credential = TestEnvironment.Credential;

            // instrumenting the client options will allow the recording to work
            var options = InstrumentClientOptions(new ConfigurationClientOptions());
            // instrumenting the client will add the sync tests as well as adding the diagnostic tracing validation
            return InstrumentClient(
                new ConfigurationClient(new Uri(endpoint), credential, options));
        }
    }
}
