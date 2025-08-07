// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Microsoft.CoreWCF.Azure.StorageQueues.Channels
{
    internal class TransportDefaults
    {
        //max size of Azure Queue message can be upto 64KB
        internal const long DefaultMaxMessageSize = 8000L;

        internal static readonly TimeSpan ReceiveMessagevisibilityTimeout = TimeSpan.FromMinutes(15);
        internal const AzureClientCredentialType DefaultClientCredentialType = AzureClientCredentialType.Default;
    }
}
