//Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using Azure.Data.AppConfiguration;
using Azure.Test.Perf;

namespace Azure.Storage.Blobs.Perf.Scenarios
{
    /// <summary>
    /// The performance test scenario focused on downloading blobs from the Azure blobs storage.
    /// </summary>
    /// <seealso cref="Azure.Test.Perf.PerfTest{StorageTransferOptionsOptions}" />
    public sealed class GetConfigurationSettings : PerfTest<CountOptions>
    {
        private static string _prefix = Guid.NewGuid().ToString("N");
        private static SettingSelector _filter = new SettingSelector() { KeyFilter = _prefix + "*" };

        private readonly ConfigurationClient _configurationClient;

        public GetConfigurationSettings(CountOptions options) : base(options)
        {
            _configurationClient = new ConfigurationClient(PerfTestEnvironment.Instance.ConnectionString);
        }

        public override async Task GlobalSetupAsync()
        {
            await base.GlobalSetupAsync();

            for (int i = 0; i < Options.Count; i++)
            {
                await _configurationClient.SetConfigurationSettingAsync(_prefix + i, i.ToString());
            }
        }

        public override void Run(CancellationToken cancellationToken)
        {
            foreach (var _ in _configurationClient.GetConfigurationSettings(_filter))
            {
            }
        }

        public override async Task RunAsync(CancellationToken cancellationToken)
        {
            await foreach (var _ in _configurationClient.GetConfigurationSettingsAsync(_filter))
            {
            }
        }

        public override async Task GlobalCleanupAsync()
        {
            await foreach (var setting in _configurationClient.GetConfigurationSettingsAsync(_filter))
            {
                await _configurationClient.DeleteConfigurationSettingAsync(setting);
            }
        }
    }
}
