// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Data.Tables
{
    // https://github.com/Azure/autorest.csharp/issues/451 .
    [CodeGenClient("TableClient")]
    internal partial class TableInternalClient
    {
        internal string version { get; }

        internal TableInternalClient(ClientDiagnostics clientDiagnostics, HttpPipeline pipeline, string url, string version = "2019-02-02")
        {
            RestClient = new TableInternalRestClient(clientDiagnostics, pipeline, url, version);
            _clientDiagnostics = clientDiagnostics;
            _pipeline = pipeline;
            this.version = version;
        }
    }
}
