﻿// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core.Testing;
using Azure.Core.Pipeline;
using NUnit.Framework;
using System;
using System.Net.Http;
using Azure.Core;

namespace Azure.Data.AppConfiguration.Samples
{
    [LiveOnly]
    public partial class ConfigurationSamples
    {
        private readonly HttpClient _client = new HttpClient();

        [Test]
        public void ConfiguringPipeline()
        {
            // this instance will hold pipeline creation options
            var options = new ConfigurationClientOptions
            {

                // specify custon HttpClient
                Transport = new HttpClientTransport(_client)
            };

            // remove logging policy
            options.Diagnostics.IsLoggingEnabled = false;

            // specify custom retry policy options
            options.Retry.Mode = RetryMode.Fixed;
            options.Retry.MaxRetries = 10;
            options.Retry.Delay = TimeSpan.FromSeconds(1);

            // add a policy (custom behavior) that executes once per client call
            options.AddPolicy(new AddHeaderPolicy(), HttpPipelinePosition.PerCall);

            // add a policy that executes once per retry
            options.AddPolicy(new CustomLogPolicy(), HttpPipelinePosition.PerRetry);

            var connectionString = Environment.GetEnvironmentVariable("APPCONFIGURATION_CONNECTION_STRING");
            // pass the policy options to the client
            var client = new ConfigurationClient(connectionString, options);

            client.Set(new ConfigurationSetting("some_key", "some_value"));
            client.Delete("some_key");
        }

        private class AddHeaderPolicy : HttpPipelineSynchronousPolicy
        {
            public override void OnSendingRequest(HttpMessage message)
            {
                message.Request.Headers.Add("User-Agent", "ConfiguraingPipelineSample");
            }
        }

        private class CustomLogPolicy : HttpPipelineSynchronousPolicy
        {
            public override void OnSendingRequest(HttpMessage message)
            {
                Console.WriteLine(message.ToString());
            }
        }
    }
}
