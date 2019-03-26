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
            var options = new ConfigurationClientOptions();

            // custon HttpClient
            options.ReplaceTransport(new HttpClientTransport(s_client));

            // custom retry policy
            options.ReplaceRetryPolicy(new FixedRetryPolicy(
                maxRetries: 10,
                delay: TimeSpan.FromSeconds(1),
                retriableCodes: new int[] {
                    500, // Internal Server Error 
                    504  // Gateway Timeout
                }
            ));

            options.AddPolicy(new AddIdHeader());
            options.AddPolicy(new ConsoleLog());

            var connectionString = Environment.GetEnvironmentVariable("AZ_CONFIG_CONNECTION");

            // pass the policy options to the client
            var client = new ConfigurationClient(connectionString, options);

            await client.SetAsync(new ConfigurationSetting("some_key", "some_value"));
            await client.DeleteAsync("some_key");
        }

        class AddIdHeader : HttpPipelinePolicy
        {
            long id;

            public override async Task ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                id++;
                message.AddHeader("x-azure-id", id.ToString());
                await ProcessNextAsync(pipeline, message).ConfigureAwait(false);
            }

            public override void Register(HttpPipelineOptions options)
                => options.AddPolicy(this, HttpPipelineOptions.PolicyRunner.RunsOncePerCall);
        }

        class ConsoleLog : HttpPipelinePolicy
        {
            public override async Task ProcessAsync(HttpMessage message, ReadOnlyMemory<HttpPipelinePolicy> pipeline)
            {
                Console.WriteLine(message.ToString());
                await ProcessNextAsync(pipeline, message).ConfigureAwait(false);
            }

            public override void Register(HttpPipelineOptions options)
                => options.AddPolicy(this, HttpPipelineOptions.PolicyRunner.RuncOncePerRetry);
        }
    }
}
