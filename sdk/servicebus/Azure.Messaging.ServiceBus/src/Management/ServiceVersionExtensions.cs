// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using static Azure.Messaging.ServiceBus.Management.ServiceBusManagementClientOptions;

namespace Azure.Messaging.ServiceBus.Management
{
    internal static class ServiceVersionExtensions
    {
        internal static string ToVersionString(this ServiceVersion version)
        {
            return version switch
            {
                ServiceVersion.V2017_04 => "2017-04",
                _ => throw new ArgumentException($"Version {version} not supported."),
            };
        }
    }
}
