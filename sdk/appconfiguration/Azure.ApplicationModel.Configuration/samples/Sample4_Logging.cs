// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using NUnit.Framework;
using System;
using System.Diagnostics;
using System.Diagnostics.Tracing;

namespace Azure.Data.AppConfiguration.Samples
{
    [Category("Live")]
    public partial class ConfigurationSamples
    {
        // ConfigurationClient logs lots of useful information automatically to .NET's EventSource.
        // This sample illustrate how to control and access the log information.
        [Test]
        public void Logging()
        {
            // Retrieve the connection string from the configuration store.
            // You can get the string from your Azure portal.
            var connectionString = Environment.GetEnvironmentVariable("APPCONFIGURATION_CONNECTION_STRING");
            var client = new ConfigurationClient(connectionString);

            // Setup a listener to monitor logged events.
            var listener = new ConsoleEventListener();
            listener.EnableEvents(EventLevel.LogAlways);

            Response<ConfigurationSetting> setResponse = client.Set(new ConfigurationSetting("some_key", "some_value"));
            if (setResponse.GetRawResponse().Status != 200)
            {
                throw new Exception("could not set configuration setting");
            }

            // Delete the setting when you don't need it anymore.
            client.Delete("some_key");
        }
    }

    public class ConsoleEventListener : EventListener
    {
        const string SOURCE_NAME = "AzureSDK";

        EventLevel _enabled;
        EventSource _source;

        protected override void OnEventSourceCreated(EventSource eventSource)
        {
            base.OnEventSourceCreated(eventSource);
            if (eventSource.Name == SOURCE_NAME) {
                _source = eventSource;
                if (_enabled != default) {
                    EnableEvents(_source, _enabled);
                }
            }
        }

        public void EnableEvents(EventLevel level)
        {
            _enabled = level;
            if (_source != null) {
                EnableEvents(_source, _enabled);
            }
        }

        protected override void OnEventWritten(EventWrittenEventArgs eventData)
        {
            if (eventData.EventSource.Name == SOURCE_NAME) {
                var formatted = eventData.EventName + " : " + eventData.Payload[0].ToString();
                Console.WriteLine(formatted);
                Debug.WriteLine(formatted);
            }
        }
    }
}
