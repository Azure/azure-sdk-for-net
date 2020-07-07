// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using CommandLine;

namespace Azure.Iot.Hub.Service.Samples
{
    public class CommandLineOptions
    {
        [Option('c', "iotHubConnectionString", Required = true, HelpText = "Iot Hub connection string")]
        public string IotHubConnectionString { get; set; }
    }
}
