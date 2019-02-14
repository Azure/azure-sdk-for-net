// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure.Core.Http;
using Azure.Core.Http.Pipeline;
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
            var options = new PipelineOptions();
            options.RetryPolicy = RetryPolicy.CreateFixed(
                maxRetries: 10,
                delay: TimeSpan.FromSeconds(1),
                retriableCodes: new int[] {
                    500, // Internal Server Error 
                    504  // Gateway Timeout
                }
            );

            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");

            // pass the policy options to the client
            var client = new ConfigurationClient(connectionString, options);

            await client.SetAsync(new ConfigurationSetting("some_key", "some_value"));
            await client.DeleteAsync("some_key");
        }
    }
}
