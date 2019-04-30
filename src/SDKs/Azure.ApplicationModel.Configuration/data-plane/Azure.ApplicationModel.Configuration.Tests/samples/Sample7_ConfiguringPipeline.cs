// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure.Core.Pipeline;
using Azure.Core.Pipeline.Policies;
using NUnit.Framework;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Azure.ApplicationModel.Configuration.Samples
{
    [Category("Live")]
    public partial class ConfigurationSamples
    {
        HttpClient s_client = new HttpClient();

        [Test]
        public async Task ConfiguringPipeline()
        {
            // this instance will hold pipeline creation options
            var options = new ConfigurationClientOptions();

            // specify custon HttpClient
            options.Transport = new HttpClientTransport(s_client);

            // remove logging policy
            options.LoggingPolicy = null;

            // specify custom retry policy options
            options.RetryPolicy = new FixedRetryPolicy()
            {
                MaxRetries = 10,
                Delay = TimeSpan.FromSeconds(1)
            };

            // add a policy (custom behavior) that executes once per client call
            options.PerCallPolicies.Add(new AddHeaderPolicy());

            // add a policy that executes once per retry
            options.PerRetryPolicies.Add(new CustomLogPolicy());

            var connectionString = Environment.GetEnvironmentVariable("APP_CONFIG_CONNECTION");
            // pass the policy options to the client
            var client = new ConfigurationClient(connectionString, options);

            await client.SetAsync(new ConfigurationSetting("some_key", "some_value"));
            await client.DeleteAsync("some_key");
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
