// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Azure.Monitor.OpenTelemetry.Exporter.Internals
{
    internal enum OperationType
    {
        Unknown,
        Azure,
        Common,
        Db,
        FaaS,
        Http,
        Messaging,
        Rpc
    };
}
