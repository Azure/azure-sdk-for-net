// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

namespace Microsoft.Azure.Monitor.OpenTelemetry.Exporter
{
    internal enum PartBType
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
