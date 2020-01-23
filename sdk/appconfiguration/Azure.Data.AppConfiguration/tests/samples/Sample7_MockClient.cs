// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System.Threading;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;

namespace Azure.Data.AppConfiguration.Samples
{
    public partial class ConfigurationSamples
    {
        [Test]
        public async Task MockClient()
        {
            #region Snippet:AzConfigSample7_CreateMocks
            var mockResponse = new Mock<Response>();
            var mockClient = new Mock<ConfigurationClient>();
            #endregion

            #region Snippet:AzConfigSample7_SetupMocks

            Response<ConfigurationSetting> response = Response.FromValue(ConfigurationModelFactory.ConfigurationSetting("available_vms", "10"), mockResponse.Object);
            mockClient.Setup(c => c.GetConfigurationSettingAsync("available_vms", It.IsAny<string>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(response));
            mockClient.Setup(c => c.SetConfigurationSettingAsync(It.IsAny<ConfigurationSetting>(), true, It.IsAny<CancellationToken>()))
                .Returns((ConfigurationSetting cs, bool onlyIfUnchanged, CancellationToken ct) => Task.FromResult(Response.FromValue(cs, new Mock<Response>().Object)));
            #endregion

            #region Snippet:AzConfigSample7_UseMocks
            ConfigurationClient client = mockClient.Object;
            int availableVms = await UpdateAvailableVmsAsync(client, 2, default);
            Assert.AreEqual(12, availableVms);
            #endregion
        }

        #region Snippet:AzConfigSample7_MethodToTest
        private static async Task<int> UpdateAvailableVmsAsync(ConfigurationClient client, int releasedVMs, CancellationToken cancellationToken)
        {
            while (!cancellationToken.IsCancellationRequested)
            {
                ConfigurationSetting setting = await client.GetConfigurationSettingAsync("available_vms", cancellationToken: cancellationToken);
                var availableVmsCount = int.Parse(setting.Value);
                setting.Value = (availableVmsCount + releasedVMs).ToString();

                try
                {
                    ConfigurationSetting updatedSetting = await client.SetConfigurationSettingAsync(setting, onlyIfUnchanged: true, cancellationToken);
                    return int.Parse(updatedSetting.Value);
                }
                catch (RequestFailedException e) when (e.Status == 412)
                {
                }
            }

            cancellationToken.ThrowIfCancellationRequested();
            return 0;
        }
        #endregion
    }
}
