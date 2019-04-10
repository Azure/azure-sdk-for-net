// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure.Base.Pipeline.Policies;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Azure.ApplicationModel.Configuration.Samples
{
    [Category("Live")]
    public partial class ConfigurationSamples
    {
        [Test]
        public async Task ConfiguringRetries()
        {
            // specify retry policy options
            var options = new ConfigurationClientOptions();
            options.RetryPolicy = new FixedRetryPolicy()
            {
                MaxRetries = 10,
                Delay = TimeSpan.FromSeconds(1),
                RetriableCodes = new [] {
                    500, // Internal Server Error
                    504  // Gateway Timeout
                }
            };

            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");

            // pass the policy options to the client
            var client = new ConfigurationClient(connectionString, options);

            await client.SetAsync(new ConfigurationSetting("some_key", "some_value"));
            await client.DeleteAsync("some_key");
        }
    }
}
