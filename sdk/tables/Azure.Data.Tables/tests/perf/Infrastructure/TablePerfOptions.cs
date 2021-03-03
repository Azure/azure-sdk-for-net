// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Data.Tables.Performance;
using CommandLine;

namespace Azure.Test.Perf
{
    public class TablePerfOptions : CountOptions
    {
        [Option('e', "endpoint", Default = TableEndpointType.Storage, HelpText = "The service endpoint type that will be used by the test run.")]
        public TableEndpointType EndpointType { get; set; }
    }
}
