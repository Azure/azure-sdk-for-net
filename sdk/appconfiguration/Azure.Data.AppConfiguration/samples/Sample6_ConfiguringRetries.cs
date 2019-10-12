﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;
using NUnit.Framework;
using System;
using Azure.Core;

namespace Azure.Data.AppConfiguration.Samples
{
    [LiveOnly]
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

            var connectionString = Environment.GetEnvironmentVariable("APPCONFIGURATION_CONNECTION_STRING");

            // pass the policy options to the client
            var client = new ConfigurationClient(connectionString, options);

            client.Set(new ConfigurationSetting("some_key", "some_value"));
            client.Delete("some_key");
        }
    }
}
