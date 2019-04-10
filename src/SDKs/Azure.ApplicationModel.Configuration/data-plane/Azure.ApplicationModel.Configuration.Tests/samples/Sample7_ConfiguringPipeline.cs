// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure.Base.Pipeline;
using Azure.Base.Pipeline.Policies;
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
                Delay = TimeSpan.FromSeconds(1),
                RetriableCodes = new [] {
                    500, // Internal Server Error
                    504  // Gateway Timeout
                }
            };

            // add a policy (custom behavior) that executes once per client call
            options.PerCallPolicies.Add(new AddHeaderPolicy());

            // add a policy that executes once per retry
            options.PerRetryPolicies.Add(new CustomLogPolicy());

            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            // pass the policy options to the client
            var client = new ConfigurationClient(connectionString, options);

            await client.SetAsync(new ConfigurationSetting("some_key", "some_value"));
            await client.DeleteAsync("some_key");
        }

        class AddHeaderPolicy : HttpPipelinePolicy
        {
            public override async Task ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                message.Request.AddHeader("User-Agent", "ConfiguraingPipelineSample");
                await ProcessNextAsync(pipeline, message).ConfigureAwait(false);
            }
        }

        class CustomLogPolicy : HttpPipelinePolicy
        {
            public override async Task ProcessAsync(HttpPipelineMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                Console.WriteLine(message.ToString());
                await ProcessNextAsync(pipeline, message).ConfigureAwait(false);
            }
        }
    }
}
