// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using CommandLine;

namespace Azure.Iot.TimeSeriesInsights.Samples
{
    public class Options
    {
        [Option('a', "tsiEndpoint", Required = true, HelpText = "Time Series Insights service endpoint")]
        public string TsiEndpoint { get; set; }

        [Option('i', "clientId", Required = true, HelpText = "Client Id of the application Id to login, or the application Id used to log the user in.")]
        public string ClientId { get; set; }

        [Option('t', "tenantId", Required = true, HelpText = "Application tenant Id")]
        public string TenantId { get; set; }

        [Option('s', "clientSecret", Required = false, HelpText = "Application client secret. Only applicable when using LoginMethod of AppId.")]
        public string ClientSecret { get; set; }
    }
}
