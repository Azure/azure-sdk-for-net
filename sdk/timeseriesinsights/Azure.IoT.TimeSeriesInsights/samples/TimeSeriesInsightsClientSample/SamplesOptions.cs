// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using CommandLine;

namespace Azure.IoT.TimeSeriesInsights.Samples
{
    /// <summary>
    /// A class used to parse the parameters passed into the sample
    /// </summary>
    public class SamplesOptions
    {
        /// <summary>
        /// The Time Series Insights environment FQDN.
        /// </summary>
        [Option('a', "tsiEnvironmentFqdn", Required = true, HelpText = "Time Series Insights environment FQDN")]
        public string TsiEnvironmentFqdn { get; set; }

        /// <summary>
        /// The IoT hub connection string.
        /// </summary>
        [Option('c', "iotHubConnectionString", Required = false, HelpText = "IoT Hub connection string. Required for the Query sample.")]
        public string IoTHubConnectionString { get; set; }
    }
}
