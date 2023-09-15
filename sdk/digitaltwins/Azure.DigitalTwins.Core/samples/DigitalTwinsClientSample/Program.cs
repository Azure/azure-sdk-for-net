// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Core;
using Azure.DigitalTwins.Samples;
using Azure.Identity;
using CommandLine;

namespace Azure.DigitalTwins.Core.Samples
{
    public class Program
    {
        /// <summary>
        /// Main entry point to the sample.
        /// </summary>
        public static async Task Main(string[] args)
        {
            // Parse and validate parameters
            Options options = null;
            ParserResult<Options> result = Parser.Default.ParseArguments<Options>(args)
                .WithParsed(parsedOptions =>
                    {
                        options = parsedOptions;
                    })
                .WithNotParsed(errors =>
                    {
                        Environment.Exit(1);
                    });

            // Instantiate the client
            DigitalTwinsClient dtClient = GetDigitalTwinsClient(
                options.TenantId,
                options.ClientId,
                options.ClientSecret,
                options.AdtEndpoint);

            // Run the samples

            var dtLifecycleSamples = new DigitalTwinsLifecycleSamples(dtClient, options.EventHubEndpointName);
            await dtLifecycleSamples.RunSamplesAsync();

            var modelLifecycleSamples = new ModelLifecycleSamples();
            await modelLifecycleSamples.RunSamplesAsync(dtClient);

            var jobLifecycleSamples = new JobLifecycleSamples();
            await jobLifecycleSamples.RunSamplesAsync(dtClient, options);

            var componentSamples = new ComponentSamples();
            await componentSamples.RunSamplesAsync(dtClient);

            var publishTelemetrySamples = new PublishTelemetrySamples();
            await publishTelemetrySamples.RunSamplesAsync(dtClient);

            var relationshipSamples = new RelationshipSamples();
            await relationshipSamples.RunSamplesAsync(dtClient);
        }

        /// <summary>
        /// Illustrates how to construct a <see cref="DigitalTwinsClient"/>, using the <see cref="DefaultAzureCredential"/>
        /// implementation of <see cref="Azure.Core.TokenCredential"/>.
        /// </summary>
        /// <param name="adtEndpoint">The endpoint of the digital twins instance.</param>
        private static DigitalTwinsClient GetDigitalTwinsClient(string tenantId, string clientId, string clientSecret, string adtEndpoint)
        {
            // These environment variables are necessary for DefaultAzureCredential to use application Id and client secret to login.
            Environment.SetEnvironmentVariable("AZURE_CLIENT_SECRET", clientSecret);
            Environment.SetEnvironmentVariable("AZURE_CLIENT_ID", clientId);
            Environment.SetEnvironmentVariable("AZURE_TENANT_ID", tenantId);

            #region Snippet:DigitalTwinsSampleCreateServiceClientWithClientSecret

            // DefaultAzureCredential supports different authentication mechanisms and determines the appropriate credential type based of the environment it is executing in.
            // It attempts to use multiple credential types in an order until it finds a working credential.
            TokenCredential tokenCredential = new DefaultAzureCredential();

            var client = new DigitalTwinsClient(
                new Uri(adtEndpoint),
                tokenCredential);

            #endregion Snippet:DigitalTwinsSampleCreateServiceClientWithClientSecret

            return client;
        }
    }
}
