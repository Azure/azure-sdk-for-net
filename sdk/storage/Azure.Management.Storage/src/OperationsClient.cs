// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Management.Storage
{
    [CodeGenClient("Operations")]
    public partial class OperationsClient
    {
        public OperationsClient(TokenCredential tokenCredential, StorageManagementClientOptions options): this(
            new ClientDiagnostics(options),
            HttpPipelineBuilder.Build(options, new BearerTokenAuthenticationPolicy(tokenCredential, "https://management.azure.com/")))
        {

        }
    }
}