// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Data.Tables.Performance;
using CommandLine;

namespace Azure.Test.Perf
{
    public class TablePerfOptions : CountOptions
    {
        [Option('t', "entity", Default = EntityType.Simple, HelpText = "The entity type that will be used by the test run.")]
        public EntityType EntityType { get; set; }

        [Option('s', "endpoint", Default = TableEndpointType.Storage, HelpText = "The service endpoint type that will be used by the test run.")]
        public TableEndpointType EndpointType { get; set; }
    }
}
