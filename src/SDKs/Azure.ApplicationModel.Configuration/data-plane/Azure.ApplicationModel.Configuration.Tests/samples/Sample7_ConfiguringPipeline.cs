// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License. See License.txt in the project root for
// license information.

using Azure.Base.Http;
using Azure.Base.Http.Pipeline;
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
            var options = ConfigurationClient.CreateDefaultPipelineOptions();

            // specify custon HttpClient
            options.Transport = new HttpClientTransport(s_client);

            // specify custom retry policy options
            options.RetryPolicy = RetryPolicy.CreateFixed(
                maxRetries: 10,
                delay: TimeSpan.FromSeconds(1),
                retriableCodes: new int[] {
                    500, // Internal Server Error
                    504  // Gateway Timeout
                }
            );

            // add a policy (custom behavior) that executes once per client call
            options.AddPerCallPolicy(new AddHeaderPolicy());

            // add a policy that executes once per retry
            options.AddPerRetryPolicy(new CustomLogPolicy());

            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");
            // pass the policy options to the client
            var client = new ConfigurationClient(connectionString, options);

            await client.SetAsync(new ConfigurationSetting("some_key", "some_value"));
            await client.DeleteAsync("some_key");
        }

        class AddHeaderPolicy : HttpPipelinePolicy
        {
            public override async Task ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                message.AddHeader("User-Agent", "ConfiguraingPipelineSample");
                await ProcessNextAsync(pipeline, message).ConfigureAwait(false);
            }
        }

        class CustomLogPolicy : HttpPipelinePolicy
        {
            public override async Task ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                Console.WriteLine(message.ToString());
                await ProcessNextAsync(pipeline, message).ConfigureAwait(false);
            }
        }
    }
}
