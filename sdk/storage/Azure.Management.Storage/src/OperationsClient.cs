// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Management.Storage
{
    public partial class OperationsClient
    {
        public OperationsClient(TokenCredential tokenCredential): this(tokenCredential, StorageManagementClientOptions.Default)
        {
        }

        public OperationsClient(TokenCredential tokenCredential, StorageManagementClientOptions options):
            this(new ClientDiagnostics(options), ManagementClientPipeline.Build(options, tokenCredential))
        {
        }
    }
}