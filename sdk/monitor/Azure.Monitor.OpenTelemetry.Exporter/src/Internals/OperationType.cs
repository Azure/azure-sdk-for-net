// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    [Flags]
    internal enum OperationType
    {
        Unknown = 0,
        Azure = 1,
        Common = 2,
        Db = 4,
        FaaS = 8,
        Http = 16,
        Messaging = 32,
        Rpc = 64,
        // TODO: "V2" is no longer needed and should be removed.
        // TODO: https://github.com/Azure/azure-sdk-for-net/pull/37357/files#r1253383825
        // Check if V2 could be moved outside of this Enum.
        V2 = 128
    }
}
