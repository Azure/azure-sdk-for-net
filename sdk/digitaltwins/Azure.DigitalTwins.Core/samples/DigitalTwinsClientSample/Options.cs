// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using System.Collections.Generic;
using CommandLine;

namespace Azure.DigitalTwins.Core.Samples
{
    public class Options
    {
        public Options(string adtEndpoint, string clientId, string tenantId, string clientSecret, string eventHubName)
        {
            AdtEndpoint = adtEndpoint;
            ClientId = clientId;
            TenantId = tenantId;
            ClientSecret = clientSecret;
            EventHubName = eventHubName;
        }

        [Option("adtEndpoint", Required = true, HelpText = "Digital twins service endpoint")]
        public string AdtEndpoint { get; }

        [Option("clientId", Required = true, HelpText = "Application client Id")]
        public string ClientId { get; }

        [Option("tenantId", Required = true, HelpText = "Application tenant Id")]
        public string TenantId { get; }

        [Option("clientSecret", Required = true, HelpText = "Application client secret")]
        public string ClientSecret { get; }

        [Option("eventHubName", Required = true, HelpText = "Event Hub Name linked to digital twins instance")]
        public string EventHubName { get; }

        public static void HandleParseError(IEnumerable<Error> errors)
        {
            if (errors.IsVersion())
            {
                Console.WriteLine("1.0.0");
                return;
            }

            if (errors.IsHelp())
            {
                Console.WriteLine("Usage: .\\DigitalTwinServiceClientSample.exe " +
                    "--adtEndpoint <yourAdtEndpointName> " +
                    "--clientId <yourApplicationClientId> " +
                    "--tenantId <yourApplicationTenantId> " +
                    "--clientSecret <yourApplicationClientSecret>" +
                    "--eventHubName <yourEventHubName>");
                return;
            }

            Console.WriteLine("Parser Fail");
        }
    }
}
