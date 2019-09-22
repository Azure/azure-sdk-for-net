// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;
using NUnit.Framework;
using System;
using System.Diagnostics.Tracing;
using Azure.Core.Diagnostics;

namespace Azure.Data.AppConfiguration.Samples
{
    [LiveOnly]
    public partial class ConfigurationSamples
    {
        // AzureEventSourceListener logs lots of useful information automatically to .NET's EventSource.
        // This sample illustrate how to control and access the log information.
        [Test]
        public void Logging()
        {
            // Retrieve the connection string from the configuration store.
            // You can get the string from your Azure portal.
            var connectionString = Environment.GetEnvironmentVariable("APPCONFIGURATION_CONNECTION_STRING");
            var client = new ConfigurationClient(connectionString);

            // Setup a listener to monitor logged events.
            using AzureEventSourceListener listener = AzureEventSourceListener.CreateConsoleLogger(EventLevel.LogAlways);

            ConfigurationSetting setting = new ConfigurationSetting("some_key", "some_value");

            Response<ConfigurationSetting> setResponse = client.Set(setting);
            if (setResponse.GetRawResponse().Status != 200)
            {
                throw new Exception("could not set configuration setting");
            }

            // Delete the setting when you don't need it anymore.
            client.Delete(setting);
        }
    }
}
