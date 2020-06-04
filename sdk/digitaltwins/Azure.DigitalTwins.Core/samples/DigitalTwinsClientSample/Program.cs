// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Net.Http;
using System.Threading.Tasks;
using Azure.Core.Pipeline;
using Azure.DigitalTwins.Samples;
using Azure.Identity;
using CommandLine;
using CommandLine.Text;

namespace Azure.DigitalTwins.Core.Samples
{
    public class Program
    {
        /// <summary>
        /// Main entry point to the sample.
        /// </summary>
        public static async Task Main(string[] args)
        {
            // Parse and validate paramters

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

            if (options.GetLoginMethod() == LoginMethod.AppId
                && string.IsNullOrWhiteSpace(options.ClientSecret))
            {
                Console.Error.WriteLine("When LoginMethod is AppId, ClientSecret parameter is required.");
                Console.Error.WriteLine(HelpText.AutoBuild(result, null, null));
                Environment.Exit(1);
            }

            // Instantiate the client

            var httpClient = new HttpClient();
            DigitalTwinsClient dtClient = (options.GetLoginMethod()) switch
            {
                LoginMethod.AppId => GetDigitalTwinsClient(
                    options.TenantId,
                    options.ClientId,
                    options.ClientSecret,
                    options.AdtEndpoint),

                LoginMethod.User => GetDigitalTwinsClient(
                    options.TenantId,
                    options.ClientId,
                    options.AdtEndpoint,
                    httpClient),

                _ => throw new Exception("Unsupported login method"),
            };

            // Run the samples

            var dtLifecycleSamples = new DigitalTwinsLifecycleSamples(dtClient, options.EventHubName);
            await dtLifecycleSamples.RunSamplesAsync();

            var modelLifecycleSamples = new ModelLifecycleSamples();
            await modelLifecycleSamples.RunSamplesAsync(dtClient);

            var componentSamples = new ComponentSamples();
            await componentSamples.RunSamplesAsync(dtClient);

            var publishTelemetrySamples = new PublishTelemetrySamples();
            await publishTelemetrySamples.RunSamplesAsync(dtClient);

            // Clean up

            httpClient.Dispose();
        }

        /// <summary>
        /// Illustrates how to construct a <see cref="DigitalTwinsClient"/>, using the <see cref="ClientSecretCredential"/>
        /// implementation of <see cref="Azure.Core.TokenCredential"/>.
        /// </summary>
        /// <param name="tenantId">The Id of the tenant of the application Id.</param>
        /// <param name="clientId">The application Id.</param>
        /// <param name="clientSecret">A client secret for the application Id.</param>
        /// <param name="adtEndpoint">The endpoint of the digital twins instance.</param>
        private static DigitalTwinsClient GetDigitalTwinsClient(string tenantId, string clientId, string clientSecret, string adtEndpoint)
        {
            #region Snippet:DigitalTwinsSampleCreateServiceClientWithClientSecret

            // By using the ClientSecretCredential, a specified application Id can login using a
            // client secret.
            var tokenCredential = new ClientSecretCredential(
                tenantId,
                clientId,
                clientSecret,
                new TokenCredentialOptions { AuthorityHost = KnownAuthorityHosts.AzureCloud });

            var client = new DigitalTwinsClient(
                new Uri(adtEndpoint),
                tokenCredential);

            #endregion Snippet:DigitalTwinsSampleCreateServiceClientWithClientSecret

            return client;
        }

        /// <summary>
        /// Illustrates how to construct a <see cref="DigitalTwinsClient"/> including client options,
        /// using the <see cref="InteractiveBrowserCredential"/> implementation of <see cref="Azure.Core.TokenCredential"/>.
        /// </summary>
        /// <param name="tenantId">The Id of the tenant of the application Id.</param>
        /// <param name="clientId">The application Id.</param>
        /// <param name="adtEndpoint">The endpoint of the digital twins instance.</param>
        /// <param name="httpClient">An HttpClient instance for the client to use</param>
        private static DigitalTwinsClient GetDigitalTwinsClient(string tenantId, string clientId, string adtEndpoint, HttpClient httpClient)
        {
            #region Snippet:DigitalTwinsSampleCreateServiceClientInteractiveLogin

            // This illustrates how to specify client options, in this case, by providing an
            // instance of HttpClient for the digital twins client to use.
            var clientOptions = new DigitalTwinsClientOptions
            {
                Transport = new HttpClientTransport(httpClient),
            };

            // By using the InteractiveBrowserCredential, the current user can login using a web browser
            // interactively with the AAD
            var tokenCredential = new InteractiveBrowserCredential(
                tenantId,
                clientId,
                new TokenCredentialOptions { AuthorityHost = KnownAuthorityHosts.AzureCloud });

            var client = new DigitalTwinsClient(
                new Uri(adtEndpoint),
                tokenCredential,
                clientOptions);

            #endregion Snippet:DigitalTwinsSampleCreateServiceClientInteractiveLogin

            return client;
        }
    }
}
