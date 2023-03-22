// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using CommandLine;

namespace Azure.DigitalTwins.Core.Samples
{
    public class Options
    {
        [Option('a', "adtEndpoint", Required = true, HelpText = "Digital twins service endpoint")]
        public string AdtEndpoint { get; set; }

        [Option('i', "clientId", Required = true, HelpText = "Client Id of the application Id to login, or the application Id used to log the user in.")]
        public string ClientId { get; set; }

        [Option('t', "tenantId", Required = true, HelpText = "Application tenant Id")]
        public string TenantId { get; set; }

        [Option('s', "clientSecret", Required = false, HelpText = "Application client secret. Only applicable when using LoginMethod of AppId.")]
        public string ClientSecret { get; set; }

        [Option('e', "eventHubEndpointName", Required = true, HelpText = "Event Hub endpoint linked to digital twins instance")]
        public string EventHubEndpointName { get; set; }

        [Option('o', "storageAccountEndpoint", Required = true, HelpText = "Storage account Uri")]
        public string StorageAccountEndpoint { get; set; }

        [Option('c', "storageAccountContainerName", Required = true, HelpText = "Storage account container name with permissions for adt instance")]
        public string StorageAccountContainerName { get; set; }
    }
}
