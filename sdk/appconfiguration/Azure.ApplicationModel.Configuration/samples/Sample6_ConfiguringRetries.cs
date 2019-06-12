// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure.Core.Pipeline.Policies;
using NUnit.Framework;
using System;

namespace Azure.ApplicationModel.Configuration.Samples
{
    [Category("Live")]
    public partial class ConfigurationSamples
    {
        [Test]
        public void ConfiguringRetries()
        {
            // specify retry policy options
            var options = new ConfigurationClientOptions();
            options.Retry.Mode = RetryMode.Fixed;
            options.Retry.MaxRetries = 10;
            options.Retry.Delay = TimeSpan.FromSeconds(1);

            var connectionString = Environment.GetEnvironmentVariable("APP_CONFIG_CONNECTION");

            // pass the policy options to the client
            var client = new ConfigurationClient(connectionString, options);

            client.Set(new ConfigurationSetting("some_key", "some_value"));
            client.Delete("some_key");
        }
    }
}
