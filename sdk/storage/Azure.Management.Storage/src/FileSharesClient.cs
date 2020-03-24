// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using Azure.Core;
using Azure.Core.Pipeline;

namespace Azure.Management.Storage
{
    public partial class FileSharesClient
    {
        public FileSharesClient(string subscriptionId, TokenCredential tokenCredential): this(subscriptionId, tokenCredential, StorageManagementClientOptions.Default)
        {
        }

        public FileSharesClient(string subscriptionId, TokenCredential tokenCredential, StorageManagementClientOptions options):
            this(new ClientDiagnostics(options), ManagementClientPipeline.Build(options, tokenCredential), subscriptionId, apiVersion: options.VersionString)
        {
        }
    }
}