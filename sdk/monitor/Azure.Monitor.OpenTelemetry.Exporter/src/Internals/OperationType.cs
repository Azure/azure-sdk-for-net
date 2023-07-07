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
        V2 = 128
    }
}
