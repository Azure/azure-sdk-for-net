// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using CommandLine;

namespace Azure.Iot.TimeSeriesInsights.Samples
{
    /// <summary>
    /// A class used to parse the parameters passed into the sample
    /// </summary>
    public class Options
    {
        /// <summary>
        /// The Time Series Insights environment FQDN.
        /// </summary>
        [Option('a', "tsiEnvironmentFqdn", Required = true, HelpText = "Time Series Insights environment FQDN")]
        public string TsiEnvironmentFqdn { get; set; }

        /// <summary>
        /// The application Id used to log the user in.
        /// </summary>
        [Option('i', "clientId", Required = true, HelpText = "Client Id of the application Id to login, or the application Id used to log the user in.")]
        public string ClientId { get; set; }

        /// <summary>
        /// The tenant Id used when logging the user in.
        /// </summary>
        [Option('t', "tenantId", Required = true, HelpText = "Application tenant Id")]
        public string TenantId { get; set; }

        /// <summary>
        /// The application client secret.
        /// </summary>
        [Option('s', "clientSecret", Required = false, HelpText = "Application client secret. Only applicable when using LoginMethod of AppId.")]
        public string ClientSecret { get; set; }
    }
}
