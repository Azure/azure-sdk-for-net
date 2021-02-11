// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using static Azure.Messaging.ServiceBus.Administration.ServiceBusAdministrationClientOptions;

namespace Azure.Messaging.ServiceBus.Administration
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
