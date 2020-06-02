// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
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
            Options options = null;
            ParserResult<Options> result = Parser.Default.ParseArguments<Options>(args)
                .WithParsed(parsedOptions => { options = parsedOptions; })
                .WithNotParsed(errors => Options.HandleParseError(errors));

            var httpClient = new HttpClient();
            DigitalTwinsClient dtClient = GetDigitalTwinsClient(
                options.TenantId,
                options.ClientId,
                options.ClientSecret,
                options.AdtEndpoint,
                httpClient);

            var dtLifecycleSamples = new DigitalTwinsLifecycleSamples(dtClient, options.EventHubName);
            await dtLifecycleSamples.RunSamplesAsync().ConfigureAwait(false);

            var modelLifecycleSamples = new ModelLifecycleSamples(dtClient);
            await modelLifecycleSamples.RunSamplesAsync().ConfigureAwait(false);

            var componentSamples = new ComponentSamples(dtClient);
            await componentSamples.RunSamplesAsync().ConfigureAwait(false);

            var publishTelemetrySamples = new PublishTelemetrySamples(dtClient);
            await publishTelemetrySamples.RunSamplesAsync().ConfigureAwait(false);

            httpClient.Dispose();
        }

        /// <summary>
        /// Illustrates how to construct a <see cref="DigitalTwinsClient"/> with the fewest required parameters,
        /// using the <see cref="ClientSecretCredential"/> implementation of <see cref="Azure.Core.TokenCredential"/>.
        /// </summary>
        /// <param name="tenantId">The Id of the tenant of the application Id.</param>
        /// <param name="clientId">The application Id.</param>
        /// <param name="clientSecret">A client secret for the application Id.</param>
        /// <param name="adtEndpoint">The endpoint of the digital twins instance.</param>
        private static DigitalTwinsClient GetDigitalTwinsClient(string tenantId, string clientId, string clientSecret, string adtEndpoint)
        {
            #region Snippet:DigitalTwinSampleCreateServiceClient

            var clientSecretCredential = new ClientSecretCredential(
                tenantId,
                clientId,
                clientSecret,
                new TokenCredentialOptions { AuthorityHost = KnownAuthorityHosts.AzureCloud });

            var dtClient = new DigitalTwinsClient(
                new Uri(adtEndpoint),
                clientSecretCredential);

            #endregion Snippet:DigitalTwinSampleCreateServiceClient

            return dtClient;
        }

        /// <summary>
        /// Illustrates how to construct a <see cref="DigitalTwinsClient"/> including client options,
        /// using the <see cref="ClientSecretCredential"/> implementation of <see cref="Azure.Core.TokenCredential"/>.
        /// </summary>
        /// <param name="tenantId">The Id of the tenant of the application Id.</param>
        /// <param name="clientId">The application Id.</param>
        /// <param name="clientSecret">A client secret for the application Id.</param>
        /// <param name="adtEndpoint">The endpoint of the digital twins instance.</param>
        /// <param name="httpClient">An HttpClient instance for the client to use</param>
        private static DigitalTwinsClient GetDigitalTwinsClient(string tenantId, string clientId, string clientSecret, string adtEndpoint, HttpClient httpClient)
        {
            #region Snippet:DigitalTwinSampleCreateServiceClientWithHttpClient

            // This illustrates how to specify client options, in this case, by providing an
            // instance of HttpClient for the digital twins client to use

            var clientOptions = new DigitalTwinsClientOptions
            {
                Transport = new HttpClientTransport(httpClient),
            };

            var clientSecretCredential = new ClientSecretCredential(
                tenantId,
                clientId,
                clientSecret,
                new TokenCredentialOptions { AuthorityHost = KnownAuthorityHosts.AzureCloud });

            var dtClient = new DigitalTwinsClient(
                new Uri(adtEndpoint),
                clientSecretCredential,
                clientOptions);

            #endregion Snippet:DigitalTwinSampleCreateServiceClientWithHttpClient

            return dtClient;
        }
    }
}
