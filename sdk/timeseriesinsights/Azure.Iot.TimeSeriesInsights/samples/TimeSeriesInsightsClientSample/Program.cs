// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Threading.Tasks;
using Azure.Identity;
using CommandLine;

namespace Azure.Iot.TimeSeriesInsights.Samples
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

            // Instantiate the client
            TimeSeriesInsightsClient dtClient = GetTimeSeriesInsightsClient(
                options.TenantId,
                options.ClientId,
                options.ClientSecret,
                options.TsiEnvironmentFqdn);

            // Run the samples

            var tsiLifecycleSamples = new TimeSeriesInsightsLifecycleSamples(dtClient, options.TsiEnvironmentFqdn);
            await tsiLifecycleSamples.RunSamplesAsync();
        }

        /// <summary>
        /// Illustrates how to construct a <see cref="TimeSeriesInsightsClient"/>, using the <see cref="DefaultAzureCredential"/>
        /// implementation of <see cref="Azure.Core.TokenCredential"/>.
        /// </summary>
        /// <param name="tsiEndpoint">The endpoint of the Time Series Insights instance.</param>
        private static TimeSeriesInsightsClient GetTimeSeriesInsightsClient(string tenantId, string clientId, string clientSecret, string tsiEndpoint)
        {
            // These environment variables are necessary for DefaultAzureCredential to use application Id and client secret to login.
            Environment.SetEnvironmentVariable("AZURE_CLIENT_SECRET", clientSecret);
            Environment.SetEnvironmentVariable("AZURE_CLIENT_ID", clientId);
            Environment.SetEnvironmentVariable("AZURE_TENANT_ID", tenantId);

            #region Snippet:TimeSeriesInsightsSampleCreateServiceClientWithClientSecret

            // DefaultAzureCredential supports different authentication mechanisms and determines the appropriate credential type based of the environment it is executing in.
            // It attempts to use multiple credential types in an order until it finds a working credential.
            var tokenCredential = new DefaultAzureCredential();

            var client = new TimeSeriesInsightsClient(
                tsiEndpoint,
                tokenCredential);

            #endregion Snippet:TimeSeriesInsightsSampleCreateServiceClientWithClientSecret

            return client;
        }
    }
}
