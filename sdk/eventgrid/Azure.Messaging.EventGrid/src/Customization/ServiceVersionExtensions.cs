// Copyright (c) Microsoft Corporation. All rights reserved.
// Licensed under the MIT License.

using System;
using static Azure.Messaging.EventGrid.EventGridPublisherClientOptions;

namespace Azure.Messaging.EventGrid
{
    internal static class ServiceVersionExtensions
    {
        internal static string GetVersionString(this ServiceVersion version)
        {
            return version switch
            {
                ServiceVersion.V2018_01_01 => "2018-01-01",
                _ => throw new ArgumentException($"Version {version.ToString()} not supported."),
            };
        }
    }
}
