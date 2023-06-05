// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    [Flags]
    internal enum OperationType
    {
        Unknown = 0,
        Azure = 1 << 0,
        Common = 1 << 1,
        Db = 1 << 2,
        FaaS = 1 << 3,
        Http = 1 << 4,
        Messaging = 1 << 5,
        Rpc = 1 << 6
    };
}
