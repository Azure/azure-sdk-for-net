// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure.Core.Pipeline;
using NUnit.Framework;
using System;
using System.Net.Http;

namespace Azure.Data.AppConfiguration.Samples
{
    [Category("Live")]
    public partial class ConfigurationSamples
    {
        HttpClient s_client = new HttpClient();

        [Test]
        public void ConfiguringPipeline()
        {
            // this instance will hold pipeline creation options
            var options = new ConfigurationClientOptions();

            // specify custon HttpClient
            options.Transport = new HttpClientTransport(s_client);

            // remove logging policy
            options.Diagnostics.IsLoggingEnabled = false;

            // specify custom retry policy options
            options.Retry.Mode = RetryMode.Fixed;
            options.Retry.MaxRetries = 10;
            options.Retry.Delay = TimeSpan.FromSeconds(1);

            // add a policy (custom behavior) that executes once per client call
            options.AddPolicy(HttpPipelinePosition.PerCall, new AddHeaderPolicy());

            // add a policy that executes once per retry
            options.AddPolicy(HttpPipelinePosition.PerRetry, new CustomLogPolicy());

            var connectionString = Environment.GetEnvironmentVariable("APPCONFIGURATION_CONNECTION_STRING");
            // pass the policy options to the client
            var client = new ConfigurationClient(connectionString, options);

            client.Set(new ConfigurationSetting("some_key", "some_value"));
            client.Delete("some_key");
        }

        class AddHeaderPolicy : SynchronousHttpPipelinePolicy
        {
            public override void OnSendingRequest(HttpPipelineMessage message)
            {
                message.Request.Headers.Add("User-Agent", "ConfiguraingPipelineSample");
            }
        }

        class CustomLogPolicy : SynchronousHttpPipelinePolicy
        {
            public override void OnSendingRequest(HttpPipelineMessage message)
            {
                Console.WriteLine(message.ToString());
            }
        }
    }
}
